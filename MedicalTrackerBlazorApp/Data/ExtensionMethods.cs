namespace MedicalTrackerBlazorApp.Data
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Checks list if there's an item thats the same as the provided object.
        /// Null checks.
        /// Checks if the list's type and the object's type are the same.
        /// </summary>
        /// <param name="value">The List of items</param>
        /// <param name="objToCheck">Object to compare</param>
        /// <returns>Boolean</returns>
        public static bool HasDuplicate<T>(this List<T> value, T objToCheck)
        {
            if (objToCheck is null && value is null)
            {
                return true;
            }
            if (objToCheck is null || value is null)
            {
                return false;
            }
            foreach (T obj in value)
            {
                if (obj != null && obj.Equals(objToCheck))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
