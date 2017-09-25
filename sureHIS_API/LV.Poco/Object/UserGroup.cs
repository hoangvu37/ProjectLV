/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : UserGroup.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class UserGroup : BaseEntity, ICloneable	{
		public UserGroup()
		{
			this.UserGroupID = 0;
            this.IsBuiltIn = true;
            this.IsActive = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("UserGroupID", UserGroupID); } }


		private long _UserGroupID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long UserGroupID { get { return _UserGroupID; } set {_UserGroupID = value; } }

		private string _UserGroupName;
		[LVRequired]
        [LVMaxLength(64)]
        public string UserGroupName { get { return _UserGroupName; } set {_UserGroupName = value; } }

		private bool _IsBuiltIn;
        public bool IsBuiltIn { get { return _IsBuiltIn; } set {_IsBuiltIn = value; } }

		private string _MajorFuncDesc;
        [LVMaxLength(2048)]
        public string MajorFuncDesc { get { return _MajorFuncDesc; } set {_MajorFuncDesc = value; } }

		private bool _IsActive;
        public bool IsActive { get { return _IsActive; } set {_IsActive = value; } }

		/// <summary>
/// Ref Key: FK_PrivilegeRole_UserGroup
/// <summary>
/// <summary>
/// Ref Key: FK_UsersInGroup_UserGroup
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
    public class KeyedUserGroup : KeyedCollection<KeyValuePair<string, long>, UserGroup>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedUserGroup() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(UserGroup item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_UserGroupID) { return new KeyValuePair<string, long>("UserGroupID", k_UserGroupID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(UserGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, UserGroup item)
        {
            UserGroup orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(UserGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(UserGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public UserGroup GetObjectByKey(long k_UserGroupID) 
		{
            if (this.Contains(GetKey(k_UserGroupID)) == false) return null;
            UserGroup ob = this[GetKey(k_UserGroupID)];
            return (UserGroup)ob;
        }

		public UserGroup GetObjectByKey(long k_UserGroupID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_UserGroupID)) == false) {
				UserGroup ob = repository.GetQuery<UserGroup>().FirstOrDefault(o => o.UserGroupID == k_UserGroupID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            UserGroup obj = this[GetKey(k_UserGroupID)];
            return (UserGroup)obj;
        }

		public UserGroup GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            UserGroup ob = this[keypair];
            return (UserGroup)ob;
        }

        public UserGroup GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            UserGroup ob = this[GetKey(keypair)];
            return (UserGroup)ob;
        }

		bool _LoadAll = false;
        public List<UserGroup> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<UserGroup>().ToList();
			foreach (UserGroup item in list) {
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

        ~KeyedUserGroup()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
