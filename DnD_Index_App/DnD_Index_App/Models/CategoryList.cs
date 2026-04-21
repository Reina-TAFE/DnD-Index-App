using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;

namespace DnD_Index_App.Models
{
    public class CategoryList(int count, List<SearchCatagory>? categories) : ApiObjectInfo(null, null, null)
    {
        public int Count { get; set; } = count;
        public List<SearchCatagory>? Categories {get; set;} = categories;
    }
}
