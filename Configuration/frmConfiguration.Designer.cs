namespace Configuration
{
    partial class frmConfiguration
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguration));
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerTempDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLocalSaveDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnSetServer = new System.Windows.Forms.Button();
            this.btnSetClient = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCleanServerTemp = new System.Windows.Forms.Button();
            this.btnRestartServer = new System.Windows.Forms.Button();
            this.btnShowServerWindow = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "服务器IP及端口";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIP.Location = new System.Drawing.Point(136, 15);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(131, 21);
            this.txtServerIP.TabIndex = 8;
            this.txtServerIP.Text = "localhost:9876";
            // 
            // txtServerTempDir
            // 
            this.txtServerTempDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerTempDir.Location = new System.Drawing.Point(136, 48);
            this.txtServerTempDir.Name = "txtServerTempDir";
            this.txtServerTempDir.Size = new System.Drawing.Size(131, 21);
            this.txtServerTempDir.TabIndex = 8;
            this.txtServerTempDir.Text = "C:\\temp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "服务器临时文件夹";
            // 
            // txtLocalSaveDir
            // 
            this.txtLocalSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalSaveDir.Location = new System.Drawing.Point(136, 84);
            this.txtLocalSaveDir.Name = "txtLocalSaveDir";
            this.txtLocalSaveDir.Size = new System.Drawing.Size(131, 21);
            this.txtLocalSaveDir.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "客户端保存文件夹";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUninstall);
            this.groupBox1.Controls.Add(this.btnSetServer);
            this.groupBox1.Controls.Add(this.btnSetClient);
            this.groupBox1.Location = new System.Drawing.Point(19, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 144);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "安装选项";
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(7, 106);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(134, 23);
            this.btnUninstall.TabIndex = 16;
            this.btnUninstall.Text = "一键卸载";
            this.btnUninstall.UseVisualStyleBackColor = true;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnSetServer
            // 
            this.btnSetServer.Location = new System.Drawing.Point(7, 64);
            this.btnSetServer.Name = "btnSetServer";
            this.btnSetServer.Size = new System.Drawing.Size(134, 23);
            this.btnSetServer.TabIndex = 13;
            this.btnSetServer.Text = "设置服务端电脑";
            this.btnSetServer.UseVisualStyleBackColor = true;
            this.btnSetServer.Click += new System.EventHandler(this.btnSetServer_Click);
            // 
            // btnSetClient
            // 
            this.btnSetClient.Location = new System.Drawing.Point(7, 22);
            this.btnSetClient.Name = "btnSetClient";
            this.btnSetClient.Size = new System.Drawing.Size(134, 23);
            this.btnSetClient.TabIndex = 12;
            this.btnSetClient.Text = "设置客户端电脑";
            this.btnSetClient.UseVisualStyleBackColor = true;
            this.btnSetClient.Click += new System.EventHandler(this.btnSetClient_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(282, 15);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(44, 90);
            this.btnSaveConfig.TabIndex = 15;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCleanServerTemp);
            this.groupBox2.Controls.Add(this.btnRestartServer);
            this.groupBox2.Controls.Add(this.btnShowServerWindow);
            this.groupBox2.Location = new System.Drawing.Point(178, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 144);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器管理";
            // 
            // btnCleanServerTemp
            // 
            this.btnCleanServerTemp.Location = new System.Drawing.Point(9, 106);
            this.btnCleanServerTemp.Name = "btnCleanServerTemp";
            this.btnCleanServerTemp.Size = new System.Drawing.Size(128, 23);
            this.btnCleanServerTemp.TabIndex = 14;
            this.btnCleanServerTemp.Text = "清理临时文件夹";
            this.btnCleanServerTemp.UseVisualStyleBackColor = true;
            this.btnCleanServerTemp.Click += new System.EventHandler(this.btnCleanServerTemp_Click);
            // 
            // btnRestartServer
            // 
            this.btnRestartServer.Location = new System.Drawing.Point(11, 64);
            this.btnRestartServer.Name = "btnRestartServer";
            this.btnRestartServer.Size = new System.Drawing.Size(128, 23);
            this.btnRestartServer.TabIndex = 13;
            this.btnRestartServer.Text = "重启服务";
            this.btnRestartServer.UseVisualStyleBackColor = true;
            this.btnRestartServer.Click += new System.EventHandler(this.btnRestartServer_Click);
            // 
            // btnShowServerWindow
            // 
            this.btnShowServerWindow.Location = new System.Drawing.Point(11, 22);
            this.btnShowServerWindow.Name = "btnShowServerWindow";
            this.btnShowServerWindow.Size = new System.Drawing.Size(128, 23);
            this.btnShowServerWindow.TabIndex = 12;
            this.btnShowServerWindow.Text = "显示/隐藏服务窗口";
            this.btnShowServerWindow.UseVisualStyleBackColor = true;
            this.btnShowServerWindow.Click += new System.EventHandler(this.btnShowServerWindow_Click);
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 292);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocalSaveDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServerTempDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理控制台";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtServerTempDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalSaveDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnSetServer;
        private System.Windows.Forms.Button btnSetClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCleanServerTemp;
        private System.Windows.Forms.Button btnRestartServer;
        private System.Windows.Forms.Button btnShowServerWindow;
        private System.Windows.Forms.Button btnUninstall;

    }
}

