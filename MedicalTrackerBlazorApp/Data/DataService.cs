﻿using MedicalTracker;
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
        /// Makes and returns a copy of a Patient object.
        /// </summary>
        /// <param name="currentPatient">Patient Object to copy.</param>
        /// <returns>Patient copy</returns>
        public Patient GetCurrentPatient()
        {
            Patient copyPatient = new(CurrentPatient);
            return copyPatient;
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

        private Patient _currentPatient { get; set; } = new();
        public Patient CurrentPatient
        {
            get => _currentPatient;
            set => _currentPatient = value;
        }

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
        /// If the Patient.Count is less than or equal to 0 then it would add the currentPatient into the Patients list.
        /// </summary>
        public void SubmitAndSerializePatient()
        {
            Patient copyPatient = new(CurrentPatient);

            if (!HasDuplicate(Patients, copyPatient))
            {
                copyPatient.ID = GetNextPatientID();

                Patients.Add(copyPatient);
                CurrentPatient = new();
                MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
            }
        }


        /// <summary>
        /// Used whenever trying to add new items into the currentPatient.
        /// First, copies the CurrentPatient. (Or Reassigns)
        /// Second, uses a method to see if all items that are required are filled within that NewObject.
        /// Third, iterates through the list of items (of CopyCurrentPatient) in which the newObject will be added into, to check for any existing duplicates.
        /// If second and third pass, it will then add it onto the copyPatient and then it would replace the currentPatient.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objListFromCopyCurrentPatient"></param>
        /// <param name="newObj"></param>
        /// <param name="copyCurrentPatient"></param>
        /// <param name="methodParameter"></param>
        /// <param name="method"></param>
        /// <returns>bool</returns>
        public bool CheckReviewNewDataAndUpdateCurrentPatient<T>(List<T> objListFromCopyCurrentPatient, T newObj, Patient copyCurrentPatient, T methodParameter, Func<T, bool> method)
        {
            copyCurrentPatient = new(GetCurrentPatient());

            bool objectCompletedAndFilled = method(methodParameter); //is object is filled or not

            if (!HasDuplicate(objListFromCopyCurrentPatient, newObj) && objectCompletedAndFilled) //Check for duplicates and if it's filled
            {
                objListFromCopyCurrentPatient.Add(newObj);

                //TODO: working on this with GetGeneralInfo first
                //****Add to currentPatient here*****
                return true;//to check success
            }
            return false;
        }


        /// <summary>
        /// Will check if only a designated value in a list got added, won't pass if any other items in that list got changed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="unchangedList">Original list, unchanged.</param>
        /// <param name="changedList">List where the new value was added.</param>
        /// <param name="valueAdded">Value that is being compared and was added to a list.</param>
        /// <returns>True if the valueAdded was the only item added.</returns>
        public bool HasDifferenceOfAValue<T>(List<T> unchangedList, List<T> changedList, T valueAdded)
        {
            if (unchangedList == null && changedList == null)
            {
                return false;
            }
            if (unchangedList == null || changedList == null)
            {
                return true;
            }
            if (unchangedList.GetType() != changedList.GetType())
            {
                return false;
            }
            //if (!HasDuplicate(unchangedList, valueAdded) && HasDuplicate(changedList, valueAdded))
            //{
            //    return true;
            //}

            //var difference = changedList.Except(unchangedList);

            var difference = unchangedList.Where(X => !changedList.Contains(X));

            if (difference.Equals(valueAdded))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Checks to see if the patient list file exists locally. 
        /// If true, it'll assign the stored values into a Patient list variable.
        /// </summary>
        public void LoadExistingPatients()
        {
            if (File.Exists(filePathPatientsList) && MedicalTracker.Program.XmlReader<List<Patient>>(filePathPatientsList) != null) //Exception Handling?
            {
                Patients = MedicalTracker.Program.XmlReader<List<Patient>>(filePathPatientsList); //TODO: try catch?
            }
        }


        /// <summary>
        /// Returns an new int by finding the Max ID within the Patients list and adding one.
        /// Intended to be used for patient IDs.
        /// </summary> 
        public int GetNextPatientID()
        {
            //check for 'leftover' IDs that were used and deleted?
            return Patients.Count <= 0 ? 1 : Patients.Max(x => x.ID) + 1;
        }


        /// <summary>
        /// Checks list if there's an item thats the same as the provided object.
        /// Null checks.
        /// Checks if the list's type and the object's type are the same.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objList">The List of items</param>
        /// <param name="objToCheck">Object to compare</param>
        /// <returns>Boolean</returns>
        public bool HasDuplicate<T>(List<T> objList, T objToCheck)
        {
            if (objToCheck is null && objList is null)
            {
                return true;
            }
            if (objToCheck is null || objList is null)
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


        /// <summary>
        /// Checks a patient object to see if it's filled with all the required info.
        /// </summary>
        /// <param name="GeneralInfo">Patient object</param>
        /// <returns>boolean, whether or not a patient object is filled.</returns>
        public bool IsGeneralInfoFilled(GeneralInfo GeneralInfo)
        {
            if (GeneralInfo.Name.FirstName == null && GeneralInfo.Name.LastName == null)
            {
                return false; //TODO: later on return what is specifically needed instead of a boolean.
            }
            if (GeneralInfo.DateOfBirth <= DateOnly.MinValue)
            {
                return false;
            }
            if (GeneralInfo.Age <= 0)
            {
                return false;
            }
            if (GeneralInfo.Weight <= 0)
            {
                return false;
            }
            if (GeneralInfo.Height <= 0)
            {
                return false;
            }
            if (!IsContactInfoFilled(GeneralInfo.ContactInfo))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Checks a Contact object to see if it's filled with all the required info.
        /// </summary>
        /// <param name="contact">Contact object</param>
        /// <returns>Bool, whether or not the necessary info is filled out.</returns>
        public bool IsContactInfoFilled(ContactInfo contact)
        {
            //TODO: later on return what is specifically needed instead of a boolean.
            if (contact.Name.FirstName == null || contact.Name.LastName == null)
            {
                return false;
            }
            if (contact.MobilePhoneNum == null && contact.HomePhoneNum == null && contact.WorkPhoneNum == null)
            {
                return false;
            }
            if (!IsAddressInfoFilled(contact.Address))
            {
                return false; //TODO: this is in an if statement cause later on IsContactInfoFilled and IsAddressInfoFilled will return what is specifically needed to be filled out.
            }
            return true;
        }


        /// <summary>
        /// Checks the Address object to see if it's filled with all the required info.
        /// </summary>
        /// <param name="address">Address object</param>
        /// <returns>Bool, whether or not Address is info is filled.</returns>
        public bool IsAddressInfoFilled(Address address)
        {
            //TODO: later on return what is specifically needed instead of a boolean.
            if (address.BuildingNumber <= 0)
            {
                return false;
            }
            if (address.StreetName == null)
            {
                return false;
            }
            if (address.City == null)
            {
                return false;
            }
            if (address.State == null)
            {
                return false;
            }
            if (address.ZIPCode == null)
            {
                return false;
            }
            if (address.Country == null)
            {
                return false;
            }
            return true;
        }
    }
}

