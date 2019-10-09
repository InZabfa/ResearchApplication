using KidsApp.Data;
using KidsApp.Handlers;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SharedObjects.DesignGame;
using SharedObjects.Response;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWord : ContentPage
    {
        private readonly LoggedInData LoggedInData;
        private AddWordDetails wordDetails = new AddWordDetails();
        private int difficultyIndex;

        public AddWord()
        {
            InitializeComponent();
        }

        public AddWord(LoggedInData data) : this()
        {
            LoggedInData = data;
            ReloadContentAsync(data);
        }

        private Difficulties Difficulties { get; set; }

        private async void ReloadContentAsync(LoggedInData x)
        {
            if (x != null)
            {
                Difficulties = await ServerHandler.PostAsync<Difficulties>(x.GetToken(), FailedToRetrieve, "KidsAppAPI/api/Difficulty");
                if (Difficulties != null)
                {
                    comboBox.ComboBoxSource = Difficulties.Values.Values.ToList();
                }
            }

            comboBox.SelectionChanged += (object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e) =>
            {
                difficultyIndex = Difficulties.Values.FirstOrDefault(i => i.Value == comboBox.SelectedValue.ToString()).Key;
            };
        }

        private void FailedToRetrieve(HttpResponseMessage obj) => DisplayAlert("Fail", obj.ReasonPhrase, "OK");

        private MediaFile _mediaFile;

        private async void UploadImage_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                IFilePicker crossFileData = CrossFilePicker.Current;
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                wordDetails.Contents = File.ReadAllBytes(_mediaFile.Path);
                wordDetails.FileName = _mediaFile.Path;
                ImageAddedMsg.Text = "The image has been selected!";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild to upload", ex.Message, "OK");
            }
        }


        private async void SaveWord_ClickedAsync(object sender, System.EventArgs e)
        {
            if (_mediaFile != null)
            {
                wordDetails.Word = txtWord.Text;
                wordDetails.UserID = LoggedInData.GetUser().ID;
                wordDetails.Token = LoggedInData.GetToken().TokenValue;
                if (difficultyIndex != 0)
                {
                    wordDetails.Difficulty = difficultyIndex;
                }
                else
                {
                    await DisplayAlert("Incomplete", "Please select difficulty to be able to save this word", "Ok");
                }

                Response obj = await ServerHandler.PostAsync<Response>(wordDetails, UnableToUploadImageAsync, "KidsAppAPI/api/AddWord");

                if (obj != null)
                {
                    await DisplayAlert("Success", obj.Message, "OK");
                    txtWord.Text = "";
                    ImageAddedMsg.Text = "";
                    comboBox.SelectedItem = null;
                }
                else
                {
                    await DisplayAlert("No Response", "We couldn't verify if the image was uploaded. Try again!", "OK");
                }
            }
            else
            {
                await DisplayAlert("Failure", "Oops! It didn't work, try again :)", "OK");
            }
        }

        private async void UnableToUploadImageAsync(HttpResponseMessage obj)
        {
            await DisplayAlert("Problem", obj.ReasonPhrase, "OK");
        }
    }
}