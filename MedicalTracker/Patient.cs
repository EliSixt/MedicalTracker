using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Patient
    {
        //Todo: A lot of information needs an input, look into how to obtain data from EHR(Electronic Health Records)
        //Hospitals use different types of EHR registries, look into just the UofL hospitals in local area.
        //Todo: realtime medicine recall tracking? 
        // history of past medicine?
        public ContactInfo PatientInfo { get; set; }
        public List<Allergies> Allergies { get; set; }
        public EmergencyMedication EmergMedication { get; set; }
        public DailyMedicine DailyMedication { get; set; }
        public string EmergContacts { get; set; }//Its own separate class
        public string Appointments { get; set; }//Its own separate class
        public string MedicalCondition { get; set; }//Its own separate class
        public string Symptoms { get; set; }//Its own separate class
        public string SpecialNeeds { get; set; }//Its own separate class
        public string Caretakers { get; set; }//Its own separate class

    }
}
