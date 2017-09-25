/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedSerInDept.cs         
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
	public partial class MedSerInDept : BaseEntity, ICloneable	{
		public MedSerInDept()
		{
			this.MedSerInDeptID = 0;
			this.MedSerID = 0;
			this.HosDeptID = 0;
            this.AppliedDate = DateTime.Now;
			this.EstEmpID = 0;
            this.NoEffect = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedSerInDeptID", MedSerInDeptID); } }


		private long _MedSerInDeptID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedSerInDeptID { get { return _MedSerInDeptID; } set {_MedSerInDeptID = value; } }

		private long _MedSerID;
		[LVRequired]
        public long MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private long _HosDeptID;
		[LVRequired]
        public long HosDeptID { get { return _HosDeptID; } set {_HosDeptID = value; } }

		private DateTime? _AppliedDate;
        public DateTime? AppliedDate { get { return _AppliedDate; } set {_AppliedDate = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private bool _NoEffect;
        public bool NoEffect { get { return _NoEffect; } set {_NoEffect = value; } }

		/// <summary>
/// Ref Key: FK_MedSerInDept_HospitalSpecialist
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
    public class KeyedMedSerInDept : KeyedCollection<KeyValuePair<string, long>, MedSerInDept>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedSerInDept() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedSerInDept item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedSerInDeptID) { return new KeyValuePair<string, long>("MedSerInDeptID", k_MedSerInDeptID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedSerInDept item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedSerInDept item)
        {
            MedSerInDept orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedSerInDept item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedSerInDept item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedSerInDept GetObjectByKey(long k_MedSerInDeptID) 
		{
            if (this.Contains(GetKey(k_MedSerInDeptID)) == false) return null;
            MedSerInDept ob = this[GetKey(k_MedSerInDeptID)];
            return (MedSerInDept)ob;
        }

		public MedSerInDept GetObjectByKey(long k_MedSerInDeptID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedSerInDeptID)) == false) {
				MedSerInDept ob = repository.GetQuery<MedSerInDept>().FirstOrDefault(o => o.MedSerInDeptID == k_MedSerInDeptID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedSerInDept obj = this[GetKey(k_MedSerInDeptID)];
            return (MedSerInDept)obj;
        }

		public MedSerInDept GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedSerInDept ob = this[keypair];
            return (MedSerInDept)ob;
        }

        public MedSerInDept GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedSerInDept ob = this[GetKey(keypair)];
            return (MedSerInDept)ob;
        }

		bool _LoadAll = false;
        public List<MedSerInDept> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedSerInDept>().ToList();
			foreach (MedSerInDept item in list) {
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

        ~KeyedMedSerInDept()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
