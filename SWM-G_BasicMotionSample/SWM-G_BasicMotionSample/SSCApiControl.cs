/*****************************************************************************/
/* FILE        : SSCApiControl.cs                                            */
/* DESCRIPTION : SSCApi positioning class.                                   */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCApiCLR;
using System.Windows.Forms;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public class SSCApiControl : SSCApiBase
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const string DeviceName = "SSCApiControl";      //Device name
        private const int StopTimeMilliseconds = 1;             //Time in milliseconds to stop.[1ms]

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private static SSCApi sscApi = new SSCApi();            //SSCApi class
        protected CoreMotion sscApi_cm = null;                  //CoreMotion class
        private static int connectCnt = 0;                      //Number of connections.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public SSCApiControl()
        {
            sscApi_cm = new CoreMotion(sscApi);
        }

        //----------------------------------------------------------------
        // Functions : SSCApi create device.
        //----------------------------------------------------------------
        public virtual bool CreateDevice()
        {
            bool bRet = true;
            if (0 == connectCnt)
            {   //First connection.
                bRet = base.CreateDevice(ref sscApi, DeviceName);
            }
            if (bRet)
            {
                connectCnt++;
            }
            return bRet;
        }

        //----------------------------------------------------------------
        // Functions : SSCApi close device.
        //----------------------------------------------------------------
        public virtual bool DeviceClose()
        {
            bool bRet = false;
            connectCnt--;
            if (0 == connectCnt)
            {   //Last connection.
                bRet = base.DeviceClose(ref sscApi);
            }
            return bRet;
        }

        //----------------------------------------------------------------
        // Functions : Turn a servo drive in the servo network on or off.
        //----------------------------------------------------------------
        public bool ServoOn(int axis, bool bSvOn)
        {
            int nError = ErrorCode.None;
            int newState = bSvOn ? 1 : 0;
            // Set servo on.
            nError = sscApi_cm.AxisControl.SetServoOn(axis, newState);
            if (ErrorCode.None != nError)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "GetStatus()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Read the axis status.
        //----------------------------------------------------------------
        public bool GetServoOnState(int axis)
        {
            bool bRet = false;
            if (axis < Constants.MaxAxes)
            {
                int nError = ErrorCode.None;
                CoreMotionStatus cmStatus = new CoreMotionStatus();
                nError = sscApi_cm.GetStatus(ref cmStatus);
                if (ErrorCode.None == nError)
                {
                    bRet = cmStatus.AxesStatus[axis].ServoOn;
                }
            }
            return bRet;
        }

        //----------------------------------------------------------------
        // Functions : Start homing an axis. 
        //----------------------------------------------------------------
        public bool Home(int axis)
        {
            int nError = ErrorCode.None;
            // Homing.
            Config.HomeParam homeParam = new Config.HomeParam();
            nError = sscApi_cm.Config.GetHomeParam(axis, ref homeParam);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "GetHomeParam()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                homeParam.HomeType = Config.HomeType.CurrentPos;
                nError = sscApi_cm.Config.SetHomeParam(axis, homeParam);
                if (nError != ErrorCode.None)
                {
                    MessageBox.Show
                    (
                        String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                        String.Format(SampleConstants.sErrMsgTitle, "SetHomeParam()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    nError = sscApi_cm.Home.StartHome(axis);
                    if (nError != ErrorCode.None)
                    {
                        MessageBox.Show
                        (
                            String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                            String.Format(SampleConstants.sErrMsgTitle, "StartHome()"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    else
                    {
                        nError = sscApi_cm.Motion.Wait(axis);
                        if (nError != ErrorCode.None)
                        {
                            MessageBox.Show
                            (
                                String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                                String.Format(SampleConstants.sErrMsgTitle, "Wait()"),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                }
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Start a relative position motion command 
        // for a single axis.
        //----------------------------------------------------------------
        public bool StartMov(int axis, double target, double velocity, double accdec)
        {
            //-----------------------------------------------------------------
            // Create a command value.
            //-----------------------------------------------------------------
            Motion.PosCommand posCommand = new Motion.PosCommand();
            posCommand.Profile.Type = SSCApiCLR.ProfileType.Trapezoidal;
            posCommand.Axis = axis;
            posCommand.Target = target;
            posCommand.Profile.Velocity = velocity;
            posCommand.Profile.Acc = accdec;
            posCommand.Profile.Dec = accdec;

            int nError = sscApi_cm.Motion.StartMov(posCommand);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "StartMov()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Start an absolute position motion command
        //             for a single axis.
        //----------------------------------------------------------------
        public bool StartPos(int axis, double target, double velocity, double accdec)
        {
            //-----------------------------------------------------------------
            // Create a command value.
            //-----------------------------------------------------------------
            Motion.PosCommand posCommand = new Motion.PosCommand();
            posCommand.Profile.Type = SSCApiCLR.ProfileType.Trapezoidal;
            posCommand.Axis = axis;
            posCommand.Target = target;
            posCommand.Profile.Velocity = velocity;
            posCommand.Profile.Acc = accdec;
            posCommand.Profile.Dec = accdec;

            //-----------------------------------------------------------------
            // Execute command to move from current position to 
            // specified position.
            //-----------------------------------------------------------------
            int nError = sscApi_cm.Motion.StartPos(posCommand);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "StartPos()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Start an absolute triggered position motion 
        //             command for a single axis.
        //             (Trigger type : RemainingDistance )
        //----------------------------------------------------------------
        public bool StartPos(int axis, double target, double velocity, double accdec, double triggerValue)
        {
            //-----------------------------------------------------------------
            // Create a trigger command value.
            //-----------------------------------------------------------------
            Motion.TriggerPosCommand triggerPosCommand = new Motion.TriggerPosCommand();
            triggerPosCommand.Profile.Type = SSCApiCLR.ProfileType.Trapezoidal;
            triggerPosCommand.Axis = axis;
            triggerPosCommand.Target = target;
            triggerPosCommand.Profile.Velocity = velocity;
            triggerPosCommand.Profile.Acc = accdec;
            triggerPosCommand.Profile.Dec = accdec;
            triggerPosCommand.Trigger.TriggerAxis = axis;
            triggerPosCommand.Trigger.TriggerType = TriggerType.RemainingDistance;
            triggerPosCommand.Trigger.TriggerValue = triggerValue;

            //-----------------------------------------------------------------
            // Execute command to move from current position to 
            // specified position.
            //-----------------------------------------------------------------
            int nError = sscApi_cm.Motion.StartPos(triggerPosCommand);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "StartPos()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Start a blocking wait command, returning only 
        //             when the axis becomes idle.
        //----------------------------------------------------------------
        public bool Wait(int axis)
        {
            //-----------------------------------------------------------------
            // Start a blocking wait command, returning only when 
            // the axis becomes idle.
            //-----------------------------------------------------------------
            int nError = sscApi_cm.Motion.Wait(axis);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "Wait()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Start a blocking wait command, Wait until 
        //             the specified axes are all executing motion
        //             or in Idle state
        //----------------------------------------------------------------
        public bool WaitMotionStarted(int axis)
        {
            //-----------------------------------------------------------------
            // Create a wait condition value.
            //-----------------------------------------------------------------
            Motion.WaitCondition waitCond = new Motion.WaitCondition();
            waitCond.WaitConditionType = Motion.WaitConditionType.MotionStarted;
            waitCond.AxisCount = 1;
            waitCond.Axis[0] = axis;

            //-----------------------------------------------------------------
            // Starts the blocking wait command and waits until 
            // the specified wait condition is true.
            //-----------------------------------------------------------------
            int nError = sscApi_cm.Motion.Wait(waitCond);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "Wait()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Start a JOG motion command for a single axis.
        //----------------------------------------------------------------
        public bool StartJog(int axis, double velocity, double accdec)
        {
            //-----------------------------------------------------------------
            // Create a command value.
            //-----------------------------------------------------------------
            Motion.JogCommand jogCommand = new Motion.JogCommand();
            jogCommand.Axis = axis;
            jogCommand.Profile.Type = SSCApiCLR.ProfileType.Trapezoidal;
            jogCommand.Profile.Velocity = velocity;
            jogCommand.Profile.Acc = accdec;
            jogCommand.Profile.Dec = accdec;

            //-----------------------------------------------------------------
            // Execute the command to execute JOG.
            //-----------------------------------------------------------------
            int nError = sscApi_cm.Motion.StartJog(jogCommand);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "StartJog()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Pause the execution of a position command 
        //             for an axis.
        //----------------------------------------------------------------
        public bool Pause(int axis)
        {
            int nError = sscApi_cm.Motion.Pause(axis);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "Pause()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Resume the execution of a paused position command 
        //             for an axis.
        //----------------------------------------------------------------
        public bool Resume(int axis)
        {
            int nError = sscApi_cm.Motion.Resume(axis);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "Resume()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Stop an axis that is currently in motion in 
        //             the specified amount of time using a trapezoidal profile.
        //----------------------------------------------------------------
        public bool ExecTimedStop(int axis, double timeMilliseconds = StopTimeMilliseconds)
        {
            int nError = sscApi_cm.Motion.ExecTimedStop(axis, timeMilliseconds);    //Motion stop.
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "ExecTimedStop()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }
    }
}
