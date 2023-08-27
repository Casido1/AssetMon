using AssetMon.Shared.DTOs;

namespace AssetMon.Services.TemplateEngine
{
    public interface ITemplateEngine
    {
        Task<string> GenerateBodyHtml(string templateName, List<KeyValuePair<string, string>> keyValuePairs);
    }
}
