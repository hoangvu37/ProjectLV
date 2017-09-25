/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : WardInDept.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class WardInDept : BaseEntity, ICloneable	{
		public WardInDept()
		{
			this.WDID = 0;
			this.WID = 0;
			this.HosDeptID = 0;
            this.ModifiedDate = DateTime.Now;
			this.EstEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("WDID", WDID); } }


		private long _WDID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long WDID { get { return _WDID; } set {_WDID = value; } }

		private long _WID;
		[LVRequired]
        public long WID { get { return _WID; } set {_WID = value; } }

		private long _HosDeptID;
		[LVRequired]
        public long HosDeptID { get { return _HosDeptID; } set {_HosDeptID = value; } }

		private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_Appointment_WardInDept
/// <summary>
/// <summary>
/// Ref Key: FK_EmpAllocation_WardInDept
/// <summary>
/// <summary>
/// Ref Key: FK_WardInDept_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_InsuranceRegQueue_WardInDept
/// <summary>
/// <summary>
/// Ref Key: FK_OpSkedDistibution_WardInDept
/// <summary>
/// <summary>
/// Ref Key: FK_RegQueue_WardInDept
/// <summary>
/// <summary>
/// Ref Key: FK_Allocation_WardInDept
/// <summary>
/// <summary>
/// Ref Key: FK_WardInDept_Ward
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
    public class KeyedWardInDept : KeyedCollection<KeyValuePair<string, long>, WardInDept>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedWardInDept() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(WardInDept item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_WDID) { return new KeyValuePair<string, long>("WDID", k_WDID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(WardInDept item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, WardInDept item)
        {
            WardInDept orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(WardInDept item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(WardInDept item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public WardInDept GetObjectByKey(long k_WDID) 
		{
            if (this.Contains(GetKey(k_WDID)) == false) return null;
            WardInDept ob = this[GetKey(k_WDID)];
            return (WardInDept)ob;
        }

		public WardInDept GetObjectByKey(long k_WDID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_WDID)) == false) {
				WardInDept ob = repository.GetQuery<WardInDept>().FirstOrDefault(o => o.WDID == k_WDID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            WardInDept obj = this[GetKey(k_WDID)];
            return (WardInDept)obj;
        }

		public WardInDept GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            WardInDept ob = this[keypair];
            return (WardInDept)ob;
        }

        public WardInDept GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            WardInDept ob = this[GetKey(keypair)];
            return (WardInDept)ob;
        }

		bool _LoadAll = false;
        public List<WardInDept> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<WardInDept>().ToList();
			foreach (WardInDept item in list) {
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

        ~KeyedWardInDept()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
