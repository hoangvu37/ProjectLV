/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refAdmissionType.cs         
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
	public partial class refAdmissionType : BaseEntity, ICloneable	{
		public refAdmissionType()
		{
			this.HCFERecAdmTypeID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HCFERecAdmTypeID", HCFERecAdmTypeID); } }


		private long _HCFERecAdmTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HCFERecAdmTypeID { get { return _HCFERecAdmTypeID; } set {_HCFERecAdmTypeID = value; } }

		private string _HCFERecAdmissionTypeCode;
		[LVRequired]
        [LVMaxLength(6)]
        public string HCFERecAdmissionTypeCode { get { return _HCFERecAdmissionTypeCode; } set {_HCFERecAdmissionTypeCode = value; } }

		private string _HCFERecAdmissionTypeName;
		[LVRequired]
        [LVMaxLength(64)]
        public string HCFERecAdmissionTypeName { get { return _HCFERecAdmissionTypeName; } set {_HCFERecAdmissionTypeName = value; } }

		private string _VNHCFERecAdmissionTypeName;
        [LVMaxLength(64)]
        public string VNHCFERecAdmissionTypeName { get { return _VNHCFERecAdmissionTypeName; } set {_VNHCFERecAdmissionTypeName = value; } }

		private string _AdmissionTypeNotes;
        [LVMaxLength(256)]
        public string AdmissionTypeNotes { get { return _AdmissionTypeNotes; } set {_AdmissionTypeNotes = value; } }

		/// <summary>
/// Ref Key: FK_HospitalizationHistory_refAdmissionType
/// <summary>
/// <summary>
/// Ref Key: FK_PtAdmission_refAdmissionType
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
    public class KeyedrefAdmissionType : KeyedCollection<KeyValuePair<string, long>, refAdmissionType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefAdmissionType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refAdmissionType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HCFERecAdmTypeID) { return new KeyValuePair<string, long>("HCFERecAdmTypeID", k_HCFERecAdmTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refAdmissionType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refAdmissionType item)
        {
            refAdmissionType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refAdmissionType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refAdmissionType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refAdmissionType GetObjectByKey(long k_HCFERecAdmTypeID) 
		{
            if (this.Contains(GetKey(k_HCFERecAdmTypeID)) == false) return null;
            refAdmissionType ob = this[GetKey(k_HCFERecAdmTypeID)];
            return (refAdmissionType)ob;
        }

		public refAdmissionType GetObjectByKey(long k_HCFERecAdmTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HCFERecAdmTypeID)) == false) {
				refAdmissionType ob = repository.GetQuery<refAdmissionType>().FirstOrDefault(o => o.HCFERecAdmTypeID == k_HCFERecAdmTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refAdmissionType obj = this[GetKey(k_HCFERecAdmTypeID)];
            return (refAdmissionType)obj;
        }

		public refAdmissionType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refAdmissionType ob = this[keypair];
            return (refAdmissionType)ob;
        }

        public refAdmissionType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refAdmissionType ob = this[GetKey(keypair)];
            return (refAdmissionType)ob;
        }

		bool _LoadAll = false;
        public List<refAdmissionType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refAdmissionType>().ToList();
			foreach (refAdmissionType item in list) {
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

        ~KeyedrefAdmissionType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
