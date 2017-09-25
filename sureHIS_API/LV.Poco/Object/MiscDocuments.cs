/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MiscDocuments.cs         
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
	public partial class MiscDocuments : BaseEntity, ICloneable	{
		public MiscDocuments()
		{
			this.MiscDocID = 0;
			this.PtComMedRecID = 0;
			this.IAdmReferralTypeCode = 0;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MiscDocID", MiscDocID); } }


		private long _MiscDocID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MiscDocID { get { return _MiscDocID; } set {_MiscDocID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long _IAdmReferralTypeCode;
		[LVRequired]
        public long IAdmReferralTypeCode { get { return _IAdmReferralTypeCode; } set {_IAdmReferralTypeCode = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_MiscDocuments_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_MiscDocuments_refAdmReferralType
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
    public class KeyedMiscDocuments : KeyedCollection<KeyValuePair<string, long>, MiscDocuments>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMiscDocuments() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MiscDocuments item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MiscDocID) { return new KeyValuePair<string, long>("MiscDocID", k_MiscDocID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MiscDocuments item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MiscDocuments item)
        {
            MiscDocuments orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MiscDocuments item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MiscDocuments item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MiscDocuments GetObjectByKey(long k_MiscDocID) 
		{
            if (this.Contains(GetKey(k_MiscDocID)) == false) return null;
            MiscDocuments ob = this[GetKey(k_MiscDocID)];
            return (MiscDocuments)ob;
        }

		public MiscDocuments GetObjectByKey(long k_MiscDocID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MiscDocID)) == false) {
				MiscDocuments ob = repository.GetQuery<MiscDocuments>().FirstOrDefault(o => o.MiscDocID == k_MiscDocID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MiscDocuments obj = this[GetKey(k_MiscDocID)];
            return (MiscDocuments)obj;
        }

		public MiscDocuments GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MiscDocuments ob = this[keypair];
            return (MiscDocuments)ob;
        }

        public MiscDocuments GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MiscDocuments ob = this[GetKey(keypair)];
            return (MiscDocuments)ob;
        }

		bool _LoadAll = false;
        public List<MiscDocuments> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MiscDocuments>().ToList();
			foreach (MiscDocuments item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<MiscDocuments> LoadIXFK_MiscDocuments_PatientCommonMedRecord(long p_PtComMedRecID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<MiscDocuments>().Where(o=> o.PtComMedRecID == p_PtComMedRecID).ToList();
			foreach (MiscDocuments item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
            return list;
		}
			
		public List<MiscDocuments> LoadIXFK_MiscDocuments_refAdmReferralType(long p_IAdmReferralTypeCode, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<MiscDocuments>().Where(o=> o.IAdmReferralTypeCode == p_IAdmReferralTypeCode).ToList();
			foreach (MiscDocuments item in list) {
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

        ~KeyedMiscDocuments()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
