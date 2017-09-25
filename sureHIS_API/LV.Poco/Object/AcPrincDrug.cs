/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AcPrincDrug.cs         
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
	public partial class AcPrincDrug : BaseEntity, ICloneable	{
		public AcPrincDrug()
		{
			this.ADID = 0;
			this.DrugID = 0;
			this.AcPrincipleID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ADID", ADID); } }


		private long _ADID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ADID { get { return _ADID; } set {_ADID = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private long _AcPrincipleID;
		[LVRequired]
        public long AcPrincipleID { get { return _AcPrincipleID; } set {_AcPrincipleID = value; } }

		/// <summary>
/// Ref Key: FK_AcPrincDrug_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_AcPrincDrug_refActiviePrinciple
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
    public class KeyedAcPrincDrug : KeyedCollection<KeyValuePair<string, long>, AcPrincDrug>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAcPrincDrug() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AcPrincDrug item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ADID) { return new KeyValuePair<string, long>("ADID", k_ADID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AcPrincDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AcPrincDrug item)
        {
            AcPrincDrug orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AcPrincDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AcPrincDrug item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AcPrincDrug GetObjectByKey(long k_ADID) 
		{
            if (this.Contains(GetKey(k_ADID)) == false) return null;
            AcPrincDrug ob = this[GetKey(k_ADID)];
            return (AcPrincDrug)ob;
        }

		public AcPrincDrug GetObjectByKey(long k_ADID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ADID)) == false) {
				AcPrincDrug ob = repository.GetQuery<AcPrincDrug>().FirstOrDefault(o => o.ADID == k_ADID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AcPrincDrug obj = this[GetKey(k_ADID)];
            return (AcPrincDrug)obj;
        }

		public AcPrincDrug GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AcPrincDrug ob = this[keypair];
            return (AcPrincDrug)ob;
        }

        public AcPrincDrug GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AcPrincDrug ob = this[GetKey(keypair)];
            return (AcPrincDrug)ob;
        }

		bool _LoadAll = false;
        public List<AcPrincDrug> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AcPrincDrug>().ToList();
			foreach (AcPrincDrug item in list) {
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

        ~KeyedAcPrincDrug()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
