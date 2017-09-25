/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DrugConfign.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class DrugConfign : BaseEntity, ICloneable	{
		public DrugConfign()
		{
			this.ConfigDrugID = 0;
			this.DrugID = 0;
			this.RDrugID = 0;
			this.UOMID = 0;
            this.CnvFactor = 1;
            this.Quantity = 0;
            this.SysDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ConfigDrugID", ConfigDrugID); } }


		private long _ConfigDrugID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ConfigDrugID { get { return _ConfigDrugID; } set {_ConfigDrugID = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private long _RDrugID;
		[LVRequired]
        public long RDrugID { get { return _RDrugID; } set {_RDrugID = value; } }

		private long _UOMID;
		[LVRequired]
        public long UOMID { get { return _UOMID; } set {_UOMID = value; } }

		private decimal _CnvFactor;
		[LVRequired]
        public decimal CnvFactor { get { return _CnvFactor; } set {_CnvFactor = value; } }

		private decimal _Quantity;
		[LVRequired]
        public decimal Quantity { get { return _Quantity; } set {_Quantity = value; } }

		private string _Notes;
        [LVMaxLength(300)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private DateTime _SysDate;
		[LVRequired]
        public DateTime SysDate { get { return _SysDate; } set {_SysDate = value; } }

		/// <summary>
/// Ref Key: FK_DrugConfign_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DrugConfign_Drug_02
/// <summary>
/// <summary>
/// Ref Key: FK_DrugConfign_refUnitOfMeasure
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
    public class KeyedDrugConfign : KeyedCollection<KeyValuePair<string, long>, DrugConfign>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDrugConfign() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DrugConfign item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ConfigDrugID) { return new KeyValuePair<string, long>("ConfigDrugID", k_ConfigDrugID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DrugConfign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DrugConfign item)
        {
            DrugConfign orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DrugConfign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DrugConfign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DrugConfign GetObjectByKey(long k_ConfigDrugID) 
		{
            if (this.Contains(GetKey(k_ConfigDrugID)) == false) return null;
            DrugConfign ob = this[GetKey(k_ConfigDrugID)];
            return (DrugConfign)ob;
        }

		public DrugConfign GetObjectByKey(long k_ConfigDrugID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ConfigDrugID)) == false) {
				DrugConfign ob = repository.GetQuery<DrugConfign>().FirstOrDefault(o => o.ConfigDrugID == k_ConfigDrugID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DrugConfign obj = this[GetKey(k_ConfigDrugID)];
            return (DrugConfign)obj;
        }

		public DrugConfign GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DrugConfign ob = this[keypair];
            return (DrugConfign)ob;
        }

        public DrugConfign GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DrugConfign ob = this[GetKey(keypair)];
            return (DrugConfign)ob;
        }

		bool _LoadAll = false;
        public List<DrugConfign> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DrugConfign>().ToList();
			foreach (DrugConfign item in list) {
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

        ~KeyedDrugConfign()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
