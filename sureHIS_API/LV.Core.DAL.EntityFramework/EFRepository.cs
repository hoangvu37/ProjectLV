using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LV.Core.DAL.Base;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Entity.Migrations;
using System.Collections;
using System.Configuration;
using System.Data.Metadata.Edm;
using System.Xml;
using System.Reflection;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core;
using System.Data.Entity;
using System.Web;
using System.Data;
using System.Data.Entity.Infrastructure.Interception;
using log4net;

namespace LV.Core.DAL.EntityFramework
{
    public class EFRepository : IRepository
    {
        private const string ENTITY_KEY_NAME = "RecID";
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IUnitOfWork _UnitOfWork = null;
        private EFDbContext _DbContext = null;
        private System.Data.Entity.Core.Objects.ObjectContext _objectContext { get { return _DbContext.ObjectContext; } }
        private string ConnectString
        {
            get
            {
                DbConnection enCnn = (((IObjectContextAdapter)_DbContext).ObjectContext.Connection as System.Data.Entity.Core.EntityClient.EntityConnection).StoreConnection;
                return enCnn.ConnectionString;
            }
        }
        public EFRepository(IUnitOfWork Uow)
        {
            _DbContext = (EFDbContext)Uow.Orm;

        }

        /// <summary>
        /// Attach the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            dbContext.Set<TEntity>().Attach(entity);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            var ent = dbContext.Set<TEntity>().Add(entity);
            Console.WriteLine(ent.ToString());
        }

