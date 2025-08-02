/*****************************************************************************/
/* FILE        : FormSdoBatchReadWrite.cs                                    */
/* DESCRIPTION : SDO batch read / write form.                                */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SSCApiCLR;
using SSCApiCLR.CCLinkApiCLR;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Enume : Execution state
    //----------------------------------------------------------------
    enum ExecuteStatus
    {
        Idle,
        Running,
        Completed,
        InputError
    }

    //----------------------------------------------------------------
    // Struct : SDO parameter controls.
    //----------------------------------------------------------------
    public struct stSdoParametersControls
    {
        public CheckBox checkBox;
        public TextBox textSlaveId;
        public TextBox textDropNo;
        public TextBox textIndex;
        public TextBox textSubIndex;

        public stSdoParametersControls(CheckBox checkBox, TextBox textSlaveId, TextBox textDropNo, TextBox textIndex, TextBox textSubIndex)
        {
            this.checkBox = checkBox;
            this.textSlaveId = textSlaveId;
            this.textDropNo = textDropNo;
            this.textIndex = textIndex;
            this.textSubIndex = textSubIndex;
        }
    }

    //----------------------------------------------------------------
    // Struct : SDO read execution result control.
    //----------------------------------------------------------------
    public struct stSdoReadResultControls
    {
        public Label labelData;
        public Label labelLen;
        public Label labelStatus;

        public stSdoReadResultControls(Label labelReadData, Label labelReadLength, Label labelReadStatus)
        {
            labelData = labelReadData;
            labelLen = labelReadLength;
            labelStatus = labelReadStatus;
        }
    }

    //----------------------------------------------------------------
    // Struct : SDO write execution result control.
    //----------------------------------------------------------------
    public struct stSdoWriteResultControls
    {
        public TextBox textData;
        public ComboBox comboLen;
        public Label labelStatus;

        public stSdoWriteResultControls(TextBox textWriteData, ComboBox comboWriteLength, Label labelWriteStatus)
        {
            textData = textWriteData;
            comboLen = comboWriteLength;
            labelStatus = labelWriteStatus;
        }
    }

    //----------------------------------------------------------------
    // Struct : SDO execution result value.
    //----------------------------------------------------------------
    public struct stSdoResultValue
    {
        public int result;
        public uint errCode;
        public string status;
        public string data;
        public int len;

        public stSdoResultValue(int result, uint errCode, string status, string data = "", int len = 1)
        {
            this.result = result;
            this.errCode = errCode;
            this.status = status;
            this.data = data;
            this.len = len;
        }
    }


    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public partial class FormSdoBatchReadWrite : Form
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const int MaxSdoNo = 4;
        private const string StatusSdoErrorFormat = "SDO error.(0x{0:X})";
        private const string StatusApiErrorFormat = "API error.(0x{0:X})";

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------
        private SSCApiSdoControl sscApiSdoCtrl = null;      //SSCApiSdoControl class
        private static int formCount = 0;                   //Number of display forms.

        //---------------------------------------
        //SDO Upload call back functions.
        private CCLinkSdoUploadCallBackFunc[] ccLinkSdoUploadCallBackFunc = new CCLinkSdoUploadCallBackFunc[MaxSdoNo];
        //---------------------------------------
        //SDO Download call back functions.
        private CCLinkSdoDownloadCallBackFunc[] ccLinkSdoDownloadCallBackFunc = new CCLinkSdoDownloadCallBackFunc[MaxSdoNo];

        private stSdoParametersControls[] sdoParametersControls;        //Parameter setting controls.
        private stSdoWriteResultControls[] sdoWriteResultControls;      //Write result controls.
        private stSdoReadResultControls[] sdoReadResultControls;        //Read result controls.

        private delegate void WriteUpdateControl();        //Delegate definition for write controls update.
        private delegate void ReadUpdateControl();         //Delegate definition for read controls update
        private WriteUpdateControl DelegateWriteUpdate;    //Write controls update.
        private ReadUpdateControl DelegateReadUpdate;      //Read controls update

        private stSdoResultValue[] sdoWriteResultValue = new stSdoResultValue[MaxSdoNo];    //Write result value.(0-3)
        private stSdoResultValue[] sdoReadResultValue = new stSdoResultValue[MaxSdoNo];     //Rrite result value.(0-3)
        private int sdoWriteExecCnt = 0;    //Number of write executions.
        private int sdoReadExecCnt = 0;     //Number of read executions.

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public FormSdoBatchReadWrite()
        {
            InitializeComponent();

            //----------------------------------------------------------------
            //Delegate Function
            DelegateWriteUpdate = new WriteUpdateControl(MethodUpdateBatchWriteControl);
            DelegateReadUpdate = new ReadUpdateControl(MethodUpdateBatchReadControl);

            //----------------------------------------------------------------
            //CallBack Functions
            ccLinkSdoUploadCallBackFunc[0] = new CCLinkSdoUploadCallBackFunc(MethodSdoUploadCallBack1);
            ccLinkSdoUploadCallBackFunc[1] = new CCLinkSdoUploadCallBackFunc(MethodSdoUploadCallBack2);
            ccLinkSdoUploadCallBackFunc[2] = new CCLinkSdoUploadCallBackFunc(MethodSdoUploadCallBack3);
            ccLinkSdoUploadCallBackFunc[3] = new CCLinkSdoUploadCallBackFunc(MethodSdoUploadCallBack4);
            ccLinkSdoDownloadCallBackFunc[0] = new CCLinkSdoDownloadCallBackFunc(MethodSdoDownloadCallBack1);
            ccLinkSdoDownloadCallBackFunc[1] = new CCLinkSdoDownloadCallBackFunc(MethodSdoDownloadCallBack2);
            ccLinkSdoDownloadCallBackFunc[2] = new CCLinkSdoDownloadCallBackFunc(MethodSdoDownloadCallBack3);
            ccLinkSdoDownloadCallBackFunc[3] = new CCLinkSdoDownloadCallBackFunc(MethodSdoDownloadCallBack4);

            sdoParametersControls = new stSdoParametersControls[] {
                new stSdoParametersControls(checkBox1, textSlaveID1, textDropNo1, textIndex1, textSubIndex1 ),
                new stSdoParametersControls(checkBox2, textSlaveID2, textDropNo2, textIndex2, textSubIndex2 ),
                new stSdoParametersControls(checkBox3, textSlaveID3, textDropNo3, textIndex3, textSubIndex3 ),
                new stSdoParametersControls(checkBox4, textSlaveID4, textDropNo4, textIndex4, textSubIndex4 )
            };
            sdoReadResultControls = new stSdoReadResultControls[] {
                new stSdoReadResultControls(labelReadData1, labelReadLength1, labelReadStatus1),
                new stSdoReadResultControls(labelReadData2, labelReadLength2, labelReadStatus2),
                new stSdoReadResultControls(labelReadData3, labelReadLength3, labelReadStatus3),
                new stSdoReadResultControls(labelReadData4, labelReadLength4, labelReadStatus4)
            };
            sdoWriteResultControls = new stSdoWriteResultControls[] {
                new stSdoWriteResultControls(textWriteData1, comboWriteLength1, labelWriteStatus1),
                new stSdoWriteResultControls(textWriteData2, comboWriteLength2, labelWriteStatus2),
                new stSdoWriteResultControls(textWriteData3, comboWriteLength3, labelWriteStatus3),
                new stSdoWriteResultControls(textWriteData4, comboWriteLength4, labelWriteStatus4),
            };
        }

        //----------------------------------------------------------------
        // Function : Occurs before a form is displayed for the first time.
        //            Create device and Initial controls.
        //----------------------------------------------------------------
        private void FormSdoBatchReadWrite_Load(object sender, EventArgs e)
        {
            bool bNormal = false;
            formCount++;
            if (formCount <= SampleConstants.FormShowMax)
            {   //formCount : 1 - 5
                if (CreateSSCApiObject())
                {
                    if (sscApiSdoCtrl.CreateDevice())
                    {
                        //-------------------------------------------------
                        //Initial controls.
                        for (int i = 0; i < sdoParametersControls.Length; i++)
                        {
                            sdoParametersControls[i].checkBox.Checked = true;
                            sdoParametersControls[i].textSlaveId.Text = String.Format("{0:D}", (formCount - 1) * 4 + i);
                            sdoParametersControls[i].textSlaveId.MaxLength = SampleConstants.MaxSlaveIdLength;
                            sdoParametersControls[i].textDropNo.MaxLength = SampleConstants.MaxDropNoLength;
                            sdoParametersControls[i].textIndex.MaxLength = SampleConstants.MaxIndexLength;
                            sdoParametersControls[i].textSubIndex.MaxLength = SampleConstants.MaxSubIndexLength;
                        }
                        for (int i = 0; i < sdoWriteResultControls.Length; i++)
                        {
                            sdoWriteResultControls[i].textData.MaxLength = SampleConstants.MaxSdoDataLength;
                            sdoWriteResultControls[i].comboLen.Text = "1";
                        }
                        //-------------------------------------------------
                        //Updata controls.
                        MethodUpdateBatchReadControl();
                        MethodUpdateBatchWriteControl();
                        bNormal = true;
                    }
                }
            }
            if(!bNormal)
            {
                Close();    //Form close.
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Batch Read button control is clicked.
        //----------------------------------------------------------------
        private void buttonBatchRead_Click(object sender, EventArgs e)
        {
            buttonBatchRead.Enabled = false;
            buttonBatchWrite.Enabled = false;

            stSdoParameters sdoParam;
            sdoReadExecCnt = 0;
            for (int i = 0; i < sdoReadResultControls.Length; i++)
            {
                string status = "";
                if (sdoParametersControls[i].checkBox.Checked)
                {
                    if (
                        int.TryParse(sdoParametersControls[i].textSlaveId.Text, out sdoParam.slaveId) &&
                        int.TryParse(sdoParametersControls[i].textDropNo.Text, out sdoParam.dropNo) &&
                        int.TryParse(sdoParametersControls[i].textIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.index) &&
                        int.TryParse(sdoParametersControls[i].textSubIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.subIndex)
                    )
                    {
                        status = GetExecuteStatusString(ExecuteStatus.Running);
                        if (sscApiSdoCtrl.SdoUpload(sdoParam, ccLinkSdoUploadCallBackFunc[i]))
                        {
                            sdoReadExecCnt++;
                        }
                        else
                        {   //error
                            status = "API error.";
                        }
                    }
                    else
                    {
                        status = GetExecuteStatusString(ExecuteStatus.InputError);  //Input error.
                    }
                }
                else
                {
                    sdoReadResultValue[i].data = "";
                    sdoReadResultValue[i].len = 0;
                }
                sdoReadResultValue[i].result = ErrorCode.None;
                sdoReadResultValue[i].errCode = 0;
                sdoReadResultValue[i].status = status;
            }
            MethodUpdateBatchReadControl(); //Update control.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Batch Write button control is clicked.
        //----------------------------------------------------------------
        private void buttonBatchWrite_Click(object sender, EventArgs e)
        {
            buttonBatchRead.Enabled = false;
            buttonBatchWrite.Enabled = false;

            sdoWriteExecCnt = 0;
            for (int i = 0; i < sdoWriteResultControls.Length; i++)
            {
                stSdoParameters sdoParam;
                string status = "";
                if (sdoParametersControls[i].checkBox.Checked)
                {
                    if (
                        int.TryParse(sdoParametersControls[i].textSlaveId.Text, out sdoParam.slaveId) &&
                        int.TryParse(sdoParametersControls[i].textDropNo.Text, out sdoParam.dropNo) &&
                        int.TryParse(sdoParametersControls[i].textIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.index) &&
                        int.TryParse(sdoParametersControls[i].textSubIndex.Text, System.Globalization.NumberStyles.HexNumber, null, out sdoParam.subIndex)
                    )
                    {
                        byte[] sdoData;
                        if (SampleComFunc.stringToByteData(sdoWriteResultControls[i].textData.Text, int.Parse(sdoWriteResultControls[i].comboLen.Text), out sdoData))   //string -> byte[]
                        {
                            status = GetExecuteStatusString(ExecuteStatus.Running);
                            if (sscApiSdoCtrl.SdoDownload(sdoParam, sdoData, ccLinkSdoDownloadCallBackFunc[i]))
                            {
                                sdoWriteExecCnt++;
                            }
                            else
                            {   //error
                                status = "API error.";
                            }
                        }
                    }
                    else
                    {
                        status = GetExecuteStatusString(ExecuteStatus.InputError);  //Input Error.
                    }
                }
                else
                {
                    sdoWriteResultValue[i].data = "";
                    sdoWriteResultValue[i].len = 0;
                }
                sdoWriteResultValue[i].result = ErrorCode.None;
                sdoWriteResultValue[i].errCode = 0;
                sdoWriteResultValue[i].status = status;
            }
            MethodUpdateBatchWriteControl(); //Update control.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the Close button control is clicked.
        //----------------------------------------------------------------
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();    //Form close.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when the value of the Checked property changes.
        //             Enables / disables the controls in the group.
        //----------------------------------------------------------------
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control item in ((GroupBox)((CheckBox)sender).Parent).Controls)
            {
                if (item is TextBox)
                {
                    item.Enabled = ((CheckBox)sender).Checked;
                }
            }
        }

        //----------------------------------------------------------------
        // Functions : Occurs when a character. key is pressed while 
        //             the textHex control has focus.
        //----------------------------------------------------------------
        private void textHex_KeyPress(object sender, KeyPressEventArgs e)
        {
            SampleComFunc.CheckKeyPressNumHex(e);     //Input key check.
        }

        //----------------------------------------------------------------
        // Functions : Occurs when a character. key is pressed while 
        //             the textNum control has focus.
        //----------------------------------------------------------------
        private void textNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            SampleComFunc.CheckKeyPressNum(e);     //Input key check.
        }

        //----------------------------------------------------------------
        // Functions : Occurs after the form is closed.
        //             Wait for the callback function to finish
        //             and close the device.
        //----------------------------------------------------------------
        private void FormSdoBatchReadWrite_FormClosed(object sender, FormClosedEventArgs e)
        {
            while (sdoReadExecCnt != 0 || sdoWriteExecCnt != 0)
            {   //Waiting for callback to complete.
                Thread.Sleep(1);
            }
            formCount--;
            sscApiSdoCtrl?.DeviceClose();
        }

        //----------------------------------------------------------------
        // Functions : SOD upload callback function. (No.1)
        //----------------------------------------------------------------
        public int MethodSdoUploadCallBack1(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetReadOutputValue(0, result, errCode, data, len);
            sdoReadExecCnt--;
            Invoke(DelegateReadUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : SOD upload callback function. (No.2)
        //----------------------------------------------------------------
        public int MethodSdoUploadCallBack2(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetReadOutputValue(1, result, errCode, data, len);
            sdoReadExecCnt--;
            Invoke(DelegateReadUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : SOD upload callback function. (No.3)
        //----------------------------------------------------------------
        public int MethodSdoUploadCallBack3(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetReadOutputValue(2, result, errCode, data, len);
            sdoReadExecCnt--;
            Invoke(DelegateReadUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : SOD upload callback function. (No.4)
        //----------------------------------------------------------------
        public int MethodSdoUploadCallBack4(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetReadOutputValue(3, result, errCode, data, len);
            sdoReadExecCnt--;
            Invoke(DelegateReadUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : SOD downoad callback function. (No.1)
        //----------------------------------------------------------------
        public int MethodSdoDownloadCallBack1(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetWriteOutputValue(0, result, errCode);
            sdoWriteExecCnt--;
            Invoke(DelegateWriteUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : SOD downoad callback function. (No.2)
        //----------------------------------------------------------------
        public int MethodSdoDownloadCallBack2(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetWriteOutputValue(1, result, errCode);
            sdoWriteExecCnt--;
            Invoke(DelegateWriteUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : SOD downoad callback function. (No.3)
        //----------------------------------------------------------------
        public int MethodSdoDownloadCallBack3(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetWriteOutputValue(2, result, errCode);
            sdoWriteExecCnt--;
            Invoke(DelegateWriteUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : SOD downoad callback function. (No.4)
        //----------------------------------------------------------------
        public int MethodSdoDownloadCallBack4(int result, int slaveId, int dropNo, int index, int subindex, CCLinkSdoType sdoType, int len, byte[] data, uint errCode)
        {
            SetWriteOutputValue(3, result, errCode);
            sdoWriteExecCnt--;
            Invoke(DelegateWriteUpdate);
            return 1;
        }

        //----------------------------------------------------------------
        // Functions : Set read output data.
        //----------------------------------------------------------------
        private void SetReadOutputValue(int no, int result, uint errCode, byte[] data, int len)
        {
            string sResultData = "-";
            if (no < sdoReadResultValue.Length)
            {
                sdoReadResultValue[no].len = len;
                if (ErrorCode.None == result)
                {
                    if (0 == errCode)
                    {
                        SampleComFunc.byteDataToString(data, (uint)len, out sResultData);
                    }
                }
                sdoReadResultValue[no].result = result;
                sdoReadResultValue[no].errCode = errCode;
                sdoReadResultValue[no].data = sResultData;
                sdoReadResultValue[no].status = GetExecuteStatusString(ExecuteStatus.Completed, result, errCode);
            }
        }
        //----------------------------------------------------------------
        // Functions : Set write output data.
        //----------------------------------------------------------------
        private void SetWriteOutputValue(int no, int result, uint errCode)
        {
            if (no < sdoWriteResultValue.Length)
            {
                sdoWriteResultValue[no].result = result;
                sdoWriteResultValue[no].errCode = errCode;
                sdoWriteResultValue[no].status = GetExecuteStatusString(ExecuteStatus.Completed, result, errCode);
            }
        }

        //----------------------------------------------------------------
        // Functions : Set the read execute status string.
        //----------------------------------------------------------------
        private string GetExecuteStatusString(ExecuteStatus status, int result = 0, uint errCode = 0)
        {
            string dispStatus = "";
            switch (status)
            {
                case ExecuteStatus.Idle:
                    dispStatus = "-";
                    break;
                case ExecuteStatus.Running:
                    dispStatus = "Running";
                    break;
                case ExecuteStatus.Completed:
                    if (ErrorCode.None == result)
                    {
                        if (0 == errCode)
                        {
                            dispStatus = "Normal complete";
                        }
                        else
                        {
                            dispStatus = String.Format(StatusSdoErrorFormat, errCode);  //SDO error.
                        }
                    }
                    else
                    {
                        dispStatus = String.Format(StatusApiErrorFormat, result);       //API error.
                    }
                    break;
                case ExecuteStatus.InputError:
                    dispStatus = "Input error.";
                    break;
                default:
                    dispStatus = "";
                    break;
            }
            return dispStatus;
        }

        //----------------------------------------------------------------
        // Functions : Update batch read control.
        //----------------------------------------------------------------
        public void MethodUpdateBatchReadControl()
        {
            for (int i = 0; i < sdoReadResultValue.Length; i++)
            {
                sdoReadResultControls[i].labelData.Text = sdoReadResultValue[i].data;
                sdoReadResultControls[i].labelLen.Text = sdoReadResultValue[i].len.ToString();
                sdoReadResultControls[i].labelStatus.Text = sdoReadResultValue[i].status;
                int result = sdoReadResultValue[i].result;
                if (ErrorCode.None != result)
                {
                    sdoReadResultValue[i].result = ErrorCode.None;
                    MessageBox.Show(
                        String.Format(SampleConstants.sSodErrMsgFormat, (i + 1).ToString(), result, CCLink.ErrorToString(result)),
                        String.Format(SampleConstants.sErrMsgTitle, "SdoUpload()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            if ((sdoReadExecCnt == 0) && (sdoWriteExecCnt == 0))
            {
                buttonBatchRead.Enabled = true;
                buttonBatchWrite.Enabled = true;
            }
        }

        //----------------------------------------------------------------
        // Functions : Update batch write control.
        //----------------------------------------------------------------
        public void MethodUpdateBatchWriteControl()
        {
            for (int i = 0; i < sdoWriteResultValue.Length; i++)
            {
                sdoWriteResultControls[i].labelStatus.Text = sdoWriteResultValue[i].status;
                int result = sdoWriteResultValue[i].result;
                if (ErrorCode.None != result)
                {
                    sdoWriteResultValue[i].result = ErrorCode.None;
                    MessageBox.Show(
                        String.Format(SampleConstants.sSodErrMsgFormat, (i + 1).ToString(), result, CCLink.ErrorToString(result)),
                        String.Format(SampleConstants.sErrMsgTitle, "SdoDpwnload()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            if ((sdoReadExecCnt == 0) && (sdoWriteExecCnt == 0))
            {
                buttonBatchRead.Enabled = true;
                buttonBatchWrite.Enabled = true;
            }
        }

        //----------------------------------------------------------------
        // Functions : Create object
        //----------------------------------------------------------------
        private bool CreateSSCApiObject()
        {
            sscApiSdoCtrl = new SSCApiSdoControl();
            return (sscApiSdoCtrl != null);
        }
    }
}

