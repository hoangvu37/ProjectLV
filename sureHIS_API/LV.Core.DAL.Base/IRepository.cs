using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Data.Entity.Core.Objects;
using System.Data.Objects;


namespace LV.Core.DAL.Base
{
    public interface IRepository
    {
        /// <summary>
        /// Accept all change to object state
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void AcceptAllChanges();

        /// <summary>
        /// Attach the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Attach<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Add<TEntity>(TEntity entity) where TEntity : class;
        void AddReturn<TEntity>(TEntity entity, out TEntity inserted) where TEntity : class;

        /// <summary>
        /// Updates changes of the existing entity. 
        /// The caller must later call SaveChanges() on the repository explicitly to save the entity to database
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateByKey<TEntity>(string keyName, string keyOldValue, TEntity entity) where TEntity : class;
        /// <summary>
        /// Adds or Update the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void AddOrUpdate<TEntity>(params TEntity[] entities) where TEntity : class;

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void Delete<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Deletes one or many entities matching the specified criteria
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        void Delete<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        /// <summary>
        /// Gets entity by key.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <returns></returns>
        TEntity GetByKey<TEntity>(object keyValue) where TEntity : class;

        /// <summary>
        /// Finds entities based on provided criteria.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        /// <summary>
        /// Finds one entity based on provided criteria.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        /// <summary>
        /// Gets entity by key.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValue">The key value.</param>
        /// <param name="IsGetFromDataSource">If true get data form data source, else get from DataContext.</param>
        /// <returns></returns>
        TEntity GetOneByKey<TEntity>(object item, bool IsGetFromDataSource) where TEntity : class;

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;

        /// <summary>
        /// Counts the specified entities.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        int Count<TEntity>() where TEntity : class;

        /// <summary>
        /// Counts entities with the specified criteria.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        int Count<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>The unit of work.</value>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Get Entity queryable
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class;

        /// <summary>
        /// Get Entity queryable
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryNoLock<TEntity>() where TEntity : class;

        /// <summary>
        /// Get Entity queryable & Include all input tables
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="tables"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery<TEntity>(params string[] tables) where TEntity : class;

        /// <summary>
        /// Execute native SQL query
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        System.Data.Entity.Core.Objects.ObjectResult<TEntity> ExecuteSQL<TEntity>(string sql) where TEntity : class;

        /// <summary>
        /// Execute native SQL query with parameters
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        System.Data.Entity.Core.Objects.ObjectResult<TEntity> ExecuteSQL<TEntity>(string sql, object[] parameters) where TEntity : class;


        /// <summary>
        /// thưc thi store
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteStoreCommand(string sql, params object[] parameters);

        System.Data.DataSet ExecuteStoreScalar(string sqlName, object[] parameterValues = null);
        System.Data.DataSet ExecuteStoreScalar(string sqlName, object[] parameterNames = null, object[] parameterValues = null);

        System.Data.DataSet ExecSQL(string sql);

        int ExecuteStoreOutParas(string sqlName, object[] parameterValues);

        /// <summary>
        /// Execute entity SQL query with parameters
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> EntitySQL<TEntity>(IQueryable<TEntity> source, string sql) where TEntity : class;

        /// <summary>
        /// Execute entity SQL query with parameters
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> EntitySQL<TEntity>(IQueryable<TEntity> source, string sql, object[] parameters) where TEntity : class;

        /// <summary>
        /// Check if record is exit in database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criteria"></param>
        /// <returns></returns>
        bool IsExits<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        string[] GetKeys<TEntity>(TEntity entity) where TEntity : class;

        int GetPageOfSourceByKey<TEntity>(IQueryable<TEntity> source, string Key, string Value, int PageSize, string Sort);
        string GetSQLString<TEntity>(IQueryable<TEntity> source);
        /// <summary>
        /// Get current database name
        /// </summary>
        /// <returns></returns>
        string GetDatabaseName();

        /// <summary>
        /// 
        /// </summary>

        void Close();
    }
}
