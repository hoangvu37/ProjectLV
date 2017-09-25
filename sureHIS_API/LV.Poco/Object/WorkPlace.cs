/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : WorkPlace.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class WorkPlace : BaseEntity, ICloneable	{
		public WorkPlace()
		{
			this.WorkPlaceID = 0;
			this.PtID = 0;
			this.OUID = 0;
            this.IsCurrently = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("WorkPlaceID", WorkPlaceID); } }


		private long _WorkPlaceID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long WorkPlaceID { get { return _WorkPlaceID; } set {_WorkPlaceID = value; } }

		private long _PtID;
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private long _OUID;
		[LVRequired]
        public long OUID { get { return _OUID; } set {_OUID = value; } }

		private DateTime? _FromDate;
        public DateTime? FromDate { get { return _FromDate; } set {_FromDate = value; } }

		private bool _IsCurrently;
        public bool IsCurrently { get { return _IsCurrently; } set {_IsCurrently = value; } }

		/// <summary>
/// Ref Key: FK_WorkPlace_Organization
/// <summary>
/// <summary>
/// Ref Key: FK_WorkPlace_Patient
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
    public class KeyedWorkPlace : KeyedCollection<KeyValuePair<string, long>, WorkPlace>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedWorkPlace() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(WorkPlace item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_WorkPlaceID) { return new KeyValuePair<string, long>("WorkPlaceID", k_WorkPlaceID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(WorkPlace item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, WorkPlace item)
        {
            WorkPlace orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(WorkPlace item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(WorkPlace item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public WorkPlace GetObjectByKey(long k_WorkPlaceID) 
		{
            if (this.Contains(GetKey(k_WorkPlaceID)) == false) return null;
            WorkPlace ob = this[GetKey(k_WorkPlaceID)];
            return (WorkPlace)ob;
        }

		public WorkPlace GetObjectByKey(long k_WorkPlaceID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_WorkPlaceID)) == false) {
				WorkPlace ob = repository.GetQuery<WorkPlace>().FirstOrDefault(o => o.WorkPlaceID == k_WorkPlaceID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            WorkPlace obj = this[GetKey(k_WorkPlaceID)];
            return (WorkPlace)obj;
        }

		public WorkPlace GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            WorkPlace ob = this[keypair];
            return (WorkPlace)ob;
        }

        public WorkPlace GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            WorkPlace ob = this[GetKey(keypair)];
            return (WorkPlace)ob;
        }

		bool _LoadAll = false;
        public List<WorkPlace> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<WorkPlace>().ToList();
			foreach (WorkPlace item in list) {
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

        ~KeyedWorkPlace()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
