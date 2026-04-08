using DnD_Index_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models.EquipmentModels
{
    public class ArmourModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            ApiObjectInfo? gearCategory, List<string>? desc, string? url, Cost? cost,
            int? weight, string? updatedAt, List<(ApiObjectInfo, int)>? contents, 
            List<ApiObjectInfo> properites, string? armourCategory, ArmourClass? armourClass,
            int? strMinimum, bool? stealthDisadvange) : EquipmentModel(index, name, 
            equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properites)
    {
        [JsonPropertyName("armor_category")]
        public string? ArmourCategory { get; set; } = armourCategory;

        [JsonPropertyName("armor_class")]
        public ArmourClass? ArmourClass { get; set; } = armourClass;

        [JsonPropertyName("str_minimum")]
        public int? StrMinimum { get; set; } = strMinimum;

        [JsonPropertyName("stealth_disadvantage")]
        public bool? StealthDisadvange { get; set; } = stealthDisadvange;

    }

    public class ArmourClass
    {
        [JsonPropertyName("base")]
        public string? Base { get; set; }

        [JsonPropertyName("dex_bonus")]
        public bool? DexBonus { get; set; }

        [JsonPropertyName("max_bonus")]
        public int? MaxBonus { get; set; }

        public override string ToString()
        {
            return $"{Base}{((bool)DexBonus ? $" + DEX{((MaxBonus != null) ? $", up to +{MaxBonus}" : null)}" : null)}";
        }
    }
}
