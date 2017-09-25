/* Lac Viet ERP                                                
 * Copyright (c) 2011 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EFDbContextManager.cs         
 * Created by           : LDUY - 04/12/2012 16:35:54                     
 * Last modify          :                    
 * Version              : 1.0                                  
 * ============================================================
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Data.Entity.Design;
using LV.Core.DAL.Base;

namespace LV.Core.DAL.EntityFramework
{
    public class EFDbContextManager
    {
        private const string STORAGE_KEY = "HTTPContextSession";

        /// <summary>
        /// Get DB context for key (Per session)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static EFDbContext GetEFDbContextForKey(string key)
        {
            EFDbContext dbContext = null;
            HttpContext context = HttpContext.Current;

            if (context != null && context.Session != null)
            {
                EFDbContextStorage ctxStorage = context.Session[STORAGE_KEY] as EFDbContextStorage;

                if (ctxStorage != null)
                    dbContext = ctxStorage.GetEFDbContextForKey(key);
            }

            return dbContext;
        }

        /// <summary>
        /// Add DBContext to store
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dbContext"></param>
        public static void AddEFDbContextToStore(string key, EFDbContext dbContext)
        {
            HttpContext context = HttpContext.Current;

            if (context != null && context.Session != null)
            {
                EFDbContextStorage ctxStorage = context.Session[STORAGE_KEY] as EFDbContextStorage;

                if (ctxStorage == null)
                    ctxStorage = new EFDbContextStorage();

                ctxStorage.SetEFDbContextForKey(key, dbContext);
                context.Session[STORAGE_KEY] = ctxStorage;
            }
        }

        /// <summary>
        /// Get all DB Context
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<EFDbContext> GetAllEFDbContext()
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null)
            {
                EFDbContextStorage ctxStorage = context.Session[STORAGE_KEY] as EFDbContextStorage;
                return ctxStorage.GetAllDbContexts();
            }
            else
                return null;
        }

        /// <summary>
        /// Close all db context
        /// </summary>
        public static void CloseAllDbContext()
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null)
            {
                EFDbContextStorage ctxStorage = context.Session[STORAGE_KEY] as EFDbContextStorage;

                if (ctxStorage != null)
                {
                    foreach (EFDbContext ctx in ctxStorage.GetAllDbContexts())
                    {
                        if (ctx.Database.Connection.State == System.Data.ConnectionState.Open)
                            ctx.Database.Connection.Close();

                        if (ctx.ObjectContext.Connection.State == System.Data.ConnectionState.Open)
                            ctx.Database.Connection.Close();

                        ctx.ObjectContext.Dispose();
                        ctx.Dispose();
                    }

                    context.Session.Remove(STORAGE_KEY);
                }
            }
        }

        /// <summary>
        /// Close all db context
        /// </summary>
        public static void CloseAllDbContext(IDALContainer dalContainer)
        {
            HttpContext context = HttpContext.Current;
            if (context != null && context.Session != null)
            {
                EFDbContextStorage ctxStorage = context.Session[STORAGE_KEY] as EFDbContextStorage;

                if (ctxStorage != null)
                {
                    foreach (EFDbContext ctx in ctxStorage.GetAllDbContexts())
                    {
                        if (ctx.Database.Connection.State == System.Data.ConnectionState.Open)
                            ctx.Database.Connection.Close();

                        ctx.Dispose();
                    }

                    context.Session.Remove(STORAGE_KEY);
                }
            }
            else if (dalContainer != null)
            {
                dalContainer.Close();
                dalContainer.Dispose();
            }
        }
    }
}
