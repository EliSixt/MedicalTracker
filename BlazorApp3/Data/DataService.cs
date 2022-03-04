using MedicalTracker;

namespace BlazorApp3.Data
{

    public class DataService
    {
        private readonly string filePathPatientsList = @"C:\Users\Elias\OneDrive\TMP\patientsList.xml";
        private List<Patient> _patients = new();
        public List<Patient> Patients
        {
            get => _patients;
            set => _patients = value;
        }

        public void AddPatient(Patient P)
        {
            Patients.Add(P);
            //XmlWriter<Patient>(_patients, filePath);
            MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
        }
    }
}
