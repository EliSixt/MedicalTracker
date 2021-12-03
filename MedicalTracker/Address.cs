using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Address
    {
        public int BuildingNumber { get; set; } 
        //public int ApptNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIPCode { get; set; }

        public override string ToString()
        {
            return $" {BuildingNumber} {StreetName}, {City}, {State}, {ZIPCode}";
        }
    }
}
