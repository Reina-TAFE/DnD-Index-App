using DnD_Index_App.Models.ResponseModels;
using DnD_Index_App.Models;
using DnD_Index_App.Pages;
using DnD_Index_App.Services;

namespace DnD_Index_App.Pages;

public partial class SearchPage : ContentPage, IQueryAttributable
{
	public String PageName { get; set; } = default!;
	public List<SearchCategory> CategoryOptions { get; set; } = default!;
	public String CategoryType { get; set; } = default!;
    public static ApiService Api = new ApiService();
    public SearchPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if(query.TryGetValue("PageName", out var pageName))
		{
			PageName = pageName as String;
			PageNameLabel.Text = PageName;
		}
        if (query.TryGetValue("CategoryOptions", out var CategoryOptions))
        {
            CategoryOptions = CategoryOptions as List<SearchCategory>;
			SearchCategoriesCollection.ItemsSource = CategoryOptions;
        }
		if(query.TryGetValue("CategoryType", out var CategoryType))
		{
			CategoryType = CategoryType as String;
			CategoryTypeLabel.Text = CategoryType;
		}
    }

    private async void SettingsBtn_Tapped(object? sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new SettingsPage());
        await Shell.Current.GoToAsync("SettingsPage");
    }

    private async void BackBtn_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void SearchOption_Tapped(object sender, TappedEventArgs e)
    {
		Button button = sender as Button;
		SearchCategory searchOption = button.BindingContext as SearchCategory;
		if (searchOption != null)
        {
            if(searchOption.ResultTypeInfo.TypeName == "SearchCategory") 
            {
                SpellCategoryResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<SpellCategoryResponseModel>(searchOption);
                CategoryList newSearchOptions = responseObj.ToModel();
            }
            else if(searchOption.ResultTypeInfo.TypeName == "result")
            {
                if (searchOption.ResultTypeInfo.ResultClass == "spell")
                {
                    SpellResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<SpellResponseModel>(searchOption);
                    SpellModel spell = responseObj.ToModel();
                }
                else if (searchOption.ResultTypeInfo.ResultClass == "class")
                {
                    ClassResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<ClassResponseModel>(searchOption);
                    ClassModel result = responseObj.ToModel();
                }
                else if (searchOption.ResultTypeInfo.ResultClass == "equipment")
                {
                    EquipmentModel? result = await ApiService.GetEquipmentAsync(searchOption);
                }
            }

        }
    }
}