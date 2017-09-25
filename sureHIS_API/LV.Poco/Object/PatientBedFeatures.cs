/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientBedFeatures.cs         
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
	public partial class PatientBedFeatures : BaseEntity, ICloneable	{
		public PatientBedFeatures()
		{
			this.PtBedID = 0;
			this.PtBedFeatureID = 0;
			this.V_PatientBedFeature = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtBedFeatureID", PtBedFeatureID); } }


		private long _PtBedID;
		[LVRequired]
        public long PtBedID { get { return _PtBedID; } set {_PtBedID = value; } }

		private long _PtBedFeatureID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtBedFeatureID { get { return _PtBedFeatureID; } set {_PtBedFeatureID = value; } }

		private long _V_PatientBedFeature;
		[LVRequired]
        public long V_PatientBedFeature { get { return _V_PatientBedFeature; } set {_V_PatientBedFeature = value; } }

		private string _Notes;
        [LVMaxLength(256)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_PtBedFeatures_PtBed
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
    public class KeyedPatientBedFeatures : KeyedCollection<KeyValuePair<string, long>, PatientBedFeatures>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientBedFeatures() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientBedFeatures item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtBedFeatureID) { return new KeyValuePair<string, long>("PtBedFeatureID", k_PtBedFeatureID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientBedFeatures item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientBedFeatures item)
        {
            PatientBedFeatures orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientBedFeatures item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientBedFeatures item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientBedFeatures GetObjectByKey(long k_PtBedFeatureID) 
		{
            if (this.Contains(GetKey(k_PtBedFeatureID)) == false) return null;
            PatientBedFeatures ob = this[GetKey(k_PtBedFeatureID)];
            return (PatientBedFeatures)ob;
        }

		public PatientBedFeatures GetObjectByKey(long k_PtBedFeatureID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtBedFeatureID)) == false) {
				PatientBedFeatures ob = repository.GetQuery<PatientBedFeatures>().FirstOrDefault(o => o.PtBedFeatureID == k_PtBedFeatureID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientBedFeatures obj = this[GetKey(k_PtBedFeatureID)];
            return (PatientBedFeatures)obj;
        }

		public PatientBedFeatures GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientBedFeatures ob = this[keypair];
            return (PatientBedFeatures)ob;
        }

        public PatientBedFeatures GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientBedFeatures ob = this[GetKey(keypair)];
            return (PatientBedFeatures)ob;
        }

		bool _LoadAll = false;
        public List<PatientBedFeatures> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientBedFeatures>().ToList();
			foreach (PatientBedFeatures item in list) {
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

        ~KeyedPatientBedFeatures()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
