/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EmpWorkSchedule.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class EmpWorkSchedule : BaseEntity, ICloneable	{
		public EmpWorkSchedule()
		{
			this.DOpSkedID = 0;
			this.WSID = 0;
            this.DateObserved = DateTime.Now;
			this.EmpID = 0;
            this.TAbsID = null;
            this.StatusOfApptSlot = true;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("WSID", WSID); } }


		private long _DOpSkedID;
		[LVRequired]
        public long DOpSkedID { get { return _DOpSkedID; } set {_DOpSkedID = value; } }

		private long _WSID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long WSID { get { return _WSID; } set {_WSID = value; } }

		private DateTime _DateObserved;
		[LVRequired]
        public DateTime DateObserved { get { return _DateObserved; } set {_DateObserved = value; } }

		private long _EmpID;
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private byte? _TAbsID;
        public byte? TAbsID { get { return _TAbsID; } set {_TAbsID = value; } }

		private bool? _StatusOfApptSlot;
        public bool? StatusOfApptSlot { get { return _StatusOfApptSlot; } set {_StatusOfApptSlot = value; } }

		private string _Notes;
        [LVMaxLength(512)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_Appointment_EmpWorkSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_BusySchedule_EmpWorkSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_EmpWorkSchedule_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_EmpWorkSchedule_Operations
/// <summary>
/// <summary>
/// Ref Key: FK_EmpWorkSchedule_refTypeAbsent
/// <summary>
/// <summary>
/// Ref Key: FK_RescrUsedInOperation_EmpWorkSchedule
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
    public class KeyedEmpWorkSchedule : KeyedCollection<KeyValuePair<string, long>, EmpWorkSchedule>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEmpWorkSchedule() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EmpWorkSchedule item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_WSID) { return new KeyValuePair<string, long>("WSID", k_WSID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EmpWorkSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EmpWorkSchedule item)
        {
            EmpWorkSchedule orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EmpWorkSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EmpWorkSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EmpWorkSchedule GetObjectByKey(long k_WSID) 
		{
            if (this.Contains(GetKey(k_WSID)) == false) return null;
            EmpWorkSchedule ob = this[GetKey(k_WSID)];
            return (EmpWorkSchedule)ob;
        }

		public EmpWorkSchedule GetObjectByKey(long k_WSID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_WSID)) == false) {
				EmpWorkSchedule ob = repository.GetQuery<EmpWorkSchedule>().FirstOrDefault(o => o.WSID == k_WSID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EmpWorkSchedule obj = this[GetKey(k_WSID)];
            return (EmpWorkSchedule)obj;
        }

		public EmpWorkSchedule GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EmpWorkSchedule ob = this[keypair];
            return (EmpWorkSchedule)ob;
        }

        public EmpWorkSchedule GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EmpWorkSchedule ob = this[GetKey(keypair)];
            return (EmpWorkSchedule)ob;
        }

		bool _LoadAll = false;
        public List<EmpWorkSchedule> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EmpWorkSchedule>().ToList();
			foreach (EmpWorkSchedule item in list) {
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

        ~KeyedEmpWorkSchedule()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
