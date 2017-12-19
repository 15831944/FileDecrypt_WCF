using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using IWshRuntimeLibrary;

namespace UtilityLib
{
    public class ShortcutHelper
    {
        /// <summary>  
        /// 创建快捷方式。  
        /// </summary>  
        /// <param name="shortcutPath">快捷方式路径。</param>  
        /// <param name="targetPath">目标路径。</param>
        /// <param name="arguments">参数</param>
        /// <param name="workingDirectory">工作路径。</param>  
        /// <param name="description">快捷键描述。</param>
        /// <param name="iconLocation">图标文件路径</param>
        /// <param name="hotKey">热键</param>
        /// <param name="windowStyle">窗口状态</param>  
        public static bool CreateShortcut(string shortcutPath, string targetPath, 
            string arguments, string workingDirectory, string description,  string hotKey = "", int windowStyle = 1)
        {
            try
            {
                WshShell shell = new WshShell();

                IWshShortcut shortcut = (IWshShortcut) shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = targetPath;
                shortcut.Arguments = arguments; // 参数
                shortcut.WorkingDirectory = workingDirectory; //程序所在文件夹，在快捷方式图标点击右键可以看到此属性
                shortcut.Description = description;
                //shortcut.IconLocation = iconLocation; //图标
                shortcut.Hotkey = hotKey; //热键
                shortcut.WindowStyle = windowStyle;
                shortcut.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
