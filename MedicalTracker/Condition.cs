using System.Collections.Generic;

namespace MedicalTracker
{
    public class Condition
    {
        public string ConditionName { get; set; }
        public List<Symptom> Symptoms { get; set; }//symptoms associated with this condition
        public string UserID { get; set; }
        public string Sex { get; set; }
        public double Age { get; set; }
        public string Country { get; set; }
        public string Severity { get; set; }
        public double Date { get; set; } //date of the condition
        //public string TrackableType { get; set; }

        /// <summary>
        /// Overrides string for Condition.
        /// </summary>
        /// <returns>Displays the name of the condition, severity, sex, age, country, and userId.</returns>
        public override string ToString()
        {
            return $"name = {ConditionName}, severity = {Severity}, sex = {Sex}, age = {Age}, country = {Country}, userID = {UserID}";
        }

        /// <summary>
        /// Checks if the obj is Null and of the same type,
        /// uses the ConditionName from two Condition objects and returns if the two objects are the same or not.
        /// </summary>
        /// <param name="obj">Other object being compared</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType()))
            {
                Condition item = obj as Condition;
                if (item is null && this is null)
                {
                    return true;
                }
                if (item is null || this is null)
                {
                    return false;
                }
                return this.ConditionName.ToLower().Equals(item.ConditionName.ToLower());
            }
            return false;
        }

        /// <summary>
        /// Null checks.
        /// Uses the .Equals function to determine if two Condition objects are equal to one another.
        /// </summary>
        /// <param name="condition1"></param>
        /// <param name="condition2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(Condition condition1, Condition condition2)
        {
            if (condition1 is null && condition2 is null)
            {
                return true;
            }
            if (condition1 is null || condition2 is null)
            {
                return false;
            }
            return condition1.Equals(condition2);
        }

        /// <summary>
        /// Uses the .Equals function within the Equality operator to determine if two condition objects are not equal to one another.
        /// </summary>
        /// <param name="condition1"></param>
        /// <param name="condition2"></param>
        /// <returns>Bool</returns>
        public static bool operator !=(Condition condition1, Condition condition2)
        {
            return !(condition1 == condition2);
        }

        /// <summary>
        /// Gets the hashcode of ConditionName lowercased.
        /// </summary>
        /// <returns>HashCode of ConditionName lowercase </returns>
        public override int GetHashCode()
        {
            return ConditionName.ToLower().GetHashCode();
        }
    }
}
