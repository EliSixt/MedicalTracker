namespace MedicalTracker
{
    public class ContactInfo : IValidateable
    {
        public string TitleOrRelationship { get; set; }
        public Name Name { get; set; } = new();
        public string MobilePhoneNum { get; set; }
        public string HomePhoneNum { get; set; }
        public string WorkPhoneNum { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; } = new();


        /// <summary>
        /// Overrides string for ContactInfo
        /// </summary>
        /// <returns>Displays all the variables of ContactInfo and their values.</returns>
        public override string ToString()
        {
            return $"Name: {Name.FirstName} {Name.LastName}, Title/Relation: {TitleOrRelationship}";
        }

        /// <summary>
        /// Checks a Contact object to see if it's filled with all the required info.
        /// </summary>
        /// <returns>Returns true if the object is filled.</returns>
        public bool Validate()
        {
            //TODO: later on return what is specifically needed instead of a boolean.
            if (Name.FirstName == null || Name.LastName == null)
            {
                return false;
            }
            if (MobilePhoneNum == null && HomePhoneNum == null && WorkPhoneNum == null)
            {
                return false;
            }
            if (!Address.Validate())
            {
                return false;
            }
            return true;
        }
    }
}
