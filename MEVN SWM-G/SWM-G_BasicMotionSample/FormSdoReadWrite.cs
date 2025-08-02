/*****************************************************************************/
/* FILE        : FormSdoReadWrite.cs                                         */
/* DESCRIPTION : SDO read / write form.                                      */
/*****************************************************************************/
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
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public partial class FormSdoReadWrite : Form
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const int SdoMaxLen = 64;               //Number of SDO read/Write buffer.[byte]

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private SSCApiSdoControl sscApiSdoCtrl = null;  //SSCApiSdoControl class
        private static int formCount = 0;               //Number of display forms.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public FormSdoReadWrite()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------
        // Function : Occurs before a form is displayed for 
        //            the first time.
        //----------------------------------------------------------------
        private void FormSdoReadWrite_Load(object sender, EventArgs e)
        {
            bool bNormal = false;
            formCount++;
            if (formCount <= SampleConstants.FormShowMax)
            {   //formCount : 1 - 5
                if (CreateObject())
                {
                    if (sscApiSdoCtrl.CreateDevice())
                    {
                        //-------------------------------------------------
                        //Initial controls.
                        comboLength.Text = "1";
                        textSlaveID.Text = String.Format("{0:D}", formCount - 1);
                        textData.MaxLength = SampleConstants.MaxSdoDataLength;
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
        // Functions : Occurs when the Axes Monitor button control is 
        //             clicked.
        //----------------------------------------------------------------
        private void buttonRead_Click(object sender, EventArgs e)
        {
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            stSdoParameters sdoParam;
            if (
                int.TryParse(textSlaveID.Text, out sdoParam.slaveId) &&
                int.TryParse(textDropNo.Text, out sdoParam.dropNo) &&
                int.TryParse(textIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.index) &&
                int.TryParse(textSubIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.subIndex)
            )
            {
                byte[] sdoBuff = new byte[SdoMaxLen];
                uint actualSize = (uint)sdoBuff.GetLength(0);
                uint errorCode = 0;

                //SDO Upload
                if (sscApiSdoCtrl.SdoUpload(sdoParam, sdoBuff, ref actualSize, ref errorCode))
                {
                    string readData = "";
                    SampleComFunc.byteDataToString(sdoBuff, actualSize, out readData);
                    textData.Text = readData;
                    comboLength.Text = actualSize.ToString();
                }
                else
                {
                    ;
                }
            }
            Cursor.Current = preCursor;
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Axes Monitor button control is 
        //             clicked.
        //----------------------------------------------------------------
        private void buttonWrite_Click(object sender, EventArgs e)
        {
            Cursor preCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            //Input Data
            stSdoParameters sdoParam;
            if (
                int.TryParse(textSlaveID.Text, out sdoParam.slaveId) &&
                int.TryParse(textDropNo.Text, out sdoParam.dropNo) &&
                int.TryParse(textIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.index) &&
                int.TryParse(textSubIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.subIndex)
            )
            {
                int dataSize = int.Parse(comboLength.Text);
                byte[] sdoBuff;
                uint errorCode = 0;
                SampleComFunc.stringToByteData(textData.Text, dataSize, out sdoBuff);   //string -> byte[]
                sscApiSdoCtrl.SdoDownload(sdoParam, sdoBuff, ref errorCode);
            }
            Cursor.Current = preCursor;
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Close button control is clicked.
        //----------------------------------------------------------------
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();    //Form close.
        }

        //----------------------------------------------------------------
        // Functions : Occurs after the form is closed.
        //----------------------------------------------------------------
        private void FormSdoReadWrite_FormClosed(object sender, FormClosedEventArgs e)
        {
            formCount--;
            sscApiSdoCtrl?.DeviceClose();
        }

        //----------------------------------------------------------------
        // Functions : Occurs when a character. key is pressed while 
        //             the textHex control has focus.
        //----------------------------------------------------------------
        private void textHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            SampleComFunc.CheckKeyPressNumHex(e);   //Input key check.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when a character. key is pressed while 
        //             the textNum control has focus.
        //----------------------------------------------------------------
        private void textNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            SampleComFunc.CheckKeyPressNum(e);     //Input key check.(Integer)
        }

        //----------------------------------------------------------------
        // Functions : Create object
        //----------------------------------------------------------------
        private bool CreateObject()
        {
            sscApiSdoCtrl = new SSCApiSdoControl();
            return (sscApiSdoCtrl != null);
        }
    }
}
