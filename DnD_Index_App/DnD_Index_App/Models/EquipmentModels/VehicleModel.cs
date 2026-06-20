using DnD_Index_App.Models.UI;
using DnD_Index_App.ViewModels;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;
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
            string? updatedAt, List<(ApiObjectInfo, int)>? contents, List<ApiObjectInfo>? properties,
            string? vehicleCategory, Speed? speed, string? capacity) : EquipmentModel(index, name,
            equipmentCategory, gearCategory, desc, url, cost, weight, updatedAt, contents, properties)
    {
        [JsonPropertyName("vehicle_category")]
        public string? VehicleCategory { get; set; } = vehicleCategory;

        [JsonPropertyName("speed")]
        public Speed? VehicleSpeed { get; set; } = speed;

        [JsonPropertyName("capacity")]
        public string? VehicleCapacity { get; set; } = capacity;

        new public ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, $"{EquipmentCategory?.Name}");
            ResultsPageSectionModel body = new ResultsPageSectionModel("spell", GetSections());
            return new ResultsPageViewModel(new ResultsPageHeaderViewModel(header), new ResultsPageSectionViewModel(body));
        }

        new public List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent vehiclePropertiesSection = GetVehiclePropertiesSection();
            SectionContent propertiesSection = GetPropertiesSection();
            sections.Add(vehiclePropertiesSection);
            sections.Add(propertiesSection);
            return sections;
        }

        public SectionContent GetVehiclePropertiesSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = "Vehicle Properties",
                ContentType = "standard",
                Content = new List<SectionItem>
                {
                    new SectionItem
                    {
                        SectionItemTitle = "Vehicle Attributes",
                        ItemType = "KeyValueList",
                        ItemContent = new List<Dictionary<string, string?>>
                        {
                            new Dictionary<string, string?>
                            {
                                { "Vehicle Category", VehicleCategory},
                                { "Speed", VehicleSpeed?.ToString() },
                                { "Vehicle Capacity", VehicleCapacity?.ToString() },
                            }
                        }
                    },
                }
            };
            return section;
        }

    }

    public class Speed
    {
        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }

        public override string ToString()
        {
            return $"{Quantity}{Unit}";
        }
    }
}
