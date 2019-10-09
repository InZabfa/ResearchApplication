using SharedObjects.Authentication;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace KidsApp
{
    public partial class ResearcherLogin : ContentPage
    {
        public ResearcherLogin()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void ResearcherLoginAsync(object sender, EventArgs args)
        {
            Credentials c = new Credentials
            {
                email = txtEmail.Text,
                password = txtPassword.Text
            };

            Token token = await Handlers.ServerHandler.PostAsync<Token>(c, LoginFail, "KidsAppAPI/api/ResearcherLogin");
            if (token != null)
            {
                Data.LoggedInData loggedInData = new Data.LoggedInData();
                loggedInData.SetToken(token);
                loggedInData.SetUser(new SharedObjects.Accounts.User(token.UserID, txtEmail.Text));
                Application.Current.MainPage = new NavigationPage(new Forms.Home_Researcher.ResearcherNavigation(loggedInData));
            }
        }


        private void LoginFail(HttpResponseMessage x)
        {
            DisplayAlert("Login Fail", "Could not log you in, please check your credentials/ensure you attempt to log into the correct account type and try again.", "OK");
        }

        private void CreateResearcherAccountTapGesture_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateResearcherAccountForm());
        }
    }
}
