/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ContactDetails.cs         
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
	public partial class ContactDetails : BaseEntity, ICloneable	{
		public ContactDetails()
		{
			this.KID = 0;
			this.DKID = 0;
			this.RscrID = 0;
			this.Qty = 0;
			this.UnitPrice = 0;
			this.ExchangeRate = 0;
            this.WarrantyNo = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DKID", DKID); } }


		private long _KID;
		[LVRequired]
        public long KID { get { return _KID; } set {_KID = value; } }

		private long _DKID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DKID { get { return _DKID; } set {_DKID = value; } }

		private long _RscrID;
		[LVRequired]
        public long RscrID { get { return _RscrID; } set {_RscrID = value; } }

		private short _Qty;
		[LVRequired]
        public short Qty { get { return _Qty; } set {_Qty = value; } }

		private double _UnitPrice;
		[LVRequired]
        public double UnitPrice { get { return _UnitPrice; } set {_UnitPrice = value; } }

		private string _CurCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string CurCode { get { return _CurCode; } set {_CurCode = value; } }

		private double _ExchangeRate;
		[LVRequired]
        public double ExchangeRate { get { return _ExchangeRate; } set {_ExchangeRate = value; } }

		private string _WarrantyNo;
        [LVMaxLength(50)]
        public string WarrantyNo { get { return _WarrantyNo; } set {_WarrantyNo = value; } }

		/// <summary>
/// Ref Key: FK_ContactDetails_Contract
/// <summary>
/// <summary>
/// Ref Key: FK_ContactDetails_Resource
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
    public class KeyedContactDetails : KeyedCollection<KeyValuePair<string, long>, ContactDetails>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedContactDetails() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ContactDetails item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DKID) { return new KeyValuePair<string, long>("DKID", k_DKID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ContactDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ContactDetails item)
        {
            ContactDetails orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ContactDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ContactDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ContactDetails GetObjectByKey(long k_DKID) 
		{
            if (this.Contains(GetKey(k_DKID)) == false) return null;
            ContactDetails ob = this[GetKey(k_DKID)];
            return (ContactDetails)ob;
        }

		public ContactDetails GetObjectByKey(long k_DKID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DKID)) == false) {
				ContactDetails ob = repository.GetQuery<ContactDetails>().FirstOrDefault(o => o.DKID == k_DKID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ContactDetails obj = this[GetKey(k_DKID)];
            return (ContactDetails)obj;
        }

		public ContactDetails GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ContactDetails ob = this[keypair];
            return (ContactDetails)ob;
        }

        public ContactDetails GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ContactDetails ob = this[GetKey(keypair)];
            return (ContactDetails)ob;
        }

		bool _LoadAll = false;
        public List<ContactDetails> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ContactDetails>().ToList();
			foreach (ContactDetails item in list) {
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

        ~KeyedContactDetails()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
