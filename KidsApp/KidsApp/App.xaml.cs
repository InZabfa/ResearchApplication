using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace KidsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Registers the license for Syncfusion Xamarin controls.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Njk1NDlAMzEzNjJlMzQyZTMwQmdvV2tUZVpJazVPWVZzQTNYYmc2TTBycUdJSTBpRlVLMVRDdjVGYklMZz0=");
            MainPage = new NavigationPage(new MainLogin());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleepss
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
