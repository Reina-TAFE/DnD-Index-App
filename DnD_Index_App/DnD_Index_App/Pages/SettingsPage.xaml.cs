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
    public List<string> Languages = new List<string>
    {
        "English",
    };
    public List<string> GameVersions = new List<string>
    {
        "5th Edition (2014)",
    };
    private int _bodyFontSize;

    public int BodyFontSize
    {
        get 
        {
            return _bodyFontSize;
        } 
        set
        {
            if(PreferenceManager.ValidFontSizes.Contains(value))
            {
                _bodyFontSize = value;
            }
        }
    
    }
    private int _headingFontSize;
    public int HeadingFontSize
    {
        get
        {
            return _headingFontSize;
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
        BodyTextSizePicker.FontSize = selectedFontSize;
    }

    private void HeadingFontSizeOnSelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedFontSize = (int)HeadingSizePicker.SelectedItem;
        PreferenceManager.SetHeadingFontSize(selectedFontSize);
        HeadingFontSize = selectedFontSize;
        HeadingSizePicker.FontSize = selectedFontSize;
    }
}