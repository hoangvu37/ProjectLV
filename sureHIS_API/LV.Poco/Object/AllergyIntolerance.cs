/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AllergyIntolerance.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class AllergyIntolerance : BaseEntity, ICloneable	{
		public AllergyIntolerance()
		{
			this.AllergyID = 0;
			this.PtComMedRecID = 0;
			this.AllgIndexID = 0;
            this.AllergyText = null;
            this.H7AllgSeverity = null;
            this.H7AllgStatus = null;
            this.AllgReactionText = null;
            this.AllgOnsetDtm = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
            this.EstEmpID = null;
            this.IsDel = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AllergyID", AllergyID); } }


		private long _AllergyID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AllergyID { get { return _AllergyID; } set {_AllergyID = value; } }

		private long _PtComMedRecID;
		[LVRequired]
        public long PtComMedRecID { get { return _PtComMedRecID; } set {_PtComMedRecID = value; } }

		private long _AllgIndexID;
		[LVRequired]
        public long AllgIndexID { get { return _AllgIndexID; } set {_AllgIndexID = value; } }

		private string _AllergyText;
        [LVMaxLength(254)]
        public string AllergyText { get { return _AllergyText; } set {_AllergyText = value; } }

		private long? _H7AllgSeverity;
        public long? H7AllgSeverity { get { return _H7AllgSeverity; } set {_H7AllgSeverity = value; } }

		private long? _H7AllgStatus;
        public long? H7AllgStatus { get { return _H7AllgStatus; } set {_H7AllgStatus = value; } }

		private string _AllgReactionText;
        [LVMaxLength(254)]
        public string AllgReactionText { get { return _AllgReactionText; } set {_AllgReactionText = value; } }

		private DateTime? _AllgOnsetDtm;
        public DateTime? AllgOnsetDtm { get { return _AllgOnsetDtm; } set {_AllgOnsetDtm = value; } }

		private DateTime _ModifiedDate;
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private bool? _IsDel;
        public bool? IsDel { get { return _IsDel; } set {_IsDel = value; } }

		/// <summary>
/// Ref Key: FK_Allergy_PatientCommonMedRecord
/// <summary>
/// <summary>
/// Ref Key: FK_AllergyIntolerance_refAllergyIndex
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
    public class KeyedAllergyIntolerance : KeyedCollection<KeyValuePair<string, long>, AllergyIntolerance>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAllergyIntolerance() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AllergyIntolerance item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AllergyID) { return new KeyValuePair<string, long>("AllergyID", k_AllergyID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AllergyIntolerance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AllergyIntolerance item)
        {
            AllergyIntolerance orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AllergyIntolerance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AllergyIntolerance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AllergyIntolerance GetObjectByKey(long k_AllergyID) 
		{
            if (this.Contains(GetKey(k_AllergyID)) == false) return null;
            AllergyIntolerance ob = this[GetKey(k_AllergyID)];
            return (AllergyIntolerance)ob;
        }

		public AllergyIntolerance GetObjectByKey(long k_AllergyID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AllergyID)) == false) {
				AllergyIntolerance ob = repository.GetQuery<AllergyIntolerance>().FirstOrDefault(o => o.AllergyID == k_AllergyID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AllergyIntolerance obj = this[GetKey(k_AllergyID)];
            return (AllergyIntolerance)obj;
        }

		public AllergyIntolerance GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AllergyIntolerance ob = this[keypair];
            return (AllergyIntolerance)ob;
        }

        public AllergyIntolerance GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AllergyIntolerance ob = this[GetKey(keypair)];
            return (AllergyIntolerance)ob;
        }

		bool _LoadAll = false;
        public List<AllergyIntolerance> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AllergyIntolerance>().ToList();
			foreach (AllergyIntolerance item in list) {
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

        ~KeyedAllergyIntolerance()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
