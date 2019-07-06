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
    }
}
