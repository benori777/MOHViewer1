using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using MOHViewer.Services;
using MOHViewer.Models;

namespace MOHViewer.ViewModels
{
    internal class DataViewerViewModel : BindableBase  
    {

        #region Services

        private readonly IMOHDataFetchService _srvMOHDataFetchService;

        #endregion

        #region Properties

        private List<City> _lstCities;

        public List<City> lstCities
        {
            get { return _lstCities; }
            set {SetProperty(ref _lstCities , value); }
        }

        private string _selectedCity;

        public string selectedCity
        {
            get { return _selectedCity; }
            set 
            {
                SetProperty(ref _selectedCity, value);
                UpdateList();
            }
        }

        private List<CityDailyData> _lstCityDailyData;

        public List<CityDailyData> lstCityDailyData
        {
            get { return _lstCityDailyData; }
            set { SetProperty(ref _lstCityDailyData, value); }
        }

        private bool _IsWaiting;

        public bool IsWaiting
        {
            get { return _IsWaiting; }
            set { SetProperty(ref _IsWaiting, value); }
        }

        #endregion

        #region Activate

        public DataViewerViewModel(IMOHDataFetchService srvMOHDataFetchService)
        {
            _srvMOHDataFetchService = srvMOHDataFetchService;

            ActivateViewModel();

        }

        private async void ActivateViewModel()
        {
            IsWaiting = true;

            var lst = await _srvMOHDataFetchService.GetAllCities();

            try
            {
                lstCities = lst ?? new List<City>();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Error retrieving data from service: " + ex);
            }
            finally
            {
                IsWaiting = false;
            }
            
        }
        #endregion

        #region Functionality

        private async void UpdateList()
        {
            IsWaiting = true;

            var lst = await _srvMOHDataFetchService.GetAllCityData(selectedCity);

            try
            {
                lstCityDailyData = lst ?? new List<CityDailyData>();
            }
            catch (AggregateException   ex)
            {
                Console.WriteLine("Error retrieving data from service: " + ex);
            }
            finally
            {
                IsWaiting = false;
            }
        }

            #endregion

        }
    }
