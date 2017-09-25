/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedLabTest.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class MedLabTest : BaseEntity, ICloneable	{
		public MedLabTest()
		{
			this.ParClinExamGroupID = 0;
			this.MedLabTestID = 0;
            this.DXProcNmeasAnalInterpCode = null;
            this.ClinIndTypeID = null;
			this.DXProcNmeasAnalUnitCode = 0;
            this.MClinIndMaxValue = null;
            this.MClinIndMinValue = null;
            this.MClinIndLimitedValue = null;
            this.MClinIndValue = null;
            this.FClinIndMaxValue = null;
            this.FClinIndMinValue = null;
            this.FClinIndLimitedValue = null;
            this.FClinIndValue = null;
            this.PClinIndMaxValue = null;
            this.PClinIndMinValue = null;
            this.PClinIndLimitedValue = null;
            this.PClinIndValue = null;
            this.Notes = null;
            this.MNormalRange = null;
            this.FNormalRange = null;
            this.PNormalRange = null;
			this.V_AffectedFactor = 0;
            this.isQualitative = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedLabTestID", MedLabTestID); } }


		private long _ParClinExamGroupID;
		[LVRequired]
        public long ParClinExamGroupID { get { return _ParClinExamGroupID; } set {_ParClinExamGroupID = value; } }

		private long _MedLabTestID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedLabTestID { get { return _MedLabTestID; } set {_MedLabTestID = value; } }

		private string _MedLabTestCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string MedLabTestCode { get { return _MedLabTestCode; } set {_MedLabTestCode = value; } }

		private string _DXProcNmeasAnalCode;
        [LVMaxLength(10)]
        public string DXProcNmeasAnalCode { get { return _DXProcNmeasAnalCode; } set {_DXProcNmeasAnalCode = value; } }

		private string _MedLabTestName;
		[LVRequired]
        [LVMaxLength(128)]
        public string MedLabTestName { get { return _MedLabTestName; } set {_MedLabTestName = value; } }

		private string _DXProcNmeasAnalInterpCode;
        [LVMaxLength(1024)]
        public string DXProcNmeasAnalInterpCode { get { return _DXProcNmeasAnalInterpCode; } set {_DXProcNmeasAnalInterpCode = value; } }

		private long? _ClinIndTypeID;
        public long? ClinIndTypeID { get { return _ClinIndTypeID; } set {_ClinIndTypeID = value; } }

		private long? _DXProcNmeasAnalUnitCode;
        public long? DXProcNmeasAnalUnitCode { get { return _DXProcNmeasAnalUnitCode; } set {_DXProcNmeasAnalUnitCode = value; } }

		private double? _MClinIndMaxValue;
        public double? MClinIndMaxValue { get { return _MClinIndMaxValue; } set {_MClinIndMaxValue = value; } }

		private double? _MClinIndMinValue;
        public double? MClinIndMinValue { get { return _MClinIndMinValue; } set {_MClinIndMinValue = value; } }

		private double? _MClinIndLimitedValue;
        public double? MClinIndLimitedValue { get { return _MClinIndLimitedValue; } set {_MClinIndLimitedValue = value; } }

		private string _MClinIndValue;
        [LVMaxLength(20)]
        public string MClinIndValue { get { return _MClinIndValue; } set {_MClinIndValue = value; } }

		private double? _FClinIndMaxValue;
        public double? FClinIndMaxValue { get { return _FClinIndMaxValue; } set {_FClinIndMaxValue = value; } }

		private double? _FClinIndMinValue;
        public double? FClinIndMinValue { get { return _FClinIndMinValue; } set {_FClinIndMinValue = value; } }

		private double? _FClinIndLimitedValue;
        public double? FClinIndLimitedValue { get { return _FClinIndLimitedValue; } set {_FClinIndLimitedValue = value; } }

		private string _FClinIndValue;
        [LVMaxLength(20)]
        public string FClinIndValue { get { return _FClinIndValue; } set {_FClinIndValue = value; } }

		private double? _PClinIndMaxValue;
        public double? PClinIndMaxValue { get { return _PClinIndMaxValue; } set {_PClinIndMaxValue = value; } }

		private double? _PClinIndMinValue;
        public double? PClinIndMinValue { get { return _PClinIndMinValue; } set {_PClinIndMinValue = value; } }

		private double? _PClinIndLimitedValue;
        public double? PClinIndLimitedValue { get { return _PClinIndLimitedValue; } set {_PClinIndLimitedValue = value; } }

		private string _PClinIndValue;
        [LVMaxLength(20)]
        public string PClinIndValue { get { return _PClinIndValue; } set {_PClinIndValue = value; } }

		private string _Notes;
        [LVMaxLength(512)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private string _MNormalRange;
        [LVMaxLength(32)]
        public string MNormalRange { get { return _MNormalRange; } set {_MNormalRange = value; } }

		private string _FNormalRange;
        [LVMaxLength(32)]
        public string FNormalRange { get { return _FNormalRange; } set {_FNormalRange = value; } }

		private string _PNormalRange;
        [LVMaxLength(32)]
        public string PNormalRange { get { return _PNormalRange; } set {_PNormalRange = value; } }

		private string _UnisexRange;
        [LVMaxLength(32)]
        public string UnisexRange { get { return _UnisexRange; } set {_UnisexRange = value; } }

		private string _EffectedRange;
        [LVMaxLength(32)]
        public string EffectedRange { get { return _EffectedRange; } set {_EffectedRange = value; } }

		private long? _V_AffectedFactor;
        public long? V_AffectedFactor { get { return _V_AffectedFactor; } set {_V_AffectedFactor = value; } }

		private bool? _isQualitative;
        public bool? isQualitative { get { return _isQualitative; } set {_isQualitative = value; } }

		/// <summary>
/// Ref Key: FK_ParaClinicalExamType_ClinicalIndicatorType
/// <summary>
/// <summary>
/// Ref Key: FK_MedLabTestItems_MedLabTest
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalExamType_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalExamType_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRequestOnSpecimen_MedLabTest
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
    public class KeyedMedLabTest : KeyedCollection<KeyValuePair<string, long>, MedLabTest>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedLabTest() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedLabTest item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedLabTestID) { return new KeyValuePair<string, long>("MedLabTestID", k_MedLabTestID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedLabTest item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedLabTest item)
        {
            MedLabTest orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedLabTest item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedLabTest item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedLabTest GetObjectByKey(long k_MedLabTestID) 
		{
            if (this.Contains(GetKey(k_MedLabTestID)) == false) return null;
            MedLabTest ob = this[GetKey(k_MedLabTestID)];
            return (MedLabTest)ob;
        }

		public MedLabTest GetObjectByKey(long k_MedLabTestID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedLabTestID)) == false) {
				MedLabTest ob = repository.GetQuery<MedLabTest>().FirstOrDefault(o => o.MedLabTestID == k_MedLabTestID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedLabTest obj = this[GetKey(k_MedLabTestID)];
            return (MedLabTest)obj;
        }

		public MedLabTest GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedLabTest ob = this[keypair];
            return (MedLabTest)ob;
        }

        public MedLabTest GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedLabTest ob = this[GetKey(keypair)];
            return (MedLabTest)ob;
        }

		bool _LoadAll = false;
        public List<MedLabTest> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedLabTest>().ToList();
			foreach (MedLabTest item in list) {
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

        ~KeyedMedLabTest()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
