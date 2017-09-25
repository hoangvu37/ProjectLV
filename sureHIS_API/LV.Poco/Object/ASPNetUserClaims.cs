/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ASPNetUserClaims.cs         
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
	public partial class ASPNetUserClaims : BaseEntity, ICloneable	{
		public ASPNetUserClaims()
		{
			this.ID = 0;
			this.ASPNetUserID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ID", ID); } }


		private long _ID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ID { get { return _ID; } set {_ID = value; } }

		private long? _ASPNetUserID;
        public long? ASPNetUserID { get { return _ASPNetUserID; } set {_ASPNetUserID = value; } }

		private string _ClaimType;
        [LVMaxLength(64)]
        public string ClaimType { get { return _ClaimType; } set {_ClaimType = value; } }

		private string _ClaimValue;
        [LVMaxLength(64)]
        public string ClaimValue { get { return _ClaimValue; } set {_ClaimValue = value; } }

		private string _IdentityUser_ID;
        [LVMaxLength(128)]
        public string IdentityUser_ID { get { return _IdentityUser_ID; } set {_IdentityUser_ID = value; } }

		/// <summary>
/// Ref Key: FK_ASPNetUserClaims_ASPNetUser
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
    public class KeyedASPNetUserClaims : KeyedCollection<KeyValuePair<string, long>, ASPNetUserClaims>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedASPNetUserClaims() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ASPNetUserClaims item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ID) { return new KeyValuePair<string, long>("ID", k_ID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ASPNetUserClaims item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ASPNetUserClaims item)
        {
            ASPNetUserClaims orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ASPNetUserClaims item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ASPNetUserClaims item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ASPNetUserClaims GetObjectByKey(long k_ID) 
		{
            if (this.Contains(GetKey(k_ID)) == false) return null;
            ASPNetUserClaims ob = this[GetKey(k_ID)];
            return (ASPNetUserClaims)ob;
        }

		public ASPNetUserClaims GetObjectByKey(long k_ID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ID)) == false) {
				ASPNetUserClaims ob = repository.GetQuery<ASPNetUserClaims>().FirstOrDefault(o => o.ID == k_ID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ASPNetUserClaims obj = this[GetKey(k_ID)];
            return (ASPNetUserClaims)obj;
        }

		public ASPNetUserClaims GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ASPNetUserClaims ob = this[keypair];
            return (ASPNetUserClaims)ob;
        }

        public ASPNetUserClaims GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ASPNetUserClaims ob = this[GetKey(keypair)];
            return (ASPNetUserClaims)ob;
        }

		bool _LoadAll = false;
        public List<ASPNetUserClaims> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ASPNetUserClaims>().ToList();
			foreach (ASPNetUserClaims item in list) {
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

        ~KeyedASPNetUserClaims()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
