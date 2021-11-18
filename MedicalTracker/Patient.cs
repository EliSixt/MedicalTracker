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
        public ContactInfo PatientInfo { get; set; } = new();
        public List<ContactInfo> EmergencyContacts { get; set; } = new();
        public List<ContactInfo> Caretakers { get; set; } = new();
        public List<Allergies> Allergies { get; set; } = new();
        public List<Medicine> EmergencyMedications { get; set; } = new();//like an epipen
        public List<DailyMedicine> DailyMedication { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
        public MedicalConditions MedicalCondition { get; set; }
        public MedicalSymptoms Symptoms { get; set; }
        public List<AdditionalNeeds> SpecialNeeds { get; set; } = new();

    }
}
