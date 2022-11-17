using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

namespace SolutionCreator.Core
{
    public class TemplateGeneration
    {
        private static readonly string[] regexTags =
        {
            "Authors"
          , "Company"
          , "PackageTags"
          , "Description"
          , "PackageLicenseExpression"
          , "Version"
          , "FileVersion"
          , "AssemblyVersion"
        };

        private static readonly string[] replacementTags =
        {
            "Author"
          , "Company"
          , "tags"
          , "Description"
          , "License"
          , "Version"
          , "Version"
          , "Version"
        };

        private static readonly string[] outlawedDirectories =
        {
            "bin"
          , "obj"
          , ".vs"
          , ".git"
          , "fna"
          , "fnalibs"
          , "release"
        };

        private readonly string _outputPath;
        private readonly Dictionary<string, string> _projectNameReplacements;
        private readonly string _sourcePath;
        private readonly string _sourceSolutionPath;
        private readonly Template _template;

        public TemplateGeneration(Template templateInfo, string outputPath, Dictionary<string, string> projectNameReplacements, string sourcePath)
        {
            this._template = templateInfo;
            this._outputPath = outputPath;
            this._projectNameReplacements = projectNameReplacements;
            this._sourceSolutionPath = sourcePath;
            this._sourcePath = Path.GetDirectoryName(sourcePath);
        }

        public void GenerateTemplate(bool deleteWorkingDirectory)
        {
            var actualPath = Path.GetFileName(this._outputPath) == this._template.Name ? this._outputPath : Path.Combine(this._outputPath, this._template.Name);

            // Step 1 - Create the output path if it doesn't exist...
            if (Directory.Exists(actualPath))
            {
                Directory.Delete(actualPath, true);
            }

            // Step 2 - Copy the old solution over...
            CopyDirectory(this._sourcePath, actualPath);

            // Step 3 - Create the TEMPLATE_INFO.txt file
            var templateInfoFile = Path.Combine(actualPath, "TEMPLATE_INFO.txt");
            if (File.Exists(templateInfoFile))
            {
                File.Delete(templateInfoFile);
            }

            var template = JsonConvert.SerializeObject(this._template, Formatting.Indented);
            File.WriteAllText(templateInfoFile, template);

            // Step 4 - Update the .SLN file...
            var solutionFile = Path.Combine(actualPath, Path.GetFileName(this._sourceSolutionPath));
            var guids = GetGuidsAndReplacements(solutionFile);
            var slnFile = File.ReadAllText(solutionFile);
            slnFile = Replace(slnFile, guids);

            File.WriteAllText(solutionFile, slnFile);

            // Step 5 - Update the .CSPROJ files...
            UpdateProjectFiles(actualPath, GetReplacements());

            // Step 6 - Archive the Directory and Delete the working directory
            var archivePath = Path.Combine(Path.GetDirectoryName(actualPath), $"{this._template.Name}.zip");
            if (File.Exists(archivePath))
            {
                File.Delete(archivePath);
            }

            ZipFile.CreateFromDirectory(actualPath, archivePath);
            if (deleteWorkingDirectory)
            {
                Directory.Delete(actualPath, true);
            }
        }

        private Dictionary<Regex, string> GetReplacements()
        {
            Dictionary<Regex, string> output = new();

            for (var i = 0; i < regexTags.Length; i++)
            {
                output.Add(new Regex($"<{regexTags[i]}>.*<\\/{regexTags[i]}>"), $"<{regexTags[i]}>[{replacementTags[i].ToUpperInvariant()}]</{regexTags[i]}>");
            }

            foreach (var pair in this._projectNameReplacements)
            {
                output.Add(new Regex(pair.Key), pair.Value);
            }

            return output;
        }

        private void UpdateProjectFiles(string directory, Dictionary<Regex, string> replacements)
        {
            // find and update csproj files
            var files = Directory.GetFiles(directory, "*.csproj");
            for (var i = 0; i < files.Length; i++)
            {
                var text = File.ReadAllLines(files[i]);
                File.WriteAllText(files[i], UpdateProjectFile(text, replacements));
            }

            // find and update shproj files
            files = Directory.GetFiles(directory, "*.shproj");
            for (var i = 0; i < files.Length; i++)
            {
                var text = File.ReadAllLines(files[i]);
                File.WriteAllText(files[i], UpdateProjectFile(text, replacements));
            }

            // find and update projitems files
            files = Directory.GetFiles(directory, "*.projitems");
            for (var i = 0; i < files.Length; i++)
            {
                var text = File.ReadAllLines(files[i]);
                File.WriteAllText(files[i], UpdateProjectFile(text, replacements));
            }

            // Update csproj files in sub-directories
            var directories = Directory.GetDirectories(directory);
            for (var i = 0; i < directories.Length; i++)
            {
                UpdateProjectFiles(directories[i], replacements);
            }
        }

        private string UpdateProjectFile(string[] fileText, Dictionary<Regex, string> replacements)
        {
            var output = new StringBuilder();

            for (var i = 0; i < fileText.Length; i++)
            {
                var text = fileText[i];
                foreach (var replacement in replacements)
                {
                    text = replacement.Key.Replace(text, replacement.Value);
                }

                output.AppendLine(text);
            }

            return output.ToString();
        }

        private Dictionary<string, string> GetGuidsAndReplacements(string solutionFile)
        {
            var guids = new Dictionary<string, string>();
            var lines = File.ReadAllLines(solutionFile);
            var padding = $"D{this._template.Guids.ToString().Length}";

            // get guids
            foreach (var line in lines)
            {
                if (line.StartsWith("Project(", StringComparison.InvariantCultureIgnoreCase))
                {
                    var splitByComma = line.Split(",");
                    var last = splitByComma[splitByComma.Length - 1];

                    var guid = last.Substring(3, last.Length - 5);
                    guids.Add(guid, $"GUID{guids.Count.ToString(padding)}");
                }
            }

            // add replacements
            foreach (var pair in this._projectNameReplacements)
            {
                guids.Add(pair.Key, pair.Value);
            }

            return guids;
        }

        private string Replace(string text, Dictionary<string, string> replacements)
        {
            foreach (var pair in replacements)
            {
                text = text.Replace(pair.Key, pair.Value);
            }

            return text;
        }

        private void CopyDirectory(string oldPath, string newPath)
        {
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            // Copy over items
            var files = Directory.GetFiles(oldPath);
            for (var i = 0; i < files.Length; i++)
            {
                var path = Path.Combine(newPath, Path.GetFileName(files[i]));
                File.Copy(files[i], path, true);
            }

            // Copy over sub-directories
            var directories = Directory.GetDirectories(oldPath);
            for (var i = 0; i < directories.Length; i++)
            {
                var dirName = Path.GetFileName(directories[i]);
                if (!outlawedDirectories.Contains(dirName.ToLowerInvariant()))
                {
                    var path = Path.Combine(newPath, dirName);
                    CopyDirectory(directories[i], path);
                }
            }
        }
    }
}
