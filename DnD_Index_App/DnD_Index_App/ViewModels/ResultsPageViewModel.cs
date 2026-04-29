using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;
using DnD_Index_App.Models.UI;
using DnD_Index_App.Services;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;

namespace DnD_Index_App.ViewModels
{
    public class ResultsPageViewModel : ContentView
    {
        public ResultsPageHeaderViewModel? Header { get; set; }
        public ResultsPageSectionViewModel? Body { get; set; }
        public List<ImageButton> NavBar = NavBarModel.NavBarButtons;

        public ResultsPageViewModel(ResultsPageHeaderViewModel? header, ResultsPageSectionViewModel? body) 
        {
            Header = header;
            Body = body;
            Grid PageWrapper = new Grid
            {
                    RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = GridLength.Auto },
                },
            };
            Grid ContentGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                },
            };
            ContentGrid.Add(Header, 0, 0);
            ContentGrid.Add(Body, 0, 1);
            ScrollView ContentScrollView = new ScrollView
            {
                Content = ContentGrid
            };
            PageWrapper.Add(ContentScrollView, 0, 0);
            Content = PageWrapper;

        }
    }
}
