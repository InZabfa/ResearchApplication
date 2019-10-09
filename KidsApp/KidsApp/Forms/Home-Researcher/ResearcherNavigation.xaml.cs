using KidsApp.Data;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResearcherNavigation : MasterDetailPage
    {
        private readonly LoggedInData LoggedInData;

        public ResearcherNavigation()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            UpdateSelectedPage();
        }

        public ResearcherNavigation(LoggedInData data) : this()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            LoggedInData = data;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ResearcherNavigationDetail), LoggedInData));
        }

        public void UpdateSelectedPage()
        {
            if (MasterPage.ListView.SelectedItem != null)
            {
                Type current_page = Detail.GetType();
                ResearcherNavigationMenuItem item = MasterPage.ListView.ItemsSource.Cast<ResearcherNavigationMenuItem>()
                    .FirstOrDefault(i => i.TargetType == current_page);

                if (item != null) MasterPage.ListView.SelectedItem = item;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ResearcherNavigationMenuItem item = e.SelectedItem as ResearcherNavigationMenuItem;
            if (item != null)
                if (item.UseNavigationPage)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType, LoggedInData));
                    UpdateSelectedPage();
                    IsPresented = false;
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    IsPresented = false;
                }

        }
    }
}
