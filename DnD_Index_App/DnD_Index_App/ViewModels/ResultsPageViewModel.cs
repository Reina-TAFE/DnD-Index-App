using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;
using DnD_Index_App.Models.UI;
using DnD_Index_App.Services;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;

namespace DnD_Index_App.ViewModels
{
    public class ResultsPageViewModel
    {
        public ResultsPageHeaderViewModel Header { get; set; }
        public ResultsPageSectionViewModel Body { get; set; }
        public List<ImageButton> NavBar = NavBarModel.NavBarButtons;

        public ResultsPageViewModel() 
        {
            Content = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = GridLength.Auto },
            },

            };
        }
    }
}
