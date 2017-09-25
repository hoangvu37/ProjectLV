using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LV.Core.DAL.EntityFramework
{
    public class EFDALContainerStorage
    {
        private Dictionary<string, EFDALContainer> storage = new Dictionary<string, EFDALContainer>();

        /// <summary>
        /// Stores the DALContainer into a dictionary using the specified key.
        /// If an DALContainer already exists by the specified key, 
        /// it gets overwritten by the new db context passed in.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="DALContainer">The EFDALContainer.</param>
        public void SetEFDbContextForKey(string key, EFDALContainer dalContainer)
        {
            if (storage.ContainsKey(key) == false)
                storage.Add(key, dalContainer);
        }

        /// Returns the DALContainer associated with the specified key or
        /// null if the specified key is not found.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public EFDALContainer GetEFDALContainerForKey(string key)
        {
            if (storage.ContainsKey(key))
                return storage[key];
            else
                return null;
        }

        /// <summary>
        /// Returns all the values of the internal dictionary of DALContainer.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public IEnumerable<EFDALContainer> GetAllDALContainer()
        {
            return storage.Values;
        }
    }
}
