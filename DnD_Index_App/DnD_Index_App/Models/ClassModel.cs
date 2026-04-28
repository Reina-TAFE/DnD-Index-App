using System;
using System.Collections.Generic;
using System.Text;
using DnD_Index_App.Models;

namespace DnD_Index_App.Models
{
    public class ClassModel : ApiObjectInfo
    {
        public string? UpdatedAt { get; set; }
        public int? HitDie { get; set; }
        public string? ClassLevelsResourceUrl { get; set; }
        public MultiClassing? MultiClassing { get; set; }
        public object? SpellCasting { get; set; } = null;
        public string? SpellsListResourceUrl { get; set; } = null;
        public List<StartingEquipment>? StartingEquipment { get; set; }
        public List<OptionSet>? StartingEquipmentOptions { get; set; }
        public List<OptionSet>? ProficiencyChoices { get; set; }
        public List<ApiObjectInfo>? Proficiencies { get; set; }
        public List<ApiObjectInfo>? SavingThrows { get; set; }
        public List<ApiObjectInfo>? Subclasses { get; set; }

        public ClassModel(string index, string name, string url, int hitDie, string classLevelResourceUrl,
            MultiClassing multiClassing, List<StartingEquipment> startingEquipment, List<OptionSet> startingEquipmentOptions,
            List<OptionSet> proficiencyChoices, List<ApiObjectInfo> proficiencies, List<ApiObjectInfo> savingThrows,
            List<ApiObjectInfo> subclasses, object? spellCasting = null, string? spellsListResourceUrl = null)
            : base(index, name, url)
        {
            HitDie = hitDie;
            ClassLevelsResourceUrl = classLevelResourceUrl;
            MultiClassing = multiClassing;
            SpellCasting = spellCasting;
            SpellsListResourceUrl = spellsListResourceUrl;
            StartingEquipment = startingEquipment;
            StartingEquipmentOptions = startingEquipmentOptions;
            ProficiencyChoices = proficiencyChoices;
            Proficiencies = proficiencies;
            SavingThrows = savingThrows;
            Subclasses = subclasses;
        }
    }


    public class MultiClassing
    {
        public List<Prerequisite> prerequisites { get; set; }
        public List<ApiObjectInfo> proficiencies { get; set; }
    }

    public class Prerequisite
    {
        public ApiObjectInfo ability_score { get; set; }
        public int minimum_score { get; set; }
    }

    public class StartingEquipment
    {
        public ApiObjectInfo equipment { get; set; }
        public int quantity { get; set; }
    }

    public class OptionSet
    {
        public string desc { get; set; }
        public int choose { get; set; }
        public string type { get; set; }
        public From from { get; set; }
    }

    public class From
    {
        public string option_set_type { get; set; }
        public List<Option>? options { get; set; }
        public ApiObjectInfo? equipment_category { get; set; }
    }

    public class Option
    {
        public string option_type { get; set; }
        public ApiObjectInfo? item { get; set; }
        public OptionSet? choice { get; set; }
        public int? count { get; set; }
        public ApiObjectInfo? of { get; set; }
    }
}