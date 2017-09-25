/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HCStakeholder.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class HCStakeholder : BaseEntity, ICloneable	{
		public HCStakeholder()
		{
			this.HCStakeholderID = 0;
			this.OUID = 0;
			this.PersonID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HCStakeholderID", HCStakeholderID); } }


		private long _HCStakeholderID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HCStakeholderID { get { return _HCStakeholderID; } set {_HCStakeholderID = value; } }

		private long _OUID;
		[LVRequired]
        public long OUID { get { return _OUID; } set {_OUID = value; } }

		private long? _PersonID;
        public long? PersonID { get { return _PersonID; } set {_PersonID = value; } }

		/// <summary>
/// Ref Key: FK_HCStakeholder_Organization
/// <summary>
/// <summary>
/// Ref Key: FK_HCStakeholder_Person
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
    public class KeyedHCStakeholder : KeyedCollection<KeyValuePair<string, long>, HCStakeholder>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHCStakeholder() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HCStakeholder item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HCStakeholderID) { return new KeyValuePair<string, long>("HCStakeholderID", k_HCStakeholderID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HCStakeholder item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HCStakeholder item)
        {
            HCStakeholder orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HCStakeholder item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HCStakeholder item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HCStakeholder GetObjectByKey(long k_HCStakeholderID) 
		{
            if (this.Contains(GetKey(k_HCStakeholderID)) == false) return null;
            HCStakeholder ob = this[GetKey(k_HCStakeholderID)];
            return (HCStakeholder)ob;
        }

		public HCStakeholder GetObjectByKey(long k_HCStakeholderID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HCStakeholderID)) == false) {
				HCStakeholder ob = repository.GetQuery<HCStakeholder>().FirstOrDefault(o => o.HCStakeholderID == k_HCStakeholderID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HCStakeholder obj = this[GetKey(k_HCStakeholderID)];
            return (HCStakeholder)obj;
        }

		public HCStakeholder GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HCStakeholder ob = this[keypair];
            return (HCStakeholder)ob;
        }

        public HCStakeholder GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HCStakeholder ob = this[GetKey(keypair)];
            return (HCStakeholder)ob;
        }

		bool _LoadAll = false;
        public List<HCStakeholder> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HCStakeholder>().ToList();
			foreach (HCStakeholder item in list) {
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

        ~KeyedHCStakeholder()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
