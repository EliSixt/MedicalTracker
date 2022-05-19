using System.Collections.Generic;

namespace MedicalTracker
{
    public class Condition
    {
        public List<Symptom> Symptoms { get; set; }//symptoms associated with this condition
        public string UserID { get; set; }
        public string Sex { get; set; }
        public double Age { get; set; }
        public string Country { get; set; }
        public string Severity { get; set; }
        public double Date { get; set; }
        //public string TrackableType { get; set; }
        public string ConditionName { get; set; }

        /// <summary>
        /// Overrides string for Condition.
        /// </summary>
        /// <returns>Displays the name of the condition, severity, sex, age, country, and userId.</returns>
        public override string ToString()
        {
            return $"name = {ConditionName}, severity = {Severity}, sex = {Sex}, age = {Age}, country = {Country}, userID = {UserID}";
        }
        /// <summary>
        /// Uses the ConditionName from two Condition objects and returns if the two objects are the same or not.
        /// </summary>
        /// <param name="obj">Other object being compared</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            return ConditionName.ToLower() == ((Condition)obj).ConditionName.ToLower();
        }
        /// <summary>
        /// Uses the .Equals function to determine if two Condition objects are equal to one another.
        /// </summary>
        /// <param name="condition1"></param>
        /// <param name="condition2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(Condition condition1, Condition condition2)
        {
            return condition1.Equals(condition2);
        }
        /// <summary>
        /// Uses the .Equals function to determine if two condition objects are equal to one another.
        /// </summary>
        /// <param name="condition1"></param>
        /// <param name="condition2"></param>
        /// <returns>Bool</returns>
        public static bool operator !=(Condition condition1, Condition condition2)
        {
            return condition1.Equals(condition2);
        }
    }
}
