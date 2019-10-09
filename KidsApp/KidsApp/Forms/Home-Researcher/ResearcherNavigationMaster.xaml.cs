using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsApp.Forms.Home_Researcher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResearcherNavigationMaster : ContentPage
    {
        public ListView ListView;

        public ResearcherNavigationMaster()
        {
            InitializeComponent();

            BindingContext = new ResearcherNavigationMasterViewModel();
            ListView = MenuItemsListView;
        }

        private class ResearcherNavigationMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ResearcherNavigationMenuItem> MenuItems { get; set; }

            public ResearcherNavigationMasterViewModel()
            {
                MenuItems = new ObservableCollection<ResearcherNavigationMenuItem>(new[]
                {
                    new ResearcherNavigationMenuItem { Title = "My Profile", TargetType = typeof(ResearcherNavigationDetail)},
                    new ResearcherNavigationMenuItem { Title = "Add Participant", TargetType = typeof(AddParticipant) },
                    new ResearcherNavigationMenuItem { Title = "Add Word", TargetType = typeof(AddWord) },
                    new ResearcherNavigationMenuItem { Title = "Create Level", TargetType = typeof(CreateLevel) },
                    new ResearcherNavigationMenuItem { Title = "Create Session", TargetType = typeof(CreateSession)},
                    new ResearcherNavigationMenuItem { Title = "Create Experiment", TargetType = typeof(CreateExperiment) },
                    new ResearcherNavigationMenuItem { Title = "Edit Session", TargetType = typeof(EditSession)},                    
                    new ResearcherNavigationMenuItem { Title = "Log Out", TargetType = typeof(MainLogin), UseNavigationPage = false},
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