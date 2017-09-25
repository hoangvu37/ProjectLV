/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ClinicalTrialResult.cs         
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
	public partial class ClinicalTrialResult : BaseEntity, ICloneable	{
		public ClinicalTrialResult()
		{
			this.ClintRsltID = 0;
			this.ClintID = 0;
			this.V_ClinicalTestResult = 0;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ClintRsltID", ClintRsltID); } }


		private long _ClintRsltID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ClintRsltID { get { return _ClintRsltID; } set {_ClintRsltID = value; } }

		private long? _ClintID;
        public long? ClintID { get { return _ClintID; } set {_ClintID = value; } }

		private long? _V_ClinicalTestResult;
        public long? V_ClinicalTestResult { get { return _V_ClinicalTestResult; } set {_V_ClinicalTestResult = value; } }

		private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_ClinicalTrialResult_ClinicalTrial
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
    public class KeyedClinicalTrialResult : KeyedCollection<KeyValuePair<string, long>, ClinicalTrialResult>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedClinicalTrialResult() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ClinicalTrialResult item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ClintRsltID) { return new KeyValuePair<string, long>("ClintRsltID", k_ClintRsltID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ClinicalTrialResult item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ClinicalTrialResult item)
        {
            ClinicalTrialResult orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ClinicalTrialResult item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ClinicalTrialResult item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ClinicalTrialResult GetObjectByKey(long k_ClintRsltID) 
		{
            if (this.Contains(GetKey(k_ClintRsltID)) == false) return null;
            ClinicalTrialResult ob = this[GetKey(k_ClintRsltID)];
            return (ClinicalTrialResult)ob;
        }

		public ClinicalTrialResult GetObjectByKey(long k_ClintRsltID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ClintRsltID)) == false) {
				ClinicalTrialResult ob = repository.GetQuery<ClinicalTrialResult>().FirstOrDefault(o => o.ClintRsltID == k_ClintRsltID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ClinicalTrialResult obj = this[GetKey(k_ClintRsltID)];
            return (ClinicalTrialResult)obj;
        }

		public ClinicalTrialResult GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ClinicalTrialResult ob = this[keypair];
            return (ClinicalTrialResult)ob;
        }

        public ClinicalTrialResult GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ClinicalTrialResult ob = this[GetKey(keypair)];
            return (ClinicalTrialResult)ob;
        }

		bool _LoadAll = false;
        public List<ClinicalTrialResult> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ClinicalTrialResult>().ToList();
			foreach (ClinicalTrialResult item in list) {
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

        ~KeyedClinicalTrialResult()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
