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
        /// Uses the firstname lastname and DateOfBirth from two GeneralInfo objects and returns if the two objects are the same or not.
        /// </summary>
        /// <param name="obj">Other object being compared.</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            return (obj == null) || this.GetType().Equals(obj.GetType())
                ? false
                : (Name.FirstName + Name.LastName).ToLower() + DateOfBirth == (((GeneralInfo)obj).Name.FirstName + ((GeneralInfo)obj).Name.LastName).ToLower() + ((GeneralInfo)obj).DateOfBirth;
        }
        /// <summary>
        /// Uses the .Equals function to determine if two GeneralInfo objects are equal to one another.
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(GeneralInfo person1, GeneralInfo person2)
        {
            return person1.Equals(person2);
        }
        /// <summary>
        ///  Uses the .Equals function to determine if two GeneralInfo objects are not equal to one another.
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        /// <returns>Bool</returns>
        public static bool operator !=(GeneralInfo person1, GeneralInfo person2)
        {
            return !person1.Equals(person2);
        }
        /// <summary>
        /// Gets the hashcode of the firstName and lastName lowercased.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return (Name.FirstName.ToLower() + Name.LastName.ToLower()).GetHashCode();
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
            SexAtBirth = originalGeneralInfo.SexAtBirth;
        }

        public GeneralInfo()
        {
        }
    }
}
