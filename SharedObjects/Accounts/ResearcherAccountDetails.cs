using Syncfusion.XForms.DataForm;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace SharedObjects.Accounts
{
    public class ResearcherAccountDetails 
    {
        public ResearcherAccountDetails() { }

        [DisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Forename", Prompt = "John")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a forename*")]
        public string FirstName { get; set; }

        [DisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Surname", Prompt = "Smith")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a surname*")]
        public string LastName { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail", Prompt = "example@example.com")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter an E-mail address*")]
        public string Email { get; set; }

        [DisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password must be entered*")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password cannot be empty*")]
        [DisplayOptions(ColumnSpan = 1)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a mobile number*")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [DisplayOptions(ColumnSpan = 2)]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a department*")]
        public string Department { get; set; }

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
                if (Password != ConfirmPassword)
                    list.Add("Password and Confirm Password do not match.");

            return list;
        }

        private void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    }
}
