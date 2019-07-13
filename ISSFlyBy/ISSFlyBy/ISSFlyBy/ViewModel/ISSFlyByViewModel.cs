using ISSFlyBy.Models;
using ISSFlyBy.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ISSFlyBy.ViewModels
{
    public class ISSFlyByViewModel : BaseViewModel
    {
        ISSDataService ISSDataService;
        
        private ISSFlyByTimesResponse _ISSFlyByTimesResponse;
        public ISSFlyByTimesResponse ISSFlyByTimesResponse
        {
            get { return _ISSFlyByTimesResponse; }
            set { SetProperty(ref _ISSFlyByTimesResponse, value); }
        }

        private ObservableCollection<Response> _ISSFlyByResponses;
        public ObservableCollection<Response> ISSFlyByResponses
        {
            get { return _ISSFlyByResponses; }
            set { SetProperty(ref _ISSFlyByResponses, value); }
        }


        public ISSFlyByViewModel()
        {
            ISSDataService = new ISSDataService();
        
            Task.Run(async () => {
                await LoadData();
            });
        }

        public async Task LoadData()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                var response = await ISSDataService.GetISSFlyByTime(location.Latitude, location.Longitude, 10);
                
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ISSFlyByTimesResponse = response;
                    
                    ISSFlyByResponses = new ObservableCollection<Response>(ISSFlyByTimesResponse.Response);

                });
            }


        }
    }
}
