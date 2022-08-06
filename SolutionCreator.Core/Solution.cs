using System.Diagnostics;
using System.Text;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace SolutionCreator.Core
{
    public class Solution
    {
        private static readonly List<string> ExcludedFiles = new() {"TEMPLATE_INFO.txt", "SolutionBackup.sln"};
        private readonly Func<string, bool> _instructionsOutputMethod;
        private readonly Func<string, bool> _outputMethod;
        private readonly Dictionary<string, string> _replacementText;
        private readonly SolutionSettings _settings;
        private readonly Template _template;

        public Solution(Template template, SolutionSettings settings, Func<string, bool> outputMethod, Func<string, bool> instructionsOutputMethod)
        {
            this._template = template;
            this._settings = settings;
            this._outputMethod = outputMethod;
            this._instructionsOutputMethod = instructionsOutputMethod;

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
            errors = Array.Empty<string>();

            // TODO: come up with validations :)

            return true;
        }

        public void Log(string value)
        {
            this._outputMethod(value);
        }

        public void GenerateSolution()
        {
            // Generate!

            // Step 1 - Unzip the template
            Log("Extracting template...");
            UnzipDirectory();

            // Step 2 - Update naming of directories and files (and update the contents of the files!)
            Log("Updating template naming...");
            UpdateDirectory(this.SolutionDirectory);

            // Step 3 - Run commands, if possible
            Log("Running commands...");
            var addCommandsToInstructions = false;
            if (this._template.Commands.Count == 0)
            {
                Log("No commands to run!");
            }
            else
            {
                if (!this._template.CommandsRequireGit || (this._template.CommandsRequireGit && Directory.Exists(Path.Combine(this.SolutionDirectory, ".git"))))
                {
                    var cmdStart = $"/C cd \"{this.SolutionDirectory}\"";
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

            // Step 4 - Cleanup after ourselves
            Log("Cleaning up...");
            for (var i = 0; i < this._template.CleanupDirectories.Count; i++)
            {
                Directory.Delete(this._template.CleanupDirectories[i], true);
            }

            // Step 5 - Display Instructions
            Log("Formatting manual instructions for output...");
            var instructions = new StringBuilder();
            if (addCommandsToInstructions)
            {
                instructions.AppendLine("Please execute the following commands once git has been enabled in the repo:");

                foreach (var command in this._template.Commands)
                {
                    instructions.AppendLine(command);
                }

                instructions.AppendLine("");
            }

            foreach (var instruction in this._template.Instructions)
            {
                instructions.AppendLine(instruction);
            }

            this._instructionsOutputMethod(instructions.ToString());

            // Done!
            Log("Solution generated!");
        }

        private void UnzipDirectory()
        {
            var archivePath = this._template.FilePath;
            var outputDirectory = this.SolutionDirectory;

            using (var file = File.OpenRead(archivePath))
            {
                using (var zip = new ZipFile(file))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        var path = Path.Combine(outputDirectory, entry.Name.Substring(this._template.PathLength)).Replace("/", "\\");
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
                }
            }
        }

        private void UpdateDirectory(string directory)
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
                        UpdateDirectory(path);
                    }
                }
                else
                {
                    if (entry != newEntryPath)
                    {
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
