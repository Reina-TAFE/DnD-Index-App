using DnD_Index_App;
using DnD_Index_App.Pages;

namespace DnD_Index_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("SettingsPage", typeof(Pages.SettingsPage));
        }
    }
}
