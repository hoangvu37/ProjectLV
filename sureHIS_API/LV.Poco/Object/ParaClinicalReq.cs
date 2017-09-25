/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ParaClinicalReq.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class ParaClinicalReq : BaseEntity, ICloneable	{
		public ParaClinicalReq()
		{
			this.MedTestProcID = 0;
			this.ClinReqID = 0;
			this.AdmID = 0;
			this.RefDoctorID = 0;
            this.AppointedDate = DateTime.Now;
            this.NationalMedicalCode = null;
			this.MedEncnID = 0;
            this.PreDiagnosis = null;
            this.TechnicalReq = null;
            this.ParaClinExamForOPatient = true;
            this.IsExternalTest = false;
            this.IsReferral = true;
            this.Recipients = null;
            this.ReceiverID = null;
            this.ReceiverName = null;
            this.IsDiagnosticImaging = false;
			this.V_pClinStatus = 0;
			this.V_pClinCatg = 0;
			this.PreICD10Diag = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ClinReqID", ClinReqID); } }


		private long _MedTestProcID;
		[LVRequired]
        public long MedTestProcID { get { return _MedTestProcID; } set {_MedTestProcID = value; } }

		private long _ClinReqID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ClinReqID { get { return _ClinReqID; } set {_ClinReqID = value; } }

		private string _ClinReqCode;
		[LVRequired]
        [LVMaxLength(20)]
        public string ClinReqCode { get { return _ClinReqCode; } set {_ClinReqCode = value; } }

		private long _AdmID;
		[LVRequired]
        public long AdmID { get { return _AdmID; } set {_AdmID = value; } }

		private long _RefDoctorID;
		[LVRequired]
        public long RefDoctorID { get { return _RefDoctorID; } set {_RefDoctorID = value; } }

		private DateTime _AppointedDate;
		[LVRequired]
        public DateTime AppointedDate { get { return _AppointedDate; } set {_AppointedDate = value; } }

		private string _NationalMedicalCode;
        [LVMaxLength(14)]
        public string NationalMedicalCode { get { return _NationalMedicalCode; } set {_NationalMedicalCode = value; } }

		private long? _MedEncnID;
        public long? MedEncnID { get { return _MedEncnID; } set {_MedEncnID = value; } }

		private string _PreDiagnosis;
        [LVMaxLength(512)]
        public string PreDiagnosis { get { return _PreDiagnosis; } set {_PreDiagnosis = value; } }

		private string _TechnicalReq;
        [LVMaxLength(1024)]
        public string TechnicalReq { get { return _TechnicalReq; } set {_TechnicalReq = value; } }

		private bool? _ParaClinExamForOPatient;
        public bool? ParaClinExamForOPatient { get { return _ParaClinExamForOPatient; } set {_ParaClinExamForOPatient = value; } }

		private bool? _IsExternalTest;
        public bool? IsExternalTest { get { return _IsExternalTest; } set {_IsExternalTest = value; } }

		private bool? _IsReferral;
        public bool? IsReferral { get { return _IsReferral; } set {_IsReferral = value; } }

		private string _Recipients;
        [LVMaxLength(1024)]
        public string Recipients { get { return _Recipients; } set {_Recipients = value; } }

		private long? _ReceiverID;
        public long? ReceiverID { get { return _ReceiverID; } set {_ReceiverID = value; } }

		private string _ReceiverName;
        [LVMaxLength(64)]
        public string ReceiverName { get { return _ReceiverName; } set {_ReceiverName = value; } }

		private bool? _IsDiagnosticImaging;
        public bool? IsDiagnosticImaging { get { return _IsDiagnosticImaging; } set {_IsDiagnosticImaging = value; } }

		private bool? _HighPriority;
        public bool? HighPriority { get { return _HighPriority; } set {_HighPriority = value; } }

		private long _V_pClinStatus;
		[LVRequired]
        public long V_pClinStatus { get { return _V_pClinStatus; } set {_V_pClinStatus = value; } }

		private long _V_pClinCatg;
		[LVRequired]
        public long V_pClinCatg { get { return _V_pClinCatg; } set {_V_pClinCatg = value; } }

		private long? _PreICD10Diag;
        public long? PreICD10Diag { get { return _PreICD10Diag; } set {_PreICD10Diag = value; } }

		/// <summary>
/// Ref Key: FK_BodyRegion_ParaClinicalReq
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReq_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReq_MedicalTestProcedure
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReq_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReqDetails_ParaClinicalReq
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRadiology_ParaClinicalReq
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_ParaClinicalReq
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
    public class KeyedParaClinicalReq : KeyedCollection<KeyValuePair<string, long>, ParaClinicalReq>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedParaClinicalReq() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ParaClinicalReq item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ClinReqID) { return new KeyValuePair<string, long>("ClinReqID", k_ClinReqID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ParaClinicalReq item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ParaClinicalReq item)
        {
            ParaClinicalReq orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ParaClinicalReq item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ParaClinicalReq item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ParaClinicalReq GetObjectByKey(long k_ClinReqID) 
		{
            if (this.Contains(GetKey(k_ClinReqID)) == false) return null;
            ParaClinicalReq ob = this[GetKey(k_ClinReqID)];
            return (ParaClinicalReq)ob;
        }

		public ParaClinicalReq GetObjectByKey(long k_ClinReqID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ClinReqID)) == false) {
				ParaClinicalReq ob = repository.GetQuery<ParaClinicalReq>().FirstOrDefault(o => o.ClinReqID == k_ClinReqID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ParaClinicalReq obj = this[GetKey(k_ClinReqID)];
            return (ParaClinicalReq)obj;
        }

		public ParaClinicalReq GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ParaClinicalReq ob = this[keypair];
            return (ParaClinicalReq)ob;
        }

        public ParaClinicalReq GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ParaClinicalReq ob = this[GetKey(keypair)];
            return (ParaClinicalReq)ob;
        }

		bool _LoadAll = false;
        public List<ParaClinicalReq> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ParaClinicalReq>().ToList();
			foreach (ParaClinicalReq item in list) {
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

        ~KeyedParaClinicalReq()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
