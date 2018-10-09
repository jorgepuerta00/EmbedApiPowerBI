using System;
using System.Configuration;
using System.Threading.Tasks;
using EmbedPowerBI;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;

namespace EmbedPowerBI
{
    public class ClsEmbedPowerBI
    {
        public string GroupId { get; set; }
        public string ReportId { get; set; }
        public string DatasetId { get; set; }
        public string AccessLevel { get; set; }

        private string AuthorityUrl { get; set; }
        private string ResourceUrl { get; set; }
        private string ApiUrl { get; set; }
        private string Username { get; set; }
        
        private UserPasswordCredential Credential { get; set; }
        private AuthenticationResult AuthenticationResult { get; set; }
        private TokenCredentials TokenCredentials { get; set; }

        public ClsEmbedPowerBI() { }

        public ClsEmbedPowerBI(string groupId, string reportId, string datasetId, string accessLevel)
        {
            GroupId = groupId;
            ReportId = reportId;
            DatasetId = datasetId;
            AccessLevel = accessLevel;            
        }

        public string GetTokenAccess()
        {
            try
            {
                AuthorityUrl = ConfigurationManager.AppSettings["authorityUrl"];
                ResourceUrl = ConfigurationManager.AppSettings["resourceUrl"];
                ApiUrl = ConfigurationManager.AppSettings["apiUrl"];
                Username = ConfigurationManager.AppSettings["username"];

                // Create a user password cradentials.
                Credential = new UserPasswordCredential(Username, Secrets.Password);

                // Authenticate using created credentials
                Authorize().Wait();

                using (var client = new PowerBIClient(new Uri(ApiUrl), TokenCredentials))
                {

                    EmbedToken embedToken = client.Reports.GenerateTokenInGroup(groupId: GroupId, reportKey: ReportId, requestParameters: new GenerateTokenRequest(accessLevel: AccessLevel, datasetId: DatasetId));
                    return embedToken.Token;
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private Task Authorize()
        {
            return Task.Run(async () =>
            {
                AuthenticationResult = null;
                TokenCredentials = null;
                var authenticationContext = new AuthenticationContext(AuthorityUrl);

                AuthenticationResult = await authenticationContext.AcquireTokenAsync(ResourceUrl, Secrets.ClientID, Credential);

                if (AuthenticationResult != null)
                {
                    TokenCredentials = new TokenCredentials(AuthenticationResult.AccessToken, "Bearer");
                }
            });
        }
    }
}