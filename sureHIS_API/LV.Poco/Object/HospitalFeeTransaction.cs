/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HospitalFeeTransaction.cs         
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
	public partial class HospitalFeeTransaction : BaseEntity, ICloneable	{
		public HospitalFeeTransaction()
		{
			this.HosFeeTransID = 0;
			this.TransID = 0;
            this.IntRcptTypeID = null;
            this.ManualReceiptNo = null;
            this.TransItemRemarkd = null;
            this.InvoiceID = null;
            this.V_DocType = null;
			this.V_PmtMethod = 0;
            this.CurCode = null;
            this.TransSummary = null;
			this.EstEmpID = 0;
            this.ModifiedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HosFeeTransID", HosFeeTransID); } }


		private long _HosFeeTransID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HosFeeTransID { get { return _HosFeeTransID; } set {_HosFeeTransID = value; } }

		private long _TransID;
		[LVRequired]
        public long TransID { get { return _TransID; } set {_TransID = value; } }

		private byte? _IntRcptTypeID;
        public byte? IntRcptTypeID { get { return _IntRcptTypeID; } set {_IntRcptTypeID = value; } }

		private string _ReceiptNo;
		[LVRequired]
        [LVMaxLength(20)]
        public string ReceiptNo { get { return _ReceiptNo; } set {_ReceiptNo = value; } }

		private string _ManualReceiptNo;
        [LVMaxLength(20)]
        public string ManualReceiptNo { get { return _ManualReceiptNo; } set {_ManualReceiptNo = value; } }

		private string _TransItemRemarkd;
        [LVMaxLength(1024)]
        public string TransItemRemarkd { get { return _TransItemRemarkd; } set {_TransItemRemarkd = value; } }

		private long? _InvoiceID;
        public long? InvoiceID { get { return _InvoiceID; } set {_InvoiceID = value; } }

		private long? _V_DocType;
        public long? V_DocType { get { return _V_DocType; } set {_V_DocType = value; } }

		private long _V_PmtMethod;
		[LVRequired]
        public long V_PmtMethod { get { return _V_PmtMethod; } set {_V_PmtMethod = value; } }

		private string _CurCode;
        [LVMaxLength(3)]
        public string CurCode { get { return _CurCode; } set {_CurCode = value; } }

		private string _TransSummary;
        public string TransSummary { get { return _TransSummary; } set {_TransSummary = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		/// <summary>
/// Ref Key: FK_HospitalFeeTransaction_PatientInvoices
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalClaimService_HospitalFeeTransaction
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
    public class KeyedHospitalFeeTransaction : KeyedCollection<KeyValuePair<string, long>, HospitalFeeTransaction>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHospitalFeeTransaction() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HospitalFeeTransaction item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HosFeeTransID) { return new KeyValuePair<string, long>("HosFeeTransID", k_HosFeeTransID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HospitalFeeTransaction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HospitalFeeTransaction item)
        {
            HospitalFeeTransaction orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HospitalFeeTransaction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HospitalFeeTransaction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HospitalFeeTransaction GetObjectByKey(long k_HosFeeTransID) 
		{
            if (this.Contains(GetKey(k_HosFeeTransID)) == false) return null;
            HospitalFeeTransaction ob = this[GetKey(k_HosFeeTransID)];
            return (HospitalFeeTransaction)ob;
        }

		public HospitalFeeTransaction GetObjectByKey(long k_HosFeeTransID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HosFeeTransID)) == false) {
				HospitalFeeTransaction ob = repository.GetQuery<HospitalFeeTransaction>().FirstOrDefault(o => o.HosFeeTransID == k_HosFeeTransID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HospitalFeeTransaction obj = this[GetKey(k_HosFeeTransID)];
            return (HospitalFeeTransaction)obj;
        }

		public HospitalFeeTransaction GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HospitalFeeTransaction ob = this[keypair];
            return (HospitalFeeTransaction)ob;
        }

        public HospitalFeeTransaction GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HospitalFeeTransaction ob = this[GetKey(keypair)];
            return (HospitalFeeTransaction)ob;
        }

		bool _LoadAll = false;
        public List<HospitalFeeTransaction> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HospitalFeeTransaction>().ToList();
			foreach (HospitalFeeTransaction item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<HospitalFeeTransaction> LoadIXFK_HospitalFeeTransaction_PatientInvoices(long p_InvoiceID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<HospitalFeeTransaction>().Where(o=> o.InvoiceID == p_InvoiceID).ToList();
			foreach (HospitalFeeTransaction item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
            return list;
		}
			
		public List<HospitalFeeTransaction> LoadIXFK_HospitalFeeTransaction_PatientTransaction(long p_TransID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<HospitalFeeTransaction>().Where(o=> o.TransID == p_TransID).ToList();
			foreach (HospitalFeeTransaction item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
            return list;
		}
			
		public List<HospitalFeeTransaction> LoadIXFK_HospitalFeeTransaction_refCurrency(string p_CurCode, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<HospitalFeeTransaction>().Where(o=> o.CurCode == p_CurCode).ToList();
			foreach (HospitalFeeTransaction item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
            return list;
		}
			
		public List<HospitalFeeTransaction> LoadIXFK_HospitalFeeTransaction_refInternalReceiptType(byte p_IntRcptTypeID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<HospitalFeeTransaction>().Where(o=> o.IntRcptTypeID == p_IntRcptTypeID).ToList();
			foreach (HospitalFeeTransaction item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
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

        ~KeyedHospitalFeeTransaction()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
