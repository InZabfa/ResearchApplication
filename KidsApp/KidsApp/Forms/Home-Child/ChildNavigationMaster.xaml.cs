using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Child
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildNavigationMaster : ContentPage
    {
        public ListView ListView;

        public ChildNavigationMaster()
        {
            InitializeComponent();

            BindingContext = new ChildNavigationMasterViewModel();
            ListView = ChildMenuItemsListView;
        }

        private class ChildNavigationMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ChildNavigationMenuItem> ChildMenuItems { get; set; }

            public ChildNavigationMasterViewModel()
            {
                ChildMenuItems = new ObservableCollection<ChildNavigationMenuItem>(new[]
                {
                    new ChildNavigationMenuItem { Title = "My Profile", TargetType = typeof(ChildNavigationDetail)},
                    new ChildNavigationMenuItem { Title = "Experiments", TargetType = typeof(UpcomingExperiments)},
                    new ChildNavigationMenuItem { Title = "Start Experiment", TargetType = typeof(StartExperiment)},
                    new ChildNavigationMenuItem { Title = "Log Out", TargetType = typeof(MainLogin), UseNavigationPage = false},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}