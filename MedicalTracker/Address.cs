namespace MedicalTracker
{
    public class Address
    {
        public int BuildingNumber { get; set; }
        //public int ApptNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZIPCode { get; set; }
        public string Country { get; set; }


        /// <summary>
        /// Overrides string for Address
        /// </summary>
        /// <returns>Displays all the variables of Address and their values.</returns>
        public override string ToString()
        {
            return $" {BuildingNumber} {StreetName}, {City}, {State}, {ZIPCode}, {Country}";
        }
    }
}
