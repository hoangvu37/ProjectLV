/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refUnitOfMeasure.cs         
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
	public partial class refUnitOfMeasure : BaseEntity, ICloneable	{
		public refUnitOfMeasure()
		{
			this.UOMNo = 0;
			this.V_UOMCategory = 0;
            this.UOMDesc = null;
			this.MCLID = 0;
            this.PrefID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("UOMNo", UOMNo); } }


		private long _UOMNo;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long UOMNo { get { return _UOMNo; } set {_UOMNo = value; } }

		private string _UOMCode;
		[LVRequired]
        [LVMaxLength(32)]
        public string UOMCode { get { return _UOMCode; } set {_UOMCode = value; } }

		private string _UOMName;
		[LVRequired]
        [LVMaxLength(128)]
        public string UOMName { get { return _UOMName; } set {_UOMName = value; } }

		private string _UOMSymbol;
		[LVRequired]
        [LVMaxLength(32)]
        public string UOMSymbol { get { return _UOMSymbol; } set {_UOMSymbol = value; } }

		private long? _V_UOMCategory;
        public long? V_UOMCategory { get { return _V_UOMCategory; } set {_V_UOMCategory = value; } }

		private string _UOMDesc;
        [LVMaxLength(100)]
        public string UOMDesc { get { return _UOMDesc; } set {_UOMDesc = value; } }

		private bool _IsBaseUnit;
        public bool IsBaseUnit { get { return _IsBaseUnit; } set {_IsBaseUnit = value; } }

		private long? _MCLID;
        public long? MCLID { get { return _MCLID; } set {_MCLID = value; } }

		private byte? _PrefID;
        public byte? PrefID { get { return _PrefID; } set {_PrefID = value; } }

		/// <summary>
/// Ref Key: FK_Drug_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refUnitOfMeasure_02
/// <summary>
/// <summary>
/// Ref Key: FK_Drug_refUnitOfMeasure_03
/// <summary>
/// <summary>
/// Ref Key: FK_DrugConfign_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalExamType_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_ConversionMS_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_PatientVitalSign_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_refUnitOfMeasure_refCLMeasurement
/// <summary>
/// <summary>
/// Ref Key: FK_refLimVitalSign_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_refUnitOfMeasure_SIPrefix
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
    public class KeyedrefUnitOfMeasure : KeyedCollection<KeyValuePair<string, long>, refUnitOfMeasure>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefUnitOfMeasure() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refUnitOfMeasure item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_UOMNo) { return new KeyValuePair<string, long>("UOMNo", k_UOMNo); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refUnitOfMeasure item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refUnitOfMeasure item)
        {
            refUnitOfMeasure orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refUnitOfMeasure item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refUnitOfMeasure item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refUnitOfMeasure GetObjectByKey(long k_UOMNo) 
		{
            if (this.Contains(GetKey(k_UOMNo)) == false) return null;
            refUnitOfMeasure ob = this[GetKey(k_UOMNo)];
            return (refUnitOfMeasure)ob;
        }

		public refUnitOfMeasure GetObjectByKey(long k_UOMNo, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_UOMNo)) == false) {
				refUnitOfMeasure ob = repository.GetQuery<refUnitOfMeasure>().FirstOrDefault(o => o.UOMNo == k_UOMNo);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refUnitOfMeasure obj = this[GetKey(k_UOMNo)];
            return (refUnitOfMeasure)obj;
        }

		public refUnitOfMeasure GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refUnitOfMeasure ob = this[keypair];
            return (refUnitOfMeasure)ob;
        }

        public refUnitOfMeasure GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refUnitOfMeasure ob = this[GetKey(keypair)];
            return (refUnitOfMeasure)ob;
        }

		bool _LoadAll = false;
        public List<refUnitOfMeasure> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refUnitOfMeasure>().ToList();
			foreach (refUnitOfMeasure item in list) {
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

        ~KeyedrefUnitOfMeasure()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
