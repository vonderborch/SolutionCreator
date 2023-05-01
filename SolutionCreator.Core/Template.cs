using System.Text;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

using Newtonsoft.Json;

namespace SolutionCreator.Core
{
    public class Template
    {
        public bool AskForNugetInfo = false;

        public List<string> CleanupDirectories = new();
        public List<string> Commands = new();

        public bool CommandsRequireGit = false;

        public string DefaultAuthor = string.Empty;      // Allowed Special Values: <CurrentFullName>
        public string DefaultCompanyName = string.Empty; // Allowed Special Values: <CurrentFullName>
        public string DefaultName = string.Empty;
        public string DefaultNameFormat = string.Empty; // Allowed Special Values: <CurrentFullName>, <ParentDir>

        public string DefaultNugetDescription = string.Empty;
        public string DefaultNugetLicense = string.Empty;
        public string DefaultNugetTags = string.Empty;

        public string Description = "No Description Provided";

        public List<string> ExcludedDirectories = new();

        public string FileName = string.Empty;
        public string FileNameNoExtension = string.Empty;
        public string FilePath = string.Empty;

        public int Guids = 0;
        public List<string> Instructions = new();

        public string Name = string.Empty;
        public int PathLength;

        public List<string> RenameOnlyDirectories = new();
        public List<string> RenameOnlyFiles = new();

        public Dictionary<string, string> ReplaceText = new();

        public string TemplateAuthor = "No Author Provided";

        public string TemplateVersion = string.Empty;

        public Template() { }

        public Template(string filePath)
        {
            this.FilePath = filePath;
            this.FileName = Path.GetFileName(filePath);
            this.FileNameNoExtension = Path.GetFileNameWithoutExtension(filePath);
            this.PathLength = this.FileNameNoExtension.Length + 1;

            this.ReplaceText = new Dictionary<string, string> {{this.FileNameNoExtension, Constants.SpecialTextProjectName}};

            // look for the TEMPLATE_INFO file for additional info, if available
            using (var file = File.OpenRead(filePath))
            {
                using (var zip = new ZipFile(file))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        if (Path.GetFileName(entry.Name).ToUpperInvariant() == Constants.TemplateInfoFileName.ToUpperInvariant())
                        {
                            var contents = "";
                            using (var inputStream = zip.GetInputStream(entry))
                            {
                                using (var output = new MemoryStream())
                                {
                                    var buffer = new byte[4096];
                                    StreamUtils.Copy(inputStream, output, buffer);
                                    contents = Encoding.UTF8.GetString(output.ToArray());
                                }
                            }

                            JsonConvert.PopulateObject(contents, this);
                            if (string.IsNullOrWhiteSpace(this.FilePath))
                            {
                                this.FilePath = filePath;
                                this.FileName = Path.GetFileName(filePath);
                                this.FileNameNoExtension = Path.GetFileNameWithoutExtension(filePath);
                                this.PathLength = this.FileNameNoExtension.Length + 1;
                            }

                            if (string.IsNullOrWhiteSpace(this.DefaultName))
                            {
                                this.DefaultName = this.Name;
                            }

                            if (!this.ReplaceText.ContainsKey(this.Name))
                            {
                                this.ReplaceText.Add(this.Name, Constants.SpecialTextProjectName);
                            }

                            if (!this.ReplaceText.ContainsKey(this.FileNameNoExtension))
                            {
                                this.ReplaceText.Add(this.FileNameNoExtension, Constants.SpecialTextProjectName);
                            }
                        }
                    }
                }
            }
        }

        public void PopulateFromTemplateInfoFile(string filePath)
        {
            JsonConvert.PopulateObject(File.ReadAllText(filePath), this);
            if (string.IsNullOrWhiteSpace(this.DefaultName))
            {
                this.DefaultName = this.Name;
            }

            if (!this.ReplaceText.ContainsKey(this.Name))
            {
                this.ReplaceText.Add(this.Name, Constants.SpecialTextProjectName);
            }
        }

        public string UpdateText(string text)
        {
            foreach (var replacement in this.ReplaceText)
            {
                text = text.Replace(replacement.Key, replacement.Value);
            }

            return text;
        }

        public override string ToString()
        {
            return $"{this.Name} - v{this.TemplateVersion}";
        }
    }
}
