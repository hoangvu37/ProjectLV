/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refPersMaritalStatus.cs         
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
	public partial class refPersMaritalStatus : BaseEntity, ICloneable	{
		public refPersMaritalStatus()
		{
			this.PersMaritalStatusID = 0;
            this.is7 = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PersMaritalStatusID", PersMaritalStatusID); } }


		private long _PersMaritalStatusID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PersMaritalStatusID { get { return _PersMaritalStatusID; } set {_PersMaritalStatusID = value; } }

		private string _PersMaritalStatusCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string PersMaritalStatusCode { get { return _PersMaritalStatusCode; } set {_PersMaritalStatusCode = value; } }

		private string _PersMaritalStatusName;
		[LVRequired]
        [LVMaxLength(40)]
        public string PersMaritalStatusName { get { return _PersMaritalStatusName; } set {_PersMaritalStatusName = value; } }

		private string _VNPersMaritalStatusName;
        [LVMaxLength(64)]
        public string VNPersMaritalStatusName { get { return _VNPersMaritalStatusName; } set {_VNPersMaritalStatusName = value; } }

		private bool? _is7;
        public bool? is7 { get { return _is7; } set {_is7 = value; } }

		/// <summary>
/// Ref Key: FK_Person_refPersMaritalStatus
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
    public class KeyedrefPersMaritalStatus : KeyedCollection<KeyValuePair<string, long>, refPersMaritalStatus>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefPersMaritalStatus() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refPersMaritalStatus item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PersMaritalStatusID) { return new KeyValuePair<string, long>("PersMaritalStatusID", k_PersMaritalStatusID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refPersMaritalStatus item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refPersMaritalStatus item)
        {
            refPersMaritalStatus orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refPersMaritalStatus item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refPersMaritalStatus item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refPersMaritalStatus GetObjectByKey(long k_PersMaritalStatusID) 
		{
            if (this.Contains(GetKey(k_PersMaritalStatusID)) == false) return null;
            refPersMaritalStatus ob = this[GetKey(k_PersMaritalStatusID)];
            return (refPersMaritalStatus)ob;
        }

		public refPersMaritalStatus GetObjectByKey(long k_PersMaritalStatusID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PersMaritalStatusID)) == false) {
				refPersMaritalStatus ob = repository.GetQuery<refPersMaritalStatus>().FirstOrDefault(o => o.PersMaritalStatusID == k_PersMaritalStatusID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refPersMaritalStatus obj = this[GetKey(k_PersMaritalStatusID)];
            return (refPersMaritalStatus)obj;
        }

		public refPersMaritalStatus GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refPersMaritalStatus ob = this[keypair];
            return (refPersMaritalStatus)ob;
        }

        public refPersMaritalStatus GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refPersMaritalStatus ob = this[GetKey(keypair)];
            return (refPersMaritalStatus)ob;
        }

		bool _LoadAll = false;
        public List<refPersMaritalStatus> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refPersMaritalStatus>().ToList();
			foreach (refPersMaritalStatus item in list) {
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

        ~KeyedrefPersMaritalStatus()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
