/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : InsuranceRegQueue.cs         
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
	public partial class InsuranceRegQueue : BaseEntity, ICloneable	{
		public InsuranceRegQueue()
		{
			this.InsRegQueueID = 0;
			this.InsSequenceNo = 0;
			this.SID = 0;
            this.IsWaiting = false;
			this.GroupHCNo = 0;
            this.RCEmpID = null;
            this.WDID = null;
            this.NumOfRep = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("InsRegQueueID", InsRegQueueID); } }


		private long _InsRegQueueID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long InsRegQueueID { get { return _InsRegQueueID; } set {_InsRegQueueID = value; } }

		private long? _InsSequenceNo;
        public long? InsSequenceNo { get { return _InsSequenceNo; } set {_InsSequenceNo = value; } }

		private string _PatientCode;
        [LVMaxLength(20)]
        public string PatientCode { get { return _PatientCode; } set {_PatientCode = value; } }

		private string _HealthInsNo;
        [LVMaxLength(20)]
        public string HealthInsNo { get { return _HealthInsNo; } set {_HealthInsNo = value; } }

		private DateTime _InsQueueUpDate;
		[LVRequired]
        public DateTime InsQueueUpDate { get { return _InsQueueUpDate; } set {_InsQueueUpDate = value; } }

		private long _SID;
		[LVRequired]
        public long SID { get { return _SID; } set {_SID = value; } }

		private bool? _IsWaiting;
        public bool? IsWaiting { get { return _IsWaiting; } set {_IsWaiting = value; } }

		private long? _GroupHCNo;
        public long? GroupHCNo { get { return _GroupHCNo; } set {_GroupHCNo = value; } }

		private long? _RCEmpID;
        public long? RCEmpID { get { return _RCEmpID; } set {_RCEmpID = value; } }

		private long? _WDID;
        public long? WDID { get { return _WDID; } set {_WDID = value; } }

		private byte _NumOfRep;
		[LVRequired]
        public byte NumOfRep { get { return _NumOfRep; } set {_NumOfRep = value; } }

		/// <summary>
/// Ref Key: FK_InsuranceRegQueue_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_InsuranceRegQueue_WardInDept
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
    public class KeyedInsuranceRegQueue : KeyedCollection<KeyValuePair<string, long>, InsuranceRegQueue>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedInsuranceRegQueue() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(InsuranceRegQueue item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_InsRegQueueID) { return new KeyValuePair<string, long>("InsRegQueueID", k_InsRegQueueID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(InsuranceRegQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, InsuranceRegQueue item)
        {
            InsuranceRegQueue orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(InsuranceRegQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(InsuranceRegQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public InsuranceRegQueue GetObjectByKey(long k_InsRegQueueID) 
		{
            if (this.Contains(GetKey(k_InsRegQueueID)) == false) return null;
            InsuranceRegQueue ob = this[GetKey(k_InsRegQueueID)];
            return (InsuranceRegQueue)ob;
        }

		public InsuranceRegQueue GetObjectByKey(long k_InsRegQueueID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_InsRegQueueID)) == false) {
				InsuranceRegQueue ob = repository.GetQuery<InsuranceRegQueue>().FirstOrDefault(o => o.InsRegQueueID == k_InsRegQueueID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            InsuranceRegQueue obj = this[GetKey(k_InsRegQueueID)];
            return (InsuranceRegQueue)obj;
        }

		public InsuranceRegQueue GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            InsuranceRegQueue ob = this[keypair];
            return (InsuranceRegQueue)ob;
        }

        public InsuranceRegQueue GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            InsuranceRegQueue ob = this[GetKey(keypair)];
            return (InsuranceRegQueue)ob;
        }

		bool _LoadAll = false;
        public List<InsuranceRegQueue> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<InsuranceRegQueue>().ToList();
			foreach (InsuranceRegQueue item in list) {
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

        ~KeyedInsuranceRegQueue()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
