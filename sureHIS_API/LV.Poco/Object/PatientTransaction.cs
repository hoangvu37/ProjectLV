/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientTransaction.cs         
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
	public partial class PatientTransaction : BaseEntity, ICloneable	{
		public PatientTransaction()
		{
			this.TransID = 0;
            this.TransBeginDate = DateTime.Now;
            this.TransEndDate = DateTime.Now;
            this.TransRemarks = null;
			this.PtID = 0;
            this.PTClassHisID = null;
			this.TransTypeID = 0;
			this.AdmID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("TransID", TransID); } }


		private long _TransID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long TransID { get { return _TransID; } set {_TransID = value; } }

		private DateTime _TransBeginDate;
		[LVRequired]
        public DateTime TransBeginDate { get { return _TransBeginDate; } set {_TransBeginDate = value; } }

		private DateTime? _TransEndDate;
        public DateTime? TransEndDate { get { return _TransEndDate; } set {_TransEndDate = value; } }

		private string _TransRemarks;
        [LVMaxLength(2048)]
        public string TransRemarks { get { return _TransRemarks; } set {_TransRemarks = value; } }

		private long _PtID;
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private long? _PTClassHisID;
        public long? PTClassHisID { get { return _PTClassHisID; } set {_PTClassHisID = value; } }

		private long _TransTypeID;
		[LVRequired]
        public long TransTypeID { get { return _TransTypeID; } set {_TransTypeID = value; } }

		private long? _AdmID;
        public long? AdmID { get { return _AdmID; } set {_AdmID = value; } }

		/// <summary>
/// Ref Key: FK_PatientTransaction_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientTransaction_PatientAdmission
/// <summary>
/// <summary>
/// Ref Key: FK_PatientTransaction_PatientClassHistory_02
/// <summary>
/// <summary>
/// Ref Key: FK_PatientTransaction_refTransactionType
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
    public class KeyedPatientTransaction : KeyedCollection<KeyValuePair<string, long>, PatientTransaction>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientTransaction() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientTransaction item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_TransID) { return new KeyValuePair<string, long>("TransID", k_TransID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientTransaction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientTransaction item)
        {
            PatientTransaction orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientTransaction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientTransaction item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientTransaction GetObjectByKey(long k_TransID) 
		{
            if (this.Contains(GetKey(k_TransID)) == false) return null;
            PatientTransaction ob = this[GetKey(k_TransID)];
            return (PatientTransaction)ob;
        }

		public PatientTransaction GetObjectByKey(long k_TransID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_TransID)) == false) {
				PatientTransaction ob = repository.GetQuery<PatientTransaction>().FirstOrDefault(o => o.TransID == k_TransID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientTransaction obj = this[GetKey(k_TransID)];
            return (PatientTransaction)obj;
        }

		public PatientTransaction GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientTransaction ob = this[keypair];
            return (PatientTransaction)ob;
        }

        public PatientTransaction GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientTransaction ob = this[GetKey(keypair)];
            return (PatientTransaction)ob;
        }

		bool _LoadAll = false;
        public List<PatientTransaction> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientTransaction>().ToList();
			foreach (PatientTransaction item in list) {
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

        ~KeyedPatientTransaction()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
