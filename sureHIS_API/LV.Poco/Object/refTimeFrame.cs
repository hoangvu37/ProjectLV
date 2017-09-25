/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refTimeFrame.cs         
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
	public partial class refTimeFrame : BaseEntity, ICloneable	{
		public refTimeFrame()
		{
			this.TFID = 0;
			this.SID = 0;
            this.V_Purpose = null;
            this.EffectivelyDate = DateTime.Now;
            this.ExpiredDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, short> Key { get { return new KeyValuePair<string, short>("TFID", TFID); } }


		private short _TFID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public short TFID { get { return _TFID; } set {_TFID = value; } }

		private long _SID;
		[LVRequired]
        public long SID { get { return _SID; } set {_SID = value; } }

		private TimeSpan _StartTime;
		[LVRequired]
        public TimeSpan StartTime { get { return _StartTime; } set {_StartTime = value; } }

		private TimeSpan _EndTime;
		[LVRequired]
        public TimeSpan EndTime { get { return _EndTime; } set {_EndTime = value; } }

		private long? _V_Purpose;
        public long? V_Purpose { get { return _V_Purpose; } set {_V_Purpose = value; } }

		private DateTime? _EffectivelyDate;
        public DateTime? EffectivelyDate { get { return _EffectivelyDate; } set {_EffectivelyDate = value; } }

		private DateTime? _ExpiredDate;
        public DateTime? ExpiredDate { get { return _ExpiredDate; } set {_ExpiredDate = value; } }

		/// <summary>
/// Ref Key: FK_Appointment_refTimeFrame
/// <summary>
/// <summary>
/// Ref Key: FK_BusySchedule_refTimeFrame
/// <summary>
/// <summary>
/// Ref Key: FK_refTimeFrame_refShift
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
    public class KeyedrefTimeFrame : KeyedCollection<KeyValuePair<string, short>, refTimeFrame>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefTimeFrame() : base() { }

        protected override KeyValuePair<string, short> GetKeyForItem(refTimeFrame item)
        {
            return item.Key;
        }

        public KeyValuePair<string, short> GetKey(short k_TFID) { return new KeyValuePair<string, short>("TFID", k_TFID); }

        public KeyValuePair<string, short> GetKey(object keypair) { try { return (KeyValuePair<string, short>)keypair; } catch { return new KeyValuePair<string, short>(); } }
        #endregion

        #region Method
        public bool AddObject(refTimeFrame item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, short> keypair, refTimeFrame item)
        {
            refTimeFrame orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refTimeFrame item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refTimeFrame item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refTimeFrame GetObjectByKey(short k_TFID) 
		{
            if (this.Contains(GetKey(k_TFID)) == false) return null;
            refTimeFrame ob = this[GetKey(k_TFID)];
            return (refTimeFrame)ob;
        }

		public refTimeFrame GetObjectByKey(short k_TFID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_TFID)) == false) {
				refTimeFrame ob = repository.GetQuery<refTimeFrame>().FirstOrDefault(o => o.TFID == k_TFID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refTimeFrame obj = this[GetKey(k_TFID)];
            return (refTimeFrame)obj;
        }

		public refTimeFrame GetObjectByKey(KeyValuePair<string, short> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refTimeFrame ob = this[keypair];
            return (refTimeFrame)ob;
        }

        public refTimeFrame GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refTimeFrame ob = this[GetKey(keypair)];
            return (refTimeFrame)ob;
        }

		bool _LoadAll = false;
        public List<refTimeFrame> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refTimeFrame>().ToList();
			foreach (refTimeFrame item in list) {
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

        ~KeyedrefTimeFrame()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
