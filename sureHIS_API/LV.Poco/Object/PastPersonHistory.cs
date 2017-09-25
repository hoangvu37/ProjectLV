/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PastPersonHistory.cs         
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
	public partial class PastPersonHistory : BaseEntity, ICloneable	{
		public PastPersonHistory()
		{
			this.PerHisID = 0;
			this.PtComMedRecID = 0;
			this.MHIndexID = 0;
            this.UsedTime = null;
            this.V_SHSeverity = null;
            this.IsStop = true;
            this.HExmPastHistPrevIllText = null;
            this.HExmHabitsText = null;
            this.HHistDtm = DateTime.Now;
            this.HExmHistSourceName = null;
            this.HExmHistSourceRelPtCode = null;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PerHisID", PerHisID); } }


		private long _PerHisID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PerHisID { get { return _PerHisID; } set {_PerHisID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long _MHIndexID;
		[LVRequired]
        public long MHIndexID { get { return _MHIndexID; } set {_MHIndexID = value; } }

		private short? _UsedTime;
        public short? UsedTime { get { return _UsedTime; } set {_UsedTime = value; } }

		private long? _V_SHSeverity;
        public long? V_SHSeverity { get { return _V_SHSeverity; } set {_V_SHSeverity = value; } }

		private bool? _IsStop;
        public bool? IsStop { get { return _IsStop; } set {_IsStop = value; } }

		private string _HExmPastHistPrevIllText;
        [LVMaxLength(50)]
        public string HExmPastHistPrevIllText { get { return _HExmPastHistPrevIllText; } set {_HExmPastHistPrevIllText = value; } }

		private string _HExmHabitsText;
        [LVMaxLength(50)]
        public string HExmHabitsText { get { return _HExmHabitsText; } set {_HExmHabitsText = value; } }

		private DateTime? _HHistDtm;
        public DateTime? HHistDtm { get { return _HHistDtm; } set {_HHistDtm = value; } }

		private string _HExmHistSourceName;
        [LVMaxLength(128)]
        public string HExmHistSourceName { get { return _HExmHistSourceName; } set {_HExmHistSourceName = value; } }

		private long? _HExmHistSourceRelPtCode;
        public long? HExmHistSourceRelPtCode { get { return _HExmHistSourceRelPtCode; } set {_HExmHistSourceRelPtCode = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_PastPersonHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_PastPersonHistory_refFAMRelationship
/// <summary>
/// <summary>
/// Ref Key: FK_PastPersonHistory_refMedHisIndex
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
    public class KeyedPastPersonHistory : KeyedCollection<KeyValuePair<string, long>, PastPersonHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPastPersonHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PastPersonHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PerHisID) { return new KeyValuePair<string, long>("PerHisID", k_PerHisID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PastPersonHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PastPersonHistory item)
        {
            PastPersonHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PastPersonHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PastPersonHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PastPersonHistory GetObjectByKey(long k_PerHisID) 
		{
            if (this.Contains(GetKey(k_PerHisID)) == false) return null;
            PastPersonHistory ob = this[GetKey(k_PerHisID)];
            return (PastPersonHistory)ob;
        }

		public PastPersonHistory GetObjectByKey(long k_PerHisID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PerHisID)) == false) {
				PastPersonHistory ob = repository.GetQuery<PastPersonHistory>().FirstOrDefault(o => o.PerHisID == k_PerHisID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PastPersonHistory obj = this[GetKey(k_PerHisID)];
            return (PastPersonHistory)obj;
        }

		public PastPersonHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PastPersonHistory ob = this[keypair];
            return (PastPersonHistory)ob;
        }

        public PastPersonHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PastPersonHistory ob = this[GetKey(keypair)];
            return (PastPersonHistory)ob;
        }

		bool _LoadAll = false;
        public List<PastPersonHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PastPersonHistory>().ToList();
			foreach (PastPersonHistory item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<PastPersonHistory> LoadIXFK_PastPersonHistory_refMedHisIndex(long p_MHIndexID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<PastPersonHistory>().Where(o=> o.MHIndexID == p_MHIndexID).ToList();
			foreach (PastPersonHistory item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
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

        ~KeyedPastPersonHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
