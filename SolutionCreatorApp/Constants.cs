using Octokit;

namespace SolutionCreatorApp
{
    internal sealed class Constants
    {
        public static string AppHeaderName = "Solution-Creator";

        public static string GithubOwner = "vonderborch";

        public static string GithubRepo = "SolutionCreator";

        public static string IssueAndFeatureRequestPage = "https://www.github.com/vonderborch/SolutionCreator/issues/new";

        public static string NewVersionPage = "https://github.com/vonderborch/To-Do-List/releases";

        static Constants() { }

        private Constants() { }

        public static Constants Instance { get; } = new();

        public App MainApp { get; set; }

        public GitHubClient GitClient => new(new ProductHeaderValue(AppHeaderName));

        public static string CoreSpecialTextCurrentFullName => SolutionCreator.Core.Constants.SpecialTextCurrentFullName;

        public static string CoreSpecialTextParentDir => SolutionCreator.Core.Constants.SpecialTextParentDir;
    }
}
