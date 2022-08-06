namespace SolutionCreator.Core
{
    public class Core
    {
        public Dictionary<string, Template> Templates = new();

        public Core(string templatesDirectory = "TEMPLATES")
        {
            this.TemplatesPath = Path.Combine(Directory.GetCurrentDirectory(), templatesDirectory);
        }

        public string TemplatesPath { get; }

        public void RefreshTemplatesList()
        {
            this.Templates.Clear();
            foreach (var file in Directory.EnumerateFiles(this.TemplatesPath))
            {
                if (Path.GetExtension(file) == ".zip")
                {
                    var template = new Template(file);
                    this.Templates.Add(template.Name, template);
                }
            }
        }
    }
}
