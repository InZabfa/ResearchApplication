using Syncfusion.XForms.DataForm;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SharedObjects.EditExistingAccount
{
    public class ResearcherAccountChanges : INotifyPropertyChanged
    {
        public ResearcherAccountChanges(int UserID, string Token)
        {
            this.UserID = UserID;
            this.Token = Token;
        }

        [Display(AutoGenerateField = false)]
        public string Token { get; }

        //Don't include this in the form generated view.
        [Display(AutoGenerateField = false)]
        public int UserID { get; set; }

        private string password;
        private string confirm_password;

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail", Prompt = "example@example.com", GroupName = "Change E-mail address")]
        public string Email { get; set; }

        [DisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", GroupName = "Change Password")]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password cannot be empty*")]
        [DisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password", GroupName = "Change Password")]
        public string ConfirmPassword
        {
            get => confirm_password;
            set
            {
                confirm_password = value;
                RaisePropertyChanged("ConfirmPassword");
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> list = new List<string>();

            if (propertyName == "ConfirmPassword")
                if (password != confirm_password)
                    list.Add("Password and Confirm Password do not match.");

            return list;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
