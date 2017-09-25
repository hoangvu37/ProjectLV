/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientMedLabTestResult.cs         
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
	public partial class PatientMedLabTestResult : BaseEntity, ICloneable	{
		public PatientMedLabTestResult()
		{
			this.ReqdPtOnSpecID = 0;
			this.PtSpecTestID = 0;
			this.DClinReqID = 0;
			this.MedLabTestID = 0;
            this.Notes = null;
            this.URLParClinExamFileLocation = null;
            this.IsBackup = false;
			this.V_DiagStatus = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ReqdPtOnSpecID", ReqdPtOnSpecID); } }


		private long _ReqdPtOnSpecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ReqdPtOnSpecID { get { return _ReqdPtOnSpecID; } set {_ReqdPtOnSpecID = value; } }

		private long _PtSpecTestID;
		[LVRequired]
        public long PtSpecTestID { get { return _PtSpecTestID; } set {_PtSpecTestID = value; } }

		private long _DClinReqID;
		[LVRequired]
        public long DClinReqID { get { return _DClinReqID; } set {_DClinReqID = value; } }

		private long? _MedLabTestID;
        public long? MedLabTestID { get { return _MedLabTestID; } set {_MedLabTestID = value; } }

		private string _TestResult;
        [LVMaxLength(16)]
        public string TestResult { get { return _TestResult; } set {_TestResult = value; } }

		private string _DXProcNmeasAnalUnitCode;
        [LVMaxLength(16)]
        public string DXProcNmeasAnalUnitCode { get { return _DXProcNmeasAnalUnitCode; } set {_DXProcNmeasAnalUnitCode = value; } }

		private bool? _ResultEvaluation;
        public bool? ResultEvaluation { get { return _ResultEvaluation; } set {_ResultEvaluation = value; } }

		private string _Notes;
        [LVMaxLength(64)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private string _URLParClinExamFileLocation;
        [LVMaxLength(512)]
        public string URLParClinExamFileLocation { get { return _URLParClinExamFileLocation; } set {_URLParClinExamFileLocation = value; } }

		private bool? _IsBackup;
        public bool? IsBackup { get { return _IsBackup; } set {_IsBackup = value; } }

		private long _V_DiagStatus;
		[LVRequired]
        public long V_DiagStatus { get { return _V_DiagStatus; } set {_V_DiagStatus = value; } }

		/// <summary>
/// Ref Key: FK_PatientRequestOnSpecimen_MedLabTest
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRequestOnSpecimen_ParaClinicalReqDetails
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRequestOnSpecimen_PatientSpecimenTest
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
    public class KeyedPatientMedLabTestResult : KeyedCollection<KeyValuePair<string, long>, PatientMedLabTestResult>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientMedLabTestResult() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientMedLabTestResult item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ReqdPtOnSpecID) { return new KeyValuePair<string, long>("ReqdPtOnSpecID", k_ReqdPtOnSpecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientMedLabTestResult item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientMedLabTestResult item)
        {
            PatientMedLabTestResult orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientMedLabTestResult item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientMedLabTestResult item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientMedLabTestResult GetObjectByKey(long k_ReqdPtOnSpecID) 
		{
            if (this.Contains(GetKey(k_ReqdPtOnSpecID)) == false) return null;
            PatientMedLabTestResult ob = this[GetKey(k_ReqdPtOnSpecID)];
            return (PatientMedLabTestResult)ob;
        }

		public PatientMedLabTestResult GetObjectByKey(long k_ReqdPtOnSpecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ReqdPtOnSpecID)) == false) {
				PatientMedLabTestResult ob = repository.GetQuery<PatientMedLabTestResult>().FirstOrDefault(o => o.ReqdPtOnSpecID == k_ReqdPtOnSpecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientMedLabTestResult obj = this[GetKey(k_ReqdPtOnSpecID)];
            return (PatientMedLabTestResult)obj;
        }

		public PatientMedLabTestResult GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientMedLabTestResult ob = this[keypair];
            return (PatientMedLabTestResult)ob;
        }

        public PatientMedLabTestResult GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientMedLabTestResult ob = this[GetKey(keypair)];
            return (PatientMedLabTestResult)ob;
        }

		bool _LoadAll = false;
        public List<PatientMedLabTestResult> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientMedLabTestResult>().ToList();
			foreach (PatientMedLabTestResult item in list) {
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

        ~KeyedPatientMedLabTestResult()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
