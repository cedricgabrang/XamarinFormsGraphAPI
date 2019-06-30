using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace XFormsGraphAPI
{
    public class AuthenticationHelper
    {
        public static string TokenForUser = null;
        public static DateTimeOffset expiration;

        private static GraphServiceClient graphClient = null;

        public static GraphServiceClient GetAuthenticatedClient()
        {
            if (graphClient == null)
            {
                try
                {
                    graphClient = new GraphServiceClient(
                        "https://graph.microsoft.com/v1.0",
                        new DelegateAuthenticationProvider(
                        async (requestMessage) =>
                        {
                                var token = await GetTokenForUserAsync();
                                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                        }));

                    return graphClient;
                }

                catch (Exception ex)
                {
                    Debug.WriteLine("Could not create a graph client: " + ex.Message);
                }
            }

            return graphClient;
        }

        public static async Task<string> GetTokenForUserAsync()
        {
            if (TokenForUser == null)
            {
                AuthenticationResult authResult = await App.IdentityClientApp.AcquireTokenAsync(App.Scopes, App.UiParent);

                TokenForUser = authResult.AccessToken;
                expiration = authResult.ExpiresOn;
            }

            return TokenForUser;
        }
    }
}
