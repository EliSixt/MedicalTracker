using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class ExcelLists
    {
        public List<Condition> Conditions { get; set; } = new();
        public List<Symptom> Symptoms { get; set; } = new();
    }
}
