/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : SpecMedRecTmp.cs         
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
	public partial class SpecMedRecTmp : BaseEntity, ICloneable	{
		public SpecMedRecTmp()
		{
			this.SpecMDTmpID = 0;
			this.DeptID = 0;
			this.MDTmpID = 0;
            this.SpecMDTmpDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SpecMDTmpID", SpecMDTmpID); } }


		private long _SpecMDTmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SpecMDTmpID { get { return _SpecMDTmpID; } set {_SpecMDTmpID = value; } }

		private long _DeptID;
		[LVRequired]
        public long DeptID { get { return _DeptID; } set {_DeptID = value; } }

		private long _MDTmpID;
		[LVRequired]
        public long MDTmpID { get { return _MDTmpID; } set {_MDTmpID = value; } }

		private string _SpecMDTmpDesc;
        [LVMaxLength(1024)]
        public string SpecMDTmpDesc { get { return _SpecMDTmpDesc; } set {_SpecMDTmpDesc = value; } }

		/// <summary>
/// Ref Key: FK_SpecMedRecordTemp_MedRecordTemp
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
    public class KeyedSpecMedRecTmp : KeyedCollection<KeyValuePair<string, long>, SpecMedRecTmp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedSpecMedRecTmp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(SpecMedRecTmp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SpecMDTmpID) { return new KeyValuePair<string, long>("SpecMDTmpID", k_SpecMDTmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(SpecMedRecTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, SpecMedRecTmp item)
        {
            SpecMedRecTmp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(SpecMedRecTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(SpecMedRecTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public SpecMedRecTmp GetObjectByKey(long k_SpecMDTmpID) 
		{
            if (this.Contains(GetKey(k_SpecMDTmpID)) == false) return null;
            SpecMedRecTmp ob = this[GetKey(k_SpecMDTmpID)];
            return (SpecMedRecTmp)ob;
        }

		public SpecMedRecTmp GetObjectByKey(long k_SpecMDTmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SpecMDTmpID)) == false) {
				SpecMedRecTmp ob = repository.GetQuery<SpecMedRecTmp>().FirstOrDefault(o => o.SpecMDTmpID == k_SpecMDTmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            SpecMedRecTmp obj = this[GetKey(k_SpecMDTmpID)];
            return (SpecMedRecTmp)obj;
        }

		public SpecMedRecTmp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            SpecMedRecTmp ob = this[keypair];
            return (SpecMedRecTmp)ob;
        }

        public SpecMedRecTmp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            SpecMedRecTmp ob = this[GetKey(keypair)];
            return (SpecMedRecTmp)ob;
        }

		bool _LoadAll = false;
        public List<SpecMedRecTmp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<SpecMedRecTmp>().ToList();
			foreach (SpecMedRecTmp item in list) {
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

        ~KeyedSpecMedRecTmp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
