using System.Collections.Generic;

namespace MedicalTracker
{
    public class Allergy : IValidateable, ICloneable
    {
        public bool IngestionOnly { get; set; }
        public string AlgyName { get; set; }//food,drug,latex,insect,mold,pet,pollen,other..
        public bool? ConfirmedTestedAlgyType { get; set; } //dont think this is necessary
        public string CommonReactions { get; set; }//list? This should go after IsLifeThreatening in UI, if its true then the user might input duplicates. Redundant.
        //life threatening?? action plan..
        public bool? IslifeThreatening { get; set; }
        public List<Symptom> SymptomsLeadingToLifeThreatening { get; set; } = new(); //changed to list, limit character input for brief descriptions
        //if having symptomsLeadintoLifeThreatening
        //do
        public bool? EpiPenRequired { get; set; }
        //then do
        public bool? CPRRequired { get; set; }
        public bool? Call911 { get; set; }
        //else
        public bool? TreatmentRequired { get; set; }
        public List<Medicine> AlgyTreatmentMedication { get; set; } = new();

        /// <summary>
        /// Overrides string for Allergy
        /// </summary>
        /// <returns>Displays all the variables of Allergy and their values.</returns>
        public override string ToString()
        {
            return $"Allergy: {AlgyName}, IngestionOnly: ${IngestionOnly}," +
                $" ConfirmedTestedAlgy: ${ConfirmedTestedAlgyType}, CommonReactions: ${CommonReactions}, IslifeThreatening: ${IslifeThreatening}, " +
                $"EpiPenRequired: ${EpiPenRequired}, CPRRequired: ${CPRRequired}, Call911: ${Call911}, TreatmentRequired: ${TreatmentRequired}, AlgyTreatmentMedication: ${AlgyTreatmentMedication} ";
        }
        /// <summary>
        /// Compares two allergy objects by using the .Equals function and determines if they're equal.
        /// </summary>
        /// <param name="allergy1"></param>
        /// <param name="allergy2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(Allergy allergy1, Allergy allergy2)
        {
            if (allergy1 is null && allergy2 is null)
            {
                return true;
            }

            if (allergy1 is null || allergy2 is null)
            {
                return false;
            }

            return allergy1.Equals(allergy2);
        }
        /// <summary>
        /// Compares two allergy objects by using the .Equals function within the equality operator and determines if they're NOT equal.
        /// </summary>
        /// <param name="allergy1"></param>
        /// <param name="allergy2"></param>
        /// <returns>bool</returns>
        public static bool operator !=(Allergy allergy1, Allergy allergy2)
        {
            return !(allergy1 == allergy2);
        }
        /// <summary>
        /// Compares two Allergy objects. 
        /// Checks if the obj is Null and of the same type, it then checks if the two AlgyName of both Allergy objects are equal.
        /// </summary>
        /// <param name="obj">allergy object</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType()))
            {
                Allergy item = obj as Allergy;
                if (item is null && this is null)
                {
                    return true;
                }
                if (item is null || this is null)
                {
                    return false;
                }
                return this.AlgyName.ToLower().Equals(item.AlgyName.ToLower());
            }
            return false;
        }

        /// <summary>
        /// Gets the hashcode of AlgyName lowercased.
        /// </summary>
        /// <returns>HashCode of AlgyName lowercase </returns>
        public override int GetHashCode()
        {
            return AlgyName.ToLower().GetHashCode();
        }

        /// <summary>
        /// Checks an allergy object to see if it's filled with all the required info.
        /// </summary>
        /// <returns>boolean, whether or not the allergy is filled.</returns>
        public bool Validate()
        {
            if (string.IsNullOrEmpty(AlgyName))
            {
                return false;
            }
            if (!IslifeThreatening.HasValue)
            {
                return false;
            }
            if (string.IsNullOrEmpty(CommonReactions))
            {
                return false;
            }
            if (SymptomsLeadingToLifeThreatening.Count <= 0)
            {
                return false;
            }
            if (!EpiPenRequired.HasValue)
            {
                return false;
            }
            if (!CPRRequired.HasValue)
            {
                return false;
            }
            if (!Call911.HasValue)
            {
                return false;
            }
            if (TreatmentRequired.HasValue)
            {
                if (AlgyTreatmentMedication.Count <= 0)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Creates a new copy/clone of itself by calling the Copy Constructor.
        /// </summary>
        /// <param name="allergy"></param>
        /// <returns>cloned object</returns>
        public object Clone()
        {
            return new Allergy(this);
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="originalAllergy"></param>
        public Allergy(Allergy originalAllergy)
        {
            IngestionOnly = originalAllergy.IngestionOnly;
            AlgyName = originalAllergy.AlgyName;
            ConfirmedTestedAlgyType = originalAllergy.ConfirmedTestedAlgyType;
            CommonReactions = originalAllergy.CommonReactions;
            IslifeThreatening = originalAllergy.IslifeThreatening;
            //SymptomsLeadingToLifeThreatening = new List<Symptom>(SymptomsLeadingToLifeThreatening);
            SymptomsLeadingToLifeThreatening = originalAllergy.SymptomsLeadingToLifeThreatening;
            EpiPenRequired = originalAllergy.EpiPenRequired;
            CPRRequired = originalAllergy.CPRRequired;
            Call911 = originalAllergy.Call911;
            TreatmentRequired = originalAllergy.TreatmentRequired;
            //AlgyTreatmentMedication = new List<Medicine>(AlgyTreatmentMedication);
            AlgyTreatmentMedication = originalAllergy.AlgyTreatmentMedication;
        }

        public Allergy()
        {
        }
    }
}
