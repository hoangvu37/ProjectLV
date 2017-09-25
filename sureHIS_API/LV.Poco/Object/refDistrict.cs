/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refDistrict.cs         
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
	public partial class refDistrict : BaseEntity, ICloneable	{
		public refDistrict()
		{
            this.DistrictLevel = null;
            this.CityProvinceID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("DistrictID", DistrictID); } }


		private string _DistrictID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(3)]
        public string DistrictID { get { return _DistrictID; } set {_DistrictID = value; } }

		private string _DistrictName;
		[LVRequired]
        [LVMaxLength(128)]
        public string DistrictName { get { return _DistrictName; } set {_DistrictName = value; } }

		private string _DistrictLevel;
        [LVMaxLength(32)]
        public string DistrictLevel { get { return _DistrictLevel; } set {_DistrictLevel = value; } }

		private string _CityProvinceID;
        [LVMaxLength(2)]
        public string CityProvinceID { get { return _CityProvinceID; } set {_CityProvinceID = value; } }

		/// <summary>
/// Ref Key: FK_Person_refDistrict
/// <summary>
/// <summary>
/// Ref Key: FK_refDistrict_refProvince
/// <summary>
/// <summary>
/// Ref Key: FK_refWard_refDistrict
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
    public class KeyedrefDistrict : KeyedCollection<KeyValuePair<string, string>, refDistrict>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefDistrict() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refDistrict item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_DistrictID) { return new KeyValuePair<string, string>("DistrictID", k_DistrictID); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refDistrict item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refDistrict item)
        {
            refDistrict orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refDistrict item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refDistrict item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refDistrict GetObjectByKey(string k_DistrictID) 
		{
            if (this.Contains(GetKey(k_DistrictID)) == false) return null;
            refDistrict ob = this[GetKey(k_DistrictID)];
            return (refDistrict)ob;
        }

		public refDistrict GetObjectByKey(string k_DistrictID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DistrictID)) == false) {
				refDistrict ob = repository.GetQuery<refDistrict>().FirstOrDefault(o => o.DistrictID == k_DistrictID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refDistrict obj = this[GetKey(k_DistrictID)];
            return (refDistrict)obj;
        }

		public refDistrict GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refDistrict ob = this[keypair];
            return (refDistrict)ob;
        }

        public refDistrict GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refDistrict ob = this[GetKey(keypair)];
            return (refDistrict)ob;
        }

		bool _LoadAll = false;
        public List<refDistrict> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refDistrict>().ToList();
			foreach (refDistrict item in list) {
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

        ~KeyedrefDistrict()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
