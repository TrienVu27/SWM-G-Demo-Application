/*****************************************************************************/
/* FILE        : FormMotionContiControl.cs                                   */
/* DESCRIPTION : Continuous positioning form.                                */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSCApiCLR;
using System.Threading;


namespace BasicMotionSample
{
    

    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public partial class FormMotionContiControl : Form
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const int MonInterval = 50;       //Monitor Interval 50[ms]
        private const double AccelDecel = 10000.0;  //Acceleration / Deceleration 
        private const int MaxPosPoint = 10;         //Max positioning point.

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private SSCApiControlForThreads sscApiMotionCtrl = null;  //SSCApiControl class
        private static int formCount = 0;               //Number of display forms.
        private delegate void UpdateControl();          //Delegate definition
        private UpdateControl DelegateUpdateControl;    //Delegate definition for controls update.
        private Thread ThreadPositioning = null;        //Positioning thread.
        private int execPoint = 0;                      //Number of execution point.
        private Object lockObj = new Object();          //Lock object
        private bool bRunning = false;                  //Running flag.
        private bool bPause = false;                    //Pausing flag.
        private stPotisionData potisionData = new stPotisionData(); //Positioning point data.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public FormMotionContiControl()
        {
            InitializeComponent();
            DelegateUpdateControl = new UpdateControl(MethodUpdateControl);
            potisionData.pointData = new stPointData[MaxPosPoint];
         }

