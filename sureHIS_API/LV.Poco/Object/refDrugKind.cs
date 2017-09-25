/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refDrugKind.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class refDrugKind : BaseEntity, ICloneable	{
		public refDrugKind()
		{
			this.DrugKindID = 0;
			this.PDrugKindID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DrugKindID", DrugKindID); } }


		private long _DrugKindID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DrugKindID { get { return _DrugKindID; } set {_DrugKindID = value; } }

		private string _DrugKindName;
		[LVRequired]
        [LVMaxLength(254)]
        public string DrugKindName { get { return _DrugKindName; } set {_DrugKindName = value; } }

		private long? _PDrugKindID;
        public long? PDrugKindID { get { return _PDrugKindID; } set {_PDrugKindID = value; } }

		/// <summary>
/// Ref Key: FK_Drug_DrugKind
/// <summary>
/// <summary>
/// Ref Key: FK_refDrugKind_refDrugKind
/// <summary>
/// <summary>
/// Ref Key: FK_refDrugKind_refDrugKind
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
    public class KeyedrefDrugKind : KeyedCollection<KeyValuePair<string, long>, refDrugKind>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefDrugKind() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refDrugKind item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DrugKindID) { return new KeyValuePair<string, long>("DrugKindID", k_DrugKindID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refDrugKind item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refDrugKind item)
        {
            refDrugKind orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refDrugKind item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refDrugKind item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refDrugKind GetObjectByKey(long k_DrugKindID) 
		{
            if (this.Contains(GetKey(k_DrugKindID)) == false) return null;
            refDrugKind ob = this[GetKey(k_DrugKindID)];
            return (refDrugKind)ob;
        }

		public refDrugKind GetObjectByKey(long k_DrugKindID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DrugKindID)) == false) {
				refDrugKind ob = repository.GetQuery<refDrugKind>().FirstOrDefault(o => o.DrugKindID == k_DrugKindID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refDrugKind obj = this[GetKey(k_DrugKindID)];
            return (refDrugKind)obj;
        }

		public refDrugKind GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refDrugKind ob = this[keypair];
            return (refDrugKind)ob;
        }

        public refDrugKind GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refDrugKind ob = this[GetKey(keypair)];
            return (refDrugKind)ob;
        }

		bool _LoadAll = false;
        public List<refDrugKind> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refDrugKind>().ToList();
			foreach (refDrugKind item in list) {
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

        ~KeyedrefDrugKind()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
