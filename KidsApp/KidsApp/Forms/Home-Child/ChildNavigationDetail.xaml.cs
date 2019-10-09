using KidsApp.Data;
using KidsApp.Handlers;
using SharedObjects.EditExistingAccount;
using SharedObjects.Response;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Child
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildNavigationDetail : ContentPage
    {
        public ChildNavigationDetail()
        {
            InitializeComponent();
            BindingContext = this;
            NavigationPage.SetHasBackButton(this, false);
        }

        private readonly LoggedInData LoggedInData = null;
        public ChildNavigationDetail(LoggedInData data) : this()
        {
            LoggedInData = data;
            ReloadContentAsync();
            ChildInfoChangesDataForm.DataObject = new ChildAccountChanges(LoggedInData.GetUser().ID, LoggedInData.GetToken().TokenValue);
            ChildInfoChangesDataForm.AutoGeneratingDataFormItem += ChildInfoChangesDataForm_AutoGeneratingDataFormItem;
        }

        private void ChildInfoChangesDataForm_AutoGeneratingDataFormItem(object sender, Syncfusion.XForms.DataForm.AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormGroupItem != null)
                e.DataFormGroupItem.IsExpanded = false;
        }

        private async void ReloadContentAsync()
        {
            if (LoggedInData != null)
            {
                SharedObjects.Accounts.ChildUser response = await ServerHandler.PostAsync<SharedObjects.Accounts.ChildUser>(LoggedInData.GetToken(), FailedToRetrieve, "KidsAppAPI/api/ChildUser");

                if (response != null)
                {
                    lblFullName.Text = response.ChildName + " and " + response.ParentName + " " + response.LastName;
                    lblFullName.FontSize = 30.0;
                    lblEmail.Text = response.Email;
                }
            }
        }

        private void FailedToRetrieve(HttpResponseMessage obj) => DisplayAlert("Fail", obj.ReasonPhrase, "OK");


        private async void SaveChanges_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                if (ChildInfoChangesDataForm.Validate())
                {
                    Response response = await ServerHandler.PostAsync<Response>((ChildAccountChanges)ChildInfoChangesDataForm.DataObject, UpdateFailed, "KidsAppAPI/api/SaveChangesChildAccount");

                    if (response != null)
                    {
                        ChildAccountChanges obj = ((ChildAccountChanges)ChildInfoChangesDataForm.DataObject);
                        await DisplayAlert("Success", response.Message, "OK");
                        obj.Email = "";
                        obj.Password = "";
                        obj.ConfirmPassword = "";
                        ChildInfoChangesDataForm.UpdateEditor("Email");
                        ChildInfoChangesDataForm.UpdateEditor("Password");
                        ChildInfoChangesDataForm.UpdateEditor("ConfirmPassword");
                    }
                }
                else
                {
                    await DisplayAlert("Failed to Save Changes", "Try again next time", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.ToString(), "ok");
            }

        }
        private void UpdateFailed(HttpResponseMessage obj) => DisplayAlert("Oops", obj.ReasonPhrase, "OK");
    }
}