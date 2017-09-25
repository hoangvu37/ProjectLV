/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HealthInsurance.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class HealthInsurance : BaseEntity, ICloneable	{
		public HealthInsurance()
		{
			this.HICardID = 0;
			this.PtID = 0;
			this.RegistrationLocID = 0;
            this.IsOverFiveYears = true;
			this.HIAreaCode = 0;
			this.InsCoID = 0;
			this.IBID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HICardID", HICardID); } }


		private long _HICardID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HICardID { get { return _HICardID; } set {_HICardID = value; } }

		private long? _PtID;
        public long? PtID { get { return _PtID; } set {_PtID = value; } }

		private string _HICardNo;
		[LVRequired]
        [LVMaxLength(50)]
        public string HICardNo { get { return _HICardNo; } set {_HICardNo = value; } }

		private string _RegistrationLocation;
        [LVMaxLength(128)]
        public string RegistrationLocation { get { return _RegistrationLocation; } set {_RegistrationLocation = value; } }

		private string _ContactPerson;
        [LVMaxLength(100)]
        public string ContactPerson { get { return _ContactPerson; } set {_ContactPerson = value; } }

		private long _RegistrationLocID;
		[LVRequired]
        public long RegistrationLocID { get { return _RegistrationLocID; } set {_RegistrationLocID = value; } }

		private DateTime _ValidDateFrom;
		[LVRequired]
        public DateTime ValidDateFrom { get { return _ValidDateFrom; } set {_ValidDateFrom = value; } }

		private DateTime _ValidDateTo;
		[LVRequired]
        public DateTime ValidDateTo { get { return _ValidDateTo; } set {_ValidDateTo = value; } }

		private DateTime? _HIOverFiveYears;
        public DateTime? HIOverFiveYears { get { return _HIOverFiveYears; } set {_HIOverFiveYears = value; } }

		private bool? _IsOverFiveYears;
        public bool? IsOverFiveYears { get { return _IsOverFiveYears; } set {_IsOverFiveYears = value; } }

		private DateTime? _IssueDate;
        public DateTime? IssueDate { get { return _IssueDate; } set {_IssueDate = value; } }

		private int? _HIAreaCode;
        public int? HIAreaCode { get { return _HIAreaCode; } set {_HIAreaCode = value; } }

		private long? _InsCoID;
        public long? InsCoID { get { return _InsCoID; } set {_InsCoID = value; } }

		private int? _IBID;
        public int? IBID { get { return _IBID; } set {_IBID = value; } }

		/// <summary>
/// Ref Key: FK_HealthInsurance_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_HIAdmission_HealthInsurance
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
    public class KeyedHealthInsurance : KeyedCollection<KeyValuePair<string, long>, HealthInsurance>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHealthInsurance() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HealthInsurance item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HICardID) { return new KeyValuePair<string, long>("HICardID", k_HICardID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HealthInsurance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HealthInsurance item)
        {
            HealthInsurance orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HealthInsurance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HealthInsurance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HealthInsurance GetObjectByKey(long k_HICardID) 
		{
            if (this.Contains(GetKey(k_HICardID)) == false) return null;
            HealthInsurance ob = this[GetKey(k_HICardID)];
            return (HealthInsurance)ob;
        }

		public HealthInsurance GetObjectByKey(long k_HICardID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HICardID)) == false) {
				HealthInsurance ob = repository.GetQuery<HealthInsurance>().FirstOrDefault(o => o.HICardID == k_HICardID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HealthInsurance obj = this[GetKey(k_HICardID)];
            return (HealthInsurance)obj;
        }

		public HealthInsurance GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HealthInsurance ob = this[keypair];
            return (HealthInsurance)ob;
        }

        public HealthInsurance GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HealthInsurance ob = this[GetKey(keypair)];
            return (HealthInsurance)ob;
        }

		bool _LoadAll = false;
        public List<HealthInsurance> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HealthInsurance>().ToList();
			foreach (HealthInsurance item in list) {
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

        ~KeyedHealthInsurance()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
