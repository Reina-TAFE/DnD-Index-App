using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models
{
    public class ClassModel
    {
        public string? Index { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? UpdatedAt { get; set; }
        public int? HitDie { get; set; }
        public string? ClassLevelsResourceUrl { get; set; }
        public object? MultiClassing { get; set; }
        public object? SpellCasting { get; set; }
        public string? SpellsListResourceUrl { get; set; }
        public List<object>? StartingEquipment { get; set; }
        public List<object>? StartingEquipmentOptions { get; set; }
        public List<object>? ProficiencyChoices { get; set; }
        public List<object>? Proficiencies { get; set; }
        public List<object>? SavingThrows { get; set; }
        public List<object>? Subclasses { get; set; }

        public ClassModel(Task<object> classProperties) 
        {
            
        }
    }
}