/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EquivMedService.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class EquivMedService : BaseEntity, ICloneable	{
		public EquivMedService()
		{
			this.EMSID = 0;
			this.MedSerID = 0;
            this.HISerItemID = null;
            this.Surcharge = null;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EMSID", EMSID); } }


		private long _EMSID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EMSID { get { return _EMSID; } set {_EMSID = value; } }

		private long _MedSerID;
		[LVRequired]
        public long MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private long? _HISerItemID;
        public long? HISerItemID { get { return _HISerItemID; } set {_HISerItemID = value; } }

		private double? _Surcharge;
        public double? Surcharge { get { return _Surcharge; } set {_Surcharge = value; } }

		private string _Notes;
        [LVMaxLength(1024)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_EquivMedService_HIServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_EquivMedService_MedicalServiceItem
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
    public class KeyedEquivMedService : KeyedCollection<KeyValuePair<string, long>, EquivMedService>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEquivMedService() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EquivMedService item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EMSID) { return new KeyValuePair<string, long>("EMSID", k_EMSID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EquivMedService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EquivMedService item)
        {
            EquivMedService orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EquivMedService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EquivMedService item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EquivMedService GetObjectByKey(long k_EMSID) 
		{
            if (this.Contains(GetKey(k_EMSID)) == false) return null;
            EquivMedService ob = this[GetKey(k_EMSID)];
            return (EquivMedService)ob;
        }

		public EquivMedService GetObjectByKey(long k_EMSID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EMSID)) == false) {
				EquivMedService ob = repository.GetQuery<EquivMedService>().FirstOrDefault(o => o.EMSID == k_EMSID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EquivMedService obj = this[GetKey(k_EMSID)];
            return (EquivMedService)obj;
        }

		public EquivMedService GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EquivMedService ob = this[keypair];
            return (EquivMedService)ob;
        }

        public EquivMedService GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EquivMedService ob = this[GetKey(keypair)];
            return (EquivMedService)ob;
        }

		bool _LoadAll = false;
        public List<EquivMedService> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EquivMedService>().ToList();
			foreach (EquivMedService item in list) {
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

        ~KeyedEquivMedService()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
