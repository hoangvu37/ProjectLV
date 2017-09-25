/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : RoomAllocation.cs         
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
	public partial class RoomAllocation : BaseEntity, ICloneable	{
		public RoomAllocation()
		{
			this.RoomID = 0;
			this.WDID = 0;
			this.ARescrID = 0;
            this.SetupDate = DateTime.Now;
			this.EstEmpID = 0;
			this.V_TreatmentRoomFeatures = 0;
            this.isAvailable = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RoomID", RoomID); } }


		private long _RoomID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RoomID { get { return _RoomID; } set {_RoomID = value; } }

		private long _WDID;
		[LVRequired]
        public long WDID { get { return _WDID; } set {_WDID = value; } }

		private long _ARescrID;
		[LVRequired]
        public long ARescrID { get { return _ARescrID; } set {_ARescrID = value; } }

		private string _LocationName;
		[LVRequired]
        [LVMaxLength(10)]
        public string LocationName { get { return _LocationName; } set {_LocationName = value; } }

		private string _LocationDesc;
		[LVRequired]
        [LVMaxLength(2048)]
        public string LocationDesc { get { return _LocationDesc; } set {_LocationDesc = value; } }

		private DateTime? _SetupDate;
        public DateTime? SetupDate { get { return _SetupDate; } set {_SetupDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private long _V_TreatmentRoomFeatures;
		[LVRequired]
        public long V_TreatmentRoomFeatures { get { return _V_TreatmentRoomFeatures; } set {_V_TreatmentRoomFeatures = value; } }

		private bool? _isAvailable;
        public bool? isAvailable { get { return _isAvailable; } set {_isAvailable = value; } }

		/// <summary>
/// Ref Key: FK_Allocation_ArchitectureResources
/// <summary>
/// <summary>
/// Ref Key: FK_AssignMedEquip_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_BedInRoom_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_DHCRoomBlock_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_PatientSpecimen_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_RescrUsedInOperation_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_ResourceLog_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_Allocation_WardInDept
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
    public class KeyedRoomAllocation : KeyedCollection<KeyValuePair<string, long>, RoomAllocation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedRoomAllocation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(RoomAllocation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RoomID) { return new KeyValuePair<string, long>("RoomID", k_RoomID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(RoomAllocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, RoomAllocation item)
        {
            RoomAllocation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(RoomAllocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(RoomAllocation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public RoomAllocation GetObjectByKey(long k_RoomID) 
		{
            if (this.Contains(GetKey(k_RoomID)) == false) return null;
            RoomAllocation ob = this[GetKey(k_RoomID)];
            return (RoomAllocation)ob;
        }

		public RoomAllocation GetObjectByKey(long k_RoomID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RoomID)) == false) {
				RoomAllocation ob = repository.GetQuery<RoomAllocation>().FirstOrDefault(o => o.RoomID == k_RoomID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            RoomAllocation obj = this[GetKey(k_RoomID)];
            return (RoomAllocation)obj;
        }

		public RoomAllocation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            RoomAllocation ob = this[keypair];
            return (RoomAllocation)ob;
        }

        public RoomAllocation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            RoomAllocation ob = this[GetKey(keypair)];
            return (RoomAllocation)ob;
        }

		bool _LoadAll = false;
        public List<RoomAllocation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<RoomAllocation>().ToList();
			foreach (RoomAllocation item in list) {
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

        ~KeyedRoomAllocation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