        //----------------------------------------------------------------
        // Function : Occurs before a form is displayed for the first time.
        //            Create device and Initial controls.
        //----------------------------------------------------------------
        private void FormMotionContiControl_Load(object sender, EventArgs e)
        {
            bool bNormal = false;
            formCount++;
            if (formCount <= SampleConstants.FormShowMax)
            {   //formCount : 1 - 5
                if (CreateSSCApiObject())
                {
                    if (sscApiMotionCtrl.CreateDevice())
                    {
                        //-------------------------------------------------
                        //Initial controls.
                        textAxis.Text = (formCount - 1).ToString();
                        textAxis.MaxLength = SampleConstants.MaxAxisLength;
                        InitializeDataGridView();
                        buttonPause.Enabled = false;
                        MethodUpdateControl();  //Update controls.
                        timerMonitor.Interval = MonInterval;
                        timerMonitor.Enabled = true;
                        bNormal = true;
                    }
                }
            }
            if (!bNormal)
            {
                Close();    //Form close.
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Start/Stop button control is clicked.
        //             Stopped: Starts the positioning thread.
        //             In operation: Stops the axis.
        //----------------------------------------------------------------
        private void buttonStart_Click(object sender, EventArgs e)
        {
            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
                if (bRunning)
                {
                    //Stop
                    lock (lockObj)
                    {
                        bRunning = false;
                    }
                    sscApiMotionCtrl.ExecTimedStop(axis);      //Motion stop.
                }
                else
                {
                    //Runnig
                    if (CheckPositionValueSetMember())  //Set Input data
                    {
                        lock (lockObj)
                        {
                            bRunning = true;
                            bPause = false;
                        }
                        ThreadPositioning?.Abort();
                        ThreadPositioning?.Join();
                        execPoint = 0;
                        //Thread start.
                        ThreadPositioning = new Thread(new ThreadStart(positioningThreadFunction));
                        ThreadPositioning.Start();
                    }
                    else
                    {   //Inout error.
                        MessageBox.Show(
                            "Positioning point value error.",
                            "Positioning point",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                MethodUpdateControl();  //Update controls.
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Pause/Resume button control is clicked.
        //             Execute the Pause() or Resume().
        //----------------------------------------------------------------
        private void buttonPause_Click(object sender, EventArgs e)
        {
            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
                lock (lockObj)
                {
                    bool bRet = false;
                    if (bPause)
                    {
                        bRet = sscApiMotionCtrl.Resume(axis);
                        bPause = false;
                    }
                    else
                    {
                        bRet = sscApiMotionCtrl.Pause(axis);
                        if (bRet)
                        {
                            bPause = true;
                        }
                    }
                }
                MethodUpdateControl();  //Update controls.
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Servo ON button control is clicked.
        //             Execute the GetServoOnState().
        //----------------------------------------------------------------
        private void buttonServoON_Click(object sender, EventArgs e)
        {
            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
                bool bSvOn = sscApiMotionCtrl.GetServoOnState(axis);
                sscApiMotionCtrl.ServoOn(axis, !bSvOn);
            }
            MethodUpdateControl();  //Update controls.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Close button control is clicked.
        //----------------------------------------------------------------
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();    //Form close.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when a character. key is pressed 
        //             while the textAxis control has focus.
        //----------------------------------------------------------------
        private void textAxis_KeyPress(object sender, KeyPressEventArgs e)
        {
            SampleComFunc.CheckKeyPressNum(e);     //Input key check.(Integer)
        }

        //----------------------------------------------------------------
        // Functions : Occurs when a control for editing a cell is showing.
        //             Set a keypress event in the text box.
        //----------------------------------------------------------------
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridView dataGrid = (DataGridView)sender;
                DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
                tb.MaxLength = SampleConstants.MaxDecimalLength;
                tb.KeyPress -= new KeyPressEventHandler(dataGridViewTextBox_KeyPress);  //Remove KeyPress Handler
                tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);  //Add KeyPress Handler
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when a character. key is pressed 
        //             while the dataGridViewTextBox control has focus.
        //----------------------------------------------------------------
        private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SampleComFunc.CheckKeyPressNumPoint(e, ((TextBox)sender).Text);     //Input key check.(Decimal)
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the specified timer interval 
        //             has elapsed and the timer is enabled.
        //----------------------------------------------------------------
        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            timerMonitor.Enabled = false;
            MethodUpdateControl();      //Update button control.
            timerMonitor.Enabled = true;
        }

        //----------------------------------------------------------------
        // Functions : Occurs after the form is closed.
        //             Axis stop, thread abort, and device close.
        //----------------------------------------------------------------
        private void FormMotionContiControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCount--;
            if (sscApiMotionCtrl != null)
            {
                int axis;
                if (Int32.TryParse(textAxis.Text, out axis))
                {
                    if (sscApiMotionCtrl.GetServoOnState(axis))
                    {
                        sscApiMotionCtrl.ExecTimedStop(axis);   //Motion stop.
                    }
                }
            }
            ThreadPositioning?.Abort();
            ThreadPositioning?.Join();
            sscApiMotionCtrl?.DeviceClose();
        }

        //----------------------------------------------------------------
        // Functions : Initialize data grid view.
        //----------------------------------------------------------------
        private void InitializeDataGridView()
        {
            dataGridView.ColumnCount = 4;
            dataGridView.RowCount = MaxPosPoint;

            dataGridView.Columns[0].HeaderText = "No.";
            dataGridView.Columns[1].HeaderText = "Target";
            dataGridView.Columns[2].HeaderText = "Velocity";
            dataGridView.Columns[3].HeaderText = "Remaining Distance";

            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView.Columns[0].Width = 40;
            dataGridView.Columns[1].Width = 120;
            dataGridView.Columns[2].Width = 120;
            dataGridView.Columns[3].Width = 120;

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView.Columns[0].ReadOnly = true;
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            for (int i = 0; i < MaxPosPoint; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = (i + 1).ToString();
                dataGridView.Rows[i].Cells[1].Value = (10000 * i).ToString("F3");
                dataGridView.Rows[i].Cells[2].Value = (10000).ToString("F3");
                dataGridView.Rows[i].Cells[3].Value = (100).ToString("F3");
            }

            dataGridView.Columns[1].ValueType = System.Type.GetType("System.double");
            dataGridView.Columns[2].ValueType = System.Type.GetType("System.double");
            dataGridView.Columns[3].ValueType = System.Type.GetType("System.double");


            dataGridView.ReadOnly = false;
            dataGridView.Enabled = true;

            dataGridView.ClearSelection();
        }

        //----------------------------------------------------------------
        // Functions : Check position value set member.
        //----------------------------------------------------------------
        public bool CheckPositionValueSetMember()
        {
            bool bType1 = radioStanbyType1.Checked;
            bool bCheckRet = Int32.TryParse(textAxis.Text, out potisionData.axis);
            if (bCheckRet)
            {
                for (int i = 0; i < MaxPosPoint; i++)
                {
                    int indexRD = (i == (MaxPosPoint - 1)) ? 0 : i + 1;
                    bCheckRet =
                        double.TryParse(dataGridView[1, i].Value.ToString(), out potisionData.pointData[i].target) &&
                        double.TryParse(dataGridView[2, i].Value.ToString(), out potisionData.pointData[i].velocity) &&
                        (bType1 || double.TryParse(dataGridView[3, i].Value.ToString(), out potisionData.pointData[indexRD].remainingDistance));
                    if (!bCheckRet)
                    {
                        bCheckRet = false;
                        break;
                    }
                }
            }
            return bCheckRet;
        }

        //----------------------------------------------------------------
        // Functions : Update controls.
        //----------------------------------------------------------------
        public void MethodUpdateControl()
        {
            lock (lockObj)
            {
                if (bRunning)
                {
                    dataGridView.ClearSelection();
                    dataGridView.Rows[execPoint].Selected = true;
                }

                int axis;
                if (Int32.TryParse(textAxis.Text, out axis))
                {

                    bool bSvOn = sscApiMotionCtrl.GetServoOnState(axis);
                    buttonServoON.BackColor = bSvOn ? Color.GreenYellow : SystemColors.Control;   //Button color change
                    buttonServoON.UseVisualStyleBackColor = bSvOn ? false : true;
                }

                buttonStart.Text = bRunning ? "Stop" : "Start";                                 //Button text change.
                buttonStart.BackColor = bRunning ? Color.GreenYellow : SystemColors.Control;    //Button color change
                buttonStart.UseVisualStyleBackColor = bRunning ? false : true;

                labelStatus.Text = bRunning ? (bPause ? "Pause" : "Running") : "Stop";

                buttonPause.Text = (bPause && bRunning) ? "Resume" : "Pause";                               //Button text change.
                buttonPause.BackColor = (bPause && bRunning) ? Color.GreenYellow : SystemColors.Control;   //Button color change
                buttonPause.UseVisualStyleBackColor = bPause ? false : true;
                buttonPause.Enabled = bRunning;

                dataGridView.ReadOnly = bRunning;
                dataGridView.Enabled = !bRunning;
                textAxis.Enabled = !bRunning;
                groupStanbyType.Enabled = !bRunning;
            }
        }

        //----------------------------------------------------------------
        // Functions : Positioning thread function.
        //             Performs point-by-point positioning.
        //----------------------------------------------------------------
        public void positioningThreadFunction()
        {
            bool bTypeWait = radioStanbyType1.Checked;
            bool bRet = false;

            while (true)
            {
                for (int i = 0; i < MaxPosPoint; i++)
                {
                    execPoint = i;
                    Invoke(DelegateUpdateControl);  //Update form controls.
                    if (bTypeWait)
                    {
                        // Idle wait positioning.
                        bRet = sscApiMotionCtrl.StartPos(
                            potisionData.axis,
                            potisionData.pointData[i].target,
                            potisionData.pointData[i].velocity,
                            AccelDecel
                        );
                        if (bRet)
                        {
                            bRet = sscApiMotionCtrl.Wait(potisionData.axis);    //Idle wait.
                        }
                    }
                    else
                    {
                        // Trigger wait positioning.
                        bRet = sscApiMotionCtrl.StartPos(
                            potisionData.axis,
                            potisionData.pointData[i].target,
                            potisionData.pointData[i].velocity,
                            AccelDecel,
                            potisionData.pointData[i].remainingDistance
                        );
                        if (bRet)
                        {
                            bRet = sscApiMotionCtrl.WaitMotionStarted(potisionData.axis);   //Start wait.
                        }
                    }

                PAUSE_LOOP:
                    Thread.Sleep(1);
                    bool bRunning_bk;
                    bool bPause_bk;
                    lock (lockObj)
                    {
                        bRunning_bk = bRunning;
                        bPause_bk = bPause;
                    }
                    if (!bRet || !bRunning_bk)
                    {   // API error or Stopped. 
                        break;      //Exit for().
                    }
                    if (bPause_bk)
                    {
                        goto PAUSE_LOOP;
                    }
                }
                if (!bRet || !bRunning)
                {   //API error or Stopped.
                    break;      //Exit while().
                }
                Thread.Sleep(1);
            }
            lock (lockObj)
            {
                bRunning = false;
            }
            bool bSvOn = sscApiMotionCtrl.GetServoOnState(potisionData.axis);
            if (bSvOn)
            {   //SvOn
                sscApiMotionCtrl.ExecTimedStop(potisionData.axis);  //Motion stop.
            }
            Invoke(DelegateUpdateControl);  //Update form controls.
        }

        //----------------------------------------------------------------
        // Functions : Create object
        //----------------------------------------------------------------
        private bool CreateSSCApiObject()
        {
            sscApiMotionCtrl = new SSCApiControlForThreads();
            return (sscApiMotionCtrl != null);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
