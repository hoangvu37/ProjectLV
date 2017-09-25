/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refDepreciationType.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class refDepreciationType : BaseEntity, ICloneable	{
		public refDepreciationType()
		{
			this.DeprecTypeID = 0;
            this.DeprecDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, int> Key { get { return new KeyValuePair<string, int>("DeprecTypeID", DeprecTypeID); } }


		private int _DeprecTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public int DeprecTypeID { get { return _DeprecTypeID; } set {_DeprecTypeID = value; } }

		private string _DeprecTypeName;
		[LVRequired]
        [LVMaxLength(128)]
        public string DeprecTypeName { get { return _DeprecTypeName; } set {_DeprecTypeName = value; } }

		private string _DeprecDesc;
        [LVMaxLength(2048)]
        public string DeprecDesc { get { return _DeprecDesc; } set {_DeprecDesc = value; } }

		/// <summary>
/// Ref Key: FK_Resource_refDepreciationType
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
    public class KeyedrefDepreciationType : KeyedCollection<KeyValuePair<string, int>, refDepreciationType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefDepreciationType() : base() { }

        protected override KeyValuePair<string, int> GetKeyForItem(refDepreciationType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, int> GetKey(int k_DeprecTypeID) { return new KeyValuePair<string, int>("DeprecTypeID", k_DeprecTypeID); }

        public KeyValuePair<string, int> GetKey(object keypair) { try { return (KeyValuePair<string, int>)keypair; } catch { return new KeyValuePair<string, int>(); } }
        #endregion

        #region Method
        public bool AddObject(refDepreciationType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, int> keypair, refDepreciationType item)
        {
            refDepreciationType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refDepreciationType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refDepreciationType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refDepreciationType GetObjectByKey(int k_DeprecTypeID) 
		{
            if (this.Contains(GetKey(k_DeprecTypeID)) == false) return null;
            refDepreciationType ob = this[GetKey(k_DeprecTypeID)];
            return (refDepreciationType)ob;
        }

		public refDepreciationType GetObjectByKey(int k_DeprecTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DeprecTypeID)) == false) {
				refDepreciationType ob = repository.GetQuery<refDepreciationType>().FirstOrDefault(o => o.DeprecTypeID == k_DeprecTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refDepreciationType obj = this[GetKey(k_DeprecTypeID)];
            return (refDepreciationType)obj;
        }

		public refDepreciationType GetObjectByKey(KeyValuePair<string, int> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refDepreciationType ob = this[keypair];
            return (refDepreciationType)ob;
        }

        public refDepreciationType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refDepreciationType ob = this[GetKey(keypair)];
            return (refDepreciationType)ob;
        }

		bool _LoadAll = false;
        public List<refDepreciationType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refDepreciationType>().ToList();
			foreach (refDepreciationType item in list) {
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

        ~KeyedrefDepreciationType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
