/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : WorkingSchedule.cs         
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
	public partial class WorkingSchedule : BaseEntity, ICloneable	{
		public WorkingSchedule()
		{
			this.WorkingSked = 0;
			this.HosDeptID = 0;
			this.HosID = 0;
			this.V_DayName = 0;
			this.SID = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("WorkingSked", WorkingSked); } }


		private long _WorkingSked;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long WorkingSked { get { return _WorkingSked; } set {_WorkingSked = value; } }

		private long? _HosDeptID;
        public long? HosDeptID { get { return _HosDeptID; } set {_HosDeptID = value; } }

		private long? _HosID;
        public long? HosID { get { return _HosID; } set {_HosID = value; } }

		private long _V_DayName;
		[LVRequired]
        public long V_DayName { get { return _V_DayName; } set {_V_DayName = value; } }

		private long _SID;
		[LVRequired]
        public long SID { get { return _SID; } set {_SID = value; } }

		private string _Notes;
        [LVMaxLength(512)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_WorkingSchedule_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_WorkingSchedule_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_WorkingSchedule_refShift
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
    public class KeyedWorkingSchedule : KeyedCollection<KeyValuePair<string, long>, WorkingSchedule>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedWorkingSchedule() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(WorkingSchedule item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_WorkingSked) { return new KeyValuePair<string, long>("WorkingSked", k_WorkingSked); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(WorkingSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, WorkingSchedule item)
        {
            WorkingSchedule orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(WorkingSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(WorkingSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public WorkingSchedule GetObjectByKey(long k_WorkingSked) 
		{
            if (this.Contains(GetKey(k_WorkingSked)) == false) return null;
            WorkingSchedule ob = this[GetKey(k_WorkingSked)];
            return (WorkingSchedule)ob;
        }

		public WorkingSchedule GetObjectByKey(long k_WorkingSked, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_WorkingSked)) == false) {
				WorkingSchedule ob = repository.GetQuery<WorkingSchedule>().FirstOrDefault(o => o.WorkingSked == k_WorkingSked);
				if(ob != null) this.Add(ob);
				return ob;
			}
            WorkingSchedule obj = this[GetKey(k_WorkingSked)];
            return (WorkingSchedule)obj;
        }

		public WorkingSchedule GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            WorkingSchedule ob = this[keypair];
            return (WorkingSchedule)ob;
        }

        public WorkingSchedule GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            WorkingSchedule ob = this[GetKey(keypair)];
            return (WorkingSchedule)ob;
        }

		bool _LoadAll = false;
        public List<WorkingSchedule> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<WorkingSchedule>().ToList();
			foreach (WorkingSchedule item in list) {
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

        ~KeyedWorkingSchedule()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
