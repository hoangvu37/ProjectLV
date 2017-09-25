/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refShift.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class refShift : BaseEntity, ICloneable	{
		public refShift()
		{
			this.SID = 0;
            this.AMPM = null;
            this.isNotEffect = true;
            this.ShiftIdx = 1;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SID", SID); } }


		private long _SID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SID { get { return _SID; } set {_SID = value; } }

		private string _ShiftCode;
		[LVRequired]
        [LVMaxLength(5)]
        public string ShiftCode { get { return _ShiftCode; } set {_ShiftCode = value; } }

		private string _ShiftName;
		[LVRequired]
        [LVMaxLength(64)]
        public string ShiftName { get { return _ShiftName; } set {_ShiftName = value; } }

		private string _ShiftDesc;
        [LVMaxLength(512)]
        public string ShiftDesc { get { return _ShiftDesc; } set {_ShiftDesc = value; } }

		private TimeSpan _StartTime;
		[LVRequired]
        public TimeSpan StartTime { get { return _StartTime; } set {_StartTime = value; } }

		private TimeSpan _EndTime;
		[LVRequired]
        public TimeSpan EndTime { get { return _EndTime; } set {_EndTime = value; } }

		private string _AMPM;
        [LVMaxLength(50)]
        public string AMPM { get { return _AMPM; } set {_AMPM = value; } }

		private bool? _isNotEffect;
        public bool? isNotEffect { get { return _isNotEffect; } set {_isNotEffect = value; } }

		private byte _ShiftIdx;
		[LVRequired]
        public byte ShiftIdx { get { return _ShiftIdx; } set {_ShiftIdx = value; } }

		/// <summary>
/// Ref Key: FK_Operations_refShift
/// <summary>
/// <summary>
/// Ref Key: FK_refTimeFrame_refShift
/// <summary>
/// <summary>
/// Ref Key: FK_WorkingSchedule_refShift
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
    public class KeyedrefShift : KeyedCollection<KeyValuePair<string, long>, refShift>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefShift() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refShift item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SID) { return new KeyValuePair<string, long>("SID", k_SID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refShift item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refShift item)
        {
            refShift orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refShift item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refShift item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refShift GetObjectByKey(long k_SID) 
		{
            if (this.Contains(GetKey(k_SID)) == false) return null;
            refShift ob = this[GetKey(k_SID)];
            return (refShift)ob;
        }

		public refShift GetObjectByKey(long k_SID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SID)) == false) {
				refShift ob = repository.GetQuery<refShift>().FirstOrDefault(o => o.SID == k_SID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refShift obj = this[GetKey(k_SID)];
            return (refShift)obj;
        }

		public refShift GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refShift ob = this[keypair];
            return (refShift)ob;
        }

        public refShift GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refShift ob = this[GetKey(keypair)];
            return (refShift)ob;
        }

		bool _LoadAll = false;
        public List<refShift> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refShift>().ToList();
			foreach (refShift item in list) {
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

        ~KeyedrefShift()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
