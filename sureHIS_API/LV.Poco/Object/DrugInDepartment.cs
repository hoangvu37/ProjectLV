/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrugInDepartment.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class DrugInDepartment : BaseEntity, ICloneable	{
		public DrugInDepartment()
		{
			this.DrugDepID = 0;
			this.DeptID = 0;
			this.DrugID = 0;
            this.BaseQty = 0;
            this.NoEffect = true;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrugDepID", DrugDepID); } }


		private long _DrugDepID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrugDepID { get { return _DrugDepID; } set {_DrugDepID = value; } }

		private long _DeptID;
		[LVRequired]
        public long DeptID { get { return _DeptID; } set {_DeptID = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private double _BaseQty;
		[LVRequired]
        public double BaseQty { get { return _BaseQty; } set {_BaseQty = value; } }

		private bool? _NoEffect;
        public bool? NoEffect { get { return _NoEffect; } set {_NoEffect = value; } }

		private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_DrugDepartment_Drug
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
    public class KeyedDrugInDepartment : KeyedCollection<KeyValuePair<string, long>, DrugInDepartment>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrugInDepartment() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrugInDepartment item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrugDepID) { return new KeyValuePair<string, long>("DrugDepID", k_DrugDepID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrugInDepartment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrugInDepartment item)
        {
            DrugInDepartment orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrugInDepartment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrugInDepartment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrugInDepartment GetObjectByKey(long k_DrugDepID) 
		{
            if (this.Contains(GetKey(k_DrugDepID)) == false) return null;
            DrugInDepartment ob = this[GetKey(k_DrugDepID)];
            return (DrugInDepartment)ob;
        }

		public DrugInDepartment GetObjectByKey(long k_DrugDepID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrugDepID)) == false) {
				DrugInDepartment ob = repository.GetQuery<DrugInDepartment>().FirstOrDefault(o => o.DrugDepID == k_DrugDepID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrugInDepartment obj = this[GetKey(k_DrugDepID)];
            return (DrugInDepartment)obj;
        }

		public DrugInDepartment GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrugInDepartment ob = this[keypair];
            return (DrugInDepartment)ob;
        }

        public DrugInDepartment GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrugInDepartment ob = this[GetKey(keypair)];
            return (DrugInDepartment)ob;
        }

		bool _LoadAll = false;
        public List<DrugInDepartment> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrugInDepartment>().ToList();
			foreach (DrugInDepartment item in list) {
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

        ~KeyedDrugInDepartment()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
