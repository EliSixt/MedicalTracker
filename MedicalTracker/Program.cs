using System;

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

                //emergency calls
                //practicePatient.EmergencyContacts.Add(new ContactInfo { new Name { FirstName = "Joe"} });



                return practicePatient;
            }
        }
    }
}
