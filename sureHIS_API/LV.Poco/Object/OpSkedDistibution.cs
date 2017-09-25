/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : OpSkedDistibution.cs         
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
	public partial class OpSkedDistibution : BaseEntity, ICloneable	{
		public OpSkedDistibution()
		{
			this.OSDistID = 0;
			this.OpSkedID = 0;
			this.WDID = 0;
			this.RoleID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("OSDistID", OSDistID); } }


		private long _OSDistID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long OSDistID { get { return _OSDistID; } set {_OSDistID = value; } }

		private long? _OpSkedID;
        public long? OpSkedID { get { return _OpSkedID; } set {_OpSkedID = value; } }

		private long _WDID;
		[LVRequired]
        public long WDID { get { return _WDID; } set {_WDID = value; } }

		private long _RoleID;
		[LVRequired]
        public long RoleID { get { return _RoleID; } set {_RoleID = value; } }

		/// <summary>
/// Ref Key: FK_OpSkedDistibution_OperationSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_OpSkedDistibution_refRole
/// <summary>
/// <summary>
/// Ref Key: FK_OpSkedDistibution_WardInDept
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
    public class KeyedOpSkedDistibution : KeyedCollection<KeyValuePair<string, long>, OpSkedDistibution>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedOpSkedDistibution() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(OpSkedDistibution item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_OSDistID) { return new KeyValuePair<string, long>("OSDistID", k_OSDistID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(OpSkedDistibution item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, OpSkedDistibution item)
        {
            OpSkedDistibution orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(OpSkedDistibution item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(OpSkedDistibution item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public OpSkedDistibution GetObjectByKey(long k_OSDistID) 
		{
            if (this.Contains(GetKey(k_OSDistID)) == false) return null;
            OpSkedDistibution ob = this[GetKey(k_OSDistID)];
            return (OpSkedDistibution)ob;
        }

		public OpSkedDistibution GetObjectByKey(long k_OSDistID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_OSDistID)) == false) {
				OpSkedDistibution ob = repository.GetQuery<OpSkedDistibution>().FirstOrDefault(o => o.OSDistID == k_OSDistID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            OpSkedDistibution obj = this[GetKey(k_OSDistID)];
            return (OpSkedDistibution)obj;
        }

		public OpSkedDistibution GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            OpSkedDistibution ob = this[keypair];
            return (OpSkedDistibution)ob;
        }

        public OpSkedDistibution GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            OpSkedDistibution ob = this[GetKey(keypair)];
            return (OpSkedDistibution)ob;
        }

		bool _LoadAll = false;
        public List<OpSkedDistibution> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<OpSkedDistibution>().ToList();
			foreach (OpSkedDistibution item in list) {
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

        ~KeyedOpSkedDistibution()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
