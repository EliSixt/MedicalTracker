using System;

namespace MedicalTracker
{
    public class DailyMedicine : IValidateable
    {
        public Medicine Medicine { get; set; } = new();
        public string DoseMg { get; set; }//medication taken at one time
        public string FrequencyOfDose { get; set; }//frequency of doses daily
        public TimeSpan TimeSpanOfDose { get; set; }

        //public TimeSpan Time { get; set; }


        /// <summary>
        /// Overrides string for DailyMedicine.
        /// </summary>
        /// <returns>Displays all the variables of DailyMedicine and their values.</returns>
        public override string ToString()
        {
            return $"Medicine: {Medicine}, DoseMg: {DoseMg}, Frequency of Dose: {FrequencyOfDose}, Time between dose: {TimeSpanOfDose}";
        }


        /// <summary>
        /// Checks a DailyMedicine object if it's filled with all the required info.
        /// </summary>
        /// <returns>True if all necessary info is filled.</returns>
        public bool Validate()
        {
            if (!Medicine.Validate())
            {
                return false;
            }
            if (string.IsNullOrEmpty(DoseMg))
            {
                return false;
            }
            if (TimeSpanOfDose <= TimeSpan.MinValue)
            {
                return false;
            }
            return true;
        }

        public DailyMedicine(DailyMedicine OrginalDailyMedicine)
        {
            Medicine = OrginalDailyMedicine.Medicine;
            DoseMg = OrginalDailyMedicine.DoseMg;
            FrequencyOfDose = OrginalDailyMedicine.FrequencyOfDose;
            TimeSpanOfDose = OrginalDailyMedicine.TimeSpanOfDose;
        }

        public DailyMedicine()
        {
        }
    }
}
