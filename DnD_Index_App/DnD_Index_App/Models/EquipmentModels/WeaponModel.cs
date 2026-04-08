using DnD_Index_App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models.EquipmentModels
{
    public class WeaponModel(string index, string name, ApiObjectInfo? equipmentCategory,
        ApiObjectInfo? gearCategory,List<string>? desc, string url, Cost? cost, int? weight,
        string updatedAt, string? weaponCatagory, string? weaponRange, Damage? damage,
        Range? range, Range? throwRange, List<ApiObjectInfo>? properties,
        List<string>? special, List<(ApiObjectInfo, int)>? contents) : EquipmentModel(index,
        name, equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properties)
    {
        [JsonPropertyName("weapon_category")]
        public string? WeaponCatagory { get; set; } = weaponCatagory;

        [JsonPropertyName("weapon_range")]
        public string? WeaponRange { get; set; } = weaponRange;

        [JsonPropertyName("damage")]
        public Damage? WeaponDamage { get; set; } = damage;

        [JsonPropertyName("range")]
        public Range? Range { get; set; } = range;

        [JsonPropertyName("throw_range")]
        public Range? ThrowRange { get; set; } = throwRange;

        [JsonPropertyName("special")]
        public List<string>? Special { get; set; } = special;
    }

    public class Range
    {
        [JsonPropertyName("normal")]
        public int? Normal {  get; set; }

        [JsonPropertyName("long")]
        public int? Long { get; set; }
    }

    public class Damage
    {
        [JsonPropertyName("damage_dice")]
        public string? DamageDice { get; set; }

        [JsonPropertyName("damage_type")]
        public ApiObjectInfo? DamageType { get; set; }
    }

}
