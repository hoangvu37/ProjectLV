/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ResourceLog.cs         
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
	public partial class ResourceLog : BaseEntity, ICloneable	{
		public ResourceLog()
		{
			this.ResLogID = 0;
			this.RoomID = 0;
			this.EmpID = 0;
            this.TrackedDateTime = DateTime.Now;
            this.V_TriggerEvent = null;
            this.V_SeverityLevel = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ResLogID", ResLogID); } }


		private long _ResLogID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ResLogID { get { return _ResLogID; } set {_ResLogID = value; } }

		private long? _RoomID;
        public long? RoomID { get { return _RoomID; } set {_RoomID = value; } }

		private long? _EmpID;
        public long? EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private DateTime? _TrackedDateTime;
        public DateTime? TrackedDateTime { get { return _TrackedDateTime; } set {_TrackedDateTime = value; } }

		private long? _V_TriggerEvent;
        public long? V_TriggerEvent { get { return _V_TriggerEvent; } set {_V_TriggerEvent = value; } }

		private long? _V_SeverityLevel;
        public long? V_SeverityLevel { get { return _V_SeverityLevel; } set {_V_SeverityLevel = value; } }

		/// <summary>
/// Ref Key: FK_ResourceLog_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_ResourceLog_RoomAllocation
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
    public class KeyedResourceLog : KeyedCollection<KeyValuePair<string, long>, ResourceLog>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedResourceLog() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ResourceLog item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ResLogID) { return new KeyValuePair<string, long>("ResLogID", k_ResLogID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ResourceLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ResourceLog item)
        {
            ResourceLog orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ResourceLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ResourceLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ResourceLog GetObjectByKey(long k_ResLogID) 
		{
            if (this.Contains(GetKey(k_ResLogID)) == false) return null;
            ResourceLog ob = this[GetKey(k_ResLogID)];
            return (ResourceLog)ob;
        }

		public ResourceLog GetObjectByKey(long k_ResLogID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ResLogID)) == false) {
				ResourceLog ob = repository.GetQuery<ResourceLog>().FirstOrDefault(o => o.ResLogID == k_ResLogID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ResourceLog obj = this[GetKey(k_ResLogID)];
            return (ResourceLog)obj;
        }

		public ResourceLog GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ResourceLog ob = this[keypair];
            return (ResourceLog)ob;
        }

        public ResourceLog GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ResourceLog ob = this[GetKey(keypair)];
            return (ResourceLog)ob;
        }

		bool _LoadAll = false;
        public List<ResourceLog> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ResourceLog>().ToList();
			foreach (ResourceLog item in list) {
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

        ~KeyedResourceLog()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
