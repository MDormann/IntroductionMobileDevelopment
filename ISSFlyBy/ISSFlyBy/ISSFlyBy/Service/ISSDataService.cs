using System;
using System.Net.Http;
using System.Threading.Tasks;
using ISSFlyBy.Models;
using Newtonsoft.Json;

namespace ISSFlyBy.Services
{
    public class ISSDataService
    {
        private HttpClient httpClient;
        private string baseUrl;

        public ISSDataService()
        {
            httpClient = new HttpClient();
            baseUrl = "http://api.open-notify.org";
        }

        public async Task<ISSCurrentPositionResponse> GetISSCurrentPosition()
        {
			try
			{
				var response = await httpClient.GetAsync($"{baseUrl}/iss-now.json");

				if (!response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();

					throw new HttpRequestException(content);
				}

				string serialized = await response.Content.ReadAsStringAsync();
				ISSCurrentPositionResponse result = JsonConvert.DeserializeObject<ISSCurrentPositionResponse>(serialized);

				return result;
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public async Task<ISSFlyByTimesResponse> GetISSFlyByTime(double Lat, double Long, int PassTimes)
        {
            try
            {
                var response = await httpClient.GetAsync($"{baseUrl}/iss-pass.json?lat={Lat}&lon={Long}&n={PassTimes}");
                
                //Fixer Standort der FOM Siegen, falls kein GPS Sensor im Emulator bereitsteht kann diese Zeile einkommentiert werden.
                //var response = await httpClient.GetAsync($"{baseUrl}/iss-pass.json?lat=50.9085179&lon=8.0054351&n=5");

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    throw new HttpRequestException(content);
                }

                string serialized = await response.Content.ReadAsStringAsync();
                ISSFlyByTimesResponse result = JsonConvert.DeserializeObject<ISSFlyByTimesResponse>(serialized);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ISSCurrentCrew> GetCurrentCrew()
        {
            try
            {
                var response = await httpClient.GetAsync($"{baseUrl}/astros.json");

                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    throw new HttpRequestException(content);
                }

                string serialized = await response.Content.ReadAsStringAsync();
                ISSCurrentCrew result = JsonConvert.DeserializeObject<ISSCurrentCrew>(serialized);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
