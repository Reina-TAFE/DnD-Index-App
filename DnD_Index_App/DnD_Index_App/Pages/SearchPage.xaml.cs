namespace DnD_Index_App.Pages;

public partial class SearchPage : ContentPage, IQueryAttributable
{
	public String PageName { get; set; }
	public List<String> CatagoryOptions { get; set; } = default!;
	public SearchPage()
	{
		InitializeComponent();
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if(query.TryGetValue("PageName", out var pageName))
		{
			PageName = pageName as String;
		}
        if (query.TryGetValue("CatagoryOptions", out var catagoryOptions))
        {
            CatagoryOptions = catagoryOptions as List<String>;
        }
    }
}