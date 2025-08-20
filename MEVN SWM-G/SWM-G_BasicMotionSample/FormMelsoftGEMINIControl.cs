using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSCApiCLR;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace BasicMotionSample
{
    public partial class FormMelsofGEMINIControl : Form
    {
        private SSCApiAxesMonitor sscApiAxesMonitor = null;     //SSCApiAxesMonitor class
        private SSCApiControl sscApiMotionCtrl = null;  //SSCApiControl class\

        static SSCApi sscLib = new SSCApi();
        private CoreMotion sscLib_cm = new CoreMotion(sscLib);
        Motion.LinearIntplCommand linearIntplCommand = new Motion.LinearIntplCommand();

        private bool bStart = false;
        private bool bMoinitor = true;

        private string serverUrl = "opc.tcp://localhost:52250"; //OPC UA server link
        private ApplicationConfiguration config = null;
        private ApplicationInstance app = null;
        static Session session = null;

        //data OPC
        DataValue bGeminiConnect;
        DataValue Monitor_X_Axis;
        DataValue Monitor_Y_Axis;
        WriteValue Ctrl_X_Axis = new WriteValue();
        WriteValue Ctrl_Y_Axis = new WriteValue();
        WriteValue bModeCtrl = new WriteValue();

        /// <Stream>
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        const int GWL_STYLE = -16;
        const int WS_CAPTION = 0x00C00000;
        const int WS_THICKFRAME = 0x00040000;

        private Process vcProcess;
        private bool bStartVC = false;


        public FormMelsofGEMINIControl()
        {
            InitializeComponent();
            this.Load += FormMelsofGEMINIControl_Load;
            this.Resize += FormMelsofGEMINIControl_Resize;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            session.Close();
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Interval = 10;
            labelOPCConnected.Visible = session.Connected ? true : false;
            buttonStart.Text = bStart ? "Stop" : "Start";
            buttonStart.BackColor = bStart ? Color.Green : Color.White;
            buttonMonitor.BackColor = bMoinitor ? Color.Green : Color.White;
            textBoxXTarget.Enabled = !bStart;
            textBoxYTarget.Enabled = !bStart; 

            OPCUAUpdateDevices();
            AxesUpdate();
            AxesCotrol();

            timer1.Enabled = true;
        }

        private void radioButtonControl_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonControl.Checked)
            {
                radioButtonMonitor.Checked = false;
                groupBox1.Enabled = true;
            }    
        }

        private void radioButtonMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMonitor.Checked)
            {
                radioButtonControl.Checked = false;
                groupBox1.Enabled = false;
                bStart = false;
            } 
        }

        [Obsolete]
        private void FormMelsofGEMINIControl_Load(object sender, EventArgs e)
        {
            radioButtonControl.Checked = true;
            labelOPCConnected.Visible = false;
            labelGEMINICConnected.Visible = false;
            bStartVC = false;
            if (CreateSSCApiObject())
            {
                if (sscApiAxesMonitor.CreateDevice() && sscApiMotionCtrl.CreateDevice())
                {
                    //-------------------------------------------------
                    //Initial controls.
                    sscLib.CreateDevice("C:\\Program Files\\MotionSoftware\\SWM-G\\",
                                 DeviceType.DeviceTypeNormal,
                                 0xFFFFFFFF);
                    //OPCUAInitandHandle();
                    //timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Can not CreateDevice, Window was closed");
                    Close();
                }
            }
        }

        private bool CreateSSCApiObject()
        {
            sscApiAxesMonitor = new SSCApiAxesMonitor();
            sscApiMotionCtrl = new SSCApiControl();
            return ((sscApiAxesMonitor != null) && (sscApiMotionCtrl != null));
        }

        private void buttonSrvON_Click(object sender, EventArgs e)
        {
            bool bSvOn = sscApiMotionCtrl.GetServoOnState(0)||sscApiMotionCtrl.GetServoOnState(1);
            buttonSrvON.BackColor = !bSvOn ? Color.Green : Color.White;
            sscApiMotionCtrl.ServoOn(0, !bSvOn);
            sscApiMotionCtrl.ServoOn(1, !bSvOn);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            bool bHome0 = sscApiMotionCtrl.GetServoOnState(0) ? sscApiMotionCtrl.Home(0) : false;
            bool bHome1 = sscApiMotionCtrl.GetServoOnState(1) ? sscApiMotionCtrl.Home(1) : false;  
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            bStart = !bStart;
        }

        [Obsolete]
        private void OPCUAInitandHandle()
        {
            // Bước 1: Tạo cấu hình ứng dụng
            config = new ApplicationConfiguration()
            {
                ApplicationName = "MyOpcUaClient",
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier(),
                    AutoAcceptUntrustedCertificates = true,
                    AddAppCertToTrustedStore = true
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
            };
            // Bước 2: Tạo application instance
            app = new ApplicationInstance
            {
                ApplicationName = "MyOpcUaClient",
                ApplicationType = ApplicationType.Client,
                ApplicationConfiguration = config
            };

            try
            {
                // Bước 3: Kết nối đến server
                var selectedEndpoint = CoreClientUtils.SelectEndpoint(serverUrl, useSecurity: false);
                var endpointConfig = EndpointConfiguration.Create(config);
                var endpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfig);
                // Tạo task kết nối
                session = Session.Create(config, endpoint, false, "MySession", 60000, null, null).Result;
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi kết nối: " + ex.Message);
            }
        }

        private void OPCUAUpdateDevices()
        {
            //bModeCtrl = session.ReadValue("ns=2;s=SYSTEM.TAGS.bModeCtrl");
            bGeminiConnect = session.ReadValue("ns=2;s=SYSTEM.TAGS.Gemini_Connect");
            labelGEMINICConnected.Visible = Convert.ToBoolean(bGeminiConnect.Value) ? true : false;
            //Ctrl_X_Axis = session.ReadValue("ns=2;s=SYSTEM.TAGS.Ctrl_X_Axis");
            //Ctrl_Y_Axis = session.ReadValue("ns=2;s=SYSTEM.TAGS.Ctrl_Y_Axis");
            Monitor_X_Axis = session.ReadValue("ns=2;s=SYSTEM.TAGS.Monitor_X_Axis");
            Monitor_Y_Axis = session.ReadValue("ns=2;s=SYSTEM.TAGS.Monitor_Y_Axis");

            ////https://github.com/OPCFoundation/UA-.NETStandard/blob/master/Applications/ConsoleReferenceClient/ClientSamples.cs
            ///
            WriteValueCollection nodesToWrite = new WriteValueCollection();

            // Int32 Node - Objects\CTT\Scalar\Scalar_Static\Int32
            //WriteValue Ctrl_X_Axis = new WriteValue();
            Ctrl_X_Axis.NodeId = new NodeId("ns=2;s=SYSTEM.TAGS.Ctrl_X_Axis");
            Ctrl_X_Axis.AttributeId = Attributes.Value;
            Ctrl_X_Axis.Value = new DataValue();
            //Ctrl_X_Axis.Value.Value = bStart ? (Int32.TryParse(textBoxXTarget.Text, out int X_Axis_value) ? X_Axis_value : 0) : (Int32.TryParse(textBoxXActual.Text, out X_Axis_value) ? X_Axis_value : 0);
            Ctrl_X_Axis.Value.Value = bStart ? (Int32.TryParse(textBoxXActual.Text, out int X_Axis_value) ? X_Axis_value : 0) : (Int32.TryParse(textBoxXActual.Text, out X_Axis_value) ? X_Axis_value : 0);
            nodesToWrite.Add(Ctrl_X_Axis);


            // Int32 Node - Objects\CTT\Scalar\Scalar_Static\Int32
            //WriteValue Ctrl_Y_Axis = new WriteValue();
            Ctrl_Y_Axis.NodeId = new NodeId("ns=2;s=SYSTEM.TAGS.Ctrl_Y_Axis");
            Ctrl_Y_Axis.AttributeId = Attributes.Value;
            Ctrl_Y_Axis.Value = new DataValue();
            //Ctrl_Y_Axis.Value.Value = bStart ? (Int32.TryParse(textBoxYTarget.Text, out int Y_Axis_value) ? Y_Axis_value : 0): (Int32.TryParse(textBoxYActual.Text, out Y_Axis_value) ? Y_Axis_value : 0);
            Ctrl_Y_Axis.Value.Value = bStart ? (Int32.TryParse(textBoxYActual.Text, out int Y_Axis_value) ? Y_Axis_value : 0) : (Int32.TryParse(textBoxYActual.Text, out Y_Axis_value) ? Y_Axis_value : 0);
            nodesToWrite.Add(Ctrl_Y_Axis);
            

            // Bool Node - Objects\CTT\Scalar\Scalar_Static\Bool
            //WriteValue bModeCtrl = new WriteValue();
            bModeCtrl.NodeId = new NodeId("ns=2;s=SYSTEM.TAGS.bModeCtrl");
            bModeCtrl.AttributeId = Attributes.Value;
            bModeCtrl.Value = new DataValue();
            bModeCtrl.Value.Value = radioButtonControl.Checked ? true : false;
            nodesToWrite.Add(bModeCtrl);

            // Write the node attributes
            StatusCodeCollection results = null;
            DiagnosticInfoCollection diagnosticInfos;

            // Call Write Service
            session.Write(null, nodesToWrite, out results, out diagnosticInfos);
        }
        private void AxesUpdate()
        {
            if (sscApiAxesMonitor.UpdateAxesStatus())
            {
                CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
                textBoxXActual.Text = Convert.ToInt32(axisStatus[0].ActualPos / 100).ToString();
                textBoxYActual.Text = Convert.ToInt32(axisStatus[1].ActualPos / 100).ToString();
                buttonSrvON.BackColor = axisStatus[0].ServoOn && axisStatus[1].ServoOn ? Color.Green : Color.White;
                buttonStart.Enabled = axisStatus[0].ServoOn && axisStatus[1].ServoOn;
                buttonHome.Enabled = axisStatus[0].ServoOn && axisStatus[1].ServoOn;

            }
        }
        private void AxesCotrol()
        {
            double X_target, Y_target, velocity, accDcc;
            velocity = 5000;
            accDcc = 10000;
            bool bRet;
            CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
            if (
                double.TryParse(textBoxXTarget.Text, out X_target) &&
                double.TryParse(textBoxYTarget.Text, out Y_target)&&
                radioButtonControl.Checked && 
                bStart &&
                axisStatus[0].ServoOn &&
                axisStatus[1].ServoOn
            )
            {
                //chạy nội suy
                //bRet = axisStatus[0].ServoOn ? sscApiMotionCtrl.StartPos(0, X_target*100+1, velocity, accDcc): false;
                //bRet = axisStatus[1].ServoOn ? sscApiMotionCtrl.StartPos(1, Y_target*100+1, velocity, accDcc) : false;
                linearIntplCommand.AxisCount = 2;
                linearIntplCommand.Axis[0] = 0;
                linearIntplCommand.Axis[1] = 1;
                linearIntplCommand.Target[0] = X_target * 100;
                linearIntplCommand.Target[1] = Y_target * 100;

                linearIntplCommand.Profile.Type = ProfileType.Trapezoidal;
                linearIntplCommand.Profile.Velocity = velocity;
                linearIntplCommand.Profile.Acc = accDcc;
                linearIntplCommand.Profile.Dec = 1000000;

                sscLib_cm.Motion.StartLinearIntplPos(linearIntplCommand);
                bStart = false;
            }
            if (
                double.TryParse(Convert.ToInt32(Monitor_X_Axis.Value).ToString(), out X_target) &&
                double.TryParse(Convert.ToInt32(Monitor_Y_Axis.Value).ToString(), out Y_target) &&
                !radioButtonControl.Checked && bMoinitor
            )
            {
                bRet = axisStatus[0].ServoOn ? sscApiMotionCtrl.StartPos(0, X_target * 100, velocity*100, accDcc) : false;
                bRet = axisStatus[1].ServoOn ? sscApiMotionCtrl.StartPos(1, Y_target * 100, velocity*100, accDcc) : false;
            }
        }

        private void buttonMonitor_Click(object sender, EventArgs e)
        {
            bMoinitor = !bMoinitor;
        }

        ////////////////////Streaming//////////////////////////////
        private void ResizeEmbeddedApp()
        {
            if (vcProcess != null && vcProcess.MainWindowHandle != IntPtr.Zero)
            {
                MoveWindow(vcProcess.MainWindowHandle, 0, 0, panel1.Width, panel1.Height, true);
            }
        }

        private void RemoveWindowBorders(IntPtr hWnd)
        {
            int style = GetWindowLong(hWnd, GWL_STYLE);
            style &= ~WS_CAPTION;    // bỏ caption bar
            style &= ~WS_THICKFRAME; // bỏ viền resize
            SetWindowLong(hWnd, GWL_STYLE, style);
        }

        private void FormMelsofGEMINIControl_Resize(object sender, EventArgs e)
        {
            ResizeEmbeddedApp();
        }

        private void buttonStartVC_Click(object sender, EventArgs e)
        {
            if (!bStartVC)
            {
                string vcPath = @"C:\Program Files\Visual Components\Visual Components Experience\VisualComponents.Experience.exe";
                //string vcPath = @"C:\Program Files\Visual Components\Visual Components Experience 4.6\VCExperience.exe";

                vcProcess = Process.Start(vcPath);
                if (vcProcess == null) return;

                // Đợi cho đến khi cửa sổ chính xuất hiện
                vcProcess.WaitForInputIdle();
                while (vcProcess.MainWindowHandle == IntPtr.Zero)
                {
                    Thread.Sleep(100); // chờ 100ms
                    vcProcess.Refresh();
                }

                // Nhúng vào panel
                IntPtr vcHandle = vcProcess.MainWindowHandle;
                SetParent(vcHandle, panel1.Handle);
                MoveWindow(vcHandle, 0, 0, panel1.Width, panel1.Height, true);
                ResizeEmbeddedApp();
                RemoveWindowBorders(vcHandle);
                bStartVC = true;
            }    
        }

        private void buttonOPCConnect_Click(object sender, EventArgs e)
        {
            OPCUAInitandHandle();
        }

        private void textBoxXTarget_TextChanged(object sender, EventArgs e)
        {
            bool bRet;
            bRet = double.TryParse(textBoxXTarget.Text, out double X_target);
            if(!bRet)
            {
                MessageBox.Show("Vui lòng nhập giá trị số! Xin nhập lại....");
                textBoxXTarget.Text = "000";
            }    
            else if (X_target > 900  || X_target < 0)
            {
                MessageBox.Show("Vui lòng nhập giá trị số từ 000 - 900! Xin nhập lại....");
                textBoxXTarget.Text = "000";
            }    
        }

        private void textBoxYTarget_TextChanged(object sender, EventArgs e)
        {
            bool bRet;
            bRet = double.TryParse(textBoxYTarget.Text, out double Y_target);
            if (!bRet)
            {
                MessageBox.Show("Vui lòng nhập giá trị số! Xin nhập lại....");
                textBoxYTarget.Text = "000";
            }
            else if (Y_target > 900 || Y_target < 0)
            {
                MessageBox.Show("Vui lòng nhập giá trị số từ 000 - 900! Xin nhập lại....");
                textBoxYTarget.Text = "000";
            }
        }
    }
}
