﻿using System.Collections.Generic;

namespace MedicalTracker
{
    public class Allergy
    {
        public bool IngestionOnly { get; set; }
        public string AlgyName { get; set; }//food,drug,latex,insect,mold,pet,pollen,other..
        public bool ConfirmedTestedAlgyType { get; set; } //dont think this is necessary
        public string CommonReactions { get; set; }//list? This should go after IsLifeThreatening in UI, if its true then the user might input duplicates. Redundant.
        //life threatening?? action plan..
        public bool IslifeThreatening { get; set; }
        public List<Symptom> SymptomsLeadingToLifeThreatening { get; set; } = new(); //changed to list, limit character input for brief descriptions
        //if having symptomsLeadintoLifeThreatening
        //do
        public bool EpiPenRequired { get; set; }
        //then do
        public bool CPRRequired { get; set; }
        public bool Call911 { get; set; }
        //else
        public bool TreatmentRequired { get; set; }
        public List<Medicine> AlgyTreatmentMedication { get; set; } = new();

        public override string ToString()
        {
            return $"Allergy: {AlgyName}";
        }

        public Allergy(Allergy OriginalAllergy)
        {
            IngestionOnly = OriginalAllergy.IngestionOnly;
            AlgyName = OriginalAllergy.AlgyName;
            ConfirmedTestedAlgyType = OriginalAllergy.ConfirmedTestedAlgyType;
            CommonReactions = OriginalAllergy.CommonReactions;
            IslifeThreatening = OriginalAllergy.IslifeThreatening;
            SymptomsLeadingToLifeThreatening = new List<Symptom>(SymptomsLeadingToLifeThreatening);
            EpiPenRequired = OriginalAllergy.EpiPenRequired;
            CPRRequired = OriginalAllergy.CPRRequired;
            Call911 = OriginalAllergy.Call911;
            TreatmentRequired = OriginalAllergy.TreatmentRequired;
            AlgyTreatmentMedication = new List<Medicine>(AlgyTreatmentMedication);
        }

        public Allergy()
        {
        }
    }
}
