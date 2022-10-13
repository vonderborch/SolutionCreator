using CommandLine;

namespace SolutionCreator.Options
{
    [Verb("update-templates", HelpText = "Downloads updates or new templates from the Template Repository")]
    public class DownloadUpdateTemplates
    {
        [Option('m', "templates-directory", Default = "TEMPLATES", Required = false, HelpText = "The (relative) directory to use to search for templates in")]
        public string TemplatesDirectory { get; set; }
    }
}
