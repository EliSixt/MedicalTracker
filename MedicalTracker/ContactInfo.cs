namespace MedicalTracker
{
    public class ContactInfo
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

    }
}
