/*****************************************************************************/
/* FILE        : SampleConstants.cs                                          */
/* DESCRIPTION : Sample constant definition.                                 */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    static class SampleConstants
    {
        //-------------------------------------------------
        //Form
        public const int FormShowMax = 5;                      //Maximum number of displays

        //-------------------------------------------------
        //Maximum input character for text control.
        public const int MaxDecimalLength = 12;                 //Decimal
        public const int MaxAxisLength = 3;                     //Axis
        public const int MaxSlaveIdLength = 3;                  //DlaveID
        public const int MaxDropNoLength = 1;                   //DropNo
        public const int MaxIndexLength = 4;                    //Index
        public const int MaxSubIndexLength = 2;                 //SubIndex
        public const int MaxSdoDataLength = 8;                  //SDO data

        //-------------------------------------------------
        //SSCApi
        public const string sSWM_G_Path = "C:\\Program Files\\MotionSoftware\\SWM-G\\";     //SWM-G installation path

        //-------------------------------------------------
        //Error Message
        public const string sErrMsgFormat = "ErrorCode:0x{0:X}\n{1:G}";
        public const string sSodErrMsgFormat = "No.{0:D}\nErrorCode:0x{1:X}\n{2:G}";
        public const string sErrMsgTitle  = "API error.[{0:G}]";
    }
}
