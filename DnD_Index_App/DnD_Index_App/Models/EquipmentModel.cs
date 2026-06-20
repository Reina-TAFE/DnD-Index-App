using DnD_Index_App.Models;
using DnD_Index_App.Models.EquipmentModels;
using DnD_Index_App.Models.UI;
using DnD_Index_App.ViewModels;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models
{
    public class EquipmentModel : ApiObjectInfo
    {

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
            EquipmentCategory = equipmentCategory;
            GearCategory = gearCategory;
            Description = desc;
            Cost = cost;
            Weight = weight;
            UpdatedAt = updatedAt;
            Contents = contents;
            Properties = properties;
        }

        public ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, $"{EquipmentCategory?.Name}");
            ResultsPageSectionModel body = new ResultsPageSectionModel("spell", GetSections()); // GetInfoSection() 
            return new ResultsPageViewModel(new ResultsPageHeaderViewModel(header), new ResultsPageSectionViewModel(body));
        }

        public List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent propertiesSection = GetPropertiesSection();
            //SectionContent infoSection = GetInfoSection();
            sections.Add(propertiesSection);
            return sections;
        }

        public SectionContent GetPropertiesSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = "Properties",
                ContentType = "standard",
                Content = new List<SectionItem>
                {
                    new SectionItem
                    {
                        SectionItemTitle = "Item Attributes",
                        ItemType = "KeyValueList",
                        ItemContent = new List<Dictionary<string, string?>>
                        {
                            new Dictionary<string, string?>
                            {
                                { "Equipment Category", EquipmentCategory?.Name },
                                { "Weight", Weight?.ToString() },
                                { "Cost", Cost?.ToString() },
                            }
                        }
                    },
                }
            };
            return section;
        }
    }


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
