/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PhysicalExamination.cs         
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
	public partial class PhysicalExamination : BaseEntity, ICloneable	{
		public PhysicalExamination()
		{
			this.PhyExamID = 0;
			this.MedEncnID = 0;
			this.HExmFindingCode = 0;
            this.HExmExaminerName = null;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PhyExamID", PhyExamID); } }


		private long _PhyExamID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PhyExamID { get { return _PhyExamID; } set {_PhyExamID = value; } }

		private long _MedEncnID;
		[LVRequired]
        public long MedEncnID { get { return _MedEncnID; } set {_MedEncnID = value; } }

		private DateTime _HExmDtm;
		[LVRequired]
        public DateTime HExmDtm { get { return _HExmDtm; } set {_HExmDtm = value; } }

		private long _HExmFindingCode;
		[LVRequired]
        public long HExmFindingCode { get { return _HExmFindingCode; } set {_HExmFindingCode = value; } }

		private string _HExmFindingValueQty;
		[LVRequired]
        [LVMaxLength(10)]
        public string HExmFindingValueQty { get { return _HExmFindingValueQty; } set {_HExmFindingValueQty = value; } }

		private string _HExmExaminerName;
        [LVMaxLength(128)]
        public string HExmExaminerName { get { return _HExmExaminerName; } set {_HExmExaminerName = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_PhysicalExamination_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_PhysicalExamination_RefExamObservation
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
    public class KeyedPhysicalExamination : KeyedCollection<KeyValuePair<string, long>, PhysicalExamination>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPhysicalExamination() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PhysicalExamination item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PhyExamID) { return new KeyValuePair<string, long>("PhyExamID", k_PhyExamID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PhysicalExamination item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PhysicalExamination item)
        {
            PhysicalExamination orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PhysicalExamination item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PhysicalExamination item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PhysicalExamination GetObjectByKey(long k_PhyExamID) 
		{
            if (this.Contains(GetKey(k_PhyExamID)) == false) return null;
            PhysicalExamination ob = this[GetKey(k_PhyExamID)];
            return (PhysicalExamination)ob;
        }

		public PhysicalExamination GetObjectByKey(long k_PhyExamID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PhyExamID)) == false) {
				PhysicalExamination ob = repository.GetQuery<PhysicalExamination>().FirstOrDefault(o => o.PhyExamID == k_PhyExamID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PhysicalExamination obj = this[GetKey(k_PhyExamID)];
            return (PhysicalExamination)obj;
        }

		public PhysicalExamination GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PhysicalExamination ob = this[keypair];
            return (PhysicalExamination)ob;
        }

        public PhysicalExamination GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PhysicalExamination ob = this[GetKey(keypair)];
            return (PhysicalExamination)ob;
        }

		bool _LoadAll = false;
        public List<PhysicalExamination> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PhysicalExamination>().ToList();
			foreach (PhysicalExamination item in list) {
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

        ~KeyedPhysicalExamination()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
