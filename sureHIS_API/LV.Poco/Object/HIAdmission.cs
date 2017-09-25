/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HIAdmission.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class HIAdmission : BaseEntity, ICloneable	{
		public HIAdmission()
		{
			this.HIAdmID = 0;
			this.AdmID = 0;
			this.HICardID = 0;
			this.RebatePercentage = 0;
			this.V_NHIAdmCases = 0;
			this.V_NHITransCases = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HIAdmID", HIAdmID); } }


		private long _HIAdmID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HIAdmID { get { return _HIAdmID; } set {_HIAdmID = value; } }

		private long _AdmID;
		[LVRequired]
        public long AdmID { get { return _AdmID; } set {_AdmID = value; } }

		private long _HICardID;
		[LVRequired]
        public long HICardID { get { return _HICardID; } set {_HICardID = value; } }

		private double _RebatePercentage;
		[LVRequired]
        public double RebatePercentage { get { return _RebatePercentage; } set {_RebatePercentage = value; } }

		private long? _V_NHIAdmCases;
        public long? V_NHIAdmCases { get { return _V_NHIAdmCases; } set {_V_NHIAdmCases = value; } }

		private long? _V_NHITransCases;
        public long? V_NHITransCases { get { return _V_NHITransCases; } set {_V_NHITransCases = value; } }

		/// <summary>
/// Ref Key: FK_HIAdmission_HealthInsurance
/// <summary>
/// <summary>
/// Ref Key: FK_HIAdmission_PatientAdmission
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
    public class KeyedHIAdmission : KeyedCollection<KeyValuePair<string, long>, HIAdmission>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHIAdmission() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HIAdmission item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HIAdmID) { return new KeyValuePair<string, long>("HIAdmID", k_HIAdmID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HIAdmission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HIAdmission item)
        {
            HIAdmission orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HIAdmission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HIAdmission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HIAdmission GetObjectByKey(long k_HIAdmID) 
		{
            if (this.Contains(GetKey(k_HIAdmID)) == false) return null;
            HIAdmission ob = this[GetKey(k_HIAdmID)];
            return (HIAdmission)ob;
        }

		public HIAdmission GetObjectByKey(long k_HIAdmID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HIAdmID)) == false) {
				HIAdmission ob = repository.GetQuery<HIAdmission>().FirstOrDefault(o => o.HIAdmID == k_HIAdmID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HIAdmission obj = this[GetKey(k_HIAdmID)];
            return (HIAdmission)obj;
        }

		public HIAdmission GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HIAdmission ob = this[keypair];
            return (HIAdmission)ob;
        }

        public HIAdmission GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HIAdmission ob = this[GetKey(keypair)];
            return (HIAdmission)ob;
        }

		bool _LoadAll = false;
        public List<HIAdmission> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HIAdmission>().ToList();
			foreach (HIAdmission item in list) {
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

        ~KeyedHIAdmission()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
