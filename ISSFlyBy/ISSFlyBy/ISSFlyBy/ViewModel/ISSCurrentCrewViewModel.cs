using ISSFlyBy.Models;
using ISSFlyBy.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ISSFlyBy.ViewModels
{
    public class ISSCurrentCrewViewModel : BaseViewModel
    {
        ISSDataService ISSDataService;
        
        private ISSCurrentCrew _ISSCurrentCrew;
        public ISSCurrentCrew ISSCurrentCrew
        {
            get { return _ISSCurrentCrew; }
            set { SetProperty(ref _ISSCurrentCrew, value); }
        }

        public ISSCurrentCrewViewModel()
        {
            ISSDataService = new ISSDataService();
        
            Task.Run(async () => {
                await LoadData();
            });
        }

        public async Task LoadData()
        {
            var response = await ISSDataService.GetCurrentCrew();
            //var response = await ISSDataService.GetISSFlyByTime(50.9085179f, 8.0054351f, 10);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                ISSCurrentCrew = response;
            });
        }
    }
}
