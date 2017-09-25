/* Lac Viet ERP                                                
 * Copyright (c) 2011 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EFDbContext.cs         
 * Created by           : LDUY - 03/24/2012 11:50:00                     
 * Last modify          : LDUY - 03/24/2012 11:50:00                     
 * Version              : 1.0                                  
 * ============================================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Reflection;
using System.IO;
using System.Web;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Core.Objects;

namespace LV.Core.DAL.EntityFramework
{
    public class EFDbContext :DbContext, IDbModelCacheKeyProvider
    {
        public string SchemaName { get; private set; }

        //public bool IsSysConnect { get; set; }

        /// <summary>
        /// Contructor DbContext with given connection name
        /// </summary>
        /// <param name="connectionName"></param>
        public EFDbContext(ObjectContext objectContext, string schema)
            : base(objectContext,true)
        {
            SchemaName = schema;
            objectContext.DefaultContainerName = "Entities";
            //if (DBName.Equals(EFDALContainer.DbSystemName, StringComparison.OrdinalIgnoreCase))
            //    IsSysConnect = true;
            //else
            //    IsSysConnect = false;

            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<T>().ToTable("Estate");
        //}

        public EFDbContext(string name)
            : base(name)
        {
            SchemaName = "dbo";
            
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }
        /// <summary>
        /// Get ObjectContext
        /// </summary>
        /// <returns></returns>
        public System.Data.Entity.Core.Objects.ObjectContext ObjectContext
        {
            get
            {
                    return ((IObjectContextAdapter)this).ObjectContext;
            }
        }

        /// <summary>
        /// Lambda expression to get property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="property"></param>
        /// <returns></returns>
        public static Expression<Func<T, U>> BuildLambda<T, U>(PropertyInfo property)
        {
            var param = Expression.Parameter(typeof(T), "p");
            MemberExpression memberExpression = Expression.Property(param, property);
            var lambda = Expression.Lambda<Func<T, U>>(memberExpression, param);
            return lambda;
        }

        /// <summary>
        /// Set precision for decimal column
        /// </summary>
        public static void SetPrecision<T>(EntityTypeConfiguration<T> entityConfig, PropertyInfo property, byte precision, byte scale) where T : class
        {
            var lambda = BuildLambda<T, decimal>(property);
            entityConfig.Property(lambda).HasPrecision(precision, scale);
        }

        /// <summary>
        /// Set model entity
        /// </summary>
        public void SetEntity<T>(DbModelBuilder modelBuilder, string tableName) where T : class
        {
            modelBuilder.Entity<T>();
        }

        public string CacheKey
        {
            get { return this.SchemaName; }
        }
    }
}
