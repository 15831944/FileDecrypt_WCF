using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UtilityLib;

namespace Configuration
{
    public partial class frmConfiguration : Form
    {
        private List<string> _lnkList;
        public frmConfiguration()
        {
            InitializeComponent();

            toolTip1.SetToolTip(txtServerIP, "服务器IP和端口。示例:localhost:1234 或 192.168.1.100:7654。");
            toolTip1.SetToolTip(txtServerTempDir, "服务器存储临时文件的目录。");
            toolTip1.SetToolTip(txtLocalSaveDir, "本地存储处理后的文件的目录，为空则保存到源文件所在目录。");

            InitialTxtBox();
            _lnkList = new List<string>
            {
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SendTo), "上传至服务器.lnk"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "TransferServiceHost.lnk"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "DecryptServiceHost.lnk")
            };
        }

        private void InitialTxtBox()
        {
            txtServerIP.Text = ConfigHelper.GetConfig("ServerIP");
            txtLocalSaveDir.Text = ConfigHelper.GetConfig("LocalSaveDir");
            txtServerTempDir.Text = ConfigHelper.GetConfig("ServerTempDir");
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (!ConfigHelper.SetConfig("ServerIP", txtServerIP.Text) ||
                !ConfigHelper.SetConfig("LocalSaveDir", txtLocalSaveDir.Text) ||
                !ConfigHelper.SetConfig("ServerTempDir", txtServerTempDir.Text))
            {
                MessageBox.Show(@"保存失败！");
            }
            else
            {
                MessageBox.Show(@"保存成功！");
            }
        }

        private void btnSetClient_Click(object sender, EventArgs e)
        {
            var file = Path.Combine(Environment.CurrentDirectory, "UploadClient.exe");
            var shortcut = _lnkList[0];

            MessageBox.Show(ShortcutHelper.CreateShortcut(shortcut, file, "", Path.GetDirectoryName(file), "")
                ? @"客户端设置成功！"
                : @"客户端设置失败！");
        }

        private void btnSetServer_Click(object sender, EventArgs e)
        {
            var tempDir = new DirectoryInfo(ConfigHelper.GetConfig("ServerTempDir"));
            if (!tempDir.Exists)
            {
                tempDir.Create();
            }

            var file1 = Path.Combine(Environment.CurrentDirectory, "TransferServiceHost.exe");
            var shotcut1 = _lnkList[1];


            var file2 = Path.Combine(Environment.CurrentDirectory, "DecryptServiceHost.exe");
            var newFile = Path.Combine(Environment.CurrentDirectory, ConfigHelper.GetConfig("CheaterApp"));

            if (!File.Exists(newFile) || !IsValidFileContent(file2, newFile))
            {
                Win32Helper.KillProcessByExeName(newFile);
                Thread.Sleep(200);
                using (var newSteam = new FileStream(newFile, FileMode.Create))
                {
                    using (var stream = new FileStream(file2, FileMode.Open))
                    {
                        stream.CopyTo(newSteam);
                    }
                }
                //Win32Helper.StartExe(newFile);
            }
            var shotcut2 = _lnkList[2];

            if (ShortcutHelper.CreateShortcut(shotcut1, file1, "", Path.GetDirectoryName(file1), "") &&
                ShortcutHelper.CreateShortcut(shotcut2, newFile, "", Path.GetDirectoryName(newFile), ""))
            {
                RestartService();
                MessageBox.Show(@"服务器端设置成功！");
            }
            else
                MessageBox.Show(@"服务器端设置失败！");
        }

        private void btnCleanServerTemp_Click(object sender, EventArgs e)
        {
            var tempDir = new DirectoryInfo(ConfigHelper.GetConfig("ServerTempDir"));
            int errorCount = 0;
            int okCount = 0;
            foreach (var fileInfo in tempDir.GetFiles())
            {
                try
                {
                    fileInfo.Delete();
                    okCount++;
                }
                catch (Exception)
                {
                    errorCount++;
                }
            }
            if (errorCount == 0)
            {
                MessageBox.Show(string.Format("{0} 内:\n\t{1}个文件删除成功！", tempDir, okCount));
            }
            else
            {
                MessageBox.Show(string.Format("{0} 内:\n\t{1}个文件删除成功！\n\t{2}个文件删除失败，请手动删除！", tempDir, okCount, errorCount));
            }
        }

        private void btnShowServerWindow_Click(object sender, EventArgs e)
        {
            var tranferWndTittle = ConfigHelper.GetConfig("TranferServiceTittle");
            var decryptWndTittle = ConfigHelper.GetConfig("DecryptServiceTittle");
            if (Win32Helper.IsWindowHidden("ConsoleWindowClass", tranferWndTittle))
            {
                Win32Helper.ShowWindow("ConsoleWindowClass", tranferWndTittle);
            }
            else
            {
                Win32Helper.HideWindow("ConsoleWindowClass", tranferWndTittle);
            }

            if (Win32Helper.IsWindowHidden("ConsoleWindowClass", decryptWndTittle))
            {
                Win32Helper.ShowWindow("ConsoleWindowClass", decryptWndTittle);
            }
            else
            {
                Win32Helper.HideWindow("ConsoleWindowClass", decryptWndTittle);
            }
        }

        private void btnRestartServer_Click(object sender, EventArgs e)
        {
            RestartService();
            //MessageBox.Show(@"重启服务成功!");
        }

        private void RestartService()
        {
            var file1 = Path.Combine(Environment.CurrentDirectory, "TransferServiceHost.exe");
            var file2 = Path.Combine(Environment.CurrentDirectory, ConfigHelper.GetConfig("CheaterApp"));
            Win32Helper.KillProcessByExeName(file1);
            Win32Helper.KillProcessByExeName(file2);
            Win32Helper.StartExe(file1);
            Win32Helper.StartExe(file2);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            var file1 = Path.Combine(Environment.CurrentDirectory, "TransferServiceHost.exe");
            var file2 = Path.Combine(Environment.CurrentDirectory, ConfigHelper.GetConfig("CheaterApp"));
            Win32Helper.KillProcessByExeName(file1);
            Win32Helper.KillProcessByExeName(file2);

            


            string error = "";
            foreach (var shortcut in _lnkList)
            {
                try
                {
                    File.Delete(shortcut);
                }
                catch (Exception)
                {
                    error += (shortcut + "\n");
                }
            }
            if (!_lnkList.Any(File.Exists))
            {
                MessageBox.Show(@"卸载完成!");
            }
            else
            {
                MessageBox.Show(@"未能删除以下文件，请手动删除：\n" + error);
            }
        }

        public static bool IsValidFileContent2(string filePath1, string filePath2)
        {
            //创建一个哈希算法对象 
            using (HashAlgorithm hash = HashAlgorithm.Create())
            {
                using (
                    FileStream file1 = new FileStream(filePath1, FileMode.Open),
                        file2 = new FileStream(filePath2, FileMode.Open))
                {
                    byte[] hashByte1 = hash.ComputeHash(file1); //哈希算法根据文本得到哈希码的字节数组 
                    byte[] hashByte2 = hash.ComputeHash(file2);
                    string str1 = BitConverter.ToString(hashByte1); //将字节数组装换为字符串 
                    string str2 = BitConverter.ToString(hashByte2);
                    return (str1 == str2); //比较哈希码 
                }
            }
        }

        public static bool IsValidFileContent(string filePath1, string filePath2)
        {
            var fi1 = new FileInfo(filePath1);
            var fi2 = new FileInfo(filePath2);
            return fi1.Length == fi2.Length;
        }
    }
}
