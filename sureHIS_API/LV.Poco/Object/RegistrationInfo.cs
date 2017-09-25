/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : RegistrationInfo.cs         
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
	public partial class RegistrationInfo : BaseEntity, ICloneable	{
		public RegistrationInfo()
		{
			this.RegInfoID = 0;
            this.PtID = null;
            this.PPN = null;
            this.ReqCfmBySMS = true;
            this.OTP = null;
			this.Gender = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RegInfoID", RegInfoID); } }


		private long _RegInfoID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RegInfoID { get { return _RegInfoID; } set {_RegInfoID = value; } }

		private long? _PtID;
        public long? PtID { get { return _PtID; } set {_PtID = value; } }

		private string _LastName;
		[LVRequired]
        [LVMaxLength(96)]
        public string LastName { get { return _LastName; } set {_LastName = value; } }

		private string _FirstName;
		[LVRequired]
        [LVMaxLength(15)]
        public string FirstName { get { return _FirstName; } set {_FirstName = value; } }

		private string _MobilePhoneNumber;
		[LVRequired]
        [LVMaxLength(13)]
        public string MobilePhoneNumber { get { return _MobilePhoneNumber; } set {_MobilePhoneNumber = value; } }

		private string _EmailAddress;
		[LVRequired]
        [LVMaxLength(80)]
        public string EmailAddress { get { return _EmailAddress; } set {_EmailAddress = value; } }

		private DateTime? _DOB;
        public DateTime? DOB { get { return _DOB; } set {_DOB = value; } }

		private string _IDNumber;
        [LVMaxLength(12)]
        public string IDNumber { get { return _IDNumber; } set {_IDNumber = value; } }

		private string _PPN;
        [LVMaxLength(15)]
        public string PPN { get { return _PPN; } set {_PPN = value; } }

		private bool? _ReqCfmBySMS;
        public bool? ReqCfmBySMS { get { return _ReqCfmBySMS; } set {_ReqCfmBySMS = value; } }

		private string _OTP;
        [LVMaxLength(12)]
        public string OTP { get { return _OTP; } set {_OTP = value; } }

		private long? _Gender;
        public long? Gender { get { return _Gender; } set {_Gender = value; } }

		/// <summary>
/// Ref Key: FK_OnlineQueue_RegistrationInfo
/// <summary>
/// <summary>
/// Ref Key: FK_RegistrationInfo_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_RegistrationInfo_refPersGender
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
    public class KeyedRegistrationInfo : KeyedCollection<KeyValuePair<string, long>, RegistrationInfo>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedRegistrationInfo() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(RegistrationInfo item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RegInfoID) { return new KeyValuePair<string, long>("RegInfoID", k_RegInfoID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(RegistrationInfo item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, RegistrationInfo item)
        {
            RegistrationInfo orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(RegistrationInfo item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(RegistrationInfo item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public RegistrationInfo GetObjectByKey(long k_RegInfoID) 
		{
            if (this.Contains(GetKey(k_RegInfoID)) == false) return null;
            RegistrationInfo ob = this[GetKey(k_RegInfoID)];
            return (RegistrationInfo)ob;
        }

		public RegistrationInfo GetObjectByKey(long k_RegInfoID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RegInfoID)) == false) {
				RegistrationInfo ob = repository.GetQuery<RegistrationInfo>().FirstOrDefault(o => o.RegInfoID == k_RegInfoID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            RegistrationInfo obj = this[GetKey(k_RegInfoID)];
            return (RegistrationInfo)obj;
        }

		public RegistrationInfo GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            RegistrationInfo ob = this[keypair];
            return (RegistrationInfo)ob;
        }

        public RegistrationInfo GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            RegistrationInfo ob = this[GetKey(keypair)];
            return (RegistrationInfo)ob;
        }

		bool _LoadAll = false;
        public List<RegistrationInfo> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<RegistrationInfo>().ToList();
			foreach (RegistrationInfo item in list) {
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

        ~KeyedRegistrationInfo()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
