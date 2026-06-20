using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models.UI
{
    public class NavBarModel
    {
        public static List<ImageButton> GetNavBarButtons() 
        { 
            return new List<ImageButton>()
                {
                    new ImageButton()
                    {
                        Source = "/Assets/Icons/spellbook.png",
                        GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(async () => await Shell.Current.GoToAsync("SearchPage", await App.PageQueryOptions("SpellSearchPage"))) } },
                    },
                    new ImageButton()
                    {
                        Source = "/Assets/Icons/paladin.png",
                        GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(async () => await Shell.Current.GoToAsync("SearchPage", await App.PageQueryOptions("ClassesSearchPage"))) } },
                    },
                    new ImageButton()
                    {
                        Source = "/Assets/Icons/fighter_symbol.png",
                        GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(async () => await Shell.Current.GoToAsync("SearchPage", await App.PageQueryOptions("EquipmentSearchPage"))) } },
                    },
                    new ImageButton()
                    {
                        Source = "/Assets/Icons/scroll.png",
                        GestureRecognizers = { new TapGestureRecognizer() { Command = new Command(async () => await Shell.Current.GoToAsync("SearchPage", await App.PageQueryOptions("RulesSearchPage"))) } },
                    }
                };
        } 
    }
}