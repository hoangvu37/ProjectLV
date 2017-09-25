/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HIServiceItem.cs         
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
	public partial class HIServiceItem : BaseEntity, ICloneable	{
		public HIServiceItem()
		{
			this.HISerItemID = 0;
            this.V_HISerItem = null;
			this.MedSerTypeID = 0;
            this.Stop = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HISerItemID", HISerItemID); } }


		private long _HISerItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HISerItemID { get { return _HISerItemID; } set {_HISerItemID = value; } }

		private string _HISerItemCode;
		[LVRequired]
        [LVMaxLength(12)]
        public string HISerItemCode { get { return _HISerItemCode; } set {_HISerItemCode = value; } }

		private string _HISerItemName;
		[LVRequired]
        [LVMaxLength(250)]
        public string HISerItemName { get { return _HISerItemName; } set {_HISerItemName = value; } }

		private string _HISerItemDesc;
        [LVMaxLength(500)]
        public string HISerItemDesc { get { return _HISerItemDesc; } set {_HISerItemDesc = value; } }

		private string _HISerItemUOM;
		[LVRequired]
        [LVMaxLength(10)]
        public string HISerItemUOM { get { return _HISerItemUOM; } set {_HISerItemUOM = value; } }

		private long? _V_HISerItem;
        public long? V_HISerItem { get { return _V_HISerItem; } set {_V_HISerItem = value; } }

		private long _MedSerTypeID;
		[LVRequired]
        public long MedSerTypeID { get { return _MedSerTypeID; } set {_MedSerTypeID = value; } }

		private bool _Stop;
        public bool Stop { get { return _Stop; } set {_Stop = value; } }

		/// <summary>
/// Ref Key: FK_EquivMedService_HIServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_HIServiceItem_refMedicalServiceType
/// <summary>
/// <summary>
/// Ref Key: FK_HIServiceItems_HIServiceItem
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
    public class KeyedHIServiceItem : KeyedCollection<KeyValuePair<string, long>, HIServiceItem>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHIServiceItem() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HIServiceItem item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HISerItemID) { return new KeyValuePair<string, long>("HISerItemID", k_HISerItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HIServiceItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HIServiceItem item)
        {
            HIServiceItem orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HIServiceItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HIServiceItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HIServiceItem GetObjectByKey(long k_HISerItemID) 
		{
            if (this.Contains(GetKey(k_HISerItemID)) == false) return null;
            HIServiceItem ob = this[GetKey(k_HISerItemID)];
            return (HIServiceItem)ob;
        }

		public HIServiceItem GetObjectByKey(long k_HISerItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HISerItemID)) == false) {
				HIServiceItem ob = repository.GetQuery<HIServiceItem>().FirstOrDefault(o => o.HISerItemID == k_HISerItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HIServiceItem obj = this[GetKey(k_HISerItemID)];
            return (HIServiceItem)obj;
        }

		public HIServiceItem GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HIServiceItem ob = this[keypair];
            return (HIServiceItem)ob;
        }

        public HIServiceItem GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HIServiceItem ob = this[GetKey(keypair)];
            return (HIServiceItem)ob;
        }

		bool _LoadAll = false;
        public List<HIServiceItem> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HIServiceItem>().ToList();
			foreach (HIServiceItem item in list) {
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

        ~KeyedHIServiceItem()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
