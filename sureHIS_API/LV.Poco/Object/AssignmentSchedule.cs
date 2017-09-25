/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AssignmentSchedule.cs         
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
	public partial class AssignmentSchedule : BaseEntity, ICloneable	{
		public AssignmentSchedule()
		{
			this.AssignSkedID = 0;
			this.OpSkedID = 0;
			this.EmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AssignSkedID", AssignSkedID); } }


		private long _AssignSkedID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AssignSkedID { get { return _AssignSkedID; } set {_AssignSkedID = value; } }

		private long _OpSkedID;
		[LVRequired]
        public long OpSkedID { get { return _OpSkedID; } set {_OpSkedID = value; } }

		private long _EmpID;
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		/// <summary>
/// Ref Key: FK_AssignmentSchedule_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_AssignmentSchedule_OperationSchedule
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
    public class KeyedAssignmentSchedule : KeyedCollection<KeyValuePair<string, long>, AssignmentSchedule>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAssignmentSchedule() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AssignmentSchedule item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AssignSkedID) { return new KeyValuePair<string, long>("AssignSkedID", k_AssignSkedID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AssignmentSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AssignmentSchedule item)
        {
            AssignmentSchedule orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AssignmentSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AssignmentSchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AssignmentSchedule GetObjectByKey(long k_AssignSkedID) 
		{
            if (this.Contains(GetKey(k_AssignSkedID)) == false) return null;
            AssignmentSchedule ob = this[GetKey(k_AssignSkedID)];
            return (AssignmentSchedule)ob;
        }

		public AssignmentSchedule GetObjectByKey(long k_AssignSkedID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AssignSkedID)) == false) {
				AssignmentSchedule ob = repository.GetQuery<AssignmentSchedule>().FirstOrDefault(o => o.AssignSkedID == k_AssignSkedID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AssignmentSchedule obj = this[GetKey(k_AssignSkedID)];
            return (AssignmentSchedule)obj;
        }

		public AssignmentSchedule GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AssignmentSchedule ob = this[keypair];
            return (AssignmentSchedule)ob;
        }

        public AssignmentSchedule GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AssignmentSchedule ob = this[GetKey(keypair)];
            return (AssignmentSchedule)ob;
        }

		bool _LoadAll = false;
        public List<AssignmentSchedule> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AssignmentSchedule>().ToList();
			foreach (AssignmentSchedule item in list) {
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

        ~KeyedAssignmentSchedule()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
