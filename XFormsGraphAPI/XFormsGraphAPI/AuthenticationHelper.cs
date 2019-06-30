using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
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
                // Create Microsoft Graph client.
                try
                {
                    graphClient = new GraphServiceClient(
                        "https://graph.microsoft.com/v1.0",
                        new DelegateAuthenticationProvider(
                            async (requestMessage) =>
                            {
                                var token = "";

                                if (string.IsNullOrWhiteSpace(token))
                                {
                                    token = await GetTokenForUserAsync();
                                }


                                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);



                                // This header has been added to identify our sample in the Microsoft Graph service.  If extracting this code for your project please remove.
                                //requestMessage.Headers.Add("SampleID", "xamarin-csharp-connect-sample");

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
