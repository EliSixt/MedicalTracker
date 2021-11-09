using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Medicine
    {
        //generic name and brand name??
        //warning, use, dose, 
        public string GenericName { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; } //looks
        public string Warnings { get; set; }
        public string Uses { get; set; }
        public string Purpose { get; set; }
        public string Directions { get; set; } //int?
        public string AllergyAlerts { get; set; }//run a check with allergies?
    }
}
