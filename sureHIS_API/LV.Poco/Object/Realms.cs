/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Realms.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class Realms : BaseEntity, ICloneable	{
		public Realms()
		{
			this.RealmID = 0;
			this.RoleID = 0;
			this.AppFuncID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RealmID", RealmID); } }


		private long _RealmID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RealmID { get { return _RealmID; } set {_RealmID = value; } }

		private long _RoleID;
		[LVRequired]
        public long RoleID { get { return _RoleID; } set {_RoleID = value; } }

		private long _AppFuncID;
		[LVRequired]
        public long AppFuncID { get { return _AppFuncID; } set {_AppFuncID = value; } }

		/// <summary>
/// Ref Key: FK_Realms_Application
/// <summary>
/// <summary>
/// Ref Key: FK_Realms_refRole
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
    public class KeyedRealms : KeyedCollection<KeyValuePair<string, long>, Realms>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedRealms() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Realms item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RealmID) { return new KeyValuePair<string, long>("RealmID", k_RealmID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Realms item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Realms item)
        {
            Realms orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Realms item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Realms item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Realms GetObjectByKey(long k_RealmID) 
		{
            if (this.Contains(GetKey(k_RealmID)) == false) return null;
            Realms ob = this[GetKey(k_RealmID)];
            return (Realms)ob;
        }

		public Realms GetObjectByKey(long k_RealmID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RealmID)) == false) {
				Realms ob = repository.GetQuery<Realms>().FirstOrDefault(o => o.RealmID == k_RealmID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Realms obj = this[GetKey(k_RealmID)];
            return (Realms)obj;
        }

		public Realms GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Realms ob = this[keypair];
            return (Realms)ob;
        }

        public Realms GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Realms ob = this[GetKey(keypair)];
            return (Realms)ob;
        }

		bool _LoadAll = false;
        public List<Realms> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Realms>().ToList();
			foreach (Realms item in list) {
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

        ~KeyedRealms()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
