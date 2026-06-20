using DnD_Index_App.Models.UI;
using DnD_Index_App.ViewModels;
using DnD_Index_App.ViewModels.ResultsPageComponentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models
{
    public class RuleModel : ApiObjectInfo
    {
        public string? Description { get; set; }
        public string? UpdatedAt { get; set; }

        public RuleModel(string? index, string? name, string? url, string? desc, string? updatedAt)
            : base(index, name, url)
        {
            Description = desc;
            UpdatedAt = updatedAt;
        }

        public ResultsPageViewModel ToResultsPageViewModel()
        {
            ResultsPageHeaderModel headerModel = new ResultsPageHeaderModel(Name, string.Empty);
            ResultsPageSectionModel bodyModel = new ResultsPageSectionModel(string.Empty, GetSections());
            ResultsPageHeaderViewModel headerVM = new ResultsPageHeaderViewModel(headerModel);
            ResultsPageSectionViewModel bodyVM = new ResultsPageSectionViewModel(bodyModel);
            return new ResultsPageViewModel(headerVM, bodyVM);
        }

        public List<SectionContent> GetSections()
        {
            List<SectionContent> sections = new List<SectionContent>();
            SectionContent descSection = GetDescSection();
            sections.Add(descSection);
            return sections;
        }

        public SectionContent GetDescSection()
        {
            return new SectionContent
            {
                SectionTitle = Description,
                ContentType = "Rule",
                Content = new List<SectionItem>
                {
                    {
                        new SectionItem
                        {
                            SectionItemTitle = string.Empty,
                            ItemType = "Markdown",
                            ItemContent = new List<Dictionary<string, string?>>
                            {
                                {
                                    new Dictionary<string, string?>
                                    {
                                        { "markdown", Description }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
