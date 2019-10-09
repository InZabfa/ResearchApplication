using Syncfusion.XForms.DataForm;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SharedObjects.Accounts
{
    public class CreateParticipantAccount
    {

        public CreateParticipantAccount() { }


        private string password;
        private string confirm_password;


        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Parent Forename", Prompt = "John")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a parent forename*")]
        public string FirstNameParent { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Child Forename", Prompt = "Joe")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a child forename*")]
        public string FirstNameChild { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Surname", Prompt = "Smith")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a surname*")]
        public string LastName { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail", Prompt = "example@example.com")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter an E-mail address*")]
        public string Email { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a mobile number*")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must be entered*")]
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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password cannot be empty*")]
        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword
        {
            get
            {
                return confirm_password;
            }
            set
            {
                confirm_password = value;
                RaisePropertyChanged("ConfirmPassword");
            }
        }


        [Display(AutoGenerateField = false)]
        public bool HasErrors()
        {
            //If password doesn't match, return false.
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> list = new List<string>();

            if (propertyName == "ConfirmPassword")
                if (password != confirm_password)
                    list.Add("Password and Confirm Password do not match.");

            return list;
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
