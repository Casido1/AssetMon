namespace AssetMon.Services.TemplateEngine
{
    public class TemplateEngine : ITemplateEngine
    {
        private readonly string _searchPath;
        public TemplateEngine()
        {
            string currentDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;//Directory.GetCurrentDirectory();
            var newPath = Path.GetDirectoryName(currentDirectory);
            _searchPath = Path.Combine(newPath, "Templates");
        }

        private async Task<string> LoadTemplate(string templateName) 
        {
            string templatePath = Path.Combine(_searchPath, $"{templateName}.html");
            string template = await File.ReadAllTextAsync(templatePath);
            return template;
        }

        public async Task<string> GenerateBodyHtml(string templateName, List<KeyValuePair<string, string>> keyValuePairs)
        {
            var text = await LoadTemplate(templateName);

            if(!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach(var placeHolder in keyValuePairs)
                {
                    if(text.Contains(placeHolder.Key))
                    {
                        text = text.Replace(placeHolder.Key, placeHolder.Value);
                    }
                }
            }

            return text;
        }
    }
}
