namespace SolutionCreatorApp.Pages
{
    partial class SolutionCreator
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.solutionTemplates_box = new System.Windows.Forms.GroupBox();
            this.templates_lst = new System.Windows.Forms.ComboBox();
            this.templateName_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.templateDescription_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.templateVersion_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.templateAuthor_txt = new System.Windows.Forms.TextBox();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.solutionConfig_box = new System.Windows.Forms.GroupBox();
            this.reset_btn = new System.Windows.Forms.Button();
            this.log_txt = new System.Windows.Forms.TextBox();
            this.copyCommands_btn = new System.Windows.Forms.Button();
            this.commands_txt = new System.Windows.Forms.TextBox();
            this.copyInstructions_btn = new System.Windows.Forms.Button();
            this.goToDirectory_btn = new System.Windows.Forms.Button();
            this.author_txt = new System.Windows.Forms.TextBox();
            this.instructions_txt = new System.Windows.Forms.TextBox();
            this.generate_btn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nugetDescription_txt = new System.Windows.Forms.TextBox();
            this.company_txt = new System.Windows.Forms.TextBox();
            this.browse_btn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.solution_txt = new System.Windows.Forms.TextBox();
            this.nugetTags_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.directory_txt = new System.Windows.Forms.TextBox();
            this.nugetLicense_txt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.version_txt = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.solutionTemplates_box.SuspendLayout();
            this.solutionConfig_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.solutionTemplates_box);
            this.flowLayoutPanel1.Controls.Add(this.solutionConfig_box);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1524, 642);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // solutionTemplates_box
            // 
            this.solutionTemplates_box.Controls.Add(this.templates_lst);
            this.solutionTemplates_box.Controls.Add(this.templateName_txt);
            this.solutionTemplates_box.Controls.Add(this.label3);
            this.solutionTemplates_box.Controls.Add(this.label4);
            this.solutionTemplates_box.Controls.Add(this.templateDescription_txt);
            this.solutionTemplates_box.Controls.Add(this.label1);
            this.solutionTemplates_box.Controls.Add(this.templateVersion_txt);
            this.solutionTemplates_box.Controls.Add(this.label2);
            this.solutionTemplates_box.Controls.Add(this.templateAuthor_txt);
            this.solutionTemplates_box.Controls.Add(this.refresh_btn);
            this.solutionTemplates_box.Location = new System.Drawing.Point(3, 3);
            this.solutionTemplates_box.Name = "solutionTemplates_box";
            this.solutionTemplates_box.Size = new System.Drawing.Size(314, 627);
            this.solutionTemplates_box.TabIndex = 14;
            this.solutionTemplates_box.TabStop = false;
            this.solutionTemplates_box.Text = "Solution Templates";
            // 
            // templates_lst
            // 
            this.templates_lst.FormattingEnabled = true;
            this.templates_lst.Location = new System.Drawing.Point(6, 17);
            this.templates_lst.Name = "templates_lst";
            this.templates_lst.Size = new System.Drawing.Size(265, 23);
            this.templates_lst.TabIndex = 21;
            this.templates_lst.SelectedIndexChanged += new System.EventHandler(this.templates_lst_SelectedIndexChanged);
            // 
            // templateName_txt
            // 
            this.templateName_txt.Location = new System.Drawing.Point(89, 48);
            this.templateName_txt.Name = "templateName_txt";
            this.templateName_txt.ReadOnly = true;
            this.templateName_txt.Size = new System.Drawing.Size(211, 23);
            this.templateName_txt.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Author:";
            // 
            // templateDescription_txt
            // 
            this.templateDescription_txt.Location = new System.Drawing.Point(9, 156);
            this.templateDescription_txt.Multiline = true;
            this.templateDescription_txt.Name = "templateDescription_txt";
            this.templateDescription_txt.ReadOnly = true;
            this.templateDescription_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.templateDescription_txt.Size = new System.Drawing.Size(291, 465);
            this.templateDescription_txt.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            // 
            // templateVersion_txt
            // 
            this.templateVersion_txt.Location = new System.Drawing.Point(89, 78);
            this.templateVersion_txt.Name = "templateVersion_txt";
            this.templateVersion_txt.ReadOnly = true;
            this.templateVersion_txt.Size = new System.Drawing.Size(211, 23);
            this.templateVersion_txt.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Version:";
            // 
            // templateAuthor_txt
            // 
            this.templateAuthor_txt.Location = new System.Drawing.Point(89, 107);
            this.templateAuthor_txt.Name = "templateAuthor_txt";
            this.templateAuthor_txt.ReadOnly = true;
            this.templateAuthor_txt.Size = new System.Drawing.Size(211, 23);
            this.templateAuthor_txt.TabIndex = 19;
            // 
            // refresh_btn
            // 
            this.refresh_btn.BackgroundImage = global::SolutionCreatorApp.Properties.Resources.icons8_refresh_192;
            this.refresh_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refresh_btn.Location = new System.Drawing.Point(277, 19);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(23, 23);
            this.refresh_btn.TabIndex = 2;
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // solutionConfig_box
            // 
            this.solutionConfig_box.Controls.Add(this.reset_btn);
            this.solutionConfig_box.Controls.Add(this.log_txt);
            this.solutionConfig_box.Controls.Add(this.copyCommands_btn);
            this.solutionConfig_box.Controls.Add(this.commands_txt);
            this.solutionConfig_box.Controls.Add(this.copyInstructions_btn);
            this.solutionConfig_box.Controls.Add(this.goToDirectory_btn);
            this.solutionConfig_box.Controls.Add(this.author_txt);
            this.solutionConfig_box.Controls.Add(this.instructions_txt);
            this.solutionConfig_box.Controls.Add(this.generate_btn);
            this.solutionConfig_box.Controls.Add(this.label12);
            this.solutionConfig_box.Controls.Add(this.label11);
            this.solutionConfig_box.Controls.Add(this.label5);
            this.solutionConfig_box.Controls.Add(this.nugetDescription_txt);
            this.solutionConfig_box.Controls.Add(this.company_txt);
            this.solutionConfig_box.Controls.Add(this.browse_btn);
            this.solutionConfig_box.Controls.Add(this.label6);
            this.solutionConfig_box.Controls.Add(this.label8);
            this.solutionConfig_box.Controls.Add(this.solution_txt);
            this.solutionConfig_box.Controls.Add(this.nugetTags_txt);
            this.solutionConfig_box.Controls.Add(this.label7);
            this.solutionConfig_box.Controls.Add(this.label9);
            this.solutionConfig_box.Controls.Add(this.directory_txt);
            this.solutionConfig_box.Controls.Add(this.nugetLicense_txt);
            this.solutionConfig_box.Controls.Add(this.label10);
            this.solutionConfig_box.Controls.Add(this.label13);
            this.solutionConfig_box.Controls.Add(this.version_txt);
            this.solutionConfig_box.Enabled = false;
            this.solutionConfig_box.Location = new System.Drawing.Point(323, 3);
            this.solutionConfig_box.Name = "solutionConfig_box";
            this.solutionConfig_box.Size = new System.Drawing.Size(617, 627);
            this.solutionConfig_box.TabIndex = 42;
            this.solutionConfig_box.TabStop = false;
            this.solutionConfig_box.Text = "New Solution Configuration";
            // 
            // reset_btn
            // 
            this.reset_btn.Location = new System.Drawing.Point(6, 252);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(43, 47);
            this.reset_btn.TabIndex = 34;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // log_txt
            // 
            this.log_txt.Location = new System.Drawing.Point(6, 305);
            this.log_txt.Multiline = true;
            this.log_txt.Name = "log_txt";
            this.log_txt.ReadOnly = true;
            this.log_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log_txt.Size = new System.Drawing.Size(600, 87);
            this.log_txt.TabIndex = 33;
            // 
            // copyCommands_btn
            // 
            this.copyCommands_btn.Location = new System.Drawing.Point(527, 495);
            this.copyCommands_btn.Name = "copyCommands_btn";
            this.copyCommands_btn.Size = new System.Drawing.Size(79, 91);
            this.copyCommands_btn.TabIndex = 32;
            this.copyCommands_btn.Text = "Copy Commands";
            this.copyCommands_btn.UseVisualStyleBackColor = true;
            this.copyCommands_btn.Click += new System.EventHandler(this.copyCommands_btn_Click);
            // 
            // commands_txt
            // 
            this.commands_txt.Location = new System.Drawing.Point(6, 495);
            this.commands_txt.Multiline = true;
            this.commands_txt.Name = "commands_txt";
            this.commands_txt.ReadOnly = true;
            this.commands_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commands_txt.Size = new System.Drawing.Size(515, 91);
            this.commands_txt.TabIndex = 31;
            // 
            // copyInstructions_btn
            // 
            this.copyInstructions_btn.Location = new System.Drawing.Point(527, 398);
            this.copyInstructions_btn.Name = "copyInstructions_btn";
            this.copyInstructions_btn.Size = new System.Drawing.Size(79, 91);
            this.copyInstructions_btn.TabIndex = 4;
            this.copyInstructions_btn.Text = "Copy Instructions";
            this.copyInstructions_btn.UseVisualStyleBackColor = true;
            this.copyInstructions_btn.Click += new System.EventHandler(this.copyInstructions_btn_Click);
            // 
            // goToDirectory_btn
            // 
            this.goToDirectory_btn.Enabled = false;
            this.goToDirectory_btn.Location = new System.Drawing.Point(6, 592);
            this.goToDirectory_btn.Name = "goToDirectory_btn";
            this.goToDirectory_btn.Size = new System.Drawing.Size(600, 23);
            this.goToDirectory_btn.TabIndex = 5;
            this.goToDirectory_btn.Text = "Open New Solution in Explorer!";
            this.goToDirectory_btn.UseVisualStyleBackColor = true;
            this.goToDirectory_btn.Click += new System.EventHandler(this.goToDirectory_btn_Click);
            // 
            // author_txt
            // 
            this.author_txt.BackColor = System.Drawing.SystemColors.Window;
            this.author_txt.Location = new System.Drawing.Point(144, 24);
            this.author_txt.Name = "author_txt";
            this.author_txt.Size = new System.Drawing.Size(462, 23);
            this.author_txt.TabIndex = 2;
            this.author_txt.TextChanged += new System.EventHandler(this.author_txt_TextChanged);
            // 
            // instructions_txt
            // 
            this.instructions_txt.Location = new System.Drawing.Point(6, 398);
            this.instructions_txt.Multiline = true;
            this.instructions_txt.Name = "instructions_txt";
            this.instructions_txt.ReadOnly = true;
            this.instructions_txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.instructions_txt.Size = new System.Drawing.Size(515, 91);
            this.instructions_txt.TabIndex = 2;
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(55, 252);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(551, 47);
            this.generate_btn.TabIndex = 0;
            this.generate_btn.Text = "Generate New Solution";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "Nuget Settings:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(135, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "Package Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Author:";
            // 
            // nugetDescription_txt
            // 
            this.nugetDescription_txt.Location = new System.Drawing.Point(277, 167);
            this.nugetDescription_txt.Name = "nugetDescription_txt";
            this.nugetDescription_txt.Size = new System.Drawing.Size(329, 23);
            this.nugetDescription_txt.TabIndex = 28;
            this.nugetDescription_txt.TextChanged += new System.EventHandler(this.nugetDescription_txt_TextChanged);
            // 
            // company_txt
            // 
            this.company_txt.Location = new System.Drawing.Point(144, 51);
            this.company_txt.Name = "company_txt";
            this.company_txt.Size = new System.Drawing.Size(462, 23);
            this.company_txt.TabIndex = 4;
            this.company_txt.TextChanged += new System.EventHandler(this.company_txt_TextChanged);
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(531, 109);
            this.browse_btn.Name = "browse_btn";
            this.browse_btn.Size = new System.Drawing.Size(75, 23);
            this.browse_btn.TabIndex = 20;
            this.browse_btn.Text = "Browse";
            this.browse_btn.UseVisualStyleBackColor = true;
            this.browse_btn.Click += new System.EventHandler(this.browse_btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Company Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Package Tags:";
            // 
            // solution_txt
            // 
            this.solution_txt.Location = new System.Drawing.Point(144, 80);
            this.solution_txt.Name = "solution_txt";
            this.solution_txt.Size = new System.Drawing.Size(462, 23);
            this.solution_txt.TabIndex = 6;
            this.solution_txt.TextChanged += new System.EventHandler(this.solution_txt_TextChanged);
            // 
            // nugetTags_txt
            // 
            this.nugetTags_txt.Location = new System.Drawing.Point(277, 225);
            this.nugetTags_txt.Name = "nugetTags_txt";
            this.nugetTags_txt.Size = new System.Drawing.Size(329, 23);
            this.nugetTags_txt.TabIndex = 16;
            this.nugetTags_txt.TextChanged += new System.EventHandler(this.nugetTags_txt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "New Solution Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Package License Type:";
            // 
            // directory_txt
            // 
            this.directory_txt.Location = new System.Drawing.Point(144, 109);
            this.directory_txt.Name = "directory_txt";
            this.directory_txt.Size = new System.Drawing.Size(381, 23);
            this.directory_txt.TabIndex = 8;
            this.directory_txt.TextChanged += new System.EventHandler(this.directory_txt_TextChanged);
            // 
            // nugetLicense_txt
            // 
            this.nugetLicense_txt.Location = new System.Drawing.Point(277, 196);
            this.nugetLicense_txt.Name = "nugetLicense_txt";
            this.nugetLicense_txt.Size = new System.Drawing.Size(329, 23);
            this.nugetLicense_txt.TabIndex = 14;
            this.nugetLicense_txt.TextChanged += new System.EventHandler(this.nugetLicense_txt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Root Directory:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 15);
            this.label13.TabIndex = 11;
            this.label13.Text = "Starting Version:";
            // 
            // version_txt
            // 
            this.version_txt.Location = new System.Drawing.Point(144, 138);
            this.version_txt.Name = "version_txt";
            this.version_txt.Size = new System.Drawing.Size(462, 23);
            this.version_txt.TabIndex = 10;
            this.version_txt.TextChanged += new System.EventHandler(this.version_txt_TextChanged);
            // 
            // SolutionCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 642);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SolutionCreator";
            this.Text = "SolutionCreator";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.solutionTemplates_box.ResumeLayout(false);
            this.solutionTemplates_box.PerformLayout();
            this.solutionConfig_box.ResumeLayout(false);
            this.solutionConfig_box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox solutionTemplates_box;
        private Button refresh_btn;
        private TextBox templateName_txt;
        private Label label3;
        private Label label4;
        private TextBox templateDescription_txt;
        private Label label1;
        private TextBox templateVersion_txt;
        private Label label2;
        private TextBox templateAuthor_txt;
        private ComboBox templates_lst;
        private GroupBox solutionConfig_box;
        private TextBox author_txt;
        private Button generate_btn;
        private Label label12;
        private Label label11;
        private Label label5;
        private TextBox nugetDescription_txt;
        private TextBox company_txt;
        private Button browse_btn;
        private Label label6;
        private Label label8;
        private TextBox solution_txt;
        private TextBox nugetTags_txt;
        private Label label7;
        private Label label9;
        private TextBox directory_txt;
        private TextBox nugetLicense_txt;
        private Label label10;
        private Label label13;
        private TextBox version_txt;
        private TextBox log_txt;
        private Button copyCommands_btn;
        private TextBox commands_txt;
        private Button copyInstructions_btn;
        private Button goToDirectory_btn;
        private TextBox instructions_txt;
        private Button reset_btn;
    }
}