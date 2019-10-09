using KidsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSession : ContentPage
    {
        private readonly LoggedInData LoggedInData;

        public EditSession()
        {
            InitializeComponent();
        }

        public EditSession(LoggedInData loggedInData)
        {
            InitializeComponent();
        }

        private void DeleteSession_Clicked(object sender, EventArgs e)
        {

        }

        private void EditSessionBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}