using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Text;

using SolutionCreator.Core;

using SolutionCreatorApp.Properties;

namespace SolutionCreatorApp.Pages
{
    public partial class SolutionCreator : Form
    {
        private readonly Dictionary<Area, List<Control>> _groupedControls = new();
        private readonly Core _templateCore;

        private bool _actionGuard;

        private string _currentUserFullName;

        private Dictionary<string, string> _replacementText = new();
        private FileConflictMode _repoFileConflictMode = FileConflictMode.Override;

        private GitRepoMode _repoMode = GitRepoMode.NoRepo;

        public SolutionCreator()
        {
            InitializeComponent();

            // defaults
            this._templateCore = new Core();
            this._actionGuard = false;

            // group controls
            this._groupedControls.Add(Area.Info, new List<Control> {this.templateName_txt, this.templateAuthor_txt, this.templateVersion_txt, this.templateDescription_txt});
            this._groupedControls.Add(
                                      Area.Config
                                    , new List<Control>
                                      {
                                          this.author_txt
                                        , this.company_txt
                                        , this.solution_txt
                                        , this.version_txt
                                        , this.directory_txt
                                        , this.nugetDescription_txt
                                        , this.nugetLicense_txt
                                        , this.nugetTags_txt
                                        , this.log_txt
                                        , this.generate_btn
                                        , this.reset_btn
                                        , this.browse_btn
                                        , this.gitSetting_lst
                                        , this.gitExistingRepo_lst
                                        , this.gitRepoName_txt
                                        , this.gitPrivate_cxb
                                      }
                                     );

            this._groupedControls.Add(Area.Output, new List<Control> {this.copyInstructions_btn, this.copyCommands_btn, this.goToDirectory_btn, this.instructions_txt, this.commands_txt});

            // refresh
            RefreshTemplatesList(true);
        }

        private Template SelectedTemplate => this.templates_lst.SelectedIndex == -1 ? null : this._templateCore.Templates[(string) this.templates_lst.SelectedItem];

        public void RefreshTemplatesList(bool firstRun = false)
        {
            if (!this._actionGuard)
            {
                this._actionGuard = true;
                ResetTemplateInfo();

                this.solutionTemplates_box.Enabled = false;
                this.templates_lst.Items.Clear();
                this.templates_lst.Refresh();

                Constants.Instance.MainApp.UpdateStatusText("Refreshing template list...");
                Constants.Instance.MainApp.UpdateTemplatesText("Refreshing template list...");
                this._templateCore.RefreshTemplatesList();
                var items = new List<string>();
                foreach (var pair in this._templateCore.Templates)
                {
                    items.Add(pair.Key);
                }

                items.Sort();
                foreach (var item in items)
                {
                    this.templates_lst.Items.Add(item);
                }

                Constants.Instance.MainApp.UpdateStatusText("Templates refreshed!");

                Constants.Instance.MainApp.UpdateTemplatesText($"Available Templates: {this._templateCore.Templates.Count}");

                if (firstRun)
                {
                    // we only want to do this once if we can!
                    Task.Run(
                             () =>
                             {
                                 Constants.Instance.MainApp.UpdateStatusText("Fetching user display name...");
                                 this._currentUserFullName = UserPrincipal.Current.DisplayName;
                                 Invoke(EnableFirstRun);
                                 Constants.Instance.MainApp.UpdateStatusText("User display name fetched!");
                             }
                            );
                }
                else
                {
                    this.solutionTemplates_box.Enabled = true;
                }

                this._actionGuard = false;
            }
        }

        public void ResetTemplateInfo()
        {
            ClearAndEnable(this._groupedControls[Area.Info], true);
            ResetSolutionConfig();
        }

        public void EnableFirstRun()
        {
            this.solutionTemplates_box.Enabled = true;
        }

        public void ResetSolutionConfig()
        {
            this.solutionConfig_box.Enabled = false;
            this._replacementText.Clear();

            ClearAndEnable(this._groupedControls[Area.Config], true);
            this.gitPrivate_cxb.Checked = false;

            ResetSolutionOutput();
        }

        public void ResetSolutionOutput()
        {
            ClearAndEnable(this._groupedControls[Area.Output], false);
        }

        public void ClearAndEnable(List<Control> controls, bool enable)
        {
            for (var i = 0; i < controls.Count; i++)
            {
                if (controls[i] is TextBox)
                {
                    UpdateTextBox((TextBox) controls[i], string.Empty);
                }
                else if (controls[i] is ComboBox)
                {
                    ((ComboBox) controls[i]).SelectedIndex = 0;
                }

                controls[i].Enabled = enable;
            }
        }

