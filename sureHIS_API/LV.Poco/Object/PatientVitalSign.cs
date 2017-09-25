/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientVitalSign.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class PatientVitalSign : BaseEntity, ICloneable	{
		public PatientVitalSign()
		{
			this.VsID = 0;
			this.MedEncnID = 0;
			this.PtComMedRecID = 0;
			this.VitSignCode = 0;
			this.VitSignUnitCode = 0;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("VsID", VsID); } }


		private long _VsID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long VsID { get { return _VsID; } set {_VsID = value; } }

		private long? _MedEncnID;
        public long? MedEncnID { get { return _MedEncnID; } set {_MedEncnID = value; } }

		private long? _PtComMedRecID;
        public long? PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long _VitSignCode;
		[LVRequired]
        public long VitSignCode { get { return _VitSignCode; } set {_VitSignCode = value; } }

		private DateTime _VitSignDtm;
		[LVRequired]
        public DateTime VitSignDtm { get { return _VitSignDtm; } set {_VitSignDtm = value; } }

		private string _VitSignQty;
		[LVRequired]
        [LVMaxLength(10)]
        public string VitSignQty { get { return _VitSignQty; } set {_VitSignQty = value; } }

		private long? _VitSignUnitCode;
        public long? VitSignUnitCode { get { return _VitSignUnitCode; } set {_VitSignUnitCode = value; } }

		private string _Executor;
		[LVRequired]
        [LVMaxLength(20)]
        public string Executor { get { return _Executor; } set {_Executor = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_PatientVitalSign_MedicalEncounter
/// <summary>
/// <summary>
/// Ref Key: FK_PatientVitalSign_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_PatientVitalSign_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_PatientVitalSign_refVitalSign
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
    public class KeyedPatientVitalSign : KeyedCollection<KeyValuePair<string, long>, PatientVitalSign>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientVitalSign() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientVitalSign item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_VsID) { return new KeyValuePair<string, long>("VsID", k_VsID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientVitalSign item)
        {
            PatientVitalSign orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientVitalSign GetObjectByKey(long k_VsID) 
		{
            if (this.Contains(GetKey(k_VsID)) == false) return null;
            PatientVitalSign ob = this[GetKey(k_VsID)];
            return (PatientVitalSign)ob;
        }

		public PatientVitalSign GetObjectByKey(long k_VsID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_VsID)) == false) {
				PatientVitalSign ob = repository.GetQuery<PatientVitalSign>().FirstOrDefault(o => o.VsID == k_VsID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientVitalSign obj = this[GetKey(k_VsID)];
            return (PatientVitalSign)obj;
        }

		public PatientVitalSign GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientVitalSign ob = this[keypair];
            return (PatientVitalSign)ob;
        }

        public PatientVitalSign GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientVitalSign ob = this[GetKey(keypair)];
            return (PatientVitalSign)ob;
        }

		bool _LoadAll = false;
        public List<PatientVitalSign> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientVitalSign>().ToList();
			foreach (PatientVitalSign item in list) {
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

        ~KeyedPatientVitalSign()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
