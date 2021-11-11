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
        //Appointment Alerts?
        public ContactInfo PatientInfo { get; set; }
        public List<Allergies> Allergies { get; set; }
        public EmergencyMedication EmergMedication { get; set; }
        public List<DailyMedicine> DailyMedication { get; set; }
        public EmergencyContacts EmergContacts { get; set; }
        public List<Appointment> Appointments { get; set; }
        public MedicalConditions MedicalCondition { get; set; }
        public MedicalSymptoms Symptoms { get; set; }
        public List<AdditionalNeeds> SpecialNeeds { get; set; }
        public CareGivers Caretakers { get; set; }

    }
}
