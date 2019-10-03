using System.Configuration;

namespace EmbedPowerBI
{
    public class Secrets
    {
        public static string Password = ConfigurationManager.AppSettings["Password"];
        public static string ClientID = ConfigurationManager.AppSettings["ClientID"];
    }
}