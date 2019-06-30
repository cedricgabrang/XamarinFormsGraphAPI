using Microsoft.Identity.Client;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFormsGraphAPI
{
    public partial class App : Application
    {

        
        public static string ClientID = "[INSERT YOUR APPLICATION ID]";
        public static PublicClientApplication IdentityClientApp = null;
        public static string[] Scopes = { "User.Read", "User.ReadWrite", "User.ReadBasic.All" };
        public static UIParent UiParent = null;

        public App()
        {
            InitializeComponent();
            IdentityClientApp = new PublicClientApplication(ClientID);
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
