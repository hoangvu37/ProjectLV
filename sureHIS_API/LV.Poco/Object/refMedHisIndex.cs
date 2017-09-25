/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refMedHisIndex.cs         
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
	public partial class refMedHisIndex : BaseEntity, ICloneable	{
		public refMedHisIndex()
		{
			this.MHIndexID = 0;
            this.IsPastHis = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MHIndexID", MHIndexID); } }


		private long _MHIndexID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MHIndexID { get { return _MHIndexID; } set {_MHIndexID = value; } }

		private string _MHIndexName;
		[LVRequired]
        [LVMaxLength(50)]
        public string MHIndexName { get { return _MHIndexName; } set {_MHIndexName = value; } }

		private bool _IsPastHis;
        public bool IsPastHis { get { return _IsPastHis; } set {_IsPastHis = value; } }

		/// <summary>
/// Ref Key: FK_PastPersonHistory_refMedHisIndex
/// <summary>
/// <summary>
/// Ref Key: FK_refSocialHisSeverity_refMedHisIndex
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
    public class KeyedrefMedHisIndex : KeyedCollection<KeyValuePair<string, long>, refMedHisIndex>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefMedHisIndex() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refMedHisIndex item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MHIndexID) { return new KeyValuePair<string, long>("MHIndexID", k_MHIndexID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refMedHisIndex item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refMedHisIndex item)
        {
            refMedHisIndex orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refMedHisIndex item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refMedHisIndex item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refMedHisIndex GetObjectByKey(long k_MHIndexID) 
		{
            if (this.Contains(GetKey(k_MHIndexID)) == false) return null;
            refMedHisIndex ob = this[GetKey(k_MHIndexID)];
            return (refMedHisIndex)ob;
        }

		public refMedHisIndex GetObjectByKey(long k_MHIndexID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MHIndexID)) == false) {
				refMedHisIndex ob = repository.GetQuery<refMedHisIndex>().FirstOrDefault(o => o.MHIndexID == k_MHIndexID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refMedHisIndex obj = this[GetKey(k_MHIndexID)];
            return (refMedHisIndex)obj;
        }

		public refMedHisIndex GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refMedHisIndex ob = this[keypair];
            return (refMedHisIndex)ob;
        }

        public refMedHisIndex GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refMedHisIndex ob = this[GetKey(keypair)];
            return (refMedHisIndex)ob;
        }

		bool _LoadAll = false;
        public List<refMedHisIndex> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refMedHisIndex>().ToList();
			foreach (refMedHisIndex item in list) {
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

        ~KeyedrefMedHisIndex()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
