/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refSpecimenType.cs         
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
	public partial class refSpecimenType : BaseEntity, ICloneable	{
		public refSpecimenType()
		{
			this.SpecTypeID = 0;
            this.SpecTypeDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SpecTypeID", SpecTypeID); } }


		private long _SpecTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SpecTypeID { get { return _SpecTypeID; } set {_SpecTypeID = value; } }

		private string _SpecTypeCode;
		[LVRequired]
        [LVMaxLength(20)]
        public string SpecTypeCode { get { return _SpecTypeCode; } set {_SpecTypeCode = value; } }

		private string _SpecTypeName;
		[LVRequired]
        [LVMaxLength(64)]
        public string SpecTypeName { get { return _SpecTypeName; } set {_SpecTypeName = value; } }

		private string _SpecTypeDesc;
        [LVMaxLength(1024)]
        public string SpecTypeDesc { get { return _SpecTypeDesc; } set {_SpecTypeDesc = value; } }

		/// <summary>
/// Ref Key: FK_MedicalTest_refSpecimenType
/// <summary>
/// <summary>
/// Ref Key: FK_PatientSpecimen_refSpecimenType
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
    public class KeyedrefSpecimenType : KeyedCollection<KeyValuePair<string, long>, refSpecimenType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefSpecimenType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refSpecimenType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SpecTypeID) { return new KeyValuePair<string, long>("SpecTypeID", k_SpecTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refSpecimenType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refSpecimenType item)
        {
            refSpecimenType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refSpecimenType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refSpecimenType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refSpecimenType GetObjectByKey(long k_SpecTypeID) 
		{
            if (this.Contains(GetKey(k_SpecTypeID)) == false) return null;
            refSpecimenType ob = this[GetKey(k_SpecTypeID)];
            return (refSpecimenType)ob;
        }

		public refSpecimenType GetObjectByKey(long k_SpecTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SpecTypeID)) == false) {
				refSpecimenType ob = repository.GetQuery<refSpecimenType>().FirstOrDefault(o => o.SpecTypeID == k_SpecTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refSpecimenType obj = this[GetKey(k_SpecTypeID)];
            return (refSpecimenType)obj;
        }

		public refSpecimenType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refSpecimenType ob = this[keypair];
            return (refSpecimenType)ob;
        }

        public refSpecimenType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refSpecimenType ob = this[GetKey(keypair)];
            return (refSpecimenType)ob;
        }

		bool _LoadAll = false;
        public List<refSpecimenType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refSpecimenType>().ToList();
			foreach (refSpecimenType item in list) {
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

        ~KeyedrefSpecimenType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
