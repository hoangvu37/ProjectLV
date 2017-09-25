/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ICD10.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class ICD10 : BaseEntity, ICloneable	{
		public ICD10()
		{
			this.GroupID = 0;
			this.PICDID = 0;
			this.ICDID = 0;
            this.DiseaseNameVNs = null;
            this.MOHICDCode = null;
            this.MOHICDCodeAdd = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ICDID", ICDID); } }


		private long _GroupID;
		[LVRequired]
        public long GroupID { get { return _GroupID; } set {_GroupID = value; } }

		private long? _PICDID;
        public long? PICDID { get { return _PICDID; } set {_PICDID = value; } }

		private long _ICDID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ICDID { get { return _ICDID; } set {_ICDID = value; } }

		private string _ICDCode;
		[LVRequired]
        [LVMaxLength(8)]
        public string ICDCode { get { return _ICDCode; } set {_ICDCode = value; } }

		private string _DiseaseName;
		[LVRequired]
        [LVMaxLength(512)]
        public string DiseaseName { get { return _DiseaseName; } set {_DiseaseName = value; } }

		private string _DiseaseNameVNese;
		[LVRequired]
        [LVMaxLength(1024)]
        public string DiseaseNameVNese { get { return _DiseaseNameVNese; } set {_DiseaseNameVNese = value; } }

		private string _DiseaseNameVNs;
        [LVMaxLength(1024)]
        public string DiseaseNameVNs { get { return _DiseaseNameVNs; } set {_DiseaseNameVNs = value; } }

		private string _MOHICDCode;
        [LVMaxLength(7)]
        public string MOHICDCode { get { return _MOHICDCode; } set {_MOHICDCode = value; } }

		private string _MOHICDCodeAdd;
        [LVMaxLength(7)]
        public string MOHICDCodeAdd { get { return _MOHICDCodeAdd; } set {_MOHICDCodeAdd = value; } }

		/// <summary>
/// Ref Key: FK_DrPrescriptionTmp_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_ICD10_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_ICD10_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_ICD10_ICDGroup
/// <summary>
/// <summary>
/// Ref Key: FK_MedEnctrDiagnosis_IDC10
/// <summary>
/// <summary>
/// Ref Key: FK_Prescription_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_SpecifiedParaclinical_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_SymptomIndicator_IDC10
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
    public class KeyedICD10 : KeyedCollection<KeyValuePair<string, long>, ICD10>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedICD10() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ICD10 item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ICDID) { return new KeyValuePair<string, long>("ICDID", k_ICDID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ICD10 item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ICD10 item)
        {
            ICD10 orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ICD10 item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ICD10 item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ICD10 GetObjectByKey(long k_ICDID) 
		{
            if (this.Contains(GetKey(k_ICDID)) == false) return null;
            ICD10 ob = this[GetKey(k_ICDID)];
            return (ICD10)ob;
        }

		public ICD10 GetObjectByKey(long k_ICDID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ICDID)) == false) {
				ICD10 ob = repository.GetQuery<ICD10>().FirstOrDefault(o => o.ICDID == k_ICDID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ICD10 obj = this[GetKey(k_ICDID)];
            return (ICD10)obj;
        }

		public ICD10 GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ICD10 ob = this[keypair];
            return (ICD10)ob;
        }

        public ICD10 GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ICD10 ob = this[GetKey(keypair)];
            return (ICD10)ob;
        }

		bool _LoadAll = false;
        public List<ICD10> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ICD10>().ToList();
			foreach (ICD10 item in list) {
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

        ~KeyedICD10()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
