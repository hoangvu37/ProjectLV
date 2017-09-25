/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refWard.cs         
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
	public partial class refWard : BaseEntity, ICloneable	{
		public refWard()
		{
            this.DistrictID = null;
            this.WardLevel = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("WardID", WardID); } }


		private string _DistrictID;
        [LVMaxLength(3)]
        public string DistrictID { get { return _DistrictID; } set {_DistrictID = value; } }

		private string _WardID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(5)]
        public string WardID { get { return _WardID; } set {_WardID = value; } }

		private string _WardName;
		[LVRequired]
        [LVMaxLength(128)]
        public string WardName { get { return _WardName; } set {_WardName = value; } }

		private string _WardLevel;
        [LVMaxLength(32)]
        public string WardLevel { get { return _WardLevel; } set {_WardLevel = value; } }

		/// <summary>
/// Ref Key: FK_Person_refWard
/// <summary>
/// <summary>
/// Ref Key: FK_refWard_refDistrict
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
    public class KeyedrefWard : KeyedCollection<KeyValuePair<string, string>, refWard>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefWard() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refWard item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_WardID) { return new KeyValuePair<string, string>("WardID", k_WardID); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refWard item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refWard item)
        {
            refWard orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refWard item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refWard item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refWard GetObjectByKey(string k_WardID) 
		{
            if (this.Contains(GetKey(k_WardID)) == false) return null;
            refWard ob = this[GetKey(k_WardID)];
            return (refWard)ob;
        }

		public refWard GetObjectByKey(string k_WardID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_WardID)) == false) {
				refWard ob = repository.GetQuery<refWard>().FirstOrDefault(o => o.WardID == k_WardID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refWard obj = this[GetKey(k_WardID)];
            return (refWard)obj;
        }

		public refWard GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refWard ob = this[keypair];
            return (refWard)ob;
        }

        public refWard GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refWard ob = this[GetKey(keypair)];
            return (refWard)ob;
        }

		bool _LoadAll = false;
        public List<refWard> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refWard>().ToList();
			foreach (refWard item in list) {
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

        ~KeyedrefWard()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
