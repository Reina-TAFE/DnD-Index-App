using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DnD_Index_App.Models.EquipmentModels
{
    public class VehicleModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            ApiObjectInfo? gearCategory, List<string>? desc, string? url, Cost? cost, int? weight, 
            string? updatedAt, List<(ApiObjectInfo, int)>? contents, List<ApiObjectInfo> properties, 
            string? vehicleCategory, Speed? speed, string? capacity) : EquipmentModel(index, name,
            equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properties)
    {
        [JsonPropertyName("vehicle_category")]
        public string? VehicleCategory { get; set; } = vehicleCategory;

        [JsonPropertyName("speed")]
        public Speed? VehicleSpeed { get; set; } = speed;

        [JsonPropertyName("capacity")]
        public string? VehicleCapacity { get; set; } = capacity;
    }

    public class Speed
    {
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }
    }
}
