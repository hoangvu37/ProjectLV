/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ReminderNotices.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class ReminderNotices : BaseEntity, ICloneable	{
		public ReminderNotices()
		{
			this.NoticesID = 0;
			this.V_ReminderNoticesTypes = 0;
            this.IsBuiltIn = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("NoticesID", NoticesID); } }


		private long _NoticesID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long NoticesID { get { return _NoticesID; } set {_NoticesID = value; } }

		private string _NoticesContents;
		[LVRequired]
        [LVMaxLength(256)]
        public string NoticesContents { get { return _NoticesContents; } set {_NoticesContents = value; } }

		private long _V_ReminderNoticesTypes;
		[LVRequired]
        public long V_ReminderNoticesTypes { get { return _V_ReminderNoticesTypes; } set {_V_ReminderNoticesTypes = value; } }

		private bool? _IsBuiltIn;
        public bool? IsBuiltIn { get { return _IsBuiltIn; } set {_IsBuiltIn = value; } }

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
    public class KeyedReminderNotices : KeyedCollection<KeyValuePair<string, long>, ReminderNotices>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedReminderNotices() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ReminderNotices item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_NoticesID) { return new KeyValuePair<string, long>("NoticesID", k_NoticesID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ReminderNotices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ReminderNotices item)
        {
            ReminderNotices orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ReminderNotices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ReminderNotices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ReminderNotices GetObjectByKey(long k_NoticesID) 
		{
            if (this.Contains(GetKey(k_NoticesID)) == false) return null;
            ReminderNotices ob = this[GetKey(k_NoticesID)];
            return (ReminderNotices)ob;
        }

		public ReminderNotices GetObjectByKey(long k_NoticesID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_NoticesID)) == false) {
				ReminderNotices ob = repository.GetQuery<ReminderNotices>().FirstOrDefault(o => o.NoticesID == k_NoticesID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ReminderNotices obj = this[GetKey(k_NoticesID)];
            return (ReminderNotices)obj;
        }

		public ReminderNotices GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ReminderNotices ob = this[keypair];
            return (ReminderNotices)ob;
        }

        public ReminderNotices GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ReminderNotices ob = this[GetKey(keypair)];
            return (ReminderNotices)ob;
        }

		bool _LoadAll = false;
        public List<ReminderNotices> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ReminderNotices>().ToList();
			foreach (ReminderNotices item in list) {
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

        ~KeyedReminderNotices()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
