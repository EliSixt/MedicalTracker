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
        public ContactInfo PatientInfo { get; set; } = new(); //component made
        public GeneralInfo GeneralInfo { get; set; } = new(); // I could make a small BMI calculator? Component Made
        public List<ContactInfo> EmergencyContacts { get; set; } = new();//list of contact Info? Do I make a component or do i just leave it into a page orrrr??
        public List<ContactInfo> Caretakers { get; set; } = new();
        public List<Allergy> Allergies { get; set; } = new();
        public List<Medicine> EmergencyMedications { get; set; } = new();//like an epipen
        public List<DailyMedicine> DailyMedication { get; set; } = new();
        public List<Appointment> Appointments { get; set; } = new();
        public List<MedicalHistory> MedicalHistory { get; set; } = new();
        public List<Symptom> Symptoms { get; set; }
        public List<UnusualSymptoms> UnusualSymptoms { get; set; } = new(); //check this and change
        public List<AdditionalNeeds> AdditionalNeeds { get; set; } = new();//check this and change
        public override string ToString()
        {
            return $"Patient: {PatientInfo.Name.FirstName} {PatientInfo.Name.LastName}";
        }


    }
}
