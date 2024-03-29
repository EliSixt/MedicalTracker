﻿namespace MedicalTracker
{
    public class Name
    {
        //Middle?
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {MiddleName} {LastName}";
        }

        /// <summary>
        /// Uses the FirstName and LastName from two Name objects and returns if the two objects are the same or not.
        /// </summary>
        /// <param name="obj">Other object being compared.</param>
        /// <returns>Bool</returns>
        public override bool Equals(object obj)
        {
            //if ((obj == null) || this.GetType().Equals(obj.GetType()))
            //{
            //    return false;
            //}
            Name item = obj as Name;
            if (item is null && this is null)
            {
                return true;
            }
            if (item is null || this is null)
            {
                return false;
            }
            return (this.FirstName.ToLower() == item.FirstName.ToLower() && this.LastName.ToLower() == item.LastName.ToLower());
        }

        /// <summary>
        /// Uses the .Equals function to determine if two Name objects are equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>Bool</returns>
        public static bool operator ==(Name obj1, Name obj2)
        {
            if (obj1 is null && obj2 is null)
                return true;

            if (obj1 is null || obj2 is null)
                return false;

            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Uses the .Equals function to determine if two Name objects are not equal to one another.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns>Bool</returns>
        public static bool operator !=(Name obj1, Name obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Gets the hashcode of FirstName + LastName lowercased.
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            //return (FirstName.ToLower() + LastName.ToLower()).GetHashCode();
            int num = (this.FirstName + this.LastName).GetHashCode();
            return num;
        }
    }
}
