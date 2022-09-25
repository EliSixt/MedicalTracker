using MedicalTracker;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace MedicalTrackerBlazorApp.Data
{
    public class DataService
    {
        public DataService()
        {
            SetupUp();
            ExcelObjectGenerator(xlsxFile, filePathConditions, filePathSymptoms);
        }



        public bool PatientsLoaded
        {
            get
            {
                return _patients != null ? _patients.Count > 0 : false;
            }
        }

        //public bool flag = false; //switch/flag for currentPatient set accessibility. Second look at the naming of flag, rename something better.

        private Patient _currentPatient { get; set; } = new();
        private Patient CurrentPatient
        {
            get => _currentPatient;
            set => SetCurrentPatient(value);
        }

        private List<Patient> _patients = new();

        public List<Patient> Patients
        {
            get => _patients;
            set => _patients = value;
        }

        /// <summary>
        /// Takes in a Patient object and replaces the current patient with it.
        /// Intended to use when modifing the Current Patient.
        /// </summary>
        /// <param name="changedPatient"></param>
        /// <returns></returns>
        public bool SetCurrentPatient(Patient changedPatient)
        {
            _currentPatient = changedPatient;
            if (_currentPatient == changedPatient) //maybe run checks here???
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Makes and returns a copy of a Patient object.
        /// </summary>
        /// <param name="currentPatient">Patient Object to copy.</param>
        /// <returns>Patient copy</returns>
        public Patient GetCopyCurrentPatient()
        {
            Patient copyPatient = new(_currentPatient);
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

        //public void GenerateExcelList()
        //{
        //TODO: Insert all the steps to make the symptom and condition lists from the excel file here so they can be stored.
        //}


        public string filePathPatientsList = $"{fileStoreDirectory}{fileNamePatients}"; //TODO: Find all references and replace them
        public static string fileStoreDirectory = @"C:\Users\Elias\OneDrive\TMP\";
        public static string fileNamePatients = @"patientsList.xml";

        public static string fileNameSymptoms = @"symptomsData.xml";
        public static string fileNameCondition = @"conditionsData.xml";
        public string xlsxFile = @"C:\Users\elias\OneDrive\Documents\PeoplewithSymptomsAndConditions.xlsx";
        public string filePathConditions = $"{fileStoreDirectory}{fileNameCondition}";
        public string filePathSymptoms = $"{fileStoreDirectory}{fileNameSymptoms}";
        //string filePathPatientsList = @"C:\Users\Elias\OneDrive\TMP\patientsList.xml";
        //string testFilePath = @"C:\TMP\testFile.xml";

        List<Condition> conditionsList = new();
        List<Symptom> symptomsList = new();
        List<Condition> conditionsWithSymptoms = new();


        //This a test for serializing to a local file
        //Directory.CreateDirectory(@"C:\TMP");
        //List<string> testFile = new List<string>();
        //testFile.Add("This is a test to make sure i dont get a directory access denied exception.");


        ////Copies information from a specific excelSheet and adds it onto an object of ExcelList,
        ////returned 2 lists through excelList, and serializes those lists into separate files.
        //string xlsxFile = @"C:\Users\elias\OneDrive\Documents\PeoplewithSymptomsAndConditions.xlsx";

        //ExcelLists excelLists = new ExcelLists();
        //excelLists = ExcelObjectGenerator(xlsxFile, filePathConditions, filePathSymptoms);


        /// <summary>
        /// Method that serializes a list<Object>.
        /// </summary>
        /// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        /// <param name="listToStore">The list to serialize.</param>
        public static void XmlWriter<T>(T listToStore, string aFilePath)
        {
            XmlSerializer xmlSerializer = new(typeof(T));
            using TextWriter tx = new StreamWriter(aFilePath);
            xmlSerializer.Serialize(tx, listToStore);

        }

        /// <summary>
        /// Method that deserializes a list<object>.
        /// </summary>
        /// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        /// <typeparam name="T">The type of object of the list.</typeparam>
        /// <returns>A deserialized list object.</returns>
        public static T? XmlReader<T>(string aFilePath) where T : class
        {
            XmlSerializer xmlSerializer = new(typeof(T));
            using TextReader tx = new StreamReader(aFilePath);
            T? t = (T?)xmlSerializer.Deserialize(tx);
            if (t != null)
            {
                return t;
            }
            return null;
        }


        /// <summary>
        /// Takes in a specific Excelsheet, reads it, and filters feeds that data into an ExcelLists object with the 2 list properties.
        /// Then serializes those lists into separate xml files.
        /// </summary>
        /// <param name="xlsxFile">The filePath of the ExcelSheet.</param>
        /// <param name="filePathConditions">The filePath of the Conditions.</param>
        /// <param name="filePathSymptoms">The filePath of the Symptoms.</param>
        /// <returns>Filled ExcelList object.</returns>
        public static ExcelLists? ExcelObjectGenerator(string xlsxFile, string filePathConditions, string filePathSymptoms)
        {
            ExcelLists excelList = new();

            //Create Excel Objects.
            Application excelApp = new();

            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return null;
            }

            Workbook excelBook = excelApp.Workbooks.Open(xlsxFile);
            Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;

            int rowCount = excelRange.Rows.Count;
            int colCount = excelRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                if (excelRange.Cells[i, 7].Value2 != "Symptom" && excelRange.Cells[i, 7].Value2 != "Condition")
                {
                    var a = excelRange.Cells[i, 7].Value2;
                }
                if (excelRange.Cells[i, 7].Value2 == "Symptom")
                {
                    Symptom symptom = new();
                    symptom.UserID = excelRange.Cells[i, 1].Value2.ToString();
                    if (excelRange.Cells[i, 5].Value2 != null)
                    {
                        symptom.Date = excelRange.Cells[i, 5].Value2;
                    }
                    if (excelRange.Cells[i, 8].Value2 != null)
                    {
                        symptom.SymptomName = excelRange.Cells[i, 8].Value2.ToString();
                    }
                    if (excelRange.Cells[i, 9].Value2 != null)
                    {
                        symptom.Severity = excelRange.Cells[i, 9].Value2.ToString();
                    }
                    excelList.Symptoms.Add(symptom);
                }


                if (excelRange.Cells[i, 7].Value2 == "Condition")
                {

                    Condition condition = new();

                    condition.UserID = excelRange.Cells[i, 1].Value2.ToString();
                    if (excelRange.Cells[i, 2].Value2 != null)
                    {
                        condition.Age = excelRange.Cells[i, 2].Value2;
                    }
                    if (excelRange.Cells[i, 3].Value2 != null)
                    {
                        condition.Sex = excelRange.Cells[i, 3].Value2.ToString();
                    }
                    if (excelRange.Cells[i, 5].Value2 != null)
                    {
                        condition.Date = excelRange.Cells[i, 5].Value2;
                    }
                    //condition.TrackableType = excelRange.Cells[i, 7].Value2.ToString();
                    if (excelRange.Cells[i, 8].Value2 != null)
                    {
                        condition.ConditionName = excelRange.Cells[i, 8].Value2.ToString();
                    }
                    if (excelRange.Cells[i, 9].Value2 != null)
                    {
                        condition.Severity = excelRange.Cells[i, 9].Value2.ToString();
                    }
                    if (excelRange.Cells[i, 4].Value2 != null)
                    {
                        condition.Country = excelRange.Cells[i, 4].Value2.ToString();//this has null exception
                    }
                    excelList.Conditions.Add(condition);
                    //conditionsList.Add(condition);
                }


                //create new line
                Console.Write("\r\n");
                //for (int j = 1; j <= colCount; j++)
                //{

                //    //write the console
                //    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                //        Console.Write(excelRange.Cells[i, j].Value2.ToString() + "\t");
                //}
                XmlWriter(excelList.Conditions, filePathConditions);
                XmlWriter(excelList.Symptoms, filePathSymptoms);
            }

            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            return excelList;
        }

        /// <summary>
        /// Intended to use at the end, when all of the patient info has been filled out and ready to submit.
        /// Will add CurrentPatient into a Patients List, erase value in CurrentPatient variable, and
        /// update/override the local xml file.
        /// If the Patient.Count is less than or equal to 0 then it would add the currentPatient into the Patients list.
        /// </summary>
        public void SubmitAndSerializePatient()
        {
            Patient copyPatient = GetCopyCurrentPatient();

            if (!Patients.HasDuplicate(copyPatient))
            {
                copyPatient.ID = GetNextPatientID();

                Patients.Add(copyPatient);
                Patient newPatient = new();
                SetCurrentPatient(newPatient);
                MedicalTracker.Program.XmlWriter(Patients, filePathPatientsList);
            }
        }

        //solving the issue of adding an obj to a disignated list of the current patient.


        /// <summary>
        /// Used whenever trying to add new items into the (or override/replace) currentPatient.
        /// Copies the CurrentPatient.
        /// Iterates through the list of items (of CopyCurrentPatient) in which the newObject will be added into, to check for any existing duplicates.
        /// Uses Ivalidateable to see if all items that are required are filled within that NewObject.
        /// If second and third pass, it will then replace the currentPatient with the updated copyPatient.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objListFromPatient"></param>
        /// <param name="newObj"></param>
        /// <returns>True if successful</returns>
        public bool AddItemToCurrentPatient<T>(List<T> objListFromPatient, T newObj) where T : IValidateable
        {
            Patient patient = GetCopyCurrentPatient();

            if (!objListFromPatient.HasDuplicate(newObj))//checks for duplicates
            {
                objListFromPatient.Add(newObj);

                SetCurrentPatient(patient);

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
            if (File.Exists(filePathPatientsList) && MedicalTracker.Program.XmlReader<List<Patient>>(filePathPatientsList) != null)
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

        public void Example(IValidateable obj)
        {

        }

        //public bool AddValidatable(List<IValidateable> itemList, IValidateable item)
        //{
        //    if (item.Validate())
        //    {

        //    }
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// Creates a copy of the symptom object.
        /// Checks if the symptom object being added if it's filled through a validate check. 
        /// Prevents duplicate answers from being added onto the Symptoms list.
        /// If it passes it gets added to the provided Symptoms list.
        /// </summary>
        public bool AddSymptom(List<Symptom> symptoms, Symptom symptom)
        {
            Symptom copySymptom = new(symptom);

            if (copySymptom.Validate() && !symptoms.HasDuplicate(symptom))
            {
                symptoms.Add(copySymptom);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Creates a copy of the medicine object.
        /// Checks if the medicine object being added if it's filled through a validate check. 
        /// Prevents duplicate answers from being added onto the medicine list.
        /// If it passes it gets added to the provided medicine list.
        /// </summary>
        /// <param name="medicines"></param>
        /// <param name="medicine"></param>
        /// <returns></returns>
        public bool AddMed(List<Medicine> medicines, Medicine medicine)
        {
            Medicine copyMed = new(medicine);

            if (copyMed.Validate() && !medicines.HasDuplicate(copyMed))
            {
                medicines.Add(copyMed);
                return true;
            }
            return false;
        }


        /// <summary>
        /// Checks if DailyMedicine object is filled with the required info.
        /// Prevents duplicate Daily meds from being added into the DailyMedicine list inside CurrentPatient.
        /// Submits/Saves into Current Patient.
        /// </summary>
        /// <param name="dailyMedicines"></param>
        /// <param name="dailyMedicine"></param>
        /// <returns>True if it got saved into the current patient.</returns>
        public bool AddDailyMedication(List<DailyMedicine> dailyMedicines, DailyMedicine dailyMedicine)
        {
            DailyMedicine CopyDailyMed = new(dailyMedicine);

            if (CopyDailyMed.Validate())
            {
                return AddItemToCurrentPatient(dailyMedicines, CopyDailyMed);
            }
            return false;
        }

        /// <summary>
        /// Checks if the GeneralInfo obj is filled with the required info.
        /// Prevents duplicate patients from being added into the Patients list
        /// by comparing GeneralInfo to all of the existing (List)Patients.GeneralInfo in the DataService.
        /// If it passes it gets allowed to be submitted and saved.
        /// </summary>
        public bool SaveGeneralInfo(GeneralInfo generalInfo)
        {
            GeneralInfo copyGeneralInfo = new(generalInfo);

            if (copyGeneralInfo.Validate())//Checks to see if the GeneralInfo obj is filled (Validates itself)
            {
                //checks for duplicate and if only the new value gets added.
                return AddItemToCurrentPatient((Patients.Select(x => x.GeneralInfo).ToList()), copyGeneralInfo);
            }

            return false;
        }


        /// <summary>
        /// Checks if an allergy obj is filled with the required info.
        /// Prevents duplicate allergy from being added into the allergies list
        /// by comparing the allergy to all of the existing (List)allergies in the currentPatient.
        /// If it passes it gets allowed to be submitted and saved. 
        /// </summary>
        /// <param name="allergy"></param>
        /// <returns>bool, whether it's successful or not</returns>
        public bool SaveAllergy(Allergy allergy)
        {
            Allergy copyAllergy = new(allergy);

            Patient copyCurrentPatient = GetCopyCurrentPatient();

            if (copyAllergy.Validate())//Checks to see if the allergy obj is filled (Validates itself)
            {
                //checks for duplicate and if only the new value gets added.
                return AddItemToCurrentPatient(copyCurrentPatient.Allergies, copyAllergy);
            }

            return false;
        }


        /// <summary>
        /// Checks if a ContactInfo object is filled with the required info.
        /// Prevents duplicate Contacts from being added into the given list.
        /// If both pass checks pass, it then gets added onto the given list.
        /// Else returns false.
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="contactsList"></param>
        /// <returns>Returns true if ContactInfo Obj was added into the list.</returns>
        public bool SaveContactInfo(ContactInfo contact, List<ContactInfo> contactsList)
        {
            ContactInfo copyContact = new(contact);

            if (copyContact.Validate())
            {
                return AddItemToCurrentPatient(contactsList, contact);
            }
            return false;
        }
    }
}

