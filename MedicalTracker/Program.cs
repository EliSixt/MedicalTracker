using System;
using System.Collections.Generic;

namespace MedicalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
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
                practicePatient.Allergies.Add(new Allergies
                {
                    IngestionOnly = true,
                    AlgyType = "peanuts",
                    ConfirmedTestedAlgyType = true,
                    BriefDescriptionOfReactions = "Swelling of face and neck",
                    IslifeThreatening = true,
                    SymptomsLeadingToLifeThreatening = "Tightening of the airways and throat, causing trouble breathing",
                    EpiPenRequired = true,
                    CPRRequired = false,
                    TreatmentRequired = "Administer EpiPen"
                });
                practicePatient.Allergies.Add(new Allergies
                {
                    IngestionOnly = true,
                    AlgyType = "Penicillin",
                    ConfirmedTestedAlgyType = true,
                    BriefDescriptionOfReactions = "Rashes, hives, itchy eyes, and swollen lips, tongue, or face. Within an hour.",
                    IslifeThreatening = true,
                    SymptomsLeadingToLifeThreatening = "Tightening of the airways and throat, causing trouble breathing, Nausea or abdominal cramps, Vomiting or diarrhea, Dizziness or lightheadedness, Weak, rapid pulse, Drop in blood pressure, Seizures, Loss of consciousness",
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
                            AllergyAlerts = null
                        }
                    }
                });
                return practicePatient;
            }
        }
    }
}