        public void UpdateTextBox(TextBox box, string str)
        {
            box.Text = str;
            box.Refresh();
        }

        private void templates_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this._currentUserFullName))
            {
                this.solutionConfig_box.Enabled = true;

                var selectedTemplate = this.SelectedTemplate;
                if (selectedTemplate != null)
                {
                    // update template info
                    UpdateTextBox(this.templateName_txt, selectedTemplate.Name);
                    UpdateTextBox(this.templateAuthor_txt, selectedTemplate.TemplateAuthor);
                    UpdateTextBox(this.templateVersion_txt, selectedTemplate.TemplateVersion);
                    UpdateTextBox(this.templateDescription_txt, selectedTemplate.Description);

                    // populate solution config with defaults
                    PopulateDefaultConfig();
                    Constants.Instance.MainApp.UpdateStatusText($"Selected template: {selectedTemplate.Name}");
                }
            }
        }

        public void PopulateDefaultConfig()
        {
            var selectedTemplate = this.SelectedTemplate;
            if (selectedTemplate != null)
            {
                ResetSolutionConfig();
                this.solutionConfig_box.Enabled = true;
                this._replacementText = new Dictionary<string, string> {{Constants.CoreSpecialTextCurrentFullName, this._currentUserFullName}, {Constants.CoreSpecialTextParentDir, Constants.CoreSpecialTextParentDir}};

                // configure nuget section...
                if (selectedTemplate.AskForNugetInfo)
                {
                    this.nugetDescription_txt.Enabled = true;
                    this.nugetLicense_txt.Enabled = true;
                    this.nugetTags_txt.Enabled = true;
                }
                else
                {
                    this.nugetDescription_txt.Enabled = false;
                    this.nugetLicense_txt.Enabled = false;
                    this.nugetTags_txt.Enabled = false;
                }

                // configure default values...
                this.author_txt.Text = SanitizedText(selectedTemplate.DefaultAuthor);
                this.company_txt.Text = SanitizedText(selectedTemplate.DefaultCompanyName);
                this.solution_txt.Text = SanitizedText(selectedTemplate.DefaultName);
                this.directory_txt.Text = Directory.GetCurrentDirectory();
                this.version_txt.Text = "1.0.0";

                this.nugetDescription_txt.Text = selectedTemplate.DefaultNugetDescription;
                this.nugetLicense_txt.Text = selectedTemplate.DefaultNugetLicense;
                this.nugetTags_txt.Text = selectedTemplate.DefaultNugetTags;
            }
        }

        public string SanitizedText(string value)
        {
            foreach (var pair in this._replacementText)
            {
                value = value.Replace(pair.Key, pair.Value);
            }

            return value;
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshTemplatesList();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            ResetSolutionConfig();
            this.solutionConfig_box.Enabled = true;
            PopulateDefaultConfig();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            ResetSolutionOutput();
            var selectedTemplate = this.SelectedTemplate;
            if (selectedTemplate != null && !this._actionGuard)
            {
                Constants.Instance.MainApp.UpdateStatusText("Generating solution from template...");
                this._actionGuard = true;

                var settings = new SolutionSettings(
                                                    this.author_txt.Text
                                                  , this.company_txt.Text
                                                  , this.solution_txt.Text
                                                  , this.directory_txt.Text
                                                  , this.version_txt.Text
                                                  , this.nugetDescription_txt.Text
                                                  , this.nugetLicense_txt.Text
                                                  , this.nugetTags_txt.Text
                                                  , this._repoFileConflictMode
                                                  , new GitSettings(
                                                                    this.gitRepoName_txt.Text
                                                                  , Settings.Default.User
                                                                  , Settings.Default.User
                                                                  , Settings.Default.Password
                                                                  , this.gitPrivate_cxb.Checked
                                                                  , this._repoMode
                                                                   )
                                                   );

                var solution = new Solution(selectedTemplate, settings, UpdateOutputLog, UpdateInstructionsText, UpdateCommandsText);
                this.log_txt.Text = string.Empty;
                this.instructions_txt.Text = string.Empty;
                if (!solution.ValidateSettings(out var errors))
                {
                    Constants.Instance.MainApp.UpdateStatusText("Validation errors when generating solution!");

                    // Validation errors!
                    var str = new StringBuilder();
                    foreach (var error in errors)
                    {
                        str.AppendLine(error);
                    }

                    this.log_txt.Text = str.ToString();
                }
                else
                {
                    ClearAndEnable(this._groupedControls[Area.Output], true);

                    solution.GenerateSolution();
                    Constants.Instance.MainApp.UpdateStatusText("Solution generated!");
                }

                this._actionGuard = false;
            }
        }

        private bool UpdateOutputLog(string value)
        {
            this.log_txt.Text = $"{this.log_txt.Text}{value}{Environment.NewLine}";
            this.log_txt.Refresh();

            return true;
        }

        private bool UpdateInstructionsText(string value)
        {
            this.instructions_txt.Text = $"{this.instructions_txt.Text}{value}{Environment.NewLine}";
            this.instructions_txt.Refresh();

            return true;
        }

        private bool UpdateCommandsText(string value)
        {
            this.commands_txt.Text = $"{this.commands_txt.Text}{value}{Environment.NewLine}";
            this.commands_txt.Refresh();

            return true;
        }

        private void copyInstructions_btn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.instructions_txt.Text);
        }

        private void copyCommands_btn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.commands_txt.Text);
        }

        private void goToDirectory_btn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(this.directory_txt.Text, this.solution_txt.Text));
        }

        private void author_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void company_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void solution_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void directory_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void version_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void nugetDescription_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void nugetLicense_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void nugetTags_txt_TextChanged(object sender, EventArgs e)
        {
            if (this.goToDirectory_btn.Enabled)
            {
                ResetSolutionOutput();
            }
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = "What is the root folder for the new solution?";
            dialog.UseDescriptionForTitle = true;
            dialog.InitialDirectory = string.IsNullOrWhiteSpace(this.directory_txt.Text) ? Directory.GetCurrentDirectory() : this.directory_txt.Text;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.directory_txt.Text = dialog.SelectedPath;
                this._replacementText[Constants.CoreSpecialTextParentDir] = Path.GetFileNameWithoutExtension(dialog.SelectedPath);
                if (string.IsNullOrWhiteSpace(this.solution_txt.Text) || this.solution_txt.Text == this.SelectedTemplate.DefaultName)
                {
                    this.solution_txt.Text = SanitizedText(this.SelectedTemplate.DefaultNameFormat);

                    this.solution_txt.Text = this.SelectedTemplate.DefaultNameFormat.Replace(Constants.CoreSpecialTextParentDir, Path.GetFileNameWithoutExtension(dialog.SelectedPath));
                }
            }
        }

        private void gitSetting_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.gitSetting_lst.Text)
            {
                case "No Repo":
                    this._repoMode = GitRepoMode.NoRepo;
                    this.gitRepoName_txt.Enabled = false;
                    this.gitExistingRepo_lst.Enabled = false;

                    break;

                case "New Repo, Only Init":
                    this._repoMode = GitRepoMode.NewRepoOnlyInit;
                    this.gitRepoName_txt.Enabled = true;
                    this.gitExistingRepo_lst.Enabled = false;

                    break;

                case "New Repo, Full":
                    this._repoMode = GitRepoMode.NewRepoFull;
                    this.gitRepoName_txt.Enabled = true;
                    this.gitExistingRepo_lst.Enabled = false;

                    break;

                case "Existing Repo, Clean Slate":
                    this._repoMode = GitRepoMode.ExistingRepoCleanSlate;
                    this.gitRepoName_txt.Enabled = true;
                    this.gitExistingRepo_lst.Enabled = true;

                    break;

                case "Existing Repo, Keep Existing Code":
                    this._repoMode = GitRepoMode.ExistingRepoKeepExistingCode;
                    this.gitRepoName_txt.Enabled = true;
                    this.gitExistingRepo_lst.Enabled = true;

                    break;
            }
        }

        private void gitExistingRepo_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.gitExistingRepo_lst.Text)
            {
                case "Keep Only New File (Override)":
                    this._repoFileConflictMode = FileConflictMode.Override;

                    break;

                case "Keep Only Old File":
                    this._repoFileConflictMode = FileConflictMode.KeepOld;

                    break;

                case "New Name for New File (Duplicate)":
                    this._repoFileConflictMode = FileConflictMode.Duplicate;

                    break;
            }
        }

        private enum Area
        {
            Info
          , Config
          , Output
        }
    }
}
