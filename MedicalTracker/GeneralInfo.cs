using System;
using System.ComponentModel.DataAnnotations;
namespace MedicalTracker
{
    public class GeneralInfo
    {
        [Required]
        public Name Name { get; set; } = new();
        [Required]
        public DateOnly DateOfBirth { get; set; }
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

        /// <summary>
        /// Produces a unique int hashcode from a string.
        /// </summary>
        /// <param name="s">string</param>
        /// <param name="s2">string</param>
        /// <returns>Hashcode</returns>
        public static int GetHashString(string s, string s2)
        {
            int hash = 0;
            hash = (s.ToLower() + s2.ToLower()).GetHashCode();
            return hash;

        }
        public static bool operator ==(GeneralInfo person1, GeneralInfo person2)
        {
            bool v = false;
            if (GetHashString(person1.Name.FirstName, person1.Name.LastName).Equals(GetHashString(person2.Name.FirstName, person2.Name.LastName)))
            {
                v = true;
            }
            return v;
        }

        public static bool operator !=(GeneralInfo person1, GeneralInfo person2)
        {
            bool v = true;
            if (GetHashString(person1.Name.FirstName, person1.Name.LastName).Equals(GetHashString(person2.Name.FirstName, person2.Name.LastName)))
            {
                v = false;
            }
            return v;
        }

        /// <summary>
        /// Copy Constructor.
        /// </summary>
        /// <param name="originalGeneralInfo"></param>
        public GeneralInfo(GeneralInfo originalGeneralInfo)
        {
            Name = originalGeneralInfo.Name;
            DateOfBirth = originalGeneralInfo.DateOfBirth;
            Age = originalGeneralInfo.Age;
            Weight = originalGeneralInfo.Weight;
            Height = originalGeneralInfo.Height;
            Languages = originalGeneralInfo.Languages;
            Ethnicity = originalGeneralInfo.Ethnicity;
            Gender = originalGeneralInfo.Gender;
            Race = originalGeneralInfo.Race;
            Gender = originalGeneralInfo.Gender;
            SexAtBirth = originalGeneralInfo.SexAtBirth;
        }

        public GeneralInfo()
        {
        }
    }
}
