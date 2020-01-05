using System;
using System.Collections.Generic;

namespace DataShunt.Models
{
    public partial class SampleGovernment
    {
        public string Name { get; set; }
        public string LocationType { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Location { get; set; }
    }
}