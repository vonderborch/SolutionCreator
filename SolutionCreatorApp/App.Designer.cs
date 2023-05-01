namespace SolutionCreatorApp
{
    partial class App
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.templateGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAccessTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAccessTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.templates_txt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_txt = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.templatesToolStripMenuItem,
            this.gitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1178, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // templatesToolStripMenuItem
            // 
            this.templatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem1,
            this.toolStripSeparator1,
            this.templateGeneratorToolStripMenuItem,
            this.generateSolutionToolStripMenuItem});
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            this.templatesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.templatesToolStripMenuItem.Text = "Templates";
            // 
            // checkForUpdatesToolStripMenuItem1
            // 
            this.checkForUpdatesToolStripMenuItem1.Name = "checkForUpdatesToolStripMenuItem1";
            this.checkForUpdatesToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.checkForUpdatesToolStripMenuItem1.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem1.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // templateGeneratorToolStripMenuItem
            // 
            this.templateGeneratorToolStripMenuItem.Name = "templateGeneratorToolStripMenuItem";
            this.templateGeneratorToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.templateGeneratorToolStripMenuItem.Text = "Template Generator";
            this.templateGeneratorToolStripMenuItem.Click += new System.EventHandler(this.templateGeneratorToolStripMenuItem_Click);
            // 
            // generateSolutionToolStripMenuItem
            // 
            this.generateSolutionToolStripMenuItem.Name = "generateSolutionToolStripMenuItem";
            this.generateSolutionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.generateSolutionToolStripMenuItem.Text = "Generate Solution";
            this.generateSolutionToolStripMenuItem.Click += new System.EventHandler(this.generateSolutionToolStripMenuItem_Click);
            // 
            // gitToolStripMenuItem
            // 
            this.gitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAccessTokenToolStripMenuItem,
            this.setPasswordToolStripMenuItem,
            this.clearAccessTokenToolStripMenuItem});
            this.gitToolStripMenuItem.Name = "gitToolStripMenuItem";
            this.gitToolStripMenuItem.Size = new System.Drawing.Size(34, 20);
            this.gitToolStripMenuItem.Text = "Git";
            // 
            // setAccessTokenToolStripMenuItem
            // 
            this.setAccessTokenToolStripMenuItem.Name = "setAccessTokenToolStripMenuItem";
            this.setAccessTokenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.setAccessTokenToolStripMenuItem.Text = "Set Username";
            this.setAccessTokenToolStripMenuItem.Click += new System.EventHandler(this.setAccessTokenToolStripMenuItem_Click);
            // 
            // setPasswordToolStripMenuItem
            // 
            this.setPasswordToolStripMenuItem.Name = "setPasswordToolStripMenuItem";
            this.setPasswordToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.setPasswordToolStripMenuItem.Text = "Set Password";
            this.setPasswordToolStripMenuItem.Click += new System.EventHandler(this.setPasswordToolStripMenuItem_Click);
            // 
            // clearAccessTokenToolStripMenuItem
            // 
            this.clearAccessTokenToolStripMenuItem.Name = "clearAccessTokenToolStripMenuItem";
            this.clearAccessTokenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.clearAccessTokenToolStripMenuItem.Text = "Clear Credentials";
            this.clearAccessTokenToolStripMenuItem.Click += new System.EventHandler(this.clearAccessTokenToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.reportIssueToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // reportIssueToolStripMenuItem
            // 
            this.reportIssueToolStripMenuItem.Name = "reportIssueToolStripMenuItem";
            this.reportIssueToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.reportIssueToolStripMenuItem.Text = "Report Issue";
            this.reportIssueToolStripMenuItem.Click += new System.EventHandler(this.reportIssueToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templates_txt,
            this.toolStripStatusLabel1,
            this.status_txt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 799);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1178, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // templates_txt
            // 
            this.templates_txt.Name = "templates_txt";
            this.templates_txt.Size = new System.Drawing.Size(118, 17);
            this.templates_txt.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // status_txt
            // 
            this.status_txt.Name = "status_txt";
            this.status_txt.Size = new System.Drawing.Size(118, 17);
            this.status_txt.Text = "toolStripStatusLabel1";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 821);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "App";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "App";
            this.Load += new System.EventHandler(this.App_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem reportIssueToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel templates_txt;
        private ToolStripStatusLabel status_txt;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem gitToolStripMenuItem;
        private ToolStripMenuItem setAccessTokenToolStripMenuItem;
        private ToolStripMenuItem clearAccessTokenToolStripMenuItem;
        private ToolStripMenuItem setPasswordToolStripMenuItem;
        private ToolStripMenuItem templatesToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem1;
        private ToolStripMenuItem templateGeneratorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem generateSolutionToolStripMenuItem;
    }
}