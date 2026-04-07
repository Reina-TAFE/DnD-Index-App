using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;

namespace DnD_Index_App.Models.EquipmentModels
{
    public class ArmourModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            List<string>? desc, string? url, Cost? cost, int? weight, string? updatedAt, 
            List<(ApiObjectInfo, int)>? contents, List<ApiObjectInfo> properites,
            string? armourCategory, ArmourClass? armourClass,
            int? strMinimum, bool? stealthDisadvange) : EquipmentModel(index, name, 
                equipmentCategory, desc, url, cost, weight, updatedAt, contents, properites)
    {
        public string? ArmourCategory { get; set; } = armourCategory;
        public ArmourClass? ArmourClass { get; set; } = armourClass;
        public int? StrMinimum { get; set; } = strMinimum;
        public bool? StealthDisadvange { get; set; } = stealthDisadvange;

    }

    public class ArmourClass
    {
        public string? Base { get; set; }
        public bool? DexBonus { get; set; }
        public int? MaxBonus { get; set; }

        public override string ToString()
        {
            return $"{Base}{((bool)DexBonus ? $" + DEX{((MaxBonus != null) ? $", up to +{MaxBonus}" : null)}" : null)}";
        }
    }
}
