using SSCApiCLR;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Struct : Point data structure.
    //----------------------------------------------------------------
    public struct stPointData
    {
        public double target;
        public double velocity;
        public double remainingDistance;
    }

    //----------------------------------------------------------------
    // Struct :Positioning data structure.
    //----------------------------------------------------------------
    public struct stPotisionData
    {
        public int axis;
        public stPointData[] pointData;
    }
    public partial class FormSyncMotionControl : Form
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const int MaxMonitorAxes = 128;  //Number of display axes.
        private const int MonInterval = 50;   //Monitor Interval 50[ms]
        private const double AccelDecel = 10000.0;  //Acceleration / Deceleration
        private const int MaxPosPoint = 25;         //Max positioning point.
        private const int MaxMonitorItem = 5;   //Number of display items.

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private SSCApiAxesMonitor sscApiAxesMonitor = null;     //SSCApiAxesMonitor class
        private static int formCount = 0;                       //Number of display forms.
        private SSCApiControl sscApiMotionCtrl = null;  //SSCApiControl class
        
        static SSCApi sscLib = new SSCApi();
        static CoreMotion sscLib_cm = new CoreMotion(sscLib);
        static CoreMotionStatus CmStatus = new CoreMotionStatus();

        private delegate void UpdateControl();          //Delegate definition
        private UpdateControl DelegateUpdateControl;    //Delegate definition for controls update.
        private Thread ThreadPositioning = null;        //Positioning thread.
        private int execPoint = 0;                      //Number of execution point.
        private Object lockObj = new Object();          //Lock object
        private bool bRunning = false;                  //Running flag.
        private bool bPause = false;                    //Pausing flag.
        private bool bEnable = true;                    //Enable flag.
        private stPotisionData potisionData = new stPotisionData(); //Positioning point data.
        private int PosPoint = 2;         //positioning point.

        //----------------------------------------------
        private int Axis_Master = 0;

        public FormSyncMotionControl()
        {
            InitializeComponent();
            DelegateUpdateControl = new UpdateControl(MethodUpdateControl);
            potisionData.pointData = new stPointData[MaxPosPoint];
        }

        private void FormMultiMotionControl_Load(object sender, EventArgs e)
        {
            bool bNormal = false;
            if (formCount <= SampleConstants.FormShowMax)
            {   //formCount : 1 - 5
                if (CreateSSCApiObject())
                {
                    if (sscApiAxesMonitor.CreateDevice() && sscApiMotionCtrl.CreateDevice())
                    {
                        //-------------------------------------------------
                        //Initial controls.
                        InitializeDataGridView();
                        InitializeFunc();
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
        private void InitializeDataGridView()
        {
            /// dataGridView ////
            dataGridView.RowCount = MaxMonitorAxes;
            
            for (int i = 0; i < MaxMonitorAxes; i++)//Initil display.
            {
                dataGridView[0, i].Value = (i < 10) ? "0" + i : i.ToString();
            }

            /// dataGridView1 ////
            dataGridView1.RowCount = 0;// MaxMonitorAxes;

            /// dataGridView2 ////
            dataGridView2.ColumnCount = 4;

            dataGridView2.Columns[0].HeaderText = "No.";
            dataGridView2.Columns[1].HeaderText = "Target";
            dataGridView2.Columns[2].HeaderText = "Velocity";
            dataGridView2.Columns[3].HeaderText = "Remaining Distance";

            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView2.Columns[0].Width = 40;
            dataGridView2.Columns[1].Width = 120;
            dataGridView2.Columns[2].Width = 120;
            dataGridView2.Columns[3].Width = 120;

            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView2.Columns[0].ReadOnly = true;
            foreach (DataGridViewColumn item in dataGridView2.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            MethodUpdatePostioningPointTable(PosPoint);

            dataGridView2.Columns[1].ValueType = System.Type.GetType("System.double");
            dataGridView2.Columns[2].ValueType = System.Type.GetType("System.double");
            dataGridView2.Columns[3].ValueType = System.Type.GetType("System.double");


            dataGridView2.ReadOnly = false;
            dataGridView2.Enabled = true;

            dataGridView2.ClearSelection();

            /// dataGridView3 ////
            dataGridView3.ReadOnly = true;
            dataGridView3.ColumnCount = MaxMonitorItem + 1;
            dataGridView3.RowCount = MaxMonitorAxes;

            dataGridView3.Columns[0].HeaderText = "Axis";
            dataGridView3.Columns[1].HeaderText = "Servo ON";
            dataGridView3.Columns[2].HeaderText = "Pos Cmd";
            dataGridView3.Columns[3].HeaderText = "Actual Pos";
            dataGridView3.Columns[4].HeaderText = "Velocity Cmd";
            dataGridView3.Columns[5].HeaderText = "Op State";

            dataGridView3.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView3.Columns[0].Width = 40;
            dataGridView3.Columns[1].Width = 60;
            dataGridView3.Columns[2].Width = 100;
            dataGridView3.Columns[3].Width = 100;
            dataGridView3.Columns[4].Width = 100;
            dataGridView3.Columns[5].Width = 70;

            for (int i = 0; i < dataGridView3.ColumnCount; i++)
            {
                dataGridView3.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView3.ClearSelection();
            foreach (DataGridViewColumn item in dataGridView3.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }

        //----------------------------------------------------------------
        // Functions : Update the axis monitor.
        //----------------------------------------------------------------
        private void UpdateAxesMonitor(int row, ref CoreMotionAxisStatus axisStatus)
        {

            //dataGridView//
            bool bRet = Int32.TryParse(comboBox1.Text, out int dataGridView1Selected);

            dataGridView[1, row].Value = (bRet && (row == dataGridView1Selected) && !axisStatus.ServoOffline) ? "Master" : (axisStatus.ServoOffline) ? "Offline" : (axisStatus.OpState.ToString() == "Sync") ? "Sync" : "No Sync";
            dataGridView[1, row].Style.BackColor = (bRet && (row == dataGridView1Selected) && !axisStatus.ServoOffline) ? Color.White : (axisStatus.ServoOffline) ? Color.Gray : (dataGridView[1, row].Value.ToString() != "Sync") ? Color.Red : Color.Green;
            dataGridView[1, row].Style.ForeColor = (bRet && (row == dataGridView1Selected) && !axisStatus.ServoOffline) ? Color.Black : (axisStatus.ServoOffline) ? Color.DarkGray : (dataGridView[1, row].Value.ToString() != "Sync") ? Color.Yellow : Color.LightSkyBlue;
            dataGridView[2, row].Value = (bRet && (row == dataGridView1Selected) && !axisStatus.ServoOffline) ? "Master" : (axisStatus.ServoOffline) ? "" : (dataGridView[1, row].Value.ToString() != "Sync") ? "Enable" : "Disable";
            
            Axis_Master = (bRet && (row == dataGridView1Selected) && !axisStatus.ServoOffline) ? row : Axis_Master;
            
            if (bRet && (row == dataGridView1Selected) && axisStatus.ServoOffline)
            {
                MessageBox.Show("Master axis is offline! Please select another axis");
                comboBox1.SelectedIndex = 0;
            }

            //dataGridView3//
            dataGridView3[0, row].Value = row;
            dataGridView3[1, row].Value = axisStatus.ServoOn ? "ON" : axisStatus.ServoOffline ? "-":"OFF";         //Servo On
            dataGridView3[1, row].Style.BackColor = axisStatus.ServoOn ? Color.Green : Color.White;         //Servo On
            dataGridView3[2, row].Value = axisStatus.ServoOffline ? "-" : axisStatus.PosCmd.ToString("F3");          //Pos Cmd
            dataGridView3[3, row].Value = axisStatus.ServoOffline ? "-" : axisStatus.ActualPos.ToString("F3");       //Actual Pos
            dataGridView3[4, row].Value = axisStatus.ServoOffline ? "-" : axisStatus.VelocityCmd.ToString("F3");     //Velocity Cmd
            dataGridView3[5, row].Value = axisStatus.ServoOffline ? "-" : SSCApiBase.OP_STATE(axisStatus.OpState);   //Op State
        }

        //----------------------------------------------------------------
        // Functions : Create object
        //----------------------------------------------------------------
        private bool CreateSSCApiObject()
        {
            sscApiAxesMonitor = new SSCApiAxesMonitor();
            sscApiMotionCtrl = new SSCApiControlForThreads();
            return ((sscApiAxesMonitor != null)&& (sscApiMotionCtrl != null));
        }

        private void buttonAllAxisSyncON_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < MaxMonitorAxes; j++)
            {
                int bRet = (Axis_Master != j) ? sscLib_cm.Sync.SetSyncMasterSlave(Axis_Master, j) : 0;
            }
            bEnable = true;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timerMonitor.Enabled = false;
            //Update monitor.
            if (sscApiAxesMonitor.UpdateAxesStatus())
            {
                CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
                for (int i = 0; i < MaxMonitorAxes; i++)
                {
                    UpdateAxesMonitor(i, ref axisStatus[i]);
                }              
                timerMonitor.Enabled = true;
                if (bEnable)
                {
                    MethodUpdateDataGridView1();
                    bEnable = false;   
                }    
            }
            buttonPause.Enabled = bRunning;
            buttonStop.Enabled = bRunning;
            buttonHome.Enabled = !bRunning;
            buttonStart.Enabled = !bRunning;
            comboBox2.Enabled = !bRunning;
        }

        private static void InitializeFunc()
        {
            // Create device.
            sscLib.CreateDevice("C:\\Program Files\\MotionSoftware\\SWM-G\\",
                                 DeviceType.DeviceTypeNormal,
                                 0xFFFFFFFF);
            // Set Device Name.
            sscLib.SetDeviceName("SyncMotion");
            // Start Communication.
            sscLib.StartCommunication(0xFFFFFFFF);
        }

        private void buttonAllAxisSyncOFF_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < MaxMonitorAxes; i++)
            {
                int bRet = (Axis_Master != i) ? sscLib_cm.Sync.ResolveSync(i) : 0;
            }
            bEnable = true;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                switch (dataGridView[2, e.RowIndex].Value)
                {
                    case "Enable":
                        sscLib_cm.Sync.SetSyncMasterSlave(Axis_Master, e.RowIndex);
                        comboBox1.Enabled = false;
                        break;
                    case "Disable":
                        sscLib_cm.Sync.ResolveSync(e.RowIndex);
                        break;
                    default:
                        break;
                }
                bEnable = true;
            }
        }

        private void buttonAllServoON_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MaxMonitorAxes; i++)
            {
                sscLib_cm.AxisControl.SetServoOn(i, 1);
            }
        }

        private void buttonAllServoOFF_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MaxMonitorAxes; i++)
            {
                sscLib_cm.AxisControl.SetServoOn(i, 0);
            }
            bEnable = true;
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            //-----------------------------------------------------------------
            // Homing the servo to the home position.
            // (The slave axis is also homed synchronously.)
            //-----------------------------------------------------------------
            Config.HomeParam homeParam = new Config.HomeParam();
            homeParam.HomeType = Config.HomeType.CurrentPos;
            sscLib_cm.Config.SetHomeParam(Axis_Master, homeParam);
            sscLib_cm.Home.StartHome(Axis_Master);
            sscLib_cm.Motion.Wait(Axis_Master);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            sscLib_cm.Motion.ExecTimedStop(Axis_Master, 10);
            bRunning = false;
            bPause = false;
            buttonPause.Text = "Pause";
            buttonPause.BackColor = Color.White;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            int bRet = bPause ? sscLib_cm.Motion.Resume(Axis_Master): sscLib_cm.Motion.Pause(Axis_Master);
            buttonPause.Text = bPause ? "Pause" : "Resume";
            buttonPause.BackColor = bPause ? Color.White : Color.LightGreen;
            bPause = !bPause;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (bRunning)
            {
                //Stop
                //lock (lockObj)
                //{
                   // bRunning = false;
                //}
                //sscApiMotionCtrl.ExecTimedStop(Axis_Master);      //Motion stop.
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


        /////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////
        //----------------------------------------------------------------
        // Functions : Positioning thread function.
        //             Performs point-by-point positioning.
        //----------------------------------------------------------------
        public void positioningThreadFunction()
        {
            bool bTypeWait = true;
            bool bRet = false;

            while (true)
            {
                for (int i = 0; i < PosPoint; i++)
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
        // Functions : Check position value set member.
        //----------------------------------------------------------------
        public bool CheckPositionValueSetMember()
        { 
            bool bCheckRet = Int32.TryParse(Axis_Master.ToString(), out potisionData.axis);
            if (bCheckRet)
            {
                for (int i = 0; i < PosPoint; i++)
                {
                    int indexRD = (i == (PosPoint - 1)) ? 0 : i + 1;
                    bCheckRet =
                        double.TryParse(dataGridView2[1, i].Value.ToString(), out potisionData.pointData[i].target) &&
                        double.TryParse(dataGridView2[2, i].Value.ToString(), out potisionData.pointData[i].velocity) &&
                        double.TryParse(dataGridView2[3, i].Value.ToString(), out potisionData.pointData[indexRD].remainingDistance);
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
                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[execPoint].Selected = true;
                }
                int axis;
                if (Int32.TryParse(Axis_Master.ToString(), out axis))
                {
                    bool bSvOn = sscApiMotionCtrl.GetServoOnState(axis);
                }
                labelStatus.Text = bRunning ? (bPause ? "Pause" : "Running") : "Stop";
                buttonPause.Text = (bPause && bRunning) ? "Resume" : "Pause";                               //Button text change.
                buttonPause.BackColor = (bPause && bRunning) ? Color.GreenYellow : SystemColors.Control;   //Button color change
                buttonPause.UseVisualStyleBackColor = bPause ? false : true;
                buttonPause.Enabled = bRunning;
                dataGridView2.ReadOnly = bRunning;
                dataGridView2.Enabled = !bRunning;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAlarmReset_Click(object sender, EventArgs e)
        {
            //sscLib_cm.AxisControl.ClearAxisAlarm(Axis_Master);
            //testGIT
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bCheckRet = Int32.TryParse(comboBox2.SelectedIndex.ToString(), out int selectedIndex);
            if (bCheckRet)
            {
                PosPoint = selectedIndex + 1;
                MethodUpdatePostioningPointTable(PosPoint);
            }    
        }

        //----------------------------------------------------------------
        // Functions : Update Postioning Point table.
        //----------------------------------------------------------------
        public void MethodUpdatePostioningPointTable(int PosPointNum)
        {
            dataGridView2.RowCount = PosPointNum;
            for (int i = 0; i < PosPointNum; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                dataGridView2.Rows[i].Cells[1].Value = (500000 * i).ToString("F3");
                dataGridView2.Rows[i].Cells[2].Value = (100000).ToString("F3");
                dataGridView2.Rows[i].Cells[3].Value = (100).ToString("F3");
            }
        }

        //----------------------------------------------------------------
        // Functions : Update dataGridView1.
        //----------------------------------------------------------------
        public void MethodUpdateDataGridView1()
        {
            int row = 0;
            dataGridView1.RowCount = 0;
            for (int i = 0; i < MaxMonitorAxes; i++)
            {
                if (dataGridView[1, i].Value.ToString() == "Sync")
                {
                    dataGridView1.RowCount++;
                    dataGridView1[0, row].Value = "Axis" + i;
                    row++;
                }
            }
            comboBox1.Enabled = (row == 0) ? true : false;
            dataGridView1.ClearSelection();
        }
    }
}
