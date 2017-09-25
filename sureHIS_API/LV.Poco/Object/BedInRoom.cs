/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : BedInRoom.cs         
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
	public partial class BedInRoom : BaseEntity, ICloneable	{
		public BedInRoom()
		{
			this.PtBdRmID = 0;
			this.RoomID = 0;
            this.PtBedID = null;
			this.V_PatientBedStatus = 0;
			this.SID = 0;
			this.EstEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtBdRmID", PtBdRmID); } }


		private long _PtBdRmID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtBdRmID { get { return _PtBdRmID; } set {_PtBdRmID = value; } }

		private long _RoomID;
		[LVRequired]
        public long RoomID { get { return _RoomID; } set {_RoomID = value; } }

		private byte _SlotNo;
		[LVRequired]
        public byte SlotNo { get { return _SlotNo; } set {_SlotNo = value; } }

		private long? _PtBedID;
        public long? PtBedID { get { return _PtBedID; } set {_PtBedID = value; } }

		private long _V_PatientBedStatus;
		[LVRequired]
        public long V_PatientBedStatus { get { return _V_PatientBedStatus; } set {_V_PatientBedStatus = value; } }

		private DateTime _AllocatedDate;
		[LVRequired]
        public DateTime AllocatedDate { get { return _AllocatedDate; } set {_AllocatedDate = value; } }

		private long _SID;
		[LVRequired]
        public long SID { get { return _SID; } set {_SID = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_BedInRoom_PatientBed
/// <summary>
/// <summary>
/// Ref Key: FK_BedInRoom_RoomAllocation
/// <summary>
/// <summary>
/// Ref Key: FK_PatientInBedRoom_BedInRoom
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
    public class KeyedBedInRoom : KeyedCollection<KeyValuePair<string, long>, BedInRoom>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedBedInRoom() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(BedInRoom item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtBdRmID) { return new KeyValuePair<string, long>("PtBdRmID", k_PtBdRmID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(BedInRoom item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, BedInRoom item)
        {
            BedInRoom orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(BedInRoom item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(BedInRoom item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public BedInRoom GetObjectByKey(long k_PtBdRmID) 
		{
            if (this.Contains(GetKey(k_PtBdRmID)) == false) return null;
            BedInRoom ob = this[GetKey(k_PtBdRmID)];
            return (BedInRoom)ob;
        }

		public BedInRoom GetObjectByKey(long k_PtBdRmID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtBdRmID)) == false) {
				BedInRoom ob = repository.GetQuery<BedInRoom>().FirstOrDefault(o => o.PtBdRmID == k_PtBdRmID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            BedInRoom obj = this[GetKey(k_PtBdRmID)];
            return (BedInRoom)obj;
        }

		public BedInRoom GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            BedInRoom ob = this[keypair];
            return (BedInRoom)ob;
        }

        public BedInRoom GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            BedInRoom ob = this[GetKey(keypair)];
            return (BedInRoom)ob;
        }

		bool _LoadAll = false;
        public List<BedInRoom> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<BedInRoom>().ToList();
			foreach (BedInRoom item in list) {
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

        ~KeyedBedInRoom()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
