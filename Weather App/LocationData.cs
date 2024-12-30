using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App
{
    public class LocalNames
    {
        public string? en { get; set; }
        // Add other languages if needed
    }

    public class LocationData
    {

        public string? name { get; set; }
        public LocalNames? local_names { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }

    }
}
