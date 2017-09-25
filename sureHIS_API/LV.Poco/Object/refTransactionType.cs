/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refTransactionType.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class refTransactionType : BaseEntity, ICloneable	{
		public refTransactionType()
		{
			this.TransTypeID = 0;
            this.TransTypeDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("TransTypeID", TransTypeID); } }


		private long _TransTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long TransTypeID { get { return _TransTypeID; } set {_TransTypeID = value; } }

		private string _TransTypeName;
		[LVRequired]
        [LVMaxLength(128)]
        public string TransTypeName { get { return _TransTypeName; } set {_TransTypeName = value; } }

		private string _TransTypeDesc;
        [LVMaxLength(1024)]
        public string TransTypeDesc { get { return _TransTypeDesc; } set {_TransTypeDesc = value; } }

		/// <summary>
/// Ref Key: FK_PatientTransaction_refTransactionType
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
    public class KeyedrefTransactionType : KeyedCollection<KeyValuePair<string, long>, refTransactionType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefTransactionType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refTransactionType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_TransTypeID) { return new KeyValuePair<string, long>("TransTypeID", k_TransTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refTransactionType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refTransactionType item)
        {
            refTransactionType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refTransactionType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refTransactionType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refTransactionType GetObjectByKey(long k_TransTypeID) 
		{
            if (this.Contains(GetKey(k_TransTypeID)) == false) return null;
            refTransactionType ob = this[GetKey(k_TransTypeID)];
            return (refTransactionType)ob;
        }

		public refTransactionType GetObjectByKey(long k_TransTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_TransTypeID)) == false) {
				refTransactionType ob = repository.GetQuery<refTransactionType>().FirstOrDefault(o => o.TransTypeID == k_TransTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refTransactionType obj = this[GetKey(k_TransTypeID)];
            return (refTransactionType)obj;
        }

		public refTransactionType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refTransactionType ob = this[keypair];
            return (refTransactionType)ob;
        }

        public refTransactionType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refTransactionType ob = this[GetKey(keypair)];
            return (refTransactionType)ob;
        }

		bool _LoadAll = false;
        public List<refTransactionType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refTransactionType>().ToList();
			foreach (refTransactionType item in list) {
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

        ~KeyedrefTransactionType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
