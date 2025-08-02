/*****************************************************************************/
/* FILE        : FormMotionControl.cs                                        */
/* DESCRIPTION : Single axis positioning / JOG form.                         */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SSCApiCLR;
using System.Windows.Forms;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class :
    //----------------------------------------------------------------
    public partial class FormMotionControl : Form
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const int MonInterval = 50;  //Monitor Interval 50[ms]

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private SSCApiControl sscApiMotionCtrl = null;  //SSCApiControl class
        private static int formCount = 0;               //Number of display forms.
        private bool bPause = false;                    //Pausing flag.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public FormMotionControl()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------
        // Function : Occurs before a form is displayed for the first time.
        //            Create device and Initial controls.
        //----------------------------------------------------------------
        private void FormMotionControl_Load(object sender, EventArgs e)
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
                        //Input Max Length
                        textAxis.MaxLength = SampleConstants.MaxAxisLength;
                        textTarget.MaxLength = SampleConstants.MaxDecimalLength;
                        textVelocity.MaxLength = SampleConstants.MaxDecimalLength;
                        textAccDec.MaxLength = SampleConstants.MaxDecimalLength;
                        timerMonitor.Interval = MonInterval;
                        timerMonitor.Enabled = true;
                        //-------------------------------------------------
                        //Updata controls.
                        UpdateButtonControl();
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
        // Functions : Occurs when the Servo ON button control is clicked.
        //             Execute the GetServoOnState().
        //----------------------------------------------------------------
        private void buttonServoON_Click(object sender, EventArgs e)
        {
            int axis;
            if (Int32.TryParse(textAxis.Text,out axis))
            {
                bool bSvOn = !sscApiMotionCtrl.GetServoOnState(axis);
                sscApiMotionCtrl.ServoOn(axis, bSvOn);
                if (!bSvOn)
                {
                    bPause = false;
                }
            }
            UpdateButtonControl();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Home button control is clicked.
        //             Execute the Home
        //----------------------------------------------------------------
        private void buttonHome_Click(object sender, EventArgs e)
        {
            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
                sscApiMotionCtrl.Home(axis);
                
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Stop button control is clicked.
        //             Execute the ExecTimedStop().
        //----------------------------------------------------------------
        private void buttonStop_Click(object sender, EventArgs e)
        {
            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
                if (sscApiMotionCtrl.ExecTimedStop(axis))   //Motion stop.
                {
                    bPause = false;
                }
                UpdateButtonControl();
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the AbsMove button control is clicked.
        //             Execute the StartPos().
        //----------------------------------------------------------------
        private void buttonAbs_Click(object sender, EventArgs e)
        {
            int axis;
            double target, velocity, accDcc;
            if (
                Int32.TryParse(textAxis.Text, out axis) &&
                double.TryParse(textTarget.Text, out target) &&
                double.TryParse(textVelocity.Text, out velocity) &&
                double.TryParse(textAccDec.Text, out accDcc)
            )
            {
                sscApiMotionCtrl.StartPos(axis, target, velocity, accDcc);
                bPause = false;
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the RelMove button control is clicked.
        //             Execute the StartMov().
        //----------------------------------------------------------------
        private void buttonRel_Click(object sender, EventArgs e)
        {
            int axis;
            double target, velocity, accDcc;
            if (
                Int32.TryParse(textAxis.Text, out axis) &&
                double.TryParse(textTarget.Text, out target) &&
                double.TryParse(textVelocity.Text, out velocity) &&
                double.TryParse(textAccDec.Text, out accDcc)
            )
            {
                sscApiMotionCtrl.StartMov(axis, target, velocity, accDcc);
                bPause = false;
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
        // Functions : Occurs when the Pause/Resume button control is clicked.
        //             Execute the Pause() or Resume().
        //----------------------------------------------------------------
        private void buttonPause_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
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
                UpdateButtonControl();
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the mouse pointer is over 
        //             the JOG(-) button and a mouse button is pressed.
        //             Execute the StartJog().
        //----------------------------------------------------------------
        private void buttonJogM_MouseDown(object sender, MouseEventArgs e)
        {
            buttonJogM.BackColor = Color.GreenYellow;   //Button color change
            buttonJogM.UseVisualStyleBackColor = false;

            int axis;
            double velocity, accDcc;
            if (
                Int32.TryParse(textAxis.Text, out axis) &&
                double.TryParse(textVelocity.Text, out velocity) &&
                double.TryParse(textAccDec.Text, out accDcc)
            )
            {
                if (!sscApiMotionCtrl.StartJog(axis, -velocity, accDcc))
                {
                    buttonJogM.BackColor = SystemColors.Control;   //Button color change    
                    buttonJogM.UseVisualStyleBackColor = true;
                }
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the mouse pointer is over 
        //             the JOG(+) button and a mouse button is pressed.
        //             Execute the StartJog().
        //----------------------------------------------------------------
        private void buttonJogP_MouseDown(object sender, MouseEventArgs e)
        {
            buttonJogP.BackColor = Color.GreenYellow;   //Button color change
            buttonJogP.UseVisualStyleBackColor = false;

            int axis;
            double velocity, accDcc;
            if (
                Int32.TryParse(textAxis.Text, out axis) &&
                double.TryParse(textVelocity.Text, out velocity) &&
                double.TryParse(textAccDec.Text, out accDcc)
            )
            {
                if (!sscApiMotionCtrl.StartJog(axis, velocity, accDcc))
                {
                    buttonJogP.BackColor = SystemColors.Control;   //Button color change
                    buttonJogP.UseVisualStyleBackColor = true;
                }
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the mouse pointer is over
        //             the  JOG button and a mouse JOG button is released.
        //             Execute the ExecTimedStop().
        //----------------------------------------------------------------
        private void buttonJog_MouseUp(object sender, MouseEventArgs e)
        {
            buttonJogM.BackColor = SystemColors.Control;   //Button color change
            buttonJogM.UseVisualStyleBackColor = true;
            buttonJogP.BackColor = SystemColors.Control;   //Button color change
            buttonJogP.UseVisualStyleBackColor = true;

            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
                sscApiMotionCtrl.ExecTimedStop(axis);   //Motion stop.
                bPause = false;
            }
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
        // Functions : Occurs when a character. key is pressed 
        //             while the textAxis control has focus.
        //----------------------------------------------------------------
        private void textValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            SampleComFunc.CheckKeyPressNumPoint(e, ((TextBox)sender).Text);     //Input key check.(Decimal)
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the specified timer interval
        //             has elapsed and the timer is enabled.
        //             Update button control.
        //----------------------------------------------------------------
        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            timerMonitor.Enabled = false;
            UpdateButtonControl();      //Update button control.
            timerMonitor.Enabled = true;
        }

        //----------------------------------------------------------------
        // Functions : Occurs after the form is closed.
        //----------------------------------------------------------------
        private void FormMotionControl_FormClosed(object sender, FormClosedEventArgs e)
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
                sscApiMotionCtrl.DeviceClose();
            }
        }

        //----------------------------------------------------------------
        // Functions : Update button control.
        //----------------------------------------------------------------
        private void UpdateButtonControl()
        {
            int axis;
            if (Int32.TryParse(textAxis.Text, out axis))
            {
                bool bSvOn = sscApiMotionCtrl.GetServoOnState(axis);
                buttonServoON.BackColor = bSvOn ? Color.GreenYellow : SystemColors.Control;   //Button color change
                buttonServoON.UseVisualStyleBackColor = bSvOn ? false : true;
            }

            buttonPause.Text = bPause ? "Resume" : "Pause";                              //Button text change.
            buttonPause.BackColor = bPause ? Color.GreenYellow : SystemColors.Control;   //Button color change
            buttonPause.UseVisualStyleBackColor = bPause ? false : true;
        }

        //----------------------------------------------------------------
        // Functions : Create object
        //----------------------------------------------------------------
        private bool CreateSSCApiObject()
        {
            sscApiMotionCtrl = new SSCApiControl();
            return (sscApiMotionCtrl != null);
        }
    }
}
