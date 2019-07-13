using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ISSFlyBy.ViewModels;
using ISSFlyBy.Models;
using ISSFlyBy.Services;
using System.Collections.ObjectModel;
using Xamarin.Essentials;

namespace ISSFlyBy.ViewModels
{
    public class ISSLiveViewModel : BaseViewModel
    {
        ISSDataService ISSDataService;

		private ISSCurrentPositionResponse _ISSCurrentPosition;
        public ISSCurrentPositionResponse ISSCurrentPosition
		{
			get { return _ISSCurrentPosition; }
			set { SetProperty(ref _ISSCurrentPosition, value); }
		}

        public ObservableCollection<ISSCurrentPositionResponse> Positions { get; set; }

		public ISSLiveViewModel()
        {
            ISSDataService = new ISSDataService();
            Positions = new ObservableCollection<ISSCurrentPositionResponse>();

            Task.Run(async() =>
            {
                while(true)
				{
                    try
                    {
                        var currentPosition = await ISSDataService.GetISSCurrentPosition();

                        if (currentPosition != null)
                        {
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                ISSCurrentPosition = currentPosition;
                                
                                //Wenn diese Zeile auskommentiert ist, dann wird der ISS Verlauf dargestellt.
                                //Positions.Clear();
                                Positions.Add(currentPosition);
                                
                            });

                            Debug.Print($"[{ISSCurrentPosition?.Timestamp}] | [INFO] Current Position: {ISSCurrentPosition?.ISS_Position?.Latitude} / {ISSCurrentPosition?.ISS_Position?.Longitude}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Print($"[{ISSCurrentPosition.Timestamp}] | [ERROR] Fehlermeldung: {ex}");
                    }

                    System.Threading.Thread.Sleep(5000);
				}
			});
        }
    }
}
