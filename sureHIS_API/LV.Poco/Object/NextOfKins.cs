/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : NextOfKins.cs         
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
	public partial class NextOfKins : BaseEntity, ICloneable	{
		public NextOfKins()
		{
			this.RID = 0;
			this.PersonID = 0;
			this.FAMMbrRelationshipCode = 0;
            this.MiddleName = null;
            this.FAMMrLocationText = null;
            this.State = null;
            this.PhoneNumber = null;
            this.MobiPhoneNumber = null;
            this.EmailAddress = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RID", RID); } }


		private long _RID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RID { get { return _RID; } set {_RID = value; } }

		private long _PersonID;
		[LVRequired]
        public long PersonID { get { return _PersonID; } set {_PersonID = value; } }

		private long _FAMMbrRelationshipCode;
		[LVRequired]
        public long FAMMbrRelationshipCode { get { return _FAMMbrRelationshipCode; } set {_FAMMbrRelationshipCode = value; } }

		private string _FirstName;
		[LVRequired]
        [LVMaxLength(15)]
        public string FirstName { get { return _FirstName; } set {_FirstName = value; } }

		private string _MiddleName;
        [LVMaxLength(25)]
        public string MiddleName { get { return _MiddleName; } set {_MiddleName = value; } }

		private string _LastName;
		[LVRequired]
        [LVMaxLength(15)]
        public string LastName { get { return _LastName; } set {_LastName = value; } }

		private DateTime _DOB;
		[LVRequired]
        public DateTime DOB { get { return _DOB; } set {_DOB = value; } }

		private string _FAMMrLocationText;
        [LVMaxLength(1024)]
        public string FAMMrLocationText { get { return _FAMMrLocationText; } set {_FAMMrLocationText = value; } }

		private string _State;
        [LVMaxLength(80)]
        public string State { get { return _State; } set {_State = value; } }

		private string _PhoneNumber;
        [LVMaxLength(15)]
        public string PhoneNumber { get { return _PhoneNumber; } set {_PhoneNumber = value; } }

		private string _MobiPhoneNumber;
        [LVMaxLength(15)]
        public string MobiPhoneNumber { get { return _MobiPhoneNumber; } set {_MobiPhoneNumber = value; } }

		private string _EmailAddress;
        [LVMaxLength(128)]
        public string EmailAddress { get { return _EmailAddress; } set {_EmailAddress = value; } }

		/// <summary>
/// Ref Key: FK_NextOfKins_Person
/// <summary>
/// <summary>
/// Ref Key: FK_NextOfKins_refFAMRelationship
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
    public class KeyedNextOfKins : KeyedCollection<KeyValuePair<string, long>, NextOfKins>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedNextOfKins() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(NextOfKins item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RID) { return new KeyValuePair<string, long>("RID", k_RID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(NextOfKins item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, NextOfKins item)
        {
            NextOfKins orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(NextOfKins item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(NextOfKins item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public NextOfKins GetObjectByKey(long k_RID) 
		{
            if (this.Contains(GetKey(k_RID)) == false) return null;
            NextOfKins ob = this[GetKey(k_RID)];
            return (NextOfKins)ob;
        }

		public NextOfKins GetObjectByKey(long k_RID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RID)) == false) {
				NextOfKins ob = repository.GetQuery<NextOfKins>().FirstOrDefault(o => o.RID == k_RID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            NextOfKins obj = this[GetKey(k_RID)];
            return (NextOfKins)obj;
        }

		public NextOfKins GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            NextOfKins ob = this[keypair];
            return (NextOfKins)ob;
        }

        public NextOfKins GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            NextOfKins ob = this[GetKey(keypair)];
            return (NextOfKins)ob;
        }

		bool _LoadAll = false;
        public List<NextOfKins> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<NextOfKins>().ToList();
			foreach (NextOfKins item in list) {
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

        ~KeyedNextOfKins()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
