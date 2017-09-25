/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedImagingTest.cs         
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
	public partial class MedImagingTest : BaseEntity, ICloneable	{
		public MedImagingTest()
		{
			this.ParClinExamGroupID = 0;
			this.MedImgTestID = 0;
            this.MedImgTestDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedImgTestID", MedImgTestID); } }


		private long _ParClinExamGroupID;
		[LVRequired]
        public long ParClinExamGroupID { get { return _ParClinExamGroupID; } set {_ParClinExamGroupID = value; } }

		private long _MedImgTestID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedImgTestID { get { return _MedImgTestID; } set {_MedImgTestID = value; } }

		private string _MedImgTestCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string MedImgTestCode { get { return _MedImgTestCode; } set {_MedImgTestCode = value; } }

		private string _MedImgTestName;
		[LVRequired]
        [LVMaxLength(128)]
        public string MedImgTestName { get { return _MedImgTestName; } set {_MedImgTestName = value; } }

		private string _MedImgTestDesc;
        [LVMaxLength(2048)]
        public string MedImgTestDesc { get { return _MedImgTestDesc; } set {_MedImgTestDesc = value; } }

		/// <summary>
/// Ref Key: FK_MedImagingTest_ParaClinicalExamGroup
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingTestItem_MedImagingTest
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRadiology_MedImagingTest
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
    public class KeyedMedImagingTest : KeyedCollection<KeyValuePair<string, long>, MedImagingTest>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedImagingTest() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedImagingTest item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedImgTestID) { return new KeyValuePair<string, long>("MedImgTestID", k_MedImgTestID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedImagingTest item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedImagingTest item)
        {
            MedImagingTest orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedImagingTest item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedImagingTest item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedImagingTest GetObjectByKey(long k_MedImgTestID) 
		{
            if (this.Contains(GetKey(k_MedImgTestID)) == false) return null;
            MedImagingTest ob = this[GetKey(k_MedImgTestID)];
            return (MedImagingTest)ob;
        }

		public MedImagingTest GetObjectByKey(long k_MedImgTestID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedImgTestID)) == false) {
				MedImagingTest ob = repository.GetQuery<MedImagingTest>().FirstOrDefault(o => o.MedImgTestID == k_MedImgTestID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedImagingTest obj = this[GetKey(k_MedImgTestID)];
            return (MedImagingTest)obj;
        }

		public MedImagingTest GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedImagingTest ob = this[keypair];
            return (MedImagingTest)ob;
        }

        public MedImagingTest GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedImagingTest ob = this[GetKey(keypair)];
            return (MedImagingTest)ob;
        }

		bool _LoadAll = false;
        public List<MedImagingTest> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedImagingTest>().ToList();
			foreach (MedImagingTest item in list) {
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

        ~KeyedMedImagingTest()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
