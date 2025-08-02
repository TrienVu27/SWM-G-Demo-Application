/*****************************************************************************/
/* FILE        : SSCApiBase.cs                                               */
/* DESCRIPTION : SSCApi Base class                                           */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SSCApiCLR;
using SSCApiCLR.CCLinkApiCLR;
using System.Reflection;
using System.Windows.Forms;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    public class SSCApiBase
    {
        //----------------------------------------------------------------
        // Constant
        //----------------------------------------------------------------
        private const int DeviceCreateTimeout = 30000;          //Create device Timeout [ms]
        private const int StartCommTimeout = 30000;             //StartComm.Timeout [ms]

        //----------------------------------------------------------------
        // Member
        //----------------------------------------------------------------

        //----------------------------------------------------------------
        // Functions : constructor
        //----------------------------------------------------------------
        public SSCApiBase()
        {
        }

        //----------------------------------------------------------------
        // Functions : Create a device to interface with the SWM-G engine.
        //----------------------------------------------------------------
        public bool CreateDevice(ref SSCApi sscApi, string sDeviceName)
        {
            int nError = ErrorCode.None;
            nError = sscApi.CreateDevice(
                SampleConstants.sSWM_G_Path,
                DeviceType.DeviceTypeNormal,
                DeviceCreateTimeout
            );
            if (ErrorCode.None != nError)
            {
                MessageBox.Show(
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "CreateDevice()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else
            {
                // Set Device Name.
                nError = sscApi.SetDeviceName(sDeviceName);
                if (ErrorCode.None != nError)
                {
                    MessageBox.Show(
                        String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                        String.Format(SampleConstants.sErrMsgTitle, "SetDeviceName()"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    // Start Communication.
                    nError = sscApi.StartCommunication(StartCommTimeout);
                    if (ErrorCode.None != nError)
                    {
                        MessageBox.Show(
                            String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                            String.Format(SampleConstants.sErrMsgTitle, "StartCommunication()"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Close a device.
        //----------------------------------------------------------------
        public bool DeviceClose(ref SSCApi sscApi)
        {
            int nError = ErrorCode.None;
            //Quit device.
            nError = sscApi.CloseDevice();
            if(ErrorCode.None != nError)
            {
                MessageBox.Show(
                    String.Format(SampleConstants.sErrMsgFormat, nError, CoreMotion.ErrorToString(nError)),
                    String.Format(SampleConstants.sErrMsgTitle, "CloseDevice()"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return (ErrorCode.None == nError);
        }

        //----------------------------------------------------------------
        // Functions : Generates a string of Engine state.
        //----------------------------------------------------------------
        public static string ENG_STATE(SSCApiCLR.EngineState state)
        {
            switch (state)
            {
                case SSCApiCLR.EngineState.Idle:
                    return "Stopped";
                case SSCApiCLR.EngineState.Running:
                    return "Running";
                case SSCApiCLR.EngineState.Communicating:
                    return "Communicating";
                case SSCApiCLR.EngineState.Shutdown:
                    return "Shutdown";
                default:
                    return "Unknown";
            }
        }

        //----------------------------------------------------------------
        // Functions : Generates a string of Operation state.
        //----------------------------------------------------------------
        public static string OP_STATE(SSCApiCLR.OperationState state)
        {
            switch (state)
            {
                case SSCApiCLR.OperationState.Idle:
                    return "Idle";
                case SSCApiCLR.OperationState.Pos:
                    return "Pos";
                case SSCApiCLR.OperationState.Jog:
                    return "Jog";
                case SSCApiCLR.OperationState.Home:
                    return "Home";
                case SSCApiCLR.OperationState.Sync:
                    return "Sync";
                case SSCApiCLR.OperationState.GantryHome:
                    return "GantryHome";
                case SSCApiCLR.OperationState.Stop:
                    return "Stop";
                case SSCApiCLR.OperationState.Intpl:
                    return "Intpl";
                case SSCApiCLR.OperationState.Velocity:
                    return "Velocity";
                case SSCApiCLR.OperationState.ConstLinearVelocity:
                    return "ConstLinearVelocity";
                case SSCApiCLR.OperationState.Trq:
                    return "Trq";
                case SSCApiCLR.OperationState.DirectControl:
                    return "DirectControl";
                case SSCApiCLR.OperationState.PVT:
                    return "PVT";
                case SSCApiCLR.OperationState.ECAM:
                    return "ECAM";
                case SSCApiCLR.OperationState.SyncCatchUp:
                    return "SyncCatchUp";
                case SSCApiCLR.OperationState.DancerControl:
                    return "DancerControl";
                default:
                    return "";
            }
        }
    }
}
