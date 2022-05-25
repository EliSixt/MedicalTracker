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
        public void SubmitAndSerializePatient()
        {
            if (!Directory.Exists(@"C:\TMP"))
            {
                _ = Directory.CreateDirectory(@"C:\TMP");
            }

            CurrentPatient.ID = CreatePatientID();
            Patient copyPatient = new(CurrentPatient);

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
        /// Creates a string ID.
        /// Concatenates the first two letters of the first name and last name (lowercase) and adds birth date to the end of the string.
        /// </summary>
        /// <returns>ID String</returns>
        public string CreatePatientID()
        {
            return string.Concat(CurrentPatient.GeneralInfo.Name.FirstName.AsSpan(0, 2), CurrentPatient.GeneralInfo.Name.LastName.AsSpan(0, 2)).ToLower() + CurrentPatient.GeneralInfo.DateOfBirth;
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
            if (objToCheck == null || objList == null || objList.GetType().Equals(objToCheck.GetType()))
            {
                return true;
            }
            foreach (T obj in objList)
            {
                if (obj.Equals(objToCheck))
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

