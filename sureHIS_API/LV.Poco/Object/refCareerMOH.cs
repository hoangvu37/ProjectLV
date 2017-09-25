/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refCareerMOH.cs         
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
	public partial class refCareerMOH : BaseEntity, ICloneable	{
		public refCareerMOH()
		{
			this.CareerMOHID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("CareerMOHID", CareerMOHID); } }


		private long _CareerMOHID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long CareerMOHID { get { return _CareerMOHID; } set {_CareerMOHID = value; } }

		private string _CareerMOHCode;
		[LVRequired]
        [LVMaxLength(7)]
        public string CareerMOHCode { get { return _CareerMOHCode; } set {_CareerMOHCode = value; } }

		private string _CareerName;
		[LVRequired]
        [LVMaxLength(512)]
        public string CareerName { get { return _CareerName; } set {_CareerName = value; } }

		/// <summary>
/// Ref Key: FK_OccCareerMOH_refCareerMOH
/// <summary>
/// <summary>
/// Ref Key: FK_Patient_refCareerMOH
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
    public class KeyedrefCareerMOH : KeyedCollection<KeyValuePair<string, long>, refCareerMOH>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefCareerMOH() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refCareerMOH item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_CareerMOHID) { return new KeyValuePair<string, long>("CareerMOHID", k_CareerMOHID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refCareerMOH item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refCareerMOH item)
        {
            refCareerMOH orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refCareerMOH item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refCareerMOH item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refCareerMOH GetObjectByKey(long k_CareerMOHID) 
		{
            if (this.Contains(GetKey(k_CareerMOHID)) == false) return null;
            refCareerMOH ob = this[GetKey(k_CareerMOHID)];
            return (refCareerMOH)ob;
        }

		public refCareerMOH GetObjectByKey(long k_CareerMOHID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_CareerMOHID)) == false) {
				refCareerMOH ob = repository.GetQuery<refCareerMOH>().FirstOrDefault(o => o.CareerMOHID == k_CareerMOHID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refCareerMOH obj = this[GetKey(k_CareerMOHID)];
            return (refCareerMOH)obj;
        }

		public refCareerMOH GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refCareerMOH ob = this[keypair];
            return (refCareerMOH)ob;
        }

        public refCareerMOH GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refCareerMOH ob = this[GetKey(keypair)];
            return (refCareerMOH)ob;
        }

		bool _LoadAll = false;
        public List<refCareerMOH> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refCareerMOH>().ToList();
			foreach (refCareerMOH item in list) {
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

        ~KeyedrefCareerMOH()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
