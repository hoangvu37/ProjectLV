/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientClassification.cs         
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
	public partial class PatientClassification : BaseEntity, ICloneable	{
		public PatientClassification()
		{
			this.PtClassID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtClassID", PtClassID); } }


		private long _PtClassID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtClassID { get { return _PtClassID; } set {_PtClassID = value; } }

		private string _PtClassCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string PtClassCode { get { return _PtClassCode; } set {_PtClassCode = value; } }

		private string _PtClassName;
		[LVRequired]
        [LVMaxLength(125)]
        public string PtClassName { get { return _PtClassName; } set {_PtClassName = value; } }

		private string _PCNotes;
        [LVMaxLength(1024)]
        public string PCNotes { get { return _PCNotes; } set {_PCNotes = value; } }

		/// <summary>
/// Ref Key: FK_PatientAdmission_PatientClassification
/// <summary>
/// <summary>
/// Ref Key: FK_PtCHis_PtClassification
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
    public class KeyedPatientClassification : KeyedCollection<KeyValuePair<string, long>, PatientClassification>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientClassification() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientClassification item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtClassID) { return new KeyValuePair<string, long>("PtClassID", k_PtClassID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientClassification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientClassification item)
        {
            PatientClassification orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientClassification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientClassification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientClassification GetObjectByKey(long k_PtClassID) 
		{
            if (this.Contains(GetKey(k_PtClassID)) == false) return null;
            PatientClassification ob = this[GetKey(k_PtClassID)];
            return (PatientClassification)ob;
        }

		public PatientClassification GetObjectByKey(long k_PtClassID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtClassID)) == false) {
				PatientClassification ob = repository.GetQuery<PatientClassification>().FirstOrDefault(o => o.PtClassID == k_PtClassID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientClassification obj = this[GetKey(k_PtClassID)];
            return (PatientClassification)obj;
        }

		public PatientClassification GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientClassification ob = this[keypair];
            return (PatientClassification)ob;
        }

        public PatientClassification GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientClassification ob = this[GetKey(keypair)];
            return (PatientClassification)ob;
        }

		bool _LoadAll = false;
        public List<PatientClassification> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientClassification>().ToList();
			foreach (PatientClassification item in list) {
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

        ~KeyedPatientClassification()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
