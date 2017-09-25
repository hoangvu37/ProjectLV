/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Patient.cs         
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
	public partial class Patient : BaseEntity, ICloneable	{
		public Patient()
		{
			this.PtId = 0;
            this.PtUniversalHealthNum = null;
            this.PtNotes = null;
			this.OccupationCode = 0;
            this.FContactFullName = null;
            this.FAMMbrRelationshipCode = null;
            this.FContactAddress = null;
            this.FContactHomePhone = null;
            this.FContactBusinessPhone = null;
            this.FContactCellPhone = null;
            this.FAlternateContact = null;
            this.FAlternatePhone = null;
            this.BloodTypeID = null;
            this.IsDeleted = false;
            this.CreatedDate = DateTime.Now;
            this.CreatedBy = null;
            this.LastUpdDate = DateTime.Now;
            this.LastUpdBy = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtId", PtId); } }


		private long _PtId;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtId { get { return _PtId; } set {_PtId = value; } }

		private string _PtCode;
		[LVRequired]
        [LVMaxLength(25)]
        public string PtCode { get { return _PtCode; } set {_PtCode = value; } }

		private string _PtBarCode;
        [LVMaxLength(20)]
        public string PtBarCode { get { return _PtBarCode; } set {_PtBarCode = value; } }

		private string _PtQRcode;
		[LVRequired]
        [LVMaxLength(20)]
        public string PtQRcode { get { return _PtQRcode; } set {_PtQRcode = value; } }

		private string _PtUniversalHealthNum;
        [LVMaxLength(32)]
        public string PtUniversalHealthNum { get { return _PtUniversalHealthNum; } set {_PtUniversalHealthNum = value; } }

		private DateTime _DateBecamePt;
		[LVRequired]
        public DateTime DateBecamePt { get { return _DateBecamePt; } set {_DateBecamePt = value; } }

		private string _PtNotes;
        [LVMaxLength(1024)]
        public string PtNotes { get { return _PtNotes; } set {_PtNotes = value; } }

		private long _OccupationCode;
		[LVRequired]
        public long OccupationCode { get { return _OccupationCode; } set {_OccupationCode = value; } }

		private string _FContactFullName;
        [LVMaxLength(35)]
        public string FContactFullName { get { return _FContactFullName; } set {_FContactFullName = value; } }

		private string _FAMMbrRelationshipCode;
        [LVMaxLength(10)]
        public string FAMMbrRelationshipCode { get { return _FAMMbrRelationshipCode; } set {_FAMMbrRelationshipCode = value; } }

		private string _FContactAddress;
        [LVMaxLength(125)]
        public string FContactAddress { get { return _FContactAddress; } set {_FContactAddress = value; } }

		private string _FContactHomePhone;
        [LVMaxLength(15)]
        public string FContactHomePhone { get { return _FContactHomePhone; } set {_FContactHomePhone = value; } }

		private string _FContactBusinessPhone;
        [LVMaxLength(15)]
        public string FContactBusinessPhone { get { return _FContactBusinessPhone; } set {_FContactBusinessPhone = value; } }

		private string _FContactCellPhone;
        [LVMaxLength(15)]
        public string FContactCellPhone { get { return _FContactCellPhone; } set {_FContactCellPhone = value; } }

		private string _FAlternateContact;
        [LVMaxLength(35)]
        public string FAlternateContact { get { return _FAlternateContact; } set {_FAlternateContact = value; } }

		private string _FAlternatePhone;
        [LVMaxLength(15)]
        public string FAlternatePhone { get { return _FAlternatePhone; } set {_FAlternatePhone = value; } }

		private long? _BloodTypeID;
        public long? BloodTypeID { get { return _BloodTypeID; } set {_BloodTypeID = value; } }

		private DateTime _PtEarliestEntryDtm;
		[LVRequired]
        public DateTime PtEarliestEntryDtm { get { return _PtEarliestEntryDtm; } set {_PtEarliestEntryDtm = value; } }

		private DateTime _PtLatestEntryDtm;
		[LVRequired]
        public DateTime PtLatestEntryDtm { get { return _PtLatestEntryDtm; } set {_PtLatestEntryDtm = value; } }

		private bool _IsDeleted;
        public bool IsDeleted { get { return _IsDeleted; } set {_IsDeleted = value; } }

		private DateTime _CreatedDate;
		[LVRequired]
        public DateTime CreatedDate { get { return _CreatedDate; } set {_CreatedDate = value; } }

		private string _CreatedBy;
        [LVMaxLength(20)]
        public string CreatedBy { get { return _CreatedBy; } set {_CreatedBy = value; } }

		private DateTime? _LastUpdDate;
        public DateTime? LastUpdDate { get { return _LastUpdDate; } set {_LastUpdDate = value; } }

		private string _LastUpdBy;
        [LVMaxLength(20)]
        public string LastUpdBy { get { return _LastUpdBy; } set {_LastUpdBy = value; } }

		/// <summary>
/// Ref Key: FK_NetworkGuestAccount_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_Patient_Person
/// <summary>
/// <summary>
/// Ref Key: FK_Patient_refBloodType
/// <summary>
/// <summary>
/// Ref Key: FK_Patient_refCareerMOH
/// <summary>
/// <summary>
/// Ref Key: FK_PatientAddressHistory_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientAddressHistory_Patient_02
/// <summary>
/// <summary>
/// Ref Key: FK_PatientAdmission_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientClassHistory_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientPVID_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRadiology_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientSpecimen_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientTransaction_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PtMedRecord_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_RegistrationInfo_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_WorkPlace_Patient
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
    public class KeyedPatient : KeyedCollection<KeyValuePair<string, long>, Patient>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatient() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Patient item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtId) { return new KeyValuePair<string, long>("PtId", k_PtId); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Patient item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Patient item)
        {
            Patient orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Patient item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Patient item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Patient GetObjectByKey(long k_PtId) 
		{
            if (this.Contains(GetKey(k_PtId)) == false) return null;
            Patient ob = this[GetKey(k_PtId)];
            return (Patient)ob;
        }

		public Patient GetObjectByKey(long k_PtId, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtId)) == false) {
				Patient ob = repository.GetQuery<Patient>().FirstOrDefault(o => o.PtId == k_PtId);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Patient obj = this[GetKey(k_PtId)];
            return (Patient)obj;
        }

		public Patient GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Patient ob = this[keypair];
            return (Patient)ob;
        }

        public Patient GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Patient ob = this[GetKey(keypair)];
            return (Patient)ob;
        }

		bool _LoadAll = false;
        public List<Patient> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Patient>().ToList();
			foreach (Patient item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<Patient> LoadIXFK_Patient_refCareerMOH(long p_OccupationCode, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<Patient>().Where(o=> o.OccupationCode == p_OccupationCode).ToList();
			foreach (Patient item in list) {
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

        ~KeyedPatient()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
