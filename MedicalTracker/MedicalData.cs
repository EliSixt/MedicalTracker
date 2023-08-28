using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    internal class MedicalData
    {
        //constructor
        public MedicalData()
        {
        }

        //symptoms are indicators of a disease or condition, while a disease is a specific pathological process,
        //and a condition is a more general term that encompasses both diseases and other health-related issues.


        public List<Condition> Disease { get; set; }
    }
}
