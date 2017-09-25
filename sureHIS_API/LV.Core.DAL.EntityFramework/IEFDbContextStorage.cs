using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace LV.Core.DAL.EntityFramework
{
    public interface IEFDbContextStorage
    {
        /// <summary>
        /// Gets the db context for key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        EFDbContext GetEFDbContextForKey(string key);

        /// <summary>
        /// Sets the db context for key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="objectContext">The object context.</param>
        void SetEFDbContextForKey(string key, EFDbContext dbContext);

        /// <summary>
        /// Gets all db contexts.
        /// </summary>
        /// <returns></returns>
        IEnumerable<EFDbContext> GetAllDbContexts();
    }
}
