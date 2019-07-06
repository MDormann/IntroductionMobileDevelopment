using System;
using ISSFlyBy.Converter;
using Newtonsoft.Json;

namespace ISSFlyBy.Models
{
    public class ISSCurrentPositionResponse
    {
        public ISSCurrentPositionResponse()
        {
        }

        public string Message { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime Timestamp { get; set; }

        public ISSPosition ISS_Position { get; set; }
    }
}
