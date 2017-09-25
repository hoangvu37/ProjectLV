/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : TestOnPatientSpecimen.cs         
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
	public partial class TestOnPatientSpecimen : BaseEntity, ICloneable	{
		public TestOnPatientSpecimen()
		{
			this.PtSpecTestID = 0;
			this.ClinReqID = 0;
			this.PtSpecID = 0;
            this.EstEmpID = null;
            this.TestDtm = DateTime.Now;
            this.DiagPlace = null;
			this.V_pClinSceneCtg = 0;
            this.ClinicalDoctorID = null;
            this.Dignosis = null;
            this.isExportedPDF = true;
            this.PublishedDate = DateTime.Now;
            this.EquipMDSrcrID = null;
			this.PerfmEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtSpecTestID", PtSpecTestID); } }


		private long _PtSpecTestID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtSpecTestID { get { return _PtSpecTestID; } set {_PtSpecTestID = value; } }

		private long _ClinReqID;
		[LVRequired]
        public long ClinReqID { get { return _ClinReqID; } set {_ClinReqID = value; } }

		private long _PtSpecID;
		[LVRequired]
        public long PtSpecID { get { return _PtSpecID; } set {_PtSpecID = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private DateTime? _TestDtm;
        public DateTime? TestDtm { get { return _TestDtm; } set {_TestDtm = value; } }

		private string _DiagPlace;
        [LVMaxLength(64)]
        public string DiagPlace { get { return _DiagPlace; } set {_DiagPlace = value; } }

		private long? _V_pClinSceneCtg;
        public long? V_pClinSceneCtg { get { return _V_pClinSceneCtg; } set {_V_pClinSceneCtg = value; } }

		private long? _ClinicalDoctorID;
        public long? ClinicalDoctorID { get { return _ClinicalDoctorID; } set {_ClinicalDoctorID = value; } }

		private string _Dignosis;
        [LVMaxLength(1024)]
        public string Dignosis { get { return _Dignosis; } set {_Dignosis = value; } }

		private string _TxRec;
        [LVMaxLength(1024)]
        public string TxRec { get { return _TxRec; } set {_TxRec = value; } }

		private bool? _isExportedPDF;
        public bool? isExportedPDF { get { return _isExportedPDF; } set {_isExportedPDF = value; } }

		private DateTime? _PublishedDate;
        public DateTime? PublishedDate { get { return _PublishedDate; } set {_PublishedDate = value; } }

		private long? _EquipMDSrcrID;
        public long? EquipMDSrcrID { get { return _EquipMDSrcrID; } set {_EquipMDSrcrID = value; } }

		private long? _PerfmEmpID;
        public long? PerfmEmpID { get { return _PerfmEmpID; } set {_PerfmEmpID = value; } }

		/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_Employee_02
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_MedicalEquimentsResources
/// <summary>
/// <summary>
/// Ref Key: FK_MedLabRepository_TestOnPatientSpecimen
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_ParaClinicalReq
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRequestOnSpecimen_PatientSpecimenTest
/// <summary>
/// <summary>
/// Ref Key: FK_TestOnPatientSpecimen_PatientSpecimen
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
    public class KeyedTestOnPatientSpecimen : KeyedCollection<KeyValuePair<string, long>, TestOnPatientSpecimen>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedTestOnPatientSpecimen() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(TestOnPatientSpecimen item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtSpecTestID) { return new KeyValuePair<string, long>("PtSpecTestID", k_PtSpecTestID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(TestOnPatientSpecimen item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, TestOnPatientSpecimen item)
        {
            TestOnPatientSpecimen orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(TestOnPatientSpecimen item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(TestOnPatientSpecimen item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public TestOnPatientSpecimen GetObjectByKey(long k_PtSpecTestID) 
		{
            if (this.Contains(GetKey(k_PtSpecTestID)) == false) return null;
            TestOnPatientSpecimen ob = this[GetKey(k_PtSpecTestID)];
            return (TestOnPatientSpecimen)ob;
        }

		public TestOnPatientSpecimen GetObjectByKey(long k_PtSpecTestID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtSpecTestID)) == false) {
				TestOnPatientSpecimen ob = repository.GetQuery<TestOnPatientSpecimen>().FirstOrDefault(o => o.PtSpecTestID == k_PtSpecTestID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            TestOnPatientSpecimen obj = this[GetKey(k_PtSpecTestID)];
            return (TestOnPatientSpecimen)obj;
        }

		public TestOnPatientSpecimen GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            TestOnPatientSpecimen ob = this[keypair];
            return (TestOnPatientSpecimen)ob;
        }

        public TestOnPatientSpecimen GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            TestOnPatientSpecimen ob = this[GetKey(keypair)];
            return (TestOnPatientSpecimen)ob;
        }

		bool _LoadAll = false;
        public List<TestOnPatientSpecimen> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<TestOnPatientSpecimen>().ToList();
			foreach (TestOnPatientSpecimen item in list) {
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

        ~KeyedTestOnPatientSpecimen()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
