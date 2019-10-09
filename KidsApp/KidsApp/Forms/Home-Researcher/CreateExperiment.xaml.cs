using KidsApp.Data;
using KidsApp.Handlers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SharedObjects.DesignGame;
using SharedObjects.Response;
using System.Dynamic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateExperiment : ContentPage
    {
        private readonly LoggedInData LoggedInData;
        public CreateExperiment() => InitializeComponent();
        public CreateExperiment(LoggedInData data) : this()
        {
            LoggedInData = data;
            //CreateExperimentDataForm.DataObject = new CreateExperimentDetails(LoggedInData.GetUser().ID, LoggedInData.GetToken().TokenValue);
        }

        private async void SaveExperiment_Clicked(object sender, System.EventArgs e)
        {
            //if (CreateExperimentDataForm.Validate())
            //{

            //    Response response = await ServerHandler.PostAsync<Response>((CreateExperimentDetails)CreateExperimentDataForm.DataObject, CreateExperimentFailed, "KidsAppAPI/api/CreateExperiment");

            //    if (response != null)
            //    {
            //        await DisplayAlert("Success", response.Message, "OK");
            //    }
            //}
            await DisplayAlert("Error","Unfortunetly couldn't save the Experiment at the moment","OK");

        }

        private async void CreateExperimentFailed(HttpResponseMessage obj)
        {

            string msg = await obj.Content.ReadAsStringAsync();

            ExpandoObjectConverter expConverter = new ExpandoObjectConverter();
            dynamic response_msg = JsonConvert.DeserializeObject<ExpandoObject>(msg, expConverter);

            if (response_msg.Message != null)
            {
                await DisplayAlert("Oops", response_msg.Message, "OK");
            }
            else
            {
                await DisplayAlert("Oops", obj.ReasonPhrase, "OK");
            }
        }
    }
}