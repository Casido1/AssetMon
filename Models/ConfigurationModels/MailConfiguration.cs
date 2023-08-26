namespace AssetMon.Models.ConfigurationModels
{
    public class MailConfiguration
    {
        public string Section { get; set; } = "MailSettings";
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }
}
