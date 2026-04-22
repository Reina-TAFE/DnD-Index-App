using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;
using DnD_Index_App.Models.UI;

namespace DnD_Index_App.Services
{
    public static class PreferenceManager
    {
        public static List<string> ValidThemeNames = new List<string>()
        {
            "Light Mode",
            "Dark Mode"
        };

        public static void SetCurrentTheme(string themeName)
        {
            if (ValidThemeNames.Contains(themeName))
            {
                Preferences.Set("CurrentTheme", themeName);
                UpdateResourceColours();
            }
        }


        public static void UpdateResourceColours()
        {
            string currentTheme = Preferences.Get("CurrentTheme", "Light Mode");
            if (currentTheme == "Light Mode")
            {
                Application.Current.Resources["CurrentBackgroundColour"] = Application.Current.Resources["LightBackground"];
                Application.Current.Resources["CurrentSectionColour"] = Application.Current.Resources["LightSection"];
                Application.Current.Resources["CurrentButtonColour"] = Application.Current.Resources["LightButton"];
                Application.Current.Resources["CurrentButtonTextColour"] = Application.Current.Resources["LightButtonText"];
                Application.Current.Resources["CurrentTextColour"] = Application.Current.Resources["LightText"];
                Application.Current.Resources["CurrentTitleColour"] = Application.Current.Resources["LightTitle"];
                Application.Current.Resources["CurrentNavColour"] = Application.Current.Resources["LightNav"];
            }
            else if (currentTheme == "Dark Mode")
            {
                Application.Current.Resources["CurrentBackgroundColour"] = Application.Current.Resources["DarkBackground"];
                Application.Current.Resources["CurrentSectionColour"] = Application.Current.Resources["DarkSection"];
                Application.Current.Resources["CurrentButtonColour"] = Application.Current.Resources["DarkButton"];
                Application.Current.Resources["CurrentButtonTextColour"] = Application.Current.Resources["DarkButtonText"];
                Application.Current.Resources["CurrentTextColour"] = Application.Current.Resources["DarkText"];
                Application.Current.Resources["CurrentTitleColour"] = Application.Current.Resources["DarkTitle"];
                Application.Current.Resources["CurrentNavColour"] = Application.Current.Resources["DarkNav"];
            }
        }


    }
}
