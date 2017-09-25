/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refAdmReferralType.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class refAdmReferralType : BaseEntity, ICloneable	{
		public refAdmReferralType()
		{
			this.IAdmReferralTypeID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("IAdmReferralTypeID", IAdmReferralTypeID); } }


		private long _IAdmReferralTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long IAdmReferralTypeID { get { return _IAdmReferralTypeID; } set {_IAdmReferralTypeID = value; } }

		private string _IAdmReferralTypeCode;
		[LVRequired]
        [LVMaxLength(6)]
        public string IAdmReferralTypeCode { get { return _IAdmReferralTypeCode; } set {_IAdmReferralTypeCode = value; } }

		private string _IAdmReferralTypeName;
		[LVRequired]
        [LVMaxLength(50)]
        public string IAdmReferralTypeName { get { return _IAdmReferralTypeName; } set {_IAdmReferralTypeName = value; } }

		private string _VNIAdmReferralTypeName;
        [LVMaxLength(50)]
        public string VNIAdmReferralTypeName { get { return _VNIAdmReferralTypeName; } set {_VNIAdmReferralTypeName = value; } }

		/// <summary>
/// Ref Key: FK_HospitalizationHistory_refAdmReferralType
/// <summary>
/// <summary>
/// Ref Key: FK_MiscDocuments_refAdmReferralType
/// <summary>
/// <summary>
/// Ref Key: FK_PtAdmission_refAdmReferralType
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
    public class KeyedrefAdmReferralType : KeyedCollection<KeyValuePair<string, long>, refAdmReferralType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefAdmReferralType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refAdmReferralType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_IAdmReferralTypeID) { return new KeyValuePair<string, long>("IAdmReferralTypeID", k_IAdmReferralTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refAdmReferralType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refAdmReferralType item)
        {
            refAdmReferralType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refAdmReferralType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refAdmReferralType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refAdmReferralType GetObjectByKey(long k_IAdmReferralTypeID) 
		{
            if (this.Contains(GetKey(k_IAdmReferralTypeID)) == false) return null;
            refAdmReferralType ob = this[GetKey(k_IAdmReferralTypeID)];
            return (refAdmReferralType)ob;
        }

		public refAdmReferralType GetObjectByKey(long k_IAdmReferralTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_IAdmReferralTypeID)) == false) {
				refAdmReferralType ob = repository.GetQuery<refAdmReferralType>().FirstOrDefault(o => o.IAdmReferralTypeID == k_IAdmReferralTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refAdmReferralType obj = this[GetKey(k_IAdmReferralTypeID)];
            return (refAdmReferralType)obj;
        }

		public refAdmReferralType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refAdmReferralType ob = this[keypair];
            return (refAdmReferralType)ob;
        }

        public refAdmReferralType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refAdmReferralType ob = this[GetKey(keypair)];
            return (refAdmReferralType)ob;
        }

		bool _LoadAll = false;
        public List<refAdmReferralType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refAdmReferralType>().ToList();
			foreach (refAdmReferralType item in list) {
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

        ~KeyedrefAdmReferralType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
