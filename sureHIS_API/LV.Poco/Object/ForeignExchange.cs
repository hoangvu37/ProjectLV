/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ForeignExchange.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class ForeignExchange : BaseEntity, ICloneable	{
		public ForeignExchange()
		{
			this.FXID = 0;
            this.ValidFrom = DateTime.Now;
            this.CurCodeFrom = "USD";
            this.Multiply = true;
            this.ExchangeRate = 1;
            this.CurCodeTo = "VND";
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("FXID", FXID); } }


		private long _FXID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long FXID { get { return _FXID; } set {_FXID = value; } }

		private DateTime _ValidFrom;
		[LVRequired]
        public DateTime ValidFrom { get { return _ValidFrom; } set {_ValidFrom = value; } }

		private string _CurCodeFrom;
		[LVRequired]
        [LVMaxLength(3)]
        public string CurCodeFrom { get { return _CurCodeFrom; } set {_CurCodeFrom = value; } }

		private bool _Multiply;
        public bool Multiply { get { return _Multiply; } set {_Multiply = value; } }

		private double _ExchangeRate;
		[LVRequired]
        public double ExchangeRate { get { return _ExchangeRate; } set {_ExchangeRate = value; } }

		private string _CurCodeTo;
		[LVRequired]
        [LVMaxLength(3)]
        public string CurCodeTo { get { return _CurCodeTo; } set {_CurCodeTo = value; } }

		

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
    public class KeyedForeignExchange : KeyedCollection<KeyValuePair<string, long>, ForeignExchange>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedForeignExchange() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ForeignExchange item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_FXID) { return new KeyValuePair<string, long>("FXID", k_FXID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ForeignExchange item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ForeignExchange item)
        {
            ForeignExchange orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ForeignExchange item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ForeignExchange item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ForeignExchange GetObjectByKey(long k_FXID) 
		{
            if (this.Contains(GetKey(k_FXID)) == false) return null;
            ForeignExchange ob = this[GetKey(k_FXID)];
            return (ForeignExchange)ob;
        }

		public ForeignExchange GetObjectByKey(long k_FXID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_FXID)) == false) {
				ForeignExchange ob = repository.GetQuery<ForeignExchange>().FirstOrDefault(o => o.FXID == k_FXID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ForeignExchange obj = this[GetKey(k_FXID)];
            return (ForeignExchange)obj;
        }

		public ForeignExchange GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ForeignExchange ob = this[keypair];
            return (ForeignExchange)ob;
        }

        public ForeignExchange GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ForeignExchange ob = this[GetKey(keypair)];
            return (ForeignExchange)ob;
        }

		bool _LoadAll = false;
        public List<ForeignExchange> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ForeignExchange>().ToList();
			foreach (ForeignExchange item in list) {
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

        ~KeyedForeignExchange()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
