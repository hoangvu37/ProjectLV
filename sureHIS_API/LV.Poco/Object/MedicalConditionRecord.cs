/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalConditionRecord.cs         
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
	public partial class MedicalConditionRecord : BaseEntity, ICloneable	{
		public MedicalConditionRecord()
		{
			this.MCRecID = 0;
			this.MCID = 0;
			this.PtComMedRecID = 0;
            this.MCYesNo = false;
            this.MCTextValue = null;
            this.MCExplainOrNotes = null;
            this.IsDel = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MCRecID", MCRecID); } }


		private long _MCRecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MCRecID { get { return _MCRecID; } set {_MCRecID = value; } }

		private long _MCID;
		[LVRequired]
        public long MCID { get { return _MCID; } set {_MCID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private bool _MCYesNo;
        public bool MCYesNo { get { return _MCYesNo; } set {_MCYesNo = value; } }

		private string _MCTextValue;
        [LVMaxLength(125)]
        public string MCTextValue { get { return _MCTextValue; } set {_MCTextValue = value; } }

		private string _MCExplainOrNotes;
        [LVMaxLength(255)]
        public string MCExplainOrNotes { get { return _MCExplainOrNotes; } set {_MCExplainOrNotes = value; } }

		private bool? _IsDel;
        public bool? IsDel { get { return _IsDel; } set {_IsDel = value; } }

		/// <summary>
/// Ref Key: FK_MedicalConditionRecord_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalConditionRecord_refMedicalCondition
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
    public class KeyedMedicalConditionRecord : KeyedCollection<KeyValuePair<string, long>, MedicalConditionRecord>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalConditionRecord() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalConditionRecord item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MCRecID) { return new KeyValuePair<string, long>("MCRecID", k_MCRecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalConditionRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalConditionRecord item)
        {
            MedicalConditionRecord orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalConditionRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalConditionRecord item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalConditionRecord GetObjectByKey(long k_MCRecID) 
		{
            if (this.Contains(GetKey(k_MCRecID)) == false) return null;
            MedicalConditionRecord ob = this[GetKey(k_MCRecID)];
            return (MedicalConditionRecord)ob;
        }

		public MedicalConditionRecord GetObjectByKey(long k_MCRecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MCRecID)) == false) {
				MedicalConditionRecord ob = repository.GetQuery<MedicalConditionRecord>().FirstOrDefault(o => o.MCRecID == k_MCRecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalConditionRecord obj = this[GetKey(k_MCRecID)];
            return (MedicalConditionRecord)obj;
        }

		public MedicalConditionRecord GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalConditionRecord ob = this[keypair];
            return (MedicalConditionRecord)ob;
        }

        public MedicalConditionRecord GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalConditionRecord ob = this[GetKey(keypair)];
            return (MedicalConditionRecord)ob;
        }

		bool _LoadAll = false;
        public List<MedicalConditionRecord> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalConditionRecord>().ToList();
			foreach (MedicalConditionRecord item in list) {
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

        ~KeyedMedicalConditionRecord()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
