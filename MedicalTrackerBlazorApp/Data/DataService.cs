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

        public void AddPatient(Patient P)
        {
            //Patient copyPatient = new (CurrentPatient);

            Patients.Add(P);

            //XmlWriter<Patient>(_patients, filePath);

            MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
        }
        
    }
}

