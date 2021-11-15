﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Allergies
    {
        public bool IngestionOnly { get; set; }
        public string AlgyType { get; set; }//food,drug,latex,insect,mold,pet,pollen,other..
        public bool ConfirmedTestedAlgyType { get; set; }
        public string BriefDescriptionOfReactions { get; set; }
        //life threatening?? action plan..
        public bool IslifeThreatening { get; set; }
        public string SymptomsLeadingToLifeThreatening { get; set; }
        //if having symptomsLeadintoLifeThreatening
        //do
        public bool EpiPenRequired { get; set; }
        //then do
        public bool CPRRequired { get; set; }
        public bool Call911 { get; set; }
        //else
        public string TreatmentRequired { get; set; }
        public Medicine AlgyTreatmentMedication { get; set; }


    }
}