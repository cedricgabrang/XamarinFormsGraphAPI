using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsGraphAPI
{
    public partial class LoginPage : ContentPage
    {

        private static GraphServiceClient graphClient = null;
        private string _userDisplayName;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await CreateGraphClientAsync();

            }).ContinueWith(result => Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert("Welcome!", _userDisplayName, "CLOSE");
            }));
        }

        private async Task<bool> CreateGraphClientAsync()
        {
            try
            {

                var authenticationHelper = new AuthenticationHelper();
                graphClient = AuthenticationHelper.GetAuthenticatedClient();
                var currentUserObject = await graphClient.Me.Request().GetAsync();
                _userDisplayName = currentUserObject.GivenName;
                return true;
            }

            catch (MsalException ex)
            {
                return false;
            }
        }
    }
}
