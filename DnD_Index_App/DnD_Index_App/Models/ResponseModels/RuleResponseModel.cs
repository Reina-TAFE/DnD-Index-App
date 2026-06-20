using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Index_App.Models.ResponseModels
{
    public class RuleResponseModel
    {
        public string? name { get; set; }
        public string? index { get; set; }
        public string? desc { get; set; }
        public string? url { get; set; }
        public string? updated_at { get; set; }

        public RuleModel ToModel() 
        {
            return new RuleModel(
                index,
                name,
                url,
                desc,
                updated_at
                );
        }
    }
}
