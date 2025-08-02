/*****************************************************************************/
/* FILE        : SSCApiSdoControl.cs                                         */
/* DESCRIPTION : SDO control class.                                          */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCApiCLR;
using SSCApiCLR.CCLinkApiCLR;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Struct : SDO parameters
    //----------------------------------------------------------------
    public struct stSdoParameters
    {
        public int slaveId;
        public int dropNo;
        public int index;
        public int subIndex;
    }

    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public class SSCApiSdoControl : SSCApiBase
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const string DeviceName = "SSCApiSdoControl";   //Device name
        private const uint SdoTimeout = 30000;                  //SDO Upload/Download Timeout [ms]

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private static SSCApi sscApi = new SSCApi();        //SSCApi class
        private CCLink sscApi_cclink = null;                //CCLink class
        private static int connectCnt = 0;                  //Number of connections.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public SSCApiSdoControl()
        {
            sscApi_cclink = new CCLink(sscApi);
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
        // Function : Upload data from the specified slave SDO. 
        //----------------------------------------------------------------
        public bool SdoUpload(stSdoParameters sdoUpload, byte[] sdoBuff,ref uint actualSize ,ref uint errorCode)
        {
            int nError = ErrorCode.None;
            nError = sscApi_cclink.SdoUpload(sdoUpload.slaveId, sdoUpload.dropNo, sdoUpload.index, sdoUpload.subIndex, sdoBuff, ref actualSize, ref errorCode, SdoTimeout);
            if (ErrorCode.None != nError)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CCLink.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "SdoUpload()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Function : Download data to the specified slave SDO. 
        //----------------------------------------------------------------
        public bool SdoDownload(stSdoParameters sdoDownload, byte[] sdoBuff, ref uint errorCode)
        {
            int nError = ErrorCode.None;
            uint actualSize = (uint)sdoBuff.GetLength(0);
            nError = sscApi_cclink.SdoDownload(sdoDownload.slaveId, sdoDownload.dropNo, sdoDownload.index, sdoDownload.subIndex, sdoBuff, ref errorCode, SdoTimeout);
            if (nError != ErrorCode.None)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CCLink.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "SdoDownload()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Function : Upload data from the specified slave SDO. 
        //            (callback function)
        //----------------------------------------------------------------
        public bool SdoUpload(stSdoParameters sdoUpload, CCLinkSdoUploadCallBackFunc callbackFunc)
        {
            int nError = sscApi_cclink.SdoUpload(sdoUpload.slaveId, sdoUpload.dropNo, sdoUpload.index, sdoUpload.subIndex, callbackFunc, SdoTimeout);
            if (ErrorCode.None != nError)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CCLink.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "SdoUpload()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Function : Download data to the specified slave SDO. 
        //            (callback function)
        //----------------------------------------------------------------
        public bool SdoDownload(stSdoParameters sdoDownload, byte[] sdoData, CCLinkSdoDownloadCallBackFunc callbackFunc)
        {
            int nError = sscApi_cclink.SdoDownload(sdoDownload.slaveId, sdoDownload.dropNo, sdoDownload.index, sdoDownload.subIndex, sdoData, callbackFunc, SdoTimeout);
            if (ErrorCode.None != nError)
            {
                MessageBox.Show
                (
                    String.Format(SampleConstants.sErrMsgFormat, nError, CCLink.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "SdoDownload()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }
    }
}
