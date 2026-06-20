using CommunityToolkit.Mvvm.ComponentModel;
using DnD_Index_App.Models;
using DnD_Index_App.Models.UI;
using DnD_Index_App.Services;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.ViewModels
{
    [QueryProperty("ViewModel", "ViewModel")]
    public class ResultsPageViewModel : ObservableObject
    {
        public ContentView PageContent = new ContentView();
        public ResultsPageHeaderViewModel? Header { get; set; }
        public ResultsPageSectionViewModel? Body { get; set; }
        public List<ImageButton> NavBar = NavBarModel.GetNavBarButtons();

        public ResultsPageViewModel(ResultsPageHeaderViewModel? header, ResultsPageSectionViewModel? body)
        {
            Header = header;
            Body = body;
            Header?.Content.Parent = null;

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
            VerticalStackLayout gridWrapper = new VerticalStackLayout();
            ContentGrid.Add(Header, 0, 0);
            ContentGrid.Add(Body, 0, 1);
            ScrollView ContentScrollView = new ScrollView
            {
                Content = ContentGrid
            };
            PageWrapper.Add(ContentScrollView, 0, 0);
            PageContent.Content = PageWrapper;


        }
    }
}
