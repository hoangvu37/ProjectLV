/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : InsuranceInterests.cs         
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
	public partial class InsuranceInterests : BaseEntity, ICloneable	{
		public InsuranceInterests()
		{
			this.IIID = 0;
			this.IBID = 0;
			this.RebatePercentage = 0;
			this.MaxPayable = 0;
			this.MaxPayableRemark = 0;
			this.PercentageOnMaxPayable = 0;
			this.EstEmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("IIID", IIID); } }


		private long _IIID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long IIID { get { return _IIID; } set {_IIID = value; } }

		private int? _IBID;
        public int? IBID { get { return _IBID; } set {_IBID = value; } }

		private string _InsInterestsCode;
        [LVMaxLength(3)]
        public string InsInterestsCode { get { return _InsInterestsCode; } set {_InsInterestsCode = value; } }

		private string _InsInterestsName;
        [LVMaxLength(500)]
        public string InsInterestsName { get { return _InsInterestsName; } set {_InsInterestsName = value; } }

		private double? _RebatePercentage;
        public double? RebatePercentage { get { return _RebatePercentage; } set {_RebatePercentage = value; } }

		private double? _MaxPayable;
        public double? MaxPayable { get { return _MaxPayable; } set {_MaxPayable = value; } }

		private double? _MaxPayableRemark;
        public double? MaxPayableRemark { get { return _MaxPayableRemark; } set {_MaxPayableRemark = value; } }

		private double? _PercentageOnMaxPayable;
        public double? PercentageOnMaxPayable { get { return _PercentageOnMaxPayable; } set {_PercentageOnMaxPayable = value; } }

		private DateTime? _UpdateDate;
        public DateTime? UpdateDate { get { return _UpdateDate; } set {_UpdateDate = value; } }

		private long? _EstEmpID;
        public long? EstEmpID { get { return _EstEmpID; } set {_EstEmpID = value; } }

		

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
    public class KeyedInsuranceInterests : KeyedCollection<KeyValuePair<string, long>, InsuranceInterests>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedInsuranceInterests() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(InsuranceInterests item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_IIID) { return new KeyValuePair<string, long>("IIID", k_IIID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(InsuranceInterests item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, InsuranceInterests item)
        {
            InsuranceInterests orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(InsuranceInterests item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(InsuranceInterests item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public InsuranceInterests GetObjectByKey(long k_IIID) 
		{
            if (this.Contains(GetKey(k_IIID)) == false) return null;
            InsuranceInterests ob = this[GetKey(k_IIID)];
            return (InsuranceInterests)ob;
        }

		public InsuranceInterests GetObjectByKey(long k_IIID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_IIID)) == false) {
				InsuranceInterests ob = repository.GetQuery<InsuranceInterests>().FirstOrDefault(o => o.IIID == k_IIID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            InsuranceInterests obj = this[GetKey(k_IIID)];
            return (InsuranceInterests)obj;
        }

		public InsuranceInterests GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            InsuranceInterests ob = this[keypair];
            return (InsuranceInterests)ob;
        }

        public InsuranceInterests GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            InsuranceInterests ob = this[GetKey(keypair)];
            return (InsuranceInterests)ob;
        }

		bool _LoadAll = false;
        public List<InsuranceInterests> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<InsuranceInterests>().ToList();
			foreach (InsuranceInterests item in list) {
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

        ~KeyedInsuranceInterests()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
