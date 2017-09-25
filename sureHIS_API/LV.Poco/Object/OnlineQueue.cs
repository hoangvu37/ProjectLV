/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : OnlineQueue.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class OnlineQueue : BaseEntity, ICloneable	{
		public OnlineQueue()
		{
			this.OQueueID = 0;
			this.RegInfoID = 0;
			this.IdentityUser_ID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("OQueueID", OQueueID); } }


		private long _OQueueID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long OQueueID { get { return _OQueueID; } set {_OQueueID = value; } }

		private long? _RegInfoID;
        public long? RegInfoID { get { return _RegInfoID; } set {_RegInfoID = value; } }

		private long? _IdentityUser_ID;
        public long? IdentityUser_ID { get { return _IdentityUser_ID; } set {_IdentityUser_ID = value; } }

		/// <summary>
/// Ref Key: FK_Appointment_OnlineQueue
/// <summary>
/// <summary>
/// Ref Key: FK_OnlineQueue_NetworkGuestAccount
/// <summary>
/// <summary>
/// Ref Key: FK_OnlineQueue_RegistrationInfo
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
    public class KeyedOnlineQueue : KeyedCollection<KeyValuePair<string, long>, OnlineQueue>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedOnlineQueue() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(OnlineQueue item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_OQueueID) { return new KeyValuePair<string, long>("OQueueID", k_OQueueID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(OnlineQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, OnlineQueue item)
        {
            OnlineQueue orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(OnlineQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(OnlineQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public OnlineQueue GetObjectByKey(long k_OQueueID) 
		{
            if (this.Contains(GetKey(k_OQueueID)) == false) return null;
            OnlineQueue ob = this[GetKey(k_OQueueID)];
            return (OnlineQueue)ob;
        }

		public OnlineQueue GetObjectByKey(long k_OQueueID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_OQueueID)) == false) {
				OnlineQueue ob = repository.GetQuery<OnlineQueue>().FirstOrDefault(o => o.OQueueID == k_OQueueID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            OnlineQueue obj = this[GetKey(k_OQueueID)];
            return (OnlineQueue)obj;
        }

		public OnlineQueue GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            OnlineQueue ob = this[keypair];
            return (OnlineQueue)ob;
        }

        public OnlineQueue GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            OnlineQueue ob = this[GetKey(keypair)];
            return (OnlineQueue)ob;
        }

		bool _LoadAll = false;
        public List<OnlineQueue> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<OnlineQueue>().ToList();
			foreach (OnlineQueue item in list) {
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

        ~KeyedOnlineQueue()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
