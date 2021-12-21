using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    public class Symptom
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public double Date { get; set; }
        public string Severity { get; set; }

    }
}
