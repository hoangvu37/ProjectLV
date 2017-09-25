/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HistoricalAuditData.cs         
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
	public partial class HistoricalAuditData : BaseEntity, ICloneable	{
		public HistoricalAuditData()
		{
			this.ID = 0;
            this.KeepTrackDtm = DateTime.Now;
			this.AuditRowNo = 0;
            this.AuditDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ID", ID); } }


		private long _ID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ID { get { return _ID; } set {_ID = value; } }

		private DateTime _KeepTrackDtm;
		[LVRequired]
        public DateTime KeepTrackDtm { get { return _KeepTrackDtm; } set {_KeepTrackDtm = value; } }

		private string _DBUsr;
        [LVMaxLength(64)]
        public string DBUsr { get { return _DBUsr; } set {_DBUsr = value; } }

		private string _AppUsr;
        [LVMaxLength(64)]
        public string AppUsr { get { return _AppUsr; } set {_AppUsr = value; } }

		private string _HostName;
        [LVMaxLength(64)]
        public string HostName { get { return _HostName; } set {_HostName = value; } }

		private string _AuditTblName;
		[LVRequired]
        [LVMaxLength(64)]
        public string AuditTblName { get { return _AuditTblName; } set {_AuditTblName = value; } }

		private long _AuditRowNo;
		[LVRequired]
        public long AuditRowNo { get { return _AuditRowNo; } set {_AuditRowNo = value; } }

		private string _AuditType;
		[LVRequired]
        [LVMaxLength(1)]
        public string AuditType { get { return _AuditType; } set {_AuditType = value; } }

		private string _AuditDesc;
        [LVMaxLength(512)]
        public string AuditDesc { get { return _AuditDesc; } set {_AuditDesc = value; } }

		

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
    public class KeyedHistoricalAuditData : KeyedCollection<KeyValuePair<string, long>, HistoricalAuditData>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHistoricalAuditData() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HistoricalAuditData item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ID) { return new KeyValuePair<string, long>("ID", k_ID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HistoricalAuditData item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HistoricalAuditData item)
        {
            HistoricalAuditData orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HistoricalAuditData item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HistoricalAuditData item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HistoricalAuditData GetObjectByKey(long k_ID) 
		{
            if (this.Contains(GetKey(k_ID)) == false) return null;
            HistoricalAuditData ob = this[GetKey(k_ID)];
            return (HistoricalAuditData)ob;
        }

		public HistoricalAuditData GetObjectByKey(long k_ID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ID)) == false) {
				HistoricalAuditData ob = repository.GetQuery<HistoricalAuditData>().FirstOrDefault(o => o.ID == k_ID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HistoricalAuditData obj = this[GetKey(k_ID)];
            return (HistoricalAuditData)obj;
        }

		public HistoricalAuditData GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HistoricalAuditData ob = this[keypair];
            return (HistoricalAuditData)ob;
        }

        public HistoricalAuditData GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HistoricalAuditData ob = this[GetKey(keypair)];
            return (HistoricalAuditData)ob;
        }

		bool _LoadAll = false;
        public List<HistoricalAuditData> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HistoricalAuditData>().ToList();
			foreach (HistoricalAuditData item in list) {
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

        ~KeyedHistoricalAuditData()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
