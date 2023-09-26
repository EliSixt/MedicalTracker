using MedicalTracker;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.CompilerServices;

namespace MedicalTrackerBlazorApp.Data
{
    public class DataService
    {
        public DataService()
        {
            SetupUp();
            StringListSetup(EnglishWordList, filePathWordList); //TODO: this is just a temporary wordlist of english words replace with symptoms and conditions
            //oneTimeSetup();
        }



        public bool PatientsLoaded
        {
            get
            {
                return _patients != null ? _patients.Count > 0 : false;
            }
        }

        public bool currentPatientSetControl = false; //switch/flag for currentPatient set accessibility. Second look at the naming of flag, rename something better.

        private Patient _currentPatient { get; set; } = new();
        private Patient CurrentPatient
        {
            get => _currentPatient;
            set
            {
                if (currentPatientSetControl)
                { _currentPatient = value; }
            }
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
            currentPatientSetControl = true;
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
            FileStartUpCheck(filePathConditions);
            FileStartUpCheck(filePathSymptoms);
            FileStartUpCheck(filePathWordList);
            FileStartUpCheck(filePathEnglishWordList);

            //ListSetup(wordList, filePathWordList); TODO: temporarily commented out

            LoadExistingPatients();
        }



        public string filePathPatientsList = $"{fileStoreDirectory}{fileNamePatients}";
        public static string fileStoreDirectory = @"G:\Medical Tracker\";
        public static string fileNamePatients = @"patientsList.xml";


        public static string fileNameWordList = @"english_words_479k.txt";
        public static string fileNameEnglishWordList = @"englishWordList.xml";
        public static string fileNameSymptoms = @"symptomsData.xml";
        public static string fileNameCondition = @"conditionsData.xml";


        public string filePathConditions = $"{fileStoreDirectory}{fileNameCondition}";
        public string filePathSymptoms = $"{fileStoreDirectory}{fileNameSymptoms}";

        public static string filePathWordList = $"{fileStoreDirectory}{fileNameWordList}";
        public static string filePathEnglishWordList = $"{fileStoreDirectory}{fileNameEnglishWordList}";



        //Big list of people, dates, region, sex, dates, symptoms, conditions, age.
        string FilePathPeopleDataSet = $"{fileStoreDirectory}Copy of DataSet of people with symptoms and conditions.xlsx";
        string CSVFilePathPeopleDataSet = $"{fileStoreDirectory}Copy of DataSet of people with symptoms and conditions.csv";

        //list of diseases and their associated symptoms
        string FilePathDiseasesWithTheirSymptoms = $"{fileStoreDirectory}List of diseases with multiple symptoms.csv";

        //List of diseases and their description
        string FilePathDiseasesWithDescriptions = $"{fileStoreDirectory}Disease explanations and definitions.csv";

        //list of diseases and their treatments and cures
        string FilePathDiseasesWithTreatmentsAndCures = $"{fileStoreDirectory}Diseases treatments and cures.csv";



        //Redo the method ExcelObjectGenerator() it's too slow and the data is too big. It tackles the data of user-IDS, age, sex, country, checkin date, 
        //trackable ID (symptom, condition, tag?, food, weather), trackable name (condition, symptom), trackable value (dosage amount of medicine or something).
        //It is under: public string xlsxFile = $"{fileStoreDirectory}DataSet of people with symptoms and conditions.xlsx";

        //List<Condition> conditionsList = new();
        //List<Symptom> symptomsList = new();
        //List<Condition> conditionsWithSymptoms = new();


        //**Here are all the lists/Data needed throughout the website**
        //List of English words
        public readonly List<string> EnglishWordList = new();
        //list of allergies
        readonly List<Allergy> allergyList = new();
        //list of symptoms
        readonly List<Symptom> symptoms1 = new();
        //List of conditions and their symptoms
        readonly List<Condition> conditions1 = new();
        //list of condition definitions
        readonly List<Condition> diseasesDefinitions = new();
        //list of people, age,  region, correlating the dates for symptoms and conditions.
        readonly List<Patient> patientDataList = new();


