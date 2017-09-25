/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EmployeeLeaveTaken.cs         
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
	public partial class EmployeeLeaveTaken : BaseEntity, ICloneable	{
		public EmployeeLeaveTaken()
		{
			this.LPeriodID = 0;
			this.EmpID = 0;
			this.V_LeavePeriodType = 0;
            this.LeaveFromDate = DateTime.Now;
            this.ReasonVacation = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("LPeriodID", LPeriodID); } }


		private long _LPeriodID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long LPeriodID { get { return _LPeriodID; } set {_LPeriodID = value; } }

		private long? _EmpID;
        public long? EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private byte _TAbsID;
		[LVRequired]
        public byte TAbsID { get { return _TAbsID; } set {_TAbsID = value; } }

		private long _V_LeavePeriodType;
		[LVRequired]
        public long V_LeavePeriodType { get { return _V_LeavePeriodType; } set {_V_LeavePeriodType = value; } }

		private DateTime _LeaveFromDate;
		[LVRequired]
        public DateTime LeaveFromDate { get { return _LeaveFromDate; } set {_LeaveFromDate = value; } }

		private DateTime _LeaveToDate;
		[LVRequired]
        public DateTime LeaveToDate { get { return _LeaveToDate; } set {_LeaveToDate = value; } }

		private string _ReasonVacation;
        [LVMaxLength(1024)]
        public string ReasonVacation { get { return _ReasonVacation; } set {_ReasonVacation = value; } }

		/// <summary>
/// Ref Key: FK_EmployeeLeaveTaken_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_EmployeeLeaveTaken_refTypeAbsent
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
    public class KeyedEmployeeLeaveTaken : KeyedCollection<KeyValuePair<string, long>, EmployeeLeaveTaken>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEmployeeLeaveTaken() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EmployeeLeaveTaken item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_LPeriodID) { return new KeyValuePair<string, long>("LPeriodID", k_LPeriodID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EmployeeLeaveTaken item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EmployeeLeaveTaken item)
        {
            EmployeeLeaveTaken orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EmployeeLeaveTaken item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EmployeeLeaveTaken item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EmployeeLeaveTaken GetObjectByKey(long k_LPeriodID) 
		{
            if (this.Contains(GetKey(k_LPeriodID)) == false) return null;
            EmployeeLeaveTaken ob = this[GetKey(k_LPeriodID)];
            return (EmployeeLeaveTaken)ob;
        }

		public EmployeeLeaveTaken GetObjectByKey(long k_LPeriodID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_LPeriodID)) == false) {
				EmployeeLeaveTaken ob = repository.GetQuery<EmployeeLeaveTaken>().FirstOrDefault(o => o.LPeriodID == k_LPeriodID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EmployeeLeaveTaken obj = this[GetKey(k_LPeriodID)];
            return (EmployeeLeaveTaken)obj;
        }

		public EmployeeLeaveTaken GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EmployeeLeaveTaken ob = this[keypair];
            return (EmployeeLeaveTaken)ob;
        }

        public EmployeeLeaveTaken GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EmployeeLeaveTaken ob = this[GetKey(keypair)];
            return (EmployeeLeaveTaken)ob;
        }

		bool _LoadAll = false;
        public List<EmployeeLeaveTaken> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EmployeeLeaveTaken>().ToList();
			foreach (EmployeeLeaveTaken item in list) {
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

        ~KeyedEmployeeLeaveTaken()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
