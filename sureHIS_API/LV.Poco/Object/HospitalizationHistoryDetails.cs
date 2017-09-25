/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HospitalizationHistoryDetails.cs         
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
	public partial class HospitalizationHistoryDetails : BaseEntity, ICloneable	{
		public HospitalizationHistoryDetails()
		{
			this.HosHisDetailID = 0;
			this.HosHisID = 0;
            this.HosHisDetailNotes = null;
			this.DeptID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HosHisDetailID", HosHisDetailID); } }


		private long _HosHisDetailID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HosHisDetailID { get { return _HosHisDetailID; } set {_HosHisDetailID = value; } }

		private long _HosHisID;
		[LVRequired]
        public long HosHisID { get { return _HosHisID; } set {_HosHisID = value; } }

		private DateTime _DateTimeTransfer;
		[LVRequired]
        public DateTime DateTimeTransfer { get { return _DateTimeTransfer; } set {_DateTimeTransfer = value; } }

		private string _HosHisDetailNotes;
        [LVMaxLength(254)]
        public string HosHisDetailNotes { get { return _HosHisDetailNotes; } set {_HosHisDetailNotes = value; } }

		private long _DeptID;
		[LVRequired]
        public long DeptID { get { return _DeptID; } set {_DeptID = value; } }

		/// <summary>
/// Ref Key: FK_HospitalizationHistoryDetails_HospitalizationHistory
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
    public class KeyedHospitalizationHistoryDetails : KeyedCollection<KeyValuePair<string, long>, HospitalizationHistoryDetails>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHospitalizationHistoryDetails() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HospitalizationHistoryDetails item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HosHisDetailID) { return new KeyValuePair<string, long>("HosHisDetailID", k_HosHisDetailID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HospitalizationHistoryDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HospitalizationHistoryDetails item)
        {
            HospitalizationHistoryDetails orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HospitalizationHistoryDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HospitalizationHistoryDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HospitalizationHistoryDetails GetObjectByKey(long k_HosHisDetailID) 
		{
            if (this.Contains(GetKey(k_HosHisDetailID)) == false) return null;
            HospitalizationHistoryDetails ob = this[GetKey(k_HosHisDetailID)];
            return (HospitalizationHistoryDetails)ob;
        }

		public HospitalizationHistoryDetails GetObjectByKey(long k_HosHisDetailID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HosHisDetailID)) == false) {
				HospitalizationHistoryDetails ob = repository.GetQuery<HospitalizationHistoryDetails>().FirstOrDefault(o => o.HosHisDetailID == k_HosHisDetailID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HospitalizationHistoryDetails obj = this[GetKey(k_HosHisDetailID)];
            return (HospitalizationHistoryDetails)obj;
        }

		public HospitalizationHistoryDetails GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HospitalizationHistoryDetails ob = this[keypair];
            return (HospitalizationHistoryDetails)ob;
        }

        public HospitalizationHistoryDetails GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HospitalizationHistoryDetails ob = this[GetKey(keypair)];
            return (HospitalizationHistoryDetails)ob;
        }

		bool _LoadAll = false;
        public List<HospitalizationHistoryDetails> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HospitalizationHistoryDetails>().ToList();
			foreach (HospitalizationHistoryDetails item in list) {
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

        ~KeyedHospitalizationHistoryDetails()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
