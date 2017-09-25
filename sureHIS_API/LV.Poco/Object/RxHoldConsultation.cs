/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : RxHoldConsultation.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class RxHoldConsultation : BaseEntity, ICloneable	{
		public RxHoldConsultation()
		{
			this.RxHCID = 0;
            this.HCDateTime = DateTime.Now;
			this.EmpID = 0;
			this.V_HCReason = 0;
            this.V_HCForm = null;
            this.V_HCResult = null;
            this.Notes = null;
			this.PresID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("RxHCID", RxHCID); } }


		private long _RxHCID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long RxHCID { get { return _RxHCID; } set {_RxHCID = value; } }

		private DateTime _HCDateTime;
		[LVRequired]
        public DateTime HCDateTime { get { return _HCDateTime; } set {_HCDateTime = value; } }

		private long _EmpID;
		[LVRequired]
        public long EmpID { get { return _EmpID; } set {_EmpID = value; } }

		private long? _V_HCReason;
        public long? V_HCReason { get { return _V_HCReason; } set {_V_HCReason = value; } }

		private long? _V_HCForm;
        public long? V_HCForm { get { return _V_HCForm; } set {_V_HCForm = value; } }

		private long? _V_HCResult;
        public long? V_HCResult { get { return _V_HCResult; } set {_V_HCResult = value; } }

		private string _Notes;
        [LVMaxLength(1024)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private long? _PresID;
        public long? PresID { get { return _PresID; } set {_PresID = value; } }

		/// <summary>
/// Ref Key: FK_RxHoldConsultation_Prescription
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
    public class KeyedRxHoldConsultation : KeyedCollection<KeyValuePair<string, long>, RxHoldConsultation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedRxHoldConsultation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(RxHoldConsultation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_RxHCID) { return new KeyValuePair<string, long>("RxHCID", k_RxHCID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(RxHoldConsultation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, RxHoldConsultation item)
        {
            RxHoldConsultation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(RxHoldConsultation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(RxHoldConsultation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public RxHoldConsultation GetObjectByKey(long k_RxHCID) 
		{
            if (this.Contains(GetKey(k_RxHCID)) == false) return null;
            RxHoldConsultation ob = this[GetKey(k_RxHCID)];
            return (RxHoldConsultation)ob;
        }

		public RxHoldConsultation GetObjectByKey(long k_RxHCID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_RxHCID)) == false) {
				RxHoldConsultation ob = repository.GetQuery<RxHoldConsultation>().FirstOrDefault(o => o.RxHCID == k_RxHCID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            RxHoldConsultation obj = this[GetKey(k_RxHCID)];
            return (RxHoldConsultation)obj;
        }

		public RxHoldConsultation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            RxHoldConsultation ob = this[keypair];
            return (RxHoldConsultation)ob;
        }

        public RxHoldConsultation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            RxHoldConsultation ob = this[GetKey(keypair)];
            return (RxHoldConsultation)ob;
        }

		bool _LoadAll = false;
        public List<RxHoldConsultation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<RxHoldConsultation>().ToList();
			foreach (RxHoldConsultation item in list) {
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

        ~KeyedRxHoldConsultation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
