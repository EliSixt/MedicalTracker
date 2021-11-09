using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Patient
    {
        //A lot of information needs an input, look into how to obtain data from EHR(Electronic Health Records)
        //Hospitals use different types of EHR registries, look into the UofL hospitals in local area.
        public string Name { get; set; }//firstname and lastname ?
        public int PhoneNumber { get; set; }
        public string Address { get; set; } //Its own separate class
        public string Allergies { get; set; }//Its own separate class
        public string EmergencyContacts { get; set; }//Its own separate class
        public string DailyMedication { get; set; }//Its own separate class, history of past medicine
        public string EmergencyMedication { get; set; }//Its own separate class
        public string Appointments { get; set; }//Its own separate class
        public string MedicalCondition { get; set; }//Its own separate class
        public string Symptoms { get; set; }//Its own separate class
        public string SpecialNeeds { get; set; }//Its own separate class
        public string Caretakers { get; set; }//Its own separate class
        public string ContactInfo { get; set; }//Its own separate class? Comprised of address, phoneNumber, email?

    }
}
