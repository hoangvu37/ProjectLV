/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientMedRecord.cs         
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
	public partial class PatientMedRecord : BaseEntity, ICloneable	{
		public PatientMedRecord()
		{
			this.PtRecID = 0;
			this.PtId = 0;
            this.MedReportBookCode = null;
            this.NationalMedicalCode = null;
            this.PtRecQRCode = null;
            this.CreatedDtm = DateTime.Now;
            this.FinishedDtm = DateTime.Now;
            this.ExpiryDtm = DateTime.Now;
			this.EstEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtRecID", PtRecID); } }


		private long _PtRecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtRecID { get { return _PtRecID; } set {_PtRecID = value; } }

		private long _PtId;
		[LVRequired]
        public long PtId { get { return _PtId; } set {_PtId = value; } }

		private string _MedReportBookCode;
        [LVMaxLength(14)]
        public string MedReportBookCode { get { return _MedReportBookCode; } set {_MedReportBookCode = value; } }

		private string _NationalMedicalCode;
        [LVMaxLength(14)]
        public string NationalMedicalCode { get { return _NationalMedicalCode; } set {_NationalMedicalCode = value; } }

		private string _PtRecQRCode;
        [LVMaxLength(20)]
        public string PtRecQRCode { get { return _PtRecQRCode; } set {_PtRecQRCode = value; } }

		private DateTime _CreatedDtm;
		[LVRequired]
        public DateTime CreatedDtm { get { return _CreatedDtm; } set {_CreatedDtm = value; } }

		private DateTime? _FinishedDtm;
        public DateTime? FinishedDtm { get { return _FinishedDtm; } set {_FinishedDtm = value; } }

		private DateTime? _ExpiryDtm;
        public DateTime? ExpiryDtm { get { return _ExpiryDtm; } set {_ExpiryDtm = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_Encounter_PatientRecords
/// <summary>
/// <summary>
/// Ref Key: FK_PtMedRecord_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientCommonMedRecord_PatientMedRecords
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
    public class KeyedPatientMedRecord : KeyedCollection<KeyValuePair<string, long>, PatientMedRecord>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientMedRecord() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientMedRecord item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtRecID) { return new KeyValuePair<string, long>("PtRecID", k_PtRecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientMedRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientMedRecord item)
        {
            PatientMedRecord orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientMedRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientMedRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientMedRecord GetObjectByKey(long k_PtRecID) 
		{
            if (this.Contains(GetKey(k_PtRecID)) == false) return null;
            PatientMedRecord ob = this[GetKey(k_PtRecID)];
            return (PatientMedRecord)ob;
        }

		public PatientMedRecord GetObjectByKey(long k_PtRecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtRecID)) == false) {
				PatientMedRecord ob = repository.GetQuery<PatientMedRecord>().FirstOrDefault(o => o.PtRecID == k_PtRecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientMedRecord obj = this[GetKey(k_PtRecID)];
            return (PatientMedRecord)obj;
        }

		public PatientMedRecord GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientMedRecord ob = this[keypair];
            return (PatientMedRecord)ob;
        }

        public PatientMedRecord GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientMedRecord ob = this[GetKey(keypair)];
            return (PatientMedRecord)ob;
        }

		bool _LoadAll = false;
        public List<PatientMedRecord> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientMedRecord>().ToList();
			foreach (PatientMedRecord item in list) {
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

        ~KeyedPatientMedRecord()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
