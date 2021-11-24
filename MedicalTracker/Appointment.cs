using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Appointment
    {
        private DateTime date = new();

        //todo: Track upcoming appointments with 
        //DateTime today = DateTime.Now;
        //using TimeSpan. 

        //You can use the DateTime.Add() method to add the time to the date.
        public TimeSpan Time { get; set; } = new();
        public DateTime Date { get => date; set => date = value.Add(Time); }
        public ContactInfo PlaceOfAppointment { get; set; } = new ContactInfo();
        public string BriefDiscription { get; set; }
    }
}
