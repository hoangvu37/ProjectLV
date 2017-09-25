/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ASPNetRole.cs         
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
	public partial class ASPNetRole : BaseEntity, ICloneable	{
		public ASPNetRole()
		{
			this.RoleID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RoleID", RoleID); } }


		private long _RoleID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RoleID { get { return _RoleID; } set {_RoleID = value; } }

		private string _Name;
		[LVRequired]
        [LVMaxLength(64)]
        public string Name { get { return _Name; } set {_Name = value; } }

		/// <summary>
/// Ref Key: FK_TRolePermission_TRole
/// <summary>
/// <summary>
/// Ref Key: FK_TUserRole_TRole
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
    public class KeyedASPNetRole : KeyedCollection<KeyValuePair<string, long>, ASPNetRole>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedASPNetRole() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ASPNetRole item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RoleID) { return new KeyValuePair<string, long>("RoleID", k_RoleID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ASPNetRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ASPNetRole item)
        {
            ASPNetRole orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ASPNetRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ASPNetRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ASPNetRole GetObjectByKey(long k_RoleID) 
		{
            if (this.Contains(GetKey(k_RoleID)) == false) return null;
            ASPNetRole ob = this[GetKey(k_RoleID)];
            return (ASPNetRole)ob;
        }

		public ASPNetRole GetObjectByKey(long k_RoleID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RoleID)) == false) {
				ASPNetRole ob = repository.GetQuery<ASPNetRole>().FirstOrDefault(o => o.RoleID == k_RoleID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ASPNetRole obj = this[GetKey(k_RoleID)];
            return (ASPNetRole)obj;
        }

		public ASPNetRole GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ASPNetRole ob = this[keypair];
            return (ASPNetRole)ob;
        }

        public ASPNetRole GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ASPNetRole ob = this[GetKey(keypair)];
            return (ASPNetRole)ob;
        }

		bool _LoadAll = false;
        public List<ASPNetRole> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ASPNetRole>().ToList();
			foreach (ASPNetRole item in list) {
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

        ~KeyedASPNetRole()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
