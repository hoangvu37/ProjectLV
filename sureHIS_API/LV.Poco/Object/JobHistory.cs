/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : JobHistory.cs         
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
	public partial class JobHistory : BaseEntity, ICloneable	{
		public JobHistory()
		{
			this.JHID = 0;
			this.EmpID = 0;
			this.JMID = 0;
            this.DateAssignedFrom = DateTime.Now;
            this.DateAssignedTo = DateTime.Now;
            this.IsPrimaryJobRole = true;
            this.NotAssigned = true;
            this.JHDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("JHID", JHID); } }


		private long _JHID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long JHID { get { return _JHID; } set {_JHID = value; } }

		private long _EmpID;
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private long? _JMID;
        public long? JMID { get { return _JMID; } set {_JMID = value; } }

		private DateTime? _DateAssignedFrom;
        public DateTime? DateAssignedFrom { get { return _DateAssignedFrom; } set {_DateAssignedFrom = value; } }

		private DateTime? _DateAssignedTo;
        public DateTime? DateAssignedTo { get { return _DateAssignedTo; } set {_DateAssignedTo = value; } }

		private bool? _IsPrimaryJobRole;
        public bool? IsPrimaryJobRole { get { return _IsPrimaryJobRole; } set {_IsPrimaryJobRole = value; } }

		private bool? _NotAssigned;
        public bool? NotAssigned { get { return _NotAssigned; } set {_NotAssigned = value; } }

		private string _JHDesc;
        [LVMaxLength(1024)]
        public string JHDesc { get { return _JHDesc; } set {_JHDesc = value; } }

		/// <summary>
/// Ref Key: FK_JobHistory_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_JobHistory_JobModel
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
    public class KeyedJobHistory : KeyedCollection<KeyValuePair<string, long>, JobHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedJobHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(JobHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_JHID) { return new KeyValuePair<string, long>("JHID", k_JHID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(JobHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, JobHistory item)
        {
            JobHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(JobHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(JobHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public JobHistory GetObjectByKey(long k_JHID) 
		{
            if (this.Contains(GetKey(k_JHID)) == false) return null;
            JobHistory ob = this[GetKey(k_JHID)];
            return (JobHistory)ob;
        }

		public JobHistory GetObjectByKey(long k_JHID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_JHID)) == false) {
				JobHistory ob = repository.GetQuery<JobHistory>().FirstOrDefault(o => o.JHID == k_JHID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            JobHistory obj = this[GetKey(k_JHID)];
            return (JobHistory)obj;
        }

		public JobHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            JobHistory ob = this[keypair];
            return (JobHistory)ob;
        }

        public JobHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            JobHistory ob = this[GetKey(keypair)];
            return (JobHistory)ob;
        }

		bool _LoadAll = false;
        public List<JobHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<JobHistory>().ToList();
			foreach (JobHistory item in list) {
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

        ~KeyedJobHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
