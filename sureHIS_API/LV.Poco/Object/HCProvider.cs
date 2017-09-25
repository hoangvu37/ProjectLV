/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HCProvider.cs         
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
	public partial class HCProvider : BaseEntity, ICloneable	{
		public HCProvider()
		{
			this.HosID = 0;
            this.PHosID = null;
            this.SatOfHosID = null;
			this.OUID = 0;
            this.HosShortName = null;
            this.HosLogoImgPath = null;
            this.Slogan = null;
            this.HosPhone = null;
            this.HosHotline = null;
            this.HosWebSite = null;
            this.HosEmail = null;
            this.HosFax = null;
			this.HCPrvProviderTypeCode = 0;
            this.IsHeadOffice = false;
            this.HCPrvAgencyIDCode = null;
            this.IsBuiltIn = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HosID", HosID); } }


		private long _HosID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HosID { get { return _HosID; } set {_HosID = value; } }

		private long? _PHosID;
        public long? PHosID { get { return _PHosID; } set {_PHosID = value; } }

		private long? _SatOfHosID;
        public long? SatOfHosID { get { return _SatOfHosID; } set {_SatOfHosID = value; } }

		private string _HIHosCode;
        [LVMaxLength(6)]
        public string HIHosCode { get { return _HIHosCode; } set {_HIHosCode = value; } }

		private long? _OUID;
        public long? OUID { get { return _OUID; } set {_OUID = value; } }

		private string _HCPrvProviderId;
		[LVRequired]
        [LVMaxLength(10)]
        public string HCPrvProviderId { get { return _HCPrvProviderId; } set {_HCPrvProviderId = value; } }

		private string _HCPrvProviderName;
		[LVRequired]
        [LVMaxLength(254)]
        public string HCPrvProviderName { get { return _HCPrvProviderName; } set {_HCPrvProviderName = value; } }

		private string _ProvinceID;
		[LVRequired]
        [LVMaxLength(2)]
        public string ProvinceID { get { return _ProvinceID; } set {_ProvinceID = value; } }

		private string _HosShortName;
        [LVMaxLength(32)]
        public string HosShortName { get { return _HosShortName; } set {_HosShortName = value; } }

		private string _HCPractAddressText;
		[LVRequired]
        [LVMaxLength(254)]
        public string HCPractAddressText { get { return _HCPractAddressText; } set {_HCPractAddressText = value; } }

		private string _HosLogoImgPath;
        [LVMaxLength(256)]
        public string HosLogoImgPath { get { return _HosLogoImgPath; } set {_HosLogoImgPath = value; } }

		private string _Slogan;
        [LVMaxLength(1024)]
        public string Slogan { get { return _Slogan; } set {_Slogan = value; } }

		private string _HosPhone;
        [LVMaxLength(13)]
        public string HosPhone { get { return _HosPhone; } set {_HosPhone = value; } }

		private string _HosHotline;
        [LVMaxLength(32)]
        public string HosHotline { get { return _HosHotline; } set {_HosHotline = value; } }

		private string _HosWebSite;
        [LVMaxLength(128)]
        public string HosWebSite { get { return _HosWebSite; } set {_HosWebSite = value; } }

		private string _HosEmail;
        [LVMaxLength(128)]
        public string HosEmail { get { return _HosEmail; } set {_HosEmail = value; } }

		private string _HosFax;
        [LVMaxLength(64)]
        public string HosFax { get { return _HosFax; } set {_HosFax = value; } }

		private long _HCPrvProviderTypeCode;
		[LVRequired]
        public long HCPrvProviderTypeCode { get { return _HCPrvProviderTypeCode; } set {_HCPrvProviderTypeCode = value; } }

		private bool? _IsHeadOffice;
        public bool? IsHeadOffice { get { return _IsHeadOffice; } set {_IsHeadOffice = value; } }

		private string _HCPrvAgencyIDCode;
        [LVMaxLength(10)]
        public string HCPrvAgencyIDCode { get { return _HCPrvAgencyIDCode; } set {_HCPrvAgencyIDCode = value; } }

		private bool? _IsBuiltIn;
        public bool? IsBuiltIn { get { return _IsBuiltIn; } set {_IsBuiltIn = value; } }

		/// <summary>
/// Ref Key: FK_AdmNoTemp_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_HCEnterprise
/// <summary>
/// <summary>
/// Ref Key: FK_HCProvider_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_HCProvider_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_HCProvider_Organization
/// <summary>
/// <summary>
/// Ref Key: FK_HCProvider_refProviderType
/// <summary>
/// <summary>
/// Ref Key: FK_HCProvider_refProvince
/// <summary>
/// <summary>
/// Ref Key: FK_HCProvider_SatOfHosID
/// <summary>
/// <summary>
/// Ref Key: FK_HCProvider_SatOfHosID
/// <summary>
/// <summary>
/// Ref Key: FK_HealthInsurance_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalizationHistory_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalSpecialist_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_HosRanking_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_WorkingSchedule_HCProvider
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
    public class KeyedHCProvider : KeyedCollection<KeyValuePair<string, long>, HCProvider>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHCProvider() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HCProvider item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HosID) { return new KeyValuePair<string, long>("HosID", k_HosID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HCProvider item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HCProvider item)
        {
            HCProvider orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HCProvider item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HCProvider item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HCProvider GetObjectByKey(long k_HosID) 
		{
            if (this.Contains(GetKey(k_HosID)) == false) return null;
            HCProvider ob = this[GetKey(k_HosID)];
            return (HCProvider)ob;
        }

		public HCProvider GetObjectByKey(long k_HosID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HosID)) == false) {
				HCProvider ob = repository.GetQuery<HCProvider>().FirstOrDefault(o => o.HosID == k_HosID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HCProvider obj = this[GetKey(k_HosID)];
            return (HCProvider)obj;
        }

		public HCProvider GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HCProvider ob = this[keypair];
            return (HCProvider)ob;
        }

        public HCProvider GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HCProvider ob = this[GetKey(keypair)];
            return (HCProvider)ob;
        }

		bool _LoadAll = false;
        public List<HCProvider> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HCProvider>().ToList();
			foreach (HCProvider item in list) {
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

        ~KeyedHCProvider()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
