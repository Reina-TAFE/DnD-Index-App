using DnD_Index_App.Pages;

namespace DnD_Index_App.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private async void BackBtn_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {

    }
}