using Microsoft.Identity.Client;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFormsGraphAPI
{
    public partial class App : Application
    {

        
        public static string ClientID = "9aa5b306-d31c-4428-b495-f54383e771cc";
        public static PublicClientApplication IdentityClientApp = null;
        public static string[] Scopes = { "User.Read", "User.ReadWrite", "User.ReadBasic.All" };
        public static UIParent UiParent = null;

        public App()
        {
            InitializeComponent();
            IdentityClientApp = new PublicClientApplication(ClientID);
            MainPage = new LoginPage();
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
