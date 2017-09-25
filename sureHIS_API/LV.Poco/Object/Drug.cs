/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Drug.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class Drug : BaseEntity, ICloneable	{
		public Drug()
		{
			this.DrugID = 0;
			this.V_ItemGroup = 0;
			this.DrugKindID = 0;
            this.HIDrug = false;
			this.InvMearsure = 0;
			this.BuyMearsure = 0;
            this.BuyCnvFactor = 1;
			this.SellMearsure = 0;
            this.SellCnvFactor = 1;
            this.SafeStock = 0;
            this.MinStock = 0;
            this.MaxStock = 0;
            this.Stop = false;
            this.CreatedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrugID", DrugID); } }


		private long _DrugID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private string _DrugCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string DrugCode { get { return _DrugCode; } set {_DrugCode = value; } }

		private string _MedcnNameText;
		[LVRequired]
        [LVMaxLength(254)]
        public string MedcnNameText { get { return _MedcnNameText; } set {_MedcnNameText = value; } }

		private string _DrugFullName;
        [LVMaxLength(254)]
        public string DrugFullName { get { return _DrugFullName; } set {_DrugFullName = value; } }

		private string _DrugContent;
        [LVMaxLength(100)]
        public string DrugContent { get { return _DrugContent; } set {_DrugContent = value; } }

		private string _MedcnVehicleFormCode;
        [LVMaxLength(16)]
        public string MedcnVehicleFormCode { get { return _MedcnVehicleFormCode; } set {_MedcnVehicleFormCode = value; } }

		private string _MedcnAdminRouteCode;
        [LVMaxLength(16)]
        public string MedcnAdminRouteCode { get { return _MedcnAdminRouteCode; } set {_MedcnAdminRouteCode = value; } }

		private string _ProductCode;
        [LVMaxLength(50)]
        public string ProductCode { get { return _ProductCode; } set {_ProductCode = value; } }

		private long _V_ItemGroup;
		[LVRequired]
        public long V_ItemGroup { get { return _V_ItemGroup; } set {_V_ItemGroup = value; } }

		private long _DrugKindID;
		[LVRequired]
        public long DrugKindID { get { return _DrugKindID; } set {_DrugKindID = value; } }

		private bool _HIDrug;
        public bool HIDrug { get { return _HIDrug; } set {_HIDrug = value; } }

		private string _InsurKindID;
        [LVMaxLength(10)]
        public string InsurKindID { get { return _InsurKindID; } set {_InsurKindID = value; } }

		private string _InsurName;
        [LVMaxLength(254)]
        public string InsurName { get { return _InsurName; } set {_InsurName = value; } }

		private string _MedDrugID;
        [LVMaxLength(25)]
        public string MedDrugID { get { return _MedDrugID; } set {_MedDrugID = value; } }

		private string _MedNumber;
        [LVMaxLength(10)]
        public string MedNumber { get { return _MedNumber; } set {_MedNumber = value; } }

		private string _CountryID;
        [LVMaxLength(2)]
        public string CountryID { get { return _CountryID; } set {_CountryID = value; } }

		private string _ProducerID;
        [LVMaxLength(10)]
        public string ProducerID { get { return _ProducerID; } set {_ProducerID = value; } }

		private string _MedcnDoseUnitCode;
        [LVMaxLength(10)]
        public string MedcnDoseUnitCode { get { return _MedcnDoseUnitCode; } set {_MedcnDoseUnitCode = value; } }

		private long _InvMearsure;
		[LVRequired]
        public long InvMearsure { get { return _InvMearsure; } set {_InvMearsure = value; } }

		private long? _BuyMearsure;
        public long? BuyMearsure { get { return _BuyMearsure; } set {_BuyMearsure = value; } }

		private decimal _BuyCnvFactor;
		[LVRequired]
        public decimal BuyCnvFactor { get { return _BuyCnvFactor; } set {_BuyCnvFactor = value; } }

		private long? _SellMearsure;
        public long? SellMearsure { get { return _SellMearsure; } set {_SellMearsure = value; } }

		private decimal _SellCnvFactor;
		[LVRequired]
        public decimal SellCnvFactor { get { return _SellCnvFactor; } set {_SellCnvFactor = value; } }

		private decimal _SafeStock;
		[LVRequired]
        public decimal SafeStock { get { return _SafeStock; } set {_SafeStock = value; } }

		private decimal _MinStock;
		[LVRequired]
        public decimal MinStock { get { return _MinStock; } set {_MinStock = value; } }

		private decimal _MaxStock;
		[LVRequired]
        public decimal MaxStock { get { return _MaxStock; } set {_MaxStock = value; } }

		private string _DrugImage;
        [LVMaxLength(254)]
        public string DrugImage { get { return _DrugImage; } set {_DrugImage = value; } }

		private string _Notes;
        [LVMaxLength(254)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private bool _Stop;
        public bool Stop { get { return _Stop; } set {_Stop = value; } }

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
/// Ref Key: FK_AcPrincDrug_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_AntagonistDrug_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_AntagonistDrug_Drug_02
/// <summary>
/// <summary>
/// Ref Key: FK_DDI_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DDI_Drug_02
/// <summary>
/// <summary>
/// Ref Key: FK_DonorMedication_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DrMedicineTmp_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_DrugKind
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_InsurKind
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refCountry
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refMedcnAdminRoute
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refMedcnVehicleForm
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refUnitOfMeasure_02
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refUnitOfMeasure_03
/// <summary>
/// <summary>
/// Ref Key: FK_DrugConfign_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DrugConfign_Drug_02
/// <summary>
/// <summary>
/// Ref Key: FK_DrugDepartment_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DrugPrice_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_InOutwardDrug_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_PrescriptionDetail_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_ProvidableDrugs_Drug
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
    public class KeyedDrug : KeyedCollection<KeyValuePair<string, long>, Drug>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrug() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Drug item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrugID) { return new KeyValuePair<string, long>("DrugID", k_DrugID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Drug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Drug item)
        {
            Drug orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Drug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Drug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Drug GetObjectByKey(long k_DrugID) 
		{
            if (this.Contains(GetKey(k_DrugID)) == false) return null;
            Drug ob = this[GetKey(k_DrugID)];
            return (Drug)ob;
        }

		public Drug GetObjectByKey(long k_DrugID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrugID)) == false) {
				Drug ob = repository.GetQuery<Drug>().FirstOrDefault(o => o.DrugID == k_DrugID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Drug obj = this[GetKey(k_DrugID)];
            return (Drug)obj;
        }

		public Drug GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Drug ob = this[keypair];
            return (Drug)ob;
        }

        public Drug GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Drug ob = this[GetKey(keypair)];
            return (Drug)ob;
        }

		bool _LoadAll = false;
        public List<Drug> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Drug>().ToList();
			foreach (Drug item in list) {
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

        ~KeyedDrug()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
