using DnD_Index_App.Pages;
using DnD_Index_App.Services;

namespace DnD_Index_App.Pages;

public partial class SettingsPage : ContentPage
{
    public List<string> Languages = new List<string>
    {
        "English",
    };
    public List<string> GameVersions = new List<string>
    {
        "5th Edition (2014)",
    };
    private int _bodyFontSize = 16;

    public int BodyFontSize
    {
        get 
        {
            return PreferenceManager.ValidFontSizes.Contains(_bodyFontSize) ? _bodyFontSize : PreferenceManager.GetBodyFontSize();
        } 
        set
        {
            if(PreferenceManager.ValidFontSizes.Contains(value))
            {
                _bodyFontSize = value;
            }
        }
    
    }
    private int _headingFontSize = 24;
    public int HeadingFontSize
    {
        get
        {
            return PreferenceManager.ValidFontSizes.Contains(_headingFontSize) ? _headingFontSize : PreferenceManager.GetHeadingFontSize();
        }
        set
        {
            if (PreferenceManager.ValidFontSizes.Contains(value))
            {
                _headingFontSize = value;
            }
        }

    }
    public SettingsPage()
	{
		InitializeComponent();
        PreferenceManager.UpdateResourceColours();
        BodyTextSizePicker.ItemsSource = PreferenceManager.ValidFontSizes;
        HeadingSizePicker.ItemsSource = PreferenceManager.ValidFontSizes;
        LanguagePicker.ItemsSource = Languages;
        GameVersionPicker.ItemsSource = GameVersions;
        LoadCurrentSettings();
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

    public void LoadCurrentSettings()
    {
        DarkModeSwitch.IsToggled = (PreferenceManager.GetCurrentTheme() == "Dark Mode") ? true : false;
        BodyTextSizePicker.SelectedItem = PreferenceManager.GetBodyFontSize();
        HeadingSizePicker.SelectedItem = PreferenceManager.GetHeadingFontSize();
        GameVersionPicker.SelectedIndex = 0;
        LanguagePicker.SelectedIndex = 0;
        GameVersionPicker.SelectedIndex = 0;
    }
    private void BodyFontSizeOnSelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedFontSize = (int)BodyTextSizePicker.SelectedItem;
        PreferenceManager.SetBodyFontSize(selectedFontSize);
        BodyFontSize = selectedFontSize;
        GameVersionLabel.FontSize = BodyFontSize;
        DarkModeLabel.FontSize = BodyFontSize;
        ThemesLabel.FontSize = BodyFontSize;
        HeadingSizeLabel.FontSize = BodyFontSize;
        BodySizeLabel.FontSize = BodyFontSize;
        ColourblindLabel.FontSize = BodyFontSize;
        LanguageLabel.FontSize = BodyFontSize;
        AppVersionLabel.FontSize = BodyFontSize;
        VersionLabel.FontSize = BodyFontSize;
    }

    private void HeadingFontSizeOnSelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedFontSize = (int)HeadingSizePicker.SelectedItem;
        PreferenceManager.SetHeadingFontSize(selectedFontSize);
        HeadingFontSize = selectedFontSize;
        AppSettingsLabel.FontSize = HeadingFontSize;
        AppearanceSettingsLabel.FontSize = HeadingFontSize;
        AccessibilitySettingsLabel.FontSize = HeadingFontSize;
        LanguageSettingsLabel.FontSize = HeadingFontSize;
        AboutSettingsLabel.FontSize = HeadingFontSize;
    }
}