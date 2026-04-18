using DnD_Index_App.Models;
using DnD_Index_App.Models.EquipmentModels;
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
    public class ApiService
    {
        private string _baseUrl = "https://www.dnd5eapi.co";
        public string BaseUrl
        {
            get {  return _baseUrl; }
        }
        public static HttpClient client = new HttpClient();
        public ApiService() { }

        public async Task<object?> GetApiResponse(SearchCatagory searchItem)
        {
            HttpResponseMessage response = await client.GetAsync(searchItem.Url);

            return await response.Content.ReadFromJsonAsync<object?>();
        }

        public static async Task<SpellModel> GetSpellAsync(string index)
        {
            HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/spells/{index}");
            return await response.Content.ReadFromJsonAsync<SpellModel>();
        }

        public static async Task<ClassModel> GetClassAsync(string index)
        {
            HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/classes/{index}");
            return await response.Content.ReadFromJsonAsync<ClassModel>();
        }

        public static async Task<EquipmentModel>? GetEquipmentAsync(string index)
        {
            HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/equipment/{index}");
            response.EnsureSuccessStatusCode();
            string JsonString = await response.Content.ReadAsStringAsync();
            JsonDocument json = JsonDocument.Parse(JsonString);
            JsonElement root = json.RootElement;
            if (root.TryGetProperty("equipment_category", out JsonElement category))
            {
                if (category.TryGetProperty("name", out JsonElement categoryName))
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

        public static async Task<object> GetResourcesForEndpointAsync(SearchCatagory endpoint) 
        {
            HttpResponseMessage response = await client.GetAsync(endpoint.Url);
            if (endpoint.ResultType == "category")
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<ApiObjectInfo>>();
            }
            else if (endpoint.ResultType == "result")
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ApiObjectInfo>();
            }
            else 
            { 
                throw new NotImplementedException();
            }
        }

    }
}
