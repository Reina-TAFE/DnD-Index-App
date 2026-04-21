using DnD_Index_App.Models;
using DnD_Index_App.Pages;
using DnD_Index_App.Services;

namespace DnD_Index_App.Pages;

public partial class SearchPage : ContentPage, IQueryAttributable
{
	public String PageName { get; set; } = default!;
	public List<SearchCatagory> CatagoryOptions { get; set; } = default!;
	public String CatagoryType { get; set; } = default!;
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
        if (query.TryGetValue("CatagoryOptions", out var catagoryOptions))
        {
            CatagoryOptions = catagoryOptions as List<SearchCatagory>;
			SearchCatagoriesCollection.ItemsSource = CatagoryOptions;
        }
		if(query.TryGetValue("CatagoryType", out var catagoryType))
		{
			CatagoryType = catagoryType as String;
			CatagoryTypeLabel.Text = CatagoryType;
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
		SearchCatagory searchOption = button.BindingContext as SearchCatagory;
		if (searchOption != null)
        {
            if(searchOption.ResultTypeInfo.TypeName == "SearchCategory") 
            {
                CategoryList newSearchOptions = await ApiService.GetCategoryListForEndpoint(searchOption);
            }
            else if(searchOption.ResultTypeInfo.TypeName == "result")
            {
                if (searchOption.ResultTypeInfo.ResultClass == "spell")
                {
                    SpellModel result = await ApiService.GetResourcesForEndpointAsync<SpellModel>(searchOption);
                }
            }

        }
    }
}