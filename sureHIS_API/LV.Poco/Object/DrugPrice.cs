/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrugPrice.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class DrugPrice : BaseEntity, ICloneable	{
		public DrugPrice()
		{
			this.DrugPriceID = 0;
			this.PriceListID = 0;
			this.DrugID = 0;
            this.SellPrice = null;
            this.HIPrice = null;
            this.IsFree = false;
            this.NoEffect = true;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrugPriceID", DrugPriceID); } }


		private long _DrugPriceID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrugPriceID { get { return _DrugPriceID; } set {_DrugPriceID = value; } }

		private long _PriceListID;
		[LVRequired]
        public long PriceListID { get { return _PriceListID; } set {_PriceListID = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private decimal? _SellPrice;
        public decimal? SellPrice { get { return _SellPrice; } set {_SellPrice = value; } }

		private decimal? _HIPrice;
        public decimal? HIPrice { get { return _HIPrice; } set {_HIPrice = value; } }

		private bool? _IsFree;
        public bool? IsFree { get { return _IsFree; } set {_IsFree = value; } }

		private string _Notes;
        [LVMaxLength(256)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private bool? _NoEffect;
        public bool? NoEffect { get { return _NoEffect; } set {_NoEffect = value; } }

		private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_DrugPrice_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DrugPrice_PriceList
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
    public class KeyedDrugPrice : KeyedCollection<KeyValuePair<string, long>, DrugPrice>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrugPrice() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrugPrice item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrugPriceID) { return new KeyValuePair<string, long>("DrugPriceID", k_DrugPriceID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrugPrice item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrugPrice item)
        {
            DrugPrice orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrugPrice item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrugPrice item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrugPrice GetObjectByKey(long k_DrugPriceID) 
		{
            if (this.Contains(GetKey(k_DrugPriceID)) == false) return null;
            DrugPrice ob = this[GetKey(k_DrugPriceID)];
            return (DrugPrice)ob;
        }

		public DrugPrice GetObjectByKey(long k_DrugPriceID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrugPriceID)) == false) {
				DrugPrice ob = repository.GetQuery<DrugPrice>().FirstOrDefault(o => o.DrugPriceID == k_DrugPriceID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrugPrice obj = this[GetKey(k_DrugPriceID)];
            return (DrugPrice)obj;
        }

		public DrugPrice GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrugPrice ob = this[keypair];
            return (DrugPrice)ob;
        }

        public DrugPrice GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrugPrice ob = this[GetKey(keypair)];
            return (DrugPrice)ob;
        }

		bool _LoadAll = false;
        public List<DrugPrice> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrugPrice>().ToList();
			foreach (DrugPrice item in list) {
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

        ~KeyedDrugPrice()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
