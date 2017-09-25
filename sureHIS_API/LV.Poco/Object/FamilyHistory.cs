/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : FamilyHistory.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class FamilyHistory : BaseEntity, ICloneable	{
		public FamilyHistory()
		{
			this.PatientFamilyID = 0;
			this.PtComMedRecID = 0;
			this.FAMMbrRelationshipCode = 0;
            this.FAMMbrStatus = null;
            this.RelaPatientID = null;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PatientFamilyID", PatientFamilyID); } }


		private long _PatientFamilyID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PatientFamilyID { get { return _PatientFamilyID; } set {_PatientFamilyID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private string _FAMMbrName;
		[LVRequired]
        [LVMaxLength(128)]
        public string FAMMbrName { get { return _FAMMbrName; } set {_FAMMbrName = value; } }

		private long _FAMMbrRelationshipCode;
		[LVRequired]
        public long FAMMbrRelationshipCode { get { return _FAMMbrRelationshipCode; } set {_FAMMbrRelationshipCode = value; } }

		private string _FAMMbrMajDiagDeathCode;
		[LVRequired]
        [LVMaxLength(50)]
        public string FAMMbrMajDiagDeathCode { get { return _FAMMbrMajDiagDeathCode; } set {_FAMMbrMajDiagDeathCode = value; } }

		private string _FAMMbrStatus;
        [LVMaxLength(16)]
        public string FAMMbrStatus { get { return _FAMMbrStatus; } set {_FAMMbrStatus = value; } }

		private long? _RelaPatientID;
        public long? RelaPatientID { get { return _RelaPatientID; } set {_RelaPatientID = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_FamilyHistory_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_FamilyHistory_refFAMRelationship
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
    public class KeyedFamilyHistory : KeyedCollection<KeyValuePair<string, long>, FamilyHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedFamilyHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(FamilyHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PatientFamilyID) { return new KeyValuePair<string, long>("PatientFamilyID", k_PatientFamilyID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(FamilyHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, FamilyHistory item)
        {
            FamilyHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(FamilyHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(FamilyHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public FamilyHistory GetObjectByKey(long k_PatientFamilyID) 
		{
            if (this.Contains(GetKey(k_PatientFamilyID)) == false) return null;
            FamilyHistory ob = this[GetKey(k_PatientFamilyID)];
            return (FamilyHistory)ob;
        }

		public FamilyHistory GetObjectByKey(long k_PatientFamilyID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PatientFamilyID)) == false) {
				FamilyHistory ob = repository.GetQuery<FamilyHistory>().FirstOrDefault(o => o.PatientFamilyID == k_PatientFamilyID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            FamilyHistory obj = this[GetKey(k_PatientFamilyID)];
            return (FamilyHistory)obj;
        }

		public FamilyHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            FamilyHistory ob = this[keypair];
            return (FamilyHistory)ob;
        }

        public FamilyHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            FamilyHistory ob = this[GetKey(keypair)];
            return (FamilyHistory)ob;
        }

		bool _LoadAll = false;
        public List<FamilyHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<FamilyHistory>().ToList();
			foreach (FamilyHistory item in list) {
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

        ~KeyedFamilyHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
