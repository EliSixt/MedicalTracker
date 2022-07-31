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


        /// <summary>
        /// Constrains to only accept types that implement the ICloneable interface.
        /// Clones the item that is going to be added to the list.
        /// Checks the list for any duplicate of the item being added.
        /// If no duplicates are found, then the item gets added to the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="item"></param>
        /// <returns>True if duplicate and does NOT add to the list, false if no duplicate and adds to a list.</returns>
        public static bool AddWithoutDuplicates<T>(this List<T> value, T item) where T : ICloneable
        {
            T newItem = (T)item.Clone();

            if (!value.HasDuplicate(newItem))
            {
                value.Add(newItem);
                return true;
            }
            return false;
        }
    }
}
