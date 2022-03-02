using MedicalTracker;


namespace BlazorApp3.Data
{

    public class DataService
    {
        private readonly string filePathPatientsList = @"C:\Users\Elias\OneDrive\TMP\patientsList.xml";

        public List<Patient> Patients { get; set; } = new();

        public void AddPatient(Patient P)
        {
            Patients.Add(P);
            //XmlWriter<Patient>(_patients, filePath);
            MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
        }
    }
}
