using System.Collections.Generic;

namespace MedicalTracker
{
    public class Allergy
    {
        public bool IngestionOnly { get; set; }
        public string AlgyName { get; set; }//food,drug,latex,insect,mold,pet,pollen,other..
        public bool ConfirmedTestedAlgyType { get; set; }
        public string BriefDescriptionOfReactions { get; set; }
        //life threatening?? action plan..
        public bool IslifeThreatening { get; set; }
        public List<string> SymptomsLeadingToLifeThreatening { get; set; } = new(); //changed to list, limit character input for brief descriptions
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
    }
}
