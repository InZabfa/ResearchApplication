using System;

namespace KidsApp.Forms.Home_Researcher
{

    public class ResearcherNavigationMenuItem
    {
        public ResearcherNavigationMenuItem() => TargetType = typeof(ResearcherNavigationDetail);

        /// <summary>
        /// Title of the menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The page type we are loading - e.g. typeof(MyPageHere) - A new instance is created from the page type.
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// Determines if this page should be within the Master Page or if we should ignore the slide out and navigate without it.
        /// </summary>
        public bool UseNavigationPage { get; set; } = true;
    }
}