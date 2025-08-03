using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSCApiCLR;

namespace BasicMotionSample
{
    public partial class FormMultiMotionCtrl : Form
    {
        private const int MaxAxiShow = 10;
        private int AxesGroupSelected = 0;
        private bool bEnableUpdate = true;

        private SSCApiAxesMonitor sscApiAxesMonitor = null;     //SSCApiAxesMonitor class
        private static int formCount = 0;                       //Number of display forms.
        private SSCApiControl sscApiMotionCtrl = null;  //SSCApiControl class

        public FormMultiMotionCtrl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            comboBoxAxesGroup.SelectedIndex = (comboBoxAxesGroup.SelectedIndex <= 0) ? 0 : comboBoxAxesGroup.SelectedIndex - 1;
        }

        private void FormMultiMotionCtrl_Load(object sender, EventArgs e)
        {
            if (CreateSSCApiObject())
            {
                if (sscApiAxesMonitor.CreateDevice() && sscApiMotionCtrl.CreateDevice())
                {
                    //-------------------------------------------------
                    //Initial controls.
                    timer1.Enabled = true;
                    InitializeDataGridView();
                    
                }
                else
                {
                    MessageBox.Show("Err");
                    Close();
                }
            }
            
        }

        private void InitializeDataGridView()
        {
            /// dataGridView1 ////
            dataGridView1.RowCount = MaxAxiShow;
            for (int i = 0; i < MaxAxiShow; i++)
            {
                dataGridView1[0, i].Value = "0" + i;//axis
                dataGridView1[2, i].Value = "SvON";//svON
                dataGridView1[3, i].Value = "Home";//Home
                dataGridView1[4, i].Value = "Rst";//Reset
                dataGridView1[5, i].Value = "100000";//TargetPos
                dataGridView1[6, i].Value = "10000";//Velocity
                dataGridView1[8, i].Value = "AbsMove";//ABS/REL
                dataGridView1[9, i].Value = "100000";//JogSpeed
                dataGridView1[10, i].Value = "-";//Jog-
                dataGridView1[11, i].Value = "+";//Jog+
            }
            UpdateDataGridView(0);
        }
        private void UpdateDataGridView(int groupAxes)
        {
            /// dataGridView1 ////
            if (sscApiAxesMonitor.UpdateAxesStatus())
            {
                CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
                for (int i = 0 + MaxAxiShow * groupAxes; i < MaxAxiShow * (1 + groupAxes); i++)
                {
                    if (i < 128)
                    {
                        dataGridView1[0, i - MaxAxiShow * groupAxes].Value = i < 10 ? "0" + i : i.ToString();//axis
                        UpdateAxesMonitor(i - MaxAxiShow * groupAxes, ref axisStatus[i]);
                    } 
                }
            }
        }

        private void comboBoxAxesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            AxesGroupSelected = comboBoxAxesGroup.SelectedIndex;
            bEnableUpdate = true;
        }
        private void UpdateAxesMonitor(int row, ref CoreMotionAxisStatus axisStatus)
        {
            
            
            dataGridView1[1, row].Style.BackColor = axisStatus.ServoOn ? (axisStatus.HomeDone ? Color.Green : Color.Yellow) : (axisStatus.AmpAlarm ? Color.Red : Color.White);
            dataGridView1.Rows[row].ReadOnly = axisStatus.ServoOffline ? true : false;
            dataGridView1.Rows[row].DefaultCellStyle.BackColor = axisStatus.ServoOffline ? Color.DarkGray : Color.White;
        }

        private bool CreateSSCApiObject()
        {
            sscApiAxesMonitor = new SSCApiAxesMonitor();
            sscApiMotionCtrl = new SSCApiControl();
            return ((sscApiAxesMonitor != null) && (sscApiMotionCtrl != null));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (bEnableUpdate)
            {
                UpdateDataGridView(AxesGroupSelected);
                bEnableUpdate = false;
            }
            timer1.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
            bool bRet;
            int axis = e.RowIndex + MaxAxiShow * comboBoxAxesGroup.SelectedIndex;
            switch (e.ColumnIndex)
            {
                case 2://SrvON
                    bRet = e.RowIndex != -1 ? axisStatus[axis].ServoOn ? sscApiMotionCtrl.ServoOn(axis, false) : sscApiMotionCtrl.ServoOn(axis, true): false;
                    break;
                case 3://Home
                    bRet = e.RowIndex != -1 ? axisStatus[axis].HomeDone ? true : sscApiMotionCtrl.Home(axis) : false;
                    break;
                case 4://reset
                    break;
                case 7://checkBox
                    if (e.RowIndex != -1)
                    {
                        dataGridView1[8, e.RowIndex].Value = Convert.ToBoolean(dataGridView1[7, e.RowIndex].Value) ? "AbsMove" : "RelMove";
                    }                   
                    break;
                case 8:
                    break;
                default:
                    break;
            }
            bEnableUpdate = true;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool bRet;
            int axis = e.RowIndex + MaxAxiShow * comboBoxAxesGroup.SelectedIndex;
            double.TryParse(dataGridView1[9, e.RowIndex].Value.ToString(), out double velocity);
            double accDcc = 10000;
            switch (e.ColumnIndex)
            {
                case 10:
                    bRet = e.RowIndex != -1 ? sscApiMotionCtrl.StartJog(axis, -velocity, accDcc) : false;
                    break;
                case 11:
                    bRet = e.RowIndex != -1 ? sscApiMotionCtrl.StartJog(axis, velocity, accDcc) : false;
                    break;
                default:
                    break;
            }
            bEnableUpdate = true;
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool bRet;
            int axis = e.RowIndex + MaxAxiShow * comboBoxAxesGroup.SelectedIndex;
            switch (e.ColumnIndex)
            {
                case 10:
                    bRet = e.RowIndex != -1 ? sscApiMotionCtrl.ExecTimedStop(axis) : false;
                    break;
                case 11:
                    bRet = e.RowIndex != -1 ? sscApiMotionCtrl.ExecTimedStop(axis) : false;
                    break;
                default:
                    break;
            }
            bEnableUpdate = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            comboBoxAxesGroup.SelectedIndex = (comboBoxAxesGroup.SelectedIndex >= 12) ? 12 : comboBoxAxesGroup.SelectedIndex + 1;
        }
    }   
}
