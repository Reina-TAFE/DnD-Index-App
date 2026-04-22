using DnD_Index_App.Pages;
using DnD_Index_App.Services;

namespace DnD_Index_App.Pages;

public partial class SettingsPage : ContentPage
{
    //public PreferenceManager AppPreferenceManager { get; set; }
    //public string BackgroundColour { get { return Preferences.Get("BackgroundColour", "#582929"); } set; } = Preferences.Get("BackgroundColour", "#582929");
    //public string SectionColour { get { return Preferences.Get("SectionColour", "#FFFFFF"); } set; } = Preferences.Get("SectionColour", "#FFFFFF");
    //public string ButtonColour { get { return Preferences.Get("ButtonColour", "#FFFFFF"); } set; } = Preferences.Get("ButtonColour", "#FFFFFF");
    //public string TextColour { get { return Preferences.Get("TextColour", "#FFFFFF"); } set; } = Preferences.Get("TextColour", "#FFFFFF");
    //public string TitleColour { get { return Preferences.Get("TitleColour", "#FFFFFF"); } set; } = Preferences.Get("TitleColour", "#FFFFFF");
    //public string NavColour { get { return Preferences.Get("NavColour", "#FFFFFF"); } set; } = Preferences.Get("NavColour", "#FFFFFF");


	public SettingsPage()
	{
		InitializeComponent();
        PreferenceManager.UpdateResourceColours();
    }

    private async void BackBtn_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value == true)
        {
            PreferenceManager.SetCurrentTheme("Dark Mode");
        }
        else
        {
            PreferenceManager.SetCurrentTheme("Light Mode");
        }

    }
}