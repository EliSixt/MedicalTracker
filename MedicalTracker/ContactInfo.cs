using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class ContactInfo
    {
        public Name Name { get; set; }
        public string MobilePhoneNum { get; set; }
        public string HomePhoneNum { get; set; }
        public string WorkPhoneNum { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

    }
}
