using DnD_Index_App;
using DnD_Index_App.Pages;
using DnD_Index_App.Services;

namespace DnD_Index_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute("MainPage", typeof(Pages.MainPage));
            Routing.RegisterRoute("SettingsPage", typeof(Pages.SettingsPage));
            Routing.RegisterRoute("SearchPage", typeof(Pages.SearchPage));
        }
    }
}
