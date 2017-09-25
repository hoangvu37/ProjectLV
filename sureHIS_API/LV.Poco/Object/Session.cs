/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Session.cs         
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
	public partial class Session : BaseEntity, ICloneable	{
		public Session()
		{
			this.SessID = 0;
			this.AccountID = 0;
            this.LoginTime = DateTime.Now;
            this.LogoutTime = DateTime.Now;
            this.HotAddress = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SessID", SessID); } }


		private long _SessID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SessID { get { return _SessID; } set {_SessID = value; } }

		private long? _AccountID;
        public long? AccountID { get { return _AccountID; } set {_AccountID = value; } }

		private DateTime? _LoginTime;
        public DateTime? LoginTime { get { return _LoginTime; } set {_LoginTime = value; } }

		private DateTime? _LogoutTime;
        public DateTime? LogoutTime { get { return _LogoutTime; } set {_LogoutTime = value; } }

		private string _HotAddress;
        [LVMaxLength(64)]
        public string HotAddress { get { return _HotAddress; } set {_HotAddress = value; } }

		private Guid? _SessKey;
        public Guid? SessKey { get { return _SessKey; } set {_SessKey = value; } }

		private string _SessSetting;
		[LVRequired]
        public string SessSetting { get { return _SessSetting; } set {_SessSetting = value; } }

		/// <summary>
/// Ref Key: FK_Session_UserAccount
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
    public class KeyedSession : KeyedCollection<KeyValuePair<string, long>, Session>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedSession() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Session item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SessID) { return new KeyValuePair<string, long>("SessID", k_SessID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Session item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Session item)
        {
            Session orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Session item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Session item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Session GetObjectByKey(long k_SessID) 
		{
            if (this.Contains(GetKey(k_SessID)) == false) return null;
            Session ob = this[GetKey(k_SessID)];
            return (Session)ob;
        }

		public Session GetObjectByKey(long k_SessID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SessID)) == false) {
				Session ob = repository.GetQuery<Session>().FirstOrDefault(o => o.SessID == k_SessID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Session obj = this[GetKey(k_SessID)];
            return (Session)obj;
        }

		public Session GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Session ob = this[keypair];
            return (Session)ob;
        }

        public Session GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Session ob = this[GetKey(keypair)];
            return (Session)ob;
        }

		bool _LoadAll = false;
        public List<Session> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Session>().ToList();
			foreach (Session item in list) {
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

        ~KeyedSession()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
