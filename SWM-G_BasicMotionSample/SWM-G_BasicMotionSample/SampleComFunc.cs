/*****************************************************************************/
/* FILE        : SampleComFunc.cs                                            */
/* DESCRIPTION : Common functions class                                      */
/*****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicMotionSample
{
    //----------------------------------------------------------------
    // Class
    //----------------------------------------------------------------
    class SampleComFunc
    {
        //----------------------------------------------------------------
        // Functions : Enable only integer key.
        //----------------------------------------------------------------
        public static bool CheckKeyPressNum(KeyPressEventArgs e)
        {
            if (('0' <= e.KeyChar && e.KeyChar <= '9') || (e.KeyChar == '\b'))         //'0' - '9' , BackSpace
            {
                return true;
            }
            else
            {
                e.Handled = true;   //Cancel input.
                return false;
            }
        }

        //----------------------------------------------------------------
        // Functions : Enable only hexadecimal key.
        //----------------------------------------------------------------
        public static bool CheckKeyPressNumHex(KeyPressEventArgs e)
        {
            if (('A' <= e.KeyChar && e.KeyChar <= 'F') ||           //'A' - 'F'
                ('a' <= e.KeyChar && e.KeyChar <= 'f'))              //'a' - 'f'
            {
                return true;
            }
            else
            {
                return CheckKeyPressNum(e);     //Input key check.(Integer)
            }
        }

        //----------------------------------------------------------------
        // Functions : Enable only decimal key.
        //----------------------------------------------------------------
        public static bool CheckKeyPressNumPoint(KeyPressEventArgs e, string text)
        {
            bool bRet = false;
            if ((e.KeyChar == '.' && !text.Contains(".") && text.Length != 0)  ||   //'.'
                (e.KeyChar == '-' && !text.Contains("-")))                          //'-'
            {
                return true;
            }
            else
            {
                bRet = CheckKeyPressNum(e);     //Input key check.(Integer)
            }
            return bRet;
        }

        //----------------------------------------------------------------
        // Functions : Converts a character string to byte data.
        //----------------------------------------------------------------
        public static bool stringToByteData(string sHexData,int size, out byte[] byteData)
        {
            string Fill = "";
            if (size * 2 > sHexData.Length)
            {
                Fill = new string('0', size * 2 - sHexData.Length);
            }
            string writeData = (Fill + sHexData).Substring(0, size * 2);
            byteData = new byte[size];
            bool bRet = true;
            switch (size)
            {
                case 1: //1byte
                    byteData[0] = Convert.ToByte(writeData.Substring(0, 2), 16);
                    break;
                case 2: //2byte
                    byteData[1] = Convert.ToByte(writeData.Substring(0, 2), 16);
                    byteData[0] = Convert.ToByte(writeData.Substring(2, 2), 16);
                    break;
                case 4: //4byte
                    byteData[3] = Convert.ToByte(writeData.Substring(0, 2), 16);
                    byteData[2] = Convert.ToByte(writeData.Substring(2, 2), 16);
                    byteData[1] = Convert.ToByte(writeData.Substring(4, 2), 16);
                    byteData[0] = Convert.ToByte(writeData.Substring(6, 2), 16);
                    break;
                default:    //othie
                    bRet = false;   //NG
                    break;
            }
            return bRet;
        }

        //----------------------------------------------------------------
        // Functions : Converts a  byte data to character string .
        //----------------------------------------------------------------
        public static bool byteDataToString(byte[] byteData,uint size, out string sHexData)
        {
            bool bRet = true;
            switch (size)
            {
                case 1: ///1byte
                    sHexData = String.Format("{0:X2}", byteData[0]);
                    break;
                case 2: //2byte
                    sHexData = String.Format("{0:X2}{1:X2}", byteData[1], byteData[0]);
                    break;
                case 4: //4byte
                    sHexData = String.Format("{0:X2}{1:X2}{2:X2}{3:X2}", byteData[3], byteData[2], byteData[1], byteData[0]);
                    break;
                default:
                    bRet = false;   //NG
                    sHexData = "";
                    break;
            }
            return bRet;
        }
    }
}
