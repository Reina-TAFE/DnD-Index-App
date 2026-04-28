using DnD_Index_App.Models;
using DnD_Index_App.Models.EquipmentModels;
using DnD_Index_App.Models.ResponseModels;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DnD_Index_App.Services
{
    /// <summary>
    /// A class for handling all API interactions such as making API requests and deserializing the responses.
    /// </summary>
    public class ApiService
    {
        private string _baseUrl = "https://www.dnd5eapi.co";
        public string BaseUrl
        {
            get {  return _baseUrl; }
        }
        public static HttpClient client = new HttpClient();
        public ApiService() { }

        public async Task<object?> GetApiResponse(SearchCategory searchItem)
        {
            HttpResponseMessage response = await client.GetAsync(searchItem.Url);

            return await response.Content.ReadFromJsonAsync<object?>();
        }

        public static async Task<SpellModel> GetSpellAsync(string index)
        {
            HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/spells/{index}");
            SpellResponseModel spellResponseModel = await response.Content.ReadFromJsonAsync<SpellResponseModel>();
            SpellModel spell = spellResponseModel.ToModel();
            return spell;
        }

        public static async Task<ClassModel> GetClassAsync(string index)
        {
            HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/classes/{index}");
            return await response.Content.ReadFromJsonAsync<ClassModel>();
        }

        /// <summary>
        /// Makes an api request and deserializes the response into the correct equipment model type based on the equipment category.
        /// If the equipment Category is not a weapon, armor, or vehicle, it will be deserialized into a generic equipment model object.
        /// </summary>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        public static async Task<EquipmentModel>? GetEquipmentAsync(SearchCategory searchOption)
        {
            HttpResponseMessage response = await client.GetAsync(searchOption.Url);
            response.EnsureSuccessStatusCode();
            string JsonString = await response.Content.ReadAsStringAsync();
            JsonDocument json = JsonDocument.Parse(JsonString);
            JsonElement root = json.RootElement;
            if (root.TryGetProperty("equipment_category", out JsonElement category)) // try to access 'equipment_category' field of the Json response
            {
                if (category.TryGetProperty("name", out JsonElement categoryName)) // try to access 'name' property of the 'equipment_category' json object
                {
                    if (categoryName.ToString() == "Weapon")
                    {
                        return await response.Content.ReadFromJsonAsync<WeaponModel>();
                    }
                    else if (categoryName.ToString() == "Armor")
                    {
                        return await response.Content.ReadFromJsonAsync<ArmourModel>();
                    }
                    else if (categoryName.ToString() == "Mounts and Vehicles")
                    {
                        return await response.Content.ReadFromJsonAsync<VehicleModel>();
                    }
                    else
                    {
                        return await response.Content.ReadFromJsonAsync<EquipmentModel>();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Generic method for making an api request and deserializing the response into a model object of the provided type.
        /// Model type must be a subclass of ApiObjectInfo and the endpoint provided must return a response that can be deserialized into the provided model type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static async Task<T> GetResourcesForEndpointAsync<T>(SearchCategory endpoint)
        {
            try{
                HttpResponseMessage response = await client.GetAsync(endpoint.Url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch { throw new NotImplementedException(); }
        }

        //public static async Task<CategoryList>? GetCategoryListForEndpoint(SearchCategory endpoint)
        //{
        //    try{ 
        //        HttpResponseMessage response = await client.GetAsync(endpoint.Url);

        //    }
        //    catch { throw new NotImplementedException(); }
        //}

    }
}
