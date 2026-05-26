using DnD_Index_App.Models;
using DnD_Index_App.Models.ResponseModels;
using DnD_Index_App.Models.UI;
using DnD_Index_App.Services;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Text;
using Markdig;
using Microsoft.Maui.Layouts;
using System.ComponentModel.Design;

namespace DnD_Index_App.ViewModels.ResultsPageComponentModels;

public partial class ResultsPageSectionViewModel : ContentView
{
    public ResultsPageSectionModel SectionModel;
    public ResultsPageSectionViewModel(ResultsPageSectionModel sectionModel)
    {
        InitializeComponent();
        SectionModel = sectionModel;

        FlexLayout sections = new FlexLayout
        {
            Direction = FlexDirection.Column,
            Padding = new Thickness(10, 20),
            AlignContent = FlexAlignContent.SpaceAround,
            AlignItems = FlexAlignItems.Start

        };
        foreach (SectionContent section in SectionModel.SectionContent)
        {
            VerticalStackLayout sectionElement = FormatSectionContent(section);
            sections.Add(sectionElement);
        }
        Content = sections;
    }

    public VerticalStackLayout FormatSectionContent(SectionContent sectionContent)
    {
        {
            VerticalStackLayout contentLayout = new VerticalStackLayout();
            contentLayout.Spacing = 5;
            //BoxView separator = new BoxView() { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill };
            foreach (SectionItem item in sectionContent.Content)
            {
                if (item.SectionItemTitle != null)
                {

                    Label itemTitle = new Label() { Text = item.SectionItemTitle, FontAttributes = FontAttributes.Bold, VerticalTextAlignment = TextAlignment.End };
                    //BoxView separator = new BoxView() { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill };
                    contentLayout.Add(itemTitle);
                    contentLayout.Add(new BoxView() { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill });
                }
                if (item.ItemType == "KeyValueList")
                {
                    foreach (Dictionary<string, string?> contentDict in item.ItemContent)
                    {
                        foreach (KeyValuePair<string, string?> kvp in contentDict)
                        {
                            if (kvp.Value != string.Empty && kvp.Value != null)
                            {
                                Label contentLabel = new Label { Text = $"{kvp.Key}: {kvp.Value}" };
                                contentLayout.Add(contentLabel);
                            }
                        }
                    }
                }
                else if (item.ItemType == "text")
                {
                    if (item.ItemContent != null)
                    {
                        foreach (Dictionary<string, string?> contentDict in item.ItemContent)
                        {
                            foreach (KeyValuePair<string, string?> kvp in contentDict)
                            {
                                if (kvp.Value != string.Empty && kvp.Value != null)
                                {
                                    if (kvp.Key == "text")
                                    {
                                        Label contentLabel = new Label { Text = $"{(kvp.Value != null ? kvp.Value : string.Empty)}:" };
                                        contentLayout.Add(contentLabel);
                                    }
                                    else
                                    {
                                        Label contentLabelKey = new Label { Text = $"{(kvp.Key != null ? kvp.Key : string.Empty)}:", FontAttributes = FontAttributes.Bold };
                                        Label contentLabel = new Label { Text = $"{(kvp.Value != null ? kvp.Value : string.Empty)}" };
                                        contentLayout.Add(contentLabelKey);
                                        contentLayout.Add(contentLabel);
                                    }
                                }
                            }
                        }
                        //BoxView separator2 = ;
                        contentLayout.Add(new BoxView { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill });
                    }
                }
                else if (item.ItemType == "CategoryList")
                {
                    List<SearchCategory?>? categories = item.ItemObjects?.Select(c => c as SearchCategory).ToList();
                    CollectionView categoryCollectionView = new CollectionView
                    {
                        ItemsSource = categories,
                    };
                    categoryCollectionView.ItemTemplate = new DataTemplate(() =>
                    {
                        Button categoryButton = new Button
                        {
                            HorizontalOptions = LayoutOptions.Fill,
                            HeightRequest = 65,
                            Padding = 5,
                            Margin = 5,

                        };
                        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer
                        {
                            NumberOfTapsRequired = 1,
                        };
                        tapGestureRecognizer.Tapped += async (s, e) =>
                        {
                            Button? button = (Button?)s;
                            SearchCategory searchOption = (SearchCategory)button.BindingContext;
                            SubClassResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<SubClassResponseModel>(searchOption);
                            SubClassModel subclass = responseObj.ToModel();
                            ResultsPageViewModel viewModel = subclass.ToResultsPageViewModel();
                            ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                            {
                                {  "ViewModel", viewModel   }
                            };
                            await Shell.Current.GoToAsync("ResultsPage", queryOptions);
                        };
                        categoryButton.GestureRecognizers.Add(tapGestureRecognizer);
                        categoryButton.SetBinding(Button.TextProperty, "Name");
                        return categoryButton;
                    });
                    contentLayout.Add(categoryCollectionView);
                }
                else if (item.ItemType == "LevelTable")
                {
                    VerticalStackLayout levelTableGrid = new VerticalStackLayout();
                    //{
                    //	RowDefinitions = new RowDefinitionCollection
                    //	{
                    //                       new RowDefinition { Height = GridLength.Auto },
                    //                       new RowDefinition { Height = GridLength.Auto },
                    //                       new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //		new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    //	},
                    //	ColumnDefinitions = new ColumnDefinitionCollection
                    //	{
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //		new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //	},
                    //};
                    List<string>? TableHeaders = item?.ItemObjects[0] as List<string>;
                    HorizontalStackLayout HeaderRow = new HorizontalStackLayout();
                    foreach (string cell in TableHeaders)
                    {
                        HeaderRow.Add(new Label { Text = cell });
                    }
                    levelTableGrid.Add(HeaderRow);
                    List<string>? RowHeaders = item?.ItemObjects[1] as List<string>;
                    HorizontalStackLayout colTitleRow = new HorizontalStackLayout();
                    foreach (string cell in RowHeaders)
                    {
                        colTitleRow.Add(new Label { Text = cell });
                    }
                    levelTableGrid.Add(colTitleRow);
                    List<ClassLevelsModel>? levels = item?.ItemObjects[2] as List<ClassLevelsModel>;
                    //Label ClassNameLabel = new Label { Text = TableHeaders[0] };
                    //Label SpellSlotsLabel = new Label { Text = TableHeaders[1] };
                    //levelTableGrid.Add(ClassNameLabel, 0, 0);
                    //levelTableGrid.Add(ClassNameLabel, 13, 0);
                    //int i = 0;
                    //foreach (string header in RowHeaders) 
                    //{ 
                    //	levelTableGrid.Add(new Label { Text = header }, i, 1);
                    //}
                    foreach (ClassLevelsModel level in levels)
                    {
                        HorizontalStackLayout row = new HorizontalStackLayout();

                        row.Add(new Label { Text = level.Level.ToString() });
                        row.Add(new Label { Text = level.AbilityScoreBonuses.ToString() });
                        row.Add(new Label { Text = level.ProfBonus.ToString() });
                        row.Add(new Label { Text = string.Join(", ", level.Features.Select(f => f != null ? f.Name : "")) });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.cantrips_known.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_1.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_2.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_3.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_4.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_5.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_6.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_7.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_8.ToString() : string.Empty });
                        row.Add(new Label { Text = level.SpellSlotInfo != null ? level.SpellSlotInfo.spell_slots_level_9.ToString() : string.Empty });
                        levelTableGrid.Add(row);
                    }
                    contentLayout.Add(levelTableGrid);
                }
                else if (item.ItemType == "Markdown")
                {

                    if (item.ItemContent != null)
                    {
                        foreach (Dictionary<string, string?> contentDict in item.ItemContent)
                        {
                            foreach (KeyValuePair<string, string?> kvp in contentDict)
                            {
                                if (kvp.Value != string.Empty && kvp.Value != null)
                                {
                                    if (kvp.Key == "markdown")
                                    {

                                        string rawMarkdownText = kvp.Value;
                                        string htmlMarkDownText = Markdown.ToHtml(rawMarkdownText);
                                        WebView markdownView = new WebView
                                        {
                                            Source = new HtmlWebViewSource()
                                            {
                                                Html = htmlMarkDownText
                                            },
                                            WidthRequest = 300,
                                            HeightRequest = 700,
                                        };
                                        contentLayout.Add(markdownView);
                                    }
                                    else
                                    {
                                        Label contentLabelKey = new Label { Text = $"{(kvp.Key != null ? kvp.Key : string.Empty)}:", FontAttributes = FontAttributes.Bold };
                                        Label contentLabel = new Label { Text = $"{(kvp.Value != null ? kvp.Value : string.Empty)}" };
                                        contentLayout.Add(contentLabelKey);
                                        contentLayout.Add(contentLabel);
                                    }
                                }
                            }
                        }
                        //BoxView separator2 = ;
                        contentLayout.Add(new BoxView { HeightRequest = 3, BackgroundColor = Colors.Gray, HorizontalOptions = LayoutOptions.Fill });
                    }
                }

            }
            return contentLayout;
        }
    }
}