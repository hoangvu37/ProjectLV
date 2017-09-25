/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EmployeeAnnualLeave.cs         
 * Created by           : Auto - 09/11/2017 15:20:02                     
 * Last modify          : Auto - 09/11/2017 15:20:02                     
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
	public partial class EmployeeAnnualLeave : BaseEntity, ICloneable	{
		public EmployeeAnnualLeave()
		{
			this.EmpALID = 0;
			this.EmpID = 0;
			this.YearNumber = 0;
            this.UpdatedDate = DateTime.Now;
            this.LeaveDaysAllowed = 0;
            this.LeaveCumulativeDaysTaken = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EmpALID", EmpALID); } }


		private long _EmpALID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EmpALID { get { return _EmpALID; } set {_EmpALID = value; } }

		private long _EmpID;
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private short _YearNumber;
		[LVRequired]
        public short YearNumber { get { return _YearNumber; } set {_YearNumber = value; } }

		private DateTime? _UpdatedDate;
        public DateTime? UpdatedDate { get { return _UpdatedDate; } set {_UpdatedDate = value; } }

		private byte _TAbsID;
		[LVRequired]
        public byte TAbsID { get { return _TAbsID; } set {_TAbsID = value; } }

		private byte _LeaveDaysAllowed;
		[LVRequired]
        public byte LeaveDaysAllowed { get { return _LeaveDaysAllowed; } set {_LeaveDaysAllowed = value; } }

		private byte _LeaveCumulativeDaysTaken;
		[LVRequired]
        public byte LeaveCumulativeDaysTaken { get { return _LeaveCumulativeDaysTaken; } set {_LeaveCumulativeDaysTaken = value; } }

		/// <summary>
/// Ref Key: FK_EmployeeAnnualLeave_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_EmployeeAnnualLeave_refTypeAbsent
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
    public class KeyedEmployeeAnnualLeave : KeyedCollection<KeyValuePair<string, long>, EmployeeAnnualLeave>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEmployeeAnnualLeave() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EmployeeAnnualLeave item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EmpALID) { return new KeyValuePair<string, long>("EmpALID", k_EmpALID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EmployeeAnnualLeave item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EmployeeAnnualLeave item)
        {
            EmployeeAnnualLeave orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EmployeeAnnualLeave item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EmployeeAnnualLeave item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EmployeeAnnualLeave GetObjectByKey(long k_EmpALID) 
		{
            if (this.Contains(GetKey(k_EmpALID)) == false) return null;
            EmployeeAnnualLeave ob = this[GetKey(k_EmpALID)];
            return (EmployeeAnnualLeave)ob;
        }

		public EmployeeAnnualLeave GetObjectByKey(long k_EmpALID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EmpALID)) == false) {
				EmployeeAnnualLeave ob = repository.GetQuery<EmployeeAnnualLeave>().FirstOrDefault(o => o.EmpALID == k_EmpALID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EmployeeAnnualLeave obj = this[GetKey(k_EmpALID)];
            return (EmployeeAnnualLeave)obj;
        }

		public EmployeeAnnualLeave GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EmployeeAnnualLeave ob = this[keypair];
            return (EmployeeAnnualLeave)ob;
        }

        public EmployeeAnnualLeave GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EmployeeAnnualLeave ob = this[GetKey(keypair)];
            return (EmployeeAnnualLeave)ob;
        }

		bool _LoadAll = false;
        public List<EmployeeAnnualLeave> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EmployeeAnnualLeave>().ToList();
			foreach (EmployeeAnnualLeave item in list) {
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

        ~KeyedEmployeeAnnualLeave()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
