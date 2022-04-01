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

            Patients.Add(copyPatient);

            CurrentPatient = new();

            MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
        }
        
    }
}

