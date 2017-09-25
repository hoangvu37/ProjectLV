/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refCountry.cs         
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
	public partial class refCountry : BaseEntity, ICloneable	{
		public refCountry()
		{
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("CountryID", CountryID); } }


		private string _CountryID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(2)]
        public string CountryID { get { return _CountryID; } set {_CountryID = value; } }

		private string _CountryName;
		[LVRequired]
        [LVMaxLength(100)]
        public string CountryName { get { return _CountryName; } set {_CountryName = value; } }

		private string _CountryDesc;
        [LVMaxLength(256)]
        public string CountryDesc { get { return _CountryDesc; } set {_CountryDesc = value; } }

		private string _DialingCode;
        [LVMaxLength(5)]
        public string DialingCode { get { return _DialingCode; } set {_DialingCode = value; } }

		/// <summary>
/// Ref Key: FK_Drug_refCountry
/// <summary>
/// <summary>
/// Ref Key: FK_LotNumber_refCountry
/// <summary>
/// <summary>
/// Ref Key: FK_Organization_refCountry
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refCountry
/// <summary>
/// <summary>
/// Ref Key: FK_refProvince_refCountry
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
    public class KeyedrefCountry : KeyedCollection<KeyValuePair<string, string>, refCountry>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefCountry() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refCountry item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_CountryID) { return new KeyValuePair<string, string>("CountryID", k_CountryID); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refCountry item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refCountry item)
        {
            refCountry orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refCountry item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refCountry item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refCountry GetObjectByKey(string k_CountryID) 
		{
            if (this.Contains(GetKey(k_CountryID)) == false) return null;
            refCountry ob = this[GetKey(k_CountryID)];
            return (refCountry)ob;
        }

		public refCountry GetObjectByKey(string k_CountryID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_CountryID)) == false) {
				refCountry ob = repository.GetQuery<refCountry>().FirstOrDefault(o => o.CountryID == k_CountryID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refCountry obj = this[GetKey(k_CountryID)];
            return (refCountry)obj;
        }

		public refCountry GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refCountry ob = this[keypair];
            return (refCountry)ob;
        }

        public refCountry GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refCountry ob = this[GetKey(keypair)];
            return (refCountry)ob;
        }

		bool _LoadAll = false;
        public List<refCountry> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refCountry>().ToList();
			foreach (refCountry item in list) {
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

        ~KeyedrefCountry()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
