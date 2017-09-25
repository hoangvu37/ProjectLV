/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refProviderType.cs         
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
	public partial class refProviderType : BaseEntity, ICloneable	{
		public refProviderType()
		{
			this.HCPrvProviderTypeID = 0;
            this.PPrvTypeID = null;
            this.PPrvTypeCode = null;
            this.IsNonIndividual = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HCPrvProviderTypeID", HCPrvProviderTypeID); } }


		private long _HCPrvProviderTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HCPrvProviderTypeID { get { return _HCPrvProviderTypeID; } set {_HCPrvProviderTypeID = value; } }

		private long? _PPrvTypeID;
        public long? PPrvTypeID { get { return _PPrvTypeID; } set {_PPrvTypeID = value; } }

		private string _PPrvTypeCode;
        [LVMaxLength(10)]
        public string PPrvTypeCode { get { return _PPrvTypeCode; } set {_PPrvTypeCode = value; } }

		private string _HCPrvProviderTypeCode;
        [LVMaxLength(10)]
        public string HCPrvProviderTypeCode { get { return _HCPrvProviderTypeCode; } set {_HCPrvProviderTypeCode = value; } }

		private string _HCPrvProviderTypeName;
		[LVRequired]
        [LVMaxLength(256)]
        public string HCPrvProviderTypeName { get { return _HCPrvProviderTypeName; } set {_HCPrvProviderTypeName = value; } }

		private bool? _IsNonIndividual;
        public bool? IsNonIndividual { get { return _IsNonIndividual; } set {_IsNonIndividual = value; } }

		/// <summary>
/// Ref Key: FK_HCProvider_refProviderType
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
    public class KeyedrefProviderType : KeyedCollection<KeyValuePair<string, long>, refProviderType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefProviderType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refProviderType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HCPrvProviderTypeID) { return new KeyValuePair<string, long>("HCPrvProviderTypeID", k_HCPrvProviderTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refProviderType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refProviderType item)
        {
            refProviderType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refProviderType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refProviderType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refProviderType GetObjectByKey(long k_HCPrvProviderTypeID) 
		{
            if (this.Contains(GetKey(k_HCPrvProviderTypeID)) == false) return null;
            refProviderType ob = this[GetKey(k_HCPrvProviderTypeID)];
            return (refProviderType)ob;
        }

		public refProviderType GetObjectByKey(long k_HCPrvProviderTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HCPrvProviderTypeID)) == false) {
				refProviderType ob = repository.GetQuery<refProviderType>().FirstOrDefault(o => o.HCPrvProviderTypeID == k_HCPrvProviderTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refProviderType obj = this[GetKey(k_HCPrvProviderTypeID)];
            return (refProviderType)obj;
        }

		public refProviderType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refProviderType ob = this[keypair];
            return (refProviderType)ob;
        }

        public refProviderType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refProviderType ob = this[GetKey(keypair)];
            return (refProviderType)ob;
        }

		bool _LoadAll = false;
        public List<refProviderType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refProviderType>().ToList();
			foreach (refProviderType item in list) {
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

        ~KeyedrefProviderType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
