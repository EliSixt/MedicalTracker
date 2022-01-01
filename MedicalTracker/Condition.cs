using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
