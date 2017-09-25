/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Resource.cs         
 * Created by           : Auto - 09/11/2017 15:20:03                     
 * Last modify          : Auto - 09/11/2017 15:20:03                     
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
	public partial class Resource : BaseEntity, ICloneable	{
		public Resource()
		{
			this.SupplierID = 0;
			this.MDRscTypeID = 0;
			this.RscrID = 0;
            this.IsLocatable = true;
            this.DeprecTypeID = null;
            this.RscrDeprecRate = null;
			this.V_MDRscrPurpose = 0;
			this.V_MedDeviceStd = 0;
			this.V_PotentialRisk = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RscrID", RscrID); } }


		private long? _SupplierID;
        public long? SupplierID { get { return _SupplierID; } set {_SupplierID = value; } }

		private long _MDRscTypeID;
		[LVRequired]
        public long MDRscTypeID { get { return _MDRscTypeID; } set {_MDRscTypeID = value; } }

		private long _RscrID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RscrID { get { return _RscrID; } set {_RscrID = value; } }

		private string _RscrName;
		[LVRequired]
        [LVMaxLength(128)]
        public string RscrName { get { return _RscrName; } set {_RscrName = value; } }

		private bool? _IsLocatable;
        public bool? IsLocatable { get { return _IsLocatable; } set {_IsLocatable = value; } }

		private string _RscrNameBrand;
		[LVRequired]
        [LVMaxLength(128)]
        public string RscrNameBrand { get { return _RscrNameBrand; } set {_RscrNameBrand = value; } }

		private string _RscrFunctions;
		[LVRequired]
        [LVMaxLength(2048)]
        public string RscrFunctions { get { return _RscrFunctions; } set {_RscrFunctions = value; } }

		private string _RscrTechInfo;
		[LVRequired]
        public string RscrTechInfo { get { return _RscrTechInfo; } set {_RscrTechInfo = value; } }

		private int? _DeprecTypeID;
        public int? DeprecTypeID { get { return _DeprecTypeID; } set {_DeprecTypeID = value; } }

		private double? _RscrDeprecRate;
        public double? RscrDeprecRate { get { return _RscrDeprecRate; } set {_RscrDeprecRate = value; } }

		private string _RscrValue;
        public string RscrValue { get { return _RscrValue; } set {_RscrValue = value; } }

		private string _OriginOfRscr;
        [LVMaxLength(50)]
        public string OriginOfRscr { get { return _OriginOfRscr; } set {_OriginOfRscr = value; } }

		private long? _V_MDRscrPurpose;
        public long? V_MDRscrPurpose { get { return _V_MDRscrPurpose; } set {_V_MDRscrPurpose = value; } }

		private long? _V_MedDeviceStd;
        public long? V_MedDeviceStd { get { return _V_MedDeviceStd; } set {_V_MedDeviceStd = value; } }

		private long? _V_PotentialRisk;
        public long? V_PotentialRisk { get { return _V_PotentialRisk; } set {_V_PotentialRisk = value; } }

		/// <summary>
/// Ref Key: FK_AppliedMedStandard_Resource
/// <summary>
/// <summary>
/// Ref Key: FK_ContactDetails_Resource
/// <summary>
/// <summary>
/// Ref Key: FK_DisposableMDResource_Resource
/// <summary>
/// <summary>
/// Ref Key: FK_Resource_refDepreciationType
/// <summary>
/// <summary>
/// Ref Key: FK_Resource_refMedEquipResourceType
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
    public class KeyedResource : KeyedCollection<KeyValuePair<string, long>, Resource>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedResource() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Resource item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RscrID) { return new KeyValuePair<string, long>("RscrID", k_RscrID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Resource item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Resource item)
        {
            Resource orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Resource item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Resource item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Resource GetObjectByKey(long k_RscrID) 
		{
            if (this.Contains(GetKey(k_RscrID)) == false) return null;
            Resource ob = this[GetKey(k_RscrID)];
            return (Resource)ob;
        }

		public Resource GetObjectByKey(long k_RscrID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RscrID)) == false) {
				Resource ob = repository.GetQuery<Resource>().FirstOrDefault(o => o.RscrID == k_RscrID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Resource obj = this[GetKey(k_RscrID)];
            return (Resource)obj;
        }

		public Resource GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Resource ob = this[keypair];
            return (Resource)ob;
        }

        public Resource GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Resource ob = this[GetKey(keypair)];
            return (Resource)ob;
        }

		bool _LoadAll = false;
        public List<Resource> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Resource>().ToList();
			foreach (Resource item in list) {
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

        ~KeyedResource()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
