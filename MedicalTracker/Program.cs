using System;
using System.Collections.Generic;

namespace MedicalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient p = TestPatient();

            //BIG TODO: generate methods for common usages of the app

            //Get the next appointments
            foreach (var app in p.Appointments)
            {
                if (app.Date > DateTime.Now)
                {
                    Console.WriteLine($"{app.BriefDiscription} {app.Date} {app.PlaceOfAppointment.Address}"); //ContactInfo needs a tostring method
                }
            }



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
        /// Parsing a string (user input) into an int.
        /// </summary>
        /// <returns>Int</returns>
        public static int IntParseString()
        {
            int num = 0;
            num = Convert.ToInt32(Console.ReadLine());//need to get rid of this console.readline later
            return num;
        }
        //public static Address AddAddress()
        //{
        //    Address address = new Address()
        //    {
        //        BuildingNumber = int.Parse(Console.ReadLine()),//throws an ArgumentNullException if put a null value

        //    };
        //    return address;
        //}
        //public static Patient AddAppointment(Patient Currentpatient, string DateAndTime)
        //{
        //    //string value = "12/15/2024 12:30 pm";  assign a value through UI https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse?view=net-6.0

        //    Currentpatient.Appointments.Add(new Appointment()
        //    {
        //        //BriefDiscription = "Getting blood pressure checked",
        //        //Date = new DateTime(2022, 12, 01),
        //        //Time = new TimeSpan(08, 00, 00),
        //        //PlaceOfAppointment = new ContactInfo()
        //        //{
        //        //    Address = new Address() { City = "louisville", StreetName = "streeeat", BuildingNumber = 8989 },
        //        //    Name = new Name() { FirstName = "Dr.Gray", LastName = "Shady" },
        //        //    Email = "Gray_shade@yahoo.com",
        //        //    WorkPhoneNum = "502-777-8888"

        //        Date = DateTime.Parse(DateAndTime),
        //        PlaceOfAppointment = new ContactInfo()
        //        {

        //        }
                
        //    });
        //    return Currentpatient;
        //}
        static Patient TestPatient()
        {
            Patient practicePatient = new Patient();

            practicePatient.PatientInfo.Name.FirstName = "Larry";
            practicePatient.PatientInfo.Name.MiddleInitial = 'Z';
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
                Name = new Name { FirstName = "Jose", LastName = "Swaln", MiddleInitial = 'R' },
                Address = new Address { City = "louisville", State = "kentucky", StreetName = "Lincoln", BuildingNumber = 89999, ZIPCode = 44444 },
                Email = "something@gmail.com",
                MobilePhoneNum = "5048790990",
                HomePhoneNum = "777-777-7777"
            });
            practicePatient.EmergencyContacts.Add(new ContactInfo
            {
                Name = new Name { FirstName = "Frank", LastName = "Dogs", MiddleInitial = 'R' },
                Address = new Address { City = "louisville", State = "kentucky", StreetName = "Hotdog", BuildingNumber = 1234, ZIPCode = 12345 },
                Email = "HotDogs@gmail.com",
                MobilePhoneNum = "5001231234",
                HomePhoneNum = "123-123-1234"
            });

            //caretakers
            practicePatient.EmergencyContacts.Add(new ContactInfo
            {
                Name = new Name { FirstName = "John", LastName = "Smith", MiddleInitial = 'U' },
                Address = new Address { City = "louisville", State = "kentucky", StreetName = "Lindon", BuildingNumber = 89923, ZIPCode = 44454 },
                Email = "JohnSmith@gmail.com",
                MobilePhoneNum = "5048791234",
                HomePhoneNum = "777-210-5432"
            });
            practicePatient.EmergencyContacts.Add(new ContactInfo
            {
                Name = new Name { FirstName = "Mike", LastName = "Mouse", MiddleInitial = 'E' },
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
