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
        public List<CategoryResult> results { get; set; }

        public CategoryList ToModel()
        {
            List<SearchCategory> newCategories = results.Select(r => new SearchCategory(r.name, $"level {r.level} spells", r.index, r.url)).ToList();
            return new CategoryList(count, newCategories);
        }
    }
}
