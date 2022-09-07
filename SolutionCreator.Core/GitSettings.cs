using Octokit;

namespace SolutionCreator.Core
{
    public struct GitSettings
    {
        public string RepoName;

        public string RepoOwner;

        public string Username;

        public string Password;

        public GitRepoMode RepoMode;

        public Credentials Credentials;

        public bool IsPrivate;

        public GitSettings(
            string name
          , string owner
          , string user
          , string password
          , bool isPrivate
          , GitRepoMode mode
        )
        {
            this.RepoName = name;
            this.RepoOwner = owner;
            this.Username = user;
            this.Password = password;
            this.IsPrivate = isPrivate;
            this.RepoMode = mode;

            if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(password))
            {
                this.Credentials = new Credentials(user, password);
            }
            else
            {
                this.Credentials = new Credentials("");
            }
        }
    }
}
