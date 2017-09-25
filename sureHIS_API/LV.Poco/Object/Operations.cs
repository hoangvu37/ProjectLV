/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Operations.cs         
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
	public partial class Operations : BaseEntity, ICloneable	{
		public Operations()
		{
			this.OpSkedID = 0;
			this.DOpSkedID = 0;
			this.V_DayName = 0;
			this.SID = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DOpSkedID", DOpSkedID); } }


		private long _OpSkedID;
		[LVRequired]
        public long OpSkedID { get { return _OpSkedID; } set {_OpSkedID = value; } }

		private long _DOpSkedID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DOpSkedID { get { return _DOpSkedID; } set {_DOpSkedID = value; } }

		private long _V_DayName;
		[LVRequired]
        public long V_DayName { get { return _V_DayName; } set {_V_DayName = value; } }

		private long _SID;
		[LVRequired]
        public long SID { get { return _SID; } set {_SID = value; } }

		private string _Notes;
        [LVMaxLength(128)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_EmpWorkSchedule_Operations
/// <summary>
/// <summary>
/// Ref Key: FK_Operations_OperationSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_Operations_refShift
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
    public class KeyedOperations : KeyedCollection<KeyValuePair<string, long>, Operations>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedOperations() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Operations item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DOpSkedID) { return new KeyValuePair<string, long>("DOpSkedID", k_DOpSkedID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Operations item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Operations item)
        {
            Operations orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Operations item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Operations item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Operations GetObjectByKey(long k_DOpSkedID) 
		{
            if (this.Contains(GetKey(k_DOpSkedID)) == false) return null;
            Operations ob = this[GetKey(k_DOpSkedID)];
            return (Operations)ob;
        }

		public Operations GetObjectByKey(long k_DOpSkedID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DOpSkedID)) == false) {
				Operations ob = repository.GetQuery<Operations>().FirstOrDefault(o => o.DOpSkedID == k_DOpSkedID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Operations obj = this[GetKey(k_DOpSkedID)];
            return (Operations)obj;
        }

		public Operations GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Operations ob = this[keypair];
            return (Operations)ob;
        }

        public Operations GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Operations ob = this[GetKey(keypair)];
            return (Operations)ob;
        }

		bool _LoadAll = false;
        public List<Operations> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Operations>().ToList();
			foreach (Operations item in list) {
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

        ~KeyedOperations()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
