namespace SolutionCreator.Core
{
    public class SolutionSettings
    {
        public string Author;
        public string CompanyName;

        public FileConflictMode FileConflictMode;
        public GitSettings GitSettings;
        public string NugetPackageDescription;
        public string NugetPackageLicenseType;
        public string NugetPackageTags;
        public string RootDirectory;
        public string SolutionName;
        public string StartingVersion;

        public SolutionSettings(
            string author
          , string companyName
          , string solutionName
          , string rootDirectory
          , string startingVersion
          , string nugetPackageDescription
          , string nugetLicenseType
          , string nugetPackageTags
          , FileConflictMode fileMode
          , GitSettings gitSettings
        )
        {
            this.Author = author;
            this.CompanyName = companyName;
            this.SolutionName = solutionName;
            this.RootDirectory = rootDirectory;
            this.StartingVersion = startingVersion;
            this.NugetPackageDescription = nugetPackageDescription;
            this.NugetPackageLicenseType = nugetLicenseType;
            this.NugetPackageTags = nugetPackageTags;
            this.GitSettings = gitSettings;
            this.FileConflictMode = fileMode;
        }
    }
}
