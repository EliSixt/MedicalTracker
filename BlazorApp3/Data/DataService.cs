using MedicalTracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;


namespace BlazorApp3.Data
{

    public class DataService
    {
        private List<Patient> _patients = new();

        public List<Patient> Patients
        {
            get { return _patients; }
            set { _patients = value; }
        }

        public void AddPatient(Patient P)
        {
            _patients.Add(P);
            //XmlWriter<Patient>(_patients, filePath);

        }
        ///// <summary>
        ///// Method that serializes a list<Object>.
        ///// </summary>
        ///// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        ///// <param name="listToStore">The list to serialize.</param>
        //public static void XmlWriter<T>(T listToStore, string aFilePath)
        //{
        //    XmlSerializer xmlSerializer = new(typeof(T));
        //    using (TextWriter tx = new StreamWriter(aFilePath))
        //    {
        //        xmlSerializer.Serialize(tx, listToStore);
        //    }

        }
    }
}
