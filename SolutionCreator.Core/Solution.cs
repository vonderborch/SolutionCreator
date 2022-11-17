using System.Diagnostics;
using System.Text;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

using Octokit;

using Repository = LibGit2Sharp.Repository;

namespace SolutionCreator.Core
{
    public class Solution
    {
        private static readonly List<string> ExcludedFiles = new() {"TEMPLATE_INFO.txt", "SolutionBackup.sln"};
        private readonly Func<string, bool> _commandsOutputMethod;
        private readonly Func<string, bool> _instructionsOutputMethod;
        private readonly Func<string, bool> _outputMethod;
        private readonly Dictionary<string, string> _replacementText;
        private readonly SolutionSettings _settings;
        private readonly Template _template;

        public Solution(Template template, SolutionSettings settings, Func<string, bool> outputMethod, Func<string, bool> instructionsOutputMethod, Func<string, bool> commandsOutputMethod)
        {
            this._template = template;
            this._settings = settings;
            this._outputMethod = outputMethod;
            this._instructionsOutputMethod = instructionsOutputMethod;
            this._commandsOutputMethod = commandsOutputMethod;

            this._replacementText = new Dictionary<string, string>();
            foreach (var pair in template.ReplaceText)
            {
                this._replacementText.Add(pair.Key, pair.Value.Replace(Constants.SpecialTextParentDir, settings.RootDirectory).Replace(Constants.SpecialTextProjectName, settings.SolutionName));
            }

            this._replacementText.Add("[AUTHOR]", settings.Author);
            this._replacementText.Add("[COMPANY]", settings.CompanyName);
            this._replacementText.Add("[VERSION]", settings.StartingVersion);
            this._replacementText.Add("[SOLUTIONNAME]", settings.SolutionName);
            this._replacementText.Add("[DESCRIPTION]", settings.NugetPackageDescription);
            this._replacementText.Add("[LICENSE]", settings.NugetPackageLicenseType);
            this._replacementText.Add("[TAGS]", settings.NugetPackageTags);

            var padding = $"D{template.Guids.ToString().Length}";
            for (var i = 1; i <= template.Guids; i++)
            {
                this._replacementText.Add($"GUID{i.ToString(padding)}", Guid.NewGuid().ToString());
            }
        }

        public string SolutionDirectory => Path.Combine(this._settings.RootDirectory, this._settings.SolutionName);

        public bool ValidateSettings(out string[] errors)
        {
            var actualErrors = new List<string>();

            // Git Validations
            if (this._settings.GitSettings.RepoMode != GitRepoMode.NoRepo)
            {
                if (string.IsNullOrWhiteSpace(this._settings.GitSettings.RepoName))
                {
                    actualErrors.Add("Git Repo Name must be configured!");
                }

                if (string.IsNullOrWhiteSpace(this._settings.GitSettings.Username) || string.IsNullOrWhiteSpace(this._settings.GitSettings.Password))
                {
                    actualErrors.Add("Git username/password must be configured!");
                }
            }

            // TODO: come up with more validations :)

            errors = actualErrors.ToArray();

            return actualErrors.Count == 0;
        }

        public void Log(string value)
        {
            this._outputMethod(value);
        }

        public void GenerateSolution()
        {
            try
            {
                // Generate!
                GitHubClient client;
                var cmdStart = $"/C cd \"{this.SolutionDirectory}\"";

                // Step 1 - Git, Part 1
                if (this._settings.GitSettings.RepoMode != GitRepoMode.NoRepo)
                {
                    client = new GitHubClient(new ProductHeaderValue("Solution-Creator")) {Credentials = this._settings.GitSettings.Credentials};
                    var gitUrl = $"https://github.com/{this._settings.GitSettings.Username}/{this._settings.GitSettings.RepoName}.git";

                    if (this._settings.GitSettings.RepoMode == GitRepoMode.NewRepoOnlyInit)
                    {
                        Directory.CreateDirectory(this.SolutionDirectory);
                        Repository.Init(this.SolutionDirectory);
                    }
                    else if (this._settings.GitSettings.RepoMode == GitRepoMode.NewRepoFull)
                    {
                        var repository = new NewRepository(this._settings.GitSettings.RepoName)
                                         {
                                             AutoInit = false, Description = this._settings.NugetPackageDescription, LicenseTemplate = this._settings.NugetPackageLicenseType, Private = this._settings.GitSettings.IsPrivate
                                         };

                        var context = client.Repository.Create(repository);
                        Repository.Clone(gitUrl, Path.GetDirectoryName(this.SolutionDirectory));
                    }
                    else if (this._settings.GitSettings.RepoMode == GitRepoMode.ExistingRepoCleanSlate)
                    {
                        Repository.Clone(gitUrl, this.SolutionDirectory);
                        DeleteDirectoryExcludeGit(this.SolutionDirectory);
                    }
                    else if (this._settings.GitSettings.RepoMode == GitRepoMode.ExistingRepoKeepExistingCode)
                    {
                        Repository.Clone(gitUrl, Path.GetDirectoryName(this.SolutionDirectory));
                    }
                }

                // Step 2 - Unzip the template
                Log("Extracting template...");
                UnzipDirectory(this._settings.FileConflictMode);

                // Step 3 - Update naming of directories and files (and update the contents of the files!)
                Log("Updating template naming...");
                UpdateDirectory(this.SolutionDirectory, this._settings.FileConflictMode);

                // Step 4 - Run commands, if possible
                Log("Running commands...");
                var addCommandsToInstructions = false;
                if (this._template.Commands.Count == 0)
                {
                    Log("No commands to run!");
                    this._commandsOutputMethod("N/A");
                }
                else
                {
                    if (!this._template.CommandsRequireGit || (this._template.CommandsRequireGit && Directory.Exists(Path.Combine(this.SolutionDirectory, ".git"))))
                    {
                        for (var i = 0; i < this._template.Commands.Count; i++)
                        {
                            var cmd = Process.Start(Constants.CommandPrompt, $"{cmdStart} & {this._template.Commands[i]}");
                            cmd.WaitForExit();
                        }
                    }
                    else
                    {
                        addCommandsToInstructions = true;
                        Log("Unable to run commands, git is not enabled in the solution's directory!");
                    }
                }

                // Step 5 - Cleanup after ourselves
                Log("Cleaning up...");
                for (var i = 0; i < this._template.CleanupDirectories.Count; i++)
                {
                    Directory.Delete(this._template.CleanupDirectories[i], true);
                }

                // Step 6 - Display Instructions
                Log("Formatting manual instructions for output...");
                var instructions = new StringBuilder();

                if (this._template.Instructions.Count == 0 && !addCommandsToInstructions)
                {
                    instructions.AppendLine("N/A");
                }
                else
                {
                    foreach (var instruction in this._template.Instructions)
                    {
                        instructions.AppendLine(instruction);
                    }
                }

                if (addCommandsToInstructions)
                {
                    instructions.AppendLine("Please execute the following commands once git has been enabled in the repo:");

                    var commandOutput = new StringBuilder();
                    foreach (var command in this._template.Commands)
                    {
                        commandOutput.AppendLine(command);
                    }

                    commandOutput.AppendLine("");
                    this._commandsOutputMethod(commandOutput.ToString());
                }

                this._instructionsOutputMethod(instructions.ToString());

                // Done!
                Log("Solution generated!");
            }
            catch (Exception ex)
            {
                Log("Failed to generate solution!");
                Log(ex.ToString());
            }
        }

