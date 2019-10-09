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
    public partial class UpcomingExperiments : ContentPage
    {
        public LoggedInData LoggedInData { get; set; }
        public UpcomingExperiments()
        {
            InitializeComponent();
        }

        public UpcomingExperiments(LoggedInData loggedInData)
        {
            InitializeComponent();
        }
    }
}