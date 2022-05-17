using System.Collections.Generic;

namespace MedicalTracker
{
    public class Allergy
    {
        public bool IngestionOnly { get; set; }
        public string AlgyName { get; set; }//food,drug,latex,insect,mold,pet,pollen,other..
        public bool ConfirmedTestedAlgyType { get; set; } //dont think this is necessary
        public string CommonReactions { get; set; }//list? This should go after IsLifeThreatening in UI, if its true then the user might input duplicates. Redundant.
        //life threatening?? action plan..
        public bool IslifeThreatening { get; set; }
        public List<Symptom> SymptomsLeadingToLifeThreatening { get; set; } = new(); //changed to list, limit character input for brief descriptions
        //if having symptomsLeadintoLifeThreatening
        //do
        public bool EpiPenRequired { get; set; }
        //then do
        public bool CPRRequired { get; set; }
        public bool Call911 { get; set; }
        //else
        public bool TreatmentRequired { get; set; }
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
        /// Compares the hashcodes of two algyName and determines if they're equal.
        /// </summary>
        /// <param name="allergy1"></param>
        /// <param name="allergy2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(Allergy allergy1, Allergy allergy2)
        {
            return allergy1.Equals(allergy2);
            //return allergy1.AlgyName.ToLower().GetHashCode().Equals(allergy2.AlgyName.ToLower().GetHashCode());
        }
        /// <summary>
        /// Compares the hashcodes of two algyName and determines if they're NOT equal.
        /// </summary>
        /// <param name="allergy1"></param>
        /// <param name="allergy2"></param>
        /// <returns>bool</returns>
        public static bool operator !=(Allergy allergy1, Allergy allergy2)
        {
            return !allergy1.Equals(allergy2);
            //return !(allergy1.AlgyName.ToLower().GetHashCode().Equals(allergy2.AlgyName.ToLower().GetHashCode()));
        }
        /// <summary>
        /// Compares two Allergy objects. 
        /// Checks if the obj is Null and of the same type, it then checks if the two AlgyName of both Allergy objects are equal.
        /// </summary>
        /// <param name="obj">allergy object</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            if ((obj == null) || this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return AlgyName.ToLower() == ((Allergy)obj).AlgyName.ToLower();
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
        /// Copy constructor
        /// </summary>
        /// <param name="OriginalAllergy"></param>
        public Allergy(Allergy OriginalAllergy)
        {
            IngestionOnly = OriginalAllergy.IngestionOnly;
            AlgyName = OriginalAllergy.AlgyName;
            ConfirmedTestedAlgyType = OriginalAllergy.ConfirmedTestedAlgyType;
            CommonReactions = OriginalAllergy.CommonReactions;
            IslifeThreatening = OriginalAllergy.IslifeThreatening;
            //SymptomsLeadingToLifeThreatening = new List<Symptom>(SymptomsLeadingToLifeThreatening);
            SymptomsLeadingToLifeThreatening = OriginalAllergy.SymptomsLeadingToLifeThreatening;
            EpiPenRequired = OriginalAllergy.EpiPenRequired;
            CPRRequired = OriginalAllergy.CPRRequired;
            Call911 = OriginalAllergy.Call911;
            TreatmentRequired = OriginalAllergy.TreatmentRequired;
            //AlgyTreatmentMedication = new List<Medicine>(AlgyTreatmentMedication);
            AlgyTreatmentMedication = OriginalAllergy.AlgyTreatmentMedication;
        }

        public Allergy()
        {
        }
    }
}
