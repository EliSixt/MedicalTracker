using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Appointments
    {
        public DateTime DateTime { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public string BriefDiscription { get; set; }
    }
}