        private void DeleteDirectoryExcludeGit(string directory)
        {
            foreach (var file in Directory.GetFiles(directory))
            {
                File.Delete(file);
            }

            foreach (var dir in Directory.GetDirectories(directory))
            {
                if (Path.GetFileNameWithoutExtension(dir) != ".git")
                {
                    DeleteDirectoryExcludeGit(dir);
                }
            }
        }

        private void UnzipDirectory(FileConflictMode fileConflictMode)
        {
            var archivePath = this._template.FilePath;
            var outputDirectory = this.SolutionDirectory;

            using (var file = File.OpenRead(archivePath))
            {
                using (var zip = new ZipFile(file))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        try
                        {
                            var path = Path.Combine(outputDirectory, entry.Name.Replace("/", "\\"));
                            var directoryPath = Path.GetDirectoryName(path);
                            if (!string.IsNullOrWhiteSpace(path))
                            {
                                if (entry.IsDirectory)
                                {
                                    Directory.CreateDirectory(path);
                                }
                                else
                                {
                                    if (ExcludedFiles.Contains(Path.GetFileName(entry.Name)))
                                    {
                                        continue;
                                    }

                                    if (directoryPath is {Length: > 0})
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    var buffer = new byte[4096];
                                    if (File.Exists(path))
                                    {
                                        switch (fileConflictMode)
                                        {
                                            case FileConflictMode.Override:
                                                File.Delete(path);

                                                break;

                                            case FileConflictMode.KeepOld:
                                                continue;
                                        }
                                    }

                                    if (File.Exists(path))
                                    {
                                        File.Delete(path);
                                    }

                                    using (var inputStream = zip.GetInputStream(entry))
                                    {
                                        using (var output = File.Create(path))
                                        {
                                            StreamUtils.Copy(inputStream, output, buffer);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
        }

        private void UpdateDirectory(string directory, FileConflictMode fileConflictMode)
        {
            var entries = Directory.GetFileSystemEntries(directory);
            foreach (var entry in entries)
            {
                if (this._template.ExcludedDirectories.Contains(Path.GetFileName(entry)))
                {
                    continue;
                }

                var newEntryPath = UpdateText(entry);

                if (Directory.Exists(entry))
                {
                    var path = entry;
                    if (entry != newEntryPath)
                    {
                        Directory.Move(entry, newEntryPath);
                        path = newEntryPath;
                    }

                    if (!this._template.RenameOnlyDirectories.Contains(Path.GetFileName(entry)))
                    {
                        UpdateDirectory(path, fileConflictMode);
                    }
                }
                else
                {
                    if (entry != newEntryPath)
                    {
                        if (File.Exists(newEntryPath))
                        {
                            switch (fileConflictMode)
                            {
                                case FileConflictMode.Override:
                                    File.Delete(newEntryPath);

                                    break;

                                case FileConflictMode.KeepOld:
                                    continue;
                            }
                        }

                        File.Move(entry, newEntryPath);
                    }

                    var text = File.ReadAllText(newEntryPath);
                    if (!this._template.RenameOnlyFiles.Contains(entry))
                    {
                        text = UpdateText(text);
                    }

                    File.WriteAllText(newEntryPath, text);
                }
            }
        }

        public string UpdateText(string text)
        {
            foreach (var replacement in this._replacementText)
            {
                text = text.Replace(replacement.Key, replacement.Value);
            }

            return text;
        }
    }
}
