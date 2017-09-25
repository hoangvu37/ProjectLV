/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PromotionService.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class PromotionService : BaseEntity, ICloneable	{
		public PromotionService()
		{
			this.PromSerID = 0;
			this.PercentDiscount = 0;
            this.ApplyOnWithPrice = null;
			this.PromID = 0;
			this.MedSerPkgID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PromSerID", PromSerID); } }


		private long _PromSerID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PromSerID { get { return _PromSerID; } set {_PromSerID = value; } }

		private double _PercentDiscount;
		[LVRequired]
        public double PercentDiscount { get { return _PercentDiscount; } set {_PercentDiscount = value; } }

		private byte? _ApplyOnWithPrice;
        public byte? ApplyOnWithPrice { get { return _ApplyOnWithPrice; } set {_ApplyOnWithPrice = value; } }

		private long? _PromID;
        public long? PromID { get { return _PromID; } set {_PromID = value; } }

		private long? _MedSerPkgID;
        public long? MedSerPkgID { get { return _MedSerPkgID; } set {_MedSerPkgID = value; } }

		/// <summary>
/// Ref Key: FK_PromotionService_MedicalServicePackage
/// <summary>
/// <summary>
/// Ref Key: FK_PromotionService_PromotionPlan
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
    public class KeyedPromotionService : KeyedCollection<KeyValuePair<string, long>, PromotionService>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPromotionService() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PromotionService item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PromSerID) { return new KeyValuePair<string, long>("PromSerID", k_PromSerID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PromotionService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PromotionService item)
        {
            PromotionService orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PromotionService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PromotionService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PromotionService GetObjectByKey(long k_PromSerID) 
		{
            if (this.Contains(GetKey(k_PromSerID)) == false) return null;
            PromotionService ob = this[GetKey(k_PromSerID)];
            return (PromotionService)ob;
        }

		public PromotionService GetObjectByKey(long k_PromSerID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PromSerID)) == false) {
				PromotionService ob = repository.GetQuery<PromotionService>().FirstOrDefault(o => o.PromSerID == k_PromSerID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PromotionService obj = this[GetKey(k_PromSerID)];
            return (PromotionService)obj;
        }

		public PromotionService GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PromotionService ob = this[keypair];
            return (PromotionService)ob;
        }

        public PromotionService GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PromotionService ob = this[GetKey(keypair)];
            return (PromotionService)ob;
        }

		bool _LoadAll = false;
        public List<PromotionService> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PromotionService>().ToList();
			foreach (PromotionService item in list) {
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

        ~KeyedPromotionService()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
