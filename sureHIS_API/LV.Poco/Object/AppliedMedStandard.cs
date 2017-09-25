/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AppliedMedStandard.cs         
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
	public partial class AppliedMedStandard : BaseEntity, ICloneable	{
		public AppliedMedStandard()
		{
			this.MedDeviceStdID = 0;
			this.RscrID = 0;
			this.V_MedDeviceStd = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedDeviceStdID", MedDeviceStdID); } }


		private long _MedDeviceStdID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedDeviceStdID { get { return _MedDeviceStdID; } set {_MedDeviceStdID = value; } }

		private long _RscrID;
		[LVRequired]
        public long RscrID { get { return _RscrID; } set {_RscrID = value; } }

		private long _V_MedDeviceStd;
		[LVRequired]
        public long V_MedDeviceStd { get { return _V_MedDeviceStd; } set {_V_MedDeviceStd = value; } }

		/// <summary>
/// Ref Key: FK_AppliedMedStandard_Resource
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
    public class KeyedAppliedMedStandard : KeyedCollection<KeyValuePair<string, long>, AppliedMedStandard>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAppliedMedStandard() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AppliedMedStandard item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedDeviceStdID) { return new KeyValuePair<string, long>("MedDeviceStdID", k_MedDeviceStdID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AppliedMedStandard item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AppliedMedStandard item)
        {
            AppliedMedStandard orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AppliedMedStandard item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AppliedMedStandard item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AppliedMedStandard GetObjectByKey(long k_MedDeviceStdID) 
		{
            if (this.Contains(GetKey(k_MedDeviceStdID)) == false) return null;
            AppliedMedStandard ob = this[GetKey(k_MedDeviceStdID)];
            return (AppliedMedStandard)ob;
        }

		public AppliedMedStandard GetObjectByKey(long k_MedDeviceStdID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedDeviceStdID)) == false) {
				AppliedMedStandard ob = repository.GetQuery<AppliedMedStandard>().FirstOrDefault(o => o.MedDeviceStdID == k_MedDeviceStdID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AppliedMedStandard obj = this[GetKey(k_MedDeviceStdID)];
            return (AppliedMedStandard)obj;
        }

		public AppliedMedStandard GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AppliedMedStandard ob = this[keypair];
            return (AppliedMedStandard)ob;
        }

        public AppliedMedStandard GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AppliedMedStandard ob = this[GetKey(keypair)];
            return (AppliedMedStandard)ob;
        }

		bool _LoadAll = false;
        public List<AppliedMedStandard> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AppliedMedStandard>().ToList();
			foreach (AppliedMedStandard item in list) {
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

        ~KeyedAppliedMedStandard()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
