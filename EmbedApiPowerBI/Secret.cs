using System.Configuration;

namespace EmbedPowerBI
{
    public class Secrets
    {
        // Update Power BI Account Password
        public static string Password = ConfigurationManager.AppSettings["Password"];

        // The Azure AD App - Application ID/Client ID
        public static string ClientID = ConfigurationManager.AppSettings["ClientID"];
    }
}