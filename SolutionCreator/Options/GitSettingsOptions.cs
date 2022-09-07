using CommandLine;

namespace SolutionCreator.Options
{
    [Verb("git-settings", HelpText = "Settings for Git")]
    public class GitSettingsOptions
    {
        [Value(0, MetaName = "git-username", Required = true, HelpText = "Your Github Username")]
        public string GitUsername { get; set; }

        [Value(1, MetaName = "git-password", Required = true, HelpText = "Your Github Password")]
        public string GitPassword { get; set; }
    }
}
