using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LV.Core.DAL.EntityFramework
{
    public class EFDALContainerManager
    {
        private const string STORAGE_KEY = "EFDALContainerSession";

        /// <summary>
        /// Get EFDALContainer for key (Per session)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static EFDALContainer GetEFDALContainerForKey(string key)
        {
            EFDALContainer dalContainer = null;
            HttpContext context = HttpContext.Current;

            if (context != null && context.Session != null)
            {
                EFDALContainerStorage ctxStorage = context.Session[STORAGE_KEY] as EFDALContainerStorage;

                if (ctxStorage != null)
                    dalContainer = ctxStorage.GetEFDALContainerForKey(key);
            }

            return dalContainer;
        }

        /// <summary>
        /// Add EFDALContainer to store
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dalContainer"></param>
        public static void AddEFDALContainerToStore(string key, EFDALContainer dalContainer)
        {
            HttpContext context = HttpContext.Current;

            if (context != null && context.Session != null)
            {
                EFDALContainerStorage ctxStorage = context.Session[STORAGE_KEY] as EFDALContainerStorage;

                if (ctxStorage == null)
                    ctxStorage = new EFDALContainerStorage();

                ctxStorage.SetEFDbContextForKey(key, dalContainer);
                context.Session[STORAGE_KEY] = ctxStorage;
            }
        }

        /// <summary>
        /// Get all DALContainer
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<EFDALContainer> GetAllEFDALContainer()
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null)
            {
                EFDALContainerStorage ctxStorage = context.Session[STORAGE_KEY] as EFDALContainerStorage;
                return ctxStorage.GetAllDALContainer();
            }
            else
                return null;
        }

        /// <summary>
        /// Close all DALContainer
        /// </summary>
        public static void CloseAllDALContainer()
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null)
            {
                EFDALContainerStorage ctxStorage = context.Session[STORAGE_KEY] as EFDALContainerStorage;

                if (ctxStorage != null && context.Session != null)
                {
                    foreach (EFDALContainer ctx in ctxStorage.GetAllDALContainer())
                    {
                        ctx.Close();
                        ctx.Dispose();
                    }

                    context.Session.Remove(STORAGE_KEY);
                }
            }
        }
    }
}
