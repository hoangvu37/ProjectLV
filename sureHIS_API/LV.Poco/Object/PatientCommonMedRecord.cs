/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientCommonMedRecord.cs         
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
	public partial class PatientCommonMedRecord : BaseEntity, ICloneable	{
		public PatientCommonMedRecord()
		{
			this.PtRecID = 0;
			this.PtComMedRecID = 0;
			this.AdmID = 0;
            this.ModifiedDate = DateTime.Now;
			this.EsNurseID = 0;
			this.V_ProcessingType = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtComMedRecID", PtComMedRecID); } }


		private long _PtRecID;
		[LVRequired]
        public long PtRecID { get { return _PtRecID; } set {_PtRecID = value; } }

		private long _PtComMedRecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long? _AdmID;
        public long? AdmID { get { return _AdmID; } set {_AdmID = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long _EsNurseID;
		[LVRequired]
        public long EsNurseID { get { return _EsNurseID; } set {_EsNurseID = value; } }

		private long _V_ProcessingType;
		[LVRequired]
        public long V_ProcessingType { get { return _V_ProcessingType; } set {_V_ProcessingType = value; } }

		/// <summary>
/// Ref Key: FK_Allergy_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_FamilyHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalizationHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_ImmunizationHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalConditionRecord_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_MedicationHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_MiscDocuments_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_PastPersonHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_PatientCommonMedRecord_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_PatientCommonMedRecord_PatientMedRecords
/// <summary>
/// <summary>
/// Ref Key: FK_PatientVitalSign_PatientCommonMedRecord
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
    public class KeyedPatientCommonMedRecord : KeyedCollection<KeyValuePair<string, long>, PatientCommonMedRecord>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientCommonMedRecord() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientCommonMedRecord item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtComMedRecID) { return new KeyValuePair<string, long>("PtComMedRecID", k_PtComMedRecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientCommonMedRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientCommonMedRecord item)
        {
            PatientCommonMedRecord orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientCommonMedRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientCommonMedRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientCommonMedRecord GetObjectByKey(long k_PtComMedRecID) 
		{
            if (this.Contains(GetKey(k_PtComMedRecID)) == false) return null;
            PatientCommonMedRecord ob = this[GetKey(k_PtComMedRecID)];
            return (PatientCommonMedRecord)ob;
        }

		public PatientCommonMedRecord GetObjectByKey(long k_PtComMedRecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtComMedRecID)) == false) {
				PatientCommonMedRecord ob = repository.GetQuery<PatientCommonMedRecord>().FirstOrDefault(o => o.PtComMedRecID == k_PtComMedRecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientCommonMedRecord obj = this[GetKey(k_PtComMedRecID)];
            return (PatientCommonMedRecord)obj;
        }

		public PatientCommonMedRecord GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientCommonMedRecord ob = this[keypair];
            return (PatientCommonMedRecord)ob;
        }

        public PatientCommonMedRecord GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientCommonMedRecord ob = this[GetKey(keypair)];
            return (PatientCommonMedRecord)ob;
        }

		bool _LoadAll = false;
        public List<PatientCommonMedRecord> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientCommonMedRecord>().ToList();
			foreach (PatientCommonMedRecord item in list) {
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

        ~KeyedPatientCommonMedRecord()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
