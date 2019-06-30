using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsGraphAPI
{
    public partial class MainPage : ContentPage
    {

        private static GraphServiceClient graphClient = null;
        private string _userDisplayName;

        public MainPage()
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
                lblName.Text = _userDisplayName;
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


                //try
                //{
                //    var mailHelper = new MailHelper();
                //    Stream userPhotoStream = await mailHelper.GetCurrentUserPhotoStreamAsync();
                //    var photoStreamMS = new MemoryStream();
                //    userPhotoStream.CopyTo(photoStreamMS);
                //    _userProfilePhoto = Convert.ToBase64String(photoStreamMS.ToArray());
                //}

                //catch
                //{
                //    _userProfilePhoto = null;
                //}



                return true;

            }

            catch (MsalException ex)
            {
                return false;
            }

        }

    }
}
