using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models
{
    public class ApiObjectInfo
    {
        public string? Index {  get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public ApiObjectInfo(string? index, string? name, string? url) 
        { 
            Index = index;
            Name = name;
            Url = url;
        }

        public override string ToString()
        {
            if (Name != null) { return Name; } else {  return "Missing Item Name."; }
        }
    }
}
