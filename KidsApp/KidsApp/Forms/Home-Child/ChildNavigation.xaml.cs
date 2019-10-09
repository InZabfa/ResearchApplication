using KidsApp.Data;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace KidsApp.Forms.Home_Child
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildNavigation : MasterDetailPage
    {
        private readonly LoggedInData LoggedInData;

        public ChildNavigation()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            UpdateSelectedPage();
        }

        public ChildNavigation(LoggedInData data) : this()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            LoggedInData = data;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ChildNavigationDetail), LoggedInData));
        }

        private void UpdateSelectedPage()
        {
            if (MasterPage.ListView.SelectedItem != null)
            {
                Type current_page = Detail.GetType();
                ChildNavigationMenuItem item = MasterPage.ListView.ItemsSource.Cast<ChildNavigationMenuItem>()
                    .FirstOrDefault(i => i.TargetType == current_page);

                if (item != null) MasterPage.ListView.SelectedItem = item;
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ChildNavigationMenuItem item = e.SelectedItem as ChildNavigationMenuItem;
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