/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refCurrency.cs         
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
	public partial class refCurrency : BaseEntity, ICloneable	{
		public refCurrency()
		{
            this.CurDesc = null;
            this.CurNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("CurCode", CurCode); } }


		private string _CurCode;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(3)]
        public string CurCode { get { return _CurCode; } set {_CurCode = value; } }

		private string _CurName;
		[LVRequired]
        [LVMaxLength(64)]
        public string CurName { get { return _CurName; } set {_CurName = value; } }

		private string _CurDesc;
        [LVMaxLength(64)]
        public string CurDesc { get { return _CurDesc; } set {_CurDesc = value; } }

		private string _CurNotes;
        [LVMaxLength(128)]
        public string CurNotes { get { return _CurNotes; } set {_CurNotes = value; } }

		/// <summary>
/// Ref Key: FK_Quotation_refCurrency
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
    public class KeyedrefCurrency : KeyedCollection<KeyValuePair<string, string>, refCurrency>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefCurrency() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refCurrency item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_CurCode) { return new KeyValuePair<string, string>("CurCode", k_CurCode); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refCurrency item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refCurrency item)
        {
            refCurrency orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refCurrency item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refCurrency item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refCurrency GetObjectByKey(string k_CurCode) 
		{
            if (this.Contains(GetKey(k_CurCode)) == false) return null;
            refCurrency ob = this[GetKey(k_CurCode)];
            return (refCurrency)ob;
        }

		public refCurrency GetObjectByKey(string k_CurCode, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_CurCode)) == false) {
				refCurrency ob = repository.GetQuery<refCurrency>().FirstOrDefault(o => o.CurCode == k_CurCode);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refCurrency obj = this[GetKey(k_CurCode)];
            return (refCurrency)obj;
        }

		public refCurrency GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refCurrency ob = this[keypair];
            return (refCurrency)ob;
        }

        public refCurrency GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refCurrency ob = this[GetKey(keypair)];
            return (refCurrency)ob;
        }

		bool _LoadAll = false;
        public List<refCurrency> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refCurrency>().ToList();
			foreach (refCurrency item in list) {
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

        ~KeyedrefCurrency()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
