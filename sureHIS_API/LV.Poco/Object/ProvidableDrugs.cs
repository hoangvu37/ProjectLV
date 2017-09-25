/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ProvidableDrugs.cs         
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
	public partial class ProvidableDrugs : BaseEntity, ICloneable	{
		public ProvidableDrugs()
		{
			this.ProvDrugID = 0;
			this.DrugID = 0;
			this.PharmcID = 0;
            this.NoEffect = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ProvDrugID", ProvDrugID); } }


		private long _ProvDrugID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ProvDrugID { get { return _ProvDrugID; } set {_ProvDrugID = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private long _PharmcID;
		[LVRequired]
        public long PharmcID { get { return _PharmcID; } set {_PharmcID = value; } }

		private bool? _NoEffect;
        public bool? NoEffect { get { return _NoEffect; } set {_NoEffect = value; } }

		/// <summary>
/// Ref Key: FK_ProvidableDrugs_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_ProvidableDrugs_PharmaceuticalCompany
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
    public class KeyedProvidableDrugs : KeyedCollection<KeyValuePair<string, long>, ProvidableDrugs>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedProvidableDrugs() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ProvidableDrugs item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ProvDrugID) { return new KeyValuePair<string, long>("ProvDrugID", k_ProvDrugID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ProvidableDrugs item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ProvidableDrugs item)
        {
            ProvidableDrugs orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ProvidableDrugs item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ProvidableDrugs item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ProvidableDrugs GetObjectByKey(long k_ProvDrugID) 
		{
            if (this.Contains(GetKey(k_ProvDrugID)) == false) return null;
            ProvidableDrugs ob = this[GetKey(k_ProvDrugID)];
            return (ProvidableDrugs)ob;
        }

		public ProvidableDrugs GetObjectByKey(long k_ProvDrugID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ProvDrugID)) == false) {
				ProvidableDrugs ob = repository.GetQuery<ProvidableDrugs>().FirstOrDefault(o => o.ProvDrugID == k_ProvDrugID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ProvidableDrugs obj = this[GetKey(k_ProvDrugID)];
            return (ProvidableDrugs)obj;
        }

		public ProvidableDrugs GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ProvidableDrugs ob = this[keypair];
            return (ProvidableDrugs)ob;
        }

        public ProvidableDrugs GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ProvidableDrugs ob = this[GetKey(keypair)];
            return (ProvidableDrugs)ob;
        }

		bool _LoadAll = false;
        public List<ProvidableDrugs> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ProvidableDrugs>().ToList();
			foreach (ProvidableDrugs item in list) {
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

        ~KeyedProvidableDrugs()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
