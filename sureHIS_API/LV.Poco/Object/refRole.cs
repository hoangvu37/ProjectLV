/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refRole.cs         
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
	public partial class refRole : BaseEntity, ICloneable	{
		public refRole()
		{
			this.RoleID = 0;
            this.IsInternalRole = true;
            this.isBuiltIn = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RoleID", RoleID); } }


		private long _RoleID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RoleID { get { return _RoleID; } set {_RoleID = value; } }

		private string _RoleCode;
		[LVRequired]
        [LVMaxLength(16)]
        public string RoleCode { get { return _RoleCode; } set {_RoleCode = value; } }

		private string _RoleName;
		[LVRequired]
        [LVMaxLength(64)]
        public string RoleName { get { return _RoleName; } set {_RoleName = value; } }

		private string _RoleDescription;
		[LVRequired]
        [LVMaxLength(2048)]
        public string RoleDescription { get { return _RoleDescription; } set {_RoleDescription = value; } }

		private bool _IsInternalRole;
        public bool IsInternalRole { get { return _IsInternalRole; } set {_IsInternalRole = value; } }

		private bool _isBuiltIn;
        public bool isBuiltIn { get { return _isBuiltIn; } set {_isBuiltIn = value; } }

		/// <summary>
/// Ref Key: FK_OpSkedDistibution_refRole
/// <summary>
/// <summary>
/// Ref Key: FK_PersonRole_refRole
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
    public class KeyedrefRole : KeyedCollection<KeyValuePair<string, long>, refRole>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefRole() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refRole item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RoleID) { return new KeyValuePair<string, long>("RoleID", k_RoleID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refRole item)
        {
            refRole orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refRole item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refRole GetObjectByKey(long k_RoleID) 
		{
            if (this.Contains(GetKey(k_RoleID)) == false) return null;
            refRole ob = this[GetKey(k_RoleID)];
            return (refRole)ob;
        }

		public refRole GetObjectByKey(long k_RoleID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RoleID)) == false) {
				refRole ob = repository.GetQuery<refRole>().FirstOrDefault(o => o.RoleID == k_RoleID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refRole obj = this[GetKey(k_RoleID)];
            return (refRole)obj;
        }

		public refRole GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refRole ob = this[keypair];
            return (refRole)ob;
        }

        public refRole GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refRole ob = this[GetKey(keypair)];
            return (refRole)ob;
        }

		bool _LoadAll = false;
        public List<refRole> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refRole>().ToList();
			foreach (refRole item in list) {
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

        ~KeyedrefRole()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
