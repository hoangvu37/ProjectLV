/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ImmunizationHistory.cs         
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
	public partial class ImmunizationHistory : BaseEntity, ICloneable	{
		public ImmunizationHistory()
		{
			this.ImmHisID = 0;
			this.PtComMedRecID = 0;
            this.ImmID = null;
            this.ImmDtm = DateTime.Now;
            this.IsUnknow = false;
            this.ImmRemarksText = null;
            this.ModifiedDate = DateTime.Now;
			this.EstEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ImmHisID", ImmHisID); } }


		private long _ImmHisID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ImmHisID { get { return _ImmHisID; } set {_ImmHisID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long? _ImmID;
        public long? ImmID { get { return _ImmID; } set {_ImmID = value; } }

		private DateTime? _ImmDtm;
        public DateTime? ImmDtm { get { return _ImmDtm; } set {_ImmDtm = value; } }

		private bool _IsUnknow;
        public bool IsUnknow { get { return _IsUnknow; } set {_IsUnknow = value; } }

		private string _ImmRemarksText;
        [LVMaxLength(254)]
        public string ImmRemarksText { get { return _ImmRemarksText; } set {_ImmRemarksText = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_ImmunizationHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_ImmunizationHistory_refImmunization
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
    public class KeyedImmunizationHistory : KeyedCollection<KeyValuePair<string, long>, ImmunizationHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedImmunizationHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ImmunizationHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ImmHisID) { return new KeyValuePair<string, long>("ImmHisID", k_ImmHisID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ImmunizationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ImmunizationHistory item)
        {
            ImmunizationHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ImmunizationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ImmunizationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ImmunizationHistory GetObjectByKey(long k_ImmHisID) 
		{
            if (this.Contains(GetKey(k_ImmHisID)) == false) return null;
            ImmunizationHistory ob = this[GetKey(k_ImmHisID)];
            return (ImmunizationHistory)ob;
        }

		public ImmunizationHistory GetObjectByKey(long k_ImmHisID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ImmHisID)) == false) {
				ImmunizationHistory ob = repository.GetQuery<ImmunizationHistory>().FirstOrDefault(o => o.ImmHisID == k_ImmHisID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ImmunizationHistory obj = this[GetKey(k_ImmHisID)];
            return (ImmunizationHistory)obj;
        }

		public ImmunizationHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ImmunizationHistory ob = this[keypair];
            return (ImmunizationHistory)ob;
        }

        public ImmunizationHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ImmunizationHistory ob = this[GetKey(keypair)];
            return (ImmunizationHistory)ob;
        }

		bool _LoadAll = false;
        public List<ImmunizationHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ImmunizationHistory>().ToList();
			foreach (ImmunizationHistory item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<ImmunizationHistory> LoadIXFK_ImmunizationHistory_refImmunization(long p_ImmID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<ImmunizationHistory>().Where(o=> o.ImmID == p_ImmID).ToList();
			foreach (ImmunizationHistory item in list) {
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

        ~KeyedImmunizationHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
