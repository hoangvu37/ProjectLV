/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refDepartment.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class refDepartment : BaseEntity, ICloneable	{
		public refDepartment()
		{
			this.DeptID = 0;
            this.PDeptD = null;
            this.MOHDeptCode = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DeptID", DeptID); } }


		private long _DeptID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DeptID { get { return _DeptID; } set {_DeptID = value; } }

		private long? _PDeptD;
        public long? PDeptD { get { return _PDeptD; } set {_PDeptD = value; } }

		private string _DeptName;
		[LVRequired]
        [LVMaxLength(80)]
        public string DeptName { get { return _DeptName; } set {_DeptName = value; } }

		private string _DepDescription;
        [LVMaxLength(512)]
        public string DepDescription { get { return _DepDescription; } set {_DepDescription = value; } }

		private string _MOHDeptCode;
        [LVMaxLength(3)]
        public string MOHDeptCode { get { return _MOHDeptCode; } set {_MOHDeptCode = value; } }

		private string _HIDeptCode;
        [LVMaxLength(3)]
        public string HIDeptCode { get { return _HIDeptCode; } set {_HIDeptCode = value; } }

		

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
    public class KeyedrefDepartment : KeyedCollection<KeyValuePair<string, long>, refDepartment>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefDepartment() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refDepartment item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DeptID) { return new KeyValuePair<string, long>("DeptID", k_DeptID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refDepartment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refDepartment item)
        {
            refDepartment orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refDepartment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refDepartment item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refDepartment GetObjectByKey(long k_DeptID) 
		{
            if (this.Contains(GetKey(k_DeptID)) == false) return null;
            refDepartment ob = this[GetKey(k_DeptID)];
            return (refDepartment)ob;
        }

		public refDepartment GetObjectByKey(long k_DeptID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DeptID)) == false) {
				refDepartment ob = repository.GetQuery<refDepartment>().FirstOrDefault(o => o.DeptID == k_DeptID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refDepartment obj = this[GetKey(k_DeptID)];
            return (refDepartment)obj;
        }

		public refDepartment GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refDepartment ob = this[keypair];
            return (refDepartment)ob;
        }

        public refDepartment GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refDepartment ob = this[GetKey(keypair)];
            return (refDepartment)ob;
        }

		bool _LoadAll = false;
        public List<refDepartment> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refDepartment>().ToList();
			foreach (refDepartment item in list) {
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

        ~KeyedrefDepartment()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
