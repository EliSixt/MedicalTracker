using MedicalTracker;
using System.Xml.Serialization;

namespace MedicalTrackerBlazorApp.Data
{
    public class DataService
    {
        public DataService()
        {
            SetupUp();
        }
        public bool PatientsLoaded
        {
            get
            {
                return _patients != null ? _patients.Count > 0 : false;
            }
        }

        /// <summary>
        /// Checks whether a directory exists, else it creates one.
        /// Uses a method to check for existing local patient file and loads file.
        /// </summary>
        public void SetupUp()
        {
            if (!Directory.Exists(fileStoreDirectory)) //Exception Handling? build some try catches around here
            {
                _ = Directory.CreateDirectory(fileStoreDirectory);
            }

            LoadExistingPatients();
        }

        public string filePathPatientsList = $"{fileStoreDirectory}{fileNamePatients}"; //TODO: Find all references and replace them
        public static string fileStoreDirectory = @"C:\Users\Elias\OneDrive\TMP\";
        public static string fileNamePatients = @"patientsList.xml";

        public Patient CurrentPatient { get; set; } = new();

        private List<Patient> _patients = new();

        public List<Patient> Patients
        {
            get => _patients;
            set => _patients = value;
        }
        /// <summary>
        /// Makes and returns a copy of a Patient object.
        /// </summary>
        /// <param name="currentPatient">Patient Object to copy.</param>
        /// <returns>Patient copy</returns>
        public Patient? GetCurrentPatient()
        {
            if (CurrentPatient != null)
            {
                Patient copyPatient = new(CurrentPatient);
                return copyPatient;
            }
            return null;


        }

        /// <summary>
        /// Intended to use at the end, when all of the patient info has been filled out and ready to submit.
        /// Will add CurrentPatient into a Patients List, erase value in CurrentPatient variable, and
        /// update/override the local xml file.
        /// </summary>
        public void SubmitAndSerializePatient()
        {
            Patient copyPatient = new(CurrentPatient);

            copyPatient.ID = GetNextPatientID();

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
            if (File.Exists(filePathPatientsList) && MedicalTracker.Program.XmlReader<List<Patient>>(filePathPatientsList) != null) //Exception Handling?
            {
                Patients = MedicalTracker.Program.XmlReader<List<Patient>>(filePathPatientsList);
            }
        }

        /// <summary>
        /// Returns an new int by finding the Max ID within the Patients list and adding one.
        /// Intended to be used for patient IDs.
        /// </summary> 
        public int GetNextPatientID()
        {
            return Patients.Count <= 0 ? 1 : Patients.Max(x => x.ID) + 1;
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
        /// <summary>
        ///  check if the parameter's input exists as a patient.ID
        ///  then it removes All patients with that value (just in case of duplicates)
        ///  saves the new list of patients
        ///  otherwise returns false if no patients were deleted.
        /// </summary>
        /// <param name="id">Patient ID Number</param>
        /// <returns>true if patients were deleted || false if no change</returns>
        public bool DeletePatient(int id)
        {
            //TODO check if this patient exists
            if (Patients.Any(x => x.ID == id))
            {
                //delete patient / return sucess
                int success = 0;
                success = Patients.RemoveAll(x => x.ID == id);
                if (success > 0)
                {
                    MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
                    return true;
                }
            }
            return false;
        }
        ///// <summary>
        ///// Method that serializes a list<Object>.
        ///// </summary>
        ///// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        ///// <param name="listToStore">The list to serialize.</param>
        //public static void XmlWriter<T>(T listToStore, string aFilePath)
        //{
        //    XmlSerializer xmlSerializer = new(typeof(T));
        //    using StreamWriter tx = new(aFilePath);
        //    xmlSerializer.Serialize(tx, listToStore);

        //}

        ///// <summary>
        ///// Method that deserializes a list<object>.
        ///// </summary>
        ///// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        ///// <typeparam name="T">The type of object of the list.</typeparam>
        ///// <returns>A deserialized list object.</returns>
        //public static T XmlReader<T>(string aFilePath)
        //{
        //    XmlSerializer xmlSerializer = new(typeof(T));
        //    using StreamReader tx = new(aFilePath);
        //    return (T)xmlSerializer.Deserialize(tx);
        //}
    }
}

