using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models
{
    public class EquipmentModel
    {
        public string? Index { get; set; }
        public string? Url { get; set; }
        public string? UpdatedAt { get; set; }
        public string? Name { get; set; }
        public List<string>? Description { get; set; }
        public string? Cost { get; set; }
        public int? Weight { get; set; }
        public List<string>? Special { get; set; }
        public object? EquipmentCatagory { get; set; }
        public List<object>? CategorySpecificProperties { get; set; }
        public List<object>? Contents { get; set; }
        public List<object>? Properties { get; set; }
    }
}
