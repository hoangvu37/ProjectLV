/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PromotionPlan.cs         
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
	public partial class PromotionPlan : BaseEntity, ICloneable	{
		public PromotionPlan()
		{
			this.PromID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PromID", PromID); } }


		private long _PromID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PromID { get { return _PromID; } set {_PromID = value; } }

		private string _PromName;
		[LVRequired]
        [LVMaxLength(80)]
        public string PromName { get { return _PromName; } set {_PromName = value; } }

		private DateTime _PromFromDate;
		[LVRequired]
        public DateTime PromFromDate { get { return _PromFromDate; } set {_PromFromDate = value; } }

		private DateTime _PromToDate;
		[LVRequired]
        public DateTime PromToDate { get { return _PromToDate; } set {_PromToDate = value; } }

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
    public class KeyedPromotionPlan : KeyedCollection<KeyValuePair<string, long>, PromotionPlan>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPromotionPlan() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PromotionPlan item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PromID) { return new KeyValuePair<string, long>("PromID", k_PromID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PromotionPlan item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PromotionPlan item)
        {
            PromotionPlan orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PromotionPlan item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PromotionPlan item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PromotionPlan GetObjectByKey(long k_PromID) 
		{
            if (this.Contains(GetKey(k_PromID)) == false) return null;
            PromotionPlan ob = this[GetKey(k_PromID)];
            return (PromotionPlan)ob;
        }

		public PromotionPlan GetObjectByKey(long k_PromID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PromID)) == false) {
				PromotionPlan ob = repository.GetQuery<PromotionPlan>().FirstOrDefault(o => o.PromID == k_PromID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PromotionPlan obj = this[GetKey(k_PromID)];
            return (PromotionPlan)obj;
        }

		public PromotionPlan GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PromotionPlan ob = this[keypair];
            return (PromotionPlan)ob;
        }

        public PromotionPlan GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PromotionPlan ob = this[GetKey(keypair)];
            return (PromotionPlan)ob;
        }

		bool _LoadAll = false;
        public List<PromotionPlan> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PromotionPlan>().ToList();
			foreach (PromotionPlan item in list) {
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

        ~KeyedPromotionPlan()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
