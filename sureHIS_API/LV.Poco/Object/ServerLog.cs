/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ServerLog.cs         
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
	public partial class ServerLog : BaseEntity, ICloneable	{
		public ServerLog()
		{
			this.LogEntryID = 0;
			this.AccountID = 0;
            this.V_AccessType = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("LogEntryID", LogEntryID); } }


		private long _LogEntryID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long LogEntryID { get { return _LogEntryID; } set {_LogEntryID = value; } }

		private long? _AccountID;
        public long? AccountID { get { return _AccountID; } set {_AccountID = value; } }

		private string _ClientIDAddress;
        [LVMaxLength(64)]
        public string ClientIDAddress { get { return _ClientIDAddress; } set {_ClientIDAddress = value; } }

		private DateTime? _AccessDateTime;
        public DateTime? AccessDateTime { get { return _AccessDateTime; } set {_AccessDateTime = value; } }

		private long? _V_AccessType;
        public long? V_AccessType { get { return _V_AccessType; } set {_V_AccessType = value; } }

		/// <summary>
/// Ref Key: FK_ServerLog_UserAccount
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
    public class KeyedServerLog : KeyedCollection<KeyValuePair<string, long>, ServerLog>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedServerLog() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ServerLog item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_LogEntryID) { return new KeyValuePair<string, long>("LogEntryID", k_LogEntryID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ServerLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ServerLog item)
        {
            ServerLog orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ServerLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ServerLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ServerLog GetObjectByKey(long k_LogEntryID) 
		{
            if (this.Contains(GetKey(k_LogEntryID)) == false) return null;
            ServerLog ob = this[GetKey(k_LogEntryID)];
            return (ServerLog)ob;
        }

		public ServerLog GetObjectByKey(long k_LogEntryID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_LogEntryID)) == false) {
				ServerLog ob = repository.GetQuery<ServerLog>().FirstOrDefault(o => o.LogEntryID == k_LogEntryID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ServerLog obj = this[GetKey(k_LogEntryID)];
            return (ServerLog)obj;
        }

		public ServerLog GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ServerLog ob = this[keypair];
            return (ServerLog)ob;
        }

        public ServerLog GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ServerLog ob = this[GetKey(keypair)];
            return (ServerLog)ob;
        }

		bool _LoadAll = false;
        public List<ServerLog> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ServerLog>().ToList();
			foreach (ServerLog item in list) {
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

        ~KeyedServerLog()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
