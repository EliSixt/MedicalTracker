using MedicalTracker;

namespace MedicalTrackerBlazorApp.Data
{
    public class DataService
    {

        public readonly string filePathPatientsList = @"C:\Users\Elias\OneDrive\TMP\patientsList.xml";
        public Patient CurrentPatient { get; set; } = new();

        private List<Patient> _patients = new();

        public List<Patient> Patients
        {
            get => _patients;
            set => _patients = value;
        }


        /// <summary>
        /// Checks whether a directory exists, else it creates one.
        /// Intended to use at the end, when all of the patient info has been filled out and ready to submit.
        /// Will add CurrentPatient into a Patients List, erase value in CurrentPatient variable, and
        /// update/override the local xml file.
        /// </summary>
        public void AtEndSubmitAndAddPatient()
        {
            if (!Directory.Exists(@"C:\TMP"))
            {
                _ = Directory.CreateDirectory(@"C:\TMP");
            }
            Patient copyPatient = new(CurrentPatient);
            bool duplicate = false;

            foreach (Patient P in Patients)
            {
                duplicate = string.Equals(copyPatient.GeneralInfo.Name.FirstName, P.GeneralInfo.Name.FirstName, StringComparison.OrdinalIgnoreCase);
                if (duplicate)
                {
                    break;
                }
                duplicate = string.Equals(copyPatient.GeneralInfo.Name.LastName, P.GeneralInfo.Name.LastName, StringComparison.CurrentCultureIgnoreCase);
                if (duplicate)
                {
                    break;
                }
                if (copyPatient.GeneralInfo.DateOfBirth == P.GeneralInfo.DateOfBirth)
                {
                    duplicate = true;
                    break;
                }
            }
            if (!duplicate && !string.IsNullOrEmpty(copyPatient.GeneralInfo.Name.FirstName))
            {
                Patients.Add(copyPatient);
                CurrentPatient = new();
                MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
            }
        }
        /// <summary>
        /// Checks to see if the patient list file exists locally. 
        /// If true, it'll assign the stored values into a Patient list variable.
        /// </summary>
        public void LoadExistingPatients()
        {
            if (File.Exists(filePathPatientsList))
            {
                Patients = MedicalTracker.Program.XmlReader<List<Patient>>(filePathPatientsList);
            }
        }
        /// <summary>
        /// Produces a unique hashcode from a string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>hashcode string</returns>
        public int HashingString(string s)
        {
            int hash = 0;
            foreach (char c in s)
            {
                hash = (hash * 31) + c.GetHashCode();
            }

            return hash;
        }
    }
}

