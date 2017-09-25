/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrPrescriptionTmps.cs         
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
	public partial class DrPrescriptionTmps : BaseEntity, ICloneable	{
		public DrPrescriptionTmps()
		{
			this.DrRxTmpID = 0;
			this.DrRxTmpsID = 0;
			this.MedcnID = 0;
            this.AcPrincipleName = null;
            this.MedcnDoseQty = 0;
			this.MedcnDoseUnitCode = 0;
			this.MedcnAdminFreqCode = 0;
			this.MedcnAdminFreqPerDay = 0;
            this.MedcnDispenseQty = 0;
            this.MedcnUsingDuration = null;
			this.MedcnAdminRouteCode = 0;
			this.MedcnInstructionCode = 0;
            this.MedcnNotesText = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrRxTmpsID", DrRxTmpsID); } }


		private long? _DrRxTmpID;
        public long? DrRxTmpID { get { return _DrRxTmpID; } set {_DrRxTmpID = value; } }

		private long _DrRxTmpsID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrRxTmpsID { get { return _DrRxTmpsID; } set {_DrRxTmpsID = value; } }

		private long? _MedcnID;
        public long? MedcnID { get { return _MedcnID; } set {_MedcnID = value; } }

		private string _MedcnName;
        [LVMaxLength(256)]
        public string MedcnName { get { return _MedcnName; } set {_MedcnName = value; } }

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

		private double? _MedcnDispenseQty;
        public double? MedcnDispenseQty { get { return _MedcnDispenseQty; } set {_MedcnDispenseQty = value; } }

		private byte? _MedcnUsingDuration;
        public byte? MedcnUsingDuration { get { return _MedcnUsingDuration; } set {_MedcnUsingDuration = value; } }

		private short? _MedcnAdminRouteCode;
        public short? MedcnAdminRouteCode { get { return _MedcnAdminRouteCode; } set {_MedcnAdminRouteCode = value; } }

		private short? _MedcnInstructionCode;
        public short? MedcnInstructionCode { get { return _MedcnInstructionCode; } set {_MedcnInstructionCode = value; } }

		private string _MedcnNotesText;
        [LVMaxLength(256)]
        public string MedcnNotesText { get { return _MedcnNotesText; } set {_MedcnNotesText = value; } }

		/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_DrPrescriptionTmp
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_02
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_03
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_04
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_refCommonTerm_05
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
    public class KeyedDrPrescriptionTmps : KeyedCollection<KeyValuePair<string, long>, DrPrescriptionTmps>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrPrescriptionTmps() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrPrescriptionTmps item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrRxTmpsID) { return new KeyValuePair<string, long>("DrRxTmpsID", k_DrRxTmpsID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrPrescriptionTmps item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrPrescriptionTmps item)
        {
            DrPrescriptionTmps orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrPrescriptionTmps item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrPrescriptionTmps item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrPrescriptionTmps GetObjectByKey(long k_DrRxTmpsID) 
		{
            if (this.Contains(GetKey(k_DrRxTmpsID)) == false) return null;
            DrPrescriptionTmps ob = this[GetKey(k_DrRxTmpsID)];
            return (DrPrescriptionTmps)ob;
        }

		public DrPrescriptionTmps GetObjectByKey(long k_DrRxTmpsID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrRxTmpsID)) == false) {
				DrPrescriptionTmps ob = repository.GetQuery<DrPrescriptionTmps>().FirstOrDefault(o => o.DrRxTmpsID == k_DrRxTmpsID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrPrescriptionTmps obj = this[GetKey(k_DrRxTmpsID)];
            return (DrPrescriptionTmps)obj;
        }

		public DrPrescriptionTmps GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrPrescriptionTmps ob = this[keypair];
            return (DrPrescriptionTmps)ob;
        }

        public DrPrescriptionTmps GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrPrescriptionTmps ob = this[GetKey(keypair)];
            return (DrPrescriptionTmps)ob;
        }

		bool _LoadAll = false;
        public List<DrPrescriptionTmps> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrPrescriptionTmps>().ToList();
			foreach (DrPrescriptionTmps item in list) {
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

        ~KeyedDrPrescriptionTmps()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