        /// <summary>
        ///  Reads data from a CSV file, performs necessary checks for file existence and null arguments, and returns the data as a list of string arrays based on the rows.
        /// </summary>
        /// <param name="filePath">FilePath for a CSV file.</param>
        /// <returns> List<string>[] string arrays of words </returns>
        /// <exception cref="ArgumentException">when file path does not exist</exception>
        /// <exception cref="ArgumentNullException">when the file path is null</exception>
        public List<string[]> CSVReader(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("CSVReader: The specified path does not exist.", nameof(filePath));
            }
            if (filePath == null)
            {
                throw new ArgumentNullException("CSVReader: The specified path is null.", nameof(filePath));
            }
            //string[] PeopleDataSet = new string[0];
            List<string[]> DataList = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");


                while (!parser.EndOfData)
                {
                    string[]? RowData = parser.ReadFields();

                    if (RowData != null)
                    {
                        DataList.Add(RowData);
                    }
                }

                return DataList;
            }

        }



        /// <summary>
        /// A one time setup, creates a string list from a textfile and extracts data from an Excel file,
        /// then saves both processes/lists into some local xml files.
        /// </summary>
        public void oneTimeSetup()
        {

            //ExcelObjectGenerator(FilePathPeopleDataSet, filePathConditions, filePathSymptoms);
            //ListSetup(wordList, filePathWordList); //TODO: this is just a temporary wordlist of english words replace with symptoms and conditions
        }

        /// <summary>
        /// Checks to see if a file exists in a filePath, if it doesn't it gets created. 
        /// </summary>
        /// <param name="filePath">file path of the file being checked.</param>
        public void FileStartUpCheck(string filePath)
        {
            if (File.Exists(filePath))
            {
                return;
            }
            File.Create(filePath);
        }

        /// <summary>
        /// This method is designed for initial setup, specifically to extract word lists from data.
        /// </summary>
        public void AutoCompleteWordListInitialSetup()
        {
            //check to see if lists exists already or if their empty or null first. If they dont pass, override them with these methods.
        }


        /// <summary>
        /// Reads data from a CSV file, specifically looking for rows where the 7th column contains the word "symptom" (case-insensitive). 
        /// It extracts the 8th's column information and adds it to a string list. 
        /// </summary>
        /// <param name="filePath">filepath of the CSV file for People DataSet</param>
        /// <param name="wordlist">A string list to store the symptoms word list</param>
        /// <returns>List<string>list of symptoms</returns>
        public List<string> SymptomWordListSetup(string filePath, List<string> wordlist)
        {
            HashSet<string> Stringhashset = new HashSet<string>();
            try
            {
                List<string[]> data = new(CSVReader(filePath));

                foreach (string[] row in data)
                {
                    if (row.Length != 0 || row != null)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (string.Equals("symptom", row[7], StringComparison.CurrentCultureIgnoreCase))
                            {
                                Stringhashset.Add(row[8]);
                            }
                        }
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine($"SymptomWordListSetup: The file '{filePath}' was not found.");
            }
            catch (IOException message)
            {
                Console.WriteLine($"SymptomWordListSetup: An error occurred while reading the file '{filePath}': {message.Message}.");
            }
            catch (Exception message)
            {
                Console.WriteLine($"SymptomWordListSetup: Unexpected error  ocurred: {message.Message}.");
            }

            //TODO: add something to remove all doubles before returning the stringlist
        }


        /// <summary>
        /// Reads data from a CSV file, specifically looking for rows where the 7th column contains the word "condition" (case-insensitive). 
        /// It extracts the 8th's column information and adds it to a string list. 
        /// </summary>
        /// <param name="filePath">filepath of the CSV file for People DataSet</param>
        /// <param name="wordlist">A string list to store the condtion word list</param>
        /// <returns>List<string>list of conditions</returns>
        public List<string> ConditionWordListSetup(string filePath, List<string> wordlist)
        {
            HashSet<string> StringHashSet = new HashSet<string>();
            try
            {
                List<string[]> data = new(CSVReader(filePath));

                foreach (string[] row in data)
                {
                    if (row.Length != 0 || row != null)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (string.Equals("condition", row[7], StringComparison.CurrentCultureIgnoreCase))
                            {
                                StringHashSet.Add(row[8]);
                            }
                        }
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine($"ConditionWordListSetup: The file '{filePath}' was not found.");
            }
            catch (IOException message)
            {
                Console.WriteLine($"ConditionWordListSetup: An error occurred while reading the file '{filePath}': {message.Message}.");
            }
            catch (Exception message)
            {
                Console.WriteLine($"ConditionWordListSetup: Unexpected error  ocurred: {message.Message}.");
            }

            //List<string> StringList = StringHashSet.ToList();
            return StringHashSet.ToList();
        }

        /// <summary>
        /// Reads data from two CSV files, gathers the titles of the diseases. Creates one list, without duplicates, intended to be used for autocomplete component. 
        /// </summary>
        /// <param name="filePath">CSV file of Diseases and their definitions</param>
        /// <param name="filePath2">CSV file of Diseases and their precautions</param>
        /// <param name="wordlist">Used to temporarily store the diseases word list</param>
        /// <returns>list<string> of diseases</returns>
        public List<string> DiseasesWordListSetup(string filePath, string filepath2, List<string> wordlist)
        {
            HashSet<string> DiseaseHashList = new HashSet<string>();
            try
            {
                List<string[]> data = new(CSVReader(filePath));

                foreach (string[] row in data)
                {
                    if (row.Length != 0 || row != null)
                    {
                        DiseaseHashList.Add(row[1]);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"DiseaseWordListSetup: The file '{filePath}' was not found.");
            }
            catch (IOException message)
            {
                Console.WriteLine($"DiseaseWordListSetup: An error occurred while reading the file '{filePath}': {message.Message}.");
            }
            catch (Exception message)
            {
                Console.WriteLine($"DiseaseWordListSetup: Unexpected error  ocurred: {message.Message}.");
            }


            try
            {
                List<string[]> data = new(CSVReader(filepath2));

                foreach (string[] row in data)
                {
                    if (row.Length != 0 || row != null)
                    {
                        DiseaseHashList.Add(row[1]);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"DiseaseWordListSetup: The file '{filepath2}' was not found.");
            }
            catch (IOException message)
            {
                Console.WriteLine($"DiseaseWordListSetup: An error occurred while reading the file '{filepath2}': {message.Message}.");
            }
            catch (Exception message)
            {
                Console.WriteLine($"DiseaseWordListSetup: Unexpected error  ocurred: {message.Message}.");
            }

            return DiseaseHashList.ToList();
        }


        /// <summary>
        /// TEMPORARY TEST
        /// Takes in a textfile of strings and a List<string>, 
        /// separates the textfile into strings saving each one into the List provided,
        /// then saves the string list into a local xml file.
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="filePathTextFile"></param>
        public void StringListSetup(List<string> strings, string filePathTextFile)
        {
            //var filepath = fileNameWordList;
            //using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
            //FileMode.Create, FileAccess.Write)))
            //{
            //    writer.WriteLine("sep=,");
            //    writer.WriteLine("Hello, Goodbye");
            //}
            string[] lines = File.ReadAllLines(filePathTextFile);
            foreach (string line in lines)
            {
                strings.Add(line);
            }
            XmlWriter(strings, filePathEnglishWordList);
        }



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



        //Too Slow, problem is that it opens and closes this program (excel) for every patient data. There's a couple second delay whenever it opens and closes.
        //There's millions of userss.
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
