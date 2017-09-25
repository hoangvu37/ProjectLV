/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PrescriptionDetail.cs         
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
	public partial class PrescriptionDetail : BaseEntity, ICloneable	{
		public PrescriptionDetail()
		{
			this.RxsID = 0;
			this.RxID = 0;
			this.MedcnID = 0;
            this.AcPrincipleName = null;
            this.MedcnDoseQty = 0;
			this.MedcnDoseUnitCode = 0;
			this.MedcnAdminFreqCode = 0;
            this.MedcnAdminFreqPerDay = null;
            this.MedcnDispenseQty = 0;
            this.MedcnUsingDuration = null;
			this.MedcnAdminRouteCode = 0;
			this.MedcnInstructionCode = 0;
			this.PtClassID = 0;
            this.BelongingToHI = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RxsID", RxsID); } }


		private long _RxsID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RxsID { get { return _RxsID; } set {_RxsID = value; } }

		private long _RxID;
		[LVRequired]
        public long RxID { get { return _RxID; } set {_RxID = value; } }

		private long? _MedcnID;
        public long? MedcnID { get { return _MedcnID; } set {_MedcnID = value; } }

		private string _MedcnNameText;
		[LVRequired]
        [LVMaxLength(256)]
        public string MedcnNameText { get { return _MedcnNameText; } set {_MedcnNameText = value; } }

		private string _AcPrincipleName;
        [LVMaxLength(128)]
        public string AcPrincipleName { get { return _AcPrincipleName; } set {_AcPrincipleName = value; } }

		private double? _MedcnDoseQty;
        public double? MedcnDoseQty { get { return _MedcnDoseQty; } set {_MedcnDoseQty = value; } }

		private short? _MedcnDoseUnitCode;
        public short? MedcnDoseUnitCode { get { return _MedcnDoseUnitCode; } set {_MedcnDoseUnitCode = value; } }

		private short? _MedcnAdminFreqCode;
        public short? MedcnAdminFreqCode { get { return _MedcnAdminFreqCode; } set {_MedcnAdminFreqCode = value; } }

		private short? _MedcnAdminFreqPerDay;
        public short? MedcnAdminFreqPerDay { get { return _MedcnAdminFreqPerDay; } set {_MedcnAdminFreqPerDay = value; } }

		private double _MedcnDispenseQty;
		[LVRequired]
        public double MedcnDispenseQty { get { return _MedcnDispenseQty; } set {_MedcnDispenseQty = value; } }

		private byte? _MedcnUsingDuration;
        public byte? MedcnUsingDuration { get { return _MedcnUsingDuration; } set {_MedcnUsingDuration = value; } }

		private short? _MedcnAdminRouteCode;
        public short? MedcnAdminRouteCode { get { return _MedcnAdminRouteCode; } set {_MedcnAdminRouteCode = value; } }

		private short? _MedcnInstructionCode;
        public short? MedcnInstructionCode { get { return _MedcnInstructionCode; } set {_MedcnInstructionCode = value; } }

		private string _MedcnNoteText;
        [LVMaxLength(256)]
        public string MedcnNoteText { get { return _MedcnNoteText; } set {_MedcnNoteText = value; } }

		private long? _PtClassID;
        public long? PtClassID { get { return _PtClassID; } set {_PtClassID = value; } }

		private bool? _BelongingToHI;
        public bool? BelongingToHI { get { return _BelongingToHI; } set {_BelongingToHI = value; } }

		/// <summary>
/// Ref Key: FK_PrescriptionDetail_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_Prescription
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_02
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_03
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_04
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_refCommonTerm_05
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
    public class KeyedPrescriptionDetail : KeyedCollection<KeyValuePair<string, long>, PrescriptionDetail>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPrescriptionDetail() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PrescriptionDetail item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RxsID) { return new KeyValuePair<string, long>("RxsID", k_RxsID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PrescriptionDetail item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PrescriptionDetail item)
        {
            PrescriptionDetail orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PrescriptionDetail item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PrescriptionDetail item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PrescriptionDetail GetObjectByKey(long k_RxsID) 
		{
            if (this.Contains(GetKey(k_RxsID)) == false) return null;
            PrescriptionDetail ob = this[GetKey(k_RxsID)];
            return (PrescriptionDetail)ob;
        }

		public PrescriptionDetail GetObjectByKey(long k_RxsID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RxsID)) == false) {
				PrescriptionDetail ob = repository.GetQuery<PrescriptionDetail>().FirstOrDefault(o => o.RxsID == k_RxsID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PrescriptionDetail obj = this[GetKey(k_RxsID)];
            return (PrescriptionDetail)obj;
        }

		public PrescriptionDetail GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PrescriptionDetail ob = this[keypair];
            return (PrescriptionDetail)ob;
        }

        public PrescriptionDetail GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PrescriptionDetail ob = this[GetKey(keypair)];
            return (PrescriptionDetail)ob;
        }

		bool _LoadAll = false;
        public List<PrescriptionDetail> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PrescriptionDetail>().ToList();
			foreach (PrescriptionDetail item in list) {
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

        ~KeyedPrescriptionDetail()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
