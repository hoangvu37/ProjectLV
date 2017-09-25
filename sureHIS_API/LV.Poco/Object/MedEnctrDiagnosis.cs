



using System;

/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedEnctrDiagnosis.cs         
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
	public partial class MedEnctrDiagnosis : BaseEntity, ICloneable	{
		public MedEnctrDiagnosis()
		{
			this.MedEnctrDiagID = 0;
			this.MedEncnID = 0;
			this.ICDID = 0;
            this.V_DiagType = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedEnctrDiagID", MedEnctrDiagID); } }


		private long _MedEnctrDiagID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedEnctrDiagID { get { return _MedEnctrDiagID; } set {_MedEnctrDiagID = value; } }

		private long _MedEncnID;
		[LVRequired]
        public long MedEncnID { get { return _MedEncnID; } set {_MedEncnID = value; } }

		private long? _ICDID;
        public long? ICDID { get { return _ICDID; } set {_ICDID = value; } }

		private string _DiagDesc;
		[LVRequired]
        [LVMaxLength(128)]
        public string DiagDesc { get { return _DiagDesc; } set {_DiagDesc = value; } }

		private long? _V_DiagType;
        public long? V_DiagType { get { return _V_DiagType; } set {_V_DiagType = value; } }

		/// <summary>
/// Ref Key: FK_MedEnctrDiagnosis_IDC10
/// <summary>
/// <summary>
/// Ref Key: FK_MedEnctrDiagnosis_MedicalEncounter
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
    public class KeyedMedEnctrDiagnosis : KeyedCollection<KeyValuePair<string, long>, MedEnctrDiagnosis>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedEnctrDiagnosis() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedEnctrDiagnosis item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedEnctrDiagID) { return new KeyValuePair<string, long>("MedEnctrDiagID", k_MedEnctrDiagID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedEnctrDiagnosis item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedEnctrDiagnosis item)
        {
            MedEnctrDiagnosis orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedEnctrDiagnosis item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedEnctrDiagnosis item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedEnctrDiagnosis GetObjectByKey(long k_MedEnctrDiagID) 
		{
            if (this.Contains(GetKey(k_MedEnctrDiagID)) == false) return null;
            MedEnctrDiagnosis ob = this[GetKey(k_MedEnctrDiagID)];
            return (MedEnctrDiagnosis)ob;
        }

		public MedEnctrDiagnosis GetObjectByKey(long k_MedEnctrDiagID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedEnctrDiagID)) == false) {
				MedEnctrDiagnosis ob = repository.GetQuery<MedEnctrDiagnosis>().FirstOrDefault(o => o.MedEnctrDiagID == k_MedEnctrDiagID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedEnctrDiagnosis obj = this[GetKey(k_MedEnctrDiagID)];
            return (MedEnctrDiagnosis)obj;
        }

		public MedEnctrDiagnosis GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedEnctrDiagnosis ob = this[keypair];
            return (MedEnctrDiagnosis)ob;
        }

        public MedEnctrDiagnosis GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedEnctrDiagnosis ob = this[GetKey(keypair)];
            return (MedEnctrDiagnosis)ob;
        }

		bool _LoadAll = false;
        public List<MedEnctrDiagnosis> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedEnctrDiagnosis>().ToList();
			foreach (MedEnctrDiagnosis item in list) {
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

        ~KeyedMedEnctrDiagnosis()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
