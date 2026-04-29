using DnD_Index_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models.EquipmentModels
{
    public class WeaponModel(string index, string name, ApiObjectInfo? equipmentCategory,
        ApiObjectInfo? gearCategory, List<string>? desc, string url, Cost? cost, int? weight,
        string updatedAt, string? weaponCategory, string? categoryRange, string? weaponRangeType, WeaponDamage? damage,
        WeaponDamage? twoHandedDamage, WeaponRange? range, WeaponRange? throwRange, List<ApiObjectInfo>? properties,
        List<string>? special, List<(ApiObjectInfo, int)>? contents) : EquipmentModel(index,
        name, equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properties)
    {
        [JsonPropertyName("weapon_category")]
        public string? WeaponCategory { get; set; } = weaponCategory;

        [JsonPropertyName("category_range")]
        public string? WeaponCategoryRange { get; set; } = categoryRange;

        [JsonPropertyName("weapon_range")]
        public string? WeaponRange { get; set; } = weaponRangeType;

        [JsonPropertyName("damage")]
        public WeaponDamage? Damage { get; set; } = damage;

        [JsonPropertyName("two_handed_damage")]
        public WeaponDamage? TwoHandedDamage { get; set; } = twoHandedDamage;

        [JsonPropertyName("range")]
        public WeaponRange? Range { get; set; } = range;

        [JsonPropertyName("throw_range")]
        public WeaponRange? ThrowRange { get; set; } = throwRange;

        [JsonPropertyName("special")]
        public List<string>? Special { get; set; } = special;
    }

    public class WeaponRange
    {
        [JsonPropertyName("normal")]
        public int? Normal { get; set; }

        [JsonPropertyName("long")]
        public int? Long { get; set; }
    }

    public class WeaponDamage
    {
        [JsonPropertyName("damage_dice")]
        public string? DamageDice { get; set; }

        [JsonPropertyName("damage_type")]
        public ApiObjectInfo? DamageType { get; set; }
    }

}
