using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class ContactInfo
    {
        //Needs a ToString!


        public Name Name { get; set; } = new();
        public string MobilePhoneNum { get; set; }
        public string HomePhoneNum { get; set; }
        public string WorkPhoneNum { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; } = new();

    }
}
