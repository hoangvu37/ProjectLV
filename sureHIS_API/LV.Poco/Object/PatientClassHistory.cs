/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientClassHistory.cs         
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
	public partial class PatientClassHistory : BaseEntity, ICloneable	{
		public PatientClassHistory()
		{
			this.PtClassHisID = 0;
			this.PtID = 0;
			this.PtClassID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtClassHisID", PtClassHisID); } }


		private long _PtClassHisID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtClassHisID { get { return _PtClassHisID; } set {_PtClassHisID = value; } }

		private long _PtID;
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private long _PtClassID;
		[LVRequired]
        public long PtClassID { get { return _PtClassID; } set {_PtClassID = value; } }

		private DateTime _PCFromDate;
		[LVRequired]
        public DateTime PCFromDate { get { return _PCFromDate; } set {_PCFromDate = value; } }

		private DateTime? _PCToDate;
        public DateTime? PCToDate { get { return _PCToDate; } set {_PCToDate = value; } }

		/// <summary>
/// Ref Key: FK_PatientClassHistory_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientTransaction_PatientClassHistory_02
/// <summary>
/// <summary>
/// Ref Key: FK_PtCHis_PtClassification
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
    public class KeyedPatientClassHistory : KeyedCollection<KeyValuePair<string, long>, PatientClassHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientClassHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientClassHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtClassHisID) { return new KeyValuePair<string, long>("PtClassHisID", k_PtClassHisID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientClassHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientClassHistory item)
        {
            PatientClassHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientClassHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientClassHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientClassHistory GetObjectByKey(long k_PtClassHisID) 
		{
            if (this.Contains(GetKey(k_PtClassHisID)) == false) return null;
            PatientClassHistory ob = this[GetKey(k_PtClassHisID)];
            return (PatientClassHistory)ob;
        }

		public PatientClassHistory GetObjectByKey(long k_PtClassHisID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtClassHisID)) == false) {
				PatientClassHistory ob = repository.GetQuery<PatientClassHistory>().FirstOrDefault(o => o.PtClassHisID == k_PtClassHisID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientClassHistory obj = this[GetKey(k_PtClassHisID)];
            return (PatientClassHistory)obj;
        }

		public PatientClassHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientClassHistory ob = this[keypair];
            return (PatientClassHistory)ob;
        }

        public PatientClassHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientClassHistory ob = this[GetKey(keypair)];
            return (PatientClassHistory)ob;
        }

		bool _LoadAll = false;
        public List<PatientClassHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientClassHistory>().ToList();
			foreach (PatientClassHistory item in list) {
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

        ~KeyedPatientClassHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
