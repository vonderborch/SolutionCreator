using System.Diagnostics;
using System.Reflection;
using System.Text;

using CommandLine;

using Octokit;

using SolutionCreator.Core;
using SolutionCreator.Helpers;
using SolutionCreator.Options;

namespace SolutionCreator
{
    public class Program
    {
        public static List<string> _instructions;
        public static List<string> _commands;

        public static void Main(string[] args)
        {
            args = new[] {"list-templates"};
            var parseResults = Parser.Default.ParseArguments<CreateSolutionOptions, ListAvailableTemplates, GitSettingsOptions, CheckForUpdatesOptions, ReportIssueOptions>(args);
            var texts = parseResults.MapResult(
                                               (CreateSolutionOptions opts) => CreateSolution(opts)
                                             , (ListAvailableTemplates opts) => ListTemplates(opts)
                                             , (GitSettingsOptions opts) => GitSettings(opts)
                                             , (CheckForUpdatesOptions opts) => CheckForUpdate(opts)
                                             , (ReportIssueOptions opts) => ReportIssue(opts)
                                             , _ => MakeError()
                                              );
        }

        public static string CreateSolution(CreateSolutionOptions opts)
        {
            var core = new Core.Core(opts.TemplatesDirectory);
            core.RefreshTemplatesList();

            if (core.Templates.ContainsKey(opts.Template))
            {
                var template = core.Templates[opts.Template];

                var gitUser = string.Empty;
                var gitPass = string.Empty;

                var settingsFile = Path.Combine(Directory.GetCurrentDirectory(), "settings.txt");
                if (File.Exists(settingsFile))
                {
                    var settingsFileSettings = File.ReadAllLines(settingsFile);
                    if (settingsFileSettings.Length == 2)
                    {
                        gitUser = settingsFileSettings[0];
                        gitPass = settingsFileSettings[1];
                    }
                }

                _instructions = new List<string>();
                _commands = new List<string>();

                var settings = new SolutionSettings(
                                                    GetActualValue(opts.Author, template.DefaultAuthor)
                                                  , GetActualValue(opts.Company, template.DefaultCompanyName)
                                                  , opts.Name
                                                  , opts.Directory
                                                  , GetActualValue(opts.StartingVersion, "1.0.0")
                                                  , GetActualValue(opts.NugetDescription, template.DefaultNugetDescription)
                                                  , GetActualValue(opts.NugetLicense, template.DefaultNugetLicense)
                                                  , GetActualValue(opts.NugetTags, template.DefaultNugetTags)
                                                  , opts.ConflictMode
                                                  , new GitSettings(
                                                                    opts.GitRepoName
                                                                  , gitUser
                                                                  , gitUser
                                                                  , gitPass
                                                                  , opts.IsPrivateGitRepo
                                                                  , opts.GitRepoMode
                                                                   )
                                                   );

                var solution = new Solution(template, settings, UpdateLog, UpdateInstructions, UpdateCommands);
                if (!solution.ValidateSettings(out var errors))
                {
                    // Validation errors!
                    var str = new StringBuilder();
                    Console.WriteLine("Validation Errors:");
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error);
                    }
                }
                else
                {
                    solution.GenerateSolution();

                    if (_instructions.Count > 0)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Manual Instructions:");
                        foreach (var line in _instructions)
                        {
                            Console.WriteLine(line);
                        }
                    }

                    if (_commands.Count > 0)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Manual Commands:");
                        foreach (var line in _commands)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("A template with that name could not be found!");
            }

            return string.Empty;
        }

        public static string GetActualValue(string option, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(option) ? defaultValue : option;
        }

        public static bool UpdateLog(string value)
        {
            Console.WriteLine(value);

            return true;
        }

        public static bool UpdateInstructions(string value)
        {
            _instructions.Add(value);

            return true;
        }

        public static bool UpdateCommands(string value)
        {
            _commands.Add(value);

            return true;
        }

        public static string ListTemplates(ListAvailableTemplates opts)
        {
            var core = new Core.Core(opts.TemplatesDirectory);
            core.RefreshTemplatesList();

            var rows = new List<List<string>>();
            foreach (var pair in core.Templates)
            {
                rows.Add(new List<string> {pair.Key, pair.Value.TemplateAuthor, pair.Value.TemplateVersion, pair.Value.Description});
            }

            var table = TableOutputHelpers.ConvertToTable(new List<string> {"Template Name", "Template Author", "Template Version", "Template Description"}, rows, 64);
            Console.WriteLine(table);

            return string.Empty;
        }

        public static string GitSettings(GitSettingsOptions opts)
        {
            var settingsFile = Path.Combine(Directory.GetCurrentDirectory(), "settings.txt");

            if (File.Exists(settingsFile))
            {
                File.Delete(settingsFile);
            }

            File.WriteAllLines(settingsFile, new List<string> {opts.GitUsername, opts.GitPassword});

            return string.Empty;
        }

        public static string CheckForUpdate(CheckForUpdatesOptions opts)
        {
            var client = new GitHubClient(new ProductHeaderValue("Solution-Creator"));
            var latestReleaseTask = client.Repository.Release.GetLatest("vonderborch", "SolutionCreator");
            if (latestReleaseTask.Wait(10000))
            {
                var result = latestReleaseTask.Result;
                if (Version.TryParse(result.Name, out var latestVersion))
                {
                    if (latestVersion > Assembly.GetEntryAssembly().GetName().Version)
                    {
                        OpenUrl("https://github.com/vonderborch/To-Do-List/releases", "Please go to https://github.com/vonderborch/To-Do-List/releases to download the latest version!");
                    }
                    else
                    {
                        Console.WriteLine("You are running the latest version!");
                    }
                }
                else
                {
                    Console.WriteLine("Latest version can't be parsed, please go to https://github.com/vonderborch/To-Do-List/releases to check the version!");
                }
            }
            else
            {
                Console.WriteLine("Timed out while trying to get latest release!");
            }

            return string.Empty;
        }

        public static string ReportIssue(ReportIssueOptions opts)
        {
            OpenUrl("https://www.github.com/vonderborch/SolutionCreator/issues/new", "Please go to https: //www.github.com/vonderborch/SolutionCreator/issues/new to file a bug or request a new feature!");

            return string.Empty;
        }

        public static string MakeError()
        {
            return "\0";
        }

        private static void OpenUrl(string url, string errorMessage)
        {
            try
            {
                var ps = new ProcessStartInfo(url) {UseShellExecute = true, Verb = "open"};
                Process.Start(ps);
            }
            catch (Exception ex)
            {
                Console.WriteLine(errorMessage);
            }
        }
    }
}
