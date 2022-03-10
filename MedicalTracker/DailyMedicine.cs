using System;

namespace MedicalTracker
{
    public class DailyMedicine
    {
        public Medicine Medicine { get; set; } = new();
        public string DoseMg { get; set; }//medication taken at one time
        public string FrequencyOfDose { get; set; }//frequency of doses daily
        public TimeSpan TimeSpanOfDose { get; set; }

        //public TimeSpan Time { get; set; }


        public override string ToString()
        {
            return $"Medicine: {Medicine}, DoseMg: {DoseMg}, Frequency of Dose: {FrequencyOfDose}, Time between dose: {TimeSpanOfDose}";
        }
    }
}
