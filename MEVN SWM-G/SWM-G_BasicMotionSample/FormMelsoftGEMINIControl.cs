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
    public partial class FormMelsofGEMINIControl : Form
    {
        private SSCApiAxesMonitor sscApiAxesMonitor = null;     //SSCApiAxesMonitor class
        private static int formCount = 0;                       //Number of display forms.
        private SSCApiControl sscApiMotionCtrl = null;  //SSCApiControl class\

        static SSCApi sscLib = new SSCApi();
        private CoreMotion sscLib_cm = new CoreMotion(sscLib);

        public FormMelsofGEMINIControl()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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
            }
            
        }

        private void FormMelsofGEMINIControl_Load(object sender, EventArgs e)
        {
            radioButtonMonitor.Checked = true;
            timer1.Enabled = true;
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

        }
    }
}
