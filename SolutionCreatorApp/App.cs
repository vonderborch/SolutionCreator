﻿using System.Diagnostics;
using System.Reflection;

using Microsoft.VisualBasic;

using Newtonsoft.Json;

using SolutionCreator.Core;

using SolutionCreatorApp.Pages;
using SolutionCreatorApp.Properties;

namespace SolutionCreatorApp
{
    public partial class App : Form
    {
        private readonly Dictionary<Page, Form> _pages = new();

        public App()
        {
            InitializeComponent();

            // Settings
            Constants.Instance.MainApp = this;
            this.Text = $"SolutionCreator - v{Assembly.GetEntryAssembly().GetName().Version}";

            // Download Templates
            LoadTemplates();

            // Create the pages...
            this.DefaultPage = Page.SolutionCreator;
            this._pages.Add(Page.SolutionCreator, new Pages.SolutionCreator());
        }

        private Page CurrentPage { get; set; } = Page.None;

        private Page DefaultPage { get; }

        public event TemplateRefreshEvent TemplatesRefreshed;

        private void App_Load(object sender, EventArgs e)
        {
            foreach (var page in this._pages)
            {
                page.Value.MdiParent = this;
                page.Value.Dock = DockStyle.Fill;
            }

            ChangePage(this.DefaultPage);
        }

        public void UpdateTemplatesText(string text)
        {
            this.templates_txt.Text = text;
        }

        public void UpdateStatusText(string text)
        {
            this.status_txt.Text = text;
        }

        private void ChangePage(Page newPage)
        {
            if (this.CurrentPage != Page.None)
            {
                this._pages[this.CurrentPage].Close();
            }

            this._pages[newPage].Show();
            this.CurrentPage = newPage;
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var abt = new About();
            abt.ShowDialog();
        }

        private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUrl(Constants.IssueAndFeatureRequestPage, $"Please go to {Constants.IssueAndFeatureRequestPage} to file a bug or request a new feature!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var latestReleaseTask = Constants.Instance.GitClient.Repository.Release.GetLatest(Constants.GithubOwner, Constants.GithubRepo);
            if (latestReleaseTask.Wait(10000))
            {
                var result = latestReleaseTask.Result;
                if (Version.TryParse(result.Name, out var latestVersion))
                {
                    if (latestVersion > Assembly.GetEntryAssembly().GetName().Version)
                    {
                        OpenUrl(Constants.NewVersionPage, $"Please go to {Constants.NewVersionPage} to download the latest version!");
                    }
                    else
                    {
                        Interaction.MsgBox("You are running the latest version!");
                    }
                }
                else
                {
                    Interaction.MsgBox($"Latest version can't be parsed, please go to {Constants.NewVersionPage} to check the version!", MsgBoxStyle.Critical);
                }
            }
            else
            {
                Interaction.MsgBox("Timed out while trying to get latest release!", MsgBoxStyle.Critical);
            }
        }

        private void OpenUrl(string url, string errorMessage)
        {
            try
            {
                var ps = new ProcessStartInfo(url) {UseShellExecute = true, Verb = "open"};
                Process.Start(ps);
            }
            catch
            {
                Interaction.MsgBox(errorMessage);
            }
        }

        private void setAccessTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var token = Interaction.InputBox("GIT Username?", "GIT Username");
            if (string.IsNullOrWhiteSpace(token))
            {
                Settings.Default.User = token;
            }
        }

        private void clearAccessTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.User = string.Empty;
            Settings.Default.Password = string.Empty;
        }

        private void setPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var token = Interaction.InputBox("GIT Password?", "GIT Password");
            if (string.IsNullOrWhiteSpace(token))
            {
                Settings.Default.Password = token;
            }
        }

        private void checkForUpdatesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadTemplates();
        }

        public void LoadTemplates()
        {
            try
            {
                UpdateStatusText("Checking for new/updated templates...");
                var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "TEMPLATES");
                var path = Path.Combine(rootPath, "templates.json");
                var remoteInfo = TemplateRepository.GetTemplatesInfo(Constants.Instance.GitClient);
                var localInfo = TemplateRepository.LoadLocalTemplateInfo(path);

                var (templatesToDownload, safeLocalTemplates) = TemplateRepository.GetTemplatesToDownload(localInfo, remoteInfo);

                // download templates
                for (var i = 0; i < templatesToDownload.Count; i++)
                {
                    UpdateStatusText($"Downloading template {i + 1}/{templatesToDownload.Count}: {templatesToDownload[i].Item1.Name}");
                    var template = templatesToDownload[i].Item1;
                    var name = Path.GetFileName(template.File);
                    var localPath = Path.Combine(rootPath, name);

                    if (templatesToDownload[i].Item2 && File.Exists(localPath))
                    {
                        File.Delete(localPath);
                    }

                    TemplateRepository.DownloadTemplate(Constants.Instance.GitClient, template.File, localPath);

                    safeLocalTemplates.Add(template);
                }

                File.WriteAllText(path, JsonConvert.SerializeObject(safeLocalTemplates));
                UpdateStatusText("Downloaded templates!");
                this.TemplatesRefreshed?.Invoke();
            }
            catch (Exception ex)
            {
                Interaction.MsgBox($"Unable to pull latest templates! {ex}");
                UpdateStatusText("Unable to pull latest templates!");
            }
        }
    }
}
