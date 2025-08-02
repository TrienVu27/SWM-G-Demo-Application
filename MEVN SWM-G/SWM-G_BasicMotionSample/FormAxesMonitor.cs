/*****************************************************************************/
/* FILE        : FormAxesMonitor.cs                                          */
/* DESCRIPTION : Axes monitor form                                           */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSCApiCLR;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public partial class FormAxesMonitor : Form
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const int MaxMonitorAxes = 16;  //Number of display axes.
        private const int MaxMonitorItem = 5;   //Number of display items.
        private const int MonInterval = 50;   //Monitor Interval 50[ms]

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private SSCApiAxesMonitor sscApiAxesMonitor = null;     //SSCApiAxesMonitor class
        private static int formCount = 0;                       //Number of display forms.
        private int selectAxis = 0;                             //Selection axis

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public FormAxesMonitor()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------
        // Function : Occurs before a form is displayed for the first time.
        //            Create device and Initial controls.
        //----------------------------------------------------------------
        private void FormAxesMonitor_Load(object sender, EventArgs e)
        {
            bool bNormal = false;
            formCount++;
            if (formCount <= SampleConstants.FormShowMax)
            {   //formCount : 1 - 5
                if (CreateSSCApiObject())
                {
                    if (sscApiAxesMonitor.CreateDevice())
                    {
                        //-------------------------------------------------
                        //Initial controls.
                        InitializeDataGridView();
                        comboBoxAxis.SelectedIndex = formCount - 1;
                        timerMonitor.Interval = MonInterval;
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
        // Functions : Occurs when the Monitor Start/Stop button control is clicked.
        //----------------------------------------------------------------
        private void buttonMonitor_Click(object sender, EventArgs e)
        {
            buttonMonitor.Text = timerMonitor.Enabled ? "Monitor Start": "Monior Stop";                  //Button text change.
            buttonMonitor.BackColor = timerMonitor.Enabled ? SystemColors.Control : Color.GreenYellow;   //Button color change
            buttonMonitor.UseVisualStyleBackColor = timerMonitor.Enabled ? true : false;

            timerMonitor.Enabled = !timerMonitor.Enabled;
            if(timerMonitor.Enabled)
            {
                ChangeMonitorAxis(selectAxis);
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Close button control is clicked.
        //----------------------------------------------------------------
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();    //Form close.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the comboBoxAxis has changed.
        //----------------------------------------------------------------
        private void comboBoxAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(comboBoxAxis.SelectedItem.ToString(), out selectAxis))
            {
                selectAxis = 0; //Abnormal selection.
            }
            ChangeMonitorAxis(selectAxis);
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the specified timer interval
        //             has elapsed and the timer is enabled.
        //----------------------------------------------------------------
        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            timerMonitor.Enabled = false;
            labelMonitor.Text = (labelMonitor.Text == "") ? "*" : "";   //Status text change.
            
            //Update monitor.
            if (sscApiAxesMonitor.UpdateAxesStatus())
            {
                CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
                for (int i = 0; i < MaxMonitorAxes; i++)  
                {
                    UpdateAxesMonitor(i, ref axisStatus[i + selectAxis]);
                }
                timerMonitor.Enabled = true;
            }
            else
            {   //Update error. Monitor stopped.
                buttonMonitor.Text = "Monitor Start";           //Button text change.
                buttonMonitor.BackColor = SystemColors.Control; //Burron color change.
                buttonMonitor.UseVisualStyleBackColor = true;
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs after the form is closed.
        //----------------------------------------------------------------
        private void FormAxesMonitor_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCount--;
            sscApiAxesMonitor?.DeviceClose();
        }

        //----------------------------------------------------------------
        // Functions : Initialize data grid view.
        //----------------------------------------------------------------
        private void InitializeDataGridView()
        {
            dataGridView.ReadOnly = true;
            dataGridView.ColumnCount = MaxMonitorItem + 1;
            dataGridView.RowCount = MaxMonitorAxes;

            dataGridView.Columns[0].HeaderText = "Axis";
            dataGridView.Columns[1].HeaderText = "Servo ON";
            dataGridView.Columns[2].HeaderText = "Pos Cmd";
            dataGridView.Columns[3].HeaderText = "Actual Pos";
            dataGridView.Columns[4].HeaderText = "Velocity Cmd";
            dataGridView.Columns[5].HeaderText = "Op State";

            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView.Columns[0].Width = 40;
            dataGridView.Columns[1].Width = 60;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 100;
            dataGridView.Columns[4].Width = 100;
            dataGridView.Columns[5].Width = 70;

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                dataGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView.ClearSelection();
            foreach (DataGridViewColumn item in dataGridView.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }

        //----------------------------------------------------------------
        // Functions : Change monitor axis.
        //----------------------------------------------------------------
        private void ChangeMonitorAxis(int Axis)
        {
            if (Axis < Constants.MaxAxes)
            {
                for (int i = 0; i < MaxMonitorAxes; i++)
                {   //Initil display.
                    dataGridView[0, i].Value = i + Axis;    //Axis
                    dataGridView[1, i].Value = "-";         //Servo On
                    dataGridView[2, i].Value = "-";         //Pos Cmd
                    dataGridView[3, i].Value = "-";         //Actual Pos
                    dataGridView[4, i].Value = "-";         //Velocity Cmd
                    dataGridView[5, i].Value = "-";         //Op State
                }
            }
        }

        //----------------------------------------------------------------
        // Functions : Update the axis monitor.
        //----------------------------------------------------------------
        private void UpdateAxesMonitor(int row, ref CoreMotionAxisStatus axisStatus)
        {
            dataGridView[1, row].Value = axisStatus.ServoOn ? "ON" : "OFF";         //Servo On
            dataGridView[2, row].Value = axisStatus.PosCmd.ToString("F3");          //Pos Cmd
            dataGridView[3, row].Value = axisStatus.ActualPos.ToString("F3");       //Actual Pos
            dataGridView[4, row].Value = axisStatus.VelocityCmd.ToString("F3");     //Velocity Cmd
            dataGridView[5, row].Value = SSCApiBase.OP_STATE(axisStatus.OpState);   //Op State
        }

        //----------------------------------------------------------------
        // Functions : Create object
        //----------------------------------------------------------------
        private bool CreateSSCApiObject()
        {
            sscApiAxesMonitor = new SSCApiAxesMonitor();
            return (sscApiAxesMonitor != null);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
