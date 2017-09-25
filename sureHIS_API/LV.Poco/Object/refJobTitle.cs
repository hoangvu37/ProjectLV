/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refJobTitle.cs         
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
	public partial class refJobTitle : BaseEntity, ICloneable	{
		public refJobTitle()
		{
            this.PJTID = null;
			this.JTID = 0;
			this.JBID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("JTID", JTID); } }


		private long? _PJTID;
        public long? PJTID { get { return _PJTID; } set {_PJTID = value; } }

		private long _JTID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long JTID { get { return _JTID; } set {_JTID = value; } }

		private string _JTCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string JTCode { get { return _JTCode; } set {_JTCode = value; } }

		private string _JTName;
		[LVRequired]
        [LVMaxLength(64)]
        public string JTName { get { return _JTName; } set {_JTName = value; } }

		private string _JTDef;
        [LVMaxLength(1024)]
        public string JTDef { get { return _JTDef; } set {_JTDef = value; } }

		private string _JTResp;
        public string JTResp { get { return _JTResp; } set {_JTResp = value; } }

		private string _JTScopeDesc;
        [LVMaxLength(2048)]
        public string JTScopeDesc { get { return _JTScopeDesc; } set {_JTScopeDesc = value; } }

		private long? _JBID;
        public long? JBID { get { return _JBID; } set {_JBID = value; } }

		/// <summary>
/// Ref Key: FK_Employee_refJobTitle
/// <summary>
/// <summary>
/// Ref Key: FK_JobModel_refJobTitle
/// <summary>
/// <summary>
/// Ref Key: FK_refJobTitle_refJobBand
/// <summary>
/// <summary>
/// Ref Key: FK_refJobTitle_refJobTitle
/// <summary>
/// <summary>
/// Ref Key: FK_refJobTitle_refJobTitle
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
    public class KeyedrefJobTitle : KeyedCollection<KeyValuePair<string, long>, refJobTitle>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefJobTitle() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refJobTitle item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_JTID) { return new KeyValuePair<string, long>("JTID", k_JTID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refJobTitle item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refJobTitle item)
        {
            refJobTitle orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refJobTitle item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refJobTitle item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refJobTitle GetObjectByKey(long k_JTID) 
		{
            if (this.Contains(GetKey(k_JTID)) == false) return null;
            refJobTitle ob = this[GetKey(k_JTID)];
            return (refJobTitle)ob;
        }

		public refJobTitle GetObjectByKey(long k_JTID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_JTID)) == false) {
				refJobTitle ob = repository.GetQuery<refJobTitle>().FirstOrDefault(o => o.JTID == k_JTID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refJobTitle obj = this[GetKey(k_JTID)];
            return (refJobTitle)obj;
        }

		public refJobTitle GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refJobTitle ob = this[keypair];
            return (refJobTitle)ob;
        }

        public refJobTitle GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refJobTitle ob = this[GetKey(keypair)];
            return (refJobTitle)ob;
        }

		bool _LoadAll = false;
        public List<refJobTitle> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refJobTitle>().ToList();
			foreach (refJobTitle item in list) {
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

        ~KeyedrefJobTitle()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
