/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PrivacyClass.cs         
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
	public partial class PrivacyClass : BaseEntity, ICloneable	{
		public PrivacyClass()
		{
			this.PrivClssID = 0;
            this.PrivClssName = null;
            this.Note = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PrivClssID", PrivClssID); } }


		private long _PrivClssID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PrivClssID { get { return _PrivClssID; } set {_PrivClssID = value; } }

		private string _PrivClssCode;
		[LVRequired]
        [LVMaxLength(7)]
        public string PrivClssCode { get { return _PrivClssCode; } set {_PrivClssCode = value; } }

		private string _PrivClssName;
		[LVRequired]
        [LVMaxLength(32)]
        public string PrivClssName { get { return _PrivClssName; } set {_PrivClssName = value; } }

		private string _PolicyRule;
		[LVRequired]
        public string PolicyRule { get { return _PolicyRule; } set {_PolicyRule = value; } }

		private string _Note;
        [LVMaxLength(2048)]
        public string Note { get { return _Note; } set {_Note = value; } }

		/// <summary>
/// Ref Key: FK_PatientPVID_PrivacyClass
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
    public class KeyedPrivacyClass : KeyedCollection<KeyValuePair<string, long>, PrivacyClass>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPrivacyClass() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PrivacyClass item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PrivClssID) { return new KeyValuePair<string, long>("PrivClssID", k_PrivClssID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PrivacyClass item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PrivacyClass item)
        {
            PrivacyClass orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PrivacyClass item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PrivacyClass item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PrivacyClass GetObjectByKey(long k_PrivClssID) 
		{
            if (this.Contains(GetKey(k_PrivClssID)) == false) return null;
            PrivacyClass ob = this[GetKey(k_PrivClssID)];
            return (PrivacyClass)ob;
        }

		public PrivacyClass GetObjectByKey(long k_PrivClssID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PrivClssID)) == false) {
				PrivacyClass ob = repository.GetQuery<PrivacyClass>().FirstOrDefault(o => o.PrivClssID == k_PrivClssID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PrivacyClass obj = this[GetKey(k_PrivClssID)];
            return (PrivacyClass)obj;
        }

		public PrivacyClass GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PrivacyClass ob = this[keypair];
            return (PrivacyClass)ob;
        }

        public PrivacyClass GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PrivacyClass ob = this[GetKey(keypair)];
            return (PrivacyClass)ob;
        }

		bool _LoadAll = false;
        public List<PrivacyClass> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PrivacyClass>().ToList();
			foreach (PrivacyClass item in list) {
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

        ~KeyedPrivacyClass()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
