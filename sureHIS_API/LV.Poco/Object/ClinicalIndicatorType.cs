/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ClinicalIndicatorType.cs         
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
	public partial class ClinicalIndicatorType : BaseEntity, ICloneable	{
		public ClinicalIndicatorType()
		{
			this.ClinIndTypeID = 0;
            this.ClinIndTypeDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ClinIndTypeID", ClinIndTypeID); } }


		private long _ClinIndTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ClinIndTypeID { get { return _ClinIndTypeID; } set {_ClinIndTypeID = value; } }

		private string _ClinIndTypeName;
		[LVRequired]
        [LVMaxLength(64)]
        public string ClinIndTypeName { get { return _ClinIndTypeName; } set {_ClinIndTypeName = value; } }

		private string _ClinIndTypeDesc;
        [LVMaxLength(1024)]
        public string ClinIndTypeDesc { get { return _ClinIndTypeDesc; } set {_ClinIndTypeDesc = value; } }

		/// <summary>
/// Ref Key: FK_ParaClinicalExamType_ClinicalIndicatorType
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
    public class KeyedClinicalIndicatorType : KeyedCollection<KeyValuePair<string, long>, ClinicalIndicatorType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedClinicalIndicatorType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ClinicalIndicatorType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ClinIndTypeID) { return new KeyValuePair<string, long>("ClinIndTypeID", k_ClinIndTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ClinicalIndicatorType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ClinicalIndicatorType item)
        {
            ClinicalIndicatorType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ClinicalIndicatorType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ClinicalIndicatorType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ClinicalIndicatorType GetObjectByKey(long k_ClinIndTypeID) 
		{
            if (this.Contains(GetKey(k_ClinIndTypeID)) == false) return null;
            ClinicalIndicatorType ob = this[GetKey(k_ClinIndTypeID)];
            return (ClinicalIndicatorType)ob;
        }

		public ClinicalIndicatorType GetObjectByKey(long k_ClinIndTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ClinIndTypeID)) == false) {
				ClinicalIndicatorType ob = repository.GetQuery<ClinicalIndicatorType>().FirstOrDefault(o => o.ClinIndTypeID == k_ClinIndTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ClinicalIndicatorType obj = this[GetKey(k_ClinIndTypeID)];
            return (ClinicalIndicatorType)obj;
        }

		public ClinicalIndicatorType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ClinicalIndicatorType ob = this[keypair];
            return (ClinicalIndicatorType)ob;
        }

        public ClinicalIndicatorType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ClinicalIndicatorType ob = this[GetKey(keypair)];
            return (ClinicalIndicatorType)ob;
        }

		bool _LoadAll = false;
        public List<ClinicalIndicatorType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ClinicalIndicatorType>().ToList();
			foreach (ClinicalIndicatorType item in list) {
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

        ~KeyedClinicalIndicatorType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
