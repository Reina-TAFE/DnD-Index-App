using DnD_Index_App.Models;
using DnD_Index_App.Models.EquipmentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models.ResponseModels
{
    public class UniversalEquipmentResponseModel
    {
        public List<string> desc { get; set; }
        public List<string> special { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public ApiObjectInfo equipment_category { get; set; }
        public ApiObjectInfo? gear_category { get; set; } = null;
        public Cost cost { get; set; }
        public int weight { get; set; }
        public string url { get; set; }
        public DateTime updated_at { get; set; }
        public List<(ApiObjectInfo, int)> contents { get; set; } = [];
        public List<ApiObjectInfo>? properties { get; set; } = [];

        // Weapon Properties
        [JsonPropertyName("weapon_category")]
        public string? WeaponCategory { get; set; } = null;

        [JsonPropertyName("weapon_range")]
        public string? WeaponRangeType { get; set; } = null;

        [JsonPropertyName("category_range")]
        public string? CategoryRange { get; set; } = null;

        [JsonPropertyName("range")]
        public WeaponRange? Range { get; set; } = null;

        [JsonPropertyName("throw_range")]
        public WeaponRange? ThrowRange { get; set; } = null;

        [JsonPropertyName("damage")]
        public WeaponDamage? Damage { get; set; } = null;

        [JsonPropertyName("two_handed_damage")]
        public WeaponDamage? TwoHandedDamage { get; set; } = null;

        // Armour Properties
        [JsonPropertyName("armor_category")]
        public string? ArmourCategory { get; set; } = null;

        [JsonPropertyName("armor_class")]
        public ArmourClass? ArmourClass { get; set; } = null;

        [JsonPropertyName("str_minimum")]
        public int? StrMinimum { get; set; } = null;

        [JsonPropertyName("stealth_disadvantage")]
        public bool? StealthDisadvange { get; set; } = null;

        // Vehicle Properties
        [JsonPropertyName("vehicle_category")]
        public string? VehicleCategory { get; set; } = null;

        [JsonPropertyName("speed")]
        public Speed? VehicleSpeed { get; set; } = null;

        [JsonPropertyName("capacity")]
        public string? VehicleCapacity { get; set; } = null;

        public EquipmentModel ToEquipmentModel()
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

        public WeaponModel ToWeaponModel()
        {
            return new WeaponModel(
                index,
                name,
                equipment_category,
                gear_category,
                desc,
                url,
                cost,
                weight,
                updated_at.ToString("o"),
                WeaponCategory,
                CategoryRange,
                WeaponRangeType,
                Damage,
                TwoHandedDamage,
                Range,
                ThrowRange,
                properties,
                special,
                contents
            );
        }

        public ArmourModel ToArmourModel()
        {
            return new ArmourModel(
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
                properties,
                ArmourCategory,
                ArmourClass,
                StrMinimum,
                StealthDisadvange
            );
        }

        public VehicleModel ToVehicleModel()
        {
            return new VehicleModel(
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
                properties,
                VehicleCategory,
                VehicleSpeed,
                VehicleCapacity
            );
        }
    }

}
