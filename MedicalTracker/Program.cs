using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace MedicalTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePathConditions = @"C:\Users\Elias\OneDrive\TMP\conditionsData.xml";
            string filePathSymptoms = @"C:\Users\Elias\OneDrive\TMP\symptomsData.xml";
            //string testFilePath = @"C:\TMP\testFile.xml";

            List<Condition> conditionsList = new();
            List<Symptom> symptomsList = new();
            List<Condition> conditionsWithSymptoms = new();
            List<Appointment> appointmentsList = new();

            //This a test for serializing to a local file
            //Directory.CreateDirectory(@"C:\TMP");
            //List<string> testFile = new List<string>();
            //testFile.Add("This is a test to make sure i dont get a directory access denied exception.");


            conditionsList = XmlReader<List<Condition>>(filePathConditions);
            symptomsList = XmlReader<List<Symptom>>(filePathSymptoms);

            //copies the condition list into conditionsWithSymptoms
            foreach (Condition item in conditionsList)
            {
                conditionsWithSymptoms.Add(item);
            }

            //includes any possible symptoms (based on a timeSpan) onto their respective conditions in conditionsWithSymptoms
            foreach (Condition condition in conditionsWithSymptoms)
            {
                foreach (Symptom symptom in symptomsList)
                {
                    if (condition.UserID == symptom.UserID)
                    {
                        DateTime symptomDate = DateTime.FromOADate(symptom.Date);
                        DateTime conditionDate = DateTime.FromOADate(condition.Date);
                        TimeSpan timeSpan = conditionDate - symptomDate;
                        if (timeSpan.Days < 2 && timeSpan.Days > 2)
                        {
                            condition.Symptoms.Add(symptom);
                        }
                    }
                }
            }


            //tries to group people by age and counts/shows how many inputs are in that age group
            var query = conditionsList.GroupBy(
                x => Math.Floor(x.Age),
                x => x.Age,
                (baseAge, ages) => new
                {
                    Key = baseAge,
                    Count = ages.Count(),
                    Min = ages.Min()
                    //Max = ages.Max()
                }).OrderBy(x => x.Min);

            foreach (var result in query)
            {
                Console.WriteLine($"Age group = {result.Key}");
                Console.WriteLine($"Number of inputs with this age = {result.Count}");
            }




            ////Create Excel Objects.
            //Application excelApp = new Application();

            //if (excelApp == null)
            //{
            //    Console.WriteLine("Excel is not installed!!");
            //    return;
            //}

            //Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\elias\OneDrive\Documents\PeoplewithSymptomsAndConditions.xlsx");
            //Worksheet excelSheet = excelBook.Sheets[1];
            //Range excelRange = excelSheet.UsedRange;

            //int rowCount = excelRange.Rows.Count;
            //int colCount = excelRange.Columns.Count;

            //for (int i = 2; i <= rowCount; i++)
            //{
            //    if (excelRange.Cells[i, 7].Value2 == "Symptom")
            //    {
            //        Symptom symptom = new();
            //        symptom.UserID = excelRange.Cells[i, 1].Value2.ToString();                    
            //        if (excelRange.Cells[i, 5].Value2 != null)
            //        {
            //            symptom.Date = excelRange.Cells[i, 5].Value2;
            //        }
            //        if (excelRange.Cells[i, 8].Value2 != null)
            //        {
            //            symptom.Name = excelRange.Cells[i, 8].Value2.ToString();
            //        }
            //        if (excelRange.Cells[i, 9].Value2 != null)
            //        {
            //            symptom.Severity = excelRange.Cells[i, 9].Value2.ToString();
            //        }
            //        symptomsList.Add(symptom);
            //    }
            //    if (excelRange.Cells[i, 7].Value2 == "Condition")
            //    {

            //        Condition condition = new Condition();

            //        condition.UserID = excelRange.Cells[i, 1].Value2.ToString();
            //        if (excelRange.Cells[i, 2].Value2 != null)
            //        {
            //            condition.Age = excelRange.Cells[i, 2].Value2;
            //        }
            //        if (excelRange.Cells[i, 3].Value2 != null)
            //        {
            //            condition.Sex = excelRange.Cells[i, 3].Value2.ToString();
            //        }
            //        if (excelRange.Cells[i, 5].Value2 != null)
            //        {
            //            condition.Date = excelRange.Cells[i, 5].Value2;
            //        }
            //        //condition.TrackableType = excelRange.Cells[i, 7].Value2.ToString();
            //        if (excelRange.Cells[i, 8].Value2 != null)
            //        {
            //            condition.Name = excelRange.Cells[i, 8].Value2.ToString();
            //        }
            //        if (excelRange.Cells[i, 9].Value2 != null)
            //        {
            //            condition.Severity = excelRange.Cells[i, 9].Value2.ToString();
            //        }
            //        if (excelRange.Cells[i, 4].Value2 != null)
            //        {
            //            condition.Country = excelRange.Cells[i, 4].Value2.ToString();//this has null exception
            //        }
            //        conditionsList.Add(condition);
            //    }
            //    XmlWriter(conditionsList, filePathConditions);
            //    XmlWriter(symptomsList, filePathSymptoms);
            //    //create new line
            //    Console.Write("\r\n");
            //    //for (int j = 1; j <= colCount; j++)
            //    //{

            //    //    //write the console
            //    //    if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
            //    //        Console.Write(excelRange.Cells[i, j].Value2.ToString() + "\t");
            //    //}
            //}
            ////after reading, relaase the excel project
            //excelApp.Quit();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            //Console.ReadLine(); 



            Patient p = TestPatient();


            //Get the next appointments
            foreach (Appointment app in p.Appointments)
            {
                if (app.Date > DateTime.Now)
                {
                    Console.WriteLine($"{app.BriefDiscription} {app.Date} {app.PlaceOfAppointment.Address}"); //ContactInfo needs a tostring method
                }
            }


            //BIG TODO: generate methods for common usages of the app
            //TODO list:
            //functinality to add appointment
            //alert on upcoming routine
            //alert/Get the next daily medicines
            //method to parse datetime string
            //method to Address
            //method to ContactInfo
            //method to parse a string to an int. int.parse?
            //

        }
        /// <summary>
        /// Method that serializes a list<Object>.
        /// </summary>
        /// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        /// <param name="listToStore">The list to serialize.</param>
        public static void XmlWriter<T>(List<T> listToStore, string aFilePath)
        {
            XmlSerializer xmlSerializer = new(typeof(List<T>));
            using (TextWriter tx = new StreamWriter(aFilePath))
            {
                xmlSerializer.Serialize(tx, listToStore);
            }

        }

        /// <summary>
        /// Method that deserializes a list<object>.
        /// </summary>
        /// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        /// <typeparam name="T">The type of object of the list.</typeparam>
        /// <returns>A deserialized list object.</returns>
        public static T XmlReader<T>(string aFilePath)
        {
            XmlSerializer xmlSerializer = new(typeof(T));
            using (TextReader tx = new StreamReader(aFilePath))
            {
                return (T)xmlSerializer.Deserialize(tx);
            }
        }
        /// <summary>
        /// Gets Address items from the user.
        /// </summary>
        /// <returns>Filled in Address object.</returns>
        public static Address GetAddress()
        {
            Address address = new()
            {
                BuildingNumber = UI.UserInputToInt("Enter building number."),
                StreetName = UI.GetString("Enter street name."),
                City = UI.GetString("Enter city."),
                State = UI.GetString("Enter state."),
                ZIPCode = UI.UserInputToInt("Enter Zipcode.")
            };
            return address;
        }
        /// <summary>
        /// Uses UI method to enter specific fields within Name.
        /// </summary>
        /// <returns>Filled new Name class.</returns>
        public static Name GetName()
        {
            Name name = new()
            {
                FirstName = UI.GetString("Enter first name."),
                LastName = UI.GetString("Enter last name."),
                MiddleName = UI.GetString("Enter middle name.")
            };
            return name;
        }
        /// <summary>
        /// Gets the ContactInfo items from the user and returns a filled ContactInfo object.
        /// </summary>
        /// <returns>Filled out new ContactInfo.</returns>
        public static ContactInfo GetContactInfo()
        {
            ContactInfo contactInfo = new()
            {
                Address = GetAddress(),
                TitleOrRelationship = UI.GetString("Enter title and/or relationship."),
                Name = GetName(),
                Email = UI.GetString("Enter email."),
                MobilePhoneNum = UI.GetString("Enter mobile phone number."),
                HomePhoneNum = UI.GetString("Enter home phone number."),
                WorkPhoneNum = UI.GetString("Enter work phone number.")
            };

            return contactInfo;
        }
        /// <summary>
        /// Parse a string into datetime format, from the user input.
        /// </summary>
        /// <returns>A Datetime from the user.</returns>
        public static DateTime GetDateTime()
        {
            //This should help.https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=net-6.0
            DateTime dateTime = new();
            bool validDate = false;
            Console.WriteLine("Enter date and time. Ex: '12/30/2022 7:30am'");
            do
            {
                validDate = DateTime.TryParse(Console.ReadLine(), out dateTime);//try to make a loop until it passes
                if (!validDate)
                {
                    Console.WriteLine("Please enter a valid date.");
                }
            } while (!validDate);
            return dateTime;
        }

        public static Patient AddAppointment(Patient Currentpatient, string DateAndTime)
        {
            Currentpatient.Appointments.Add(new Appointment()
            {
                //BriefDiscription = "Getting blood pressure checked",
                //Date = new DateTime(2022, 12, 01),
                //Time = new TimeSpan(08, 00, 00),
                //PlaceOfAppointment = new ContactInfo()
                //{
                //    Address = new Address() { City = "louisville", StreetName = "streeeat", BuildingNumber = 8989 },
                //    Name = new Name() { FirstName = "Dr.Gray", LastName = "Shady" },
                //    Email = "Gray_shade@yahoo.com",
                //    WorkPhoneNum = "502-777-8888"

                Date = GetDateTime(),
                PlaceOfAppointment = new ContactInfo()
                {
                    Address = GetAddress(),
                    Name = GetName(),

                }

            });
            return Currentpatient;
        }
        public static Patient TestPatient()
        {
            Patient practicePatient = new();

            practicePatient.PatientInfo.Name.FirstName = "Larry";
            practicePatient.PatientInfo.Name.MiddleName = "zoomy";
            practicePatient.PatientInfo.Name.LastName = "Quincey";

            practicePatient.PatientInfo.MobilePhoneNum = "502-800-8080";
            practicePatient.PatientInfo.Email = "LarryIsCool@gmail.com";
            practicePatient.PatientInfo.Address.BuildingNumber = 8080;
            practicePatient.PatientInfo.Address.StreetName = "CoolStreet Blvd";
            practicePatient.PatientInfo.Address.City = "louisville";
            practicePatient.PatientInfo.Address.State = "kentucky";
            practicePatient.PatientInfo.Address.ZIPCode = 41234;

            //emergency contacts
            practicePatient.EmergencyContacts.Add(new ContactInfo
            {
                Name = new Name { FirstName = "Jose", LastName = "Swaln", MiddleName = "R" },
                Address = new Address { City = "louisville", State = "kentucky", StreetName = "Lincoln", BuildingNumber = 89999, ZIPCode = 44444 },
                Email = "something@gmail.com",
                MobilePhoneNum = "5048790990",
                HomePhoneNum = "777-777-7777"
            });
            practicePatient.EmergencyContacts.Add(new ContactInfo
            {
                Name = new Name { FirstName = "Frank", LastName = "Dogs", MiddleName = "R" },
                Address = new Address { City = "louisville", State = "kentucky", StreetName = "Hotdog", BuildingNumber = 1234, ZIPCode = 12345 },
                Email = "HotDogs@gmail.com",
                MobilePhoneNum = "5001231234",
                HomePhoneNum = "123-123-1234"
            });

            //caretakers
            practicePatient.EmergencyContacts.Add(new ContactInfo
            {
                Name = new Name { FirstName = "John", LastName = "Smith", MiddleName = "umbrela" },
                Address = new Address { City = "louisville", State = "kentucky", StreetName = "Lindon", BuildingNumber = 89923, ZIPCode = 44454 },
                Email = "JohnSmith@gmail.com",
                MobilePhoneNum = "5048791234",
                HomePhoneNum = "777-210-5432"
            });
            practicePatient.EmergencyContacts.Add(new ContactInfo
            {
                Name = new Name { FirstName = "Mike", LastName = "Mouse", MiddleName = "Emph" },
                Address = new Address { City = "louisville", State = "kentucky", StreetName = "Hills", BuildingNumber = 8888, ZIPCode = 47767 },
                Email = "Disneyy@gmail.com",
                MobilePhoneNum = "502-345-7777",
                HomePhoneNum = "999-888-7777"
            });

            //allergies
            practicePatient.Allergies.Add(new Allergy
            {
                IngestionOnly = true,
                AlgyName = "peanuts",
                ConfirmedTestedAlgyType = true,
                BriefDescriptionOfReactions = "Swelling of face and neck",
                IslifeThreatening = true,
                SymptomsLeadingToLifeThreatening = "Tightening of the airways and throat, causing trouble breathing",
                EpiPenRequired = true,
                CPRRequired = false,
                TreatmentRequired = "Administer EpiPen"
            });
            practicePatient.Allergies.Add(new Allergy
            {
                IngestionOnly = true,
                AlgyName = "Penicillin",
                ConfirmedTestedAlgyType = true,
                BriefDescriptionOfReactions = "Rashes, hives, itchy eyes, and swollen lips, tongue, or face. Within an hour.",
                IslifeThreatening = true,
                SymptomsLeadingToLifeThreatening = "Tightening of the airways and throat, causing trouble breathing, Nausea or abdominal cramps, Vomiting or diarrhea, Dizziness or lightheadedness," +
                " Weak, rapid pulse, Drop in blood pressure, Seizures, Loss of consciousness",
                EpiPenRequired = false,
                CPRRequired = true,
                Call911 = true,
                TreatmentRequired = "Withdrawal of the drug, Antihistamine related drugs",
                AlgyTreatmentMedication = new List<Medicine>() {
                        new Medicine() {
                            BrandName = "Benadryl Allergy, Benadryl Children's Allergy, DiphenMax, Dytan, Uni-Tann",
                            GenericName = "antihistamine",
                            Description = null,
                            Warnings = "This medicine may also interact with the following medications: alcohol, barbiturates, like phenobarbital, " +
                            "medicines for bladder spasm like oxybutynin, tolterodine, medicines for blood pressure, medicines for depression, anxiety, or psychotic disturbances, " +
                            "medicines for movement abnormalities or Parkinson's disease, medicines for sleep, " +
                            "other medicines for cold, cough or allergy, some medicines for the stomach like chlordiazepoxide, dicyclomine",
                            WorriesomeSideEffects = "allergic reactions like skin rash, itching or hives, swelling of the face, lips, or tongue, changes in vision, confused, agitated, " +
                            "nervous, irregular or fast heartbeat, tremor, trouble passing urine, unusual bleeding or bruising, unusually weak or tired",
                            CommmonSideEffects = "constipation, diarrhea, drowsy, headache, loss of appetite, stomach upset, vomiting, thick mucous",
                            Uses = "It is used to treat the symptoms of an allergic reaction.",
                            Directions = "Take this medicine by mouth. Chew it completely before swallowing. Follow the directions on the prescription label. " +
                            "Take your doses at regular intervals. Do not take your medicine more often than directed.",
                            Purposes = "Ask healthcare provider",
                            AllergyAlerts = null,
                            WarningsBeforeUse = null,
                            OtherDrugsThatMayCauseAReaction = null
                        }
                    }
            });

            //Emergency medicine
            practicePatient.EmergencyMedications.Add(new Medicine()
            {
                BrandName = "EpiPen 2-Pak, EpiPen JR 2-Pak",
                GenericName = "epinephrine injection (EP i NEF rin)",
                Description = "EpiPen is an injection containing epinephrine, a chemical that narrows blood vessels and opens airways in the lungs. " +
                "These effects can reverse severe low blood pressure, wheezing, severe skin itching, hives, and other symptoms of an allergic reaction",
                Warnings = "Seek emergency medical attention even after you use EpiPen to treat a severe allergic reaction. The effects may wear off after 10 or 20 minutes." +
                " You will need to receive further treatment and observation." +
                "Before using EpiPen a second time, tell your doctor if your first injection caused a serious side effect such as increased breathing difficulty, or dangerously high blood pressure(severe headache," +
                " blurred vision, buzzing in your ears, anxiety, confusion, chest pain, shortness of breath, uneven heartbeats, seizure)",
                WorriesomeSideEffects = "increased breathing difficulty, or dangerously high blood pressure(severe headache," +
                " blurred vision, buzzing in your ears, anxiety, confusion, chest pain, shortness of breath, uneven heartbeats, seizure.",
                CommmonSideEffects = "breathing problems; fast, irregular, or pounding heartbeats; pale skin, sweating; nausea and vomiting;" +
                " dizziness; weakness or tremors; headache; orfeeling restless, fearful, nervous, anxious, or excited",
                Uses = "To treat allergic reactions",
                Directions = "Form a fist around the Auto-Injector with the black tip pointing down. Pull off the safety cap. " +
                "Place the black tip against the fleshy portion of the outer thigh.You may give the injection directly through your clothing.Do not put your thumb over the end of the unit.Hold the leg firmly when giving this injection to a child or infant." +
                "With a quick motion, push the Auto - Injector firmly against the thigh.This will release the spring - loaded needle that injects the dose of epinephrine.Hold the Auto - Injector in place for a few seconds after activation. " +
                "Remove the Auto - Injector from the thigh.Carefully re - insert the used device needle - first into the carrying tube. " +
                "Re- cap the tube and take it with you to the emergency room so that anyone who treats you will know how much epinephrine you have received.",
                Purposes = "To treat allergic reaction",
                AllergyAlerts = "Notify doctor of past reactions",
                WarningsBeforeUse = "Before using EpiPen, tell your doctor if any past use has caused an allergic reaction to get worse. " +
                "To make sure this medicine is safe for you, tell your doctor if you have ever had: heart disease or high blood pressure;" +
                " asthma; Parkinson's disease; depression or mental illness; a thyroid disorder; or diabetes. Having an allergic reaction while pregnant or nursing could harm both mother and baby. " +
                "You may need to use EpiPen during pregnancy or while you are breastfeeding. Seek emergency medical attention right away after using the injection." +
                " If possible during an emergency, tell your medical caregivers if you are pregnant or breastfeeding.",
                OtherDrugsThatMayCauseAReaction = "asthma medicine; an antidepressant; cold or allergy medicine(Benadryl and others); heart or blood pressure medicine; " +
                "thyroid medication; or ergot medicine - dihydroergotamine, ergotamine, ergonovine, methylergonovine."
            });

            //daily medicine
            practicePatient.DailyMedication.Add(new DailyMedicine()
            {
                Medicine = new Medicine()
                {
                    BrandName = "Dabigatran",
                    GenericName = "Pradaxa",
                    Description = "Blood thinners",
                    Purposes = "It can treat and prevent blood clots, reducing the risk of stroke.",
                    Warnings = "Premature discontinuation of any oral anticoagulant, including dabigatran, increases the risk of thrombotic events." +
                    "If anticoagulation with dabigatran must be discontinued for a reason other than pathological bleeding, consider coverage with another anticoagulant."
                },
                DoseMg = "150 mg",
                FrequencyOfDose = "Orally Twice Daily",
                TimeSpanOfDose = new TimeSpan(12, 33, 00) //every 12 hours
            });

            //appointments
            practicePatient.Appointments.Add(new Appointment()
            {
                BriefDiscription = "Getting blood pressure checked",
                Time = new TimeSpan(08, 34, 00),
                Date = new DateTime(2022, 12, 01),
                PlaceOfAppointment = new ContactInfo()
                {
                    Address = new Address() { City = "louisville", StreetName = "streeeat", BuildingNumber = 8989 },
                    Name = new Name() { FirstName = "Dr.Gray", LastName = "Shady" },
                    Email = "Gray_shade@yahoo.com",
                    WorkPhoneNum = "502-777-8888"
                }
            });
            //Medical history
            practicePatient.MedicalCondition.Add(new MedicalHistory()
            {
                MedicalCondition = "Diabietes",
                CounterMeasures = "Dont eat sugars",
                Symptoms = null,
                Treatment = "Take medication on time and excercise",
                Medicine = new Medicine() { BrandName = "insulin", Description = "To treat diabietes", Directions = "Administer by injection" }
            });
            //UnUsual symtoms list
            practicePatient.UnusualSymptoms.Add(new UnusualSymptoms() { Symptom = "Lots of unusal burping" });
            practicePatient.UnusualSymptoms.Add(new UnusualSymptoms { Symptom = "Lack of sleep from burping" });
            //additional needs
            practicePatient.AdditionalNeeds.Add(new AdditionalNeeds() { Needs = "Needs to be turned over to prevent bedsores" });

            return practicePatient;
        }
    }
}
