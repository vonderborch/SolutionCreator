namespace SolutionCreator.Core
{
    public class SolutionSettings
    {
        public string Author;
        public string CompanyName;
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
        }
    }
}
