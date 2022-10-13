using System.Text;

using Newtonsoft.Json;

using Octokit;

namespace SolutionCreator.Core
{
    public static class TemplateRepository
    {
        /// <summary>
        ///     Name of the templates repo.
        /// </summary>
        public static string TemplatesRepoName = "SolutionCreator-Templates";

        /// <summary>
        ///     Name of the templates owner.
        /// </summary>
        public static string TemplatesOwnerName = "vonderborch";

        /// <summary>
        ///     Gets templates information.
        /// </summary>
        /// <param name="client">       The client. </param>
        /// <param name="repoName">     (Optional) Name of the repo. </param>
        /// <param name="repoOwner">    (Optional) The owner of the repo. </param>
        /// <returns>
        ///     The templates information.
        /// </returns>
        public static List<TemplatesInfo> GetTemplatesInfo(GitHubClient client, string repoName = "", string repoOwner = "")
        {
            List<TemplatesInfo> results = new();

            repoOwner = string.IsNullOrWhiteSpace(repoOwner) ? TemplatesOwnerName : repoOwner;
            repoName = string.IsNullOrWhiteSpace(repoName) ? TemplatesRepoName : repoName;

            var repoContentsTask = client.Repository.Content.GetRawContent(repoOwner, repoName, "./templates.json");
            repoContentsTask.Wait();

            var jsonRaw = Encoding.UTF8.GetString(repoContentsTask.Result);

            return JsonConvert.DeserializeObject<List<TemplatesInfo>>(jsonRaw) ?? new List<TemplatesInfo>();
        }

        /// <summary>
        ///     Downloads the template.
        /// </summary>
        /// <param name="client">       The client. </param>
        /// <param name="file">         The file. </param>
        /// <param name="path">         Full pathname of the file. </param>
        /// <param name="repoName">     (Optional) Name of the repo. </param>
        /// <param name="repoOwner">    (Optional) The owner of the repo. </param>
        public static void DownloadTemplate(GitHubClient client, string file, string path, string repoName = "", string repoOwner = "")
        {
            repoOwner = string.IsNullOrWhiteSpace(repoOwner) ? TemplatesOwnerName : repoOwner;
            repoName = string.IsNullOrWhiteSpace(repoName) ? TemplatesRepoName : repoName;

            var repoContentsTask = client.Repository.Content.GetRawContent(repoOwner, repoName, file);
            repoContentsTask.Wait();

            File.WriteAllBytes(path, repoContentsTask.Result);
        }

        /// <summary>
        ///     Loads local template information.
        /// </summary>
        /// <param name="file"> The file. </param>
        /// <returns>
        ///     The local template information.
        /// </returns>
        public static List<TemplatesInfo> LoadLocalTemplateInfo(string file)
        {
            if (File.Exists(file))
            {
                var fileContents = File.ReadAllText(file);

                return JsonConvert.DeserializeObject<List<TemplatesInfo>>(fileContents) ?? new List<TemplatesInfo>();
            }

            Directory.CreateDirectory(Path.GetDirectoryName(file));
            File.WriteAllText(file, "");

            return new List<TemplatesInfo>();
        }

        /// <summary>
        ///     Gets templates to download.
        /// </summary>
        /// <param name="local">    The local. </param>
        /// <param name="remote">   The remote. </param>
        /// <returns>
        ///     The templates to download.
        /// </returns>
        public static (List<Tuple<TemplatesInfo, bool>>, List<TemplatesInfo>) GetTemplatesToDownload(List<TemplatesInfo> local, List<TemplatesInfo> remote)
        {
            Dictionary<string, TemplatesInfo> localDict = new();
            for (var i = 0; i < local.Count; i++)
            {
                localDict.Add(local[i].Name.ToUpperInvariant(), local[i]);
            }

            Dictionary<string, TemplatesInfo> remoteDict = new();
            for (var i = 0; i < remote.Count; i++)
            {
                remoteDict.Add(remote[i].Name.ToUpperInvariant(), remote[i]);
            }

            List<Tuple<TemplatesInfo, bool>> templatesToDownload = new();
            List<string> updated = new();
            foreach (var template in remoteDict)
            {
                if (!localDict.ContainsKey(template.Key))
                {
                    templatesToDownload.Add(new Tuple<TemplatesInfo, bool>(template.Value, false));
                }
                else if (template.Value.Version != localDict[template.Key].Version)
                {
                    templatesToDownload.Add(new Tuple<TemplatesInfo, bool>(template.Value, true));
                    updated.Add(template.Key);
                }
            }

            List<TemplatesInfo> noUpdates = new();
            foreach (var template in localDict)
            {
                if (!updated.Contains(template.Key))
                {
                    noUpdates.Add(template.Value);
                }
            }

            return (templatesToDownload, noUpdates);
        }
    }
}
