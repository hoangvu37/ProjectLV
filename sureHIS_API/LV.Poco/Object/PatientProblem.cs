/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientProblem.cs         
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
	public partial class PatientProblem : BaseEntity, ICloneable	{
		public PatientProblem()
		{
			this.PtProblemID = 0;
			this.PHProbCode = 0;
			this.MedEncnID = 0;
            this.PHProbProbOnsetDtm = DateTime.Now;
			this.H7PHProbStatusCode = 0;
            this.PHProbNote = null;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtProblemID", PtProblemID); } }


		private long _PtProblemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtProblemID { get { return _PtProblemID; } set {_PtProblemID = value; } }

		private long _PHProbCode;
		[LVRequired]
        public long PHProbCode { get { return _PHProbCode; } set {_PHProbCode = value; } }

		private long _MedEncnID;
		[LVRequired]
        public long MedEncnID { get { return _MedEncnID; } set {_MedEncnID = value; } }

		private DateTime? _PHProbProbOnsetDtm;
        public DateTime? PHProbProbOnsetDtm { get { return _PHProbProbOnsetDtm; } set {_PHProbProbOnsetDtm = value; } }

		private long _H7PHProbStatusCode;
		[LVRequired]
        public long H7PHProbStatusCode { get { return _H7PHProbStatusCode; } set {_H7PHProbStatusCode = value; } }

		private string _PHProbNote;
        [LVMaxLength(254)]
        public string PHProbNote { get { return _PHProbNote; } set {_PHProbNote = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_PatientProblem_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_PatientProblem_RefProblem
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
    public class KeyedPatientProblem : KeyedCollection<KeyValuePair<string, long>, PatientProblem>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientProblem() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientProblem item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtProblemID) { return new KeyValuePair<string, long>("PtProblemID", k_PtProblemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientProblem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientProblem item)
        {
            PatientProblem orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientProblem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientProblem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientProblem GetObjectByKey(long k_PtProblemID) 
		{
            if (this.Contains(GetKey(k_PtProblemID)) == false) return null;
            PatientProblem ob = this[GetKey(k_PtProblemID)];
            return (PatientProblem)ob;
        }

		public PatientProblem GetObjectByKey(long k_PtProblemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtProblemID)) == false) {
				PatientProblem ob = repository.GetQuery<PatientProblem>().FirstOrDefault(o => o.PtProblemID == k_PtProblemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientProblem obj = this[GetKey(k_PtProblemID)];
            return (PatientProblem)obj;
        }

		public PatientProblem GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientProblem ob = this[keypair];
            return (PatientProblem)ob;
        }

        public PatientProblem GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientProblem ob = this[GetKey(keypair)];
            return (PatientProblem)ob;
        }

		bool _LoadAll = false;
        public List<PatientProblem> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientProblem>().ToList();
			foreach (PatientProblem item in list) {
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

        ~KeyedPatientProblem()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
