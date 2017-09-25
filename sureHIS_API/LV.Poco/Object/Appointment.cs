/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Appointment.cs         
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
	public partial class Appointment : BaseEntity, ICloneable	{
		public Appointment()
		{
			this.ApptID = 0;
			this.OQueueID = 0;
            this.WSID = null;
            this.WDID = null;
            this.TFID = null;
			this.MedSerID = 0;
			this.V_ApptStatus = 0;
            this.IsConfirmed = true;
            this.CSEmpID = null;
            this.DateCreated = DateTime.Now;
            this.V_ApptMethod = null;
            this.SubApptDate = DateTime.Now;
            this.SubAppTime = null;
            this.ReasonOrSymptom = null;
            this.AssignedDoctorID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ApptID", ApptID); } }


		private long _ApptID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ApptID { get { return _ApptID; } set {_ApptID = value; } }

		private long? _OQueueID;
        public long? OQueueID { get { return _OQueueID; } set {_OQueueID = value; } }

		private DateTime _ApptDate;
		[LVRequired]
        public DateTime ApptDate { get { return _ApptDate; } set {_ApptDate = value; } }

		private TimeSpan? _AppTime;
        public TimeSpan? AppTime { get { return _AppTime; } set {_AppTime = value; } }

		private long? _WSID;
        public long? WSID { get { return _WSID; } set {_WSID = value; } }

		private long? _WDID;
        public long? WDID { get { return _WDID; } set {_WDID = value; } }

		private short? _TFID;
        public short? TFID { get { return _TFID; } set {_TFID = value; } }

		private long _MedSerID;
		[LVRequired]
        public long MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private long _V_ApptStatus;
		[LVRequired]
        public long V_ApptStatus { get { return _V_ApptStatus; } set {_V_ApptStatus = value; } }

		private bool? _IsConfirmed;
        public bool? IsConfirmed { get { return _IsConfirmed; } set {_IsConfirmed = value; } }

		private long? _CSEmpID;
        public long? CSEmpID { get { return _CSEmpID; } set {_CSEmpID = value; } }

		private DateTime _DateCreated;
		[LVRequired]
        public DateTime DateCreated { get { return _DateCreated; } set {_DateCreated = value; } }

		private DateTime? _DateModified;
        public DateTime? DateModified { get { return _DateModified; } set {_DateModified = value; } }

		private long? _V_ApptMethod;
        public long? V_ApptMethod { get { return _V_ApptMethod; } set {_V_ApptMethod = value; } }

		private DateTime? _SubApptDate;
        public DateTime? SubApptDate { get { return _SubApptDate; } set {_SubApptDate = value; } }

		private TimeSpan? _SubAppTime;
        public TimeSpan? SubAppTime { get { return _SubAppTime; } set {_SubAppTime = value; } }

		private string _ReasonOrSymptom;
        [LVMaxLength(1024)]
        public string ReasonOrSymptom { get { return _ReasonOrSymptom; } set {_ReasonOrSymptom = value; } }

		private long? _AssignedDoctorID;
        public long? AssignedDoctorID { get { return _AssignedDoctorID; } set {_AssignedDoctorID = value; } }

		/// <summary>
/// Ref Key: FK_Alert_Appointment
/// <summary>
/// <summary>
/// Ref Key: FK_Appointment_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_Appointment_EmpWorkSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_Appointment_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_Appointment_OnlineQueue
/// <summary>
/// <summary>
/// Ref Key: FK_Appointment_refTimeFrame
/// <summary>
/// <summary>
/// Ref Key: FK_Appointment_WardInDept
/// <summary>
/// <summary>
/// Ref Key: FK_Prescription_Appointment
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
    public class KeyedAppointment : KeyedCollection<KeyValuePair<string, long>, Appointment>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAppointment() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Appointment item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ApptID) { return new KeyValuePair<string, long>("ApptID", k_ApptID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Appointment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Appointment item)
        {
            Appointment orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Appointment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Appointment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Appointment GetObjectByKey(long k_ApptID) 
		{
            if (this.Contains(GetKey(k_ApptID)) == false) return null;
            Appointment ob = this[GetKey(k_ApptID)];
            return (Appointment)ob;
        }

		public Appointment GetObjectByKey(long k_ApptID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ApptID)) == false) {
				Appointment ob = repository.GetQuery<Appointment>().FirstOrDefault(o => o.ApptID == k_ApptID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Appointment obj = this[GetKey(k_ApptID)];
            return (Appointment)obj;
        }

		public Appointment GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Appointment ob = this[keypair];
            return (Appointment)ob;
        }

        public Appointment GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Appointment ob = this[GetKey(keypair)];
            return (Appointment)ob;
        }

		bool _LoadAll = false;
        public List<Appointment> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Appointment>().ToList();
			foreach (Appointment item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<Appointment> LoadIXFK_Appointment_MedicalServiceItem(long p_MedSerID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<Appointment>().Where(o=> o.MedSerID == p_MedSerID).ToList();
			foreach (Appointment item in list) {
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

        ~KeyedAppointment()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
