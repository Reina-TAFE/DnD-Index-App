using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;

namespace DnD_Index_App.Models.EquipmentModels
{
    public class WeaponModel(string index, string name, ApiObjectInfo? equipmentCategory,
            List<string>? desc, string url, Cost? cost, int? weight, string updatedAt, 
            string? weaponCatagory, string? weaponRange, string? damageDice,
            string? damageType, Range? range, List<ApiObjectInfo>? properties,
            List<string>? special, List<(ApiObjectInfo, int)>? contents) : EquipmentModel(index,
                name, equipmentCategory, desc, url, cost, weight, updatedAt, contents, properties)
    {
        public string? WeaponCatagory { get; set; } = weaponCatagory;
        public string? WeaponRange { get; set; } = weaponRange;
        public string? DamageDice { get; set; } = damageDice;
        public string? DamageType { get; set; } = damageType;
        public Range? Range { get; set; } = range;
        public List<string>? Special { get; set; } = special;
    }

    public class Range
    {
        public int? Normal {  get; set; }
        public int? Long { get; set; }
        public int? Thrown { get; set; }
    }

}
