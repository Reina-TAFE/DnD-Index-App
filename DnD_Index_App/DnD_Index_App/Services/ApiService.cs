using DnD_Index_App.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;

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

        public async Task<object?> GetApiResponse(string endpoint)
        {
            HttpResponseMessage response = await client.GetAsync($"{BaseUrl + endpoint}");
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

        public static async Task<EquipmentModel> GetEquipmentAsync(string index)
        {
            HttpResponseMessage response = await client.GetAsync($"https://www.dnd5eapi.co/api/2014/equipment/{index}");
            return await response.Content.ReadFromJsonAsync<EquipmentModel>();
        }
    }
}
