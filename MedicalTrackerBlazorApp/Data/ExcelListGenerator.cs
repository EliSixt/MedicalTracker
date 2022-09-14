using MedicalTracker;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace MedicalTrackerBlazorApp.Data
{
    public class ExcelListGenerator
    {
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
            }

            XmlWriter(excelList.Conditions, filePathConditions);
            XmlWriter(excelList.Symptoms, filePathSymptoms);
            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            return excelList;
        }
    }
}
