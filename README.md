# SolutionCreator
Wanting to make a template from a project but frustrated at Visual Studio for making creating templates from complex solutions complicated (especially once you start trying to add custom logic to things...)? So was I. This isn't a perfect solution, but it at least makes things easier!

# Download
The latest release is available on the releases page: https://github.com/vonderborch/SolutionCreator/releases/latest

# Execution
One means of running this program are currently available:
[Full documentation will be available eventually :)](https://github.com/vonderborch/SolutionCreator/issues/3)

## App
Start up the executable and walk through the UI to create a solution. 

## Command Prompt/Terminal Version
- Creating a new Solution: `./SolutionCreator.exe new-solution`
    - Available Parameters: `./SolutionCreator.exe help new-solution`
- List Available Templates: `./SolutionCreator.exe list-templates`
    - Available Parameters: `./SolutionCreator.exe help -templates`
- Update or Download New Templates: `./SolutionCreator.exe update-templates`
    - Available Parameters: `./SolutionCreator.exe help update-templates`
- Update/set Git Settings: `./SolutionCreator.exe git-settings myusername mypassword`
    - Available Parameters: `./SolutionCreator.exe help git-settings`
    - NOTE: Right now the code saves this data in a plaintext. This is not good, but [at some point I hope to rework it to be better](https://github.com/vonderborch/SolutionCreator/issues/12).
- Check for App Updates: `./SolutionCreator.exe update`
    - Available Parameters: `./SolutionCreator.exe help update`
- Report an Issue: `./SolutionCreator.exe report-issue`
    - Available Parameters: `./SolutionCreator.exe help report-issue`
- Get Help: `./SolutionCreator.exe help`
- Display Current Version: `./SolutionCreator.exe version`

# Existing Templates
The application will automatically download templates from the [Template Repository](https://github.com/vonderborch/SolutionCreator-Templates). Currently available templates are:
- Velentr.BASE: A simple library that isn't tied to anything XNA related
- Velentr.BASE_DUAL_SUPPORT: A library that has two different implementations: one for FNA and one for Monogame
- Velentr.GENERIC_DUAL_SUPPORT: A library that has one generic implementation (not tied to FNA or Monogame) and then either extensions or custom implementations for FNA and Monogame

# Creating a New Template
[Built-in Coming Soon!](https://github.com/vonderborch/SolutionCreator/issues/7)

For now take a look at how the existing templates are structured (these were functional libraries originally with pretty much everything stripped and then lots of changes in the .csproj and .sln files!)

# Known Issues
- Brittle, not a lot of validation checking means it can crash easily and won't tell you what went wrong too well...

Have an issue? https://github.com/vonderborch/SolutionCreator/issues

# Future Plans
See list of issues under the Milestones: https://github.com/vonderborch/SolutionCreator/milestones
