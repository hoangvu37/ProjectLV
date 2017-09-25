/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientBed.cs         
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
	public partial class PatientBed : BaseEntity, ICloneable	{
		public PatientBed()
		{
			this.PtBedID = 0;
			this.V_PtBedType = 0;
			this.V_Material = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtBedID", PtBedID); } }


		private long _PtBedID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtBedID { get { return _PtBedID; } set {_PtBedID = value; } }

		private string _PtBedCode;
        [LVMaxLength(20)]
        public string PtBedCode { get { return _PtBedCode; } set {_PtBedCode = value; } }

		private long _V_PtBedType;
		[LVRequired]
        public long V_PtBedType { get { return _V_PtBedType; } set {_V_PtBedType = value; } }

		private long? _V_Material;
        public long? V_Material { get { return _V_Material; } set {_V_Material = value; } }

		private string _Notes;
        [LVMaxLength(1024)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_BedInRoom_PatientBed
/// <summary>
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
    public class KeyedPatientBed : KeyedCollection<KeyValuePair<string, long>, PatientBed>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientBed() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientBed item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtBedID) { return new KeyValuePair<string, long>("PtBedID", k_PtBedID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientBed item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientBed item)
        {
            PatientBed orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientBed item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientBed item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientBed GetObjectByKey(long k_PtBedID) 
		{
            if (this.Contains(GetKey(k_PtBedID)) == false) return null;
            PatientBed ob = this[GetKey(k_PtBedID)];
            return (PatientBed)ob;
        }

		public PatientBed GetObjectByKey(long k_PtBedID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtBedID)) == false) {
				PatientBed ob = repository.GetQuery<PatientBed>().FirstOrDefault(o => o.PtBedID == k_PtBedID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientBed obj = this[GetKey(k_PtBedID)];
            return (PatientBed)obj;
        }

		public PatientBed GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientBed ob = this[keypair];
            return (PatientBed)ob;
        }

        public PatientBed GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientBed ob = this[GetKey(keypair)];
            return (PatientBed)ob;
        }

		bool _LoadAll = false;
        public List<PatientBed> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientBed>().ToList();
			foreach (PatientBed item in list) {
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

        ~KeyedPatientBed()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
