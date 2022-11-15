using System.Diagnostics;

using SolutionCreator.Core;

namespace SolutionCreatorApp.Pages
{
    public partial class TemplateGenerator : Form
    {
        private string _commandText = string.Empty;
        private string _instructionsText = string.Empty;
        private string _outputtedTemplate = string.Empty;
        private string _solutionDirectory = string.Empty;
        private string _solutionPath = string.Empty;
        private Template _templatesInfo;

        public TemplateGenerator()
        {
            InitializeComponent();
            Refresh();
        }

        public override void Refresh()
        {
            base.Refresh();
            this.directory_txt.Text = string.Empty;
            RefreshConfiguration();
            this.templateSettings_box.Enabled = false;
        }

        private void browse_btn_Click_1(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "What solution do you want to convert into a template?";
            dialog.Filter = "Solution Files (*.sln)|*.sln";
            dialog.InitialDirectory = Directory.GetCurrentDirectory();
            dialog.Multiselect = false;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.directory_txt.Text = dialog.FileName;
                this._solutionPath = dialog.FileName;
                this._solutionDirectory = Path.GetDirectoryName(dialog.FileName);
                RefreshConfiguration();
            }
        }

        public void RefreshConfiguration()
        {
            this.projectNameReplacements_txt.Items.Clear();

            // Look at the .SLN file and estimate the number of GUIDs that we'll need...
            if (!string.IsNullOrEmpty(this._solutionPath))
            {
                var lines = File.ReadAllLines(this._solutionPath);
                var fileName = Path.GetFileNameWithoutExtension(this._solutionPath);
                foreach (var line in lines)
                {
                    if (line.StartsWith("Project(", StringComparison.InvariantCultureIgnoreCase) && !line.StartsWith("Project(\"{2150E333-8FDC-42A3-9474-1A3956D46DE8}\"", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var name = line.Split(" = ")[1].Split(",")[0].Replace("\"", "");
                        var modifiedName = name.Replace(fileName, "[SOLUTIONNAME]");

                        this.projectNameReplacements_txt.Items.Add($"{name}: {modifiedName}");
                    }
                }
            }

            this.templateSettings_box.Enabled = true;
            this.goToDirectory_btn.Enabled = false;

            // Get or set the TemplateInfo object
            this._templatesInfo = GetTemplateInfoOrDefault(this._solutionDirectory);

            // Reset the text fields
            this.templateName_txt.Text = this._templatesInfo.Name;
            this.templateAuthor_txt.Text = this._templatesInfo.TemplateAuthor;
            this.templateVersion_txt.Text = this._templatesInfo.TemplateVersion;
            this.templateDescription_txt.Text = this._templatesInfo.Description;

            this.author_txt.Text = this._templatesInfo.DefaultAuthor;
            this.company_txt.Text = this._templatesInfo.DefaultCompanyName;
            this.solutionName_txt.Text = this._templatesInfo.DefaultName;
            this.nameFormat_txt.Text = this._templatesInfo.DefaultNameFormat;

            this.askNugetInfo_cxb.Checked = this._templatesInfo.AskForNugetInfo;
            this.nugetDescription_txt.Text = this._templatesInfo.DefaultNugetDescription;
            this.nugetTags_txt.Text = this._templatesInfo.DefaultNugetTags;
            this.nugetLicense_txt.Text = this._templatesInfo.DefaultNugetLicense;

            this.guidCount_txt.Text = this._templatesInfo.Guids.ToString();
            if (this._templatesInfo.Guids == 0)
            {
                countGuids_btn_Click(this, EventArgs.Empty);
            }

            this.excludedDirectories_txt.Text = string.Join(", ", this._templatesInfo.ExcludedDirectories);

            this.replaceText_txt.Text = string.Join(",", this._templatesInfo.ReplaceText.Select(x => $"{x.Key}: {x.Value}"));
            this.cleanupDirectories_txt.Text = string.Join(", ", this._templatesInfo.CleanupDirectories);
            this.renameDirectories_txt.Text = string.Join(", ", this._templatesInfo.RenameOnlyDirectories);
            this.renameFiles_txt.Text = string.Join(", ", this._templatesInfo.RenameOnlyFiles);
            this.commandsNeedGit_cxb.Checked = this._templatesInfo.CommandsRequireGit;
            this._commandText = string.Join(Environment.NewLine, this._templatesInfo.Commands);
            this._instructionsText = string.Join(Environment.NewLine, this._templatesInfo.Instructions);

            // Reset log and output
            this.outputPath_txt.Text = string.Empty;
            this.log_txt.Text = string.Empty;
        }

        public Template GetTemplateInfoOrDefault(string directory)
        {
            var templateInfoFile = Path.Combine(directory, "TEMPLATE_INFO.txt");
            var template = new Template();
            if (File.Exists(templateInfoFile))
            {
                // Load template info file!
                template.PopulateFromTemplateInfoFile(templateInfoFile);
            }

            return template;
        }

        private void countGuids_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this._solutionPath))
            {
                // Look at the .SLN file and estimate the number of GUIDs that we'll need...
                var lines = File.ReadAllLines(this._solutionPath);
                var count = 0;
                foreach (var line in lines)
                {
                    if (line.StartsWith("Project(", StringComparison.InvariantCultureIgnoreCase))
                    {
                        count++;
                    }

                    if (line.TrimStart().StartsWith("SolutionGuid = ", StringComparison.InvariantCultureIgnoreCase))
                    {
                        count++;
                    }
                }

                this.guidCount_txt.Text = count.ToString();
            }
        }

        private void editCommands_btn_Click(object sender, EventArgs e)
        {
            // Pop open a multi-line text window and grab the commands
            var editor = new TextEdit(this._commandText);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                this._commandText = editor.EditorText;
            }
        }

        private void editInstructions_btn_Click(object sender, EventArgs e)
        {
            // Pop open a multi-line text window and grab the instructions
            var editor = new TextEdit(this._instructionsText);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                this._instructionsText = editor.EditorText;
            }
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            // Create a template info object
            var templateInfo = new Template();
            templateInfo.Name = this.templateName_txt.Text;
            templateInfo.Description = this.templateDescription_txt.Text;
            templateInfo.TemplateVersion = this.templateVersion_txt.Text;
            templateInfo.TemplateAuthor = this.templateAuthor_txt.Text;

            templateInfo.DefaultAuthor = this.author_txt.Text;
            templateInfo.DefaultCompanyName = this.company_txt.Text;
            templateInfo.DefaultName = this.solutionName_txt.Text;
            templateInfo.DefaultNameFormat = this.nameFormat_txt.Text;

            templateInfo.AskForNugetInfo = this.askNugetInfo_cxb.Checked;
            templateInfo.DefaultNugetDescription = this.nugetDescription_txt.Text;
            templateInfo.DefaultNugetTags = this.nugetTags_txt.Text;
            templateInfo.DefaultNugetLicense = this.nugetLicense_txt.Text;

            templateInfo.Guids = int.Parse(this.guidCount_txt.Text);

            templateInfo.ExcludedDirectories = CleanedTrimmedList(this.excludedDirectories_txt.Text);
            templateInfo.CleanupDirectories = CleanedTrimmedList(this.cleanupDirectories_txt.Text);
            templateInfo.RenameOnlyDirectories = CleanedTrimmedList(this.renameDirectories_txt.Text);
            templateInfo.RenameOnlyFiles = CleanedTrimmedList(this.renameFiles_txt.Text);
            templateInfo.CommandsRequireGit = this.commandsNeedGit_cxb.Checked;

            templateInfo.Commands = CleanedTrimmedList(this._commandText, Environment.NewLine);
            templateInfo.Instructions = CleanedTrimmedList(this._instructionsText, Environment.NewLine);

            templateInfo.ReplaceText = CleanedTrimmedDict(this.replaceText_txt.Text);

            // Generate a new Template Zip
            var generator = new TemplateGeneration(templateInfo, this.outputPath_txt.Text, CleanedTrimmedDict(this.projectNameReplacements_txt.Text), this.directory_txt.Text);
            generator.GenerateTemplate(this.deleteWorkingDir_cxb.Checked);

            // Enable the GoToDirectory button
            this.goToDirectory_btn.Enabled = true;
            this._outputtedTemplate = string.Empty;
        }

        private Dictionary<string, string> CleanedTrimmedDict(string text, string delim = ",", string innerDelim = ":")
        {
            var output = new Dictionary<string, string>();
            foreach (var line in text.Split(delim))
            {
                var cleaned = line.Trim();
                if (!string.IsNullOrWhiteSpace(cleaned))
                {
                    var split2 = cleaned.Split(innerDelim);
                    var key = split2[0].Trim();
                    var value = split2[1].Trim();
                    if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(key))
                    {
                        output.Add(key, value);
                    }
                }
            }

            return output;
        }

        private List<string> CleanedTrimmedList(string text, string delim = ",")
        {
            var output = new List<string>();
            foreach (var line in text.Split(delim))
            {
                var cleaned = line.Trim();
                if (!string.IsNullOrWhiteSpace(cleaned))
                {
                    output.Add(cleaned);
                }
            }

            return output;
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            RefreshConfiguration();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Browse for an output directory
            var dialog = new FolderBrowserDialog();
            dialog.UseDescriptionForTitle = true;
            dialog.Description = "Template output folder?";
            dialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.outputPath_txt.Text = dialog.SelectedPath;
                this._outputtedTemplate = dialog.SelectedPath;
            }
        }

        private void goToDirectory_btn_Click(object sender, EventArgs e)
        {
            // open Windows Explorer where we outputted the Template
            Process.Start("explorer.exe", Path.Combine(this.directory_txt.Text, this._outputtedTemplate));
        }

        private void editSelected_btn_Click(object sender, EventArgs e)
        {
            if (this.projectNameReplacements_txt.SelectedItem != null)
            {
                // Pop open a multi-line text window and grab the commands
                var editor = new TextEdit(this.projectNameReplacements_txt.SelectedItem.ToString());
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    this.projectNameReplacements_txt.Items[this.projectNameReplacements_txt.SelectedIndex] = editor.EditorText;
                }
            }
        }
    }
}
