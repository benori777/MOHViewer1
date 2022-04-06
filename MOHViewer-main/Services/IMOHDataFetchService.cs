using MOHViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOHViewer.Services
{
    internal interface IMOHDataFetchService
    {

        Task<List<CityDailyData>?> GetAllCityData(string CityName);

        Task<List<City>?> GetAllCities();

    }
}
