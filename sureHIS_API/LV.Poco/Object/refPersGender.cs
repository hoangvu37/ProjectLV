/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refPersGender.cs         
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
	public partial class refPersGender : BaseEntity, ICloneable	{
		public refPersGender()
		{
			this.PersGenderID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PersGenderID", PersGenderID); } }


		private long _PersGenderID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PersGenderID { get { return _PersGenderID; } set {_PersGenderID = value; } }

		private string _PersGenderCode;
		[LVRequired]
        [LVMaxLength(2)]
        public string PersGenderCode { get { return _PersGenderCode; } set {_PersGenderCode = value; } }

		private string _PersGenderName;
		[LVRequired]
        [LVMaxLength(30)]
        public string PersGenderName { get { return _PersGenderName; } set {_PersGenderName = value; } }

		private string _VNPersGenderName;
        [LVMaxLength(64)]
        public string VNPersGenderName { get { return _VNPersGenderName; } set {_VNPersGenderName = value; } }

		/// <summary>
/// Ref Key: FK_Person_refPersGender
/// <summary>
/// <summary>
/// Ref Key: FK_refLimVitalSign_refPersGender
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
    public class KeyedrefPersGender : KeyedCollection<KeyValuePair<string, long>, refPersGender>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefPersGender() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refPersGender item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PersGenderID) { return new KeyValuePair<string, long>("PersGenderID", k_PersGenderID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refPersGender item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refPersGender item)
        {
            refPersGender orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refPersGender item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refPersGender item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refPersGender GetObjectByKey(long k_PersGenderID) 
		{
            if (this.Contains(GetKey(k_PersGenderID)) == false) return null;
            refPersGender ob = this[GetKey(k_PersGenderID)];
            return (refPersGender)ob;
        }

		public refPersGender GetObjectByKey(long k_PersGenderID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PersGenderID)) == false) {
				refPersGender ob = repository.GetQuery<refPersGender>().FirstOrDefault(o => o.PersGenderID == k_PersGenderID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refPersGender obj = this[GetKey(k_PersGenderID)];
            return (refPersGender)obj;
        }

		public refPersGender GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refPersGender ob = this[keypair];
            return (refPersGender)ob;
        }

        public refPersGender GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refPersGender ob = this[GetKey(keypair)];
            return (refPersGender)ob;
        }

		bool _LoadAll = false;
        public List<refPersGender> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refPersGender>().ToList();
			foreach (refPersGender item in list) {
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

        ~KeyedrefPersGender()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
