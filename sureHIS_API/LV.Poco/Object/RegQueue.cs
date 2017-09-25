/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : RegQueue.cs         
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
	public partial class RegQueue : BaseEntity, ICloneable	{
		public RegQueue()
		{
			this.RegQueueID = 0;
			this.SequenceNo = 0;
            this.PatientCode = null;
			this.SID = 0;
            this.IsWaiting = true;
            this.GroupHCNo = null;
            this.RCEmpID = null;
            this.WDID = null;
            this.NumOfRep = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RegQueueID", RegQueueID); } }


		private long _RegQueueID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RegQueueID { get { return _RegQueueID; } set {_RegQueueID = value; } }

		private long _SequenceNo;
		[LVRequired]
        public long SequenceNo { get { return _SequenceNo; } set {_SequenceNo = value; } }

		private string _PatientCode;
        [LVMaxLength(20)]
        public string PatientCode { get { return _PatientCode; } set {_PatientCode = value; } }

		private DateTime? _QueueUpDate;
        public DateTime? QueueUpDate { get { return _QueueUpDate; } set {_QueueUpDate = value; } }

		private long? _SID;
        public long? SID { get { return _SID; } set {_SID = value; } }

		private bool _IsWaiting;
        public bool IsWaiting { get { return _IsWaiting; } set {_IsWaiting = value; } }

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
/// Ref Key: FK_RegQueue_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_RegQueue_WardInDept
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
    public class KeyedRegQueue : KeyedCollection<KeyValuePair<string, long>, RegQueue>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedRegQueue() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(RegQueue item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RegQueueID) { return new KeyValuePair<string, long>("RegQueueID", k_RegQueueID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(RegQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, RegQueue item)
        {
            RegQueue orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(RegQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(RegQueue item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public RegQueue GetObjectByKey(long k_RegQueueID) 
		{
            if (this.Contains(GetKey(k_RegQueueID)) == false) return null;
            RegQueue ob = this[GetKey(k_RegQueueID)];
            return (RegQueue)ob;
        }

		public RegQueue GetObjectByKey(long k_RegQueueID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RegQueueID)) == false) {
				RegQueue ob = repository.GetQuery<RegQueue>().FirstOrDefault(o => o.RegQueueID == k_RegQueueID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            RegQueue obj = this[GetKey(k_RegQueueID)];
            return (RegQueue)obj;
        }

		public RegQueue GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            RegQueue ob = this[keypair];
            return (RegQueue)ob;
        }

        public RegQueue GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            RegQueue ob = this[GetKey(keypair)];
            return (RegQueue)ob;
        }

		bool _LoadAll = false;
        public List<RegQueue> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<RegQueue>().ToList();
			foreach (RegQueue item in list) {
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

        ~KeyedRegQueue()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
