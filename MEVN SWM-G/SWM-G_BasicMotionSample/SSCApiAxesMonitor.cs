/********************************************************************************/
/* FILE        : SSCApiAxesMonitor.cs                                           */
/* DESCRIPTION : This class is uses position command functions to positioning.  */
/********************************************************************************/
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
    public class SSCApiAxesMonitor : SSCApiBase
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const string DeviceName = "SSCApiAxesMonitor";  //Device name

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        protected static SSCApi sscApi = new SSCApi();  //SSCApi class
        protected CoreMotion sscApi_cm = null;          //CoreMotion class
        protected CoreMotionAxisStatus[] axesStatus;    //CoreMotionAxisStatus class
        private static int connectCnt = 0;              //Number of connections.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public SSCApiAxesMonitor()
        {
            sscApi_cm = new CoreMotion(sscApi);
        }

        //----------------------------------------------------------------
        // Functions : SSCApi create device.
        //----------------------------------------------------------------
        public bool CreateDevice()
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
        public bool DeviceClose()
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
        // Functions : Update axes status
        //----------------------------------------------------------------
        public bool UpdateAxesStatus()
        {
            CoreMotionStatus motionStatus = new CoreMotionStatus();
            int nError = sscApi_cm.GetStatus(ref motionStatus);
            if (ErrorCode.None == nError)
            {
                axesStatus = motionStatus.AxesStatus;
            }
            if (ErrorCode.None != nError)
            {
                MessageBox.Show(
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "GetStatus()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Get core motion axis status.
        //----------------------------------------------------------------
        public ref CoreMotionAxisStatus[] GetAxesStatus()
        {
            return ref axesStatus;
        }
    }
}
