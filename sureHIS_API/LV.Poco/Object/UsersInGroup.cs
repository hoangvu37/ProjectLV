/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : UsersInGroup.cs         
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
	public partial class UsersInGroup : BaseEntity, ICloneable	{
		public UsersInGroup()
		{
			this.AccountID = 0;
			this.UserGroupID = 0;
            this.FromDate = DateTime.Now;
            this.ToDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> Key { get { return new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(new KeyValuePair<string, long>("AccountID", AccountID), new KeyValuePair<string, long>("UserGroupID", UserGroupID)); } }


		private long _AccountID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AccountID { get { return _AccountID; } set {_AccountID = value; } }

		private long _UserGroupID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long UserGroupID { get { return _UserGroupID; } set {_UserGroupID = value; } }

		private DateTime? _FromDate;
        public DateTime? FromDate { get { return _FromDate; } set {_FromDate = value; } }

		private DateTime? _ToDate;
        public DateTime? ToDate { get { return _ToDate; } set {_ToDate = value; } }

		/// <summary>
/// Ref Key: FK_UsersInGroup_UserAccount
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
    public class KeyedUsersInGroup : KeyedCollection<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, UsersInGroup>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedUsersInGroup() : base() { }

        protected override KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> GetKeyForItem(UsersInGroup item)
        {
            return item.Key;
        }

        public KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> GetKey(long k_AccountID, long k_UserGroupID) { return new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(new KeyValuePair<string, long>("AccountID", k_AccountID), new KeyValuePair<string, long>("UserGroupID", k_UserGroupID)); }

        public KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> GetKey(object keypair) { try { return (KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>)keypair; } catch { return new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(); } }
        #endregion

        #region Method
        public bool AddObject(UsersInGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> keypair, UsersInGroup item)
        {
            UsersInGroup orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(UsersInGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(UsersInGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public UsersInGroup GetObjectByKey(long k_AccountID, long k_UserGroupID) 
		{
            if (this.Contains(GetKey(k_AccountID, k_UserGroupID)) == false) return null;
            UsersInGroup ob = this[GetKey(k_AccountID, k_UserGroupID)];
            return (UsersInGroup)ob;
        }

		public UsersInGroup GetObjectByKey(long k_AccountID, long k_UserGroupID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AccountID, k_UserGroupID)) == false) {
				UsersInGroup ob = repository.GetQuery<UsersInGroup>().FirstOrDefault(o => o.AccountID == k_AccountID && o.UserGroupID == k_UserGroupID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            UsersInGroup obj = this[GetKey(k_AccountID, k_UserGroupID)];
            return (UsersInGroup)obj;
        }

		public UsersInGroup GetObjectByKey(KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            UsersInGroup ob = this[keypair];
            return (UsersInGroup)ob;
        }

        public UsersInGroup GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            UsersInGroup ob = this[GetKey(keypair)];
            return (UsersInGroup)ob;
        }

		bool _LoadAll = false;
        public List<UsersInGroup> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<UsersInGroup>().ToList();
			foreach (UsersInGroup item in list) {
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

        ~KeyedUsersInGroup()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
