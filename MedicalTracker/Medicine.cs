﻿using System;
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
    }
}
