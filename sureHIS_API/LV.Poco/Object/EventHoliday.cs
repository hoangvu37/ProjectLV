/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EventHoliday.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class EventHoliday : BaseEntity, ICloneable	{
		public EventHoliday()
		{
			this.HldID = 0;
            this.DayObserved = DateTime.Now;
			this.YearNumber = 0;
            this.IsNationalHolidays = true;
            this.NotOneDay = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HldID", HldID); } }


		private long _HldID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HldID { get { return _HldID; } set {_HldID = value; } }

		private string _HldName;
		[LVRequired]
        [LVMaxLength(50)]
        public string HldName { get { return _HldName; } set {_HldName = value; } }

		private DateTime _DayObserved;
		[LVRequired]
        public DateTime DayObserved { get { return _DayObserved; } set {_DayObserved = value; } }

		private short _YearNumber;
		[LVRequired]
        public short YearNumber { get { return _YearNumber; } set {_YearNumber = value; } }

		private bool? _IsNationalHolidays;
        public bool? IsNationalHolidays { get { return _IsNationalHolidays; } set {_IsNationalHolidays = value; } }

		private bool? _NotOneDay;
        public bool? NotOneDay { get { return _NotOneDay; } set {_NotOneDay = value; } }

		

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
    public class KeyedEventHoliday : KeyedCollection<KeyValuePair<string, long>, EventHoliday>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEventHoliday() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EventHoliday item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HldID) { return new KeyValuePair<string, long>("HldID", k_HldID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EventHoliday item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EventHoliday item)
        {
            EventHoliday orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EventHoliday item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EventHoliday item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EventHoliday GetObjectByKey(long k_HldID) 
		{
            if (this.Contains(GetKey(k_HldID)) == false) return null;
            EventHoliday ob = this[GetKey(k_HldID)];
            return (EventHoliday)ob;
        }

		public EventHoliday GetObjectByKey(long k_HldID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HldID)) == false) {
				EventHoliday ob = repository.GetQuery<EventHoliday>().FirstOrDefault(o => o.HldID == k_HldID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EventHoliday obj = this[GetKey(k_HldID)];
            return (EventHoliday)obj;
        }

		public EventHoliday GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EventHoliday ob = this[keypair];
            return (EventHoliday)ob;
        }

        public EventHoliday GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EventHoliday ob = this[GetKey(keypair)];
            return (EventHoliday)ob;
        }

		bool _LoadAll = false;
        public List<EventHoliday> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EventHoliday>().ToList();
			foreach (EventHoliday item in list) {
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

        ~KeyedEventHoliday()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
