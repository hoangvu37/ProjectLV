/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ChainMedicalServices.cs         
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
	public partial class ChainMedicalServices : BaseEntity, ICloneable	{
		public ChainMedicalServices()
		{
			this.ChainID = 0;
			this.MedSerPkgID = 0;
			this.MedSerID = 0;
			this.Weight = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ChainID", ChainID); } }


		private long _ChainID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ChainID { get { return _ChainID; } set {_ChainID = value; } }

		private long? _MedSerPkgID;
        public long? MedSerPkgID { get { return _MedSerPkgID; } set {_MedSerPkgID = value; } }

		private long? _MedSerID;
        public long? MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private byte _Idx;
		[LVRequired]
        public byte Idx { get { return _Idx; } set {_Idx = value; } }

		private double _Weight;
		[LVRequired]
        public double Weight { get { return _Weight; } set {_Weight = value; } }

		/// <summary>
/// Ref Key: FK_ChainMedicalServices_MedicalServicePackage
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
    public class KeyedChainMedicalServices : KeyedCollection<KeyValuePair<string, long>, ChainMedicalServices>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedChainMedicalServices() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ChainMedicalServices item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ChainID) { return new KeyValuePair<string, long>("ChainID", k_ChainID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ChainMedicalServices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ChainMedicalServices item)
        {
            ChainMedicalServices orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ChainMedicalServices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ChainMedicalServices item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ChainMedicalServices GetObjectByKey(long k_ChainID) 
		{
            if (this.Contains(GetKey(k_ChainID)) == false) return null;
            ChainMedicalServices ob = this[GetKey(k_ChainID)];
            return (ChainMedicalServices)ob;
        }

		public ChainMedicalServices GetObjectByKey(long k_ChainID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ChainID)) == false) {
				ChainMedicalServices ob = repository.GetQuery<ChainMedicalServices>().FirstOrDefault(o => o.ChainID == k_ChainID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ChainMedicalServices obj = this[GetKey(k_ChainID)];
            return (ChainMedicalServices)obj;
        }

		public ChainMedicalServices GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ChainMedicalServices ob = this[keypair];
            return (ChainMedicalServices)ob;
        }

        public ChainMedicalServices GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ChainMedicalServices ob = this[GetKey(keypair)];
            return (ChainMedicalServices)ob;
        }

		bool _LoadAll = false;
        public List<ChainMedicalServices> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ChainMedicalServices>().ToList();
			foreach (ChainMedicalServices item in list) {
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

        ~KeyedChainMedicalServices()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
