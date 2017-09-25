/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : NetworkGuestAccount.cs         
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
	public partial class NetworkGuestAccount : BaseEntity, ICloneable	{
		public NetworkGuestAccount()
		{
			this.IdentityUserID = 0;
            this.IsConfirmed = true;
            this.PtID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("IdentityUserID", IdentityUserID); } }


		private long _IdentityUserID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long IdentityUserID { get { return _IdentityUserID; } set {_IdentityUserID = value; } }

		private string _IdentityUser;
        [LVMaxLength(128)]
        public string IdentityUser { get { return _IdentityUser; } set {_IdentityUser = value; } }

		private string _ProviderName;
        [LVMaxLength(128)]
        public string ProviderName { get { return _ProviderName; } set {_ProviderName = value; } }

		private string _ProviderUserID;
        [LVMaxLength(255)]
        public string ProviderUserID { get { return _ProviderUserID; } set {_ProviderUserID = value; } }

		private string _eMailAddress;
        [LVMaxLength(128)]
        public string eMailAddress { get { return _eMailAddress; } set {_eMailAddress = value; } }

		private string _Guid;
		[LVRequired]
        [LVMaxLength(128)]
        public string Guid { get { return _Guid; } set {_Guid = value; } }

		private string _NickName;
		[LVRequired]
        [LVMaxLength(128)]
        public string NickName { get { return _NickName; } set {_NickName = value; } }

		private string _ProfileURL;
        [LVMaxLength(256)]
        public string ProfileURL { get { return _ProfileURL; } set {_ProfileURL = value; } }

		private DateTime? _DOB;
        public DateTime? DOB { get { return _DOB; } set {_DOB = value; } }

		private string _Gender;
        [LVMaxLength(20)]
        public string Gender { get { return _Gender; } set {_Gender = value; } }

		private bool? _IsConfirmed;
        public bool? IsConfirmed { get { return _IsConfirmed; } set {_IsConfirmed = value; } }

		private byte? _SNetID;
        public byte? SNetID { get { return _SNetID; } set {_SNetID = value; } }

		private long? _PtID;
        public long? PtID { get { return _PtID; } set {_PtID = value; } }

		/// <summary>
/// Ref Key: FK_NetworkGuestAccount_GenericSocialNetwork
/// <summary>
/// <summary>
/// Ref Key: FK_NetworkGuestAccount_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_NetworkGuestAccount_Person
/// <summary>
/// <summary>
/// Ref Key: FK_OnlineQueue_NetworkGuestAccount
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
    public class KeyedNetworkGuestAccount : KeyedCollection<KeyValuePair<string, long>, NetworkGuestAccount>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedNetworkGuestAccount() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(NetworkGuestAccount item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_IdentityUserID) { return new KeyValuePair<string, long>("IdentityUserID", k_IdentityUserID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(NetworkGuestAccount item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, NetworkGuestAccount item)
        {
            NetworkGuestAccount orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(NetworkGuestAccount item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(NetworkGuestAccount item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public NetworkGuestAccount GetObjectByKey(long k_IdentityUserID) 
		{
            if (this.Contains(GetKey(k_IdentityUserID)) == false) return null;
            NetworkGuestAccount ob = this[GetKey(k_IdentityUserID)];
            return (NetworkGuestAccount)ob;
        }

		public NetworkGuestAccount GetObjectByKey(long k_IdentityUserID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_IdentityUserID)) == false) {
				NetworkGuestAccount ob = repository.GetQuery<NetworkGuestAccount>().FirstOrDefault(o => o.IdentityUserID == k_IdentityUserID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            NetworkGuestAccount obj = this[GetKey(k_IdentityUserID)];
            return (NetworkGuestAccount)obj;
        }

		public NetworkGuestAccount GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            NetworkGuestAccount ob = this[keypair];
            return (NetworkGuestAccount)ob;
        }

        public NetworkGuestAccount GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            NetworkGuestAccount ob = this[GetKey(keypair)];
            return (NetworkGuestAccount)ob;
        }

		bool _LoadAll = false;
        public List<NetworkGuestAccount> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<NetworkGuestAccount>().ToList();
			foreach (NetworkGuestAccount item in list) {
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

        ~KeyedNetworkGuestAccount()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
