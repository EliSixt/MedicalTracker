using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class DailyMedicine
    {
        public Medicine Medicine { get; set; }
        public int DoseMg { get; set; }//medication taken at one time
        public int FrequencyOfDose { get; set; }//frequency of doses daily
        public int TimeOfDose { get; set; }
    }
}
