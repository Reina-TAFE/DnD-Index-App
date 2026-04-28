using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;
using DnD_Index_App.Models.EquipmentModels;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models
{
    public class EquipmentModel : ApiObjectInfo
    {
        [JsonPropertyName("index")]
        public string? Index { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("equipment_category")]
        public ApiObjectInfo? EquipmentCategory { get; set; }

        [JsonPropertyName("gear_category")]
        public ApiObjectInfo? GearCategory { get; set; }

        [JsonPropertyName("desc")]
        public List<string>? Description { get; set; }

        [JsonPropertyName("cost")]
        public Cost? Cost { get; set; }

        [JsonPropertyName("weight")]
        public int? Weight { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("updated_at")]
        public string? UpdatedAt { get; set; }

        [JsonPropertyName("contents")]
        public List<(ApiObjectInfo, int)>? Contents { get; set; }

        [JsonPropertyName("properties")]
        public List<ApiObjectInfo>? Properties { get; set; }


        public EquipmentModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            ApiObjectInfo? gearCategory, List<string>? desc, string? url, Cost? cost,
            int? weight, string? updatedAt, List<(ApiObjectInfo, int)>? contents,
            List<ApiObjectInfo>? properties)
            : base(index, name, url)
        {
            Index = index;
            Name = name;
            EquipmentCategory = equipmentCategory;
            GearCategory = gearCategory;
            Description = desc;
            Cost = cost;
            Weight = weight;
            Url = url;
            UpdatedAt = updatedAt;
            Contents = contents;
            Properties = properties;
        }
    }

    //    public static Type GetEquipmentModelFromResponse(HttpResponseMessage response)
    //    {
    //        string jsonString = response.Content.ReadAsStringAsync().Result;
    //        var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
    //        if (dictionary != null && dictionary.TryGetValue("equipment_category", out object? categoryObj))
    //        {
    //            var categoryDict = categoryObj as JsonElement?;
    //            if (categoryDict.HasValue && categoryDict.Value.TryGetProperty("index", out JsonElement indexElement))
    //            {
    //                string categoryIndex = indexElement.GetString() ?? "";
    //                if (categoryIndex == "weapon")
    //                {
    //                    return typeof(WeaponModel);
    //                }
    //                else if (categoryIndex == "armor")
    //                {
    //                    return typeof(ArmourModel);
    //                }
    //                else if (categoryIndex == "mounts-and-vehicles")
    //                {
    //                    return typeof(VehicleModel);
    //                }
    //                else 
    //                {
    //                    return typeof(EquipmentModel);
    //                }
    //            }
    //        }
    //        return typeof(EquipmentModel);
    //    }
    //}

    public class Cost
    {
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }

        public override string ToString()
        {
            return $"{Quantity} {Unit}";
        }
    }


}
