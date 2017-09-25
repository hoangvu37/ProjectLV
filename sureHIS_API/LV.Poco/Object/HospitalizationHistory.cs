/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HospitalizationHistory.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class HospitalizationHistory : BaseEntity, ICloneable	{
		public HospitalizationHistory()
		{
			this.HosHisID = 0;
			this.PtComMedRecID = 0;
			this.HosID = 0;
			this.HCFERecAdmissionTypeID = 0;
            this.AdmissionReason = null;
            this.IAdmReferralTypeCode = null;
            this.FromDate = DateTime.Now;
            this.ToDate = DateTime.Now;
            this.TreatmentResult = null;
            this.DischanrgeReason = null;
            this.HHNotes = null;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HosHisID", HosHisID); } }


		private long _HosHisID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HosHisID { get { return _HosHisID; } set {_HosHisID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long _HosID;
		[LVRequired]
        public long HosID { get { return _HosID; } set {_HosID = value; } }

		private long _HCFERecAdmissionTypeID;
		[LVRequired]
        public long HCFERecAdmissionTypeID { get { return _HCFERecAdmissionTypeID; } set {_HCFERecAdmissionTypeID = value; } }

		private string _AdmissionReason;
        [LVMaxLength(50)]
        public string AdmissionReason { get { return _AdmissionReason; } set {_AdmissionReason = value; } }

		private long? _IAdmReferralTypeCode;
        public long? IAdmReferralTypeCode { get { return _IAdmReferralTypeCode; } set {_IAdmReferralTypeCode = value; } }

		private string _IAdmDiagnosisCode;
		[LVRequired]
        [LVMaxLength(50)]
        public string IAdmDiagnosisCode { get { return _IAdmDiagnosisCode; } set {_IAdmDiagnosisCode = value; } }

		private DateTime? _FromDate;
        public DateTime? FromDate { get { return _FromDate; } set {_FromDate = value; } }

		private DateTime? _ToDate;
        public DateTime? ToDate { get { return _ToDate; } set {_ToDate = value; } }

		private string _TreatmentResult;
        [LVMaxLength(50)]
        public string TreatmentResult { get { return _TreatmentResult; } set {_TreatmentResult = value; } }

		private string _DischanrgeReason;
        [LVMaxLength(50)]
        public string DischanrgeReason { get { return _DischanrgeReason; } set {_DischanrgeReason = value; } }

		private string _HHNotes;
        [LVMaxLength(254)]
        public string HHNotes { get { return _HHNotes; } set {_HHNotes = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_HospitalizationHistory_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalizationHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalizationHistory_refAdmissionType
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalizationHistory_refAdmReferralType
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalizationHistoryDetails_HospitalizationHistory
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
    public class KeyedHospitalizationHistory : KeyedCollection<KeyValuePair<string, long>, HospitalizationHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHospitalizationHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HospitalizationHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HosHisID) { return new KeyValuePair<string, long>("HosHisID", k_HosHisID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HospitalizationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HospitalizationHistory item)
        {
            HospitalizationHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HospitalizationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HospitalizationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HospitalizationHistory GetObjectByKey(long k_HosHisID) 
		{
            if (this.Contains(GetKey(k_HosHisID)) == false) return null;
            HospitalizationHistory ob = this[GetKey(k_HosHisID)];
            return (HospitalizationHistory)ob;
        }

		public HospitalizationHistory GetObjectByKey(long k_HosHisID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HosHisID)) == false) {
				HospitalizationHistory ob = repository.GetQuery<HospitalizationHistory>().FirstOrDefault(o => o.HosHisID == k_HosHisID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HospitalizationHistory obj = this[GetKey(k_HosHisID)];
            return (HospitalizationHistory)obj;
        }

		public HospitalizationHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HospitalizationHistory ob = this[keypair];
            return (HospitalizationHistory)ob;
        }

        public HospitalizationHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HospitalizationHistory ob = this[GetKey(keypair)];
            return (HospitalizationHistory)ob;
        }

		bool _LoadAll = false;
        public List<HospitalizationHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HospitalizationHistory>().ToList();
			foreach (HospitalizationHistory item in list) {
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

        ~KeyedHospitalizationHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
