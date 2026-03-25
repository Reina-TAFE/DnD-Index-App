using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models
{
    public class SearchCatagory
    {
        public string CatagoryName { get; set; }
        public string CatagoryType { get; set; }
        public string ApiValue { get; set; }

        public SearchCatagory(string catagoryName, string catagoryType, string apiValue) 
        {
            CatagoryName = catagoryName;
            CatagoryType = catagoryType;
            ApiValue = apiValue;
        }
    }
}
