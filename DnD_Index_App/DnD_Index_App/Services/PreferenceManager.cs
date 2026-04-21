using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;
using DnD_Index_App.Models.UI;

namespace DnD_Index_App.Services
{
    public static class PreferenceManager
    {
        public static List<UITheme> Themes = new List<UITheme>()
        {
            new UITheme("Light Mode", "#582929", "#401D1D",
                "#D9D9D9", "#3C3C3C", "FFECB9", "#8F8D8D"),
            new UITheme("Dark Mode", "#21123B", "#391B6D",
                "#7D736F", "#E9E9E9", "#FFEE6D", "#4C4948")
        };

        public static void SetTheme(UITheme theme)
        {
            Preferences.Set("CurrentTheme", theme.Name);
            Preferences.Set("BackgroundColour", theme.BackgroundColour);
            Preferences.Set("SectionColour", theme.SectionColour);
            Preferences.Set("ButtonColour", theme.ButtonColour);
            Preferences.Set("TextColour", theme.TextColour);
            Preferences.Set("TitleColour", theme.TitleColour);
            Preferences.Set("NavColour", theme.NavColour);
        }


    }
}
