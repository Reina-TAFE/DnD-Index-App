using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models.ResponseModels
{
    public class EquipmentCategoryResponseModel
    {
        public string? index {  get; set; }
        public string? name {  get; set; }
        public string? url {  get; set; }
        public DateTime? updated_at {  get; set; }
        public List<ApiObjectInfo>? equipment { get; set; }


        public CategoryList ToModel()
        {
            List<SearchCategory> searchOptions = new List<SearchCategory>();
            foreach (ApiObjectInfo result in equipment)
            {
                searchOptions.Add(new SearchCategory(result.Name, null, result.Index, result.Url));
            }
            return new CategoryList(equipment.Count, searchOptions);
        }
    }
}
