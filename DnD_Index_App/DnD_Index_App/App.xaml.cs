using Microsoft.Extensions.DependencyInjection;
using DnD_Index_App.Models;
using DnD_Index_App.Services;
using Microsoft.Maui.Controls;

namespace DnD_Index_App
{
    public partial class App : Application
    {
        private static List<SearchCatagory> _spellLevelList = default!;


        public static List<SearchCatagory> SpellLevelList
        {
            get
            {
                var levelList = from number in Enumerable.Range(1, 9) select new SearchCatagory($"Level {number}", $"Spells", $"level={number}", $"/api/2014/spells?level={number}");
                List<SearchCatagory> SpellLevels = levelList.ToList();
                SpellLevels.Insert(0, new SearchCatagory("Cantrips", "Spells", "level=0", $"/api/2014/spells?level=0"));
                _spellLevelList = SpellLevels;
                return SpellLevels;
            }
        }

        public static Dictionary<String, Dictionary<string, object>> PageQueryOptions = new Dictionary<String, Dictionary<string, object>>
        {
            {"SpellSearchPage", new Dictionary<string, object> {
                {"PageName", "Spells" },
                {"CatagoryType", "Levels" },
                {"CatagoryOptions", SpellLevelList },}
            },
            {"ClassesSearchPage", new Dictionary<string, object> {
                {"PageName", "Classes" },
                {"CatagoryType", "Class Types" },
                {"CatagoryOptions", SpellLevelList},}
            },
            {"EquipmentSearchPage", new Dictionary<string, object> {
                {"PageName", "Equipment" },
                {"CatagoryType", "Equipment Types" },
                {"CatagoryOptions", SpellLevelList},}
            }
        };


        public App()
        {
            InitializeComponent();
            PreferenceManager.UpdateResourceColours();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }


    }
}