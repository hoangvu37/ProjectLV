/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refItemType.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class refItemType : BaseEntity, ICloneable	{
		public refItemType()
		{
			this.ItemTypeID = 0;
            this.ItemTypeDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ItemTypeID", ItemTypeID); } }


		private long _ItemTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ItemTypeID { get { return _ItemTypeID; } set {_ItemTypeID = value; } }

		private string _ItemTypeName;
		[LVRequired]
        [LVMaxLength(64)]
        public string ItemTypeName { get { return _ItemTypeName; } set {_ItemTypeName = value; } }

		private string _ItemTypeDesc;
        [LVMaxLength(1024)]
        public string ItemTypeDesc { get { return _ItemTypeDesc; } set {_ItemTypeDesc = value; } }

		/// <summary>
/// Ref Key: FK_DocItem_refItemType
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
    public class KeyedrefItemType : KeyedCollection<KeyValuePair<string, long>, refItemType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefItemType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refItemType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ItemTypeID) { return new KeyValuePair<string, long>("ItemTypeID", k_ItemTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refItemType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refItemType item)
        {
            refItemType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refItemType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refItemType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refItemType GetObjectByKey(long k_ItemTypeID) 
		{
            if (this.Contains(GetKey(k_ItemTypeID)) == false) return null;
            refItemType ob = this[GetKey(k_ItemTypeID)];
            return (refItemType)ob;
        }

		public refItemType GetObjectByKey(long k_ItemTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ItemTypeID)) == false) {
				refItemType ob = repository.GetQuery<refItemType>().FirstOrDefault(o => o.ItemTypeID == k_ItemTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refItemType obj = this[GetKey(k_ItemTypeID)];
            return (refItemType)obj;
        }

		public refItemType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refItemType ob = this[keypair];
            return (refItemType)ob;
        }

        public refItemType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refItemType ob = this[GetKey(keypair)];
            return (refItemType)ob;
        }

		bool _LoadAll = false;
        public List<refItemType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refItemType>().ToList();
			foreach (refItemType item in list) {
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

        ~KeyedrefItemType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
