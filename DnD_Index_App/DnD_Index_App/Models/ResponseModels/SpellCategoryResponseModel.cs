using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DnD_Index_App.Models;

namespace DnD_Index_App.Models.ResponseModels
{
    public class SpellCategoryResponseModel
    {
        public int count {  get; set; }
        public List<Result> results { get; set; }

        public CategoryList ToModel()
        {
            List<SearchCatagory> newCategories = results.Select(r => new SearchCatagory(r.name, $"level {r.level} spells", r.index, r.url)).ToList();
            return new CategoryList(count, newCategories);
        }
    }

    public class Result
    {
        public string index { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public string url { get; set; }
    }
}
