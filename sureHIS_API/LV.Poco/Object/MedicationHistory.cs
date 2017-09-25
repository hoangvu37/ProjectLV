/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicationHistory.cs         
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
	public partial class MedicationHistory : BaseEntity, ICloneable	{
		public MedicationHistory()
		{
			this.MedHisID = 0;
			this.PtComMedRecID = 0;
			this.V_MedHisType = 0;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedHisID", MedHisID); } }


		private long _MedHisID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedHisID { get { return _MedHisID; } set {_MedHisID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long _V_MedHisType;
		[LVRequired]
        public long V_MedHisType { get { return _V_MedHisType; } set {_V_MedHisType = value; } }

		private string _HHistMedcnIDText;
		[LVRequired]
        [LVMaxLength(254)]
        public string HHistMedcnIDText { get { return _HHistMedcnIDText; } set {_HHistMedcnIDText = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		/// <summary>
/// Ref Key: FK_MedicationHistory_PatientCommonMedRecord
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
    public class KeyedMedicationHistory : KeyedCollection<KeyValuePair<string, long>, MedicationHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicationHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicationHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedHisID) { return new KeyValuePair<string, long>("MedHisID", k_MedHisID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicationHistory item)
        {
            MedicationHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicationHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicationHistory GetObjectByKey(long k_MedHisID) 
		{
            if (this.Contains(GetKey(k_MedHisID)) == false) return null;
            MedicationHistory ob = this[GetKey(k_MedHisID)];
            return (MedicationHistory)ob;
        }

		public MedicationHistory GetObjectByKey(long k_MedHisID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedHisID)) == false) {
				MedicationHistory ob = repository.GetQuery<MedicationHistory>().FirstOrDefault(o => o.MedHisID == k_MedHisID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicationHistory obj = this[GetKey(k_MedHisID)];
            return (MedicationHistory)obj;
        }

		public MedicationHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicationHistory ob = this[keypair];
            return (MedicationHistory)ob;
        }

        public MedicationHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicationHistory ob = this[GetKey(keypair)];
            return (MedicationHistory)ob;
        }

		bool _LoadAll = false;
        public List<MedicationHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicationHistory>().ToList();
			foreach (MedicationHistory item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<MedicationHistory> LoadIXFK_MedicationHistory_PatientCommonMedRecord(long p_PtComMedRecID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<MedicationHistory>().Where(o=> o.PtComMedRecID == p_PtComMedRecID).ToList();
			foreach (MedicationHistory item in list) {
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

        ~KeyedMedicationHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
