using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MOHViewer.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System;

namespace MOHViewer.Services
{
    internal class MOHDataFetchService : IMOHDataFetchService
    {
        private const string BaseURL = "https://data.gov.il/api/3/action/datastore_search?resource_id=8a21d39d-91e3-40db-aca1-f73f7ab1df69&limit=1500&q=";
        private readonly HttpClient m_client = new();

        

        public async Task<List<CityDailyData>?> GetAllCityData(string CityName) 
        {
            var response = await m_client.GetAsync(BaseURL + CityName);
            if (!response.IsSuccessStatusCode) return new List<CityDailyData>();
            string content = await response.Content.ReadAsStringAsync();
            if (Newtonsoft.Json.JsonConvert.DeserializeObject(content) is not JObject responseData) return new List<CityDailyData>();
            if (responseData["result"] is not JObject result) return new List<CityDailyData>();
            var allRecords = result["records"];
            if (null == allRecords)
                return null;
            return allRecords.ToObject<List<CityDailyData>>();
        }

        public async Task<List<City>?> GetAllCities()
        {
            var url = "https://data.gov.il/api/3/action/datastore_search?resource_id=d4901968-dad3-4845-a9b0-a57d027f11ab&limit=1500";
            var response = await m_client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return new List<City>();
            string content = await response.Content.ReadAsStringAsync();
            if (Newtonsoft.Json.JsonConvert.DeserializeObject(content) is not JObject responseData) return new List<City>();
            if (responseData["result"] is not JObject result) return new List<City>();
            var allRecords = result["records"];
            if (null == allRecords)
                return null;
            return allRecords.ToObject<List<City>>();
        }

    }
}
