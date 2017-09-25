/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MOHServiceItems.cs         
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
	public partial class MOHServiceItems : BaseEntity, ICloneable	{
		public MOHServiceItems()
		{
			this.MOHSerItemsID = 0;
			this.QuotationID = 0;
			this.MedSerID = 0;
			this.UnitPrice = 0;
            this.CreatedDate = DateTime.Now;
			this.CreatedBy = 0;
			this.LastUpdBy = 0;
            this.isSocialized = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MOHSerItemsID", MOHSerItemsID); } }


		private long _MOHSerItemsID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MOHSerItemsID { get { return _MOHSerItemsID; } set {_MOHSerItemsID = value; } }

		private long _QuotationID;
		[LVRequired]
        public long QuotationID { get { return _QuotationID; } set {_QuotationID = value; } }

		private long _MedSerID;
		[LVRequired]
        public long MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private double _UnitPrice;
		[LVRequired]
        public double UnitPrice { get { return _UnitPrice; } set {_UnitPrice = value; } }

		private DateTime _ValidDateFrom;
		[LVRequired]
        public DateTime ValidDateFrom { get { return _ValidDateFrom; } set {_ValidDateFrom = value; } }

		private DateTime? _ValidDateTo;
        public DateTime? ValidDateTo { get { return _ValidDateTo; } set {_ValidDateTo = value; } }

		private string _MedSerUOM;
		[LVRequired]
        [LVMaxLength(10)]
        public string MedSerUOM { get { return _MedSerUOM; } set {_MedSerUOM = value; } }

		private DateTime _CreatedDate;
		[LVRequired]
        public DateTime CreatedDate { get { return _CreatedDate; } set {_CreatedDate = value; } }

		private long? _CreatedBy;
        public long? CreatedBy { get { return _CreatedBy; } set {_CreatedBy = value; } }

		private DateTime? _LastUpdDate;
        public DateTime? LastUpdDate { get { return _LastUpdDate; } set {_LastUpdDate = value; } }

		private long? _LastUpdBy;
        public long? LastUpdBy { get { return _LastUpdBy; } set {_LastUpdBy = value; } }

		private bool? _isSocialized;
        public bool? isSocialized { get { return _isSocialized; } set {_isSocialized = value; } }

		/// <summary>
/// Ref Key: FK_MOHServiceItems_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MOHServiceItems_Quotation
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
    public class KeyedMOHServiceItems : KeyedCollection<KeyValuePair<string, long>, MOHServiceItems>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMOHServiceItems() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MOHServiceItems item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MOHSerItemsID) { return new KeyValuePair<string, long>("MOHSerItemsID", k_MOHSerItemsID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MOHServiceItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MOHServiceItems item)
        {
            MOHServiceItems orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MOHServiceItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MOHServiceItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MOHServiceItems GetObjectByKey(long k_MOHSerItemsID) 
		{
            if (this.Contains(GetKey(k_MOHSerItemsID)) == false) return null;
            MOHServiceItems ob = this[GetKey(k_MOHSerItemsID)];
            return (MOHServiceItems)ob;
        }

		public MOHServiceItems GetObjectByKey(long k_MOHSerItemsID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MOHSerItemsID)) == false) {
				MOHServiceItems ob = repository.GetQuery<MOHServiceItems>().FirstOrDefault(o => o.MOHSerItemsID == k_MOHSerItemsID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MOHServiceItems obj = this[GetKey(k_MOHSerItemsID)];
            return (MOHServiceItems)obj;
        }

		public MOHServiceItems GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MOHServiceItems ob = this[keypair];
            return (MOHServiceItems)ob;
        }

        public MOHServiceItems GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MOHServiceItems ob = this[GetKey(keypair)];
            return (MOHServiceItems)ob;
        }

		bool _LoadAll = false;
        public List<MOHServiceItems> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MOHServiceItems>().ToList();
			foreach (MOHServiceItems item in list) {
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

        ~KeyedMOHServiceItems()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
