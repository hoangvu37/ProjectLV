/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Contract.cs         
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
	public partial class Contract : BaseEntity, ICloneable	{
		public Contract()
		{
			this.KID = 0;
			this.SupplierID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("KID", KID); } }


		private long _KID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long KID { get { return _KID; } set {_KID = value; } }

		private string _KNo;
		[LVRequired]
        [LVMaxLength(20)]
        public string KNo { get { return _KNo; } set {_KNo = value; } }

		private DateTime _KDate;
		[LVRequired]
        public DateTime KDate { get { return _KDate; } set {_KDate = value; } }

		private long _SupplierID;
		[LVRequired]
        public long SupplierID { get { return _SupplierID; } set {_SupplierID = value; } }

		/// <summary>
/// Ref Key: FK_ContactDetails_Contract
/// <summary>
/// <summary>
/// Ref Key: FK_Contract_Supplier
/// <summary>
/// <summary>
/// Ref Key: FK_ContractChange_Contract
/// <summary>
/// <summary>
/// Ref Key: FK_ContractDocument_Contract
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
    public class KeyedContract : KeyedCollection<KeyValuePair<string, long>, Contract>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedContract() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Contract item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_KID) { return new KeyValuePair<string, long>("KID", k_KID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Contract item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Contract item)
        {
            Contract orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Contract item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Contract item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Contract GetObjectByKey(long k_KID) 
		{
            if (this.Contains(GetKey(k_KID)) == false) return null;
            Contract ob = this[GetKey(k_KID)];
            return (Contract)ob;
        }

		public Contract GetObjectByKey(long k_KID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_KID)) == false) {
				Contract ob = repository.GetQuery<Contract>().FirstOrDefault(o => o.KID == k_KID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Contract obj = this[GetKey(k_KID)];
            return (Contract)obj;
        }

		public Contract GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Contract ob = this[keypair];
            return (Contract)ob;
        }

        public Contract GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Contract ob = this[GetKey(keypair)];
            return (Contract)ob;
        }

		bool _LoadAll = false;
        public List<Contract> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Contract>().ToList();
			foreach (Contract item in list) {
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

        ~KeyedContract()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
