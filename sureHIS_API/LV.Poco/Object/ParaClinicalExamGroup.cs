/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ParaClinicalExamGroup.cs         
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
	public partial class ParaClinicalExamGroup : BaseEntity, ICloneable	{
		public ParaClinicalExamGroup()
		{
			this.MedDiagMethodID = 0;
			this.PParClinExamGroupID = 0;
			this.ParClinExamGroupID = 0;
            this.ParClinExamPurpose = null;
            this.IsDiagnosticImaging = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ParClinExamGroupID", ParClinExamGroupID); } }


		private long _MedDiagMethodID;
		[LVRequired]
        public long MedDiagMethodID { get { return _MedDiagMethodID; } set {_MedDiagMethodID = value; } }

		private long? _PParClinExamGroupID;
        public long? PParClinExamGroupID { get { return _PParClinExamGroupID; } set {_PParClinExamGroupID = value; } }

		private long _ParClinExamGroupID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ParClinExamGroupID { get { return _ParClinExamGroupID; } set {_ParClinExamGroupID = value; } }

		private string _ParClinExamGroupName;
		[LVRequired]
        [LVMaxLength(128)]
        public string ParClinExamGroupName { get { return _ParClinExamGroupName; } set {_ParClinExamGroupName = value; } }

		private string _ParClinExamPurpose;
        [LVMaxLength(2147483647)]
        public string ParClinExamPurpose { get { return _ParClinExamPurpose; } set {_ParClinExamPurpose = value; } }

		private bool? _IsDiagnosticImaging;
        public bool? IsDiagnosticImaging { get { return _IsDiagnosticImaging; } set {_IsDiagnosticImaging = value; } }

		/// <summary>
/// Ref Key: FK_DiagDescribeTmp_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalExamGroup_MedicalDiagnosticMethod
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalTestProcedure_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingTest_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalExamType_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalExamGroup_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalExamGroup_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_SpecifiedParaclinical_ParaClinicalExamGroup
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
    public class KeyedParaClinicalExamGroup : KeyedCollection<KeyValuePair<string, long>, ParaClinicalExamGroup>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedParaClinicalExamGroup() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ParaClinicalExamGroup item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ParClinExamGroupID) { return new KeyValuePair<string, long>("ParClinExamGroupID", k_ParClinExamGroupID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ParaClinicalExamGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ParaClinicalExamGroup item)
        {
            ParaClinicalExamGroup orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ParaClinicalExamGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ParaClinicalExamGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ParaClinicalExamGroup GetObjectByKey(long k_ParClinExamGroupID) 
		{
            if (this.Contains(GetKey(k_ParClinExamGroupID)) == false) return null;
            ParaClinicalExamGroup ob = this[GetKey(k_ParClinExamGroupID)];
            return (ParaClinicalExamGroup)ob;
        }

		public ParaClinicalExamGroup GetObjectByKey(long k_ParClinExamGroupID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ParClinExamGroupID)) == false) {
				ParaClinicalExamGroup ob = repository.GetQuery<ParaClinicalExamGroup>().FirstOrDefault(o => o.ParClinExamGroupID == k_ParClinExamGroupID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ParaClinicalExamGroup obj = this[GetKey(k_ParClinExamGroupID)];
            return (ParaClinicalExamGroup)obj;
        }

		public ParaClinicalExamGroup GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ParaClinicalExamGroup ob = this[keypair];
            return (ParaClinicalExamGroup)ob;
        }

        public ParaClinicalExamGroup GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ParaClinicalExamGroup ob = this[GetKey(keypair)];
            return (ParaClinicalExamGroup)ob;
        }

		bool _LoadAll = false;
        public List<ParaClinicalExamGroup> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ParaClinicalExamGroup>().ToList();
			foreach (ParaClinicalExamGroup item in list) {
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

        ~KeyedParaClinicalExamGroup()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
