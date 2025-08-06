﻿using System;
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
    public partial class FormAlarmMonitor : Form
    {
        private const int MaxAxiShow = 128;
        private bool bEnableUpdate = true;

        private SSCApiAxesMonitor sscApiAxesMonitor = null;     //SSCApiAxesMonitor class
        private static int formCount = 0;                       //Number of display forms.
        private SSCApiControl sscApiMotionCtrl = null;  //SSCApiControl class\
        private CoreMotion sscApiCoreMotion = null;
        public FormAlarmMonitor()
        {
            InitializeComponent();
        }

        private void InitializeDataGridView()
        {
            /// dataGridView1 ////
            dataGridView1.RowCount = MaxAxiShow;
            for (int i = 0; i < MaxAxiShow; i++)
            {
                dataGridView1[0, i].Value = i < 10 ? "0" + i : i.ToString();//axis
                dataGridView1[2, i].Value = "Rst";//Reset
            }
           //UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            /// dataGridView1 ////
            if (sscApiAxesMonitor.UpdateAxesStatus())
            {
                CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
                for (int i = 0 ; i < MaxAxiShow ; i++)
                {
                   UpdateAxesMonitor(i, ref axisStatus[i]);
                    
                }
            }
        }

        private void FormAlarmMonitor_Load(object sender, EventArgs e)
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

        private bool CreateSSCApiObject()
        {
            sscApiAxesMonitor = new SSCApiAxesMonitor();
            sscApiMotionCtrl = new SSCApiControl();
            return ((sscApiAxesMonitor != null) && (sscApiMotionCtrl != null));
        }

        private void UpdateAxesMonitor(int row, ref CoreMotionAxisStatus axisStatus)
        {
            dataGridView1[1, row].Style.BackColor = axisStatus.ServoOn ? (axisStatus.HomeDone ? Color.Green : Color.Yellow) : (axisStatus.AmpAlarm ? Color.Red : Color.White);
            dataGridView1.Rows[row].ReadOnly = axisStatus.ServoOffline ? true : false;
            dataGridView1.Rows[row].DefaultCellStyle.BackColor = axisStatus.ServoOffline ? Color.DarkGray : Color.White;
            dataGridView1[3, row].Value = axisStatus.AmpAlarm ? axisStatus.AmpAlarmCode.ToString() : "-";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            UpdateDataGridView();
            timer1.Enabled = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonResetAll_Click(object sender, EventArgs e)
        {
            CoreMotionAxisStatus[] axisStatus = sscApiAxesMonitor.GetAxesStatus();
            for (int i = 0; i < MaxAxiShow; i++)
            {
                int bRet = axisStatus[i].AmpAlarm ? sscApiCoreMotion.AxisControl.ClearAmpAlarm(i) : 0; 
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
