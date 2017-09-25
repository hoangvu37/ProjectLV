/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refLookup.cs         
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
	public partial class refLookup : BaseEntity, ICloneable	{
		public refLookup()
		{
			this.LookupID = 0;
            this.isBuiltin = true;
            this.VNObjectValue = null;
            this.isActivated = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("LookupID", LookupID); } }


		private long _LookupID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long LookupID { get { return _LookupID; } set {_LookupID = value; } }

		private bool _isBuiltin;
        public bool isBuiltin { get { return _isBuiltin; } set {_isBuiltin = value; } }

		private string _ObjectName;
		[LVRequired]
        [LVMaxLength(64)]
        public string ObjectName { get { return _ObjectName; } set {_ObjectName = value; } }

		private string _ObjectValue;
		[LVRequired]
        [LVMaxLength(128)]
        public string ObjectValue { get { return _ObjectValue; } set {_ObjectValue = value; } }

		private string _VNObjectValue;
        [LVMaxLength(128)]
        public string VNObjectValue { get { return _VNObjectValue; } set {_VNObjectValue = value; } }

		private string _ObjectNotes;
        [LVMaxLength(256)]
        public string ObjectNotes { get { return _ObjectNotes; } set {_ObjectNotes = value; } }

		private bool? _isActivated;
        public bool? isActivated { get { return _isActivated; } set {_isActivated = value; } }

		private byte _Ordinal;
		[LVRequired]
        public byte Ordinal { get { return _Ordinal; } set {_Ordinal = value; } }

		

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
    public class KeyedrefLookup : KeyedCollection<KeyValuePair<string, long>, refLookup>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefLookup() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refLookup item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_LookupID) { return new KeyValuePair<string, long>("LookupID", k_LookupID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refLookup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refLookup item)
        {
            refLookup orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refLookup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refLookup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refLookup GetObjectByKey(long k_LookupID) 
		{
            if (this.Contains(GetKey(k_LookupID)) == false) return null;
            refLookup ob = this[GetKey(k_LookupID)];
            return (refLookup)ob;
        }

		public refLookup GetObjectByKey(long k_LookupID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_LookupID)) == false) {
				refLookup ob = repository.GetQuery<refLookup>().FirstOrDefault(o => o.LookupID == k_LookupID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refLookup obj = this[GetKey(k_LookupID)];
            return (refLookup)obj;
        }

		public refLookup GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refLookup ob = this[keypair];
            return (refLookup)ob;
        }

        public refLookup GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refLookup ob = this[GetKey(keypair)];
            return (refLookup)ob;
        }

		bool _LoadAll = false;
        public List<refLookup> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refLookup>().ToList();
			foreach (refLookup item in list) {
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

        ~KeyedrefLookup()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
