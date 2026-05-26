using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models.ResponseModels
{
    public class CategoryListResponseModel
    {
        public int count { get; set; }
        public List<CategoryResult>? results { get; set; }

        public CategoryList ToModel()
        {
            List<SearchCategory> searchOptions = new List<SearchCategory>();
            foreach (CategoryResult result in results) 
            {
                searchOptions.Add(new SearchCategory(result.name, $"Level {result.level}", result.index, result.url));
            }
            return new CategoryList(count, searchOptions);
        }
    }

    public class CategoryResult
    {
        public string? index { get; set; }
        public string? name { get; set; }
        public string? url { get; set; }
        public int? level { get; set; }

    }
}
