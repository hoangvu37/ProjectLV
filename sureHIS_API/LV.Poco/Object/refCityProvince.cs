/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refCityProvince.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class refCityProvince : BaseEntity, ICloneable	{
		public refCityProvince()
		{
            this.CityProviceLevel = null;
            this.CountryID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("CityProvinceID", CityProvinceID); } }


		private string _CityProvinceID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(2)]
        public string CityProvinceID { get { return _CityProvinceID; } set {_CityProvinceID = value; } }

		private string _CityProvinceName;
		[LVRequired]
        [LVMaxLength(128)]
        public string CityProvinceName { get { return _CityProvinceName; } set {_CityProvinceName = value; } }

		private string _CityProviceLevel;
        [LVMaxLength(32)]
        public string CityProviceLevel { get { return _CityProviceLevel; } set {_CityProviceLevel = value; } }

		private string _CountryID;
        [LVMaxLength(2)]
        public string CountryID { get { return _CountryID; } set {_CountryID = value; } }

		/// <summary>
/// Ref Key: FK_HCProvider_refProvince
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refProvince
/// <summary>
/// <summary>
/// Ref Key: FK_refDistrict_refProvince
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
    public class KeyedrefCityProvince : KeyedCollection<KeyValuePair<string, string>, refCityProvince>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefCityProvince() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refCityProvince item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_CityProvinceID) { return new KeyValuePair<string, string>("CityProvinceID", k_CityProvinceID); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refCityProvince item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refCityProvince item)
        {
            refCityProvince orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refCityProvince item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refCityProvince item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refCityProvince GetObjectByKey(string k_CityProvinceID) 
		{
            if (this.Contains(GetKey(k_CityProvinceID)) == false) return null;
            refCityProvince ob = this[GetKey(k_CityProvinceID)];
            return (refCityProvince)ob;
        }

		public refCityProvince GetObjectByKey(string k_CityProvinceID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_CityProvinceID)) == false) {
				refCityProvince ob = repository.GetQuery<refCityProvince>().FirstOrDefault(o => o.CityProvinceID == k_CityProvinceID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refCityProvince obj = this[GetKey(k_CityProvinceID)];
            return (refCityProvince)obj;
        }

		public refCityProvince GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refCityProvince ob = this[keypair];
            return (refCityProvince)ob;
        }

        public refCityProvince GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refCityProvince ob = this[GetKey(keypair)];
            return (refCityProvince)ob;
        }

		bool _LoadAll = false;
        public List<refCityProvince> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refCityProvince>().ToList();
			foreach (refCityProvince item in list) {
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

        ~KeyedrefCityProvince()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
