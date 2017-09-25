/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : JobModel.cs         
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
	public partial class JobModel : BaseEntity, ICloneable	{
		public JobModel()
		{
			this.JMID = 0;
			this.JTID = 0;
            this.JTGrades = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("JMID", JMID); } }


		private long _JMID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long JMID { get { return _JMID; } set {_JMID = value; } }

		private long _JTID;
		[LVRequired]
        public long JTID { get { return _JTID; } set {_JTID = value; } }

		private short? _JTGrades;
        public short? JTGrades { get { return _JTGrades; } set {_JTGrades = value; } }

		/// <summary>
/// Ref Key: FK_JobHistory_JobModel
/// <summary>
/// <summary>
/// Ref Key: FK_JobModel_refJobTitle
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
    public class KeyedJobModel : KeyedCollection<KeyValuePair<string, long>, JobModel>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedJobModel() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(JobModel item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_JMID) { return new KeyValuePair<string, long>("JMID", k_JMID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(JobModel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, JobModel item)
        {
            JobModel orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(JobModel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(JobModel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public JobModel GetObjectByKey(long k_JMID) 
		{
            if (this.Contains(GetKey(k_JMID)) == false) return null;
            JobModel ob = this[GetKey(k_JMID)];
            return (JobModel)ob;
        }

		public JobModel GetObjectByKey(long k_JMID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_JMID)) == false) {
				JobModel ob = repository.GetQuery<JobModel>().FirstOrDefault(o => o.JMID == k_JMID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            JobModel obj = this[GetKey(k_JMID)];
            return (JobModel)obj;
        }

		public JobModel GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            JobModel ob = this[keypair];
            return (JobModel)ob;
        }

        public JobModel GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            JobModel ob = this[GetKey(keypair)];
            return (JobModel)ob;
        }

		bool _LoadAll = false;
        public List<JobModel> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<JobModel>().ToList();
			foreach (JobModel item in list) {
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

        ~KeyedJobModel()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
