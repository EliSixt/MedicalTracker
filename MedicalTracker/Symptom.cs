﻿namespace MedicalTracker
{
    public class Symptom : IValidateable
    {
        public string UserID { get; set; }
        public string SymptomName { get; set; }
        public double Date { get; set; }
        public string Severity { get; set; } //gotta add some sort of gauge for discomfort/pain. Like 0-10
        public string SymptomDescription { get; set; }

        /// <summary>
        /// Overrides string for Symptom.
        /// </summary>
        /// <returns>Displays the name of the symptom, severity, and userId.</returns>
        public override string ToString()
        {
            return $"name = {SymptomName}, symptomDescription= {SymptomDescription} , severity = {Severity}, userID = {UserID}";

        }
        /// <summary>
        /// Compares two Symptom objects. 
        /// Checks if the obj is Null and of the same type, it then checks if the two SymptomName of both Symptom objects are equal.
        /// </summary>
        /// <param name="obj">Symptom object</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType().Equals(obj.GetType()))
            {
                Symptom item = obj as Symptom;
                if (item is null && this is null)
                {
                    return true;
                }
                if (item is null || this is null)
                {
                    return false;
                }
                return this.SymptomName.ToLower() == item.SymptomName.ToLower();
            }
            return false;
        }
        /// <summary>
        /// Uses the .Equals function to determine if two Symptom objects are not equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator !=(Symptom obj1, Symptom obj2)
        {
            if (obj1 is null && obj2 is null)
            {
                return true;
            }
            if (obj1 is null || obj2 is null)
            {
                return false;
            }

            return obj1.Equals(obj2);
        }
        /// <summary>
        /// Uses the .Equals function to determine if two Symptom objects are equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator ==(Symptom obj1, Symptom obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Gets the hashcode of SymptomName lowercased.
        /// </summary>
        /// <returns>HashCode of SymptomName lowercase </returns>
        public override int GetHashCode()
        {
            return SymptomName.ToLower().GetHashCode();
        }

        /// <summary>
        /// Checks a Symptom object to see if it's filled with all the required info.
        /// </summary>
        /// <returns>Returns true if the object is filled.</returns>
        public bool Validate()
        {
            if (string.IsNullOrEmpty(SymptomName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(Severity))
            {
                return false;
            }
            if (string.IsNullOrEmpty(SymptomDescription))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="originalSymptom">Symptom to duplicate from.</param>
        public Symptom(Symptom originalSymptom)
        {
            UserID = originalSymptom.UserID;
            SymptomName = originalSymptom.SymptomName;
            Date = originalSymptom.Date;
            Severity = originalSymptom.Severity;
            SymptomDescription = originalSymptom.SymptomDescription;
        }
        public Symptom()
        {

        }
    }
}
