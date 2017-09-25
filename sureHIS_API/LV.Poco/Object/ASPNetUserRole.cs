/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ASPNetUserRole.cs         
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
	public partial class ASPNetUserRole : BaseEntity, ICloneable	{
		public ASPNetUserRole()
		{
			this.ASPNetUserID = 0;
			this.RoleID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> Key { get { return new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(new KeyValuePair<string, long>("ASPNetUserID", ASPNetUserID), new KeyValuePair<string, long>("RoleID", RoleID)); } }


		private long _ASPNetUserID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ASPNetUserID { get { return _ASPNetUserID; } set {_ASPNetUserID = value; } }

		private long _RoleID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RoleID { get { return _RoleID; } set {_RoleID = value; } }

		private string _IdentityUser_ID;
		[LVRequired]
        [LVMaxLength(128)]
        public string IdentityUser_ID { get { return _IdentityUser_ID; } set {_IdentityUser_ID = value; } }

		/// <summary>
/// Ref Key: FK_TUserRole_TRole
/// <summary>
/// <summary>
/// Ref Key: FK_ASPNetUserRole_ASPNetUser
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
    public class KeyedASPNetUserRole : KeyedCollection<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, ASPNetUserRole>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedASPNetUserRole() : base() { }

        protected override KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> GetKeyForItem(ASPNetUserRole item)
        {
            return item.Key;
        }

        public KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> GetKey(long k_ASPNetUserID, long k_RoleID) { return new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(new KeyValuePair<string, long>("ASPNetUserID", k_ASPNetUserID), new KeyValuePair<string, long>("RoleID", k_RoleID)); }

        public KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> GetKey(object keypair) { try { return (KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>)keypair; } catch { return new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(); } }
        #endregion

        #region Method
        public bool AddObject(ASPNetUserRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> keypair, ASPNetUserRole item)
        {
            ASPNetUserRole orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ASPNetUserRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ASPNetUserRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ASPNetUserRole GetObjectByKey(long k_ASPNetUserID, long k_RoleID) 
		{
            if (this.Contains(GetKey(k_ASPNetUserID, k_RoleID)) == false) return null;
            ASPNetUserRole ob = this[GetKey(k_ASPNetUserID, k_RoleID)];
            return (ASPNetUserRole)ob;
        }

		public ASPNetUserRole GetObjectByKey(long k_ASPNetUserID, long k_RoleID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ASPNetUserID, k_RoleID)) == false) {
				ASPNetUserRole ob = repository.GetQuery<ASPNetUserRole>().FirstOrDefault(o => o.ASPNetUserID == k_ASPNetUserID && o.RoleID == k_RoleID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ASPNetUserRole obj = this[GetKey(k_ASPNetUserID, k_RoleID)];
            return (ASPNetUserRole)obj;
        }

		public ASPNetUserRole GetObjectByKey(KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ASPNetUserRole ob = this[keypair];
            return (ASPNetUserRole)ob;
        }

        public ASPNetUserRole GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ASPNetUserRole ob = this[GetKey(keypair)];
            return (ASPNetUserRole)ob;
        }

		bool _LoadAll = false;
        public List<ASPNetUserRole> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ASPNetUserRole>().ToList();
			foreach (ASPNetUserRole item in list) {
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

        ~KeyedASPNetUserRole()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
