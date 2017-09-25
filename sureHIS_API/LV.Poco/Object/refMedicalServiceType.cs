/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refMedicalServiceType.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class refMedicalServiceType : BaseEntity, ICloneable	{
		public refMedicalServiceType()
		{
			this.MedSerTypeID = 0;
			this.V_MedSerTypeStatus = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedSerTypeID", MedSerTypeID); } }


		private long _MedSerTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedSerTypeID { get { return _MedSerTypeID; } set {_MedSerTypeID = value; } }

		private string _MedSerTypeCode;
		[LVRequired]
        [LVMaxLength(15)]
        public string MedSerTypeCode { get { return _MedSerTypeCode; } set {_MedSerTypeCode = value; } }

		private string _MedSerTypeName;
		[LVRequired]
        [LVMaxLength(128)]
        public string MedSerTypeName { get { return _MedSerTypeName; } set {_MedSerTypeName = value; } }

		private string _MedSerTypeDesc;
        [LVMaxLength(1024)]
        public string MedSerTypeDesc { get { return _MedSerTypeDesc; } set {_MedSerTypeDesc = value; } }

		private long? _V_MedSerTypeStatus;
        public long? V_MedSerTypeStatus { get { return _V_MedSerTypeStatus; } set {_V_MedSerTypeStatus = value; } }

		/// <summary>
/// Ref Key: FK_HIServiceItem_refMedicalServiceType
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalServiceItems_refMedicalServiceTypes
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
    public class KeyedrefMedicalServiceType : KeyedCollection<KeyValuePair<string, long>, refMedicalServiceType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefMedicalServiceType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refMedicalServiceType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedSerTypeID) { return new KeyValuePair<string, long>("MedSerTypeID", k_MedSerTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refMedicalServiceType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refMedicalServiceType item)
        {
            refMedicalServiceType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refMedicalServiceType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refMedicalServiceType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refMedicalServiceType GetObjectByKey(long k_MedSerTypeID) 
		{
            if (this.Contains(GetKey(k_MedSerTypeID)) == false) return null;
            refMedicalServiceType ob = this[GetKey(k_MedSerTypeID)];
            return (refMedicalServiceType)ob;
        }

		public refMedicalServiceType GetObjectByKey(long k_MedSerTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedSerTypeID)) == false) {
				refMedicalServiceType ob = repository.GetQuery<refMedicalServiceType>().FirstOrDefault(o => o.MedSerTypeID == k_MedSerTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refMedicalServiceType obj = this[GetKey(k_MedSerTypeID)];
            return (refMedicalServiceType)obj;
        }

		public refMedicalServiceType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refMedicalServiceType ob = this[keypair];
            return (refMedicalServiceType)ob;
        }

        public refMedicalServiceType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refMedicalServiceType ob = this[GetKey(keypair)];
            return (refMedicalServiceType)ob;
        }

		bool _LoadAll = false;
        public List<refMedicalServiceType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refMedicalServiceType>().ToList();
			foreach (refMedicalServiceType item in list) {
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

        ~KeyedrefMedicalServiceType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
