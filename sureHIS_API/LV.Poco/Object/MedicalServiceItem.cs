/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalServiceItem.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class MedicalServiceItem : BaseEntity, ICloneable	{
		public MedicalServiceItem()
		{
			this.MedSerID = 0;
			this.MedSerTypeID = 0;
            this.MedSerDesc = null;
            this.VATRate = null;
            this.ServiceMainTime = null;
            this.V_TimeUnit = null;
            this.PartnershipID = null;
            this.EstEmpID = null;
            this.IsPackage = false;
            this.UsePricePackage = false;
            this.V_MedSerCategory = null;
            this.Stop = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedSerID", MedSerID); } }


		private long _MedSerID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private long _MedSerTypeID;
		[LVRequired]
        public long MedSerTypeID { get { return _MedSerTypeID; } set {_MedSerTypeID = value; } }

		private string _MedSerCode;
		[LVRequired]
        [LVMaxLength(15)]
        public string MedSerCode { get { return _MedSerCode; } set {_MedSerCode = value; } }

		private string _MedSerName;
		[LVRequired]
        [LVMaxLength(128)]
        public string MedSerName { get { return _MedSerName; } set {_MedSerName = value; } }

		private string _MedSerDesc;
        [LVMaxLength(1024)]
        public string MedSerDesc { get { return _MedSerDesc; } set {_MedSerDesc = value; } }

		private string _MedSerUOM;
		[LVRequired]
        [LVMaxLength(10)]
        public string MedSerUOM { get { return _MedSerUOM; } set {_MedSerUOM = value; } }

		private double? _VATRate;
        public double? VATRate { get { return _VATRate; } set {_VATRate = value; } }

		private byte? _ServiceMainTime;
        public byte? ServiceMainTime { get { return _ServiceMainTime; } set {_ServiceMainTime = value; } }

		private long? _V_TimeUnit;
        public long? V_TimeUnit { get { return _V_TimeUnit; } set {_V_TimeUnit = value; } }

		private long? _PartnershipID;
        public long? PartnershipID { get { return _PartnershipID; } set {_PartnershipID = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private bool _IsPackage;
        public bool IsPackage { get { return _IsPackage; } set {_IsPackage = value; } }

		private bool _UsePricePackage;
        public bool UsePricePackage { get { return _UsePricePackage; } set {_UsePricePackage = value; } }

		private long? _V_MedSerCategory;
        public long? V_MedSerCategory { get { return _V_MedSerCategory; } set {_V_MedSerCategory = value; } }

		private bool _Stop;
        public bool Stop { get { return _Stop; } set {_Stop = value; } }

		/// <summary>
/// Ref Key: FK_Appointment_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_EquivMedService_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_HosFeeTransDetails_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MedClaimService_MedServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalServiceItems_refMedicalServiceTypes
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalServiceItems_ResearchPartnership
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingTestItems_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MedLabTestItems_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MOHServiceItems_MedicalServiceItem
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
    public class KeyedMedicalServiceItem : KeyedCollection<KeyValuePair<string, long>, MedicalServiceItem>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalServiceItem() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalServiceItem item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedSerID) { return new KeyValuePair<string, long>("MedSerID", k_MedSerID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalServiceItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalServiceItem item)
        {
            MedicalServiceItem orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalServiceItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalServiceItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalServiceItem GetObjectByKey(long k_MedSerID) 
		{
            if (this.Contains(GetKey(k_MedSerID)) == false) return null;
            MedicalServiceItem ob = this[GetKey(k_MedSerID)];
            return (MedicalServiceItem)ob;
        }

		public MedicalServiceItem GetObjectByKey(long k_MedSerID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedSerID)) == false) {
				MedicalServiceItem ob = repository.GetQuery<MedicalServiceItem>().FirstOrDefault(o => o.MedSerID == k_MedSerID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalServiceItem obj = this[GetKey(k_MedSerID)];
            return (MedicalServiceItem)obj;
        }

		public MedicalServiceItem GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalServiceItem ob = this[keypair];
            return (MedicalServiceItem)ob;
        }

        public MedicalServiceItem GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalServiceItem ob = this[GetKey(keypair)];
            return (MedicalServiceItem)ob;
        }

		bool _LoadAll = false;
        public List<MedicalServiceItem> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalServiceItem>().ToList();
			foreach (MedicalServiceItem item in list) {
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

        ~KeyedMedicalServiceItem()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
