using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Appointment
    {
        public string Title { get; set; }

        private DateTime date;

        //todo: Track upcoming appointments with 
        //DateTime today = DateTime.Now;
        //using TimeSpan. 

        //You can use the DateTime.Add() method to add the time to the date.
        //instead of the above, do DateTime.Parse and you can add the date and time in one swoop. Check for proper formating
        public TimeSpan Time { get; set; }
        public DateTime Date { get => date; set => date = value.Add(Time); }
        public ContactInfo PlaceOfAppointment { get; set; } = new ContactInfo();
        public string BriefDiscription { get; set; }

        public override string ToString()
        {
            return $"Appointment: {Title}";
        }
    }
}
