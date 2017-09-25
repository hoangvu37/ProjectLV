/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalEncounter.cs         
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
	public partial class MedicalEncounter : BaseEntity, ICloneable	{
		public MedicalEncounter()
		{
			this.MedEncnID = 0;
			this.PatientRecID = 0;
			this.AdmID = 0;
			this.HosDeptID = 0;
			this.AttendingDoctorID = 0;
			this.NurseID = 0;
			this.PtClassHisID = 0;
			this.HCFEDispDisposCode = 0;
			this.V_ConsultStatus = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedEncnID", MedEncnID); } }


		private long _MedEncnID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedEncnID { get { return _MedEncnID; } set {_MedEncnID = value; } }

		private string _HCFEncEncounterCode;
        [LVMaxLength(20)]
        public string HCFEncEncounterCode { get { return _HCFEncEncounterCode; } set {_HCFEncEncounterCode = value; } }

		private long _PatientRecID;
		[LVRequired]
        public long PatientRecID { get { return _PatientRecID; } set {_PatientRecID = value; } }

		private long _AdmID;
		[LVRequired]
        public long AdmID { get { return _AdmID; } set {_AdmID = value; } }

		private long _HosDeptID;
		[LVRequired]
        public long HosDeptID { get { return _HosDeptID; } set {_HosDeptID = value; } }

		private string _HCFEncTreatPracName;
		[LVRequired]
        [LVMaxLength(254)]
        public string HCFEncTreatPracName { get { return _HCFEncTreatPracName; } set {_HCFEncTreatPracName = value; } }

		private long _AttendingDoctorID;
		[LVRequired]
        public long AttendingDoctorID { get { return _AttendingDoctorID; } set {_AttendingDoctorID = value; } }

		private long? _NurseID;
        public long? NurseID { get { return _NurseID; } set {_NurseID = value; } }

		private long _PtClassHisID;
		[LVRequired]
        public long PtClassHisID { get { return _PtClassHisID; } set {_PtClassHisID = value; } }

		private string _HCFEncEncounterTypeCode;
        [LVMaxLength(16)]
        public string HCFEncEncounterTypeCode { get { return _HCFEncEncounterTypeCode; } set {_HCFEncEncounterTypeCode = value; } }

		private string _PreDiagnosis;
        [LVMaxLength(128)]
        public string PreDiagnosis { get { return _PreDiagnosis; } set {_PreDiagnosis = value; } }

		private string _InitialICD;
        [LVMaxLength(254)]
        public string InitialICD { get { return _InitialICD; } set {_InitialICD = value; } }

		private string _HCFEDispDiagICDCode;
        [LVMaxLength(10)]
        public string HCFEDispDiagICDCode { get { return _HCFEDispDiagICDCode; } set {_HCFEDispDiagICDCode = value; } }

		private string _DescICD;
        [LVMaxLength(254)]
        public string DescICD { get { return _DescICD; } set {_DescICD = value; } }

		private string _ExtraICD;
        [LVMaxLength(254)]
        public string ExtraICD { get { return _ExtraICD; } set {_ExtraICD = value; } }

		private long? _HCFEDispDisposCode;
        public long? HCFEDispDisposCode { get { return _HCFEDispDisposCode; } set {_HCFEDispDisposCode = value; } }

		private DateTime _HCFEDispDispDtm;
		[LVRequired]
        public DateTime HCFEDispDispDtm { get { return _HCFEDispDispDtm; } set {_HCFEDispDispDtm = value; } }

		private string _HCFEDispPtInstructText;
        [LVMaxLength(254)]
        public string HCFEDispPtInstructText { get { return _HCFEDispPtInstructText; } set {_HCFEDispPtInstructText = value; } }

		private string _HCFEDispNoteText;
        [LVMaxLength(254)]
        public string HCFEDispNoteText { get { return _HCFEDispNoteText; } set {_HCFEDispNoteText = value; } }

		private string _TransToDepID;
        [LVMaxLength(20)]
        public string TransToDepID { get { return _TransToDepID; } set {_TransToDepID = value; } }

		private long _V_ConsultStatus;
		[LVRequired]
        public long V_ConsultStatus { get { return _V_ConsultStatus; } set {_V_ConsultStatus = value; } }

		/// <summary>
/// Ref Key: FK_DeathSituationInfo_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalEncounter_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_MedEnctrDiagnosis_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_Encounter_PatientRecords
/// <summary>
/// <summary>
/// Ref Key: FK_Encounter_refDispositionType
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalEncounter_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReq_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_PatientProblem_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_PatientVitalSign_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_PhysicalExamination_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_Prescription_MedicalEncounter
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
    public class KeyedMedicalEncounter : KeyedCollection<KeyValuePair<string, long>, MedicalEncounter>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalEncounter() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalEncounter item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedEncnID) { return new KeyValuePair<string, long>("MedEncnID", k_MedEncnID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalEncounter item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalEncounter item)
        {
            MedicalEncounter orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalEncounter item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalEncounter item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalEncounter GetObjectByKey(long k_MedEncnID) 
		{
            if (this.Contains(GetKey(k_MedEncnID)) == false) return null;
            MedicalEncounter ob = this[GetKey(k_MedEncnID)];
            return (MedicalEncounter)ob;
        }

		public MedicalEncounter GetObjectByKey(long k_MedEncnID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedEncnID)) == false) {
				MedicalEncounter ob = repository.GetQuery<MedicalEncounter>().FirstOrDefault(o => o.MedEncnID == k_MedEncnID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalEncounter obj = this[GetKey(k_MedEncnID)];
            return (MedicalEncounter)obj;
        }

		public MedicalEncounter GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalEncounter ob = this[keypair];
            return (MedicalEncounter)ob;
        }

        public MedicalEncounter GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalEncounter ob = this[GetKey(keypair)];
            return (MedicalEncounter)ob;
        }

		bool _LoadAll = false;
        public List<MedicalEncounter> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalEncounter>().ToList();
			foreach (MedicalEncounter item in list) {
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

        ~KeyedMedicalEncounter()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
