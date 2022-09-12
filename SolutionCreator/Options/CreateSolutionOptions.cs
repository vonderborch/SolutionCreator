using CommandLine;

using SolutionCreator.Core;

namespace SolutionCreator.Options
{
    [Verb("new-solution", HelpText = "Create a solution from a template")]
    public class CreateSolutionOptions
    {
        [Option('t', "template", Required = true, HelpText = "The name of the template to use")]
        public string Template { get; set; }

        [Option('n', "name", Required = true, HelpText = "The name of the solution to create")]
        public string Name { get; set; }

        [Option('d', "directory", Required = true, HelpText = "The directory to place the solution in")]
        public string Directory { get; set; }

        [Option('a', "author", Required = false, HelpText = "The name of the author for the solution to use")]
        public string Author { get; set; }

        [Option('c', "company", Required = false, HelpText = "The name of the company for the solution to use")]
        public string Company { get; set; }

        [Option('v', "version", Required = false, HelpText = "The initial version number for the solution")]
        public string StartingVersion { get; set; }

        [Option("nuget-description", Required = false, HelpText = "The description of the solution using nuget")]
        public string NugetDescription { get; set; }

        [Option("nuget-license", Required = false, HelpText = "The license tag for the solution")]
        public string NugetLicense { get; set; }

        [Option("nuget-tags", Required = false, HelpText = "nuget search tags for the solution")]
        public string NugetTags { get; set; }

        [Option("file-conflicts", Required = false, Default = FileConflictMode.Override, HelpText = "What to do in the event of file conflicts occurring")]
        public FileConflictMode ConflictMode { get; set; }

        [Option("git-mode", Required = false, HelpText = "Settings for handling creating, or not, a git repo for the solution")]
        public GitRepoMode? GitRepoMode { get; set; }

        [Option("git-repo-name", Required = false, HelpText = "The name of the repo for the solution")]
        public string GitRepoName { get; set; }

        [Option("git-is-private", Required = false, HelpText = "Whether a private git repo will be created or not")]
        public bool? IsPrivateGitRepo { get; set; }

        [Option('m', "templates-directory", Default = "TEMPLATES", Required = false, HelpText = "The (relative) directory to use to search for templates in")]
        public string TemplatesDirectory { get; set; }

        [Option('s', "silent", Required = false, Default = false, HelpText = "Whether to ask prompts for missing info (false) or not (true)")]
        public bool Silent { get; set; }
    }
}
