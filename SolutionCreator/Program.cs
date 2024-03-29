﻿using System.Diagnostics;
using System.Reflection;
using System.Text;

using CommandLine;

using Newtonsoft.Json;

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
            args = new[] {"help", "new-solution"};
            var parseResults = Parser.Default.ParseArguments<CreateSolutionOptions, ListAvailableTemplates, GitSettingsOptions, CheckForUpdatesOptions, ReportIssueOptions>(args);
            var texts = parseResults.MapResult(
                                               (CreateSolutionOptions opts) => CreateSolution(opts)
                                             , (ListAvailableTemplates opts) => ListTemplates(opts)
                                             , (DownloadUpdateTemplates opts) => DownloadOrUpdateTemplates(opts)
                                             , (GitSettingsOptions opts) => GitSettings(opts)
                                             , (CheckForUpdatesOptions opts) => CheckForUpdate(opts)
                                             , (ReportIssueOptions opts) => ReportIssue(opts)
                                             , _ => MakeError()
                                              );
        }

        public static string CreateSolution(CreateSolutionOptions opts)
        {
            if (NeedsToDownloadTemplates(opts.TemplatesDirectory))
            {
                DownloadOrUpdateTemplates(new DownloadUpdateTemplates {TemplatesDirectory = opts.TemplatesDirectory});
            }

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

                if (opts.Silent)
                {
                    opts.Author = GetActualValue(opts.Author, template.DefaultAuthor);
                    opts.Company = GetActualValue(opts.Company, template.DefaultCompanyName);
                    opts.StartingVersion = GetActualValue(opts.StartingVersion, "1.0.0");

                    opts.NugetDescription = GetActualValue(opts.NugetDescription, template.DefaultNugetDescription);
                    opts.NugetLicense = GetActualValue(opts.NugetLicense, template.DefaultNugetLicense);
                    opts.NugetTags = GetActualValue(opts.NugetTags, template.DefaultNugetTags);

                    opts.GitRepoMode ??= GitRepoMode.NoRepo;
                    opts.GitRepoName = GetActualValue(opts.GitRepoName, string.Empty);
                    opts.IsPrivateGitRepo ??= false;
                }
                else
                {
                    opts.Author = AskActualValue("Author?", opts.Author, template.DefaultAuthor);
                    opts.Company = AskActualValue("Company Name?", opts.Company, template.DefaultCompanyName);
                    opts.StartingVersion = AskActualValue("Starting Version?", opts.StartingVersion, "1.0.0");

                    if (template.AskForNugetInfo)
                    {
                        opts.NugetDescription = AskActualValue("Nuget Description?", opts.NugetDescription, template.DefaultNugetDescription);
                        opts.NugetLicense = AskActualValue("Nuget License?", opts.NugetLicense, template.DefaultNugetLicense);
                        opts.NugetTags = AskActualValue("Nuget Tags?", opts.NugetTags, template.DefaultNugetTags);
                    }

                    if (opts.GitRepoMode is not GitRepoMode.NoRepo)
                    {
                        if (opts.GitRepoMode == null)
                        {
                            Console.WriteLine("Git Repo Mode?");
                            var validOptions = (from action in (GitRepoMode[]) Enum.GetValues(typeof(GitRepoMode)) select action.ToString()).ToList();
                            string? gitOption = null;
                            while (!validOptions.Contains(gitOption ?? string.Empty))
                            {
                                gitOption = Console.ReadLine();
                            }

                            if (Enum.TryParse(gitOption ?? string.Empty, out GitRepoMode opt))
                            {
                                opts.GitRepoMode = opt;
                            }
                        }

                        if (opts.GitRepoMode != GitRepoMode.NoRepo)
                        {
                            opts.GitRepoName = AskActualValue("Git Repo Name?", opts.GitRepoName, string.Empty);
                            opts.IsPrivateGitRepo = AskActualBoolean("Is Private Git Repo?", opts.IsPrivateGitRepo, false);
                        }
                    }
                }

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
                                                                  , opts.IsPrivateGitRepo ?? false
                                                                  , opts.GitRepoMode ?? GitRepoMode.NoRepo
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

        public static bool AskActualBoolean(string message, bool? option, bool defaultValue)
        {
            if (option == null)
            {
                Console.WriteLine($"{message} (Default: {defaultValue}) (Yy/Nn)");
                var validOptions = new List<string>
                                   {
                                       "Y"
                                     , "N"
                                     , "YES"
                                     , "NO"
                                     , "T"
                                     , "TRUE"
                                     , "F"
                                     , "FALSE"
                                     , ""
                                   };

                string? output = null;
                while (validOptions.Contains(output ?? string.Empty))
                {
                    output = Console.ReadLine();
                }

                switch ((output ?? string.Empty).ToUpperInvariant())
                {
                    case "":
                        return defaultValue;

                    case "Y":
                    case "YES":
                    case "T":
                    case "TRUE":
                        return true;

                    case "N":
                    case "NO":
                    case "F":
                    case "FALSE":
                        return false;
                }
            }

            return option ?? defaultValue;
        }

        public static string AskActualValue(string message, string option, string defaultValue)
        {
            if (string.IsNullOrWhiteSpace(option))
            {
                Console.WriteLine($"{message} (Default: {defaultValue})");

                return Console.ReadLine() ?? defaultValue;
            }

            return option;
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

        public static bool NeedsToDownloadTemplates(string templatesDirectory)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), templatesDirectory);
            if (!Directory.Exists(dir))
            {
                return true;
            }

            if (Directory.GetFiles(dir).Length == 0)
            {
                return true;
            }

            return false;
        }

        public static string DownloadOrUpdateTemplates(DownloadUpdateTemplates opts)
        {
            Console.WriteLine("Checking for new or updated templates at the template repository...");
            var gitClient = new GitHubClient(new ProductHeaderValue("Solution-Creator-CMD"));

            var rootPath = Path.Combine(Directory.GetCurrentDirectory(), opts.TemplatesDirectory);
            var path = Path.Combine(rootPath, "templates.json");
            var remoteInfo = TemplateRepository.GetTemplatesInfo(gitClient);
            var localInfo = TemplateRepository.LoadLocalTemplateInfo(path);

            var (templatesToDownload, safeLocalTemplates) = TemplateRepository.GetTemplatesToDownload(localInfo, remoteInfo);

            // download templates
            if (templatesToDownload.Count > 0)
            {
                for (var i = 0; i < templatesToDownload.Count; i++)
                {
                    Console.WriteLine($"Downloading template {i + 1}/{templatesToDownload.Count}: {templatesToDownload[i].Item1.Name}");
                    var template = templatesToDownload[i].Item1;
                    var name = Path.GetFileName(template.File);
                    var localPath = Path.Combine(rootPath, name);

                    if (templatesToDownload[i].Item2 && File.Exists(localPath))
                    {
                        File.Delete(localPath);
                    }

                    TemplateRepository.DownloadTemplate(gitClient, template.File, localPath);

                    safeLocalTemplates.Add(template);
                }

                File.WriteAllText(path, JsonConvert.SerializeObject(safeLocalTemplates));
                Console.WriteLine("Downloaded/Updated templates!");
            }
            else
            {
                Console.WriteLine("No templates to download/update!");
            }

            return string.Empty;
        }

        public static string ListTemplates(ListAvailableTemplates opts)
        {
            if (NeedsToDownloadTemplates(opts.TemplatesDirectory))
            {
                DownloadOrUpdateTemplates(new DownloadUpdateTemplates {TemplatesDirectory = opts.TemplatesDirectory});
            }

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
            Console.WriteLine("Checking for application updates...");

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
