/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refElthnic.cs         
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
	public partial class refElthnic : BaseEntity, ICloneable	{
		public refElthnic()
		{
			this.EthnicID = 0;
			this.PtEthnicGroupID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EthnicID", EthnicID); } }


		private long _EthnicID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EthnicID { get { return _EthnicID; } set {_EthnicID = value; } }

		private string _EthnicCode;
        [LVMaxLength(6)]
        public string EthnicCode { get { return _EthnicCode; } set {_EthnicCode = value; } }

		private string _EthnicName;
		[LVRequired]
        [LVMaxLength(23)]
        public string EthnicName { get { return _EthnicName; } set {_EthnicName = value; } }

		private string _VNEthnicName;
        [LVMaxLength(32)]
        public string VNEthnicName { get { return _VNEthnicName; } set {_VNEthnicName = value; } }

		private long _PtEthnicGroupID;
		[LVRequired]
        public long PtEthnicGroupID { get { return _PtEthnicGroupID; } set {_PtEthnicGroupID = value; } }

		/// <summary>
/// Ref Key: FK_Person_refElthnic
/// <summary>
/// <summary>
/// Ref Key: FK_refElthnic_refEthnicGroup
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
    public class KeyedrefElthnic : KeyedCollection<KeyValuePair<string, long>, refElthnic>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefElthnic() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refElthnic item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EthnicID) { return new KeyValuePair<string, long>("EthnicID", k_EthnicID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refElthnic item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refElthnic item)
        {
            refElthnic orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refElthnic item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refElthnic item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refElthnic GetObjectByKey(long k_EthnicID) 
		{
            if (this.Contains(GetKey(k_EthnicID)) == false) return null;
            refElthnic ob = this[GetKey(k_EthnicID)];
            return (refElthnic)ob;
        }

		public refElthnic GetObjectByKey(long k_EthnicID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EthnicID)) == false) {
				refElthnic ob = repository.GetQuery<refElthnic>().FirstOrDefault(o => o.EthnicID == k_EthnicID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refElthnic obj = this[GetKey(k_EthnicID)];
            return (refElthnic)obj;
        }

		public refElthnic GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refElthnic ob = this[keypair];
            return (refElthnic)ob;
        }

        public refElthnic GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refElthnic ob = this[GetKey(keypair)];
            return (refElthnic)ob;
        }

		bool _LoadAll = false;
        public List<refElthnic> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refElthnic>().ToList();
			foreach (refElthnic item in list) {
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

        ~KeyedrefElthnic()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
