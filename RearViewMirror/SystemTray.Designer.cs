namespace RearViewMirror
{
    partial class SystemTray
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemTray));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mJPEGStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDetectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopDetectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableAlarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOpacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorNone = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorBasic = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorOutline = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorBetterBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.detectorBox = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "RearViewMirror";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openVideoToolStripMenuItem,
            this.videoServerToolStripMenuItem,
            this.toolStripSeparator1,
            this.startDetectorToolStripMenuItem,
            this.stopDetectorToolStripMenuItem,
            this.toolStripSeparator2,
            this.enableAlarmToolStripMenuItem,
            this.showViewerToolStripMenuItem,
            this.setOpacityToolStripMenuItem,
            this.detectorTypeToolStripMenuItem,
            this.toolStripSeparator3,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(155, 264);
            this.trayContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.trayContextMenu_Opening);
            // 
            // openVideoToolStripMenuItem
            // 
            this.openVideoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDeviceToolStripMenuItem,
            this.mJPEGStreamToolStripMenuItem});
            this.openVideoToolStripMenuItem.Name = "openVideoToolStripMenuItem";
            this.openVideoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openVideoToolStripMenuItem.Text = "Open Video";
            // 
            // selectDeviceToolStripMenuItem
            // 
            this.selectDeviceToolStripMenuItem.Name = "selectDeviceToolStripMenuItem";
            this.selectDeviceToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.selectDeviceToolStripMenuItem.Text = "Camera Device";
            this.selectDeviceToolStripMenuItem.Click += new System.EventHandler(this.selectDeviceToolStripMenuItem_Click);
            // 
            // mJPEGStreamToolStripMenuItem
            // 
            this.mJPEGStreamToolStripMenuItem.Name = "mJPEGStreamToolStripMenuItem";
            this.mJPEGStreamToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.mJPEGStreamToolStripMenuItem.Text = "MJPEG Stream";
            this.mJPEGStreamToolStripMenuItem.Click += new System.EventHandler(this.mJPEGStreamToolStripMenuItem_Click);
            // 
            // startDetectorToolStripMenuItem
            // 
            this.startDetectorToolStripMenuItem.Name = "startDetectorToolStripMenuItem";
            this.startDetectorToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.startDetectorToolStripMenuItem.Text = "Start Detector";
            this.startDetectorToolStripMenuItem.Click += new System.EventHandler(this.startDetectorToolStripMenuItem_Click);
            // 
            // stopDetectorToolStripMenuItem
            // 
            this.stopDetectorToolStripMenuItem.Name = "stopDetectorToolStripMenuItem";
            this.stopDetectorToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.stopDetectorToolStripMenuItem.Text = "Stop Detector";
            this.stopDetectorToolStripMenuItem.Click += new System.EventHandler(this.stopDetectorToolStripMenuItem_Click);
            // 
            // videoServerToolStripMenuItem
            // 
            this.videoServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServerToolStripMenuItem,
            this.stopServerToolStripMenuItem,
            this.portToolStripMenuItem,
            this.connectionsToolStripMenuItem});
            this.videoServerToolStripMenuItem.Name = "videoServerToolStripMenuItem";
            this.videoServerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.videoServerToolStripMenuItem.Text = "Video Server";
            // 
            // startServerToolStripMenuItem
            // 
            this.startServerToolStripMenuItem.Name = "startServerToolStripMenuItem";
            this.startServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startServerToolStripMenuItem.Text = "Start Server";
            this.startServerToolStripMenuItem.Click += new System.EventHandler(this.startServerToolStripMenuItem_Click);
            // 
            // stopServerToolStripMenuItem
            // 
            this.stopServerToolStripMenuItem.Name = "stopServerToolStripMenuItem";
            this.stopServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopServerToolStripMenuItem.Text = "Stop Server";
            this.stopServerToolStripMenuItem.Click += new System.EventHandler(this.stopServerToolStripMenuItem_Click);
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.portToolStripMenuItem.Text = "Port";
            this.portToolStripMenuItem.Click += new System.EventHandler(this.portToolStripMenuItem_Click);
            // 
            // enableAlarmToolStripMenuItem
            // 
            this.enableAlarmToolStripMenuItem.Name = "enableAlarmToolStripMenuItem";
            this.enableAlarmToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.enableAlarmToolStripMenuItem.Text = "Enable Alert";
            this.enableAlarmToolStripMenuItem.Click += new System.EventHandler(this.enableAlarmToolStripMenuItem_Click);
            // 
            // showViewerToolStripMenuItem
            // 
            this.showViewerToolStripMenuItem.Name = "showViewerToolStripMenuItem";
            this.showViewerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.showViewerToolStripMenuItem.Text = "Show Viewer";
            this.showViewerToolStripMenuItem.Click += new System.EventHandler(this.showViewerToolStripMenuItem_Click);
            // 
            // setOpacityToolStripMenuItem
            // 
            this.setOpacityToolStripMenuItem.Name = "setOpacityToolStripMenuItem";
            this.setOpacityToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.setOpacityToolStripMenuItem.Text = "Set Opacity";
            this.setOpacityToolStripMenuItem.Click += new System.EventHandler(this.setOpacityToolStripMenuItem_Click);
            // 
            // detectorTypeToolStripMenuItem
            // 
            this.detectorTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detectorNone,
            this.detectorBasic,
            this.detectorOutline,
            this.detectorBlock,
            this.detectorBetterBlock,
            this.detectorBox});
            this.detectorTypeToolStripMenuItem.Name = "detectorTypeToolStripMenuItem";
            this.detectorTypeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.detectorTypeToolStripMenuItem.Text = "Detector Type";
            // 
            // detectorNone
            // 
            this.detectorNone.Name = "detectorNone";
            this.detectorNone.Size = new System.Drawing.Size(167, 22);
            this.detectorNone.Text = "None";
            this.detectorNone.Click += new System.EventHandler(this.detectorNone_Click);
            // 
            // detectorBasic
            // 
            this.detectorBasic.Name = "detectorBasic";
            this.detectorBasic.Size = new System.Drawing.Size(167, 22);
            this.detectorBasic.Text = "Baisc";
            this.detectorBasic.Click += new System.EventHandler(this.detectorBasic_Click);
            // 
            // detectorOutline
            // 
            this.detectorOutline.Name = "detectorOutline";
            this.detectorOutline.Size = new System.Drawing.Size(167, 22);
            this.detectorOutline.Text = "Outline";
            this.detectorOutline.Click += new System.EventHandler(this.detectorOutline_Click);
            // 
            // detectorBlock
            // 
            this.detectorBlock.Name = "detectorBlock";
            this.detectorBlock.Size = new System.Drawing.Size(167, 22);
            this.detectorBlock.Text = "Block";
            this.detectorBlock.Click += new System.EventHandler(this.detectorBlock_Click);
            // 
            // detectorBetterBlock
            // 
            this.detectorBetterBlock.Name = "detectorBetterBlock";
            this.detectorBetterBlock.Size = new System.Drawing.Size(167, 22);
            this.detectorBetterBlock.Text = "Block (Optimized)";
            this.detectorBetterBlock.Click += new System.EventHandler(this.detectorBetterBlock_Click);
            // 
            // detectorBox
            // 
            this.detectorBox.Name = "detectorBox";
            this.detectorBox.Size = new System.Drawing.Size(167, 22);
            this.detectorBox.Text = "Box";
            this.detectorBox.Click += new System.EventHandler(this.detectorBox_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.connectionsToolStripMenuItem.Text = "Connections";
            this.connectionsToolStripMenuItem.Click += new System.EventHandler(this.connectionsToolStripMenuItem_Click);
            // 
            // SystemTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "SystemTray";
            this.ShowInTaskbar = false;
            this.Text = "SystemTray";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem startDetectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopDetectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectorTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectorBasic;
        private System.Windows.Forms.ToolStripMenuItem detectorOutline;
        private System.Windows.Forms.ToolStripMenuItem detectorBlock;
        private System.Windows.Forms.ToolStripMenuItem detectorBetterBlock;
        private System.Windows.Forms.ToolStripMenuItem detectorBox;
        private System.Windows.Forms.ToolStripMenuItem detectorNone;
        private System.Windows.Forms.ToolStripMenuItem enableAlarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setOpacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mJPEGStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
    }
}