using Syncfusion.XForms.DataForm;
using System;

namespace SharedObjects.DesignGame
{
    public class CreateSessionDetails
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "Current date")]
        public DateTime CurrentDateTime { get; set; }
    }
}
