using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Symptom
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public double Date { get; set; }
        public string Severity { get; set; }
        /// <summary>
        /// Overrides string for Symptom.
        /// </summary>
        /// <returns>Displays the name of the symptom, severity, and userId.</returns>
        public override string ToString()
        {
            return $"name = {Name}, severity = {Severity}, userID = {UserID}";

        }
    }
}
