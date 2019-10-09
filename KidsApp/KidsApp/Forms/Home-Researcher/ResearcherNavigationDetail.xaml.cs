using KidsApp.Data;
using KidsApp.Handlers;
using SharedObjects.EditExistingAccount;
using SharedObjects.Response;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResearcherNavigationDetail : ContentPage
    {
        public ResearcherNavigationDetail()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = this;
        }

        private readonly LoggedInData LoggedInData = null;
        public ResearcherNavigationDetail(LoggedInData data) : this()
        {
            LoggedInData = data;
            ReloadContentAsync();
            ResearcherChangesDataForm.DataObject = new ResearcherAccountChanges(LoggedInData.GetUser().ID, LoggedInData.GetToken().TokenValue);
            ResearcherChangesDataForm.AutoGeneratingDataFormItem += ResearcherChangesDataForm_AutoGeneratingDataFormItem;
        }

        private void ResearcherChangesDataForm_AutoGeneratingDataFormItem(object sender, Syncfusion.XForms.DataForm.AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormGroupItem != null)
                e.DataFormGroupItem.IsExpanded = false;
        }

        public async void ReloadContentAsync()
        {
            if (LoggedInData != null)
            {
                SharedObjects.Accounts.User response = await ServerHandler.PostAsync<SharedObjects.Accounts.User>(LoggedInData.GetToken(), FailedToRetrieve, "KidsAppAPI/api/User");

                if (response != null)
                {
                    lblFullName.Text = response.FirstName + " " + response.LastName;
                    lblFullName.FontSize = 30.0;
                    lblEmail.Text = response.Email;

                }
            }
        }

        private void FailedToRetrieve(HttpResponseMessage obj) => DisplayAlert("Fail", obj.ReasonPhrase, "OK");


        private async void SaveChanges_ClickedAsync(object sender, System.EventArgs e)
        {
            try
            {
                if (ResearcherChangesDataForm.Validate())
                {
                    Response response = await ServerHandler.PostAsync<Response>((ResearcherAccountChanges)ResearcherChangesDataForm.DataObject, UpdateFailed, "KidsAppAPI/api/SaveChangesResearcher");

                    if (response != null)
                    {
                        await DisplayAlert("Success", response.Message, "OK");
                        ResearcherAccountChanges obj = ((ResearcherAccountChanges)ResearcherChangesDataForm.DataObject);
                        obj.Email = "";
                        obj.Password = "";
                        obj.ConfirmPassword = "";
                        ResearcherChangesDataForm.UpdateEditor("Email");
                        ResearcherChangesDataForm.UpdateEditor("Password");
                        ResearcherChangesDataForm.UpdateEditor("ConfirmPassword");
                    }
                }
                else
                {
                    await DisplayAlert("Failed to Save Changes", "Try again next time", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Exception", ex.ToString(), "ok");
            }
        }

        private void UpdateFailed(HttpResponseMessage obj)
        {
            DisplayAlert("Oops", obj.ReasonPhrase, "OK");
        }

        private void DataForm_Validating(object sender, Syncfusion.XForms.DataForm.ValidatingEventArgs e)
        {

        }
    }
}
