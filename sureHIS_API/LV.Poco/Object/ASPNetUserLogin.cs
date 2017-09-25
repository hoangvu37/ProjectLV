/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ASPNetUserLogin.cs         
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
	public partial class ASPNetUserLogin : BaseEntity, ICloneable	{
		public ASPNetUserLogin()
		{
			this.SessionID = 0;
			this.ASPNetUserID = 0;
            this.LoginTime = DateTime.Now;
            this.LogoutTime = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SessionID", SessionID); } }


		private long _SessionID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SessionID { get { return _SessionID; } set {_SessionID = value; } }

		private long _ASPNetUserID;
		[LVRequired]
        public long ASPNetUserID { get { return _ASPNetUserID; } set {_ASPNetUserID = value; } }

		private DateTime _LoginTime;
		[LVRequired]
        public DateTime LoginTime { get { return _LoginTime; } set {_LoginTime = value; } }

		private DateTime _LogoutTime;
		[LVRequired]
        public DateTime LogoutTime { get { return _LogoutTime; } set {_LogoutTime = value; } }

		private string _HostAddress;
		[LVRequired]
        [LVMaxLength(32)]
        public string HostAddress { get { return _HostAddress; } set {_HostAddress = value; } }

		private string _SessionKey;
		[LVRequired]
        [LVMaxLength(50)]
        public string SessionKey { get { return _SessionKey; } set {_SessionKey = value; } }

		private string _LoginProvider;
		[LVRequired]
        [LVMaxLength(128)]
        public string LoginProvider { get { return _LoginProvider; } set {_LoginProvider = value; } }

		private string _ProviderKey;
        [LVMaxLength(64)]
        public string ProviderKey { get { return _ProviderKey; } set {_ProviderKey = value; } }

		private string _IdentityUser_ID;
        [LVMaxLength(128)]
        public string IdentityUser_ID { get { return _IdentityUser_ID; } set {_IdentityUser_ID = value; } }

		/// <summary>
/// Ref Key: FK_ASPNetUserLogin_ASPNetUser
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
    public class KeyedASPNetUserLogin : KeyedCollection<KeyValuePair<string, long>, ASPNetUserLogin>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedASPNetUserLogin() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ASPNetUserLogin item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SessionID) { return new KeyValuePair<string, long>("SessionID", k_SessionID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ASPNetUserLogin item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ASPNetUserLogin item)
        {
            ASPNetUserLogin orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ASPNetUserLogin item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ASPNetUserLogin item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ASPNetUserLogin GetObjectByKey(long k_SessionID) 
		{
            if (this.Contains(GetKey(k_SessionID)) == false) return null;
            ASPNetUserLogin ob = this[GetKey(k_SessionID)];
            return (ASPNetUserLogin)ob;
        }

		public ASPNetUserLogin GetObjectByKey(long k_SessionID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SessionID)) == false) {
				ASPNetUserLogin ob = repository.GetQuery<ASPNetUserLogin>().FirstOrDefault(o => o.SessionID == k_SessionID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ASPNetUserLogin obj = this[GetKey(k_SessionID)];
            return (ASPNetUserLogin)obj;
        }

		public ASPNetUserLogin GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ASPNetUserLogin ob = this[keypair];
            return (ASPNetUserLogin)ob;
        }

        public ASPNetUserLogin GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ASPNetUserLogin ob = this[GetKey(keypair)];
            return (ASPNetUserLogin)ob;
        }

		bool _LoadAll = false;
        public List<ASPNetUserLogin> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ASPNetUserLogin>().ToList();
			foreach (ASPNetUserLogin item in list) {
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

        ~KeyedASPNetUserLogin()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
