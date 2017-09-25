/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PriceList.cs         
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
	public partial class PriceList : BaseEntity, ICloneable	{
		public PriceList()
		{
			this.PriceListID = 0;
            this.ExpDate = DateTime.Now;
            this.DeptID = null;
            this.CreatedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PriceListID", PriceListID); } }


		private long _PriceListID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PriceListID { get { return _PriceListID; } set {_PriceListID = value; } }

		private string _PriceListName;
		[LVRequired]
        [LVMaxLength(100)]
        public string PriceListName { get { return _PriceListName; } set {_PriceListName = value; } }

		private DateTime? _IssueDate;
        public DateTime? IssueDate { get { return _IssueDate; } set {_IssueDate = value; } }

		private DateTime _EffDate;
		[LVRequired]
        public DateTime EffDate { get { return _EffDate; } set {_EffDate = value; } }

		private DateTime? _ExpDate;
        public DateTime? ExpDate { get { return _ExpDate; } set {_ExpDate = value; } }

		private long? _DeptID;
        public long? DeptID { get { return _DeptID; } set {_DeptID = value; } }

		private DateTime _CreatedDate;
		[LVRequired]
        public DateTime CreatedDate { get { return _CreatedDate; } set {_CreatedDate = value; } }

		private string _CreatedBy;
        [LVMaxLength(20)]
        public string CreatedBy { get { return _CreatedBy; } set {_CreatedBy = value; } }

		private DateTime? _LastUpdDate;
        public DateTime? LastUpdDate { get { return _LastUpdDate; } set {_LastUpdDate = value; } }

		private string _LastUpdBy;
        [LVMaxLength(20)]
        public string LastUpdBy { get { return _LastUpdBy; } set {_LastUpdBy = value; } }

		private string _Notes;
        [LVMaxLength(2147483647)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_DrugPrice_PriceList
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
    public class KeyedPriceList : KeyedCollection<KeyValuePair<string, long>, PriceList>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPriceList() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PriceList item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PriceListID) { return new KeyValuePair<string, long>("PriceListID", k_PriceListID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PriceList item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PriceList item)
        {
            PriceList orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PriceList item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PriceList item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PriceList GetObjectByKey(long k_PriceListID) 
		{
            if (this.Contains(GetKey(k_PriceListID)) == false) return null;
            PriceList ob = this[GetKey(k_PriceListID)];
            return (PriceList)ob;
        }

		public PriceList GetObjectByKey(long k_PriceListID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PriceListID)) == false) {
				PriceList ob = repository.GetQuery<PriceList>().FirstOrDefault(o => o.PriceListID == k_PriceListID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PriceList obj = this[GetKey(k_PriceListID)];
            return (PriceList)obj;
        }

		public PriceList GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PriceList ob = this[keypair];
            return (PriceList)ob;
        }

        public PriceList GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PriceList ob = this[GetKey(keypair)];
            return (PriceList)ob;
        }

		bool _LoadAll = false;
        public List<PriceList> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PriceList>().ToList();
			foreach (PriceList item in list) {
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

        ~KeyedPriceList()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
