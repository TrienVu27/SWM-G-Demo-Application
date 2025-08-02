/*****************************************************************************/
/* FILE        : SSCApiControlForThreads.cs                                  */
/* DESCRIPTION : SSCApi positioning class.  (Continuous execution)           */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSCApiCLR;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public class SSCApiControlForThreads : SSCApiControl
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const string DeviceNameFromat = "SSCApiControlForThreads{0:D}";     //Device name

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private SSCApi sscApi = new SSCApi();       //SSCApi class
        private static int connectCnt = 0;          //Number of connections.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public SSCApiControlForThreads()
        {
            sscApi_cm = new CoreMotion(sscApi);
        }

        //----------------------------------------------------------------
        // Functions : SSCApi create device.
        //----------------------------------------------------------------
        public override bool CreateDevice()
        {   
            bool bRet = base.CreateDevice(ref sscApi, String.Format(DeviceNameFromat, connectCnt));
            if (bRet)
            {
                connectCnt++;
            }
            return bRet;
        }

        //----------------------------------------------------------------
        // Functions : SSCApi close device.
        //----------------------------------------------------------------
        public override bool DeviceClose()
        {
            return base.DeviceClose(ref sscApi);
        }

    }
}
