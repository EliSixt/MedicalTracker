namespace MedicalTracker
{
    public class Medicine
    {
        //generic name and brand name??
        //warning, use, dose, 
        public string BrandName { get; set; }
        public string GenericName { get; set; }
        public string Description { get; set; } //looks
        public string Warnings { get; set; }
        public string UnusualSideEffects { get; set; }
        public string CommmonSideEffects { get; set; }
        public string Uses { get; set; }
        public string Directions { get; set; } //int?
        public string Purposes { get; set; }
        public string AllergyAlerts { get; set; }//run a check with allergies?
        public string WarningsBeforeUse { get; set; }
        public string OtherDrugsThatMayCauseAReaction { get; set; }

        public override string ToString()
        {
            return $"Brand name:{BrandName}, Generic name:{GenericName}, Description:{Description}, " +
                $"warnings:{Warnings}, Unusual side-effects:{UnusualSideEffects}, Commmon side-effects:{CommmonSideEffects}, " +
                $"Uses:{Uses}, Directions:{Directions}, Purposes:{Purposes}, Allergy alerts:{AllergyAlerts}, " +
                $"Warnings before use:{WarningsBeforeUse}, Don't mix with:{OtherDrugsThatMayCauseAReaction}";
        }
        /// <summary>
        /// Uses the GeneralName and BrandName from two Medicine objects and returns if the two objects are the same or not.
        /// </summary>
        /// <param name="obj">Other object being compared.</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            if (this.GetType().Equals(obj.GetType()))
            {
                Medicine item = obj as Medicine;
                if (item is null && this is null)
                {
                    return true;
                }
                if (item is null || this is null)
                {
                    return false;
                }
                return (this.GenericName.ToLower() == item.GenericName.ToLower() || this.BrandName.ToLower() == item.BrandName.ToLower());
            }
            return false;
        }

        /// <summary>
        /// Uses the .Equals function to determine if two Medicine objects are equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(Medicine obj1, Medicine obj2)
        {
            if (obj1 is null && obj2 is null)
            {
                return true;
            }
            if (obj1 is null || obj2 is null)
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Uses the .Equals function to determine if two Medicine objects are not equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>Bool</returns>
        public static bool operator !=(Medicine obj1, Medicine obj2)
        {
            return !(obj1 == obj2);
        }
        /// <summary>
        /// Gets the hashcode of GenericName + BrandName lowercased.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return (GenericName.ToLower() + BrandName.ToLower()).GetHashCode();
        }
        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="originalMedicine">Medicine to duplicate from.</param>
        public Medicine(Medicine originalMedicine)
        {
            BrandName = originalMedicine.BrandName;
            GenericName = originalMedicine.GenericName;
            Description = originalMedicine.Description;
            Warnings = originalMedicine.Warnings;
            UnusualSideEffects = originalMedicine.UnusualSideEffects;
            CommmonSideEffects = originalMedicine.CommmonSideEffects;
            Uses = originalMedicine.Uses;
            Directions = originalMedicine.Directions;
            Purposes = originalMedicine.Purposes;
            AllergyAlerts = originalMedicine.AllergyAlerts;
            WarningsBeforeUse = originalMedicine.WarningsBeforeUse;
            OtherDrugsThatMayCauseAReaction = originalMedicine.OtherDrugsThatMayCauseAReaction;
        }

        public Medicine()
        {

        }
    }
}
