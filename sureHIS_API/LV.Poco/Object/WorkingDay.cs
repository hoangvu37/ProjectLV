/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : WorkingDay.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class WorkingDay : BaseEntity, ICloneable	{
		public WorkingDay()
		{
			this.WDID = 0;
			this.V_WorkingDay = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("WDID", WDID); } }


		private long _WDID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long WDID { get { return _WDID; } set {_WDID = value; } }

		private long _V_WorkingDay;
		[LVRequired]
        public long V_WorkingDay { get { return _V_WorkingDay; } set {_V_WorkingDay = value; } }

		private DateTime _DateObserved;
		[LVRequired]
        public DateTime DateObserved { get { return _DateObserved; } set {_DateObserved = value; } }

		

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
    public class KeyedWorkingDay : KeyedCollection<KeyValuePair<string, long>, WorkingDay>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedWorkingDay() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(WorkingDay item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_WDID) { return new KeyValuePair<string, long>("WDID", k_WDID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(WorkingDay item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, WorkingDay item)
        {
            WorkingDay orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(WorkingDay item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(WorkingDay item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public WorkingDay GetObjectByKey(long k_WDID) 
		{
            if (this.Contains(GetKey(k_WDID)) == false) return null;
            WorkingDay ob = this[GetKey(k_WDID)];
            return (WorkingDay)ob;
        }

		public WorkingDay GetObjectByKey(long k_WDID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_WDID)) == false) {
				WorkingDay ob = repository.GetQuery<WorkingDay>().FirstOrDefault(o => o.WDID == k_WDID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            WorkingDay obj = this[GetKey(k_WDID)];
            return (WorkingDay)obj;
        }

		public WorkingDay GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            WorkingDay ob = this[keypair];
            return (WorkingDay)ob;
        }

        public WorkingDay GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            WorkingDay ob = this[GetKey(keypair)];
            return (WorkingDay)ob;
        }

		bool _LoadAll = false;
        public List<WorkingDay> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<WorkingDay>().ToList();
			foreach (WorkingDay item in list) {
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

        ~KeyedWorkingDay()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
