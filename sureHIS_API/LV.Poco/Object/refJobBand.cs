/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refJobBand.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class refJobBand : BaseEntity, ICloneable	{
		public refJobBand()
		{
			this.JBID = 0;
            this.JBDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("JBID", JBID); } }


		private long _JBID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long JBID { get { return _JBID; } set {_JBID = value; } }

		private string _JBName;
		[LVRequired]
        [LVMaxLength(128)]
        public string JBName { get { return _JBName; } set {_JBName = value; } }

		private string _JBDesc;
        [LVMaxLength(2048)]
        public string JBDesc { get { return _JBDesc; } set {_JBDesc = value; } }

		/// <summary>
/// Ref Key: FK_refJobTitle_refJobBand
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
    public class KeyedrefJobBand : KeyedCollection<KeyValuePair<string, long>, refJobBand>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefJobBand() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refJobBand item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_JBID) { return new KeyValuePair<string, long>("JBID", k_JBID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refJobBand item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refJobBand item)
        {
            refJobBand orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refJobBand item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refJobBand item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refJobBand GetObjectByKey(long k_JBID) 
		{
            if (this.Contains(GetKey(k_JBID)) == false) return null;
            refJobBand ob = this[GetKey(k_JBID)];
            return (refJobBand)ob;
        }

		public refJobBand GetObjectByKey(long k_JBID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_JBID)) == false) {
				refJobBand ob = repository.GetQuery<refJobBand>().FirstOrDefault(o => o.JBID == k_JBID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refJobBand obj = this[GetKey(k_JBID)];
            return (refJobBand)obj;
        }

		public refJobBand GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refJobBand ob = this[keypair];
            return (refJobBand)ob;
        }

        public refJobBand GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refJobBand ob = this[GetKey(keypair)];
            return (refJobBand)ob;
        }

		bool _LoadAll = false;
        public List<refJobBand> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refJobBand>().ToList();
			foreach (refJobBand item in list) {
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

        ~KeyedrefJobBand()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
