/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalClaimService.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class MedicalClaimService : BaseEntity, ICloneable	{
		public MedicalClaimService()
		{
			this.MedClaimSerID = 0;
			this.AdmID = 0;
			this.MedSerID = 0;
			this.HosFeeTransID = 0;
            this.V_PmtStatus = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedClaimSerID", MedClaimSerID); } }


		private long _MedClaimSerID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedClaimSerID { get { return _MedClaimSerID; } set {_MedClaimSerID = value; } }

		private long _AdmID;
		[LVRequired]
        public long AdmID { get { return _AdmID; } set {_AdmID = value; } }

		private long? _MedSerID;
        public long? MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private long? _HosFeeTransID;
        public long? HosFeeTransID { get { return _HosFeeTransID; } set {_HosFeeTransID = value; } }

		private long? _V_PmtStatus;
        public long? V_PmtStatus { get { return _V_PmtStatus; } set {_V_PmtStatus = value; } }

		/// <summary>
/// Ref Key: FK_MedicalClaimService_HospitalFeeTransaction
/// <summary>
/// <summary>
/// Ref Key: FK_MedClaimService_MedServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalClaimService_PatientAdmission
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
    public class KeyedMedicalClaimService : KeyedCollection<KeyValuePair<string, long>, MedicalClaimService>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalClaimService() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalClaimService item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedClaimSerID) { return new KeyValuePair<string, long>("MedClaimSerID", k_MedClaimSerID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalClaimService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalClaimService item)
        {
            MedicalClaimService orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalClaimService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalClaimService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalClaimService GetObjectByKey(long k_MedClaimSerID) 
		{
            if (this.Contains(GetKey(k_MedClaimSerID)) == false) return null;
            MedicalClaimService ob = this[GetKey(k_MedClaimSerID)];
            return (MedicalClaimService)ob;
        }

		public MedicalClaimService GetObjectByKey(long k_MedClaimSerID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedClaimSerID)) == false) {
				MedicalClaimService ob = repository.GetQuery<MedicalClaimService>().FirstOrDefault(o => o.MedClaimSerID == k_MedClaimSerID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalClaimService obj = this[GetKey(k_MedClaimSerID)];
            return (MedicalClaimService)obj;
        }

		public MedicalClaimService GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalClaimService ob = this[keypair];
            return (MedicalClaimService)ob;
        }

        public MedicalClaimService GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalClaimService ob = this[GetKey(keypair)];
            return (MedicalClaimService)ob;
        }

		bool _LoadAll = false;
        public List<MedicalClaimService> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalClaimService>().ToList();
			foreach (MedicalClaimService item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<MedicalClaimService> LoadIXFK_MedicalClaimService_MedicalServiceItem(long p_MedSerID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<MedicalClaimService>().Where(o=> o.MedSerID == p_MedSerID).ToList();
			foreach (MedicalClaimService item in list) {
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

        ~KeyedMedicalClaimService()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
