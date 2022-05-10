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
            CurrentPatient.PatientID = CreatePatientID();
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
        /// <param name="s">string</param>
        /// <param name="s2">string</param>
        /// <param name="DOB">DateOfBirth</param>
        /// <returns>Hashcode String</returns>
        public int GetHashString(string s, string s2, DateOnly? DOB)
        {
            int hash = 0;
            if (DOB.HasValue)
            {
                hash = (s.ToLower() + s2.ToLower() + DOB).GetHashCode();
            }
            else
            {
                hash = (s.ToLower() + s2.ToLower()).GetHashCode();
            }
            return hash;

        }
        public Dictionary<int, Patient> HashPatients()
        {
            Dictionary<int, Patient> result = new Dictionary<int, Patient>();
            foreach (Patient patient in Patients)
            {
                // result.Add(HashingString(patient.GeneralInfo.Name.FirstName), patient);
            }
            return result;
        }
        /// <summary>
        /// Creates a string ID.
        /// Concatenates the first two letters of the first name and last name (lowercase) and adds birth date to the end of the string.
        /// </summary>
        /// <returns>ID String</returns>
        public string CreatePatientID()
        {
            return string.Concat(CurrentPatient.GeneralInfo.Name.FirstName.AsSpan(0, 2), CurrentPatient.GeneralInfo.Name.LastName.AsSpan(0, 2)).ToLower() + CurrentPatient.GeneralInfo.DateOfBirth;
        }
        //public static bool operator == (Patient obj1, Patient obj2)
        //{
        //    if (ReferenceEquals(obj1, obj2))
        //        return true;
        //    if (ReferenceEquals(obj1, null))
        //        return false;
        //    if (ReferenceEquals(obj2, null))
        //        return false;
        //    return obj1.Equals(obj2);
        //}
        //public static bool operator != (Patient person, Patient person2)
        //{
        //    if (ReferenceEquals(person, person2))
        //        return false;
        //    if (ReferenceEquals(person, null))
        //        return true;
        //    if (ReferenceEquals(person2, null))
        //        return true;
        //    return person.Equals(person2);
        //}
    }
}

