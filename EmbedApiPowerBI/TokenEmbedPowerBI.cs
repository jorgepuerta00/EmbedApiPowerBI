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
    public class TokenEmbedPowerBI
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

        public Token GetTokenAccess()
        {
            try
            {
                AuthorityUrl = ConfigurationManager.AppSettings["authorityUrl"];
                ResourceUrl = ConfigurationManager.AppSettings["resourceUrl"];
                ApiUrl = ConfigurationManager.AppSettings["apiUrl"];
                Username = ConfigurationManager.AppSettings["username"];

                Credential = new UserPasswordCredential(Username, Secrets.Password);
                Authorize().Wait();

                using (var client = new PowerBIClient(new Uri(ApiUrl), TokenCredentials))
                {

                    EmbedToken embedToken = client.Reports.GenerateTokenInGroup(groupId: GroupId, reportKey: ReportId, requestParameters: new GenerateTokenRequest(accessLevel: AccessLevel, datasetId: DatasetId));
                    Report report = client.Reports.GetReportInGroup(groupId: GroupId, reportKey: ReportId);

                    return new Token { EmbedUrl = report.EmbedUrl, EmbedToken = embedToken, Id = embedToken.TokenId };
                }
            }
            catch (Exception ex)
            {
                return new Token { ErrorMessage = ex.InnerException.ToString() };
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