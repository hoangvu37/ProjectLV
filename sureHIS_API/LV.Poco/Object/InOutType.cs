/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : InOutType.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class InOutType : BaseEntity, ICloneable	{
		public InOutType()
		{
			this.IOTypeID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("IOTypeID", IOTypeID); } }


		private long _IOTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long IOTypeID { get { return _IOTypeID; } set {_IOTypeID = value; } }

		private string _IOTypeName;
		[LVRequired]
        [LVMaxLength(100)]
        public string IOTypeName { get { return _IOTypeName; } set {_IOTypeName = value; } }

		private bool _IOType;
        public bool IOType { get { return _IOType; } set {_IOType = value; } }

		/// <summary>
/// Ref Key: FK_InOutwardDrug_InOutType
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
    public class KeyedInOutType : KeyedCollection<KeyValuePair<string, long>, InOutType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedInOutType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(InOutType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_IOTypeID) { return new KeyValuePair<string, long>("IOTypeID", k_IOTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(InOutType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, InOutType item)
        {
            InOutType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(InOutType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(InOutType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public InOutType GetObjectByKey(long k_IOTypeID) 
		{
            if (this.Contains(GetKey(k_IOTypeID)) == false) return null;
            InOutType ob = this[GetKey(k_IOTypeID)];
            return (InOutType)ob;
        }

		public InOutType GetObjectByKey(long k_IOTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_IOTypeID)) == false) {
				InOutType ob = repository.GetQuery<InOutType>().FirstOrDefault(o => o.IOTypeID == k_IOTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            InOutType obj = this[GetKey(k_IOTypeID)];
            return (InOutType)obj;
        }

		public InOutType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            InOutType ob = this[keypair];
            return (InOutType)ob;
        }

        public InOutType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            InOutType ob = this[GetKey(keypair)];
            return (InOutType)ob;
        }

		bool _LoadAll = false;
        public List<InOutType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<InOutType>().ToList();
			foreach (InOutType item in list) {
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

        ~KeyedInOutType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
