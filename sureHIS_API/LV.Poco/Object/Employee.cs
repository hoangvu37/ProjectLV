/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Employee.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class Employee : BaseEntity, ICloneable	{
		public Employee()
		{
			this.EmpID = 0;
			this.HosID = 0;
            this.JTID = null;
			this.PstnID = 0;
            this.AcademicCode = null;
            this.LeftDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
			this.HosDeptID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EmpID", EmpID); } }


		private long _EmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private string _EmpCode;
		[LVRequired]
        [LVMaxLength(20)]
        public string EmpCode { get { return _EmpCode; } set {_EmpCode = value; } }

		private long? _HosID;
        public long? HosID { get { return _HosID; } set {_HosID = value; } }

		private long? _JTID;
        public long? JTID { get { return _JTID; } set {_JTID = value; } }

		private long _PstnID;
		[LVRequired]
        public long PstnID { get { return _PstnID; } set {_PstnID = value; } }

		private int? _AcademicCode;
        public int? AcademicCode { get { return _AcademicCode; } set {_AcademicCode = value; } }

		private DateTime _EmployDate;
		[LVRequired]
        public DateTime EmployDate { get { return _EmployDate; } set {_EmployDate = value; } }

		private DateTime? _LeftDate;
        public DateTime? LeftDate { get { return _LeftDate; } set {_LeftDate = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _HosDeptID;
        public long? HosDeptID { get { return _HosDeptID; } set {_HosDeptID = value; } }

		/// <summary>
/// Ref Key: FK_AdvancedSpecialist_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_Appointment_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_AssignmentSchedule_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_DrAdviceTmp_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_DrMedicineTmp_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmp_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_EmpAllocation_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_HCEnterprise
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_Person
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_refAcademicTile
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_refJobTitle
/// <summary>
/// <summary>
/// Ref Key: FK_EmployeeAnnualLeave_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_EmployeeLeaveTaken_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_EmpWorkSchedule_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_InsuranceRegQueue_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_JobHistory_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_PersonalProperty_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_RegQueue_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_ResourceLog_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_SocialAndHealthInsurance_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_TestBlood_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_Employee_02
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
    public class KeyedEmployee : KeyedCollection<KeyValuePair<string, long>, Employee>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEmployee() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Employee item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EmpID) { return new KeyValuePair<string, long>("EmpID", k_EmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Employee item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Employee item)
        {
            Employee orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Employee item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Employee item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Employee GetObjectByKey(long k_EmpID) 
		{
            if (this.Contains(GetKey(k_EmpID)) == false) return null;
            Employee ob = this[GetKey(k_EmpID)];
            return (Employee)ob;
        }

		public Employee GetObjectByKey(long k_EmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EmpID)) == false) {
				Employee ob = repository.GetQuery<Employee>().FirstOrDefault(o => o.EmpID == k_EmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Employee obj = this[GetKey(k_EmpID)];
            return (Employee)obj;
        }

		public Employee GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Employee ob = this[keypair];
            return (Employee)ob;
        }

        public Employee GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Employee ob = this[GetKey(keypair)];
            return (Employee)ob;
        }

		bool _LoadAll = false;
        public List<Employee> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Employee>().ToList();
			foreach (Employee item in list) {
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

        ~KeyedEmployee()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
