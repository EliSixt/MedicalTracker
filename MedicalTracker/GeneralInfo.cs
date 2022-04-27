using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalTracker
{
    public class GeneralInfo
    {
        [Required]
        public Name Name { get; set; } = new();
        [Required]
        public DateTime DateOfBirth { get; set; }
        public double Age { get; set; } /*Already have birthday...*/
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Languages { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        [Required]
        public string SexAtBirth { get; set; }

        /// <summary>
        /// Overrides string for GeneralInfo.
        /// </summary>
        /// <returns>Displays all the variables of GeneralInfo and their values.</returns>
        public override string ToString()
        {
            return $"DateOfBirth:{DateOfBirth}, Age:{Age}, Weight:{Weight}, Height:{Height}, Languages:{Languages}" +
                $"Ethnicity:{Ethnicity}, Race:{Race}, Gender:{Gender}, SexAtBirth:{SexAtBirth}.";
        }
    }
}
