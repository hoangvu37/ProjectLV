/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HospitalSpecialist.cs         
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
	public partial class HospitalSpecialist : BaseEntity, ICloneable	{
		public HospitalSpecialist()
		{
			this.HosDeptID = 0;
			this.HosID = 0;
			this.DeptID = 0;
            this.ModifiedDate = DateTime.Now;
			this.EstEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HosDeptID", HosDeptID); } }


		private long _HosDeptID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HosDeptID { get { return _HosDeptID; } set {_HosDeptID = value; } }

		private long _HosID;
		[LVRequired]
        public long HosID { get { return _HosID; } set {_HosID = value; } }

		private long _DeptID;
		[LVRequired]
        public long DeptID { get { return _DeptID; } set {_DeptID = value; } }

		private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_ClinicalTrial_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_HospitalSpecialist_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalEncounter_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_MedSerInDept_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_WardInDept_HospitalSpecialist
/// <summary>
/// <summary>
/// Ref Key: FK_WorkingSchedule_HospitalSpecialist
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
    public class KeyedHospitalSpecialist : KeyedCollection<KeyValuePair<string, long>, HospitalSpecialist>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHospitalSpecialist() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HospitalSpecialist item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HosDeptID) { return new KeyValuePair<string, long>("HosDeptID", k_HosDeptID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HospitalSpecialist item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HospitalSpecialist item)
        {
            HospitalSpecialist orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HospitalSpecialist item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HospitalSpecialist item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HospitalSpecialist GetObjectByKey(long k_HosDeptID) 
		{
            if (this.Contains(GetKey(k_HosDeptID)) == false) return null;
            HospitalSpecialist ob = this[GetKey(k_HosDeptID)];
            return (HospitalSpecialist)ob;
        }

		public HospitalSpecialist GetObjectByKey(long k_HosDeptID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HosDeptID)) == false) {
				HospitalSpecialist ob = repository.GetQuery<HospitalSpecialist>().FirstOrDefault(o => o.HosDeptID == k_HosDeptID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HospitalSpecialist obj = this[GetKey(k_HosDeptID)];
            return (HospitalSpecialist)obj;
        }

		public HospitalSpecialist GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HospitalSpecialist ob = this[keypair];
            return (HospitalSpecialist)ob;
        }

        public HospitalSpecialist GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HospitalSpecialist ob = this[GetKey(keypair)];
            return (HospitalSpecialist)ob;
        }

		bool _LoadAll = false;
        public List<HospitalSpecialist> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HospitalSpecialist>().ToList();
			foreach (HospitalSpecialist item in list) {
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

        ~KeyedHospitalSpecialist()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
