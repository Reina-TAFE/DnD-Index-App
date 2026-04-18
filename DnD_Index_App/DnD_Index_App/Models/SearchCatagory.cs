using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Android.Service.Settings.Preferences;

namespace DnD_Index_App.Models
{
    public class SearchCatagory // possibly make subclass of ApiObjectInfo class
    {
        public string CatagoryName { get; set; }
        public string CatagoryType { get; set; }
        public string ApiValue { get; set; }
        public string Url { get; set; }
        public string ResultType { get; set; }

        public SearchCatagory(string catagoryName, string catagoryType, string apiValue, string url) 
        {
            CatagoryName = catagoryName;
            CatagoryType = catagoryType;
            ApiValue = apiValue;
            Url = $"https://www.dnd5eapi.co{url}";
            ResultType = GetResultType(Url);
        }

        public string GetResultType(string url)
        {
            string type = string.Empty;
            if (url.Count(s => s == '/') == 6) 
            {
               type = "result";
            }
            else if (url.Count(s => s == '/') == 5)
            {
                type = "catagory";
            }
            else
            {
                type = "unknown";
            }
            return type;
        }
    }
}
