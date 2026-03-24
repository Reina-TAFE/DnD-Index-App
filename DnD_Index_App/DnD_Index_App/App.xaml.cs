using Microsoft.Extensions.DependencyInjection;

namespace DnD_Index_App
{
    public partial class App : Application
    {
        private static List<string> spellLevelList = default!;

        public static List<string> SpellLevelList
        {
            get
            {
                var levelList = from number in Enumerable.Range(1, 21) select $"Level {number}";
                List<string> SpellLevels = levelList.ToList();
                SpellLevels.Insert(0, "Cantrips");
                spellLevelList = SpellLevels;
                return SpellLevels;
            }
        }

        public static Dictionary<String, Dictionary<string, object>> PageQueryOptions = new Dictionary<String, Dictionary<string, object>>
        {
            {"SpellSearchPage", new Dictionary<string, object> {
                {"PageName", "Spells" },
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