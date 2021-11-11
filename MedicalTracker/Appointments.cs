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

        //DateTime today = DateTime.Now;
        //TimeSpan duration = new TimeSpan(48, 0, 0, 0);
        //DateTime answer = today.Add(duration);
        
        public ContactInfo ContactInfo { get; set; }
        public string BriefDiscription { get; set; }
    }
}
