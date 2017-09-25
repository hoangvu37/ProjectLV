/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ContractChange.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class ContractChange : BaseEntity, ICloneable	{
		public ContractChange()
		{
			this.KChangeID = 0;
			this.EstEmpID = 0;
			this.KID = 0;
            this.ChangeLog = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("KChangeID", KChangeID); } }


		private long _KChangeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long KChangeID { get { return _KChangeID; } set {_KChangeID = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private long _KID;
		[LVRequired]
        public long KID { get { return _KID; } set {_KID = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private string _ChangeLog;
        [LVMaxLength(1024)]
        public string ChangeLog { get { return _ChangeLog; } set {_ChangeLog = value; } }

		/// <summary>
/// Ref Key: FK_ContractChange_Contract
/// <summary>
/// <summary>
/// Ref Key: FK_ContractDocument_ContractChange
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
    public class KeyedContractChange : KeyedCollection<KeyValuePair<string, long>, ContractChange>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedContractChange() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ContractChange item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_KChangeID) { return new KeyValuePair<string, long>("KChangeID", k_KChangeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ContractChange item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ContractChange item)
        {
            ContractChange orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ContractChange item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ContractChange item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ContractChange GetObjectByKey(long k_KChangeID) 
		{
            if (this.Contains(GetKey(k_KChangeID)) == false) return null;
            ContractChange ob = this[GetKey(k_KChangeID)];
            return (ContractChange)ob;
        }

		public ContractChange GetObjectByKey(long k_KChangeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_KChangeID)) == false) {
				ContractChange ob = repository.GetQuery<ContractChange>().FirstOrDefault(o => o.KChangeID == k_KChangeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ContractChange obj = this[GetKey(k_KChangeID)];
            return (ContractChange)obj;
        }

		public ContractChange GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ContractChange ob = this[keypair];
            return (ContractChange)ob;
        }

        public ContractChange GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ContractChange ob = this[GetKey(keypair)];
            return (ContractChange)ob;
        }

		bool _LoadAll = false;
        public List<ContractChange> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ContractChange>().ToList();
			foreach (ContractChange item in list) {
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

        ~KeyedContractChange()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
