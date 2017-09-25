/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PersonRole.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class PersonRole : BaseEntity, ICloneable	{
		public PersonRole()
		{
			this.PersonRoleID = 0;
			this.RoleID = 0;
			this.PersonID = 0;
            this.IsPrimaryRole = true;
            this.IsBlocked = true;
            this.ModifiedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PersonRoleID", PersonRoleID); } }


		private long _PersonRoleID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PersonRoleID { get { return _PersonRoleID; } set {_PersonRoleID = value; } }

		private long _RoleID;
		[LVRequired]
        public long RoleID { get { return _RoleID; } set {_RoleID = value; } }

		private long _PersonID;
		[LVRequired]
        public long PersonID { get { return _PersonID; } set {_PersonID = value; } }

		private bool _IsPrimaryRole;
        public bool IsPrimaryRole { get { return _IsPrimaryRole; } set {_IsPrimaryRole = value; } }

		private bool? _IsBlocked;
        public bool? IsBlocked { get { return _IsBlocked; } set {_IsBlocked = value; } }

		private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		/// <summary>
/// Ref Key: FK_PersonRole_Person
/// <summary>
/// <summary>
/// Ref Key: FK_PersonRole_refRole
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
    public class KeyedPersonRole : KeyedCollection<KeyValuePair<string, long>, PersonRole>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPersonRole() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PersonRole item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PersonRoleID) { return new KeyValuePair<string, long>("PersonRoleID", k_PersonRoleID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PersonRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PersonRole item)
        {
            PersonRole orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PersonRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PersonRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PersonRole GetObjectByKey(long k_PersonRoleID) 
		{
            if (this.Contains(GetKey(k_PersonRoleID)) == false) return null;
            PersonRole ob = this[GetKey(k_PersonRoleID)];
            return (PersonRole)ob;
        }

		public PersonRole GetObjectByKey(long k_PersonRoleID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PersonRoleID)) == false) {
				PersonRole ob = repository.GetQuery<PersonRole>().FirstOrDefault(o => o.PersonRoleID == k_PersonRoleID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PersonRole obj = this[GetKey(k_PersonRoleID)];
            return (PersonRole)obj;
        }

		public PersonRole GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PersonRole ob = this[keypair];
            return (PersonRole)ob;
        }

        public PersonRole GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PersonRole ob = this[GetKey(keypair)];
            return (PersonRole)ob;
        }

		bool _LoadAll = false;
        public List<PersonRole> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PersonRole>().ToList();
			foreach (PersonRole item in list) {
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

        ~KeyedPersonRole()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
