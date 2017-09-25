/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : UserAccount.cs         
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
	public partial class UserAccount : BaseEntity, ICloneable	{
		public UserAccount()
		{
			this.AccountID = 0;
            this.PersonID = null;
            this.IsActivated = false;
            this.DateOfRegistration = DateTime.Now;
            this.isBlocked = false;
            this.isBuiltIn = false;
            this.PrimaryRoleID = null;
            this.RoleName = null;
            this.ForgotPwdCode = null;
            this.RequestDateForPWD = DateTime.Now;
            this.V_AccountType = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AccountID", AccountID); } }


		private long _AccountID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AccountID { get { return _AccountID; } set {_AccountID = value; } }

		private string _AccountNameEmailAddress;
		[LVRequired]
        [LVMaxLength(80)]
        public string AccountNameEmailAddress { get { return _AccountNameEmailAddress; } set {_AccountNameEmailAddress = value; } }

		private string _AccountPwd;
		[LVRequired]
        [LVMaxLength(64)]
        public string AccountPwd { get { return _AccountPwd; } set {_AccountPwd = value; } }

		private long? _PersonID;
        public long? PersonID { get { return _PersonID; } set {_PersonID = value; } }

		private bool? _IsActivated;
        public bool? IsActivated { get { return _IsActivated; } set {_IsActivated = value; } }

		private string _ActivationCode;
        [LVMaxLength(36)]
        public string ActivationCode { get { return _ActivationCode; } set {_ActivationCode = value; } }

		private DateTime? _ActivatedDtm;
        public DateTime? ActivatedDtm { get { return _ActivatedDtm; } set {_ActivatedDtm = value; } }

		private DateTime? _DateOfRegistration;
        public DateTime? DateOfRegistration { get { return _DateOfRegistration; } set {_DateOfRegistration = value; } }

		private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private bool? _isBlocked;
        public bool? isBlocked { get { return _isBlocked; } set {_isBlocked = value; } }

		private bool? _isBuiltIn;
        public bool? isBuiltIn { get { return _isBuiltIn; } set {_isBuiltIn = value; } }

		private long? _PrimaryRoleID;
        public long? PrimaryRoleID { get { return _PrimaryRoleID; } set {_PrimaryRoleID = value; } }

		private string _ForgotPwdCode;
        [LVMaxLength(64)]
        public string ForgotPwdCode { get { return _ForgotPwdCode; } set {_ForgotPwdCode = value; } }

        private string _RoleName;
        public string RoleName { get { return _RoleName; } set { _RoleName = value; } }

        private DateTime? _RequestDateForPWD;
        public DateTime? RequestDateForPWD { get { return _RequestDateForPWD; } set {_RequestDateForPWD = value; } }

		private long? _V_AccountType;
        public long? V_AccountType { get { return _V_AccountType; } set {_V_AccountType = value; } }

		/// <summary>
/// Ref Key: FK_AdmNoTempHolding_UserAccount
/// <summary>
/// <summary>
/// Ref Key: FK_ASPNetUser_UserAccount
/// <summary>
/// <summary>
/// Ref Key: FK_UserAccount_Person
/// <summary>
/// <summary>
/// Ref Key: FK_ServerLog_UserAccount
/// <summary>
/// <summary>
/// Ref Key: FK_Session_UserAccount
/// <summary>
/// <summary>
/// Ref Key: FK_UsersInGroup_UserAccount
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
    public class KeyedUserAccount : KeyedCollection<KeyValuePair<string, long>, UserAccount>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedUserAccount() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(UserAccount item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AccountID) { return new KeyValuePair<string, long>("AccountID", k_AccountID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(UserAccount item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, UserAccount item)
        {
            UserAccount orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(UserAccount item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(UserAccount item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public UserAccount GetObjectByKey(long k_AccountID) 
		{
            if (this.Contains(GetKey(k_AccountID)) == false) return null;
            UserAccount ob = this[GetKey(k_AccountID)];
            return (UserAccount)ob;
        }

		public UserAccount GetObjectByKey(long k_AccountID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AccountID)) == false) {
				UserAccount ob = repository.GetQuery<UserAccount>().FirstOrDefault(o => o.AccountID == k_AccountID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            UserAccount obj = this[GetKey(k_AccountID)];
            return (UserAccount)obj;
        }

		public UserAccount GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            UserAccount ob = this[keypair];
            return (UserAccount)ob;
        }

        public UserAccount GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            UserAccount ob = this[GetKey(keypair)];
            return (UserAccount)ob;
        }

		bool _LoadAll = false;
        public List<UserAccount> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<UserAccount>().ToList();
			foreach (UserAccount item in list) {
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

        ~KeyedUserAccount()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
