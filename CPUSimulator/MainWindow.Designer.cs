namespace CPUSimulator
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInSeparateWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblerEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInSeparateWindowsToolStripMenuItem,
            this.showToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizationToolStripMenuItem,
            this.memoryViewerToolStripMenuItem,
            this.assemblerEditorToolStripMenuItem,
            this.commandInfoToolStripMenuItem,
            this.loggerToolStripMenuItem,
            this.controlPanelToolStripMenuItem});
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.showToolStripMenuItem.Text = "Show...";
            // 
            // visualizationToolStripMenuItem
            // 
            this.visualizationToolStripMenuItem.Name = "visualizationToolStripMenuItem";
            this.visualizationToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.visualizationToolStripMenuItem.Text = "Visualization";
            this.visualizationToolStripMenuItem.Click += new System.EventHandler(this.visualizationToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // openInSeparateWindowsToolStripMenuItem
            // 
            this.openInSeparateWindowsToolStripMenuItem.Name = "openInSeparateWindowsToolStripMenuItem";
            this.openInSeparateWindowsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openInSeparateWindowsToolStripMenuItem.Text = "Switch MDI Layout";
            this.openInSeparateWindowsToolStripMenuItem.Click += new System.EventHandler(this.openInSeparateWindowsToolStripMenuItem_Click);
            // 
            // memoryViewerToolStripMenuItem
            // 
            this.memoryViewerToolStripMenuItem.Name = "memoryViewerToolStripMenuItem";
            this.memoryViewerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.memoryViewerToolStripMenuItem.Text = "Memory Viewer";
            this.memoryViewerToolStripMenuItem.Click += new System.EventHandler(this.memoryViewerToolStripMenuItem_Click);
            // 
            // assemblerEditorToolStripMenuItem
            // 
            this.assemblerEditorToolStripMenuItem.Name = "assemblerEditorToolStripMenuItem";
            this.assemblerEditorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.assemblerEditorToolStripMenuItem.Text = "Assembler Editor";
            this.assemblerEditorToolStripMenuItem.Click += new System.EventHandler(this.assemblerEditorToolStripMenuItem_Click);
            // 
            // commandInfoToolStripMenuItem
            // 
            this.commandInfoToolStripMenuItem.Name = "commandInfoToolStripMenuItem";
            this.commandInfoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.commandInfoToolStripMenuItem.Text = "Command Info";
            this.commandInfoToolStripMenuItem.Click += new System.EventHandler(this.commandInfoToolStripMenuItem_Click);
            // 
            // loggerToolStripMenuItem
            // 
            this.loggerToolStripMenuItem.Name = "loggerToolStripMenuItem";
            this.loggerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loggerToolStripMenuItem.Text = "Logger";
            this.loggerToolStripMenuItem.Click += new System.EventHandler(this.loggerToolStripMenuItem_Click);
            // 
            // controlPanelToolStripMenuItem
            // 
            this.controlPanelToolStripMenuItem.Name = "controlPanelToolStripMenuItem";
            this.controlPanelToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.controlPanelToolStripMenuItem.Text = "Control Panel";
            this.controlPanelToolStripMenuItem.Click += new System.EventHandler(this.controlPanelToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Assembler CPU Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInSeparateWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assemblerEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlPanelToolStripMenuItem;
    }
}