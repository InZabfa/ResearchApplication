//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("KidsApp.Forms.Home_Researcher.CreateSession.xaml", "Forms/Home-Researcher/CreateSession.xaml", typeof(global::KidsApp.Forms.Home_Researcher.CreateSession))]

namespace KidsApp.Forms.Home_Researcher {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Forms\\Home-Researcher\\CreateSession.xaml")]
    public partial class CreateSession : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Entry sessionNametxt;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Syncfusion.XForms.ComboBox.SfComboBox comboBoxLevel;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private global::Xamarin.Forms.Button SaveSession;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "0.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(CreateSession));
            sessionNametxt = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Entry>(this, "sessionNametxt");
            comboBoxLevel = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.XForms.ComboBox.SfComboBox>(this, "comboBoxLevel");
            SaveSession = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Button>(this, "SaveSession");
        }
    }
}