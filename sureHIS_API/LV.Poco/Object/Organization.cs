/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Organization.cs         
 * Created by           : Auto - 09/11/2017 15:20:02                     
 * Last modify          : Auto - 09/11/2017 15:20:02                     
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
	public partial class Organization : BaseEntity, ICloneable	{
		public Organization()
		{
			this.OUID = 0;
            this.ShortOrgUnitName = null;
            this.IsHCMDOU = true;
			this.H7OrgUnitType = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("OUID", OUID); } }


		private long _OUID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long OUID { get { return _OUID; } set {_OUID = value; } }

		private string _OrgUnitName;
		[LVRequired]
        [LVMaxLength(64)]
        public string OrgUnitName { get { return _OrgUnitName; } set {_OrgUnitName = value; } }

		private string _ShortOrgUnitName;
        [LVMaxLength(32)]
        public string ShortOrgUnitName { get { return _ShortOrgUnitName; } set {_ShortOrgUnitName = value; } }

		private bool _IsHCMDOU;
        public bool IsHCMDOU { get { return _IsHCMDOU; } set {_IsHCMDOU = value; } }

		private string _OUWebsite;
        [LVMaxLength(128)]
        public string OUWebsite { get { return _OUWebsite; } set {_OUWebsite = value; } }

		private string _OUEmail;
        [LVMaxLength(128)]
        public string OUEmail { get { return _OUEmail; } set {_OUEmail = value; } }

		private string _OUAddress;
        [LVMaxLength(512)]
        public string OUAddress { get { return _OUAddress; } set {_OUAddress = value; } }

		private long _H7OrgUnitType;
		[LVRequired]
        public long H7OrgUnitType { get { return _H7OrgUnitType; } set {_H7OrgUnitType = value; } }

		private string _OUPhone;
        [LVMaxLength(15)]
        public string OUPhone { get { return _OUPhone; } set {_OUPhone = value; } }

		private string _CountryID;
        [LVMaxLength(2)]
        public string CountryID { get { return _CountryID; } set {_CountryID = value; } }

		/// <summary>
/// Ref Key: FK_HCProvider_Organization
/// <summary>
/// <summary>
/// Ref Key: FK_HCStakeholder_Organization
/// <summary>
/// <summary>
/// Ref Key: FK_Organization_refCountry
/// <summary>
/// <summary>
/// Ref Key: FK_PharmaceuticalCompany_Organization
/// <summary>
/// <summary>
/// Ref Key: FK_WorkPlace_Organization
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
    public class KeyedOrganization : KeyedCollection<KeyValuePair<string, long>, Organization>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedOrganization() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Organization item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_OUID) { return new KeyValuePair<string, long>("OUID", k_OUID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Organization item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Organization item)
        {
            Organization orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Organization item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Organization item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Organization GetObjectByKey(long k_OUID) 
		{
            if (this.Contains(GetKey(k_OUID)) == false) return null;
            Organization ob = this[GetKey(k_OUID)];
            return (Organization)ob;
        }

		public Organization GetObjectByKey(long k_OUID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_OUID)) == false) {
				Organization ob = repository.GetQuery<Organization>().FirstOrDefault(o => o.OUID == k_OUID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Organization obj = this[GetKey(k_OUID)];
            return (Organization)obj;
        }

		public Organization GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Organization ob = this[keypair];
            return (Organization)ob;
        }

        public Organization GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Organization ob = this[GetKey(keypair)];
            return (Organization)ob;
        }

		bool _LoadAll = false;
        public List<Organization> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Organization>().ToList();
			foreach (Organization item in list) {
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

        ~KeyedOrganization()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
