using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;

namespace DnD_Index_App.Models
{
    public class EquipmentModel
    {
        public string? Index { get; set; }
        public string? Name { get; set; }
        public ApiObjectInfo? EquipmentCatagory { get; set; }
        public List<string>? Description { get; set; }
        public Cost? Cost { get; set; }
        public int? Weight { get; set; }
        public string? Url { get; set; }
        public string? UpdatedAt { get; set; }
        public List<(ApiObjectInfo, int)>? Contents { get; set; }
        public List<ApiObjectInfo>? Properties { get; set; }


        public EquipmentModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            List<string>? desc, string? url, Cost? cost, int? weight, string? updatedAt, 
            List<(ApiObjectInfo, int)>? contents, List<ApiObjectInfo>? properties) 
        { 
            Index = index;
            Name = name;
            EquipmentCatagory = equipmentCategory;
            Description = desc;
            Cost = cost;
            Weight = weight;
            Url = url;
            UpdatedAt = updatedAt;
            Contents = contents;
            Properties = properties;
        }
    }

    public class Cost
    {
        public int? Quantity { get; set; }
        public string? Unit { get; set; }

        public override string ToString()
        {
            return $"{Quantity} {U}";
        }
    }


}
