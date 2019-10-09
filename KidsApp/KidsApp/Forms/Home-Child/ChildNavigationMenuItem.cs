using System;

namespace KidsApp.Forms.Home_Child
{

    public class ChildNavigationMenuItem
    {
        public ChildNavigationMenuItem() => TargetType = typeof(ChildNavigationDetail);

        public string Title { get; set; }

        public Type TargetType { get; set; }

        public bool UseNavigationPage { get; set; } = true;
    }
}