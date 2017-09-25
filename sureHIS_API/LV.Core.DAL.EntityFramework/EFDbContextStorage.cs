using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Web;

namespace LV.Core.DAL.EntityFramework
{
    public class EFDbContextStorage : IEFDbContextStorage
    {
        private Dictionary<string, EFDbContext> storage = new Dictionary<string, EFDbContext>();

        /// <summary>
        /// Stores the db context into a dictionary using the specified key.
        /// If an db context already exists by the specified key, 
        /// it gets overwritten by the new db context passed in.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="objectContext">The Dbcontext.</param>
        public void SetEFDbContextForKey(string key, EFDbContext dbContext)
        {
            if (storage.ContainsKey(key) == false)
                storage.Add(key, dbContext);
        }

        /// Returns the db context associated with the specified key or
        /// null if the specified key is not found.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public EFDbContext GetEFDbContextForKey(string key)
        {
            if (storage.ContainsKey(key))
                return storage[key];
            else
                return null;
        }

        /// <summary>
        /// Returns all the values of the internal dictionary of db contexts.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public IEnumerable<EFDbContext> GetAllDbContexts()
        {
            return storage.Values;
        }
    }
}
