using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Configuration
{
    static class ConfigurationProgram
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", @"Config.config");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConfiguration());
        }
    }
}
