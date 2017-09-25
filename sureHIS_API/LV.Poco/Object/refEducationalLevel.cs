/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refEducationalLevel.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
 * Version              : 1.0                                  
 * ============================================================
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using LV.Poco.Validate;

namespace LV.Poco
{
	[Serializable]
	public partial class refEducationalLevel : BaseEntity, ICloneable	{
		public refEducationalLevel()
		{
			this.PersEduLevelID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PersEduLevelID", PersEduLevelID); } }


		private long _PersEduLevelID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PersEduLevelID { get { return _PersEduLevelID; } set {_PersEduLevelID = value; } }

		private string _PersEducationalLevelCode;
		[LVRequired]
        [LVMaxLength(5)]
        public string PersEducationalLevelCode { get { return _PersEducationalLevelCode; } set {_PersEducationalLevelCode = value; } }

		private string _PersEducationalLevelName;
		[LVRequired]
        [LVMaxLength(64)]
        public string PersEducationalLevelName { get { return _PersEducationalLevelName; } set {_PersEducationalLevelName = value; } }

		private string _VNPersEducationalLevelName;
        [LVMaxLength(128)]
        public string VNPersEducationalLevelName { get { return _VNPersEducationalLevelName; } set {_VNPersEducationalLevelName = value; } }

		/// <summary>
/// Ref Key: FK_Person_refEducationalLevel
/// <summary>


        #endregion

		#region ICloneable Members
        public object Clone()
        {
            return this.MemberwiseClone(); 
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

	}

	[Serializable]
    public class KeyedrefEducationalLevel : KeyedCollection<KeyValuePair<string, long>, refEducationalLevel>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefEducationalLevel() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refEducationalLevel item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PersEduLevelID) { return new KeyValuePair<string, long>("PersEduLevelID", k_PersEduLevelID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refEducationalLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refEducationalLevel item)
        {
            refEducationalLevel orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refEducationalLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refEducationalLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refEducationalLevel GetObjectByKey(long k_PersEduLevelID) 
		{
            if (this.Contains(GetKey(k_PersEduLevelID)) == false) return null;
            refEducationalLevel ob = this[GetKey(k_PersEduLevelID)];
            return (refEducationalLevel)ob;
        }

		public refEducationalLevel GetObjectByKey(long k_PersEduLevelID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PersEduLevelID)) == false) {
				refEducationalLevel ob = repository.GetQuery<refEducationalLevel>().FirstOrDefault(o => o.PersEduLevelID == k_PersEduLevelID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refEducationalLevel obj = this[GetKey(k_PersEduLevelID)];
            return (refEducationalLevel)obj;
        }

		public refEducationalLevel GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refEducationalLevel ob = this[keypair];
            return (refEducationalLevel)ob;
        }

        public refEducationalLevel GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refEducationalLevel ob = this[GetKey(keypair)];
            return (refEducationalLevel)ob;
        }

		bool _LoadAll = false;
        public List<refEducationalLevel> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refEducationalLevel>().ToList();
			foreach (refEducationalLevel item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
				
        #endregion

        #region Implement interface
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        // Protected implementation of Dispose pattern.
        bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing) {}

            // Free any unmanaged objects here.
            disposed = true;
        }

        ~KeyedrefEducationalLevel()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
