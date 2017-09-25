/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientInvoices.cs         
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
	public partial class PatientInvoices : BaseEntity, ICloneable	{
		public PatientInvoices()
		{
			this.InvoiceID = 0;
            this.FormID = null;
            this.SerialNo = null;
            this.InvDate = DateTime.Now;
            this.IsPrinted = false;
            this.EstEmpID = null;
            this.PDFURL = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("InvoiceID", InvoiceID); } }


		private long _InvoiceID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long InvoiceID { get { return _InvoiceID; } set {_InvoiceID = value; } }

		private string _InvoiceNo;
		[LVRequired]
        [LVMaxLength(50)]
        public string InvoiceNo { get { return _InvoiceNo; } set {_InvoiceNo = value; } }

		private string _FormID;
        [LVMaxLength(20)]
        public string FormID { get { return _FormID; } set {_FormID = value; } }

		private string _SerialNo;
        [LVMaxLength(20)]
        public string SerialNo { get { return _SerialNo; } set {_SerialNo = value; } }

		private DateTime? _InvDate;
        public DateTime? InvDate { get { return _InvDate; } set {_InvDate = value; } }

		private bool? _IsPrinted;
        public bool? IsPrinted { get { return _IsPrinted; } set {_IsPrinted = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private string _PDFURL;
        [LVMaxLength(255)]
        public string PDFURL { get { return _PDFURL; } set {_PDFURL = value; } }

		/// <summary>
/// Ref Key: FK_HospitalFeeTransaction_PatientInvoices
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
    public class KeyedPatientInvoices : KeyedCollection<KeyValuePair<string, long>, PatientInvoices>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientInvoices() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientInvoices item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_InvoiceID) { return new KeyValuePair<string, long>("InvoiceID", k_InvoiceID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientInvoices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientInvoices item)
        {
            PatientInvoices orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientInvoices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientInvoices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientInvoices GetObjectByKey(long k_InvoiceID) 
		{
            if (this.Contains(GetKey(k_InvoiceID)) == false) return null;
            PatientInvoices ob = this[GetKey(k_InvoiceID)];
            return (PatientInvoices)ob;
        }

		public PatientInvoices GetObjectByKey(long k_InvoiceID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_InvoiceID)) == false) {
				PatientInvoices ob = repository.GetQuery<PatientInvoices>().FirstOrDefault(o => o.InvoiceID == k_InvoiceID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientInvoices obj = this[GetKey(k_InvoiceID)];
            return (PatientInvoices)obj;
        }

		public PatientInvoices GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientInvoices ob = this[keypair];
            return (PatientInvoices)ob;
        }

        public PatientInvoices GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientInvoices ob = this[GetKey(keypair)];
            return (PatientInvoices)ob;
        }

		bool _LoadAll = false;
        public List<PatientInvoices> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientInvoices>().ToList();
			foreach (PatientInvoices item in list) {
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

        ~KeyedPatientInvoices()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
