using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models
{
    public class SearchCatagory // possibly make subclass of ApiObjectInfo class
    {
        public string CatagoryName { get; set; }
        public string CatagoryType { get; set; }
        public string ApiValue { get; set; }
        public string Url { get; set; }
        public string ResultType { get; set; }

        public SearchCatagory(string catagoryName, string catagoryType, string apiValue, string url, string resultType) 
        {
            CatagoryName = catagoryName;
            CatagoryType = catagoryType;
            ApiValue = apiValue;
            ResultType = resultType; // possibly use regrex on url to determine results type 
            Url = url;
        }
    }
}
