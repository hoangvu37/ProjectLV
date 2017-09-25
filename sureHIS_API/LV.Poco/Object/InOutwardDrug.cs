/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : InOutwardDrug.cs         
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
	public partial class InOutwardDrug : BaseEntity, ICloneable	{
		public InOutwardDrug()
		{
			this.InOutID = 0;
			this.DrugID = 0;
			this.StoreHouseID = 0;
			this.SdlID = 0;
			this.LotID = 0;
			this.StaffID = 0;
			this.IOTypeID = 0;
			this.DocumentID = 0;
			this.Quantity = 0;
			this.Amount = 0;
            this.SysDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("InOutID", InOutID); } }


		private long _InOutID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long InOutID { get { return _InOutID; } set {_InOutID = value; } }

		private long? _DrugID;
        public long? DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private long? _StoreHouseID;
        public long? StoreHouseID { get { return _StoreHouseID; } set {_StoreHouseID = value; } }

		private long? _SdlID;
        public long? SdlID { get { return _SdlID; } set {_SdlID = value; } }

		private long? _LotID;
        public long? LotID { get { return _LotID; } set {_LotID = value; } }

		private long? _StaffID;
        public long? StaffID { get { return _StaffID; } set {_StaffID = value; } }

		private long? _IOTypeID;
        public long? IOTypeID { get { return _IOTypeID; } set {_IOTypeID = value; } }

		private long? _DocumentID;
        public long? DocumentID { get { return _DocumentID; } set {_DocumentID = value; } }

		private DateTime? _DocumentDate;
        public DateTime? DocumentDate { get { return _DocumentDate; } set {_DocumentDate = value; } }

		private string _InvNo;
        [LVMaxLength(20)]
        public string InvNo { get { return _InvNo; } set {_InvNo = value; } }

		private DateTime? _InvDate;
        public DateTime? InvDate { get { return _InvDate; } set {_InvDate = value; } }

		private string _Memo;
        [LVMaxLength(256)]
        public string Memo { get { return _Memo; } set {_Memo = value; } }

		private double _Quantity;
		[LVRequired]
        public double Quantity { get { return _Quantity; } set {_Quantity = value; } }

		private decimal _Amount;
		[LVRequired]
        public decimal Amount { get { return _Amount; } set {_Amount = value; } }

		private DateTime _SysDate;
		[LVRequired]
        public DateTime SysDate { get { return _SysDate; } set {_SysDate = value; } }

		/// <summary>
/// Ref Key: FK_InOutwardDrug_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_InOutwardDrug_InOutType
/// <summary>
/// <summary>
/// Ref Key: FK_InOutwardDrug_LotNumber
/// <summary>
/// <summary>
/// Ref Key: FK_InOutwardDrug_refShelfDrugLocation
/// <summary>
/// <summary>
/// Ref Key: FK_InOutwardDrug_refStoreHouse
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
    public class KeyedInOutwardDrug : KeyedCollection<KeyValuePair<string, long>, InOutwardDrug>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedInOutwardDrug() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(InOutwardDrug item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_InOutID) { return new KeyValuePair<string, long>("InOutID", k_InOutID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(InOutwardDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, InOutwardDrug item)
        {
            InOutwardDrug orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(InOutwardDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(InOutwardDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public InOutwardDrug GetObjectByKey(long k_InOutID) 
		{
            if (this.Contains(GetKey(k_InOutID)) == false) return null;
            InOutwardDrug ob = this[GetKey(k_InOutID)];
            return (InOutwardDrug)ob;
        }

		public InOutwardDrug GetObjectByKey(long k_InOutID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_InOutID)) == false) {
				InOutwardDrug ob = repository.GetQuery<InOutwardDrug>().FirstOrDefault(o => o.InOutID == k_InOutID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            InOutwardDrug obj = this[GetKey(k_InOutID)];
            return (InOutwardDrug)obj;
        }

		public InOutwardDrug GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            InOutwardDrug ob = this[keypair];
            return (InOutwardDrug)ob;
        }

        public InOutwardDrug GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            InOutwardDrug ob = this[GetKey(keypair)];
            return (InOutwardDrug)ob;
        }

		bool _LoadAll = false;
        public List<InOutwardDrug> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<InOutwardDrug>().ToList();
			foreach (InOutwardDrug item in list) {
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

        ~KeyedInOutwardDrug()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
