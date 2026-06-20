using DnD_Index_App.ViewModels;

namespace DnD_Index_App.Pages;

[QueryProperty(nameof(ViewModel), "ViewModel")]
public partial class ResultsPage : ContentPage
{
    private ResultsPageViewModel viewModel;
    public ResultsPageViewModel ViewModel
    {
        get => viewModel;
        set
        {
            OnPropertyChanged();
            if (value != null)
            {
                viewModel = value;
                LoadViewModel(value);
            }
        }
    }
    public ResultsPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public void LoadViewModel(ResultsPageViewModel vm)
    {
        vm.PageContent.Content.Parent = null;
        ResultsPageWrapper.Content = vm.PageContent.Content;
    }

    private async void BackBtn_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}