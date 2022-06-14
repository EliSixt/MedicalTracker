﻿using System.Collections.Generic;

namespace MedicalTracker
{
    public class Patient
    {
        //Todo: A lot of information needs an input, look into how to obtain data from EHR(Electronic Health Records)
        //Hospitals use different types of EHR registries, look into just the UofL hospitals in local area.
        //Todo: realtime medicine recall tracking? 
        // history of past medicine?
        //Appointment Alerts?
        public int ID { get; set; }
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

        /// <summary>
        /// Overrides string for Patient
        /// </summary>
        /// <returns>Displays all the variables of Patient and their values.</returns>
        public override string ToString()
        {
            return $"Patient: {PatientInfo.Name.FirstName} {PatientInfo.Name.LastName}";
        }
        /// <summary>
        /// Uses the GeneralInfo objects from Patient and returns if the two objects are the same or not.
        /// </summary>
        /// <param name="obj">Other object being compared.</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            //return (obj == null) || this.GetType().Equals(obj.GetType()) ? false : ((Patient)obj).GeneralInfo == GeneralInfo;
            Patient item = obj as Patient;
            if (item is null && this is null)
            {
                return true;
            }
            if (item is null || this is null)
            {
                return false;
            }
            return this.GeneralInfo.Name.Equals(item.GeneralInfo.Name);
        }
        /// <summary>
        /// Uses the .Equals function to determine if two patient objects are equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(Patient obj1, Patient obj2)  //TODO: null checks
        {
            if (obj1 is null && obj2 is null)
                return true;

            if (obj1 is null || obj2 is null)
                return false;

            return obj1.Equals(obj2);
        }
        /// <summary>
        ///  Uses the .Equals function to determine if two patient objects are not equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>Bool</returns>
        public static bool operator !=(Patient obj1, Patient obj2)
        {
            if (obj1 is null && obj2 is null) //Both null so both are equal?
            {
                return false;
            }
            if (obj1 is null || obj2 is null) // One is null and one isn't, so they are not-equal, true?
            {
                return true;
            }
            return !obj1.Equals(obj2);
        }
        /// <summary>
        /// Gets the hashcode of the firstName and lastName lowercased.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return (this.GeneralInfo.Name.FirstName.ToLower() + this.GeneralInfo.Name.LastName.ToLower()).GetHashCode();
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="originalPatient">Patient to duplicate from.</param>
        public Patient(Patient originalPatient)
        {
            ID = originalPatient.ID;
            PatientInfo = originalPatient.PatientInfo;
            GeneralInfo = originalPatient.GeneralInfo;
            EmergencyContacts = originalPatient.EmergencyContacts;
            Caretakers = originalPatient.Caretakers;
            Allergies = originalPatient.Allergies;
            EmergencyMedications = originalPatient.EmergencyMedications;
            DailyMedication = originalPatient.DailyMedication;
            Appointments = originalPatient.Appointments;
            MedicalHistory = originalPatient.MedicalHistory;
            Symptoms = originalPatient.Symptoms;
            UnusualSymptoms = originalPatient.UnusualSymptoms;
            AdditionalNeeds = originalPatient.AdditionalNeeds;
        }

        public Patient()
        {

        }
    }
}
