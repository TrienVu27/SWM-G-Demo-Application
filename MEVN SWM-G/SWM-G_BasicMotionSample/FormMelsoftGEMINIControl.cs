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

        private Process vcProcess;


        public FormMelsofGEMINIControl()
        {
            InitializeComponent();
            this.Load += FormMelsofGEMINIControl_Load;
            this.Resize += FormMelsofGEMINIControl_Resize;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            if (CreateSSCApiObject())
            {
                if (sscApiAxesMonitor.CreateDevice() && sscApiMotionCtrl.CreateDevice())
                {
                    //-------------------------------------------------
                    //Initial controls.
                    timer1.Enabled = true;
                    sscLib.CreateDevice("C:\\Program Files\\MotionSoftware\\SWM-G\\",
                                 DeviceType.DeviceTypeNormal,
                                 0xFFFFFFFF);
                    OPCUAInitandHandle();
                    timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Can not CreateDevice, Window was closed");
                    Close();
                }
            }
            // Khởi động Visual Components Experience
            vcProcess = Process.Start(@"C:\Program Files\Visual Components\Visual Components Experience\VisualComponents.Experience.exe");

            //vcProcess.WaitForInputIdle(); // Chờ app load
            //Thread.Sleep(8000); // Đợi ứng dụng mở
            int retry = 0;
            while (vcProcess.MainWindowHandle == IntPtr.Zero && retry < 500)
            {
                Thread.Sleep(10);
                vcProcess.Refresh(); // Cập nhật thông tin process
                retry++;
            }

            IntPtr appWin = vcProcess.MainWindowHandle;
            if (appWin != IntPtr.Zero)
            {
                SetParent(appWin, panel1.Handle); // panel1 là Panel trong WinForms
                ShowWindow(appWin, 3); // SW_MAXIMIZE
                ResizeEmbeddedApp();
            }
            else
            {
                MessageBox.Show("Không tìm thấy cửa sổ VC Experience!");
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
         
            // Bước 3: Kết nối đến server
            //var selectedEndpoint = CoreClientUtils.SelectEndpoint(serverUrl, useSecurity: false);
            var selectedEndpoint = CoreClientUtils.SelectEndpoint(serverUrl, useSecurity: false);
            var endpointConfig = EndpointConfiguration.Create(config);
            var endpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfig);

            session = Session.Create(config, endpoint, false, "MySession", 60000, null, null).Result;
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
                radioButtonControl.Checked && bStart
            )
            {
                bRet = axisStatus[0].ServoOn ? sscApiMotionCtrl.StartPos(0, X_target*100+1, velocity, accDcc): false;
                bRet = axisStatus[1].ServoOn ? sscApiMotionCtrl.StartPos(1, Y_target*100+1, velocity, accDcc) : false;
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

        private void FormMelsofGEMINIControl_Resize(object sender, EventArgs e)
        {
            ResizeEmbeddedApp();
        }
    }
}
