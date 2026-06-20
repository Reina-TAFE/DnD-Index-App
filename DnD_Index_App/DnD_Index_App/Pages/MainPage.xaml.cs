using System.Threading.Tasks;
using DnD_Index_App.Pages;
using DnD_Index_App.Services;
using System.Collections.ObjectModel;

namespace DnD_Index_App.Pages
{
    public partial class MainPage : ContentPage
    {
        public int? BodyFontSize = PreferenceManager.GetBodyFontSize();
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
            await Shell.Current.GoToAsync("SettingsPage");
        }

        private async void SearchBtn_Tapped(object sender, TappedEventArgs e)
        {
            Button searchPageOption = (Button)sender;
            IDictionary<string, object> queryOptions = new Dictionary<string, object>();
            if (searchPageOption.StyleId == "SpellsBtn")
            {
                queryOptions = await App.PageQueryOptions("SpellSearchPage");
            }
            else if(searchPageOption.StyleId == "ClassesBtn")
            {
                queryOptions = await App.PageQueryOptions("ClassesSearchPage");
            }
            else if (searchPageOption.StyleId == "EquipmentBtn")
            {
                queryOptions = await App.PageQueryOptions("EquipmentSearchPage");
            }
            else if (searchPageOption.StyleId == "RulesBtn")
            {
                queryOptions = await App.PageQueryOptions("RulesSearchPage");
            }
            await Shell.Current.GoToAsync("SearchPage", queryOptions);
        }

        private async void NavSearchBtn_Tapped(object sender, TappedEventArgs e)
        {
            ImageButton searchPageOption = (ImageButton)sender;
            IDictionary<string, object> queryOptions = new Dictionary<string, object>();
            if (searchPageOption.StyleId == "NavSpellsBtn")
            {
                queryOptions = await App.PageQueryOptions("SpellSearchPage");
            }
            else if (searchPageOption.StyleId == "NavClassesBtn")
            {
                queryOptions = await App.PageQueryOptions("ClassesSearchPage");
            }
            else if (searchPageOption.StyleId == "NavEquipmentBtn")
            {
                queryOptions = await App.PageQueryOptions("EquipmentSearchPage");
            }
            else if (searchPageOption.StyleId == "NavRulesBtn")
            {
                queryOptions = await App.PageQueryOptions("RulesSearchPage");
            }
            await Shell.Current.GoToAsync("SearchPage", queryOptions);
        }
    }
}
