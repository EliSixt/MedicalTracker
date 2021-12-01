using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class MedicalHistory
    {
        public string MedicalCondition { get; set; }
        public string CounterMeasures { get; set; }//list?
        public string Symptoms { get; set; }//List?
        public string Treatment { get; set; }
        public Medicine Medicine { get; set; }//Should it be a list?
        public string NeededSupport { get; set; }

        public override string ToString()
        {
            return $"Medical Condition: {MedicalCondition}";
        }
    }
}
