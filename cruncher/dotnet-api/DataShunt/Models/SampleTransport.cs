using System;
using System.Collections.Generic;

namespace DataShunt.Models
{
    public partial class SampleTransport
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public string Address { get; set; }
        public int TotalDocks { get; set; }
        public int DocksInService { get; set; }
        public string Status { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Location { get; set; }
    }
}