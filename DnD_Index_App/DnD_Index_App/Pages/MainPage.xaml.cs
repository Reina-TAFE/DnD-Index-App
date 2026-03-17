using System.Threading.Tasks;
using DnD_Index_App.Pages;
using System.Collections.ObjectModel;

namespace DnD_Index_App.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            return;
        }

        private async void SettingsBtnTapped(object? sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new SettingsPage());
            await Shell.Current.GoToAsync("SettingsPage");
        }
    }
}
