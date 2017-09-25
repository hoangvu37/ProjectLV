/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refStoreHouse.cs         
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
	public partial class refStoreHouse : BaseEntity, ICloneable	{
		public refStoreHouse()
		{
			this.StoreHouseID = 0;
            this.IsMain = false;
            this.Stop = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("StoreHouseID", StoreHouseID); } }


		private long _StoreHouseID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long StoreHouseID { get { return _StoreHouseID; } set {_StoreHouseID = value; } }

		private string _StoreHouseName;
		[LVRequired]
        [LVMaxLength(100)]
        public string StoreHouseName { get { return _StoreHouseName; } set {_StoreHouseName = value; } }

		private string _Address;
        [LVMaxLength(254)]
        public string Address { get { return _Address; } set {_Address = value; } }

		private string _Phone;
        [LVMaxLength(15)]
        public string Phone { get { return _Phone; } set {_Phone = value; } }

		private bool _IsMain;
        public bool IsMain { get { return _IsMain; } set {_IsMain = value; } }

		private bool _Stop;
        public bool Stop { get { return _Stop; } set {_Stop = value; } }

		/// <summary>
/// Ref Key: FK_InOutwardDrug_refStoreHouse
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
    public class KeyedrefStoreHouse : KeyedCollection<KeyValuePair<string, long>, refStoreHouse>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefStoreHouse() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refStoreHouse item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_StoreHouseID) { return new KeyValuePair<string, long>("StoreHouseID", k_StoreHouseID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refStoreHouse item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refStoreHouse item)
        {
            refStoreHouse orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refStoreHouse item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refStoreHouse item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refStoreHouse GetObjectByKey(long k_StoreHouseID) 
		{
            if (this.Contains(GetKey(k_StoreHouseID)) == false) return null;
            refStoreHouse ob = this[GetKey(k_StoreHouseID)];
            return (refStoreHouse)ob;
        }

		public refStoreHouse GetObjectByKey(long k_StoreHouseID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_StoreHouseID)) == false) {
				refStoreHouse ob = repository.GetQuery<refStoreHouse>().FirstOrDefault(o => o.StoreHouseID == k_StoreHouseID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refStoreHouse obj = this[GetKey(k_StoreHouseID)];
            return (refStoreHouse)obj;
        }

		public refStoreHouse GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refStoreHouse ob = this[keypair];
            return (refStoreHouse)ob;
        }

        public refStoreHouse GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refStoreHouse ob = this[GetKey(keypair)];
            return (refStoreHouse)ob;
        }

		bool _LoadAll = false;
        public List<refStoreHouse> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refStoreHouse>().ToList();
			foreach (refStoreHouse item in list) {
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

        ~KeyedrefStoreHouse()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
