using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DnD_Index_App.Models
{
    public class SearchCatagory : ApiObjectInfo // possibly make subclass of ApiObjectInfo class
    {
        public string CatagoryName { get; set; }
        public string CatagoryType { get; set; }
        public string ApiValue { get; set; }
        //public string Url { get { return $"https://www.dnd5eapi.co{Url}"; } set; }
        public ResultType ResultTypeInfo { get; set; }

        public SearchCatagory(string catagoryName, string catagoryType, string apiValue, string url)
            : base(apiValue, catagoryName, url) // Pass required parameters to base constructor
        {
            CatagoryName = catagoryName;
            CatagoryType = catagoryType;
            ApiValue = apiValue;
            Url = $"https://www.dnd5eapi.co{url}";
            ResultTypeInfo = GetResultType(Url);
        }

        public ResultType GetResultType(string url)
        {
            ResultType type = new ResultType();
            if (url.Count(s => s == '/') == 6) 
            {
               type.TypeName = "result";
                if (url.Contains("/spells/")) { type.ResultClass = "spell"; }
                else if (url.Contains("/classes/")) { type.ResultClass = "class"; }
                else if (url.Contains("/equipment/")) { type.ResultClass = "equipment"; }
                else if (url.Contains("/rules/")) { type.ResultClass = "rule"; }
            }
            else if (url.Count(s => s == '/') == 5)
            {
                type.TypeName = "catagory";
                type.ResultClass = "SearchCategory";
            }
            else
            {
                type.TypeName = "unknown";
                type.ResultClass = "unknown";
            }
            return type;
        }
    }

    public class ResultType
    {
        public string TypeName { get; set;  }
        public string ResultClass { get; set; }
    }
}
