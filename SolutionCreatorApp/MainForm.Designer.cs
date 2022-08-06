namespace SolutionCreatorApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.templates_lst = new System.Windows.Forms.ListBox();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.availableTemplates_txt = new System.Windows.Forms.TextBox();
            this.templateName_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.templateVersion_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.templateDescription_txt = new System.Windows.Forms.TextBox();
            this.createSolution_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.templateAuthor_txt = new System.Windows.Forms.TextBox();
            this.solutionTemplates_box = new System.Windows.Forms.GroupBox();
            this.templateInfo_box = new System.Windows.Forms.GroupBox();
            this.solutionConfig_box = new System.Windows.Forms.GroupBox();
            this.validationErrors_txt = new System.Windows.Forms.TextBox();
            this.author_txt = new System.Windows.Forms.TextBox();
            this.generate_btn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
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
            this.solutionOutput_box = new System.Windows.Forms.GroupBox();
            this.goToDirectory_btn = new System.Windows.Forms.Button();
            this.copyText_txt = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.instructions_txt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.output_txt = new System.Windows.Forms.TextBox();
            this.solutionTemplates_box.SuspendLayout();
            this.templateInfo_box.SuspendLayout();
            this.solutionConfig_box.SuspendLayout();
            this.solutionOutput_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // templates_lst
            // 
            this.templates_lst.FormattingEnabled = true;
            this.templates_lst.ItemHeight = 15;
            this.templates_lst.Location = new System.Drawing.Point(21, 22);
            this.templates_lst.Name = "templates_lst";
            this.templates_lst.Size = new System.Drawing.Size(231, 409);
            this.templates_lst.TabIndex = 0;
            this.templates_lst.SelectedIndexChanged += new System.EventHandler(this.templates_lst_SelectedIndexChanged);
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(196, 436);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(56, 23);
            this.refresh_btn.TabIndex = 2;
            this.refresh_btn.Text = "Refresh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // availableTemplates_txt
            // 
            this.availableTemplates_txt.Location = new System.Drawing.Point(21, 437);
            this.availableTemplates_txt.Name = "availableTemplates_txt";
            this.availableTemplates_txt.ReadOnly = true;
            this.availableTemplates_txt.Size = new System.Drawing.Size(169, 23);
            this.availableTemplates_txt.TabIndex = 3;
            // 
            // templateName_txt
            // 
            this.templateName_txt.Location = new System.Drawing.Point(83, 22);
            this.templateName_txt.Name = "templateName_txt";
            this.templateName_txt.ReadOnly = true;
            this.templateName_txt.Size = new System.Drawing.Size(349, 23);
            this.templateName_txt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Version:";
            // 
            // templateVersion_txt
            // 
            this.templateVersion_txt.Location = new System.Drawing.Point(83, 51);
            this.templateVersion_txt.Name = "templateVersion_txt";
            this.templateVersion_txt.ReadOnly = true;
            this.templateVersion_txt.Size = new System.Drawing.Size(349, 23);
            this.templateVersion_txt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description";
            // 
            // templateDescription_txt
            // 
            this.templateDescription_txt.Location = new System.Drawing.Point(83, 109);
            this.templateDescription_txt.Multiline = true;
            this.templateDescription_txt.Name = "templateDescription_txt";
            this.templateDescription_txt.ReadOnly = true;
            this.templateDescription_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.templateDescription_txt.Size = new System.Drawing.Size(349, 322);
            this.templateDescription_txt.TabIndex = 8;
            // 
            // createSolution_btn
            // 
            this.createSolution_btn.Location = new System.Drawing.Point(10, 437);
            this.createSolution_btn.Name = "createSolution_btn";
            this.createSolution_btn.Size = new System.Drawing.Size(422, 57);
            this.createSolution_btn.TabIndex = 10;
            this.createSolution_btn.Text = "Create Solution From Template";
            this.createSolution_btn.UseVisualStyleBackColor = true;
            this.createSolution_btn.Click += new System.EventHandler(this.createSolution_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Author:";
            // 
            // templateAuthor_txt
            // 
            this.templateAuthor_txt.Location = new System.Drawing.Point(83, 80);
            this.templateAuthor_txt.Name = "templateAuthor_txt";
            this.templateAuthor_txt.ReadOnly = true;
            this.templateAuthor_txt.Size = new System.Drawing.Size(349, 23);
            this.templateAuthor_txt.TabIndex = 11;
            // 
            // solutionTemplates_box
            // 
            this.solutionTemplates_box.Controls.Add(this.templates_lst);
            this.solutionTemplates_box.Controls.Add(this.refresh_btn);
            this.solutionTemplates_box.Controls.Add(this.availableTemplates_txt);
            this.solutionTemplates_box.Location = new System.Drawing.Point(12, 12);
            this.solutionTemplates_box.Name = "solutionTemplates_box";
            this.solutionTemplates_box.Size = new System.Drawing.Size(273, 818);
            this.solutionTemplates_box.TabIndex = 13;
            this.solutionTemplates_box.TabStop = false;
            this.solutionTemplates_box.Text = "Solution Templates";
            // 
            // templateInfo_box
            // 
            this.templateInfo_box.Controls.Add(this.templateName_txt);
            this.templateInfo_box.Controls.Add(this.label3);
            this.templateInfo_box.Controls.Add(this.createSolution_btn);
            this.templateInfo_box.Controls.Add(this.label4);
            this.templateInfo_box.Controls.Add(this.templateDescription_txt);
            this.templateInfo_box.Controls.Add(this.label1);
            this.templateInfo_box.Controls.Add(this.templateVersion_txt);
            this.templateInfo_box.Controls.Add(this.label2);
            this.templateInfo_box.Controls.Add(this.templateAuthor_txt);
            this.templateInfo_box.Location = new System.Drawing.Point(291, 12);
            this.templateInfo_box.Name = "templateInfo_box";
            this.templateInfo_box.Size = new System.Drawing.Size(450, 818);
            this.templateInfo_box.TabIndex = 14;
            this.templateInfo_box.TabStop = false;
            this.templateInfo_box.Text = "Template Info";
            // 
            // solutionConfig_box
            // 
            this.solutionConfig_box.Controls.Add(this.validationErrors_txt);
            this.solutionConfig_box.Controls.Add(this.author_txt);
            this.solutionConfig_box.Controls.Add(this.generate_btn);
            this.solutionConfig_box.Controls.Add(this.label12);
            this.solutionConfig_box.Controls.Add(this.cancel_btn);
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
            this.solutionConfig_box.Location = new System.Drawing.Point(747, 12);
            this.solutionConfig_box.Name = "solutionConfig_box";
            this.solutionConfig_box.Size = new System.Drawing.Size(842, 413);
            this.solutionConfig_box.TabIndex = 41;
            this.solutionConfig_box.TabStop = false;
            this.solutionConfig_box.Text = "New Solution Configuration";
            // 
            // validationErrors_txt
            // 
            this.validationErrors_txt.Location = new System.Drawing.Point(13, 307);
            this.validationErrors_txt.Multiline = true;
            this.validationErrors_txt.Name = "validationErrors_txt";
            this.validationErrors_txt.ReadOnly = true;
            this.validationErrors_txt.Size = new System.Drawing.Size(819, 100);
            this.validationErrors_txt.TabIndex = 31;
            // 
            // author_txt
            // 
            this.author_txt.Location = new System.Drawing.Point(135, 22);
            this.author_txt.Name = "author_txt";
            this.author_txt.Size = new System.Drawing.Size(697, 23);
            this.author_txt.TabIndex = 2;
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(261, 254);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(571, 47);
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
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(13, 254);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(245, 47);
            this.cancel_btn.TabIndex = 1;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
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
            this.nugetDescription_txt.Location = new System.Drawing.Point(264, 167);
            this.nugetDescription_txt.Name = "nugetDescription_txt";
            this.nugetDescription_txt.Size = new System.Drawing.Size(568, 23);
            this.nugetDescription_txt.TabIndex = 28;
            // 
            // company_txt
            // 
            this.company_txt.Location = new System.Drawing.Point(135, 51);
            this.company_txt.Name = "company_txt";
            this.company_txt.Size = new System.Drawing.Size(697, 23);
            this.company_txt.TabIndex = 4;
            // 
            // browse_btn
            // 
            this.browse_btn.Location = new System.Drawing.Point(757, 109);
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
            this.solution_txt.Location = new System.Drawing.Point(135, 80);
            this.solution_txt.Name = "solution_txt";
            this.solution_txt.Size = new System.Drawing.Size(697, 23);
            this.solution_txt.TabIndex = 6;
            // 
            // nugetTags_txt
            // 
            this.nugetTags_txt.Location = new System.Drawing.Point(264, 225);
            this.nugetTags_txt.Name = "nugetTags_txt";
            this.nugetTags_txt.Size = new System.Drawing.Size(568, 23);
            this.nugetTags_txt.TabIndex = 16;
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
            this.directory_txt.Location = new System.Drawing.Point(135, 109);
            this.directory_txt.Name = "directory_txt";
            this.directory_txt.Size = new System.Drawing.Size(616, 23);
            this.directory_txt.TabIndex = 8;
            // 
            // nugetLicense_txt
            // 
            this.nugetLicense_txt.Location = new System.Drawing.Point(264, 196);
            this.nugetLicense_txt.Name = "nugetLicense_txt";
            this.nugetLicense_txt.Size = new System.Drawing.Size(568, 23);
            this.nugetLicense_txt.TabIndex = 14;
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
            this.version_txt.Location = new System.Drawing.Point(135, 138);
            this.version_txt.Name = "version_txt";
            this.version_txt.Size = new System.Drawing.Size(697, 23);
            this.version_txt.TabIndex = 10;
            // 
            // solutionOutput_box
            // 
            this.solutionOutput_box.Controls.Add(this.goToDirectory_btn);
            this.solutionOutput_box.Controls.Add(this.copyText_txt);
            this.solutionOutput_box.Controls.Add(this.label15);
            this.solutionOutput_box.Controls.Add(this.instructions_txt);
            this.solutionOutput_box.Controls.Add(this.label14);
            this.solutionOutput_box.Controls.Add(this.output_txt);
            this.solutionOutput_box.Location = new System.Drawing.Point(747, 431);
            this.solutionOutput_box.Name = "solutionOutput_box";
            this.solutionOutput_box.Size = new System.Drawing.Size(842, 399);
            this.solutionOutput_box.TabIndex = 42;
            this.solutionOutput_box.TabStop = false;
            this.solutionOutput_box.Text = "Solution Creation Output";
            // 
            // goToDirectory_btn
            // 
            this.goToDirectory_btn.Location = new System.Drawing.Point(10, 370);
            this.goToDirectory_btn.Name = "goToDirectory_btn";
            this.goToDirectory_btn.Size = new System.Drawing.Size(832, 23);
            this.goToDirectory_btn.TabIndex = 5;
            this.goToDirectory_btn.Text = "Open New Solution in Explorer!";
            this.goToDirectory_btn.UseVisualStyleBackColor = true;
            this.goToDirectory_btn.Click += new System.EventHandler(this.goToDirectory_btn_Click);
            // 
            // copyText_txt
            // 
            this.copyText_txt.Location = new System.Drawing.Point(690, 12);
            this.copyText_txt.Name = "copyText_txt";
            this.copyText_txt.Size = new System.Drawing.Size(142, 29);
            this.copyText_txt.TabIndex = 4;
            this.copyText_txt.Text = "Copy Instructions";
            this.copyText_txt.UseVisualStyleBackColor = true;
            this.copyText_txt.Click += new System.EventHandler(this.copyText_txt_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(318, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 15);
            this.label15.TabIndex = 3;
            this.label15.Text = "Manual Instructions:";
            // 
            // instructions_txt
            // 
            this.instructions_txt.Location = new System.Drawing.Point(318, 40);
            this.instructions_txt.Multiline = true;
            this.instructions_txt.Name = "instructions_txt";
            this.instructions_txt.ReadOnly = true;
            this.instructions_txt.Size = new System.Drawing.Size(514, 324);
            this.instructions_txt.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(135, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 15);
            this.label14.TabIndex = 1;
            this.label14.Text = "Run Log:";
            // 
            // output_txt
            // 
            this.output_txt.Location = new System.Drawing.Point(10, 40);
            this.output_txt.Multiline = true;
            this.output_txt.Name = "output_txt";
            this.output_txt.ReadOnly = true;
            this.output_txt.Size = new System.Drawing.Size(292, 324);
            this.output_txt.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1601, 842);
            this.Controls.Add(this.solutionOutput_box);
            this.Controls.Add(this.solutionConfig_box);
            this.Controls.Add(this.templateInfo_box);
            this.Controls.Add(this.solutionTemplates_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.solutionTemplates_box.ResumeLayout(false);
            this.solutionTemplates_box.PerformLayout();
            this.templateInfo_box.ResumeLayout(false);
            this.templateInfo_box.PerformLayout();
            this.solutionConfig_box.ResumeLayout(false);
            this.solutionConfig_box.PerformLayout();
            this.solutionOutput_box.ResumeLayout(false);
            this.solutionOutput_box.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox templates_lst;
        private Button refresh_btn;
        private TextBox availableTemplates_txt;
        private TextBox templateName_txt;
        private Label label1;
        private Label label2;
        private TextBox templateVersion_txt;
        private Label label3;
        private TextBox templateDescription_txt;
        private Button createSolution_btn;
        private Label label4;
        private TextBox templateAuthor_txt;
        private GroupBox solutionTemplates_box;
        private GroupBox templateInfo_box;
        private GroupBox solutionConfig_box;
        private TextBox author_txt;
        private Button generate_btn;
        private Label label12;
        private Button cancel_btn;
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
        private GroupBox solutionOutput_box;
        private TextBox validationErrors_txt;
        private Button copyText_txt;
        private Label label15;
        private TextBox instructions_txt;
        private Label label14;
        private TextBox output_txt;
        private Button goToDirectory_btn;
    }
}