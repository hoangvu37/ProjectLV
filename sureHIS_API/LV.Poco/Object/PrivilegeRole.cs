/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PrivilegeRole.cs         
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
	public partial class PrivilegeRole : BaseEntity, ICloneable	{
		public PrivilegeRole()
		{
			this.PrivilegedRoleID = 0;
			this.AppFuncID = 0;
            this.IsBuiltIn = true;
            this.IsActive = false;
			this.UserGroupID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PrivilegedRoleID", PrivilegedRoleID); } }


		private long _PrivilegedRoleID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PrivilegedRoleID { get { return _PrivilegedRoleID; } set {_PrivilegedRoleID = value; } }

		private long _AppFuncID;
		[LVRequired]
        public long AppFuncID { get { return _AppFuncID; } set {_AppFuncID = value; } }

		private bool? _IsBuiltIn;
        public bool? IsBuiltIn { get { return _IsBuiltIn; } set {_IsBuiltIn = value; } }

		private bool? _IsActive;
        public bool? IsActive { get { return _IsActive; } set {_IsActive = value; } }

		private long? _UserGroupID;
        public long? UserGroupID { get { return _UserGroupID; } set {_UserGroupID = value; } }

		private byte _PermVals;
		[LVRequired]
        public byte PermVals { get { return _PermVals; } set {_PermVals = value; } }

		/// <summary>
/// Ref Key: FK_PrivilegeRole_Application
/// <summary>
/// <summary>
/// Ref Key: FK_PrivilegeRole_UserGroup
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
    public class KeyedPrivilegeRole : KeyedCollection<KeyValuePair<string, long>, PrivilegeRole>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPrivilegeRole() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PrivilegeRole item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PrivilegedRoleID) { return new KeyValuePair<string, long>("PrivilegedRoleID", k_PrivilegedRoleID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PrivilegeRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PrivilegeRole item)
        {
            PrivilegeRole orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PrivilegeRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PrivilegeRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PrivilegeRole GetObjectByKey(long k_PrivilegedRoleID) 
		{
            if (this.Contains(GetKey(k_PrivilegedRoleID)) == false) return null;
            PrivilegeRole ob = this[GetKey(k_PrivilegedRoleID)];
            return (PrivilegeRole)ob;
        }

		public PrivilegeRole GetObjectByKey(long k_PrivilegedRoleID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PrivilegedRoleID)) == false) {
				PrivilegeRole ob = repository.GetQuery<PrivilegeRole>().FirstOrDefault(o => o.PrivilegedRoleID == k_PrivilegedRoleID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PrivilegeRole obj = this[GetKey(k_PrivilegedRoleID)];
            return (PrivilegeRole)obj;
        }

		public PrivilegeRole GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PrivilegeRole ob = this[keypair];
            return (PrivilegeRole)ob;
        }

        public PrivilegeRole GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PrivilegeRole ob = this[GetKey(keypair)];
            return (PrivilegeRole)ob;
        }

		bool _LoadAll = false;
        public List<PrivilegeRole> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PrivilegeRole>().ToList();
			foreach (PrivilegeRole item in list) {
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

        ~KeyedPrivilegeRole()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
