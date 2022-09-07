using CommandLine;

namespace SolutionCreator.Options
{
    [Verb("list-templates", HelpText = "Lists the available templates")]
    public class ListAvailableTemplates
    {
        [Option('s', "templates-directory", Default = "TEMPLATES", Required = false, HelpText = "The (relative) directory to use to search for templates in")]
        public string TemplatesDirectory { get; set; }
    }
}
