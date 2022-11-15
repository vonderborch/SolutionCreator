namespace SolutionCreatorApp.Pages
{
    partial class TemplateGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateGenerator));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.solutionConfig_box = new System.Windows.Forms.GroupBox();
            this.directory_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browse_btn = new System.Windows.Forms.Button();
            this.templateSettings_box = new System.Windows.Forms.GroupBox();
            this.deleteWorkingDir_cxb = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.editSelected_btn = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.projectNameReplacements_txt = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.outputPath_txt = new System.Windows.Forms.TextBox();
            this.goToDirectory_btn = new System.Windows.Forms.Button();
            this.log_txt = new System.Windows.Forms.TextBox();
            this.generate_btn = new System.Windows.Forms.Button();
            this.editInstructions_btn = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.editCommands_btn = new System.Windows.Forms.Button();
            this.commandsNeedGit_cxb = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.renameFiles_txt = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.renameDirectories_txt = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cleanupDirectories_txt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.replaceText_txt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.excludedDirectories_txt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.countGuids_btn = new System.Windows.Forms.Button();
            this.guidCount_txt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nugetLicense_txt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nugetTags_txt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.askNugetInfo_cxb = new System.Windows.Forms.CheckBox();
            this.nugetDescription_txt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nameFormat_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.solutionName_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.templateDescription_txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.templateVersion_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.templateAuthor_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.templateName_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.author_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.company_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.solutionConfig_box.SuspendLayout();
            this.templateSettings_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.solutionConfig_box);
            this.flowLayoutPanel1.Controls.Add(this.templateSettings_box);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1121, 745);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // solutionConfig_box
            // 
            this.solutionConfig_box.Controls.Add(this.directory_txt);
            this.solutionConfig_box.Controls.Add(this.label1);
            this.solutionConfig_box.Controls.Add(this.browse_btn);
            this.solutionConfig_box.Location = new System.Drawing.Point(3, 3);
            this.solutionConfig_box.Name = "solutionConfig_box";
            this.solutionConfig_box.Size = new System.Drawing.Size(1106, 74);
            this.solutionConfig_box.TabIndex = 43;
            this.solutionConfig_box.TabStop = false;
            this.solutionConfig_box.Text = "Solution to Convert";
            // 
            // directory_txt
            // 
            this.directory_txt.Location = new System.Drawing.Point(162, 34);
            this.directory_txt.Name = "directory_txt";
            this.directory_txt.ReadOnly = true;
            this.directory_txt.Size = new System.Drawing.Size(381, 23);
            this.directory_txt.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Select Solution to Convert:";
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(549, 34);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 23);
            this.browse_btn.TabIndex = 20;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click_1);
            // 
            // templateSettings_box
            // 
            this.templateSettings_box.Controls.Add(this.deleteWorkingDir_cxb);
            this.templateSettings_box.Controls.Add(this.textBox1);
            this.templateSettings_box.Controls.Add(this.label23);
            this.templateSettings_box.Controls.Add(this.editSelected_btn);
            this.templateSettings_box.Controls.Add(this.label22);
            this.templateSettings_box.Controls.Add(this.projectNameReplacements_txt);
            this.templateSettings_box.Controls.Add(this.label21);
            this.templateSettings_box.Controls.Add(this.button4);
            this.templateSettings_box.Controls.Add(this.reset_btn);
            this.templateSettings_box.Controls.Add(this.outputPath_txt);
            this.templateSettings_box.Controls.Add(this.goToDirectory_btn);
            this.templateSettings_box.Controls.Add(this.log_txt);
            this.templateSettings_box.Controls.Add(this.generate_btn);
            this.templateSettings_box.Controls.Add(this.editInstructions_btn);
            this.templateSettings_box.Controls.Add(this.label19);
            this.templateSettings_box.Controls.Add(this.editCommands_btn);
            this.templateSettings_box.Controls.Add(this.commandsNeedGit_cxb);
            this.templateSettings_box.Controls.Add(this.label20);
            this.templateSettings_box.Controls.Add(this.renameFiles_txt);
            this.templateSettings_box.Controls.Add(this.label18);
            this.templateSettings_box.Controls.Add(this.renameDirectories_txt);
            this.templateSettings_box.Controls.Add(this.label17);
            this.templateSettings_box.Controls.Add(this.cleanupDirectories_txt);
            this.templateSettings_box.Controls.Add(this.label16);
            this.templateSettings_box.Controls.Add(this.replaceText_txt);
            this.templateSettings_box.Controls.Add(this.label15);
            this.templateSettings_box.Controls.Add(this.excludedDirectories_txt);
            this.templateSettings_box.Controls.Add(this.label14);
            this.templateSettings_box.Controls.Add(this.countGuids_btn);
            this.templateSettings_box.Controls.Add(this.guidCount_txt);
            this.templateSettings_box.Controls.Add(this.label13);
            this.templateSettings_box.Controls.Add(this.nugetLicense_txt);
            this.templateSettings_box.Controls.Add(this.label12);
            this.templateSettings_box.Controls.Add(this.nugetTags_txt);
            this.templateSettings_box.Controls.Add(this.label11);
            this.templateSettings_box.Controls.Add(this.askNugetInfo_cxb);
            this.templateSettings_box.Controls.Add(this.nugetDescription_txt);
            this.templateSettings_box.Controls.Add(this.label9);
            this.templateSettings_box.Controls.Add(this.nameFormat_txt);
            this.templateSettings_box.Controls.Add(this.label8);
            this.templateSettings_box.Controls.Add(this.solutionName_txt);
            this.templateSettings_box.Controls.Add(this.label7);
            this.templateSettings_box.Controls.Add(this.templateDescription_txt);
            this.templateSettings_box.Controls.Add(this.label10);
            this.templateSettings_box.Controls.Add(this.templateVersion_txt);
            this.templateSettings_box.Controls.Add(this.label4);
            this.templateSettings_box.Controls.Add(this.templateAuthor_txt);
            this.templateSettings_box.Controls.Add(this.label3);
            this.templateSettings_box.Controls.Add(this.templateName_txt);
            this.templateSettings_box.Controls.Add(this.label2);
            this.templateSettings_box.Controls.Add(this.author_txt);
            this.templateSettings_box.Controls.Add(this.label5);
            this.templateSettings_box.Controls.Add(this.company_txt);
            this.templateSettings_box.Controls.Add(this.label6);
            this.templateSettings_box.Enabled = false;
            this.templateSettings_box.Location = new System.Drawing.Point(3, 83);
            this.templateSettings_box.Name = "templateSettings_box";
            this.templateSettings_box.Size = new System.Drawing.Size(1106, 650);
            this.templateSettings_box.TabIndex = 44;
            this.templateSettings_box.TabStop = false;
            this.templateSettings_box.Text = "Template Settings";
            // 
            // deleteWorkingDir_cxb
            // 
            this.deleteWorkingDir_cxb.AutoSize = true;
            this.deleteWorkingDir_cxb.Location = new System.Drawing.Point(905, 468);
            this.deleteWorkingDir_cxb.Name = "deleteWorkingDir_cxb";
            this.deleteWorkingDir_cxb.Size = new System.Drawing.Size(195, 19);
            this.deleteWorkingDir_cxb.TabIndex = 98;
            this.deleteWorkingDir_cxb.Text = "Delete Temp Working Directory?";
            this.deleteWorkingDir_cxb.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(589, 165);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(511, 253);
            this.textBox1.TabIndex = 97;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(589, 147);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 15);
            this.label23.TabIndex = 96;
            this.label23.Text = "Special Text";
            // 
            // editSelected_btn
            // 
            this.editSelected_btn.Location = new System.Drawing.Point(1006, 69);
            this.editSelected_btn.Name = "editSelected_btn";
            this.editSelected_btn.Size = new System.Drawing.Size(94, 23);
            this.editSelected_btn.TabIndex = 95;
            this.editSelected_btn.Text = "Edit Selected";
            this.editSelected_btn.UseVisualStyleBackColor = true;
            this.editSelected_btn.Click += new System.EventHandler(this.editSelected_btn_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(587, 19);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(151, 15);
            this.label22.TabIndex = 94;
            this.label22.Text = "Project Name Replacement";
            // 
            // projectNameReplacements_txt
            // 
            this.projectNameReplacements_txt.FormattingEnabled = true;
            this.projectNameReplacements_txt.ItemHeight = 15;
            this.projectNameReplacements_txt.Location = new System.Drawing.Point(589, 37);
            this.projectNameReplacements_txt.Name = "projectNameReplacements_txt";
            this.projectNameReplacements_txt.Size = new System.Drawing.Size(411, 94);
            this.projectNameReplacements_txt.TabIndex = 93;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(589, 429);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 15);
            this.label21.TabIndex = 92;
            this.label21.Text = "Template Output Path:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1031, 424);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 24;
            this.button4.Text = "Browse";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.Location = new System.Drawing.Point(587, 453);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(92, 47);
            this.reset_btn.TabIndex = 91;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // outputPath_txt
            // 
            this.outputPath_txt.Location = new System.Drawing.Point(721, 424);
            this.outputPath_txt.Name = "outputPath_txt";
            this.outputPath_txt.Size = new System.Drawing.Size(304, 23);
            this.outputPath_txt.TabIndex = 23;
            // 
            // goToDirectory_btn
            // 
            this.goToDirectory_btn.Enabled = false;
            this.goToDirectory_btn.Location = new System.Drawing.Point(587, 603);
            this.goToDirectory_btn.Name = "goToDirectory_btn";
            this.goToDirectory_btn.Size = new System.Drawing.Size(519, 23);
            this.goToDirectory_btn.TabIndex = 90;
            this.goToDirectory_btn.Text = "Find Template in Explorer!";
            this.goToDirectory_btn.UseVisualStyleBackColor = true;
            this.goToDirectory_btn.Click += new System.EventHandler(this.goToDirectory_btn_Click);
            // 
            // log_txt
            // 
            this.log_txt.Location = new System.Drawing.Point(587, 523);
            this.log_txt.Multiline = true;
            this.log_txt.Name = "log_txt";
            this.log_txt.ReadOnly = true;
            this.log_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log_txt.Size = new System.Drawing.Size(519, 74);
            this.log_txt.TabIndex = 88;
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(685, 453);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(214, 47);
            this.generate_btn.TabIndex = 87;
            this.generate_btn.Text = "Generate New Template";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // editInstructions_btn
            // 
            this.editInstructions_btn.Location = new System.Drawing.Point(162, 603);
            this.editInstructions_btn.Name = "editInstructions_btn";
            this.editInstructions_btn.Size = new System.Drawing.Size(415, 23);
            this.editInstructions_btn.TabIndex = 85;
            this.editInstructions_btn.Text = "Edit Instructions";
            this.editInstructions_btn.UseVisualStyleBackColor = true;
            this.editInstructions_btn.Click += new System.EventHandler(this.editInstructions_btn_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 607);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 15);
            this.label19.TabIndex = 86;
            this.label19.Text = "Instructions:";
            // 
            // editCommands_btn
            // 
            this.editCommands_btn.Location = new System.Drawing.Point(162, 574);
            this.editCommands_btn.Name = "editCommands_btn";
            this.editCommands_btn.Size = new System.Drawing.Size(414, 23);
            this.editCommands_btn.TabIndex = 23;
            this.editCommands_btn.Text = "Edit Commands";
            this.editCommands_btn.UseVisualStyleBackColor = true;
            this.editCommands_btn.Click += new System.EventHandler(this.editCommands_btn_Click);
            // 
            // commandsNeedGit_cxb
            // 
            this.commandsNeedGit_cxb.AutoSize = true;
            this.commandsNeedGit_cxb.Location = new System.Drawing.Point(162, 549);
            this.commandsNeedGit_cxb.Name = "commandsNeedGit_cxb";
            this.commandsNeedGit_cxb.Size = new System.Drawing.Size(154, 19);
            this.commandsNeedGit_cxb.TabIndex = 84;
            this.commandsNeedGit_cxb.Text = "Commands Require Git?";
            this.commandsNeedGit_cxb.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 578);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 15);
            this.label20.TabIndex = 81;
            this.label20.Text = "Commands:";
            // 
            // renameFiles_txt
            // 
            this.renameFiles_txt.Location = new System.Drawing.Point(162, 520);
            this.renameFiles_txt.Name = "renameFiles_txt";
            this.renameFiles_txt.Size = new System.Drawing.Size(414, 23);
            this.renameFiles_txt.TabIndex = 76;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 523);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 15);
            this.label18.TabIndex = 77;
            this.label18.Text = "Rename Only Files:";
            // 
            // renameDirectories_txt
            // 
            this.renameDirectories_txt.Location = new System.Drawing.Point(162, 491);
            this.renameDirectories_txt.Name = "renameDirectories_txt";
            this.renameDirectories_txt.Size = new System.Drawing.Size(414, 23);
            this.renameDirectories_txt.TabIndex = 74;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 494);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(140, 15);
            this.label17.TabIndex = 75;
            this.label17.Text = "Rename Only Directories:";
            // 
            // cleanupDirectories_txt
            // 
            this.cleanupDirectories_txt.Location = new System.Drawing.Point(162, 462);
            this.cleanupDirectories_txt.Name = "cleanupDirectories_txt";
            this.cleanupDirectories_txt.Size = new System.Drawing.Size(414, 23);
            this.cleanupDirectories_txt.TabIndex = 72;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 465);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 15);
            this.label16.TabIndex = 73;
            this.label16.Text = "Cleanup Directories:";
            // 
            // replaceText_txt
            // 
            this.replaceText_txt.Location = new System.Drawing.Point(162, 433);
            this.replaceText_txt.Name = "replaceText_txt";
            this.replaceText_txt.Size = new System.Drawing.Size(414, 23);
            this.replaceText_txt.TabIndex = 70;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 436);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 15);
            this.label15.TabIndex = 71;
            this.label15.Text = "ReplaceText:";
            // 
            // excludedDirectories_txt
            // 
            this.excludedDirectories_txt.Location = new System.Drawing.Point(162, 404);
            this.excludedDirectories_txt.Name = "excludedDirectories_txt";
            this.excludedDirectories_txt.Size = new System.Drawing.Size(414, 23);
            this.excludedDirectories_txt.TabIndex = 68;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 407);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 15);
            this.label14.TabIndex = 69;
            this.label14.Text = "Excluded Directories:";
            // 
            // countGuids_btn
            // 
            this.countGuids_btn.Location = new System.Drawing.Point(501, 375);
            this.countGuids_btn.Name = "countGuids_btn";
            this.countGuids_btn.Size = new System.Drawing.Size(75, 23);
            this.countGuids_btn.TabIndex = 23;
            this.countGuids_btn.Text = "Calculate";
            this.countGuids_btn.UseVisualStyleBackColor = true;
            this.countGuids_btn.Click += new System.EventHandler(this.countGuids_btn_Click);
            // 
            // guidCount_txt
            // 
            this.guidCount_txt.Location = new System.Drawing.Point(163, 375);
            this.guidCount_txt.Name = "guidCount_txt";
            this.guidCount_txt.Size = new System.Drawing.Size(332, 23);
            this.guidCount_txt.TabIndex = 65;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 378);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 15);
            this.label13.TabIndex = 66;
            this.label13.Text = "Number Solution GUIDs:";
            // 
            // nugetLicense_txt
            // 
            this.nugetLicense_txt.Location = new System.Drawing.Point(162, 346);
            this.nugetLicense_txt.Name = "nugetLicense_txt";
            this.nugetLicense_txt.Size = new System.Drawing.Size(413, 23);
            this.nugetLicense_txt.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 349);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 15);
            this.label12.TabIndex = 64;
            this.label12.Text = "Default Nuget License:";
            // 
            // nugetTags_txt
            // 
            this.nugetTags_txt.Location = new System.Drawing.Point(162, 317);
            this.nugetTags_txt.Name = "nugetTags_txt";
            this.nugetTags_txt.Size = new System.Drawing.Size(413, 23);
            this.nugetTags_txt.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 15);
            this.label11.TabIndex = 62;
            this.label11.Text = "Default Nuget Tags:";
            // 
            // askNugetInfo_cxb
            // 
            this.askNugetInfo_cxb.AutoSize = true;
            this.askNugetInfo_cxb.Checked = true;
            this.askNugetInfo_cxb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.askNugetInfo_cxb.Location = new System.Drawing.Point(163, 263);
            this.askNugetInfo_cxb.Name = "askNugetInfo_cxb";
            this.askNugetInfo_cxb.Size = new System.Drawing.Size(170, 19);
            this.askNugetInfo_cxb.TabIndex = 60;
            this.askNugetInfo_cxb.Text = "Ask for Nuget Information?";
            this.askNugetInfo_cxb.UseVisualStyleBackColor = true;
            // 
            // nugetDescription_txt
            // 
            this.nugetDescription_txt.Location = new System.Drawing.Point(162, 288);
            this.nugetDescription_txt.Name = "nugetDescription_txt";
            this.nugetDescription_txt.Size = new System.Drawing.Size(413, 23);
            this.nugetDescription_txt.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 15);
            this.label9.TabIndex = 59;
            this.label9.Text = "Default Nuget Description:";
            // 
            // nameFormat_txt
            // 
            this.nameFormat_txt.Location = new System.Drawing.Point(162, 234);
            this.nameFormat_txt.Name = "nameFormat_txt";
            this.nameFormat_txt.Size = new System.Drawing.Size(413, 23);
            this.nameFormat_txt.TabIndex = 56;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 15);
            this.label8.TabIndex = 57;
            this.label8.Text = "Default Name Format:";
            // 
            // solutionName_txt
            // 
            this.solutionName_txt.Location = new System.Drawing.Point(162, 205);
            this.solutionName_txt.Name = "solutionName_txt";
            this.solutionName_txt.Size = new System.Drawing.Size(413, 23);
            this.solutionName_txt.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 15);
            this.label7.TabIndex = 55;
            this.label7.Text = "Default Solution Name:";
            // 
            // templateDescription_txt
            // 
            this.templateDescription_txt.BackColor = System.Drawing.SystemColors.Window;
            this.templateDescription_txt.Location = new System.Drawing.Point(162, 103);
            this.templateDescription_txt.Name = "templateDescription_txt";
            this.templateDescription_txt.Size = new System.Drawing.Size(413, 23);
            this.templateDescription_txt.TabIndex = 52;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 15);
            this.label10.TabIndex = 53;
            this.label10.Text = "Template Description:";
            // 
            // templateVersion_txt
            // 
            this.templateVersion_txt.BackColor = System.Drawing.SystemColors.Window;
            this.templateVersion_txt.Location = new System.Drawing.Point(162, 74);
            this.templateVersion_txt.Name = "templateVersion_txt";
            this.templateVersion_txt.Size = new System.Drawing.Size(413, 23);
            this.templateVersion_txt.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "Template Version:";
            // 
            // templateAuthor_txt
            // 
            this.templateAuthor_txt.BackColor = System.Drawing.SystemColors.Window;
            this.templateAuthor_txt.Location = new System.Drawing.Point(163, 45);
            this.templateAuthor_txt.Name = "templateAuthor_txt";
            this.templateAuthor_txt.Size = new System.Drawing.Size(412, 23);
            this.templateAuthor_txt.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 49;
            this.label3.Text = "Template Author:";
            // 
            // templateName_txt
            // 
            this.templateName_txt.BackColor = System.Drawing.SystemColors.Window;
            this.templateName_txt.Location = new System.Drawing.Point(162, 16);
            this.templateName_txt.Name = "templateName_txt";
            this.templateName_txt.Size = new System.Drawing.Size(413, 23);
            this.templateName_txt.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 47;
            this.label2.Text = "Template Name:";
            // 
            // author_txt
            // 
            this.author_txt.BackColor = System.Drawing.SystemColors.Window;
            this.author_txt.Location = new System.Drawing.Point(162, 147);
            this.author_txt.Name = "author_txt";
            this.author_txt.Size = new System.Drawing.Size(413, 23);
            this.author_txt.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "Default Author:";
            // 
            // company_txt
            // 
            this.company_txt.Location = new System.Drawing.Point(162, 176);
            this.company_txt.Name = "company_txt";
            this.company_txt.Size = new System.Drawing.Size(413, 23);
            this.company_txt.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "Default Company Name:";
            // 
            // TemplateGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 745);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TemplateGenerator";
            this.Text = "SolutionCreator";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.solutionConfig_box.ResumeLayout(false);
            this.solutionConfig_box.PerformLayout();
            this.templateSettings_box.ResumeLayout(false);
            this.templateSettings_box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox solutionConfig_box;
        private Label label1;
        private Button browse_btn;
        private TextBox directory_txt;
        private GroupBox templateSettings_box;
        private TextBox templateDescription_txt;
        private Label label10;
        private TextBox templateVersion_txt;
        private Label label4;
        private TextBox templateAuthor_txt;
        private Label label3;
        private TextBox templateName_txt;
        private Label label2;
        private TextBox author_txt;
        private Label label5;
        private TextBox company_txt;
        private Label label6;
        private Button editInstructions_btn;
        private Label label19;
        private Button editCommands_btn;
        private CheckBox commandsNeedGit_cxb;
        private Label label20;
        private TextBox renameFiles_txt;
        private Label label18;
        private TextBox renameDirectories_txt;
        private Label label17;
        private TextBox cleanupDirectories_txt;
        private Label label16;
        private TextBox replaceText_txt;
        private Label label15;
        private TextBox excludedDirectories_txt;
        private Label label14;
        private Button countGuids_btn;
        private TextBox guidCount_txt;
        private Label label13;
        private TextBox nugetLicense_txt;
        private Label label12;
        private TextBox nugetTags_txt;
        private Label label11;
        private CheckBox askNugetInfo_cxb;
        private TextBox nugetDescription_txt;
        private Label label9;
        private TextBox nameFormat_txt;
        private Label label8;
        private TextBox solutionName_txt;
        private Label label7;
        private Button reset_btn;
        private Button goToDirectory_btn;
        private TextBox log_txt;
        private Button generate_btn;
        private Label label21;
        private Button button4;
        private TextBox outputPath_txt;
        private TextBox textBox1;
        private Label label23;
        private Button editSelected_btn;
        private Label label22;
        private ListBox projectNameReplacements_txt;
        private CheckBox deleteWorkingDir_cxb;
    }
}