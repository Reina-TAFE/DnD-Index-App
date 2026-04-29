namespace DnD_Index_App.ViewModels.ResultsPageComponentModels;

public partial class ResultsPageHeaderViewModel : ContentView
{
    public string? HeaderTitle { get; set; }
    public string? HeaderSubtitle { get; set; }
    public Image? HeaderIcon { get; set; }
    public ResultsPageHeaderViewModel()
    {

        Content = new Grid
        {
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            },
        };
    }
}