using KidsApp.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateLevel : ContentPage
    {
        private readonly LoggedInData LoggedInData;
        public CreateLevel() => InitializeComponent();
        public CreateLevel(LoggedInData data) : this() => LoggedInData = data;

        private void AddWrongAnswers_Clicked(object sender, System.EventArgs e)
        {
            
        }

        private void SaveLevel_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}