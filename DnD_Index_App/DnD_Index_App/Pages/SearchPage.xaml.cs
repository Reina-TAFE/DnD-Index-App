using DnD_Index_App.Models;

namespace DnD_Index_App.Pages;

public partial class SearchPage : ContentPage, IQueryAttributable
{
	public String PageName { get; set; } = default!;
	public List<SearchCatagory> CatagoryOptions { get; set; } = default!;
	public String CatagoryType { get; set; } = default!;
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
}