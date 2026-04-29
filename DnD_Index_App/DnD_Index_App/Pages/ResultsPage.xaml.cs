using DnD_Index_App.ViewModels;

namespace DnD_Index_App.Pages;

public partial class ResultsPage : ContentPage
{
	public ResultsPage(ResultsPageViewModel viewModel)
	{
		InitializeComponent();
		ResultsPageWrapper.Content = viewModel.Content;
	}
}