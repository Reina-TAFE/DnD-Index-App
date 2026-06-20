using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;
using DnD_Index_App.Models.UI;

namespace DnD_Index_App.Services
{
    /// <summary>
    /// Provides methods for getting and setting user preferences in the app's preferences, 
    /// as well as updating the backing fields for the elements associated with those preferences in the app's resource dictionary.
    /// </summary>
    public static class PreferenceManager
    {
        public static List<string> ValidThemeNames = new List<string>() // List of valid theme names
        {
            "Light Mode",
            "Dark Mode"
        };

        public static List<int> ValidFontSizes = new List<int>() // List of valid font sizes
        {
            10,
            12,
            16,
            20,
            24,
            28,
            32,
            36,
            40,
            42,
            48,
            56,
            64,
            72
        };

        /// <summary>
        /// Sets the name of the current theme in the app's preferences.
        /// </summary>
        /// <param name="themeName">The name of the theme to be set</param>
        public static void SetCurrentTheme(string themeName)
        {
            if (ValidThemeNames.Contains(themeName)) // check if themeName is a valid theme name
            {
                Preferences.Set("CurrentTheme", themeName); // set the current theme in the app's preferences
                UpdateResourceColours(); // update the current element colour backing fields in app resource dictionary to the new theme's colours
            }
        }

        /// <summary>
        /// Returns the name of the theme currently selected in the App's Preferences.
        /// </summary>
        /// <returns>A string containing the name of the currently selected theme. Defaults to Light Mode if np theme is set</returns>
        public static string GetCurrentTheme()
        {
            return Preferences.Get("CurrentTheme", "Light Mode");
        }

        /// <summary>
        /// Updates the current colours of elements in app resource dictionary to the current theme selected in the app's preferences.
        /// </summary>
        public static void UpdateResourceColours()
        {
            string currentTheme = Preferences.Get("CurrentTheme", "Light Mode");
            if (currentTheme == "Light Mode") // update current element colours to light mode colours
            {
                Application.Current?.Resources["CurrentBackgroundColour"] = Application.Current.Resources["LightBackground"];
                Application.Current?.Resources["CurrentSectionColour"] = Application.Current.Resources["LightSection"];
                Application.Current?.Resources["CurrentButtonColour"] = Application.Current.Resources["LightButton"];
                Application.Current?.Resources["CurrentButtonTextColour"] = Application.Current.Resources["LightButtonText"];
                Application.Current?.Resources["CurrentTextColour"]  = Application.Current.Resources["LightText"];
                Application.Current?.Resources["CurrentTitleColour"] = Application.Current.Resources["LightTitle"];
                Application.Current?.Resources["CurrentNavColour"] = Application.Current.Resources["LightNav"];
            }
            else if (currentTheme == "Dark Mode") // update current element colours to dark mode colours
            {
                Application.Current?.Resources["CurrentBackgroundColour"] = Application.Current.Resources["DarkBackground"];
                Application.Current?.Resources["CurrentSectionColour"] = Application.Current.Resources["DarkSection"];
                Application.Current?.Resources["CurrentButtonColour"] = Application.Current.Resources["DarkButton"];
                Application.Current?.Resources["CurrentButtonTextColour"] = Application.Current.Resources["DarkButtonText"];
                Application.Current?.Resources["CurrentTextColour"] = Application.Current.Resources["DarkText"];
                Application.Current?.Resources["CurrentTitleColour"] = Application.Current.Resources["DarkTitle"];
                Application.Current?.Resources["CurrentNavColour"] = Application.Current.Resources["DarkNav"];
            }
        }

        public static Color? GetCurrentSectionColour()
        {
            return Application.Current?.Resources["CurrentSectionColour"] as Color;
        }

        public static Color? GetCurrentTitleColour()
        {
            return Application.Current?.Resources["CurrentTitleColour"] as Color;
        }

        public static int GetBodyFontSize()
        {
            return Preferences.Get("BodyFontSize", 16);
        }

        public static int GetHeadingFontSize()
        {
            return Preferences.Get("HeadingFontSize", 24);
        }

        public static void SetBodyFontSize(int fontSize)
        {
            Preferences.Set("BodyFontSize", fontSize);
        }

        public static void SetHeadingFontSize(int fontSize)
        {
            Preferences.Set("HeadingFontSize", fontSize);
        }

        public static Color? GetTextColour()
        {
            return Application.Current?.Resources["CurrentTextColour"] as Color;
        }

        public static Color? GetCurrentBackgroundColour()
        {
            return Application.Current?.Resources["CurrentBackgroundColour"] as Color;
        }

        public static Color? GetAccentColour()
        {
            return Application.Current?.Resources["CurrentPageAccentColour"] as Color;
        }
    }
}
