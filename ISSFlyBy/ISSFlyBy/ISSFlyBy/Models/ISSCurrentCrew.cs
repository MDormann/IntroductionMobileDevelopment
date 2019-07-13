using System;
using System.Collections.Generic;
using System.Text;

namespace ISSFlyBy.Models
{
    public class ISSCurrentCrew
    {
        public List<Person> People { get; set; }
        public int Number { get; set; }
        public string Message { get; set; }
    }
}
