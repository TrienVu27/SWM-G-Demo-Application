/*****************************************************************************/
/* FILE        : FormMain.cs                                                 */
/* DESCRIPTION : Main form                                                   */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using SSCApiCLR;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public partial class FormMain : Form
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const string DeviceName = "MEVN-SampleMain"; //Device name.
        private const int MonInterval = 1000;           //Monitor Interval 1000[ms]
        private const int DeviceCreateTimeout = 30000;  //Create device Timeout [ms]
        private const int StopEngineTimeout = 30000;    //StopEngine Timeout [ms]
        private const int StartCommTimeout = 30000;     //StartComm.Timeout [ms]

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private static SSCApi sscApi = new SSCApi();            //SSCApi class
        private EngineStatus engStatus = new EngineStatus();    //EngineStatus class
        private CoreMotion sscApiCtrl = new CoreMotion(sscApi);    //CoreMotion class
        private bool bEngineRunning = false;                    //EngineRunning flag.
        private bool bCommunicating = false;                    //Communicating flag.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public FormMain()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------
        // Function : Occurs before a form is displayed for the first time.
        //            Create device and Initial controls.
        //----------------------------------------------------------------
        private void FormMain_Load(object sender, EventArgs e)
        {
            bool bNormal = false;
            if (CreateDevice())
            { 
                timer1.Interval = MonInterval;  //Monitor interval.
                timer1.Enabled = true;
                bNormal = true;
            }
            if (!bNormal)
            {
                Close();    //Form close.
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Engine Start/Stop button control is clicked.
        //             Execute the CreateDevice() or DeviceClose() / StopEngine().
        //----------------------------------------------------------------
        private void buttonStartEng_Click(object sender, EventArgs e)
        {
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            int nError = ErrorCode.None;
            UpdateEngineState();
            if (!bEngineRunning)
            {   //Engine start.
                CreateDevice();
            }
            else
            {   //Engine Stop
                nError = sscApi.CloseDevice();
                if (ErrorCode.None != nError)
                {
                    MessageBox.Show(
                        String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                        String.Format(SampleConstants.sErrMsgTitle, "StopCommunication()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    nError = sscApi.StopEngine(StopEngineTimeout);
                    if (ErrorCode.None != nError)
                    {
                        MessageBox.Show(
                            String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                            String.Format(SampleConstants.sErrMsgTitle, "StopCommunication()"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            UpdateEngineState();
            UpdateControl();
            Cursor.Current = preCursor;
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Communication Start/Stop 
        //             button control is clicked.
        //             Execute the StartCommunication() or StopCommunication().
        //----------------------------------------------------------------
        private void buttonStartComm_Click(object sender, EventArgs e)
        {
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            int nError = ErrorCode.None;
            UpdateEngineState();
            if (!bCommunicating)
            {
                nError = sscApi.StartCommunication(StartCommTimeout);
                if (ErrorCode.None != nError)
                {
                    MessageBox.Show(
                        String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                        String.Format(SampleConstants.sErrMsgTitle, "StartCommunication()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                nError = sscApi.StopCommunication(StartCommTimeout);
                if (ErrorCode.None != nError)
                {
                    MessageBox.Show(
                        String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                        String.Format(SampleConstants.sErrMsgTitle, "StopCommunication()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            UpdateEngineState();
            UpdateControl();

            Cursor.Current = preCursor;
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Axes Monitor button control
        //             control is clicked.
        //----------------------------------------------------------------
        private void buttonAxesMonitor_Click(object sender, EventArgs e)
        {
            FormAxesMonitor myform = new FormAxesMonitor();
            myform.Show();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Single Axis Pos./JOG button 
        //             control is clicked.
        //----------------------------------------------------------------
        private void buttonMotionCtrl_Click(object sender, EventArgs e)
        {
            FormMotionControl myform = new FormMotionControl();
            myform.Show();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Single Axis Pos (Conti.) button 
        //             control is clicked.
        //----------------------------------------------------------------
        private void buttonMotionContiCtrl_Click(object sender, EventArgs e)
        {
            FormMotionContiControl myform = new FormMotionContiControl();
            myform.Show();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the SDO Read/Write button control
        //             is clicked.
        //----------------------------------------------------------------
        private void buttonSdoRW_Click(object sender, EventArgs e)
        {
            FormSdoReadWrite myform = new FormSdoReadWrite();
            myform.Show();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the SDO Read/Write(Batch) button 
        //             control is clicked.
        //----------------------------------------------------------------
        private void buttonSdoBatch_Click(object sender, EventArgs e)
        {
            FormSdoBatchReadWrite myform = new FormSdoBatchReadWrite();
            myform.Show();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Close button is clicked.
        //----------------------------------------------------------------
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();    //Form close.
        }
        
        //----------------------------------------------------------------
        // Function : Timer processing.
        //            Update Engine status / controls.
        //----------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            UpdateEngineState();
            UpdateControl();
            timer1.Enabled = true;
        }

        //----------------------------------------------------------------
        // Functions : Occurs after the form is closed.
        //             All axis servos are turned off and communication is stopped.
        //             Close all displayed forms.
        //----------------------------------------------------------------
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            AxisSelection axisSelection = new AxisSelection();
            axisSelection.AxisCount = Constants.MaxAxes;
            for (int i = 0; i < Constants.MaxAxes; i++)
            {
                axisSelection.Axis[i] = i;
            }
            CoreMotion sscApi_cm = new CoreMotion(sscApi);
            sscApi_cm.AxisControl.SetServoOn(axisSelection, 0); //All servo off.
            while (0 != Application.OpenForms.Count)
            {
                Application.OpenForms[0].Close();               //Form close event.
                Thread.Sleep(1);
            }
            sscApi.StopCommunication(StartCommTimeout);         //Stop communication.
            sscApi.CloseDevice();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the form is closing.
        //             A confirmation message is displayed
        //             Ask if you want to close it.
        //----------------------------------------------------------------
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(
                "Stop the axis, stop communication, and end the application.\nAre you sure you want to quit ?",
                Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        //----------------------------------------------------------------
        // Functions : Update the button / label control.
        //----------------------------------------------------------------
        private void UpdateControl()
        {
            buttonStartEng.Text = bEngineRunning ? "Engine Stop" : "Engine Start";                  //Button text change.
            buttonStartEng.BackColor = bEngineRunning ? Color.GreenYellow : SystemColors.Control;   //Button color change.
            buttonStartEng.UseVisualStyleBackColor = bEngineRunning ? false : true;

            buttonStartComm.Text = bCommunicating ? "Communication Stop" : "Communication Start";    //Button text change.
            buttonStartComm.BackColor = bCommunicating ? Color.GreenYellow : SystemColors.Control;   //Button color change.
            buttonStartComm.UseVisualStyleBackColor = bCommunicating ? false : true;

            labelEngCommstat.Text = SSCApiBase.ENG_STATE(engStatus.State);
        }

        //----------------------------------------------------------------
        // Functions : Update the engine state.
        //----------------------------------------------------------------
        private void UpdateEngineState()
        {
            int nError = sscApi.GetEngineStatus(ref engStatus);
            if (ErrorCode.None == nError)
            {
                bEngineRunning = (engStatus.State == SSCApiCLR.EngineState.Running || engStatus.State == SSCApiCLR.EngineState.Communicating);
                bCommunicating = (engStatus.State == SSCApiCLR.EngineState.Communicating);
            }
            else
            {
                bEngineRunning = false;
                bCommunicating = false;
                engStatus.State = EngineState.Idle;
            }
        }

        //----------------------------------------------------------------
        // Functions : Create device.
        //----------------------------------------------------------------
        private bool CreateDevice()
        {
            int nError = ErrorCode.None;
            nError = sscApi.CreateDevice(
                SampleConstants.sSWM_G_Path,
                DeviceType.DeviceTypeNormal,
                DeviceCreateTimeout
            );
            if (ErrorCode.None != nError)
            {
                MessageBox.Show(
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "CreateDevice()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                // Set Device Name.
                nError = sscApi.SetDeviceName(DeviceName);
                if (ErrorCode.None != nError)
                {
                    MessageBox.Show(
                        String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                        String.Format(SampleConstants.sErrMsgTitle, "SetDeviceName()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else//load prameter
                {
                    // Import parameters.
                    int ret = sscApiCtrl.Config.ImportAndSetAll("swmg_parameters.xml");
                    if (ret != 0)
                    {
                        MessageBox.Show("The parameter setting file does not exist in the specified location, so the file will not be imported and you will proceed.\n");
                    }
                }
            }
            return (ErrorCode.None == nError);
        }

        private void buttonMultiMotionContiCtrl_Click(object sender, EventArgs e)
        {
            FormMultiMotionControl myform = new FormMultiMotionControl();
            myform.Show();
        }

        private void buttonIOMonitor_Click(object sender, EventArgs e)
        {
            FormIOMonitor myform = new FormIOMonitor();
            myform.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