        public void AddReturn<TEntity>(TEntity entity, out TEntity inserted) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            inserted = dbContext.Set<TEntity>().Add(entity);
        }
        /// <summary>
        /// Updates changes of the existing entity. 
        /// The caller must later call SaveChanges() on the repository explicitly to save the entity to database
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            System.Data.Entity.Core.Objects.ObjectContext objContext = dbContext.ObjectContext;

            var fqen = GetEntityName<TEntity>();
            System.Data.Entity.Core.EntityKey key = objContext.CreateEntityKey(fqen, entity);

            object originalItem;
            if (objContext.TryGetObjectByKey(key, out originalItem))
            {
                System.Data.Entity.Core.EntityKeyMember[] keys = key.EntityKeyValues;

                foreach (System.Data.Entity.Core.EntityKeyMember keyMember in keys)
                {
                    PropertyInfo entityKeyProperty = entity.GetType().GetProperty(keyMember.Key);
                    PropertyInfo originalKeyProperty = originalItem.GetType().GetProperty(keyMember.Key);
                    if (entityKeyProperty != null && originalKeyProperty != null)
                    {
                        object originalKeyValue = originalKeyProperty.GetValue(originalItem, null);
                        entityKeyProperty.SetValue(entity, originalKeyValue, null);
                    }
                }

                objContext.ApplyCurrentValues<TEntity>(key.EntitySetName, entity);
            }
        }

        public void UpdateByKey<TEntity>(string keyName, string keyOldValue, TEntity entity) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            System.Data.Entity.Core.Objects.ObjectContext objContext = dbContext.ObjectContext;

            var fqen = GetEntityName<TEntity>();
            System.Data.Entity.Core.EntityKey key1 = objContext.CreateEntityKey(fqen, entity);

            System.Data.Entity.Core.EntityKey key = new System.Data.Entity.Core.EntityKey(objContext.DefaultContainerName + "." + fqen, keyName, keyOldValue);


            object originalItem;
            if (objContext.TryGetObjectByKey(key, out originalItem))
            {
                System.Data.Entity.Core.EntityKeyMember[] keys = key.EntityKeyValues;

                foreach (System.Data.Entity.Core.EntityKeyMember keyMember in keys)
                {
                    PropertyInfo entityKeyProperty = entity.GetType().GetProperty(keyMember.Key);
                    PropertyInfo originalKeyProperty = originalItem.GetType().GetProperty(keyMember.Key);
                    if (entityKeyProperty != null && originalKeyProperty != null)
                    {
                        object originalKeyValue = originalKeyProperty.GetValue(originalItem, null);
                        entityKeyProperty.SetValue(entity, originalKeyValue, null);
                    }
                }

                objContext.ApplyCurrentValues<TEntity>(key.EntitySetName, entity);
            }
        }

        /// <summary>
        /// Add or Updates changes of the existing entity. 
        /// The caller must later call SaveChanges() on the repository explicitly to save the entity to database
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void AddOrUpdate<TEntity>(params TEntity[] entities) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            dbContext.Set<TEntity>().AddOrUpdate(entities);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            dbContext.Set<TEntity>().Attach(entity);
            dbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Deletes one or many entities matching the specified criteria
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        public void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            var records = GetQuery<TEntity>().Where(criteria)
                .ToArray();

            for (int i = 0; i < records.Length; i++)
            {
                Delete<TEntity>(records[i]);
            }
        }

        /// <summary>
        /// Gets entity by key.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <returns></returns>
        public TEntity GetByKey<TEntity>(object keyValue) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            System.Data.Entity.Core.Objects.ObjectContext objContext = dbContext.ObjectContext;

            System.Data.Entity.Core.EntityKey key = GetEntityKey<TEntity>(keyValue);

            object originalItem;
            if (objContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }
            return default(TEntity);
        }

        private System.Data.Entity.Core.EntityKey GetEntityKey<TEntity>(object keyValue) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            ObjectContext objContext = dbContext.ObjectContext;

            var entitySetName = GetEntityName<TEntity>();
            var objectSet = objContext.CreateObjectSet<TEntity>();
            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var qualifiedEntitySetName = objContext.DefaultContainerName + "." + entitySetName;
            var entityKey = new System.Data.Entity.Core.EntityKey(qualifiedEntitySetName, keyPropertyName, keyValue);
            return entityKey;
        }

        /// <summary>
        /// Gets entity by key.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <returns></returns>
        public TEntity GetOneByKey<TEntity>(object item, bool IsGetFromDataSource) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            ObjectContext objContext = dbContext.ObjectContext;

            object originalItem = null;

            var entitySet = objContext.CreateObjectSet<TEntity>();
            System.Data.Entity.Core.EntityKey key = objContext.CreateEntityKey(GetEntityName<TEntity>(), item);

            if (IsGetFromDataSource)
            {
                entitySet.MergeOption = MergeOption.OverwriteChanges;
                try
                {
                    string predicate = "";
                    List<ObjectParameter> parameters = new List<ObjectParameter>();
                    foreach (var k in key.EntityKeyValues)
                    {
                        predicate = predicate + (predicate == "" ? "" : "&&") + entitySet.Name + "." + k.Key + "==@" + k.Key;
                        parameters.Add(new ObjectParameter(k.Key, k.Value));
                    }

                    TEntity objectReturn = (TEntity)entitySet.Where(predicate, parameters.ToArray()).Execute(MergeOption.OverwriteChanges).FirstOrDefault();
                    //if(objectReturn!=null)
                    //    this._ObjectContext.ApplyCurrentValues<TEntity>(GetEntityName<TEntity>(), objectReturn);
                    return objectReturn;
                }
                finally { }
            }
            else
                if (objContext.TryGetObjectByKey(key, out originalItem))
            {
                return (TEntity)originalItem;
            }
            return default(TEntity);
        }


        /// <summary>
        /// Finds entities based on provided criteria.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Where(criteria);
        }

        /// <summary>
        /// Finds one entity based on provided criteria.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return Get<TEntity>(criteria).FirstOrDefault();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().AsEnumerable<TEntity>();
        }

        /// <summary>
        /// Counts the specified entities.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        public int Count<TEntity>() where TEntity : class
        {
            return GetQuery<TEntity>().Count();
        }

        /// <summary>
        /// Counts entities with the specified criteria.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        public int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Count(criteria);
        }

        private string GetEntityName<TEntity>()
        {
            return typeof(TEntity).Name;
        }

        private static Dictionary<string, Type> cType = new Dictionary<string, Type>();
        /// <summary>
        /// Get Entity queryable
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();

            return dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Get Entity queryable
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntity> GetQueryNoLock<TEntity>() where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            NoLockInterceptor.ApplyNoLock = true;
            DbInterception.Add(new NoLockInterceptor());
            return dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Get Entity queryable & Include all input tables
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="tables"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery<TEntity>(params string[] tables) where TEntity : class
        {
            var context = GetQuery<TEntity>();
            if (tables != null)
            {
                foreach (string table in tables)
                {
                    context = ((DbQuery<TEntity>)context).Include(table);
                }
            }

            return context;
        }

        /// <summary>
        /// Execute entity SQL query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IQueryable<TEntity> EntitySQL<TEntity>(IQueryable<TEntity> source, string sql) where TEntity : class
        {
            ObjectQuery<TEntity> objQuery = (ObjectQuery<TEntity>)source;

            return objQuery.Where(sql);
        }

        /// <summary>
        /// Execute entity SQL query with parameters
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<TEntity> EntitySQL<TEntity>(IQueryable<TEntity> source, string sql, object[] parameters) where TEntity : class
        {
            ObjectQuery<TEntity> objQuery = (ObjectQuery<TEntity>)source;

            ObjectParameter[] prs = new ObjectParameter[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                prs[i] = new ObjectParameter("p" + i, parameters[i]);
            }

            return objQuery.Where(sql, prs);
        }

        /// <summary>
        /// Execute native SQL query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public ObjectResult<TEntity> ExecuteSQL<TEntity>(string sql) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            return ((IObjectContextAdapter)dbContext).ObjectContext.ExecuteStoreQuery<TEntity>(sql);
        }

        /// <summary>
        /// Execute native SQL query with parameters
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ObjectResult<TEntity> ExecuteSQL<TEntity>(string sql, object[] parameters) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();
            return ((IObjectContextAdapter)dbContext).ObjectContext.ExecuteStoreQuery<TEntity>(sql, parameters);
        }


        /// <summary>
        /// Execute native SQL query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteStoreCommand(string sql, params object[] parameters)
        {
            return _DbContext.ObjectContext.ExecuteStoreCommand(sql, parameters);
        }

        public System.Data.DataSet ExecuteStoreScalar(string sqlName, object[] parameterValues = null)
        {
            System.Data.DataSet dtReturn = new System.Data.DataSet();

            using (var conn = new SqlConnection(this.ConnectString))
            {
                    // Create Command
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = sqlName;
                    cmd.CommandTimeout = 0;
                    // Open Connection
                    conn.Open();

                    // Discover Parameters for Stored Procedure
                    // Populate command.Parameters Collection.
                    // Causes Rountrip to Database.
                    SqlCommandBuilder.DeriveParameters(cmd);
                    // Initialize Index of parameterValues Array
                    int index = 0;
                    // Populate the Input Parameters With Values Provided    
                    if (parameterValues != null)
                    {
                        foreach (SqlParameter parameter in cmd.Parameters)
                        {
                            if (parameter.Direction == System.Data.ParameterDirection.Input ||
                                 parameter.Direction == System.Data.ParameterDirection.
                                                             InputOutput)
                            {
                                if (parameterValues.Count() <= index || parameterValues[index] == null)
                                {
                                    parameter.Value = DBNull.Value;
                                }
                                else
                                    parameter.Value = parameterValues[index];
                                index++;
                            }
                        }
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dtReturn);
            }
            return dtReturn;
        }
        public System.Data.DataSet ExecuteStoreScalar(string sqlName, object[] parameterNames = null, object[] parameterValues = null)
        {
            System.Data.DataSet dtReturn = new System.Data.DataSet();

                using (var conn = new SqlConnection(this.ConnectString))
                {
                    // Create Command
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = sqlName;
                    cmd.CommandTimeout = 0;
                    // Open Connection
                    conn.Open();

                    // Discover Parameters for Stored Procedure
                    // Populate command.Parameters Collection.
                    // Causes Rountrip to Database.
                    SqlCommandBuilder.DeriveParameters(cmd);
                    // Initialize Index of parameterValues Array
                    int index = 0;
                    // Populate the Input Parameters With Values Provided    
                    if (parameterValues != null)
                    {
                        foreach (SqlParameter parameter in cmd.Parameters)
                        {
                            if (parameter.Direction == System.Data.ParameterDirection.Input ||
                                 parameter.Direction == System.Data.ParameterDirection.
                                                             InputOutput)
                            {
                                string paramName = parameter.ParameterName.Substring(1);
                                int indexparam = parameterNames.ToList().IndexOf(paramName);
                                if (indexparam >= 0)
                                {
                                    parameter.Value = parameterValues[indexparam];
                                }
                                //int indexName = parameterNames
                                //if (parameterValues.Count() <= index || parameterValues[index] == null)
                                //{
                                //    parameter.Value = DBNull.Value;
                                //}
                                //else
                                //    parameter.Value = parameterValues[index];
                                index++;
                            }
                        }
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dtReturn);
                }
            return dtReturn;
        }

        public int ExecuteStoreOutParas(string sqlName, object[] parameterValues)
        {
            int iReturn = 0;
            using (var conn = new SqlConnection(ConnectString))
            {
                // Open Connection
                conn.Open();

                SqlTransaction transaction;
                // Start a local transaction.
                transaction = conn.BeginTransaction();

                // Create Command
                var cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sqlName;
                cmd.CommandTimeout = 0;
                cmd.Transaction = transaction;

                Hashtable hsOut = new Hashtable();
                // Discover Parameters for Stored Procedure
                // Populate command.Parameters Collection.
                // Causes Rountrip to Database.
                SqlCommandBuilder.DeriveParameters(cmd);
                // Initialize Index of parameterValues Array
                int index = 0;
                int i = 0;
                // Populate the Input Parameters With Values Provided        
                try
                {
                    foreach (SqlParameter parameter in cmd.Parameters)
                    {
                        if (parameter.Direction == System.Data.ParameterDirection.Input ||
                             parameter.Direction == System.Data.ParameterDirection.
                                                         InputOutput)
                        {
                            if (parameterValues.Count() <= index || parameterValues[index] == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                            else
                                parameter.Value = parameterValues[index];

                            if (parameter.Direction == System.Data.ParameterDirection.InputOutput)
                                hsOut.Add(index, i);

                            index++;
                        }
                        i++;
                    }

                    iReturn = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    //ExceptionUtility.LogException(ex, "error");
                    throw ex;
                }
                finally
                {
                    // Attempt to commit the transaction.
                    //iReturn = (int)cmd.Parameters["@RETURNVALUE"].Value;
                    //if (iReturn == 0)
                    //{
                    transaction.Commit();
                    foreach (DictionaryEntry item in hsOut)
                    {
                        index = (int)item.Key;
                        i = (int)item.Value;
                        parameterValues[index] = cmd.Parameters[i].Value;
                    }
                    //}
                    //else
                    //{
                    //    transaction.Rollback();
                    //    hsOut.Clear();
                    //}

                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            return iReturn;
        }

        /// <summary>
        /// Check if record is exit in database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public bool IsExits<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            return GetQuery<TEntity>().Any(criteria);
        }

        /// <summary>
        /// Accept all change to object state
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        public void AcceptAllChanges()
        {
            _objectContext.AcceptAllChanges();
        }

        public string GetDatabaseName()
        {
            //return _ObjectContext.Connection.Database;
            return this._DbContext.Database.Connection.Database;
        }

        /// <summary>
        /// Get Key
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public string[] GetKeys<TEntity>(TEntity entity) where TEntity : class
        {
            EFDbContext dbContext = GetEFDbContext<TEntity>();

            System.Data.Entity.Core.EntityKey key = ((IObjectContextAdapter)dbContext).ObjectContext.CreateEntityKey(GetEntityName<TEntity>(), entity);

            if (key != null)
            {
                return key.EntityKeyValues.Select(o => o.Key).ToArray();
            }

            return new string[] { };
        }

        /// <summary>
        /// Get db context
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public EFDbContext GetEFDbContext<TEntity>()
        {
            return _DbContext;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (_UnitOfWork == null)
                {
                    _UnitOfWork = new EFUnitOfWork(_DbContext);
                }
                return _UnitOfWork;
            }
        }

        public int GetPageOfSourceByKey<TEntity>(IQueryable<TEntity> source, string Key, string Value, int PageSize, string Sort)
        {
            if (source == null) return 0;

            DbQuery<TEntity> dbQuery = ((DbQuery<TEntity>)source.Where(o => 1 == 1));
            var internalQueryField = typeof(DbQuery<TEntity>).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_internalQuery"));
            var internalQuery = internalQueryField.GetValue(dbQuery);
            var objectQueryField = internalQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_objectQuery"));
            if (objectQueryField == null)
            {
                objectQueryField = internalQuery.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_objectQuery"));
            }
            // Here's your ObjectQuery!
            var objQuery = objectQueryField.GetValue(internalQuery) as ObjectQuery<TEntity>;

            string command = "";
            if (objQuery == null)
            {
                command = internalQuery.ToString();
            }
            else
            {
                command = objQuery.ToTraceString();
            }
            string SQL = "SELECT @PageCurrent = ((RowIndex-1)/" + PageSize.ToString() + ")+1 "
                      + "FROM (SELECT Row_Number() over (order by " + Sort + ") as RowIndex," + Key + " FROM (" + command + ") sql1) sql "
                      + "WHERE " + Key + " = '" + Value + "'";

            try
            {
                using (var conn = new SqlConnection(ConnectString))
                {
                    // Create Command
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = SQL;

                    conn.Open();

                    cmd.Parameters.Add(new SqlParameter() { Direction = System.Data.ParameterDirection.InputOutput, ParameterName = "PageCurrent", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });
                    cmd.ExecuteNonQuery();
                    return (int)cmd.Parameters[0].Value;
                }
            }
            catch (Exception exp)
            {

            }

            return 0;
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_DbContext != null)
                {
                    _DbContext.Dispose();
                    _DbContext = null;
                }
            }
        }

        public void Close()
        {
            if (_DbContext.Database.Connection.State == System.Data.ConnectionState.Open)
                _DbContext.Database.Connection.Close();
        }

        public DataSet ExecSQL(string sql)
        {
            System.Data.DataSet dtReturn = new System.Data.DataSet();

            using (var conn = new SqlConnection(this.ConnectString))
            {
                // Create Command
                var cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = sql;
                cmd.CommandTimeout = 0;
                // Open Connection
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dtReturn);
            }
            return dtReturn;
        }

        public string GetSQLString<TEntity>(IQueryable<TEntity> source)
        {
            if (source == null) return "";

            DbQuery<TEntity> dbQuery = ((DbQuery<TEntity>)source);
            var internalQueryField = typeof(DbQuery<TEntity>).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_internalQuery"));
            var internalQuery = internalQueryField.GetValue(dbQuery);
            var objectQueryField = internalQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_objectQuery"));
            if (objectQueryField == null)
            {
                objectQueryField = internalQuery.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(f => f.Name.Equals("_objectQuery"));
            }
            // Here's your ObjectQuery!
            var objQuery = objectQueryField.GetValue(internalQuery) as ObjectQuery<TEntity>;

            string command = "";
            if (objQuery == null)
            {
                command = internalQuery.ToString();
            }
            else
            {
                command = objQuery.ToTraceString();
            }

            return command;
        }

        public bool IsRelationShip
        {
            get;
            set;
        }


    }
}
