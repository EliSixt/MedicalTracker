using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalTracker
{
    internal class UI
    {
        //TODO list:
        //functinality to add appointment
        //alert on upcoming routine
        //alert/Get the next daily medicines
        //method to parse datetime string
        //method to Address
        //method to ContactInfo
        //method to parse a string to an int. int.parse?
        //


        /// <summary>
        /// Parsing a string (user input) into an int.
        /// </summary>
        /// <param name="message">A message describing what is needed from the user.</param>
        /// <returns>Int</returns>
        public static int UserInputToInt(string message)
        {
            Console.WriteLine(message);
            int num = int.Parse(Console.ReadLine());//need to get rid of this console.readline later
            return num;
        }
        /// <summary>
        /// Gets a string from the user with a descriptive message.
        /// </summary>
        /// <param name="message">A message describing what is needed from the user.</param>
        /// <returns>String</returns>
        public static string GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
