/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refLimVitalSign.cs         
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
	public partial class refLimVitalSign : BaseEntity, ICloneable	{
		public refLimVitalSign()
		{
			this.LimVitID = 0;
			this.VitSignCode = 0;
            this.PersGenderCode = null;
            this.AgeOnly = false;
            this.MinAge = null;
            this.MaxAge = null;
            this.MinLim = null;
            this.MaxLim = null;
            this.VitSignUnitCode = null;
            this.V_LimVitType = null;
            this.V_VitStandType = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("LimVitID", LimVitID); } }


		private long _LimVitID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long LimVitID { get { return _LimVitID; } set {_LimVitID = value; } }

		private long _VitSignCode;
		[LVRequired]
        public long VitSignCode { get { return _VitSignCode; } set {_VitSignCode = value; } }

		private long? _PersGenderCode;
        public long? PersGenderCode { get { return _PersGenderCode; } set {_PersGenderCode = value; } }

		private bool _AgeOnly;
        public bool AgeOnly { get { return _AgeOnly; } set {_AgeOnly = value; } }

		private short? _MinAge;
        public short? MinAge { get { return _MinAge; } set {_MinAge = value; } }

		private short? _MaxAge;
        public short? MaxAge { get { return _MaxAge; } set {_MaxAge = value; } }

		private decimal? _MinLim;
        public decimal? MinLim { get { return _MinLim; } set {_MinLim = value; } }

		private decimal? _MaxLim;
        public decimal? MaxLim { get { return _MaxLim; } set {_MaxLim = value; } }

		private long? _VitSignUnitCode;
        public long? VitSignUnitCode { get { return _VitSignUnitCode; } set {_VitSignUnitCode = value; } }

		private long? _V_LimVitType;
        public long? V_LimVitType { get { return _V_LimVitType; } set {_V_LimVitType = value; } }

		private long? _V_VitStandType;
        public long? V_VitStandType { get { return _V_VitStandType; } set {_V_VitStandType = value; } }

		/// <summary>
/// Ref Key: FK_refLimVitalSign_refPersGender
/// <summary>
/// <summary>
/// Ref Key: FK_refLimVitalSign_refUnitOfMeasure
/// <summary>
/// <summary>
/// Ref Key: FK_refLimVitalSign_refVitalSign
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
    public class KeyedrefLimVitalSign : KeyedCollection<KeyValuePair<string, long>, refLimVitalSign>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefLimVitalSign() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refLimVitalSign item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_LimVitID) { return new KeyValuePair<string, long>("LimVitID", k_LimVitID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refLimVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refLimVitalSign item)
        {
            refLimVitalSign orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refLimVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refLimVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refLimVitalSign GetObjectByKey(long k_LimVitID) 
		{
            if (this.Contains(GetKey(k_LimVitID)) == false) return null;
            refLimVitalSign ob = this[GetKey(k_LimVitID)];
            return (refLimVitalSign)ob;
        }

		public refLimVitalSign GetObjectByKey(long k_LimVitID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_LimVitID)) == false) {
				refLimVitalSign ob = repository.GetQuery<refLimVitalSign>().FirstOrDefault(o => o.LimVitID == k_LimVitID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refLimVitalSign obj = this[GetKey(k_LimVitID)];
            return (refLimVitalSign)obj;
        }

		public refLimVitalSign GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refLimVitalSign ob = this[keypair];
            return (refLimVitalSign)ob;
        }

        public refLimVitalSign GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refLimVitalSign ob = this[GetKey(keypair)];
            return (refLimVitalSign)ob;
        }

		bool _LoadAll = false;
        public List<refLimVitalSign> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refLimVitalSign>().ToList();
			foreach (refLimVitalSign item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<refLimVitalSign> LoadIXFK_refLimVitalSign_refPersGender(long p_PersGenderCode, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<refLimVitalSign>().Where(o=> o.PersGenderCode == p_PersGenderCode).ToList();
			foreach (refLimVitalSign item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
            return list;
		}
			
		public List<refLimVitalSign> LoadIXFK_refLimVitalSign_refUnitOfMeasure(long p_VitSignUnitCode, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<refLimVitalSign>().Where(o=> o.VitSignUnitCode == p_VitSignUnitCode).ToList();
			foreach (refLimVitalSign item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
            return list;
		}
			
		public List<refLimVitalSign> LoadIXFK_refLimVitalSign_refVitalSign(long p_VitSignCode, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<refLimVitalSign>().Where(o=> o.VitSignCode == p_VitSignCode).ToList();
			foreach (refLimVitalSign item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
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

        ~KeyedrefLimVitalSign()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
