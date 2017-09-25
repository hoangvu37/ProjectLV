/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HosFeeTransDetails.cs         
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
	public partial class HosFeeTransDetails : BaseEntity, ICloneable	{
		public HosFeeTransDetails()
		{
			this.HosFeeTransDtlID = 0;
            this.HosFeeTransID = null;
			this.MedSerID = 0;
            this.Qty = 1;
			this.UnitPrice = 0;
            this.HIUnitPrice = null;
			this.Amount = 0;
            this.ExchangeRate = 1;
			this.ConvertedAmount = 0;
            this.HIAmount = null;
            this.PtPriceDifference = null;
            this.HIPaymentRate = null;
            this.HIRebateAmount = null;
            this.PtAmountCopay = null;
            this.PtAmountPayRate = null;
            this.Surcharge = null;
            this.AmountOther = null;
            this.Discount = null;
            this.AmountDiscount = null;
            this.PtSumAmount = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HosFeeTransDtlID", HosFeeTransDtlID); } }


		private long _HosFeeTransDtlID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HosFeeTransDtlID { get { return _HosFeeTransDtlID; } set {_HosFeeTransDtlID = value; } }

		private long? _HosFeeTransID;
        public long? HosFeeTransID { get { return _HosFeeTransID; } set {_HosFeeTransID = value; } }

		private long _MedSerID;
		[LVRequired]
        public long MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private string _UOMID;
		[LVRequired]
        [LVMaxLength(10)]
        public string UOMID { get { return _UOMID; } set {_UOMID = value; } }

		private byte _Qty;
		[LVRequired]
        public byte Qty { get { return _Qty; } set {_Qty = value; } }

		private double _UnitPrice;
		[LVRequired]
        public double UnitPrice { get { return _UnitPrice; } set {_UnitPrice = value; } }

		private double? _HIUnitPrice;
        public double? HIUnitPrice { get { return _HIUnitPrice; } set {_HIUnitPrice = value; } }

		private double _Amount;
		[LVRequired]
        public double Amount { get { return _Amount; } set {_Amount = value; } }

		private string _CurCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string CurCode { get { return _CurCode; } set {_CurCode = value; } }

		private double _ExchangeRate;
		[LVRequired]
        public double ExchangeRate { get { return _ExchangeRate; } set {_ExchangeRate = value; } }

		private double _ConvertedAmount;
		[LVRequired]
        public double ConvertedAmount { get { return _ConvertedAmount; } set {_ConvertedAmount = value; } }

		private double? _HIAmount;
        public double? HIAmount { get { return _HIAmount; } set {_HIAmount = value; } }

		private double? _PtPriceDifference;
        public double? PtPriceDifference { get { return _PtPriceDifference; } set {_PtPriceDifference = value; } }

		private double? _HIPaymentRate;
        public double? HIPaymentRate { get { return _HIPaymentRate; } set {_HIPaymentRate = value; } }

		private double? _HIRebateAmount;
        public double? HIRebateAmount { get { return _HIRebateAmount; } set {_HIRebateAmount = value; } }

		private double? _PtAmountCopay;
        public double? PtAmountCopay { get { return _PtAmountCopay; } set {_PtAmountCopay = value; } }

		private double? _PtAmountPayRate;
        public double? PtAmountPayRate { get { return _PtAmountPayRate; } set {_PtAmountPayRate = value; } }

		private double? _Surcharge;
        public double? Surcharge { get { return _Surcharge; } set {_Surcharge = value; } }

		private double? _AmountOther;
        public double? AmountOther { get { return _AmountOther; } set {_AmountOther = value; } }

		private double? _Discount;
        public double? Discount { get { return _Discount; } set {_Discount = value; } }

		private double? _AmountDiscount;
        public double? AmountDiscount { get { return _AmountDiscount; } set {_AmountDiscount = value; } }

		private double? _PtSumAmount;
        public double? PtSumAmount { get { return _PtSumAmount; } set {_PtSumAmount = value; } }

		private string _HosFeeTransDtlRemarks;
        [LVMaxLength(1024)]
        public string HosFeeTransDtlRemarks { get { return _HosFeeTransDtlRemarks; } set {_HosFeeTransDtlRemarks = value; } }

		/// <summary>
/// Ref Key: FK_HosFeeTransDetails_MedicalServiceItem
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
    public class KeyedHosFeeTransDetails : KeyedCollection<KeyValuePair<string, long>, HosFeeTransDetails>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHosFeeTransDetails() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HosFeeTransDetails item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HosFeeTransDtlID) { return new KeyValuePair<string, long>("HosFeeTransDtlID", k_HosFeeTransDtlID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HosFeeTransDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HosFeeTransDetails item)
        {
            HosFeeTransDetails orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HosFeeTransDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HosFeeTransDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HosFeeTransDetails GetObjectByKey(long k_HosFeeTransDtlID) 
		{
            if (this.Contains(GetKey(k_HosFeeTransDtlID)) == false) return null;
            HosFeeTransDetails ob = this[GetKey(k_HosFeeTransDtlID)];
            return (HosFeeTransDetails)ob;
        }

		public HosFeeTransDetails GetObjectByKey(long k_HosFeeTransDtlID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HosFeeTransDtlID)) == false) {
				HosFeeTransDetails ob = repository.GetQuery<HosFeeTransDetails>().FirstOrDefault(o => o.HosFeeTransDtlID == k_HosFeeTransDtlID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HosFeeTransDetails obj = this[GetKey(k_HosFeeTransDtlID)];
            return (HosFeeTransDetails)obj;
        }

		public HosFeeTransDetails GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HosFeeTransDetails ob = this[keypair];
            return (HosFeeTransDetails)ob;
        }

        public HosFeeTransDetails GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HosFeeTransDetails ob = this[GetKey(keypair)];
            return (HosFeeTransDetails)ob;
        }

		bool _LoadAll = false;
        public List<HosFeeTransDetails> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HosFeeTransDetails>().ToList();
			foreach (HosFeeTransDetails item in list) {
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

        ~KeyedHosFeeTransDetails()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
