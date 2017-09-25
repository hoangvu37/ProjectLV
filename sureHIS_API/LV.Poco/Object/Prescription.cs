/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Prescription.cs         
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
	public partial class Prescription : BaseEntity, ICloneable	{
		public Prescription()
		{
			this.RxID = 0;
			this.ICD10 = 0;
            this.DiagDesc = null;
			this.MedEncnID = 0;
			this.MedEnctrDiagID = 0;
            this.ReExamDate = DateTime.Now;
            this.ApptID = null;
            this.NeedHoldCnsl = true;
            this.V_RxIssueType = null;
			this.V_RxStatus = 0;
            this.V_RxCatg = null;
            this.CureNum = null;
            this.IsStabilityStatus = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RxID", RxID); } }


		private long _RxID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RxID { get { return _RxID; } set {_RxID = value; } }

		private string _RxCode;
        [LVMaxLength(20)]
        public string RxCode { get { return _RxCode; } set {_RxCode = value; } }

		private long _ICD10;
		[LVRequired]
        public long ICD10 { get { return _ICD10; } set {_ICD10 = value; } }

		private string _DiagDesc;
        [LVMaxLength(128)]
        public string DiagDesc { get { return _DiagDesc; } set {_DiagDesc = value; } }

		private long? _MedEncnID;
        public long? MedEncnID { get { return _MedEncnID; } set {_MedEncnID = value; } }

		private long? _MedEnctrDiagID;
        public long? MedEnctrDiagID { get { return _MedEnctrDiagID; } set {_MedEnctrDiagID = value; } }

		private DateTime? _MedcnStartDtm;
        public DateTime? MedcnStartDtm { get { return _MedcnStartDtm; } set {_MedcnStartDtm = value; } }

		private DateTime? _MedcnStopDtm;
        public DateTime? MedcnStopDtm { get { return _MedcnStopDtm; } set {_MedcnStopDtm = value; } }

		private string _DrAdvice;
        [LVMaxLength(256)]
        public string DrAdvice { get { return _DrAdvice; } set {_DrAdvice = value; } }

		private DateTime? _ReExamDate;
        public DateTime? ReExamDate { get { return _ReExamDate; } set {_ReExamDate = value; } }

		private long? _ApptID;
        public long? ApptID { get { return _ApptID; } set {_ApptID = value; } }

		private bool? _NeedHoldCnsl;
        public bool? NeedHoldCnsl { get { return _NeedHoldCnsl; } set {_NeedHoldCnsl = value; } }

		private string _V_PmtMethod;
        [LVMaxLength(50)]
        public string V_PmtMethod { get { return _V_PmtMethod; } set {_V_PmtMethod = value; } }

		private string _V_PmtStatus;
        [LVMaxLength(50)]
        public string V_PmtStatus { get { return _V_PmtStatus; } set {_V_PmtStatus = value; } }

		private string _ApprovedInsurID;
        [LVMaxLength(20)]
        public string ApprovedInsurID { get { return _ApprovedInsurID; } set {_ApprovedInsurID = value; } }

		private long? _V_RxIssueType;
        public long? V_RxIssueType { get { return _V_RxIssueType; } set {_V_RxIssueType = value; } }

		private long? _V_RxStatus;
        public long? V_RxStatus { get { return _V_RxStatus; } set {_V_RxStatus = value; } }

		private long? _V_RxCatg;
        public long? V_RxCatg { get { return _V_RxCatg; } set {_V_RxCatg = value; } }

		private byte? _CureNum;
        public byte? CureNum { get { return _CureNum; } set {_CureNum = value; } }

		private bool? _IsStabilityStatus;
        public bool? IsStabilityStatus { get { return _IsStabilityStatus; } set {_IsStabilityStatus = value; } }

		/// <summary>
/// Ref Key: FK_Prescription_Appointment
/// <summary>
/// <summary>
/// Ref Key: FK_Prescription_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalBill_Prescription
/// <summary>
/// <summary>
/// Ref Key: FK_Prescription_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_Prescription
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionHistory_Prescription
/// <summary>
/// <summary>
/// Ref Key: FK_RxHoldConsultation_Prescription
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
    public class KeyedPrescription : KeyedCollection<KeyValuePair<string, long>, Prescription>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPrescription() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Prescription item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RxID) { return new KeyValuePair<string, long>("RxID", k_RxID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Prescription item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Prescription item)
        {
            Prescription orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Prescription item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Prescription item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Prescription GetObjectByKey(long k_RxID) 
		{
            if (this.Contains(GetKey(k_RxID)) == false) return null;
            Prescription ob = this[GetKey(k_RxID)];
            return (Prescription)ob;
        }

		public Prescription GetObjectByKey(long k_RxID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RxID)) == false) {
				Prescription ob = repository.GetQuery<Prescription>().FirstOrDefault(o => o.RxID == k_RxID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Prescription obj = this[GetKey(k_RxID)];
            return (Prescription)obj;
        }

		public Prescription GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Prescription ob = this[keypair];
            return (Prescription)ob;
        }

        public Prescription GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Prescription ob = this[GetKey(keypair)];
            return (Prescription)ob;
        }

		bool _LoadAll = false;
        public List<Prescription> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Prescription>().ToList();
			foreach (Prescription item in list) {
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

        ~KeyedPrescription()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
