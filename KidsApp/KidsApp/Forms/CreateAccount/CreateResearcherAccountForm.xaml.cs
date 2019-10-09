using KidsApp.Handlers;
using SharedObjects.Accounts;
using SharedObjects.Authentication;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateResearcherAccountForm : ContentPage
    {
        public CreateResearcherAccountForm()
        {
            InitializeComponent();
            BindingContext = this;
            dataForm.DataObject = new ResearcherAccountDetails();
        }

        private async void BtnCreateResearcherAccount_Clicked(object sender, System.EventArgs e)
        {
            if (dataForm.Validate())
            {
                Token token = await ServerHandler.PostAsync<Token>((ResearcherAccountDetails)dataForm.DataObject, ResearcherRegisterFailed, "KidsAppAPI/api/RegisterResearcher");

                if (token != null)
                {
                    Data.LoggedInData loggedInData = new Data.LoggedInData();
                    loggedInData.SetToken(token);
                    loggedInData.SetUser(new User(token.UserID, ((ResearcherAccountDetails)dataForm.DataObject).Email));
                    Application.Current.MainPage = new NavigationPage(new Forms.Home_Researcher.ResearcherNavigation(loggedInData));
                }
            }
            else
            {
                await DisplayAlert("Failed to Create an Account", "This account already exists or you have not completed all of the fields", "OK");
            }
        }

        private void ResearcherRegisterFailed(HttpResponseMessage obj)
        {
            DisplayAlert("Account creation failed", "Please try again", "OK");
        }

        private void DataForm_Validating(object sender, Syncfusion.XForms.DataForm.ValidatingEventArgs e)
        {

        }
    }
}