/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Supplier.cs         
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
	public partial class Supplier : BaseEntity, ICloneable	{
		public Supplier()
		{
			this.SupplierID = 0;
            this.isGlobalSupplier = false;
            this.PhoneNumber = null;
            this.FaxNumber = null;
            this.WensiteURL = null;
            this.SupplierDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SupplierID", SupplierID); } }


		private long _SupplierID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SupplierID { get { return _SupplierID; } set {_SupplierID = value; } }

		private string _SupplierName;
		[LVRequired]
        [LVMaxLength(64)]
        public string SupplierName { get { return _SupplierName; } set {_SupplierName = value; } }

		private bool? _isGlobalSupplier;
        public bool? isGlobalSupplier { get { return _isGlobalSupplier; } set {_isGlobalSupplier = value; } }

		private string _Address;
		[LVRequired]
        [LVMaxLength(512)]
        public string Address { get { return _Address; } set {_Address = value; } }

		private string _CityStatetZipCode;
		[LVRequired]
        [LVMaxLength(128)]
        public string CityStatetZipCode { get { return _CityStatetZipCode; } set {_CityStatetZipCode = value; } }

		private string _ContctPerson;
		[LVRequired]
        [LVMaxLength(64)]
        public string ContctPerson { get { return _ContctPerson; } set {_ContctPerson = value; } }

		private string _PhoneNumber;
        [LVMaxLength(15)]
        public string PhoneNumber { get { return _PhoneNumber; } set {_PhoneNumber = value; } }

		private string _FaxNumber;
        [LVMaxLength(15)]
        public string FaxNumber { get { return _FaxNumber; } set {_FaxNumber = value; } }

		private string _EmailAddress;
        [LVMaxLength(128)]
        public string EmailAddress { get { return _EmailAddress; } set {_EmailAddress = value; } }

		private string _WensiteURL;
        [LVMaxLength(50)]
        public string WensiteURL { get { return _WensiteURL; } set {_WensiteURL = value; } }

		private string _CertificateAgency;
		[LVRequired]
        [LVMaxLength(50)]
        public string CertificateAgency { get { return _CertificateAgency; } set {_CertificateAgency = value; } }

		private string _SupplierDesc;
        [LVMaxLength(256)]
        public string SupplierDesc { get { return _SupplierDesc; } set {_SupplierDesc = value; } }

		/// <summary>
/// Ref Key: FK_Contract_Supplier
/// <summary>
/// <summary>
/// Ref Key: FK_Resource_Supplier
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
    public class KeyedSupplier : KeyedCollection<KeyValuePair<string, long>, Supplier>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedSupplier() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Supplier item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SupplierID) { return new KeyValuePair<string, long>("SupplierID", k_SupplierID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Supplier item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Supplier item)
        {
            Supplier orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Supplier item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Supplier item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Supplier GetObjectByKey(long k_SupplierID) 
		{
            if (this.Contains(GetKey(k_SupplierID)) == false) return null;
            Supplier ob = this[GetKey(k_SupplierID)];
            return (Supplier)ob;
        }

		public Supplier GetObjectByKey(long k_SupplierID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SupplierID)) == false) {
				Supplier ob = repository.GetQuery<Supplier>().FirstOrDefault(o => o.SupplierID == k_SupplierID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Supplier obj = this[GetKey(k_SupplierID)];
            return (Supplier)obj;
        }

		public Supplier GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Supplier ob = this[keypair];
            return (Supplier)ob;
        }

        public Supplier GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Supplier ob = this[GetKey(keypair)];
            return (Supplier)ob;
        }

		bool _LoadAll = false;
        public List<Supplier> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Supplier>().ToList();
			foreach (Supplier item in list) {
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

        ~KeyedSupplier()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
