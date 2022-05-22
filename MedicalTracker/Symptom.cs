namespace MedicalTracker
{
    public class Symptom
    {
        public string UserID { get; set; }
        public string SymptomName { get; set; }
        public double Date { get; set; }
        public string Severity { get; set; }
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
                return false;
            }

            return SymptomName.ToLower() == ((Symptom)obj).SymptomName.ToLower();
        }
        /// <summary>
        /// Uses the .Equals function to determine if two Symptom objects are not equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator !=(Symptom obj1, Symptom obj2)
        {
            return !obj1.Equals(obj2);
        }
        /// <summary>
        /// Uses the .Equals function to determine if two Symptom objects are equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator ==(Symptom obj1, Symptom obj2)
        {
            return obj1.Equals(obj2);
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
