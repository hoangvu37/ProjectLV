/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EmpAllocation.cs         
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
	public partial class EmpAllocation : BaseEntity, ICloneable	{
		public EmpAllocation()
		{
			this.EmpWardAssgID = 0;
			this.EmpID = 0;
			this.WDID = 0;
            this.FromDate = DateTime.Now;
            this.ToDate = DateTime.Now;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EmpWardAssgID", EmpWardAssgID); } }


		private long _EmpWardAssgID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EmpWardAssgID { get { return _EmpWardAssgID; } set {_EmpWardAssgID = value; } }

		private long _EmpID;
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private long _WDID;
		[LVRequired]
        public long WDID { get { return _WDID; } set {_WDID = value; } }

		private DateTime _FromDate;
		[LVRequired]
        public DateTime FromDate { get { return _FromDate; } set {_FromDate = value; } }

		private DateTime? _ToDate;
        public DateTime? ToDate { get { return _ToDate; } set {_ToDate = value; } }

		private string _Notes;
        [LVMaxLength(2048)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_EmpAllocation_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_EmpAllocation_WardInDept
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
    public class KeyedEmpAllocation : KeyedCollection<KeyValuePair<string, long>, EmpAllocation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEmpAllocation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EmpAllocation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EmpWardAssgID) { return new KeyValuePair<string, long>("EmpWardAssgID", k_EmpWardAssgID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EmpAllocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EmpAllocation item)
        {
            EmpAllocation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EmpAllocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EmpAllocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EmpAllocation GetObjectByKey(long k_EmpWardAssgID) 
		{
            if (this.Contains(GetKey(k_EmpWardAssgID)) == false) return null;
            EmpAllocation ob = this[GetKey(k_EmpWardAssgID)];
            return (EmpAllocation)ob;
        }

		public EmpAllocation GetObjectByKey(long k_EmpWardAssgID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EmpWardAssgID)) == false) {
				EmpAllocation ob = repository.GetQuery<EmpAllocation>().FirstOrDefault(o => o.EmpWardAssgID == k_EmpWardAssgID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EmpAllocation obj = this[GetKey(k_EmpWardAssgID)];
            return (EmpAllocation)obj;
        }

		public EmpAllocation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EmpAllocation ob = this[keypair];
            return (EmpAllocation)ob;
        }

        public EmpAllocation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EmpAllocation ob = this[GetKey(keypair)];
            return (EmpAllocation)ob;
        }

		bool _LoadAll = false;
        public List<EmpAllocation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EmpAllocation>().ToList();
			foreach (EmpAllocation item in list) {
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

        ~KeyedEmpAllocation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
