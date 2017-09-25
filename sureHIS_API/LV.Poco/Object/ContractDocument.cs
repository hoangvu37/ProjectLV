/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ContractDocument.cs         
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
	public partial class ContractDocument : BaseEntity, ICloneable	{
		public ContractDocument()
		{
			this.KDocID = 0;
			this.KID = 0;
			this.StdKSectD = 0;
            this.KChangeID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("KDocID", KDocID); } }


		private long _KDocID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long KDocID { get { return _KDocID; } set {_KDocID = value; } }

		private long _KID;
		[LVRequired]
        public long KID { get { return _KID; } set {_KID = value; } }

		private long _StdKSectD;
		[LVRequired]
        public long StdKSectD { get { return _StdKSectD; } set {_StdKSectD = value; } }

		private string _Notes;
        [LVMaxLength(512)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private long? _KChangeID;
        public long? KChangeID { get { return _KChangeID; } set {_KChangeID = value; } }

		/// <summary>
/// Ref Key: FK_ContractDocument_Contract
/// <summary>
/// <summary>
/// Ref Key: FK_ContractDocument_ContractChange
/// <summary>
/// <summary>
/// Ref Key: FK_ContractDocument_StdKSection
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
    public class KeyedContractDocument : KeyedCollection<KeyValuePair<string, long>, ContractDocument>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedContractDocument() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ContractDocument item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_KDocID) { return new KeyValuePair<string, long>("KDocID", k_KDocID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ContractDocument item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ContractDocument item)
        {
            ContractDocument orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ContractDocument item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ContractDocument item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ContractDocument GetObjectByKey(long k_KDocID) 
		{
            if (this.Contains(GetKey(k_KDocID)) == false) return null;
            ContractDocument ob = this[GetKey(k_KDocID)];
            return (ContractDocument)ob;
        }

		public ContractDocument GetObjectByKey(long k_KDocID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_KDocID)) == false) {
				ContractDocument ob = repository.GetQuery<ContractDocument>().FirstOrDefault(o => o.KDocID == k_KDocID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ContractDocument obj = this[GetKey(k_KDocID)];
            return (ContractDocument)obj;
        }

		public ContractDocument GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ContractDocument ob = this[keypair];
            return (ContractDocument)ob;
        }

        public ContractDocument GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ContractDocument ob = this[GetKey(keypair)];
            return (ContractDocument)ob;
        }

		bool _LoadAll = false;
        public List<ContractDocument> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ContractDocument>().ToList();
			foreach (ContractDocument item in list) {
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

        ~KeyedContractDocument()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
