using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;

namespace DnD_Index_App.Models.ResponseModels
{
    public class EquipmentResponseModel
    {
        public List<string> desc { get; set; }
        public List<object> special { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public ApiObjectInfo equipment_category { get; set; }
        public ApiObjectInfo gear_category { get; set; }
        public Cost cost { get; set; }
        public int weight { get; set; }
        public string url { get; set; }
        public DateTime updated_at { get; set; }
        public List<(ApiObjectInfo, int)> contents { get; set; } = [];
        public List<ApiObjectInfo>? properties { get; set; } = [];

        public EquipmentModel ToModel()
        {
            return new EquipmentModel(
                index,
                name,
                equipment_category,
                gear_category,
                desc,
                url,
                cost,
                weight,
                updated_at.ToString("o"),
                contents,
                properties
            );
        }
    }

}
