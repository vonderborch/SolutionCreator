using System.Diagnostics;
using System.Reflection;

using Microsoft.VisualBasic;

using SolutionCreatorApp.Pages;

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

            // Create the pages...
            this.DefaultPage = Page.SolutionCreator;
            this._pages.Add(Page.SolutionCreator, new Pages.SolutionCreator());
        }

        private Page CurrentPage { get; set; } = Page.None;

        private Page DefaultPage { get; }

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
    }
}
