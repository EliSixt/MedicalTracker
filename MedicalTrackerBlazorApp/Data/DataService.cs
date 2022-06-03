using MedicalTracker;
namespace MedicalTrackerBlazorApp.Data
{
    public class DataService
    {
        public DataService()
        {
            LoadExistingPatients();
        }
        public bool PatientsLoaded
        {
            get
            {
                return _patients != null ? _patients.Count > 0 : false;
            }
        }

        public readonly string filePathPatientsList = @"C:\Users\Elias\OneDrive\TMP\patientsList.xml"; //TODO: Find all references and replace them
        public readonly string fileStoreDirectory = @"C:\Users\Elias\OneDrive\TMP\";
        public readonly string fileNamePatients = @"patientsList.xml";
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
        public void SubmitAndSerializePatient()
        {
            if (!Directory.Exists(fileStoreDirectory))
            {
                _ = Directory.CreateDirectory(fileStoreDirectory);
            }

            CreatePatientID();
            Patient copyPatient = new(CurrentPatient);

            // copyPatient.ID = GetNextPatientID(); 

            if (!HasDuplicate(Patients, copyPatient))
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
        /// Creates an ID for current patient by finding the Max ID within the Patients list and adding one.
        /// </summary> 
        public void CreatePatientID() //TODO: Return a number instead of assigning a value
        {
            CurrentPatient.ID = Patients.Max(x => x.ID) + 1;
        }

        /// <summary>
        /// Checks list if there's an item thats the same as the provided object.
        /// Null checks.
        /// Checks if the list's tpe and the object's type are the same.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objList">The List of items</param>
        /// <param name="objToCheck">Object to compare</param>
        /// <returns>Boolean</returns>
        public bool HasDuplicate<T>(List<T> objList, T objToCheck)
        {
            if (objToCheck == null || objList == null)
            {
                return false;
            }
            foreach (T obj in objList)
            {
                if (obj != null && obj.Equals(objToCheck))
                {
                    return true;
                }
            }
            return false;
        }

        //TODO: Put this in the DataService and double checks before deleting. Save the new modified list onto a new xml List and make a backup list incase.
        public void Delete(int indicator)
        {
            Patients.RemoveAt(indicator);
        }
    }
}

