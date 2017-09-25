/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalTestProcedure.cs         
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
	public partial class MedicalTestProcedure : BaseEntity, ICloneable	{
		public MedicalTestProcedure()
		{
			this.MedTestProcID = 0;
            this.MedTestProcDesc = null;
            this.SpecTypeID = null;
            this.ResultType = null;
            this.TimeReturnsResult = 1;
            this.AppliedDate = DateTime.Now;
			this.EstEmpID = 0;
            this.NoEffect = false;
            this.isPackage = true;
			this.ParClinExamGroupID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedTestProcID", MedTestProcID); } }


		private long _MedTestProcID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedTestProcID { get { return _MedTestProcID; } set {_MedTestProcID = value; } }

		private string _MedTestProcCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string MedTestProcCode { get { return _MedTestProcCode; } set {_MedTestProcCode = value; } }

		private string _MedTestProcName;
		[LVRequired]
        [LVMaxLength(128)]
        public string MedTestProcName { get { return _MedTestProcName; } set {_MedTestProcName = value; } }

		private string _MedTestProcDesc;
        [LVMaxLength(1024)]
        public string MedTestProcDesc { get { return _MedTestProcDesc; } set {_MedTestProcDesc = value; } }

		private long? _SpecTypeID;
        public long? SpecTypeID { get { return _SpecTypeID; } set {_SpecTypeID = value; } }

		private string _ResultType;
        [LVMaxLength(128)]
        public string ResultType { get { return _ResultType; } set {_ResultType = value; } }

		private byte? _TimeReturnsResult;
        public byte? TimeReturnsResult { get { return _TimeReturnsResult; } set {_TimeReturnsResult = value; } }

		private DateTime? _AppliedDate;
        public DateTime? AppliedDate { get { return _AppliedDate; } set {_AppliedDate = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private DateTime? _ModifiedDtm;
        public DateTime? ModifiedDtm { get { return _ModifiedDtm; } set {_ModifiedDtm = value; } }

		private bool _NoEffect;
        public bool NoEffect { get { return _NoEffect; } set {_NoEffect = value; } }

		private bool? _isPackage;
        public bool? isPackage { get { return _isPackage; } set {_isPackage = value; } }

		private byte? _Idx;
        public byte? Idx { get { return _Idx; } set {_Idx = value; } }

		private long? _ParClinExamGroupID;
        public long? ParClinExamGroupID { get { return _ParClinExamGroupID; } set {_ParClinExamGroupID = value; } }

		/// <summary>
/// Ref Key: FK_MedicalTest_refSpecimenType
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalTestProcedure_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingTestItems_MedicalTestProcedure
/// <summary>
/// <summary>
/// Ref Key: FK_MedLabTestItems_MedicalTestProcedure
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReq_MedicalTestProcedure
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
    public class KeyedMedicalTestProcedure : KeyedCollection<KeyValuePair<string, long>, MedicalTestProcedure>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalTestProcedure() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalTestProcedure item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedTestProcID) { return new KeyValuePair<string, long>("MedTestProcID", k_MedTestProcID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalTestProcedure item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalTestProcedure item)
        {
            MedicalTestProcedure orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalTestProcedure item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalTestProcedure item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalTestProcedure GetObjectByKey(long k_MedTestProcID) 
		{
            if (this.Contains(GetKey(k_MedTestProcID)) == false) return null;
            MedicalTestProcedure ob = this[GetKey(k_MedTestProcID)];
            return (MedicalTestProcedure)ob;
        }

		public MedicalTestProcedure GetObjectByKey(long k_MedTestProcID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedTestProcID)) == false) {
				MedicalTestProcedure ob = repository.GetQuery<MedicalTestProcedure>().FirstOrDefault(o => o.MedTestProcID == k_MedTestProcID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalTestProcedure obj = this[GetKey(k_MedTestProcID)];
            return (MedicalTestProcedure)obj;
        }

		public MedicalTestProcedure GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalTestProcedure ob = this[keypair];
            return (MedicalTestProcedure)ob;
        }

        public MedicalTestProcedure GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalTestProcedure ob = this[GetKey(keypair)];
            return (MedicalTestProcedure)ob;
        }

		bool _LoadAll = false;
        public List<MedicalTestProcedure> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalTestProcedure>().ToList();
			foreach (MedicalTestProcedure item in list) {
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

        ~KeyedMedicalTestProcedure()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
