/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Alert.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class Alert : BaseEntity, ICloneable	{
		public Alert()
		{
			this.AlertID = 0;
			this.NoticesID = 0;
			this.AppID = 0;
            this.AlertTime = DateTime.Now;
            this.isCompleted = false;
            this.V_Frequency = null;
            this.V_ReminderTimes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AlertID", AlertID); } }


		private long _AlertID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AlertID { get { return _AlertID; } set {_AlertID = value; } }

		private long _NoticesID;
		[LVRequired]
        public long NoticesID { get { return _NoticesID; } set {_NoticesID = value; } }

		private long _AppID;
		[LVRequired]
        public long AppID { get { return _AppID; } set {_AppID = value; } }

		private DateTime _AlertTime;
		[LVRequired]
        public DateTime AlertTime { get { return _AlertTime; } set {_AlertTime = value; } }

		private bool _isCompleted;
        public bool isCompleted { get { return _isCompleted; } set {_isCompleted = value; } }

		private long? _V_Frequency;
        public long? V_Frequency { get { return _V_Frequency; } set {_V_Frequency = value; } }

		private long? _V_ReminderTimes;
        public long? V_ReminderTimes { get { return _V_ReminderTimes; } set {_V_ReminderTimes = value; } }

		/// <summary>
/// Ref Key: FK_Alert_Appointment
/// <summary>
/// <summary>
/// Ref Key: FK_Alert_Reminder
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
    public class KeyedAlert : KeyedCollection<KeyValuePair<string, long>, Alert>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAlert() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Alert item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AlertID) { return new KeyValuePair<string, long>("AlertID", k_AlertID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Alert item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Alert item)
        {
            Alert orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Alert item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Alert item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Alert GetObjectByKey(long k_AlertID) 
		{
            if (this.Contains(GetKey(k_AlertID)) == false) return null;
            Alert ob = this[GetKey(k_AlertID)];
            return (Alert)ob;
        }

		public Alert GetObjectByKey(long k_AlertID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AlertID)) == false) {
				Alert ob = repository.GetQuery<Alert>().FirstOrDefault(o => o.AlertID == k_AlertID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Alert obj = this[GetKey(k_AlertID)];
            return (Alert)obj;
        }

		public Alert GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Alert ob = this[keypair];
            return (Alert)ob;
        }

        public Alert GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Alert ob = this[GetKey(keypair)];
            return (Alert)ob;
        }

		bool _LoadAll = false;
        public List<Alert> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Alert>().ToList();
			foreach (Alert item in list) {
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

        ~KeyedAlert()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
