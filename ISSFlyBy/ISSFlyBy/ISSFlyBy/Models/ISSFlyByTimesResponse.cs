using ISSFlyBy.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISSFlyBy.Models
{
    public class ISSFlyByTimesResponse
    {
        public string Message { get; set; }
        public Request Request { get; set; }
        public List<Response> Response { get; set; }
    }
}
public class Request
{
    public int Altitude { get; set; }
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTime Datetime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Passes { get; set; }
}

public class Response
{
    public int Duration { get; set; }

    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTime Risetime { get; set; }
}