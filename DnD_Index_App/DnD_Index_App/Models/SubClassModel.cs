

using DnD_Index_App;
using DnD_Index_App.Models;
using DnD_Index_App.Models;
using DnD_Index_App.Models.ResponseModels;
using DnD_Index_App.Models.UI;
using DnD_Index_App.ViewModels;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DnD_Index_App.Models
{
    public class SubClassModel : ApiObjectInfo
    {
        [JsonPropertyName("class")]
        public ApiObjectInfo? ParentClass { get; set; }
        public string? SubclassFlavor { get; set; }
        public List<string?>? Desc { get; set; }
        public List<Spell>? Spells { get; set; }
        public string? SubclassLevels { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public SubClassModel(string? index, string? name, string? url, ApiObjectInfo? @class,
            string? subclass_flavor, List<string?>? desc, List<Spell>? spells,
            string? subclass_levels, DateTime? updated_at)
            : base(index, name, url)
        {
            ParentClass = @class;
            SubclassFlavor = subclass_flavor;
            Desc = desc;
            Spells = spells;
            SubclassLevels = subclass_levels;
            UpdatedAt = updated_at;
        }

        public ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel headerModel = new ResultsPageHeaderModel($"{ParentClass.Name}: {Name}", SubclassFlavor);
            ResultsPageSectionModel bodyModel = new ResultsPageSectionModel("subclass", this.GetSections());
            ResultsPageHeaderViewModel headerVM = new ResultsPageHeaderViewModel(headerModel);
            ResultsPageSectionViewModel bodyVM = new ResultsPageSectionViewModel(bodyModel);
            return new ResultsPageViewModel(headerVM, bodyVM);
        }

        public List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent descSection = GetDescSection();
            SectionContent spellsSection = GetSpellsSection();
            sections.Add(descSection);
            sections.Add(spellsSection);
            return sections;
        }

        public SectionContent GetDescSection()
        {
            return new SectionContent
            {
                SectionTitle = "Description",
                ContentType = "standard",
                Content = new List<SectionItem>
                {
                    new SectionItem
                    {
                        SectionItemTitle = "Description",
                        ItemType = "text",
                        ItemContent = new List<Dictionary<string, string?>>
                        {
                            {
                                new Dictionary<string, string?>
                                {
                                    { "text", $"{Desc[0]}" },
                                }
                            }

                        }
                    }
                }
            };
        }

        public SectionContent GetSpellsSection()
        {
            return new SectionContent
            {
                SectionTitle = "Spell List",
                ContentType = "standard",
                Content = new List<SectionItem>
                {
                    {
                        new SectionItem
                        {
                            SectionItemTitle = "Spells List",
                            ItemType = "KeyValueList",
                            ItemContent = new List<Dictionary<string, string?>>
                            {
                                { this.GetSpells() }
                            }
                        }
                    }
                }
            };
        }

        public Dictionary<string, string?>? GetSpells()
        {
            Dictionary<string, string?> spells = new Dictionary<string, string?>();
            foreach (Spell spell in Spells)
            {
                spells[$"{spell.spell.Name}"] = spell.prerequisites[0].name;
            }
            return spells;
        }
    }

    public class Spell
    {
        public List<SpellPrerequisite>? prerequisites { get; set; }
        public ApiObjectInfo? spell { get; set; }
    }

    public class SpellPrerequisite
    {
        public string? index { get; set; }
        public string? type { get; set; }
        public string? name { get; set; }
        public string? url { get; set; }
    }
}
