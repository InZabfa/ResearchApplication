using SharedObjects.Authentication;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace KidsApp
{
    //  [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildLogin : ContentPage
    {
        public ChildLogin()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void ChildLoginAsync(object sender, EventArgs args)
        {
            Credentials c = new Credentials
            {
                email = emailtxt.Text,
                password = passwordtxt.Text
            };

            Token token = await Handlers.ServerHandler.PostAsync<Token>(c, LoginFail, "KidsAppAPI/api/ChildLogin");
            if (token != null)
            {
                Data.LoggedInData loggedInData = new Data.LoggedInData();
                loggedInData.SetToken(token);
                loggedInData.SetUser(new SharedObjects.Accounts.User(token.UserID, emailtxt.Text));
                Application.Current.MainPage = new NavigationPage(new Forms.Home_Child.ChildNavigation(loggedInData));
            }
        }

        private void LoginFail(HttpResponseMessage x)
        {
            DisplayAlert("Login Fail", "Could not log you in, please check your credentials and try again.", "OK");
        }
    }
}