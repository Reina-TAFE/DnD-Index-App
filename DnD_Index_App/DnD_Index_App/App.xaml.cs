using Microsoft.Extensions.DependencyInjection;
using DnD_Index_App.Models;
using DnD_Index_App.Services;

namespace DnD_Index_App
{
    public partial class App : Application
    {
        private static List<ApiObjectInfo> _spellLevelList = default!;


        public static List<ApiObjectInfo> SpellLevelList
        {
            get
            {
                var levelList = from number in Enumerable.Range(1, 9) select new ApiObjectInfo($"level={number}", $"Level {number}", $"/api/2014/spells?level={number}");
                List<ApiObjectInfo> SpellLevels = levelList.ToList();
                SpellLevels.Insert(0, new ApiObjectInfo("level=0", "Cantrips", $"/api/2014/spells?level=0"));
                _spellLevelList = SpellLevels;
                return SpellLevels;
            }
        }

        public static Dictionary<String, Dictionary<string, object>> PageQueryOptions = new Dictionary<String, Dictionary<string, object>>
        {
            {"SpellSearchPage", new Dictionary<string, object> {
                {"PageName", "Spells" },
                {"CatagoryType", "Levels" },
                {"CatagoryOptions", SpellLevelList },
            }
            }
        };



        public App()
        {
            InitializeComponent();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}