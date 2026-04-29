using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models.UI
{
    public class SectionContent
    {
        public string? SectionTitle { get; set; } = null;
        public string? ContentType { get; set; } = null;

        public List<Dictionary<string, string>>? Content { get; set; } = null;
    }
}
