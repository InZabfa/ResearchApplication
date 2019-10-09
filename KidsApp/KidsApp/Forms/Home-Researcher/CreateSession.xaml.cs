using KidsApp.Data;
using SharedObjects.DesignGame;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSession : ContentPage
    {
        //Add functionality to the added elements such as the combo boxes

        public LoggedInData LoggedInData { get; set; }

        // private readonly LoggedInData LoggedInData;
        public CreateSession()
        {
            InitializeComponent();
            BindingContext = this;
           // CreateSessionDataForm.DataObject = new CreateSessionDetails();
        }

        public CreateSession(LoggedInData data) : this()
        {
            LoggedInData = data;
        }

        private void SaveSession_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}
