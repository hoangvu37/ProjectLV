/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HealthCareQueue.cs         
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
	public partial class HealthCareQueue : BaseEntity, ICloneable	{
		public HealthCareQueue()
		{
			this.HCQueueID = 0;
			this.RescrID = 0;
            this.SID = null;
			this.HQSequenceNo = 0;
			this.AdmID = 0;
            this.V_ConsultStatus = null;
            this.GroupHCNo = null;
            this.NumOfRep = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HCQueueID", HCQueueID); } }


		private long _HCQueueID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HCQueueID { get { return _HCQueueID; } set {_HCQueueID = value; } }

		private long? _RescrID;
        public long? RescrID { get { return _RescrID; } set {_RescrID = value; } }

		private DateTime _HQQueueUpDate;
		[LVRequired]
        public DateTime HQQueueUpDate { get { return _HQQueueUpDate; } set {_HQQueueUpDate = value; } }

		private long? _SID;
        public long? SID { get { return _SID; } set {_SID = value; } }

		private long _HQSequenceNo;
		[LVRequired]
        public long HQSequenceNo { get { return _HQSequenceNo; } set {_HQSequenceNo = value; } }

		private long? _AdmID;
        public long? AdmID { get { return _AdmID; } set {_AdmID = value; } }

		private long? _V_ConsultStatus;
        public long? V_ConsultStatus { get { return _V_ConsultStatus; } set {_V_ConsultStatus = value; } }

		private long? _GroupHCNo;
        public long? GroupHCNo { get { return _GroupHCNo; } set {_GroupHCNo = value; } }

		private byte _NumOfRep;
		[LVRequired]
        public byte NumOfRep { get { return _NumOfRep; } set {_NumOfRep = value; } }

		/// <summary>
/// Ref Key: FK_HealthCareQueue_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_HealthCareQueue_RescrUsedInOperation
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
    public class KeyedHealthCareQueue : KeyedCollection<KeyValuePair<string, long>, HealthCareQueue>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHealthCareQueue() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HealthCareQueue item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HCQueueID) { return new KeyValuePair<string, long>("HCQueueID", k_HCQueueID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HealthCareQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HealthCareQueue item)
        {
            HealthCareQueue orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HealthCareQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HealthCareQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HealthCareQueue GetObjectByKey(long k_HCQueueID) 
		{
            if (this.Contains(GetKey(k_HCQueueID)) == false) return null;
            HealthCareQueue ob = this[GetKey(k_HCQueueID)];
            return (HealthCareQueue)ob;
        }

		public HealthCareQueue GetObjectByKey(long k_HCQueueID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HCQueueID)) == false) {
				HealthCareQueue ob = repository.GetQuery<HealthCareQueue>().FirstOrDefault(o => o.HCQueueID == k_HCQueueID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HealthCareQueue obj = this[GetKey(k_HCQueueID)];
            return (HealthCareQueue)obj;
        }

		public HealthCareQueue GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HealthCareQueue ob = this[keypair];
            return (HealthCareQueue)ob;
        }

        public HealthCareQueue GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HealthCareQueue ob = this[GetKey(keypair)];
            return (HealthCareQueue)ob;
        }

		bool _LoadAll = false;
        public List<HealthCareQueue> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HealthCareQueue>().ToList();
			foreach (HealthCareQueue item in list) {
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

        ~KeyedHealthCareQueue()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
