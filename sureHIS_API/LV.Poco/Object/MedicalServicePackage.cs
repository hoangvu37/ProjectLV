/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalServicePackage.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class MedicalServicePackage : BaseEntity, ICloneable	{
		public MedicalServicePackage()
		{
			this.MedSerPkgID = 0;
            this.IsDiscount = false;
            this.OnlyAppliedToBusiness = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedSerPkgID", MedSerPkgID); } }


		private long _MedSerPkgID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedSerPkgID { get { return _MedSerPkgID; } set {_MedSerPkgID = value; } }

		private string _MedSerPkgCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string MedSerPkgCode { get { return _MedSerPkgCode; } set {_MedSerPkgCode = value; } }

		private string _MedSerPkgName;
		[LVRequired]
        [LVMaxLength(128)]
        public string MedSerPkgName { get { return _MedSerPkgName; } set {_MedSerPkgName = value; } }

		private bool _IsDiscount;
        public bool IsDiscount { get { return _IsDiscount; } set {_IsDiscount = value; } }

		private bool? _OnlyAppliedToBusiness;
        public bool? OnlyAppliedToBusiness { get { return _OnlyAppliedToBusiness; } set {_OnlyAppliedToBusiness = value; } }

		/// <summary>
/// Ref Key: FK_ChainMedicalServices_MedicalServicePackage
/// <summary>
/// <summary>
/// Ref Key: FK_PromotionService_MedicalServicePackage
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
    public class KeyedMedicalServicePackage : KeyedCollection<KeyValuePair<string, long>, MedicalServicePackage>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalServicePackage() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalServicePackage item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedSerPkgID) { return new KeyValuePair<string, long>("MedSerPkgID", k_MedSerPkgID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalServicePackage item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalServicePackage item)
        {
            MedicalServicePackage orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalServicePackage item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalServicePackage item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalServicePackage GetObjectByKey(long k_MedSerPkgID) 
		{
            if (this.Contains(GetKey(k_MedSerPkgID)) == false) return null;
            MedicalServicePackage ob = this[GetKey(k_MedSerPkgID)];
            return (MedicalServicePackage)ob;
        }

		public MedicalServicePackage GetObjectByKey(long k_MedSerPkgID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedSerPkgID)) == false) {
				MedicalServicePackage ob = repository.GetQuery<MedicalServicePackage>().FirstOrDefault(o => o.MedSerPkgID == k_MedSerPkgID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalServicePackage obj = this[GetKey(k_MedSerPkgID)];
            return (MedicalServicePackage)obj;
        }

		public MedicalServicePackage GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalServicePackage ob = this[keypair];
            return (MedicalServicePackage)ob;
        }

        public MedicalServicePackage GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalServicePackage ob = this[GetKey(keypair)];
            return (MedicalServicePackage)ob;
        }

		bool _LoadAll = false;
        public List<MedicalServicePackage> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalServicePackage>().ToList();
			foreach (MedicalServicePackage item in list) {
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

        ~KeyedMedicalServicePackage()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
