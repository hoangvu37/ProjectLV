/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : RescrUsedInOperation.cs         
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
	public partial class RescrUsedInOperation : BaseEntity, ICloneable	{
		public RescrUsedInOperation()
		{
			this.RescrID = 0;
			this.RoomID = 0;
			this.WSID = 0;
            this.HCRmBlockID = null;
            this.IsMasterRole = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RescrID", RescrID); } }


		private long _RescrID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RescrID { get { return _RescrID; } set {_RescrID = value; } }

		private long _RoomID;
		[LVRequired]
        public long RoomID { get { return _RoomID; } set {_RoomID = value; } }

		private long _WSID;
		[LVRequired]
        public long WSID { get { return _WSID; } set {_WSID = value; } }

		private long? _HCRmBlockID;
        public long? HCRmBlockID { get { return _HCRmBlockID; } set {_HCRmBlockID = value; } }

		private bool _IsMasterRole;
        public bool IsMasterRole { get { return _IsMasterRole; } set {_IsMasterRole = value; } }

		/// <summary>
/// Ref Key: FK_RescrUsedInOperation_EmpWorkSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_RescrUsedInOperation_HCRoomBlock
/// <summary>
/// <summary>
/// Ref Key: FK_HealthCareQueue_RescrUsedInOperation
/// <summary>
/// <summary>
/// Ref Key: FK_RescrUsedInOperation_RoomAllocation
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
    public class KeyedRescrUsedInOperation : KeyedCollection<KeyValuePair<string, long>, RescrUsedInOperation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedRescrUsedInOperation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(RescrUsedInOperation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RescrID) { return new KeyValuePair<string, long>("RescrID", k_RescrID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(RescrUsedInOperation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, RescrUsedInOperation item)
        {
            RescrUsedInOperation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(RescrUsedInOperation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(RescrUsedInOperation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public RescrUsedInOperation GetObjectByKey(long k_RescrID) 
		{
            if (this.Contains(GetKey(k_RescrID)) == false) return null;
            RescrUsedInOperation ob = this[GetKey(k_RescrID)];
            return (RescrUsedInOperation)ob;
        }

		public RescrUsedInOperation GetObjectByKey(long k_RescrID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RescrID)) == false) {
				RescrUsedInOperation ob = repository.GetQuery<RescrUsedInOperation>().FirstOrDefault(o => o.RescrID == k_RescrID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            RescrUsedInOperation obj = this[GetKey(k_RescrID)];
            return (RescrUsedInOperation)obj;
        }

		public RescrUsedInOperation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            RescrUsedInOperation ob = this[keypair];
            return (RescrUsedInOperation)ob;
        }

        public RescrUsedInOperation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            RescrUsedInOperation ob = this[GetKey(keypair)];
            return (RescrUsedInOperation)ob;
        }

		bool _LoadAll = false;
        public List<RescrUsedInOperation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<RescrUsedInOperation>().ToList();
			foreach (RescrUsedInOperation item in list) {
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

        ~KeyedRescrUsedInOperation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
