using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class GeneralInfo
    {
        public DateTime DateOfBirth { get; set; }
        public double Age { get; set; } /*Already have birthday...*/
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Languages { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string SexAtBirth { get; set; }

        public override string ToString()
        {
            return $"DateOfBirth:{DateOfBirth}, Age:{Age}, Weight:{Weight}, Height:{Height}, Languages:{Languages}" +
                $"Ethnicity:{Ethnicity}, Race:{Race}, Gender:{Gender}, SexAtBirth:{SexAtBirth}.";
        }
    }
}
