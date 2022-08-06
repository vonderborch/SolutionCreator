# SolutionCreator
Wanting to make a template from a project but frustrated at Visual Studio for making creating templates from complex solutions complicated (especially once you start trying to add custom logic to things...)? So was I. This isn't a perfect solution, but it at least makes things easier!

# Download
The latest release is available on the releases page: https://github.com/vonderborch/SolutionCreator/releases/latest

# Execution
One means of running this program are currently available:

## App
Start up the executable and walk through the steps to create a solution

## Command Prompt/Terminal Version
Coming soon maybe?

# Existing Templates
I've created some templates that are packaged with the program. The three currently available were all meant to help me with standardizing repo structure with my Velentr.X libraries.
- Velentr.BASE: A simple library that isn't tied to anything XNA related
- Velentr.BASE_DUAL_SUPPORT: A library that has two different implementations: one for FNA and one for Monogame
- Velentr.GENERIC_DUAL_SUPPORT: A library that has one generic implementation (not tied to FNA or Monogame) and then either extensions or custom implementations for FNA and Monogame

# Creating a New Template
Coming Soon!

For now take a look at how the existing templates are structured (these were functional libraries originally with pretty much everything stripped and then lots of changes in the .csproj and .sln files!)

# Known Issues
- Brittle, not a lot of validation checking means it can crash easily and won't tell you what went wrong too well...

Have an issue? https://github.com/vonderborch/SolutionCreator/issues

# Future Plans
See list of issues under the Milestones: https://github.com/vonderborch/SolutionCreator/milestones