using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Core.DAL.EntityFramework
{
    public delegate void DBSaveChangedEvent(object sender, List<DBChangeTrackerInfo> listDBChanged);
    public class DBTracker
    {
        public DBTracker(EFDbContext dbContext)
        {
            listDBChanged = new List<DBChangeTrackerInfo>();
            foreach (DbEntityEntry db in dbContext.ChangeTracker.Entries())
            {
                listDBChanged.Add(new DBChangeTrackerInfo(db, dbContext.ObjectContext));
            }
        }
        
        List<DBChangeTrackerInfo> listDBChanged = null;
        public void SaveChanged(object sender)
        {
            if (listDBChanged == null) return;
            if (OnDBSavechanged != null)
                OnDBSavechanged(sender, listDBChanged);
        }

        public static event DBSaveChangedEvent OnDBSavechanged;
    }

    [Serializable]
    public class DBChangeTrackerInfo
    {
        public DBChangeTrackerInfo() { }

        public DBChangeTrackerInfo(DbEntityEntry dbEntity, System.Data.Entity.Core.Objects.ObjectContext objContext)
        {
            entity = dbEntity.Entity;
            currentValues = dbEntity.State == System.Data.Entity.EntityState.Deleted? null : (DbPropertyValues)dbEntity.CurrentValues.Clone();
            originalValues = dbEntity.State == System.Data.Entity.EntityState.Added? null : (DbPropertyValues)dbEntity.OriginalValues.Clone();
            state = dbEntity.State;
            if (entity == null) return;
            #region GetEntityKeyValue
            string tblN = entity.GetType().Name;
            System.Data.Entity.Core.EntityKey key = objContext.CreateEntityKey(tblN, entity);
            DbKeyMember[] km = new DbKeyMember[key.EntityKeyValues.Length];
            for (int i = 0; i < key.EntityKeyValues.Length; i++)
                km[i] = new DbKeyMember(key.EntityKeyValues[i].Key, key.EntityKeyValues[i].Value);
            entityKey = new DbEntityKey(tblN, km);
            //Tracking changed data
            if (state == System.Data.Entity.EntityState.Modified && originalValues != null) 
            {
                listRecordChanged = new List<DbRecordChangedInfo>();
                foreach (var fieldProperty in originalValues.PropertyNames) {
                    if (dbEntity.Property(fieldProperty).IsModified)
                    {
                        listRecordChanged.Add(new DbRecordChangedInfo(fieldProperty, originalValues[fieldProperty], currentValues[fieldProperty]));   
                    }
                }  
            }
            #endregion
        }

        string userName = "";
        public string UserName { get { return userName; } set { userName = value; } }

        DbEntityKey entityKey;
        public DbEntityKey EntityKey { get { return entityKey; } set { entityKey = value; } }

        object entity = null;
        public object Entity { get { return entity; } set { entity = value; } }

        DbPropertyValues currentValues;
        public DbPropertyValues CurrentValues { get { return currentValues; } set { currentValues = value; } }

        DbPropertyValues originalValues;
        public DbPropertyValues OriginalValues { get { return originalValues; } set { originalValues = value; } }

        System.Data.Entity.EntityState state;
        public System.Data.Entity.EntityState State { get { return state; } set { state = value; } }

        List<DbRecordChangedInfo> listRecordChanged;
        public List<DbRecordChangedInfo> ListRecordChanged { get { return listRecordChanged; } set { listRecordChanged = value; } }

    }

    [Serializable]
    public class DbRecordChangedInfo : ICloneable
    {
        public DbRecordChangedInfo() { }

        public DbRecordChangedInfo(string P_fieldName, object p_OriginalValue, object p_ChangedValue) {
            fieldName = P_fieldName;
            originalValue = p_OriginalValue;
            changedValue = p_ChangedValue;
        }

        string fieldName = "";
        public string FieldName { get { return fieldName; } set { fieldName = value; } }

        object changedValue;
        public object ChangedValue { get { return changedValue; } set { changedValue = value; } }

        object originalValue;
        public object OriginalValue { get { return originalValue; } set { originalValue = value; } }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return FieldName + ": " + (originalValue == null? "" : originalValue.ToString()) + " - " + (changedValue == null? "" : changedValue.ToString());
        }
    }

    [Serializable]
    public class DbEntityKey : ICloneable
    {
        public DbEntityKey() { }

        public DbEntityKey(string p_tblName, DbKeyMember[] p_keyVal) {
            tblName = p_tblName;
            keyValues = p_keyVal;
        }

        string tblName = "";
        public string TblName { get { return tblName; } set { tblName = value; } }

        DbKeyMember[] keyValues;
        public DbKeyMember[] KeyValues { get { return keyValues; } set { keyValues = value; } }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    [Serializable]
    public class DbKeyMember : ICloneable
    {
        public DbKeyMember() { }
        string m_keyName = "";
        object m_Value;

        public DbKeyMember(string keyName, object keyValue) {
            m_keyName = keyName;
            m_Value = keyValue;
        }

        public string Key { get { return m_keyName; } set { m_keyName = value; } }
        public object Value { get { return m_Value; } set { m_Value = value; } }

        public override string ToString() { 
            return m_keyName + " - " + (m_Value == null? "" : m_Value.ToString());
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
