using DnD_Index_App.Models;
using DnD_Index_App.Models.UI;
using DnD_Index_App.ViewModels;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models.EquipmentModels
{
    public class ArmourModel(string? index, string? name, ApiObjectInfo? equipmentCategory,
            ApiObjectInfo? gearCategory, List<string>? desc, string? url, Cost? cost,
            int? weight, string? updatedAt, List<(ApiObjectInfo, int)>? contents,
            List<ApiObjectInfo>? properites, string? armourCategory, ArmourClass? armourClass,
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

        new public ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel header = new ResultsPageHeaderModel(Name, $"{EquipmentCategory?.Name}");
            ResultsPageSectionModel body = new ResultsPageSectionModel("spell", GetSections()); // GetInfoSection() 
            return new ResultsPageViewModel(new ResultsPageHeaderViewModel(header), new ResultsPageSectionViewModel(body));
        }

        new public List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent armourPropertiesSection = GetArmourPropertiesSection();
            SectionContent propertiesSection = GetPropertiesSection();
            //SectionContent infoSection = GetInfoSection();
            sections.Add(armourPropertiesSection);
            sections.Add(propertiesSection);
            return sections;
        }

        public SectionContent GetArmourPropertiesSection()
        {
            SectionContent section = new SectionContent
            {
                SectionTitle = "Armour Properties",
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
                                { "Armour Category", ArmourCategory },
                                { "Armour Class", ArmourClass?.ToString() },
                                { "STR Minimum", StrMinimum.ToString() },
                                { "Stealth Disadvantage", StealthDisadvange.ToString() },
                            }
                        }
                    },
                }
            };
            return section;
        }
    }

    public class ArmourClass
    {
        [JsonPropertyName("base")]
        public int? Base { get; set; }

        [JsonPropertyName("dex_bonus")]
        public bool? DexBonus { get; set; }

        [JsonPropertyName("max_bonus")]
        public int? MaxBonus { get; set; } = null;

        public override string ToString()
        {
            return $"{Base}{((bool)DexBonus ? $" + DEX{((MaxBonus != null) ? $", up to +{MaxBonus}" : null)}" : null)}";
        }
    }
}
