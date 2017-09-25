/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PtCodeCheckDigitTmp.cs         
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
	public partial class PtCodeCheckDigitTmp : BaseEntity, ICloneable	{
		public PtCodeCheckDigitTmp()
		{
			this.PtNum = 0;
			this.PtCodeCheckDigit = 0;
            this.IsUsed = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtNum", PtNum); } }


		private long _PtNum;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtNum { get { return _PtNum; } set {_PtNum = value; } }

		private long _PtCodeCheckDigit;
		[LVRequired]
        public long PtCodeCheckDigit { get { return _PtCodeCheckDigit; } set {_PtCodeCheckDigit = value; } }

		private bool? _IsUsed;
        public bool? IsUsed { get { return _IsUsed; } set {_IsUsed = value; } }

		

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
    public class KeyedPtCodeCheckDigitTmp : KeyedCollection<KeyValuePair<string, long>, PtCodeCheckDigitTmp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPtCodeCheckDigitTmp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PtCodeCheckDigitTmp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtNum) { return new KeyValuePair<string, long>("PtNum", k_PtNum); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PtCodeCheckDigitTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PtCodeCheckDigitTmp item)
        {
            PtCodeCheckDigitTmp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PtCodeCheckDigitTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PtCodeCheckDigitTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PtCodeCheckDigitTmp GetObjectByKey(long k_PtNum) 
		{
            if (this.Contains(GetKey(k_PtNum)) == false) return null;
            PtCodeCheckDigitTmp ob = this[GetKey(k_PtNum)];
            return (PtCodeCheckDigitTmp)ob;
        }

		public PtCodeCheckDigitTmp GetObjectByKey(long k_PtNum, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtNum)) == false) {
				PtCodeCheckDigitTmp ob = repository.GetQuery<PtCodeCheckDigitTmp>().FirstOrDefault(o => o.PtNum == k_PtNum);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PtCodeCheckDigitTmp obj = this[GetKey(k_PtNum)];
            return (PtCodeCheckDigitTmp)obj;
        }

		public PtCodeCheckDigitTmp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PtCodeCheckDigitTmp ob = this[keypair];
            return (PtCodeCheckDigitTmp)ob;
        }

        public PtCodeCheckDigitTmp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PtCodeCheckDigitTmp ob = this[GetKey(keypair)];
            return (PtCodeCheckDigitTmp)ob;
        }

		bool _LoadAll = false;
        public List<PtCodeCheckDigitTmp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PtCodeCheckDigitTmp>().ToList();
			foreach (PtCodeCheckDigitTmp item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<PtCodeCheckDigitTmp> LoadUQ_PtCodeCheckDigitTmp(long p_PtCodeCheckDigit, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<PtCodeCheckDigitTmp>().Where(o=> o.PtCodeCheckDigit == p_PtCodeCheckDigit).ToList();
			foreach (PtCodeCheckDigitTmp item in list) {
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

        ~KeyedPtCodeCheckDigitTmp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
