/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientDiagnosticImaging.cs         
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
	public partial class PatientDiagnosticImaging : BaseEntity, ICloneable	{
		public PatientDiagnosticImaging()
		{
			this.PtDiagImgID = 0;
			this.PtID = 0;
			this.ClinReqID = 0;
			this.EstEmpID = 0;
            this.DiagPlace = null;
			this.V_pClinSceneCtg = 0;
			this.ClinicalDoctorID = 0;
            this.DiagTechniques = null;
            this.DxDTmpID = null;
			this.MedImgTestID = 0;
            this.V_DiagStatus = null;
			this.EquipMDSrcrID = 0;
            this.PublishedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtDiagImgID", PtDiagImgID); } }


		private long _PtDiagImgID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtDiagImgID { get { return _PtDiagImgID; } set {_PtDiagImgID = value; } }

		private long? _PtID;
        public long? PtID { get { return _PtID; } set {_PtID = value; } }

		private long? _ClinReqID;
        public long? ClinReqID { get { return _ClinReqID; } set {_ClinReqID = value; } }

		private string _SID;
		[LVRequired]
        [LVMaxLength(20)]
        public string SID { get { return _SID; } set {_SID = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private DateTime? _TestDtm;
        public DateTime? TestDtm { get { return _TestDtm; } set {_TestDtm = value; } }

		private string _DiagPlace;
        [LVMaxLength(64)]
        public string DiagPlace { get { return _DiagPlace; } set {_DiagPlace = value; } }

		private long? _V_pClinSceneCtg;
        public long? V_pClinSceneCtg { get { return _V_pClinSceneCtg; } set {_V_pClinSceneCtg = value; } }

		private long? _ClinicalDoctorID;
        public long? ClinicalDoctorID { get { return _ClinicalDoctorID; } set {_ClinicalDoctorID = value; } }

		private string _DiagTechniques;
        [LVMaxLength(1024)]
        public string DiagTechniques { get { return _DiagTechniques; } set {_DiagTechniques = value; } }

		private long? _DxDTmpID;
        public long? DxDTmpID { get { return _DxDTmpID; } set {_DxDTmpID = value; } }

		private string _DiagDesc;
        [LVMaxLength(2048)]
        public string DiagDesc { get { return _DiagDesc; } set {_DiagDesc = value; } }

		private string _DiagConclusion;
        [LVMaxLength(2048)]
        public string DiagConclusion { get { return _DiagConclusion; } set {_DiagConclusion = value; } }

		private string _SuggestedTx;
        [LVMaxLength(2048)]
        public string SuggestedTx { get { return _SuggestedTx; } set {_SuggestedTx = value; } }

		private string _Notes;
        [LVMaxLength(1024)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private long? _MedImgTestID;
        public long? MedImgTestID { get { return _MedImgTestID; } set {_MedImgTestID = value; } }

		private long? _V_DiagStatus;
        public long? V_DiagStatus { get { return _V_DiagStatus; } set {_V_DiagStatus = value; } }

		private long _EquipMDSrcrID;
		[LVRequired]
        public long EquipMDSrcrID { get { return _EquipMDSrcrID; } set {_EquipMDSrcrID = value; } }

		private DateTime? _PublishedDate;
        public DateTime? PublishedDate { get { return _PublishedDate; } set {_PublishedDate = value; } }

		/// <summary>
/// Ref Key: FK_PatientDiagnosticImaging_DiagDescribeTmp
/// <summary>
/// <summary>
/// Ref Key: FK_PatientDiagnosticImaging_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingRepository_PatientDiagnosticImaging
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRadiology_MedImagingTest
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRadiology_ParaClinicalReq
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRadiology_Patient
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
    public class KeyedPatientDiagnosticImaging : KeyedCollection<KeyValuePair<string, long>, PatientDiagnosticImaging>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientDiagnosticImaging() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientDiagnosticImaging item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtDiagImgID) { return new KeyValuePair<string, long>("PtDiagImgID", k_PtDiagImgID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientDiagnosticImaging item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientDiagnosticImaging item)
        {
            PatientDiagnosticImaging orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientDiagnosticImaging item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientDiagnosticImaging item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientDiagnosticImaging GetObjectByKey(long k_PtDiagImgID) 
		{
            if (this.Contains(GetKey(k_PtDiagImgID)) == false) return null;
            PatientDiagnosticImaging ob = this[GetKey(k_PtDiagImgID)];
            return (PatientDiagnosticImaging)ob;
        }

		public PatientDiagnosticImaging GetObjectByKey(long k_PtDiagImgID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtDiagImgID)) == false) {
				PatientDiagnosticImaging ob = repository.GetQuery<PatientDiagnosticImaging>().FirstOrDefault(o => o.PtDiagImgID == k_PtDiagImgID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientDiagnosticImaging obj = this[GetKey(k_PtDiagImgID)];
            return (PatientDiagnosticImaging)obj;
        }

		public PatientDiagnosticImaging GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientDiagnosticImaging ob = this[keypair];
            return (PatientDiagnosticImaging)ob;
        }

        public PatientDiagnosticImaging GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientDiagnosticImaging ob = this[GetKey(keypair)];
            return (PatientDiagnosticImaging)ob;
        }

		bool _LoadAll = false;
        public List<PatientDiagnosticImaging> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientDiagnosticImaging>().ToList();
			foreach (PatientDiagnosticImaging item in list) {
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

        ~KeyedPatientDiagnosticImaging()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
