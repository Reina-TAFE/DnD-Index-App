using DnD_Index_App.Pages;
using DnD_Index_App.Services;

namespace DnD_Index_App.Pages;

public partial class SettingsPage : ContentPage
{
    //public PreferenceManager AppPreferenceManager { get; set; }
    public string BackgroundColour { get { return Preferences.Get("BackgroundColour", "#582929"); } set; }
    public string SectionColour { get { return Preferences.Get("SectionColour", "#FFFFFF"); } set; }
    public string ButtonColour { get { return Preferences.Get("ButtonColour", "#FFFFFF"); } set; }
    public string TextColour { get { return Preferences.Get("TextColour", "#FFFFFF"); } set; }
    public string TitleColour { get { return Preferences.Get("TitleColour", "#FFFFFF"); } set; }
    public string NavColour { get { return Preferences.Get("NavColour", "#FFFFFF"); } set; }


	public SettingsPage()
	{
        PreferenceManager.SetTheme(PreferenceManager.Themes[0]);
		InitializeComponent();
	}

    private async void BackBtn_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        PreferenceManager.SetTheme(PreferenceManager.Themes[(e.Value == true) ? 1 : 0]);
    }
}