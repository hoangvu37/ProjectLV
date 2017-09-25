/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ASPNetUser.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class ASPNetUser : BaseEntity, ICloneable	{
		public ASPNetUser()
		{
			this.ASPNetUserID = 0;
            this.EmailConfirmed = false;
            this.PhoneNumberConfirmed = false;
            this.TwoFactorEnabled = false;
            this.LockOutEndDateUTC = DateTime.Now;
            this.LockOutEnabled = true;
            this.AccessFailedCount = 0;
			this.AccountID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ASPNetUserID", ASPNetUserID); } }


		private long _ASPNetUserID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ASPNetUserID { get { return _ASPNetUserID; } set {_ASPNetUserID = value; } }

		private string _UserName;
		[LVRequired]
        [LVMaxLength(128)]
        public string UserName { get { return _UserName; } set {_UserName = value; } }

		private string _PasswordHash;
		[LVRequired]
        [LVMaxLength(128)]
        public string PasswordHash { get { return _PasswordHash; } set {_PasswordHash = value; } }

		private string _SecurityStamp;
		[LVRequired]
        [LVMaxLength(128)]
        public string SecurityStamp { get { return _SecurityStamp; } set {_SecurityStamp = value; } }

		private string _Email;
		[LVRequired]
        [LVMaxLength(128)]
        public string Email { get { return _Email; } set {_Email = value; } }

		private bool _EmailConfirmed;
        public bool EmailConfirmed { get { return _EmailConfirmed; } set {_EmailConfirmed = value; } }

		private string _PhoneNumber;
		[LVRequired]
        [LVMaxLength(20)]
        public string PhoneNumber { get { return _PhoneNumber; } set {_PhoneNumber = value; } }

		private bool _PhoneNumberConfirmed;
        public bool PhoneNumberConfirmed { get { return _PhoneNumberConfirmed; } set {_PhoneNumberConfirmed = value; } }

		private bool _TwoFactorEnabled;
        public bool TwoFactorEnabled { get { return _TwoFactorEnabled; } set {_TwoFactorEnabled = value; } }

		private DateTime? _LockOutEndDateUTC;
        public DateTime? LockOutEndDateUTC { get { return _LockOutEndDateUTC; } set {_LockOutEndDateUTC = value; } }

		private bool _LockOutEnabled;
        public bool LockOutEnabled { get { return _LockOutEnabled; } set {_LockOutEnabled = value; } }

		private int _AccessFailedCount;
		[LVRequired]
        public int AccessFailedCount { get { return _AccessFailedCount; } set {_AccessFailedCount = value; } }

		private string _Discriminator;
		[LVRequired]
        [LVMaxLength(50)]
        public string Discriminator { get { return _Discriminator; } set {_Discriminator = value; } }

		private long? _AccountID;
        public long? AccountID { get { return _AccountID; } set {_AccountID = value; } }

		/// <summary>
/// Ref Key: FK_ASPNetUser_UserAccount
/// <summary>
/// <summary>
/// Ref Key: FK_ASPNetUserClaims_ASPNetUser
/// <summary>
/// <summary>
/// Ref Key: FK_ASPNetUserLogin_ASPNetUser
/// <summary>
/// <summary>
/// Ref Key: FK_ASPNetUserRole_ASPNetUser
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
    public class KeyedASPNetUser : KeyedCollection<KeyValuePair<string, long>, ASPNetUser>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedASPNetUser() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ASPNetUser item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ASPNetUserID) { return new KeyValuePair<string, long>("ASPNetUserID", k_ASPNetUserID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ASPNetUser item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ASPNetUser item)
        {
            ASPNetUser orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ASPNetUser item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ASPNetUser item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ASPNetUser GetObjectByKey(long k_ASPNetUserID) 
		{
            if (this.Contains(GetKey(k_ASPNetUserID)) == false) return null;
            ASPNetUser ob = this[GetKey(k_ASPNetUserID)];
            return (ASPNetUser)ob;
        }

		public ASPNetUser GetObjectByKey(long k_ASPNetUserID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ASPNetUserID)) == false) {
				ASPNetUser ob = repository.GetQuery<ASPNetUser>().FirstOrDefault(o => o.ASPNetUserID == k_ASPNetUserID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ASPNetUser obj = this[GetKey(k_ASPNetUserID)];
            return (ASPNetUser)obj;
        }

		public ASPNetUser GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ASPNetUser ob = this[keypair];
            return (ASPNetUser)ob;
        }

        public ASPNetUser GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ASPNetUser ob = this[GetKey(keypair)];
            return (ASPNetUser)ob;
        }

		bool _LoadAll = false;
        public List<ASPNetUser> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ASPNetUser>().ToList();
			foreach (ASPNetUser item in list) {
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

        ~KeyedASPNetUser()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
