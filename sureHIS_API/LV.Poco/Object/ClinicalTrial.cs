/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ClinicalTrial.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class ClinicalTrial : BaseEntity, ICloneable	{
		public ClinicalTrial()
		{
			this.V_ClinTrialCategory = 0;
			this.ClintID = 0;
            this.ClintDesc = null;
			this.HosDeptID = 0;
            this.ClintNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ClintID", ClintID); } }


		private long _V_ClinTrialCategory;
		[LVRequired]
        public long V_ClinTrialCategory { get { return _V_ClinTrialCategory; } set {_V_ClinTrialCategory = value; } }

		private long _ClintID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ClintID { get { return _ClintID; } set {_ClintID = value; } }

		private string _ClintTile;
		[LVRequired]
        [LVMaxLength(128)]
        public string ClintTile { get { return _ClintTile; } set {_ClintTile = value; } }

		private string _ClintDesc;
        [LVMaxLength(2147483647)]
        public string ClintDesc { get { return _ClintDesc; } set {_ClintDesc = value; } }

		private DateTime _ClintDateFrom;
		[LVRequired]
        public DateTime ClintDateFrom { get { return _ClintDateFrom; } set {_ClintDateFrom = value; } }

		private DateTime _ClintDateTo;
		[LVRequired]
        public DateTime ClintDateTo { get { return _ClintDateTo; } set {_ClintDateTo = value; } }

		private long? _HosDeptID;
        public long? HosDeptID { get { return _HosDeptID; } set {_HosDeptID = value; } }

		private string _ClintNotes;
        [LVMaxLength(2048)]
        public string ClintNotes { get { return _ClintNotes; } set {_ClintNotes = value; } }

		/// <summary>
/// Ref Key: FK_ClinicalTrial_HospitalSpecialist
/// <summary>
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
    public class KeyedClinicalTrial : KeyedCollection<KeyValuePair<string, long>, ClinicalTrial>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedClinicalTrial() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ClinicalTrial item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ClintID) { return new KeyValuePair<string, long>("ClintID", k_ClintID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ClinicalTrial item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ClinicalTrial item)
        {
            ClinicalTrial orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ClinicalTrial item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ClinicalTrial item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ClinicalTrial GetObjectByKey(long k_ClintID) 
		{
            if (this.Contains(GetKey(k_ClintID)) == false) return null;
            ClinicalTrial ob = this[GetKey(k_ClintID)];
            return (ClinicalTrial)ob;
        }

		public ClinicalTrial GetObjectByKey(long k_ClintID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ClintID)) == false) {
				ClinicalTrial ob = repository.GetQuery<ClinicalTrial>().FirstOrDefault(o => o.ClintID == k_ClintID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ClinicalTrial obj = this[GetKey(k_ClintID)];
            return (ClinicalTrial)obj;
        }

		public ClinicalTrial GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ClinicalTrial ob = this[keypair];
            return (ClinicalTrial)ob;
        }

        public ClinicalTrial GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ClinicalTrial ob = this[GetKey(keypair)];
            return (ClinicalTrial)ob;
        }

		bool _LoadAll = false;
        public List<ClinicalTrial> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ClinicalTrial>().ToList();
			foreach (ClinicalTrial item in list) {
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

        ~KeyedClinicalTrial()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
