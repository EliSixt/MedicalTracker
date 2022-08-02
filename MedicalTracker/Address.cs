namespace MedicalTracker
{
    public class Address : IValidateable
    {
        public int BuildingNumber { get; set; }
        //public int ApptNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIPCode { get; set; }
        public string Country { get; set; }


        /// <summary>
        /// Overrides string for Address
        /// </summary>
        /// <returns>Displays all the variables of Address and their values.</returns>
        public override string ToString()
        {
            return $" {BuildingNumber} {StreetName}, {City}, {State}, {ZIPCode}, {Country}";
        }

        public bool Validate()
        {
            //TODO: later on return what is specifically needed instead of a boolean.
            if (BuildingNumber <= 0)
            {
                return false;
            }
            if (StreetName == null)
            {
                return false;
            }
            if (City == null)
            {
                return false;
            }
            if (State == null)
            {
                return false;
            }
            if (ZIPCode == null)
            {
                return false;
            }
            if (Country == null)
            {
                return false;
            }
            return true;
        }
    }
}
