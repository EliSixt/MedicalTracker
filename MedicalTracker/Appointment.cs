using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Appointment
    {
        public DateTime DateTime { get; set; }
        //todo: Track upcoming appointments with 
        //DateTime today = DateTime.Now;
        //using TimeSpan. 
        
        public ContactInfo ContactInfo { get; set; }
        public string BriefDiscription { get; set; }
    }
}
