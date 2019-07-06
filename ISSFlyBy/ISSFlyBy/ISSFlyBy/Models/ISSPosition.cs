using System;
using Xamarin.Forms.Maps;

namespace ISSFlyBy.Models
{
    public class ISSPosition
    {
        public ISSPosition()
        {
            
        }

        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Position Position => new Position(Latitude, Longitude)
;    }
}
