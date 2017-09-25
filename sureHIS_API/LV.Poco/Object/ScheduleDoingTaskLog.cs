/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ScheduleDoingTaskLog.cs         
 * Created by           : Auto - 09/11/2017 15:20:03                     
 * Last modify          : Auto - 09/11/2017 15:20:03                     
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
	public partial class ScheduleDoingTaskLog : BaseEntity, ICloneable	{
		public ScheduleDoingTaskLog()
		{
			this.ScheduleTaskID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ScheduleTaskID", ScheduleTaskID); } }


		private long _ScheduleTaskID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ScheduleTaskID { get { return _ScheduleTaskID; } set {_ScheduleTaskID = value; } }

		private string _ScheduleTaskName;
		[LVRequired]
        [LVMaxLength(50)]
        public string ScheduleTaskName { get { return _ScheduleTaskName; } set {_ScheduleTaskName = value; } }

		private DateTime? _LastScheduleDtm;
        public DateTime? LastScheduleDtm { get { return _LastScheduleDtm; } set {_LastScheduleDtm = value; } }

		

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
    public class KeyedScheduleDoingTaskLog : KeyedCollection<KeyValuePair<string, long>, ScheduleDoingTaskLog>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedScheduleDoingTaskLog() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ScheduleDoingTaskLog item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ScheduleTaskID) { return new KeyValuePair<string, long>("ScheduleTaskID", k_ScheduleTaskID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ScheduleDoingTaskLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ScheduleDoingTaskLog item)
        {
            ScheduleDoingTaskLog orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ScheduleDoingTaskLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ScheduleDoingTaskLog item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ScheduleDoingTaskLog GetObjectByKey(long k_ScheduleTaskID) 
		{
            if (this.Contains(GetKey(k_ScheduleTaskID)) == false) return null;
            ScheduleDoingTaskLog ob = this[GetKey(k_ScheduleTaskID)];
            return (ScheduleDoingTaskLog)ob;
        }

		public ScheduleDoingTaskLog GetObjectByKey(long k_ScheduleTaskID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ScheduleTaskID)) == false) {
				ScheduleDoingTaskLog ob = repository.GetQuery<ScheduleDoingTaskLog>().FirstOrDefault(o => o.ScheduleTaskID == k_ScheduleTaskID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ScheduleDoingTaskLog obj = this[GetKey(k_ScheduleTaskID)];
            return (ScheduleDoingTaskLog)obj;
        }

		public ScheduleDoingTaskLog GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ScheduleDoingTaskLog ob = this[keypair];
            return (ScheduleDoingTaskLog)ob;
        }

        public ScheduleDoingTaskLog GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ScheduleDoingTaskLog ob = this[GetKey(keypair)];
            return (ScheduleDoingTaskLog)ob;
        }

		bool _LoadAll = false;
        public List<ScheduleDoingTaskLog> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ScheduleDoingTaskLog>().ToList();
			foreach (ScheduleDoingTaskLog item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<ScheduleDoingTaskLog> LoadUQ_ScheduleDoingTaskLog(string p_ScheduleTaskName, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<ScheduleDoingTaskLog>().Where(o=> o.ScheduleTaskName == p_ScheduleTaskName).ToList();
			foreach (ScheduleDoingTaskLog item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
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

        ~KeyedScheduleDoingTaskLog()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
