/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : InsuranceBeneficiary.cs         
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
	public partial class InsuranceBeneficiary : BaseEntity, ICloneable	{
		public InsuranceBeneficiary()
		{
			this.IBID = 0;
			this.InsCoID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, int> Key { get { return new KeyValuePair<string, int>("IBID", IBID); } }


		private int _IBID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public int IBID { get { return _IBID; } set {_IBID = value; } }

		private string _IBCode;
		[LVRequired]
        [LVMaxLength(5)]
        public string IBCode { get { return _IBCode; } set {_IBCode = value; } }

		private string _IBDesc;
		[LVRequired]
        [LVMaxLength(1073741823)]
        public string IBDesc { get { return _IBDesc; } set {_IBDesc = value; } }

		private string _OtherPolicyDetails;
        [LVMaxLength(500)]
        public string OtherPolicyDetails { get { return _OtherPolicyDetails; } set {_OtherPolicyDetails = value; } }

		private long? _InsCoID;
        public long? InsCoID { get { return _InsCoID; } set {_InsCoID = value; } }

		/// <summary>
/// Ref Key: FK_InsuranceBeneficiary_InsuranceCompany
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
    public class KeyedInsuranceBeneficiary : KeyedCollection<KeyValuePair<string, int>, InsuranceBeneficiary>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedInsuranceBeneficiary() : base() { }

        protected override KeyValuePair<string, int> GetKeyForItem(InsuranceBeneficiary item)
        {
            return item.Key;
        }

        public KeyValuePair<string, int> GetKey(int k_IBID) { return new KeyValuePair<string, int>("IBID", k_IBID); }

        public KeyValuePair<string, int> GetKey(object keypair) { try { return (KeyValuePair<string, int>)keypair; } catch { return new KeyValuePair<string, int>(); } }
        #endregion

        #region Method
        public bool AddObject(InsuranceBeneficiary item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, int> keypair, InsuranceBeneficiary item)
        {
            InsuranceBeneficiary orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(InsuranceBeneficiary item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(InsuranceBeneficiary item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public InsuranceBeneficiary GetObjectByKey(int k_IBID) 
		{
            if (this.Contains(GetKey(k_IBID)) == false) return null;
            InsuranceBeneficiary ob = this[GetKey(k_IBID)];
            return (InsuranceBeneficiary)ob;
        }

		public InsuranceBeneficiary GetObjectByKey(int k_IBID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_IBID)) == false) {
				InsuranceBeneficiary ob = repository.GetQuery<InsuranceBeneficiary>().FirstOrDefault(o => o.IBID == k_IBID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            InsuranceBeneficiary obj = this[GetKey(k_IBID)];
            return (InsuranceBeneficiary)obj;
        }

		public InsuranceBeneficiary GetObjectByKey(KeyValuePair<string, int> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            InsuranceBeneficiary ob = this[keypair];
            return (InsuranceBeneficiary)ob;
        }

        public InsuranceBeneficiary GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            InsuranceBeneficiary ob = this[GetKey(keypair)];
            return (InsuranceBeneficiary)ob;
        }

		bool _LoadAll = false;
        public List<InsuranceBeneficiary> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<InsuranceBeneficiary>().ToList();
			foreach (InsuranceBeneficiary item in list) {
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

        ~KeyedInsuranceBeneficiary()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
