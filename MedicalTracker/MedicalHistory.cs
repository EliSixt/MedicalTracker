using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class MedicalHistory
    {
        public DateTime Date { get; set; } = new DateTime();
        public string MedicalName { get; set; }
        public string Treatments { get; set; }
        public List<Medicine> PastMedicines { get; set; } = new();//Should it be a list?
        public string NeededSupport { get; set; }
        public List<Condition> Conditions { get; set; } = new();
        public string Preventatives { get; set; }


        /// <summary>
        /// Defines the MedicalHistory class by overriding it's toString to it's MedicalName.
        /// </summary>
        /// <returns>The MedicalName in the class.</returns>
        public override string ToString()
        {
            return $"Medical History: {MedicalName}";
        }
    }
}
