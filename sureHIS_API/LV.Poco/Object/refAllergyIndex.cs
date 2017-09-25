/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refAllergyIndex.cs         
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
	public partial class refAllergyIndex : BaseEntity, ICloneable	{
		public refAllergyIndex()
		{
			this.AllgIndexID = 0;
			this.AllgCategoryID = 0;
			this.H7AllgType = 0;
            this.IsFhir = false;
            this.IsOther = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AllgIndexID", AllgIndexID); } }


		private long _AllgIndexID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AllgIndexID { get { return _AllgIndexID; } set {_AllgIndexID = value; } }

		private string _AllgIndexName;
		[LVRequired]
        [LVMaxLength(50)]
        public string AllgIndexName { get { return _AllgIndexName; } set {_AllgIndexName = value; } }

		private long _AllgCategoryID;
		[LVRequired]
        public long AllgCategoryID { get { return _AllgCategoryID; } set {_AllgCategoryID = value; } }

		private long _H7AllgType;
		[LVRequired]
        public long H7AllgType { get { return _H7AllgType; } set {_H7AllgType = value; } }

		private bool _IsFhir;
        public bool IsFhir { get { return _IsFhir; } set {_IsFhir = value; } }

		private bool _IsOther;
        public bool IsOther { get { return _IsOther; } set {_IsOther = value; } }

		/// <summary>
/// Ref Key: FK_AllergyIntolerance_refAllergyIndex
/// <summary>
/// <summary>
/// Ref Key: FK_refAllergyIndex_refAllergyCategory
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
    public class KeyedrefAllergyIndex : KeyedCollection<KeyValuePair<string, long>, refAllergyIndex>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefAllergyIndex() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refAllergyIndex item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AllgIndexID) { return new KeyValuePair<string, long>("AllgIndexID", k_AllgIndexID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refAllergyIndex item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refAllergyIndex item)
        {
            refAllergyIndex orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refAllergyIndex item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refAllergyIndex item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refAllergyIndex GetObjectByKey(long k_AllgIndexID) 
		{
            if (this.Contains(GetKey(k_AllgIndexID)) == false) return null;
            refAllergyIndex ob = this[GetKey(k_AllgIndexID)];
            return (refAllergyIndex)ob;
        }

		public refAllergyIndex GetObjectByKey(long k_AllgIndexID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AllgIndexID)) == false) {
				refAllergyIndex ob = repository.GetQuery<refAllergyIndex>().FirstOrDefault(o => o.AllgIndexID == k_AllgIndexID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refAllergyIndex obj = this[GetKey(k_AllgIndexID)];
            return (refAllergyIndex)obj;
        }

		public refAllergyIndex GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refAllergyIndex ob = this[keypair];
            return (refAllergyIndex)ob;
        }

        public refAllergyIndex GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refAllergyIndex ob = this[GetKey(keypair)];
            return (refAllergyIndex)ob;
        }

		bool _LoadAll = false;
        public List<refAllergyIndex> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refAllergyIndex>().ToList();
			foreach (refAllergyIndex item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<refAllergyIndex> LoadIXFK_refAllergyIndex_refAllergyCategory(long p_AllgCategoryID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<refAllergyIndex>().Where(o=> o.AllgCategoryID == p_AllgCategoryID).ToList();
			foreach (refAllergyIndex item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
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

        ~KeyedrefAllergyIndex()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
