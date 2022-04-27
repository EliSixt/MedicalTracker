using MedicalTracker;

namespace MedicalTrackerBlazorApp.Data
{
    public class DataService
    {

        private readonly string filePathPatientsList = @"C:\Users\Elias\OneDrive\TMP\patientsList.xml";

        public Patient CurrentPatient { get; set; } = new();

        private List<Patient> _patients = new();

        public List<Patient> Patients
        {
            get => _patients;
            set => _patients = value;
        }


        /// <summary>
        /// Intended to use at the end, when all of the patient info has been filled out and ready to submit.
        /// Will add CurrentPatient into a Patients List, erase value in CurrentPatient variable, and
        /// update/override the local xml file.
        /// </summary>
        public void AtEndSubmitAndAddPatient()
        {
            Patient copyPatient = new(CurrentPatient);
            bool duplicate = false;

            foreach (Patient P in Patients)
            {
                duplicate = string.Equals(copyPatient.GeneralInfo.Name.FirstName, P.GeneralInfo.Name.FirstName, StringComparison.CurrentCultureIgnoreCase);
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
    }
}

