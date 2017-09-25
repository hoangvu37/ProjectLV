/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientAdmission.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class PatientAdmission : BaseEntity, ICloneable	{
		public PatientAdmission()
		{
			this.AdmID = 0;
			this.PtID = 0;
            this.HCFEncEncDisDtm = DateTime.Now;
            this.PtClassID = null;
            this.AgencyID = null;
            this.IAdmReferralTypeCode = null;
            this.IAdmReferProvName = null;
            this.ReferralICD = null;
            this.FrontDeskEmpID = 0;
            this.PractitionerID = null;
            this.V_EmergencyMedStatus = null;
            this.HCFEncReasonVisitCode = null;
			this.HCFERecAdmTypeID = 0;
            this.PreDiagnosis = null;
            this.DxID = null;
            this.isInPtTX = true;
            this.V_AdmProcStatus = null;
            this.V_AdmPriority = 0;
			this.V_NHITransType = 0;
			this.ReferHosID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AdmID", AdmID); } }


		private long _AdmID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AdmID { get { return _AdmID; } set {_AdmID = value; } }

		private string _HCEpiIDCode;
        [LVMaxLength(20)]
        public string HCEpiIDCode { get { return _HCEpiIDCode; } set {_HCEpiIDCode = value; } }

		private long _PtID;
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private DateTime _HCFEncEncAdmDtm;
		[LVRequired]
        public DateTime HCFEncEncAdmDtm { get { return _HCFEncEncAdmDtm; } set {_HCFEncEncAdmDtm = value; } }

		private DateTime? _HCFEncEncDisDtm;
        public DateTime? HCFEncEncDisDtm { get { return _HCFEncEncDisDtm; } set {_HCFEncEncDisDtm = value; } }

		private long? _PtClassID;
        public long? PtClassID { get { return _PtClassID; } set {_PtClassID = value; } }

		private long? _AgencyID;
        public long? AgencyID { get { return _AgencyID; } set {_AgencyID = value; } }

		private string _AgencyDoctor;
        [LVMaxLength(64)]
        public string AgencyDoctor { get { return _AgencyDoctor; } set {_AgencyDoctor = value; } }

		private long? _IAdmReferralTypeCode;
        public long? IAdmReferralTypeCode { get { return _IAdmReferralTypeCode; } set {_IAdmReferralTypeCode = value; } }

		private string _IAdmReferProvName;
        [LVMaxLength(10)]
        public string IAdmReferProvName { get { return _IAdmReferProvName; } set {_IAdmReferProvName = value; } }

		private string _ReferralICD;
        [LVMaxLength(10)]
        public string ReferralICD { get { return _ReferralICD; } set {_ReferralICD = value; } }

		private string _RegMethodID;
		[LVRequired]
        [LVMaxLength(10)]
        public string RegMethodID { get { return _RegMethodID; } set {_RegMethodID = value; } }

		private long _FrontDeskEmpID;
		[LVRequired]
        public long FrontDeskEmpID { get { return _FrontDeskEmpID; } set {_FrontDeskEmpID = value; } }

		private long? _PractitionerID;
        public long? PractitionerID { get { return _PractitionerID; } set {_PractitionerID = value; } }

		private long? _V_EmergencyMedStatus;
        public long? V_EmergencyMedStatus { get { return _V_EmergencyMedStatus; } set {_V_EmergencyMedStatus = value; } }

		private string _HCFEncReasonVisitCode;
        [LVMaxLength(254)]
        public string HCFEncReasonVisitCode { get { return _HCFEncReasonVisitCode; } set {_HCFEncReasonVisitCode = value; } }

		private long _HCFERecAdmTypeID;
		[LVRequired]
        public long HCFERecAdmTypeID { get { return _HCFERecAdmTypeID; } set {_HCFERecAdmTypeID = value; } }

		private string _PreDiagnosis;
        [LVMaxLength(128)]
        public string PreDiagnosis { get { return _PreDiagnosis; } set {_PreDiagnosis = value; } }

		private long? _DxID;
        public long? DxID { get { return _DxID; } set {_DxID = value; } }

		private bool? _isInPtTX;
        public bool? isInPtTX { get { return _isInPtTX; } set {_isInPtTX = value; } }

		private long? _V_AdmProcStatus;
        public long? V_AdmProcStatus { get { return _V_AdmProcStatus; } set {_V_AdmProcStatus = value; } }

		private long _V_AdmPriority;
		[LVRequired]
        public long V_AdmPriority { get { return _V_AdmPriority; } set {_V_AdmPriority = value; } }

		private byte _isHCFEncReasonVisit;
		[LVRequired]
        public byte isHCFEncReasonVisit { get { return _isHCFEncReasonVisit; } set {_isHCFEncReasonVisit = value; } }

		private string _HCFEncNotes;
        [LVMaxLength(254)]
        public string HCFEncNotes { get { return _HCFEncNotes; } set {_HCFEncNotes = value; } }

		private DateTime? _NHITransDate;
        public DateTime? NHITransDate { get { return _NHITransDate; } set {_NHITransDate = value; } }

		private long? _V_NHITransType;
        public long? V_NHITransType { get { return _V_NHITransType; } set {_V_NHITransType = value; } }

		private long? _ReferHosID;
        public long? ReferHosID { get { return _ReferHosID; } set {_ReferHosID = value; } }

		private string _HIReferDiagnosis;
        [LVMaxLength(500)]
        public string HIReferDiagnosis { get { return _HIReferDiagnosis; } set {_HIReferDiagnosis = value; } }

		/// <summary>
/// Ref Key: FK_AttachedDoc_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_DeathSituationInfo_ReceivePatient
/// <summary>
/// <summary>
/// Ref Key: FK_HealthCareQueue_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_HIAdmission_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalClaimService_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalEncounter_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReq_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_PatientAdmission_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientAdmission_PatientClassification
/// <summary>
/// <summary>
/// Ref Key: FK_PatientCommonMedRecord_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_PatientTransaction_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_PtAdmission_reDiagnosis
/// <summary>
/// <summary>
/// Ref Key: FK_PtAdmission_refAdmissionType
/// <summary>
/// <summary>
/// Ref Key: FK_PtAdmission_refAdmReferralType
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
    public class KeyedPatientAdmission : KeyedCollection<KeyValuePair<string, long>, PatientAdmission>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientAdmission() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientAdmission item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AdmID) { return new KeyValuePair<string, long>("AdmID", k_AdmID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientAdmission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientAdmission item)
        {
            PatientAdmission orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientAdmission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientAdmission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientAdmission GetObjectByKey(long k_AdmID) 
		{
            if (this.Contains(GetKey(k_AdmID)) == false) return null;
            PatientAdmission ob = this[GetKey(k_AdmID)];
            return (PatientAdmission)ob;
        }

		public PatientAdmission GetObjectByKey(long k_AdmID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AdmID)) == false) {
				PatientAdmission ob = repository.GetQuery<PatientAdmission>().FirstOrDefault(o => o.AdmID == k_AdmID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientAdmission obj = this[GetKey(k_AdmID)];
            return (PatientAdmission)obj;
        }

		public PatientAdmission GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientAdmission ob = this[keypair];
            return (PatientAdmission)ob;
        }

        public PatientAdmission GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientAdmission ob = this[GetKey(keypair)];
            return (PatientAdmission)ob;
        }

		bool _LoadAll = false;
        public List<PatientAdmission> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientAdmission>().ToList();
			foreach (PatientAdmission item in list) {
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

        ~KeyedPatientAdmission()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
