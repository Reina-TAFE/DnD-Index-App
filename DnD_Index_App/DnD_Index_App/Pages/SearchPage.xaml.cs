using DnD_Index_App.Models;
using DnD_Index_App.Models.EquipmentModels;
using DnD_Index_App.Models.ResponseModels;
using DnD_Index_App.Pages;
using DnD_Index_App.Services;
using DnD_Index_App.ViewModels;
using System.Collections.Generic;

namespace DnD_Index_App.Pages;

[QueryProperty(nameof(PageName), "PageName")]
[QueryProperty(nameof(PageType), "PageType")]
[QueryProperty(nameof(CategoryOptions), "CategoryOptions")]
[QueryProperty(nameof(CategoryType), "CategoryType")]
public partial class SearchPage : ContentPage, IQueryAttributable
{
	public String PageName { get; set; } = default!;
	public String PageType { get; set; } = default!;
	public List<SearchCategory> CategoryOptions { get; set; } = default!;
	public String CategoryType { get; set; } = default!;
    public static ApiService Api = new ApiService();
    public int HeadingFontSize = PreferenceManager.GetHeadingFontSize();
    public int BodyFontSize = PreferenceManager.GetBodyFontSize();
    public SearchPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if(query.TryGetValue("PageName", out var pageName))
		{
			PageName = (string)pageName;
			PageNameLabel.Text = PageName;
            PageNameLabel.FontSize = HeadingFontSize;
        }
        if(query.TryGetValue("PageType", out var pageType))
        {
            PageType = (string)pageType;
            if (PageType == "SpellsSearchPage")
            {
                PageIcon.Source = ImageSource.FromFile("cleric_symbol.png");
            }
            else if (PageType == "ClassesSearchPage")
            {
                PageIcon.Source = ImageSource.FromFile("paladin.png");
            }
            else if (PageType == "EquipmentSearchPage")
            {
                PageIcon.Source = ImageSource.FromFile("fighter_symbol.png");
            }
            else if (PageType == "RulesSearchPage")
            {
                PageIcon.Source = ImageSource.FromFile("scroll.png");
            }
        }
        if (query.TryGetValue("CategoryOptions", out var categoryOptions))
        {
            CategoryOptions = (List<SearchCategory>) categoryOptions;
			SearchCategoriesCollection.ItemsSource = CategoryOptions;
        }
		if(query.TryGetValue("CategoryType", out var categoryType))
		{
			CategoryType = (string)categoryType;
			CategoryTypeLabel.Text = CategoryType;
            CategoryTypeLabel.FontSize = BodyFontSize;
		}
    }

    private async void SettingsBtn_Tapped(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }

    private async void BackBtn_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void NavSearchBtn_Tapped(object sender, TappedEventArgs e)
    {
        ImageButton searchPageOption = (ImageButton)sender;
        IDictionary<string, object> queryOptions = new Dictionary<string, object>();
        if (searchPageOption.StyleId == "NavSpellsBtn")
        {
            queryOptions = await App.PageQueryOptions("SpellSearchPage");
        }
        else if (searchPageOption.StyleId == "NavClassesBtn")
        {
            queryOptions = await App.PageQueryOptions("ClassesSearchPage");
        }
        else if (searchPageOption.StyleId == "NavEquipmentBtn")
        {
            queryOptions = await App.PageQueryOptions("EquipmentSearchPage");
        }
        else if (searchPageOption.StyleId == "NavRulesBtn")
        {
            queryOptions = await App.PageQueryOptions("RulesSearchPage");
        }
        await Shell.Current.GoToAsync("SearchPage", queryOptions);
    }

    private async void SearchOption_Tapped(object sender, TappedEventArgs e)
    {
		Button button = (Button)sender;
		SearchCategory searchOption = (SearchCategory)button.BindingContext;
		if (searchOption != null)
        {
            if(searchOption.ResultTypeInfo.TypeName == "Category") 
            {
                CategoryList newSearchOptions = new CategoryList(null, null);
                if (searchOption.ResultTypeInfo.ResultClass == "EquipmentCategory")
                {
                    EquipmentCategoryResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<EquipmentCategoryResponseModel>(searchOption);
                    newSearchOptions = responseObj.ToModel();
                }
                else
                {
                    CategoryListResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<CategoryListResponseModel>(searchOption);
                    newSearchOptions = responseObj.ToModel();
                }
                ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                    {
                        {"PageName", $"{searchOption.CategoryName.ToString()}" },
                        {"PageType", $"{searchOption.ResultTypeInfo.PageType}" },
                        {"CategoryType", searchOption.CategoryType != null ? searchOption.CategoryType.ToString() : "Options:" },
                        {"CategoryOptions", newSearchOptions.Categories},
                    };
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Shell.Current.GoToAsync("SearchPage", queryOptions);
                });
            }
            else if(searchOption.ResultTypeInfo.TypeName == "result")
            {
                if (searchOption.ResultTypeInfo.ResultClass == "spell")
                {
                    SpellResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<SpellResponseModel>(searchOption);
                    SpellModel spell = responseObj.ToModel();
                    ResultsPageViewModel viewModel = spell.ToResultsPageViewModel();
                    ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                    {
                        {  "ViewModel", viewModel   }
                    };
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync("ResultsPage", queryOptions);
                    });
                }
                else if (searchOption.ResultTypeInfo.ResultClass == "class")
                {
                    ClassResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<ClassResponseModel>(searchOption);
                    ClassModel classObject = responseObj.ToModel();
                    ResultsPageViewModel viewModel = classObject.ToResultsPageViewModel();
                    ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                    {
                        {  "ViewModel", viewModel   }
                    };
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync("ResultsPage", queryOptions);
                    });
                }
                else if (searchOption.ResultTypeInfo.ResultClass == "levelTable")
                {
                    List<ClassLevelsResponseModel> responseObj = await ApiService.GetResourceListForEndpointAsync<List<ClassLevelsResponseModel>>(searchOption);
                    LevelsTableResponseModel table = new LevelsTableResponseModel { root = responseObj };
                    ClassLevelsTableModel levelTableObject = table.ToModel();
                    ResultsPageViewModel viewModel = levelTableObject.ToResultsPageViewModel();
                    ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                    {
                        {  "ViewModel", viewModel   }
                    };
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync("ResultsPage", queryOptions);
                    });
                }
                else if (searchOption.ResultTypeInfo.ResultClass == "equipment")
                {
                    UniversalEquipmentResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<UniversalEquipmentResponseModel>(searchOption);
                    ResultsPageViewModel? viewModel = null;
                    if(responseObj.equipment_category.Name == "Weapon")
                    {
                        WeaponModel weapon = responseObj.ToWeaponModel();
                        viewModel = weapon.ToResultsPageViewModel();
                    }
                    else if (responseObj.equipment_category.Name == "Armor")
                    {
                        ArmourModel armour = responseObj.ToArmourModel();
                        viewModel = armour.ToResultsPageViewModel();
                    }
                    else if (responseObj.equipment_category.Name == "Mounts and Vehicles")
                    {
                        VehicleModel vehicle = responseObj.ToVehicleModel();
                        viewModel = vehicle.ToResultsPageViewModel();
                    }
                    else
                    {
                        EquipmentModel item = responseObj.ToEquipmentModel();
                        viewModel = item.ToResultsPageViewModel();
                    }

                    ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                    {
                        {  "ViewModel", viewModel   }
                    };

                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync("ResultsPage", queryOptions);
                    });
                }
                else if (searchOption.ResultTypeInfo.ResultClass == "rule")
                {
                    RuleResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<RuleResponseModel>(searchOption);
                    RuleModel subClassObject = responseObj.ToModel();
                    ResultsPageViewModel viewModel = subClassObject.ToResultsPageViewModel();
                    ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                    {
                        {  "ViewModel", viewModel   }
                    };
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync("ResultsPage", queryOptions);
                    });
                }
                else if (searchOption.ResultTypeInfo.ResultClass == "subclass")
                {
                    SubClassResponseModel responseObj = await ApiService.GetResourcesForEndpointAsync<SubClassResponseModel>(searchOption);
                    SubClassModel subClassObject = responseObj.ToModel();
                    ResultsPageViewModel viewModel = subClassObject.ToResultsPageViewModel();
                    ShellNavigationQueryParameters queryOptions = new ShellNavigationQueryParameters
                    {
                        {  "ViewModel", viewModel   }
                    };
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Shell.Current.GoToAsync("ResultsPage", queryOptions);
                    });
                }
            }

        }
    }
}