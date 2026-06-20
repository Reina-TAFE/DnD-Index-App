using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DnD_Index_App.Models
{
    /// <summary>
    /// Stores information about what a search Category will return, including:
    ///  - the name of the Category/result-object the api will return
    ///  - the associated url
    ///  - the result type information
    ///  - 
    ///  - (for Category endpoints) the type of catagories returned by the endpoint
    ///  - (for Result endpoints) the api index of the endpoint
    /// </summary>
    public class SearchCategory : ApiObjectInfo // possibly make subclass of ApiObjectInfo class
    {
        public string CategoryName { get; set; }
        public string? CategoryType { get; set; }
        public string? ApiValue { get; set; }
        public ResultType ResultTypeInfo { get; set; }

        /// <summary>
        /// Constructor for SearchCategory objects.
        /// </summary>
        /// <param name="categoryName">the name of the Category/result-object</param>
        /// <param name="categoryType">the type of catagories returned by the endpoint</param>
        /// <param name="apiValue">the api index of the endpoint</param>
        /// <param name="url">the associated url</param>
        public SearchCategory(string categoryName, string? categoryType, string? apiValue, string url)
            : base(apiValue, categoryName, url) // Pass required parameters to base constructor
        {
            CategoryName = categoryName;
            CategoryType = categoryType;
            ApiValue = apiValue;
            Url = $"https://www.dnd5eapi.co{url}";
            ResultTypeInfo = GetResultType(Url);
        }

        /// <summary>
        /// Determines what type of response of the api will return for a given URL: either a list of catagories or a specific result. 
        /// Also determines what object class the response data should be deserialized into.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>A ResultType object containing the response type and the object class the response data should be deserialized into.</returns>
        public ResultType GetResultType(string url)
        {
            // create a new blank resultype object.
            ResultType type = new ResultType();

            // determine of the of response based on number of slashes in the url.
            if (url.Count(s => s == '/') == 6 && url.Contains("/equipment-categories/") == false) // 6x '/': Result (e.g. 'https://www.dnd5eapi.co/api/2014/spells/acid-arrow' contains 6x '/') 
            {
               type.TypeName = "result";
                if (url.Contains("/spells/")) { type.ResultClass = "spell"; } // check url for specfic category based on route
                else if (url.Contains("/classes/"))
                {
                    if (url.Contains("/levels"))
                    {
                        type.ResultClass = "levelTable";
                    }
                    else
                    {
                        type.ResultClass = "class"; 
                    }
                }
                else if (url.Contains("/equipment/")) { type.ResultClass = "equipment"; }
                else if (url.Contains("/rule-sections/")) { type.ResultClass = "rule"; }
                else if (url.Contains("/subclasses/")) { type.ResultClass = "subclass"; }
            }
            else if (url.Count(s => s == '/') == 5) // 5x '/': Category (e.g. 'https://www.dnd5eapi.co/api/2014/spells?level=0' contains 5x '/') 
            {
                type.TypeName = "Category";
                type.ResultClass = "SearchCategory"; // catagories get deserialized into new SearchCategory objects.
                if (url.Contains("/spells/") || url.Contains("/spells?level=")) { type.PageType = "SpellsSearchPage"; }
                else if (url.Contains("/equipment-categories/")) { type.PageType = "EquipmentSearchPage"; }
                else if (url.Contains("/rule-sections/")) { type.PageType = "RulesSearchPage"; }
                else if (url.Contains("/subclasses/")) { type.PageType = "ClassesSearchPage"; }
            }
            else if (url.Contains("/equipment-categories/") == true)
            {
                type.TypeName = "Category";
                type.ResultClass = "EquipmentCategory";
                type.PageType = "EquipmentSearchPage";
            }
            else
            {
                // if url does not contain 5 or 6 slashes, set type to unknown.
                type.TypeName = "unknown";
                type.ResultClass = "unknown";
            }
            return type;
        }
    }

    /// <summary>
    /// Stores what type of response of the api will return for a given SearchCategory: either a list of catagories or a specific result. 
    /// Also stores what type of object class the response data should be deserialized into.
    /// </summary>
    public class ResultType
    {
        public string TypeName { get; set;  } // Type of response
        public string ResultClass { get; set; } // Type of object class the response data should be deserialized into
        public string? PageType { get; set; } // Type of page the response data should be associated with
    }
}
