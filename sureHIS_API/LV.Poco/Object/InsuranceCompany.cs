/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : InsuranceCompany.cs         
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
	public partial class InsuranceCompany : BaseEntity, ICloneable	{
		public InsuranceCompany()
		{
			this.InsCoID = 0;
            this.InsCoDesc = null;
            this.IsNHI = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("InsCoID", InsCoID); } }


		private long _InsCoID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long InsCoID { get { return _InsCoID; } set {_InsCoID = value; } }

		private string _InsCoName;
		[LVRequired]
        [LVMaxLength(128)]
        public string InsCoName { get { return _InsCoName; } set {_InsCoName = value; } }

		private string _InsCoShortName;
        [LVMaxLength(32)]
        public string InsCoShortName { get { return _InsCoShortName; } set {_InsCoShortName = value; } }

		private string _InsCoDesc;
        [LVMaxLength(2147483647)]
        public string InsCoDesc { get { return _InsCoDesc; } set {_InsCoDesc = value; } }

		private string _InsCoAddress;
        [LVMaxLength(512)]
        public string InsCoAddress { get { return _InsCoAddress; } set {_InsCoAddress = value; } }

		private bool? _IsNHI;
        public bool? IsNHI { get { return _IsNHI; } set {_IsNHI = value; } }

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
    public class KeyedInsuranceCompany : KeyedCollection<KeyValuePair<string, long>, InsuranceCompany>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedInsuranceCompany() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(InsuranceCompany item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_InsCoID) { return new KeyValuePair<string, long>("InsCoID", k_InsCoID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(InsuranceCompany item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, InsuranceCompany item)
        {
            InsuranceCompany orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(InsuranceCompany item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(InsuranceCompany item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public InsuranceCompany GetObjectByKey(long k_InsCoID) 
		{
            if (this.Contains(GetKey(k_InsCoID)) == false) return null;
            InsuranceCompany ob = this[GetKey(k_InsCoID)];
            return (InsuranceCompany)ob;
        }

		public InsuranceCompany GetObjectByKey(long k_InsCoID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_InsCoID)) == false) {
				InsuranceCompany ob = repository.GetQuery<InsuranceCompany>().FirstOrDefault(o => o.InsCoID == k_InsCoID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            InsuranceCompany obj = this[GetKey(k_InsCoID)];
            return (InsuranceCompany)obj;
        }

		public InsuranceCompany GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            InsuranceCompany ob = this[keypair];
            return (InsuranceCompany)ob;
        }

        public InsuranceCompany GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            InsuranceCompany ob = this[GetKey(keypair)];
            return (InsuranceCompany)ob;
        }

		bool _LoadAll = false;
        public List<InsuranceCompany> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<InsuranceCompany>().ToList();
			foreach (InsuranceCompany item in list) {
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

        ~KeyedInsuranceCompany()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
