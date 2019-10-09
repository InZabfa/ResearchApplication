using KidsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Child
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartExperiment : ContentPage
	{
        public LoggedInData LoggedInData { get; set; }

        public StartExperiment()
		{
            InitializeComponent();
        }

        public StartExperiment(LoggedInData loggedInData)
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void StartExperiment_Clicked(object sender, EventArgs e)
        {

        }

        private void StartExperimentBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}