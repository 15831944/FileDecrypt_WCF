using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace UtilityLib
{
    public struct CopydataStruct
    {
        public IntPtr DwData;
        public int CData;
        [MarshalAs(UnmanagedType.LPStr)] 
        public string LpData;
    }
    public class WindowMessageHelper
    {
        
        public const int WmCopydata = 0x004A;
        
        [DllImport("User32.dll")]
        public static extern int SendMessage(int hwnd, int msg, int wParam, ref CopydataStruct param);
        [DllImport("User32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        public static bool IsProcessExistByFileName(string fileName)
        {
            var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(fileName));
            if (processes.Any(process => process.MainModule.FileName.Trim().ToLower() == fileName.Trim().ToLower()))
            {
                return true;
            }
            return false;
        }
        public static bool StartExe(string filePath)
        {
            try
            {
                var pro = new Process
                {
                    StartInfo =
                    {
                        FileName = filePath,
                        WindowStyle = ProcessWindowStyle.Normal
                    }
                };
                pro.Start();
                //pro.WaitForInputIdle();
                Thread.Sleep(2000);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}启动失败！\n错误消息\n{1}", filePath, ex);
                return false;
            }
        }

        public static bool SendMessage(string windowTittle, string str)
        {
            int windowHandle = FindWindow(null, windowTittle);
            try
            {
                if (windowHandle != 0)
                {
                    Console.WriteLine("找到符合的窗口ID:{0}", windowHandle);

                    var arr = Encoding.Default.GetBytes(str);
                    Console.WriteLine("String length: {0} \nByte Length: {1}", str.Length, arr.Length);
                    int len = arr.Length;
                    CopydataStruct cdata;
                    cdata.DwData = (IntPtr)100;
                    cdata.LpData = str;
                    cdata.CData = len + 1;
                    SendMessage(windowHandle, WmCopydata, 0, ref cdata);
                    return true;
                }
                else
                {
                    Console.WriteLine("未找到窗口");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("发送消息发生错误:{0}",e);
                return false;
            }
        }
       
    }
}
