using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models
{
    public class SpellModel
    {
        public string? Index { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? UpdatedAt { get; set; }
        public List<string>? Description { get; set; }
        public int? Level { get; set; }
        public List<string>? HigherLevel { get; set; }
        public object? School { get; set; }
        public string? CastTime { get; set; }
        public string? Range { get; set; }
        public object? AreaOfAffect { get; set; }
        public string? Duration { get; set; }
        public List<string>? Components { get; set; }
        public string? Material {  get; set; }
        public bool? Ritual { get; set; }
        public bool? Concentration { get; set; }
        public string? AttackType { get; set; }
        public object? Damage { get; set; }
        public List<object>? Classes { get; set; }
        public List<object>? Subclasses { get; set; }

        public SpellModel(Task<object> spellproperties)
        {

        }
    }
}
