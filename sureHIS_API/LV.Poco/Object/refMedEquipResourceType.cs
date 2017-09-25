/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refMedEquipResourceType.cs         
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
	public partial class refMedEquipResourceType : BaseEntity, ICloneable	{
		public refMedEquipResourceType()
		{
            this.PMDRscTypeID = null;
			this.MDRscTypeID = 0;
            this.MDRscTypeDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MDRscTypeID", MDRscTypeID); } }


		private long? _PMDRscTypeID;
        public long? PMDRscTypeID { get { return _PMDRscTypeID; } set {_PMDRscTypeID = value; } }

		private long _MDRscTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MDRscTypeID { get { return _MDRscTypeID; } set {_MDRscTypeID = value; } }

		private string _MDRscTypeName;
		[LVRequired]
        [LVMaxLength(128)]
        public string MDRscTypeName { get { return _MDRscTypeName; } set {_MDRscTypeName = value; } }

		private string _MDRscTypeDesc;
        [LVMaxLength(2048)]
        public string MDRscTypeDesc { get { return _MDRscTypeDesc; } set {_MDRscTypeDesc = value; } }

		/// <summary>
/// Ref Key: FK_refMedEquipResourceType_refMedEquipResourceType
/// <summary>
/// <summary>
/// Ref Key: FK_refMedEquipResourceType_refMedEquipResourceType
/// <summary>
/// <summary>
/// Ref Key: FK_Resource_refMedEquipResourceType
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
    public class KeyedrefMedEquipResourceType : KeyedCollection<KeyValuePair<string, long>, refMedEquipResourceType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefMedEquipResourceType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refMedEquipResourceType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MDRscTypeID) { return new KeyValuePair<string, long>("MDRscTypeID", k_MDRscTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refMedEquipResourceType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refMedEquipResourceType item)
        {
            refMedEquipResourceType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refMedEquipResourceType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refMedEquipResourceType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refMedEquipResourceType GetObjectByKey(long k_MDRscTypeID) 
		{
            if (this.Contains(GetKey(k_MDRscTypeID)) == false) return null;
            refMedEquipResourceType ob = this[GetKey(k_MDRscTypeID)];
            return (refMedEquipResourceType)ob;
        }

		public refMedEquipResourceType GetObjectByKey(long k_MDRscTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MDRscTypeID)) == false) {
				refMedEquipResourceType ob = repository.GetQuery<refMedEquipResourceType>().FirstOrDefault(o => o.MDRscTypeID == k_MDRscTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refMedEquipResourceType obj = this[GetKey(k_MDRscTypeID)];
            return (refMedEquipResourceType)obj;
        }

		public refMedEquipResourceType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refMedEquipResourceType ob = this[keypair];
            return (refMedEquipResourceType)ob;
        }

        public refMedEquipResourceType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refMedEquipResourceType ob = this[GetKey(keypair)];
            return (refMedEquipResourceType)ob;
        }

		bool _LoadAll = false;
        public List<refMedEquipResourceType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refMedEquipResourceType>().ToList();
			foreach (refMedEquipResourceType item in list) {
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

        ~KeyedrefMedEquipResourceType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
