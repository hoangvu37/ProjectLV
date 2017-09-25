/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientSpecimen.cs         
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
	public partial class PatientSpecimen : BaseEntity, ICloneable	{
		public PatientSpecimen()
		{
			this.SpecTypeID = 0;
			this.PtSpecID = 0;
            this.PackageNum = null;
			this.PtID = 0;
            this.DXProcSpecReceiptDtm = DateTime.Now;
            this.DXProcSpecTotVolQty = 1;
			this.EstEmpID = 0;
            this.Notes = null;
            this.NationalPatientCode = null;
            this.RoomID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtSpecID", PtSpecID); } }


		private long _SpecTypeID;
		[LVRequired]
        public long SpecTypeID { get { return _SpecTypeID; } set {_SpecTypeID = value; } }

		private long _PtSpecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtSpecID { get { return _PtSpecID; } set {_PtSpecID = value; } }

		private string _SpecBarCode;
		[LVRequired]
        [LVMaxLength(20)]
        public string SpecBarCode { get { return _SpecBarCode; } set {_SpecBarCode = value; } }

		private string _PackageNum;
        [LVMaxLength(12)]
        public string PackageNum { get { return _PackageNum; } set {_PackageNum = value; } }

		private long _PtID;
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private string _DXProcSpecimenId;
		[LVRequired]
        [LVMaxLength(64)]
        public string DXProcSpecimenId { get { return _DXProcSpecimenId; } set {_DXProcSpecimenId = value; } }

		private DateTime _DXProcSpecReceiptDtm;
		[LVRequired]
        public DateTime DXProcSpecReceiptDtm { get { return _DXProcSpecReceiptDtm; } set {_DXProcSpecReceiptDtm = value; } }

		private byte? _DXProcSpecTotVolQty;
        public byte? DXProcSpecTotVolQty { get { return _DXProcSpecTotVolQty; } set {_DXProcSpecTotVolQty = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private string _DXProcSpecCollectorName;
        [LVMaxLength(100)]
        public string DXProcSpecCollectorName { get { return _DXProcSpecCollectorName; } set {_DXProcSpecCollectorName = value; } }

		private string _Notes;
        [LVMaxLength(512)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private string _NationalPatientCode;
        [LVMaxLength(14)]
        public string NationalPatientCode { get { return _NationalPatientCode; } set {_NationalPatientCode = value; } }

		private string _MedReportBookCode;
        [LVMaxLength(14)]
        public string MedReportBookCode { get { return _MedReportBookCode; } set {_MedReportBookCode = value; } }

		private long? _RoomID;
        public long? RoomID { get { return _RoomID; } set {_RoomID = value; } }

		/// <summary>
/// Ref Key: FK_PatientSpecimen_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientSpecimen_refSpecimenType
/// <summary>
/// <summary>
/// Ref Key: FK_PatientSpecimen_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_PatientSpecimen
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
    public class KeyedPatientSpecimen : KeyedCollection<KeyValuePair<string, long>, PatientSpecimen>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientSpecimen() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientSpecimen item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtSpecID) { return new KeyValuePair<string, long>("PtSpecID", k_PtSpecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientSpecimen item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientSpecimen item)
        {
            PatientSpecimen orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientSpecimen item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientSpecimen item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientSpecimen GetObjectByKey(long k_PtSpecID) 
		{
            if (this.Contains(GetKey(k_PtSpecID)) == false) return null;
            PatientSpecimen ob = this[GetKey(k_PtSpecID)];
            return (PatientSpecimen)ob;
        }

		public PatientSpecimen GetObjectByKey(long k_PtSpecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtSpecID)) == false) {
				PatientSpecimen ob = repository.GetQuery<PatientSpecimen>().FirstOrDefault(o => o.PtSpecID == k_PtSpecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientSpecimen obj = this[GetKey(k_PtSpecID)];
            return (PatientSpecimen)obj;
        }

		public PatientSpecimen GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientSpecimen ob = this[keypair];
            return (PatientSpecimen)ob;
        }

        public PatientSpecimen GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientSpecimen ob = this[GetKey(keypair)];
            return (PatientSpecimen)ob;
        }

		bool _LoadAll = false;
        public List<PatientSpecimen> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientSpecimen>().ToList();
			foreach (PatientSpecimen item in list) {
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

        ~KeyedPatientSpecimen()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
