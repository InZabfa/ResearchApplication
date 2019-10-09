using KidsApp.Data;
using KidsApp.Handlers;
using SharedObjects.Accounts;
using SharedObjects.Response;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddParticipant : ContentPage
    {
        public LoggedInData LoggedInData { get; set; }


        public AddParticipant()
        {
            InitializeComponent();
            BindingContext = this;
            AddParticipantDataForm.DataObject = new CreateParticipantAccount();
        }

        public AddParticipant(LoggedInData data) : this()
        {
            LoggedInData = data;
            AddParticipantDataForm.DataObject = new CreateParticipantAccount();
        }

        public string GetToken => LoggedInData?.GetToken()?.TokenValue;

        private async void SaveParticipantInformation_Clicked(object sender, System.EventArgs e)
        {
            if (AddParticipantDataForm.Validate())
            {
                Response response = await ServerHandler.PostAsync<Response>((CreateParticipantAccount)AddParticipantDataForm.DataObject, AddParticipantFailed, "KidsAppAPI/api/CreateParticipant");

                if (response != null)
                {
                    await DisplayAlert("Success", response.Message, "OK");
                    CreateParticipantAccount obj = ((CreateParticipantAccount)AddParticipantDataForm.DataObject);
                    obj.FirstNameParent = "";
                    obj.FirstNameChild = "";
                    obj.LastName = "";
                    obj.Email = "";
                    obj.MobileNumber = "";
                    obj.Password = "";
                    obj.ConfirmPassword = "";

                    AddParticipantDataForm.UpdateEditor("FirstNameParent");
                    AddParticipantDataForm.UpdateEditor("FirstNameChild");
                    AddParticipantDataForm.UpdateEditor("LastName");
                    AddParticipantDataForm.UpdateEditor("Email");
                    AddParticipantDataForm.UpdateEditor("MobileNumber");
                    AddParticipantDataForm.UpdateEditor("Password");
                    AddParticipantDataForm.UpdateEditor("ConfirmPassword");
                }
            }
            else
            {
                await DisplayAlert("Failed to Save a new Participant", "Try again next time", "OK");
            }
        }

        private void AddParticipantFailed(HttpResponseMessage obj)
        {
            DisplayAlert("Oops", obj.ReasonPhrase, "OK");
        }
    }
}