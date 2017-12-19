using System;
using System.Diagnostics;
using System.Drawing;
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
    public class Win32Helper
    {
        
        public const int WmCopydata = 0x004A;
        
        [DllImport("User32.dll")]
        public static extern int SendMessage(int hwnd, int msg, int wParam, ref CopydataStruct param);
        
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(int hWnd, uint nCmdShow);
        
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        
        [DllImport("user32.dll", EntryPoint = "IsWindowVisible", SetLastError = true)]
        public static extern bool IsWindowVisible(int hWnd);
        
        public static bool IsProcessExistByFileName(string fileName)
        {
            var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(fileName));
            if (processes.Any(process => process.MainModule.FileName.Trim().ToLower() == fileName.Trim().ToLower()))
            {
                return true;
            }
            return false;
        }
        public static bool StartExe(string fileName)
        {
            try
            {
                var pro = new Process
                {
                    StartInfo =
                    {
                        FileName = fileName,
                        WindowStyle = ProcessWindowStyle.Normal
                    }
                };
                pro.Start();
                //pro.WaitForInputIdle();
                //Thread.Sleep(2000);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}启动失败！\n错误消息\n{1}", fileName, ex);
                return false;
            }
        }

        public static bool KillProcessByExeName(string fileName)
        {
            var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(fileName));
            try
            {
                foreach (var process in processes)
                {
                    if (string.Equals(process.MainModule.FileName.Trim(), fileName.Trim(),
                        StringComparison.CurrentCultureIgnoreCase))
                    {
                        process.Kill();
                    }
                }
                return true;
            }
            catch (Exception)
            {
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

        public static void HideWindow(string windowClass, string windowTittle)
        {
            int hWnd = FindWindow(windowClass, windowTittle);
            if (hWnd != 0)
            {
                ShowWindow(hWnd, 0);//隐藏这个窗口
            }
        }

        public static void ShowWindow(string windowClass, string windowTittle)
        {
            int hWnd = FindWindow(windowClass, windowTittle);
            if (hWnd != 0)
            {
                ShowWindow(hWnd, 1);//显示这个窗口或者5
            }
        }

        public static bool IsWindowHidden(string windowClass, string windowTittle)
        {
            int hWnd = FindWindow(windowClass, windowTittle);
            if (hWnd != 0)
            {
                return !IsWindowVisible(hWnd);
            }
            return false;
        }
    }
}
