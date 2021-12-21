using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
     public class Condition
    {
        public string UserID { get; set; }
        public string Sex { get; set; }
        public double Age { get; set; }
        public string Country { get; set; }
        public string Severity { get; set; }
        public double Date { get; set; }
        //public string TrackableType { get; set; }
        public string Name { get; set; }
    }
}
