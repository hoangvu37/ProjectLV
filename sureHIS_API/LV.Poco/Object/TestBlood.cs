/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : TestBlood.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class TestBlood : BaseEntity, ICloneable	{
		public TestBlood()
		{
			this.TestBloodID = 0;
			this.EstEmpID = 0;
			this.V_TestResults = 0;
            this.Notes = null;
			this.BloodBankID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("TestBloodID", TestBloodID); } }


		private long _TestBloodID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long TestBloodID { get { return _TestBloodID; } set {_TestBloodID = value; } }

		private DateTime _TestDate;
		[LVRequired]
        public DateTime TestDate { get { return _TestDate; } set {_TestDate = value; } }

		private long _EstEmpID;
		[LVRequired]
        public long EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		private long _V_TestResults;
		[LVRequired]
        public long V_TestResults { get { return _V_TestResults; } set {_V_TestResults = value; } }

		private string _Notes;
        [LVMaxLength(128)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private long? _BloodBankID;
        public long? BloodBankID { get { return _BloodBankID; } set {_BloodBankID = value; } }

		/// <summary>
/// Ref Key: FK_TestBlood_Bloodbank
/// <summary>
/// <summary>
/// Ref Key: FK_TestBlood_Employee
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
    public class KeyedTestBlood : KeyedCollection<KeyValuePair<string, long>, TestBlood>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedTestBlood() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(TestBlood item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_TestBloodID) { return new KeyValuePair<string, long>("TestBloodID", k_TestBloodID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(TestBlood item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, TestBlood item)
        {
            TestBlood orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(TestBlood item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(TestBlood item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public TestBlood GetObjectByKey(long k_TestBloodID) 
		{
            if (this.Contains(GetKey(k_TestBloodID)) == false) return null;
            TestBlood ob = this[GetKey(k_TestBloodID)];
            return (TestBlood)ob;
        }

		public TestBlood GetObjectByKey(long k_TestBloodID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_TestBloodID)) == false) {
				TestBlood ob = repository.GetQuery<TestBlood>().FirstOrDefault(o => o.TestBloodID == k_TestBloodID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            TestBlood obj = this[GetKey(k_TestBloodID)];
            return (TestBlood)obj;
        }

		public TestBlood GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            TestBlood ob = this[keypair];
            return (TestBlood)ob;
        }

        public TestBlood GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            TestBlood ob = this[GetKey(keypair)];
            return (TestBlood)ob;
        }

		bool _LoadAll = false;
        public List<TestBlood> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<TestBlood>().ToList();
			foreach (TestBlood item in list) {
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

        ~KeyedTestBlood()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
