using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Reflection;
using System.Text;

using SolutionCreator.Core;

namespace SolutionCreatorApp
{
    /// <summary>
    ///     The application's main window.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        ///     (Immutable) the template core.
        /// </summary>
        private readonly Core _templateCore;

        /// <summary>
        ///     True to action guard.
        /// </summary>
        private bool _actionGuard;

        /// <summary>
        ///     Gets the current user full name.
        /// </summary>
        /// <value>
        ///     The name of the current user full.
        /// </value>
        private string _currentUserFullName;

        /// <summary>
        ///     The replacement text.
        /// </summary>
        private Dictionary<string, string> _replacementText = new();

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this._templateCore = new Core();
            this._actionGuard = false;
            this.Text = $"SolutionCreator - v{Assembly.GetEntryAssembly().GetName().Version}";
            RefreshTemplatesList(true);
        }

        /// <summary>
        ///     Gets the selected template.
        /// </summary>
        /// <value>
        ///     The selected template.
        /// </value>
        private Template SelectedTemplate => this.templates_lst.SelectedIndex == -1 ? null : this._templateCore.Templates[(string) this.templates_lst.SelectedItem];

        /// <summary>
        ///     Refresh templates list.
        /// </summary>
        public void RefreshTemplatesList(bool firstRun = false)
        {
            if (!this._actionGuard)
            {
                this._actionGuard = true;

                if (firstRun)
                {
                    // we only want to do this once if we can!
                    this._currentUserFullName = UserPrincipal.Current.DisplayName;
                }

                this.templates_lst.Items.Clear();
                this.templates_lst.Refresh();
                UpdateAvailableTemplatesText("Refreshing template list...");
                ResetTemplateInfoBox();

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

                UpdateAvailableTemplatesText($"Available Templates: {this._templateCore.Templates.Count}");

                this._actionGuard = false;
            }
        }

        /// <summary>
        ///     Resets the template information box.
        /// </summary>
        public void ResetTemplateInfoBox()
        {
            UpdateTemplateNameText(string.Empty);
            UpdateTemplateAuthorText(string.Empty);
            UpdateTemplateVersionText(string.Empty);
            UpdateTemplateDescriptionText(string.Empty);
            this.templateInfo_box.Enabled = false;
            ResetSolutionConfigBox();
        }

        /// <summary>
        ///     Resets the solution output box.
        /// </summary>
        public void ResetSolutionOutputBox()
        {
            this.solutionOutput_box.Enabled = false;
            this.output_txt.Text = string.Empty;
            this.instructions_txt.Text = string.Empty;
        }

        /// <summary>
        ///     Resets the solution configuration box.
        /// </summary>
        public void ResetSolutionConfigBox()
        {
            this.solutionConfig_box.Enabled = false;
            this._replacementText.Clear();

            this.author_txt.Text = string.Empty;
            this.company_txt.Text = string.Empty;
            this.solution_txt.Text = string.Empty;
            this.version_txt.Text = string.Empty;
            this.directory_txt.Text = string.Empty;

            this.nugetDescription_txt.Text = string.Empty;
            this.nugetLicense_txt.Text = string.Empty;
            this.nugetLicense_txt.Text = string.Empty;
            this.validationErrors_txt.Text = string.Empty;
            ResetSolutionOutputBox();
        }

        /// <summary>
        ///     Updates the template name text described by value.
        /// </summary>
        /// <param name="value">    The value. </param>
        public void UpdateTemplateNameText(string value)
        {
            this.templateName_txt.Text = value;
            this.templateName_txt.Refresh();
        }

        /// <summary>
        ///     Updates the template version text described by value.
        /// </summary>
        /// <param name="value">    The value. </param>
        public void UpdateTemplateVersionText(string value)
        {
            this.templateVersion_txt.Text = value;
            this.templateVersion_txt.Refresh();
        }

        /// <summary>
        ///     Updates the template description text described by value.
        /// </summary>
        /// <param name="value">    The value. </param>
        public void UpdateTemplateDescriptionText(string value)
        {
            this.templateDescription_txt.Text = value;
            this.templateDescription_txt.Refresh();
        }

        /// <summary>
        ///     Updates the template author text described by value.
        /// </summary>
        /// <param name="value">    The value. </param>
        public void UpdateTemplateAuthorText(string value)
        {
            this.templateAuthor_txt.Text = value;
            this.templateAuthor_txt.Refresh();
        }

        /// <summary>
        ///     Updates the available templates text described by value.
        /// </summary>
        /// <param name="value">    The value. </param>
        public void UpdateAvailableTemplatesText(string value)
        {
            this.availableTemplates_txt.Text = value;
            this.availableTemplates_txt.Refresh();
        }

        /// <summary>
        ///     Event handler. Called by refresh_btn for click events.
        /// </summary>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        private void refresh_btn_Click(object sender, EventArgs e)
        {
            RefreshTemplatesList();
        }

        /// <summary>
        ///     Event handler. Called by templates_lst for selected index changed events.
        /// </summary>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        private void templates_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTemplate = this.SelectedTemplate;
            if (selectedTemplate != null)
            {
                this.templateInfo_box.Enabled = true;
                ResetSolutionConfigBox();
                UpdateTemplateNameText(selectedTemplate.Name);
                UpdateTemplateAuthorText(selectedTemplate.TemplateAuthor);
                UpdateTemplateVersionText(selectedTemplate.TemplateVersion);
                UpdateTemplateDescriptionText(this.SelectedTemplate.Description);
                createSolution_btn_Click(this, e);
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

        /// <summary>
        ///     Event handler. Called by createSolution_btn for click events.
        /// </summary>
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        private void createSolution_btn_Click(object sender, EventArgs e)
        {
            var selectedTemplate = this.SelectedTemplate;
            if (selectedTemplate != null && !this._actionGuard)
            {
                this.solutionConfig_box.Enabled = true;
                this._replacementText = new Dictionary<string, string> {{Constants.SpecialTextCurrentFullName, this._currentUserFullName}, {Constants.SpecialTextParentDir, Constants.SpecialTextParentDir}};

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

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            ResetSolutionConfigBox();
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            var selectedTemplate = this.SelectedTemplate;
            if (selectedTemplate != null && !this._actionGuard)
            {
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
                                                   );

                var solution = new Solution(selectedTemplate, settings, UpdateOutputLog, UpdateInstructionsText);
                this.validationErrors_txt.Text = string.Empty;
                this.instructions_txt.Text = string.Empty;
                if (!solution.ValidateSettings(out var errors))
                {
                    // Validation errors!
                    this.solutionOutput_box.Enabled = false;
                    var str = new StringBuilder();
                    foreach (var error in errors)
                    {
                        str.AppendLine(error);
                    }

                    this.validationErrors_txt.Text = str.ToString();
                }
                else
                {
                    this.solutionOutput_box.Enabled = true;
                    solution.GenerateSolution();
                }

                this._actionGuard = false;
            }
        }

        private bool UpdateOutputLog(string value)
        {
            this.output_txt.Text = $"{this.output_txt.Text}{Environment.NewLine}{value}";
            this.output_txt.Refresh();

            return true;
        }

        private bool UpdateInstructionsText(string value)
        {
            this.instructions_txt.Text = $"{this.instructions_txt.Text}{Environment.NewLine}{value}";
            this.instructions_txt.Refresh();

            return true;
        }

        private void copyText_txt_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.instructions_txt.Text);
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
                this._replacementText[Constants.SpecialTextParentDir] = Path.GetFileNameWithoutExtension(dialog.SelectedPath);
                if (string.IsNullOrWhiteSpace(this.solution_txt.Text) || this.solution_txt.Text == this.SelectedTemplate.DefaultName)
                {
                    this.solution_txt.Text = SanitizedText(this.SelectedTemplate.DefaultNameFormat);

                    this.solution_txt.Text = this.SelectedTemplate.DefaultNameFormat.Replace(Constants.SpecialTextParentDir, Path.GetFileNameWithoutExtension(dialog.SelectedPath));
                }
            }
        }

        private void goToDirectory_btn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Path.Combine(this.directory_txt.Text, this.solution_txt.Text));
        }
    }
}
