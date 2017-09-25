/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : SocialAndHealthInsurance.cs         
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
	public partial class SocialAndHealthInsurance : BaseEntity, ICloneable	{
		public SocialAndHealthInsurance()
		{
			this.SHInsEmpID = 0;
            this.SocialInsNo = null;
            this.SocialInsIssuedDate = DateTime.Now;
            this.SocialInsIssuedPlace = null;
            this.HealthInsNo = null;
            this.HealthInsIssedDate = DateTime.Now;
            this.HealthInsIssuedPlace = null;
			this.EmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SHInsEmpID", SHInsEmpID); } }


		private long _SHInsEmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SHInsEmpID { get { return _SHInsEmpID; } set {_SHInsEmpID = value; } }

		private string _SocialInsNo;
		[LVRequired]
        [LVMaxLength(20)]
        public string SocialInsNo { get { return _SocialInsNo; } set {_SocialInsNo = value; } }

		private DateTime? _SocialInsIssuedDate;
        public DateTime? SocialInsIssuedDate { get { return _SocialInsIssuedDate; } set {_SocialInsIssuedDate = value; } }

		private string _SocialInsIssuedPlace;
        [LVMaxLength(80)]
        public string SocialInsIssuedPlace { get { return _SocialInsIssuedPlace; } set {_SocialInsIssuedPlace = value; } }

		private string _HealthInsNo;
        [LVMaxLength(20)]
        public string HealthInsNo { get { return _HealthInsNo; } set {_HealthInsNo = value; } }

		private DateTime? _HealthInsIssedDate;
        public DateTime? HealthInsIssedDate { get { return _HealthInsIssedDate; } set {_HealthInsIssedDate = value; } }

		private string _HealthInsIssuedPlace;
        public string HealthInsIssuedPlace { get { return _HealthInsIssuedPlace; } set {_HealthInsIssuedPlace = value; } }

		private long? _EmpID;
        public long? EmpID { get { return _EmpID; } set {_EmpID = value; } }

		/// <summary>
/// Ref Key: FK_SocialAndHealthInsurance_Employee
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
    public class KeyedSocialAndHealthInsurance : KeyedCollection<KeyValuePair<string, long>, SocialAndHealthInsurance>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedSocialAndHealthInsurance() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(SocialAndHealthInsurance item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SHInsEmpID) { return new KeyValuePair<string, long>("SHInsEmpID", k_SHInsEmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(SocialAndHealthInsurance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, SocialAndHealthInsurance item)
        {
            SocialAndHealthInsurance orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(SocialAndHealthInsurance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(SocialAndHealthInsurance item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public SocialAndHealthInsurance GetObjectByKey(long k_SHInsEmpID) 
		{
            if (this.Contains(GetKey(k_SHInsEmpID)) == false) return null;
            SocialAndHealthInsurance ob = this[GetKey(k_SHInsEmpID)];
            return (SocialAndHealthInsurance)ob;
        }

		public SocialAndHealthInsurance GetObjectByKey(long k_SHInsEmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SHInsEmpID)) == false) {
				SocialAndHealthInsurance ob = repository.GetQuery<SocialAndHealthInsurance>().FirstOrDefault(o => o.SHInsEmpID == k_SHInsEmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            SocialAndHealthInsurance obj = this[GetKey(k_SHInsEmpID)];
            return (SocialAndHealthInsurance)obj;
        }

		public SocialAndHealthInsurance GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            SocialAndHealthInsurance ob = this[keypair];
            return (SocialAndHealthInsurance)ob;
        }

        public SocialAndHealthInsurance GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            SocialAndHealthInsurance ob = this[GetKey(keypair)];
            return (SocialAndHealthInsurance)ob;
        }

		bool _LoadAll = false;
        public List<SocialAndHealthInsurance> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<SocialAndHealthInsurance>().ToList();
			foreach (SocialAndHealthInsurance item in list) {
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

        ~KeyedSocialAndHealthInsurance()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
