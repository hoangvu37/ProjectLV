/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refAllergyCategory.cs         
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
	public partial class refAllergyCategory : BaseEntity, ICloneable	{
		public refAllergyCategory()
		{
			this.AllgCategoryID = 0;
            this.VNAllgCategoryName = null;
            this.IsFhir = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AllgCategoryID", AllgCategoryID); } }


		private long _AllgCategoryID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AllgCategoryID { get { return _AllgCategoryID; } set {_AllgCategoryID = value; } }

		private string _AllgCategoryCode;
		[LVRequired]
        [LVMaxLength(11)]
        public string AllgCategoryCode { get { return _AllgCategoryCode; } set {_AllgCategoryCode = value; } }

		private string _AllgCategoryName;
		[LVRequired]
        [LVMaxLength(40)]
        public string AllgCategoryName { get { return _AllgCategoryName; } set {_AllgCategoryName = value; } }

		private string _VNAllgCategoryName;
        [LVMaxLength(40)]
        public string VNAllgCategoryName { get { return _VNAllgCategoryName; } set {_VNAllgCategoryName = value; } }

		private bool _IsFhir;
        public bool IsFhir { get { return _IsFhir; } set {_IsFhir = value; } }

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
    public class KeyedrefAllergyCategory : KeyedCollection<KeyValuePair<string, long>, refAllergyCategory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefAllergyCategory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refAllergyCategory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AllgCategoryID) { return new KeyValuePair<string, long>("AllgCategoryID", k_AllgCategoryID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refAllergyCategory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refAllergyCategory item)
        {
            refAllergyCategory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refAllergyCategory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refAllergyCategory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refAllergyCategory GetObjectByKey(long k_AllgCategoryID) 
		{
            if (this.Contains(GetKey(k_AllgCategoryID)) == false) return null;
            refAllergyCategory ob = this[GetKey(k_AllgCategoryID)];
            return (refAllergyCategory)ob;
        }

		public refAllergyCategory GetObjectByKey(long k_AllgCategoryID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AllgCategoryID)) == false) {
				refAllergyCategory ob = repository.GetQuery<refAllergyCategory>().FirstOrDefault(o => o.AllgCategoryID == k_AllgCategoryID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refAllergyCategory obj = this[GetKey(k_AllgCategoryID)];
            return (refAllergyCategory)obj;
        }

		public refAllergyCategory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refAllergyCategory ob = this[keypair];
            return (refAllergyCategory)ob;
        }

        public refAllergyCategory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refAllergyCategory ob = this[GetKey(keypair)];
            return (refAllergyCategory)ob;
        }

		bool _LoadAll = false;
        public List<refAllergyCategory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refAllergyCategory>().ToList();
			foreach (refAllergyCategory item in list) {
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

        ~KeyedrefAllergyCategory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
