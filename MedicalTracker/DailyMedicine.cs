using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class DailyMedicine
    {
        public Medicine Medicine { get; set; } = new Medicine();
        public string DoseMg { get; set; }//medication taken at one time
        public string FrequencyOfDose { get; set; }//frequency of doses daily
        public TimeSpan TimeSpanOfDose { get; set; }

        public override string ToString()
        {
            return $"Medicine: {Medicine.BrandName}/{Medicine.GenericName}, Time between dose: {TimeSpanOfDose}";
        }
    }
}
