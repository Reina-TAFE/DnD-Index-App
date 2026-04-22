using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models.UI
{
    public class ResultsPageSectionModel
    {
        private string? _sectionType;
        public string SectionType // Determines how the ContentViewModel will formot the content
        {
            get { return (_sectionType != null) ? _sectionType : "standard"; }
            set { _sectionType = value; }
        }
        private string? _sectionTitle;
        public string SectionTitle
        {
            get { return (_sectionTitle != null) ? _sectionTitle : ""; }
            set { _sectionTitle = value; }
        }

        private Dictionary<string, object>? _sectionContent;
        public Dictionary<string, object> SectionContent
        {
            get { return (_sectionContent != null) ? _sectionContent : new Dictionary<string, object>(); }
            set { _sectionContent = value; }
        }

        public ResultsPageSectionModel(string? sectionTitle, Dictionary<string, object>? sectionContent)
        {
            SectionTitle = sectionTitle;
            SectionContent = sectionContent;
        }

        public object ToObject()
        {
            return this as object;
        }
    }
}
