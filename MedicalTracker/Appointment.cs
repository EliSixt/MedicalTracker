using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Appointment
    {
        //todo: Track upcoming appointments with 
        //DateTime today = DateTime.Now;
        //using TimeSpan. 

        public DateTime DateTime { get; set; }  = new DateTime();
        public ContactInfo PlaceOfAppointment { get; set; } = new ContactInfo();
        public string BriefDiscription { get; set; }
    }
}
