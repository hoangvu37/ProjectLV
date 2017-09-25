/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrPrescriptionTmp.cs         
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
	public partial class DrPrescriptionTmp : BaseEntity, ICloneable	{
		public DrPrescriptionTmp()
		{
			this.DrID = 0;
			this.DrRxTmpID = 0;
            this.RxTmpDesc = null;
			this.ICD10 = 0;
            this.DiagDesc = null;
            this.V_RxCatg = null;
            this.IsNoEffect = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrRxTmpID", DrRxTmpID); } }


		private long _DrID;
		[LVRequired]
        public long DrID { get { return _DrID; } set {_DrID = value; } }

		private long _DrRxTmpID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrRxTmpID { get { return _DrRxTmpID; } set {_DrRxTmpID = value; } }

		private string _RxTmpName;
		[LVRequired]
        [LVMaxLength(64)]
        public string RxTmpName { get { return _RxTmpName; } set {_RxTmpName = value; } }

		private string _RxTmpDesc;
        [LVMaxLength(256)]
        public string RxTmpDesc { get { return _RxTmpDesc; } set {_RxTmpDesc = value; } }

		private long _ICD10;
		[LVRequired]
        public long ICD10 { get { return _ICD10; } set {_ICD10 = value; } }

		private string _DiagDesc;
        [LVMaxLength(128)]
        public string DiagDesc { get { return _DiagDesc; } set {_DiagDesc = value; } }

		private string _DrAdvice;
        [LVMaxLength(256)]
        public string DrAdvice { get { return _DrAdvice; } set {_DrAdvice = value; } }

		private long? _V_RxCatg;
        public long? V_RxCatg { get { return _V_RxCatg; } set {_V_RxCatg = value; } }

		private bool? _IsNoEffect;
        public bool? IsNoEffect { get { return _IsNoEffect; } set {_IsNoEffect = value; } }

		/// <summary>
/// Ref Key: FK_DrPrescriptionTmp_Employee
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmp_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_DrPrescriptionTmps_DrPrescriptionTmp
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
    public class KeyedDrPrescriptionTmp : KeyedCollection<KeyValuePair<string, long>, DrPrescriptionTmp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrPrescriptionTmp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrPrescriptionTmp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrRxTmpID) { return new KeyValuePair<string, long>("DrRxTmpID", k_DrRxTmpID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrPrescriptionTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrPrescriptionTmp item)
        {
            DrPrescriptionTmp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrPrescriptionTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrPrescriptionTmp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrPrescriptionTmp GetObjectByKey(long k_DrRxTmpID) 
		{
            if (this.Contains(GetKey(k_DrRxTmpID)) == false) return null;
            DrPrescriptionTmp ob = this[GetKey(k_DrRxTmpID)];
            return (DrPrescriptionTmp)ob;
        }

		public DrPrescriptionTmp GetObjectByKey(long k_DrRxTmpID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrRxTmpID)) == false) {
				DrPrescriptionTmp ob = repository.GetQuery<DrPrescriptionTmp>().FirstOrDefault(o => o.DrRxTmpID == k_DrRxTmpID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrPrescriptionTmp obj = this[GetKey(k_DrRxTmpID)];
            return (DrPrescriptionTmp)obj;
        }

		public DrPrescriptionTmp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrPrescriptionTmp ob = this[keypair];
            return (DrPrescriptionTmp)ob;
        }

        public DrPrescriptionTmp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrPrescriptionTmp ob = this[GetKey(keypair)];
            return (DrPrescriptionTmp)ob;
        }

		bool _LoadAll = false;
        public List<DrPrescriptionTmp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrPrescriptionTmp>().ToList();
			foreach (DrPrescriptionTmp item in list) {
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

        ~KeyedDrPrescriptionTmp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
