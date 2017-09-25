/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : BusySchedule.cs         
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
	public partial class BusySchedule : BaseEntity, ICloneable	{
		public BusySchedule()
		{
			this.BusySkedID = 0;
			this.TFID = 0;
			this.WSID = 0;
            this.V_Reasons = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("BusySkedID", BusySkedID); } }


		private long _BusySkedID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long BusySkedID { get { return _BusySkedID; } set {_BusySkedID = value; } }

		private short _TFID;
		[LVRequired]
        public short TFID { get { return _TFID; } set {_TFID = value; } }

		private long _WSID;
		[LVRequired]
        public long WSID { get { return _WSID; } set {_WSID = value; } }

		private long? _V_Reasons;
        public long? V_Reasons { get { return _V_Reasons; } set {_V_Reasons = value; } }

		/// <summary>
/// Ref Key: FK_BusySchedule_EmpWorkSchedule
/// <summary>
/// <summary>
/// Ref Key: FK_BusySchedule_refTimeFrame
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
    public class KeyedBusySchedule : KeyedCollection<KeyValuePair<string, long>, BusySchedule>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedBusySchedule() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(BusySchedule item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_BusySkedID) { return new KeyValuePair<string, long>("BusySkedID", k_BusySkedID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(BusySchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, BusySchedule item)
        {
            BusySchedule orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(BusySchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(BusySchedule item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public BusySchedule GetObjectByKey(long k_BusySkedID) 
		{
            if (this.Contains(GetKey(k_BusySkedID)) == false) return null;
            BusySchedule ob = this[GetKey(k_BusySkedID)];
            return (BusySchedule)ob;
        }

		public BusySchedule GetObjectByKey(long k_BusySkedID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_BusySkedID)) == false) {
				BusySchedule ob = repository.GetQuery<BusySchedule>().FirstOrDefault(o => o.BusySkedID == k_BusySkedID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            BusySchedule obj = this[GetKey(k_BusySkedID)];
            return (BusySchedule)obj;
        }

		public BusySchedule GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            BusySchedule ob = this[keypair];
            return (BusySchedule)ob;
        }

        public BusySchedule GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            BusySchedule ob = this[GetKey(keypair)];
            return (BusySchedule)ob;
        }

		bool _LoadAll = false;
        public List<BusySchedule> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<BusySchedule>().ToList();
			foreach (BusySchedule item in list) {
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

        ~KeyedBusySchedule()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
