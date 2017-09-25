/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HIServiceItems.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class HIServiceItems : BaseEntity, ICloneable	{
		public HIServiceItems()
		{
			this.HISID = 0;
			this.QuotationID = 0;
			this.HISerItemID = 0;
			this.UnitPrice = 0;
            this.HIPaymentRate = 0;
            this.CreatedDate = DateTime.Now;
			this.CreatedBy = 0;
			this.LastUpdBy = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HISID", HISID); } }


		private long _HISID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HISID { get { return _HISID; } set {_HISID = value; } }

		private long _QuotationID;
		[LVRequired]
        public long QuotationID { get { return _QuotationID; } set {_QuotationID = value; } }

		private long _HISerItemID;
		[LVRequired]
        public long HISerItemID { get { return _HISerItemID; } set {_HISerItemID = value; } }

		private double _UnitPrice;
		[LVRequired]
        public double UnitPrice { get { return _UnitPrice; } set {_UnitPrice = value; } }

		private double _HIPaymentRate;
		[LVRequired]
        public double HIPaymentRate { get { return _HIPaymentRate; } set {_HIPaymentRate = value; } }

		private DateTime _ValidDateFrom;
		[LVRequired]
        public DateTime ValidDateFrom { get { return _ValidDateFrom; } set {_ValidDateFrom = value; } }

		private DateTime? _ValidDateTo;
        public DateTime? ValidDateTo { get { return _ValidDateTo; } set {_ValidDateTo = value; } }

		private string _HISerItemUOM;
		[LVRequired]
        [LVMaxLength(10)]
        public string HISerItemUOM { get { return _HISerItemUOM; } set {_HISerItemUOM = value; } }

		private string _HISNotes;
        [LVMaxLength(500)]
        public string HISNotes { get { return _HISNotes; } set {_HISNotes = value; } }

		private DateTime _CreatedDate;
		[LVRequired]
        public DateTime CreatedDate { get { return _CreatedDate; } set {_CreatedDate = value; } }

		private long? _CreatedBy;
        public long? CreatedBy { get { return _CreatedBy; } set {_CreatedBy = value; } }

		private DateTime? _LastUpdDate;
        public DateTime? LastUpdDate { get { return _LastUpdDate; } set {_LastUpdDate = value; } }

		private long? _LastUpdBy;
        public long? LastUpdBy { get { return _LastUpdBy; } set {_LastUpdBy = value; } }

		/// <summary>
/// Ref Key: FK_HIServiceItems_HIServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_HIServiceItems_Quotation
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
    public class KeyedHIServiceItems : KeyedCollection<KeyValuePair<string, long>, HIServiceItems>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHIServiceItems() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HIServiceItems item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HISID) { return new KeyValuePair<string, long>("HISID", k_HISID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HIServiceItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HIServiceItems item)
        {
            HIServiceItems orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HIServiceItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HIServiceItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HIServiceItems GetObjectByKey(long k_HISID) 
		{
            if (this.Contains(GetKey(k_HISID)) == false) return null;
            HIServiceItems ob = this[GetKey(k_HISID)];
            return (HIServiceItems)ob;
        }

		public HIServiceItems GetObjectByKey(long k_HISID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HISID)) == false) {
				HIServiceItems ob = repository.GetQuery<HIServiceItems>().FirstOrDefault(o => o.HISID == k_HISID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HIServiceItems obj = this[GetKey(k_HISID)];
            return (HIServiceItems)obj;
        }

		public HIServiceItems GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HIServiceItems ob = this[keypair];
            return (HIServiceItems)ob;
        }

        public HIServiceItems GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HIServiceItems ob = this[GetKey(keypair)];
            return (HIServiceItems)ob;
        }

		bool _LoadAll = false;
        public List<HIServiceItems> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HIServiceItems>().ToList();
			foreach (HIServiceItems item in list) {
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

        ~KeyedHIServiceItems()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
