/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ASPNetRolePermission.cs         
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
	public partial class ASPNetRolePermission : BaseEntity, ICloneable	{
		public ASPNetRolePermission()
		{
			this.RightID = 0;
			this.RoleID = 0;
			this.PermItemID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RightID", RightID); } }


		private long _RightID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RightID { get { return _RightID; } set {_RightID = value; } }

		private long _RoleID;
		[LVRequired]
        public long RoleID { get { return _RoleID; } set {_RoleID = value; } }

		private long _PermItemID;
		[LVRequired]
        public long PermItemID { get { return _PermItemID; } set {_PermItemID = value; } }

		/// <summary>
/// Ref Key: FK_TRolePermission_TRole
/// <summary>
/// <summary>
/// Ref Key: FK_ASPNetRolePermission_refPermission
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
    public class KeyedASPNetRolePermission : KeyedCollection<KeyValuePair<string, long>, ASPNetRolePermission>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedASPNetRolePermission() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ASPNetRolePermission item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RightID) { return new KeyValuePair<string, long>("RightID", k_RightID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ASPNetRolePermission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ASPNetRolePermission item)
        {
            ASPNetRolePermission orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ASPNetRolePermission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ASPNetRolePermission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ASPNetRolePermission GetObjectByKey(long k_RightID) 
		{
            if (this.Contains(GetKey(k_RightID)) == false) return null;
            ASPNetRolePermission ob = this[GetKey(k_RightID)];
            return (ASPNetRolePermission)ob;
        }

		public ASPNetRolePermission GetObjectByKey(long k_RightID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RightID)) == false) {
				ASPNetRolePermission ob = repository.GetQuery<ASPNetRolePermission>().FirstOrDefault(o => o.RightID == k_RightID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ASPNetRolePermission obj = this[GetKey(k_RightID)];
            return (ASPNetRolePermission)obj;
        }

		public ASPNetRolePermission GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ASPNetRolePermission ob = this[keypair];
            return (ASPNetRolePermission)ob;
        }

        public ASPNetRolePermission GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ASPNetRolePermission ob = this[GetKey(keypair)];
            return (ASPNetRolePermission)ob;
        }

		bool _LoadAll = false;
        public List<ASPNetRolePermission> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ASPNetRolePermission>().ToList();
			foreach (ASPNetRolePermission item in list) {
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

        ~KeyedASPNetRolePermission()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
