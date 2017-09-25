/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refBloodType.cs         
 * Created by           : Auto - 09/11/2017 15:20:02                     
 * Last modify          : Auto - 09/11/2017 15:20:02                     
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
	public partial class refBloodType : BaseEntity, ICloneable	{
		public refBloodType()
		{
			this.BloodTypeID = 0;
            this.CanbeTranfusedTo = null;
            this.Desc = null;
            this.Antibody = null;
            this.Antigen = null;
            this.isRhesus = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("BloodTypeID", BloodTypeID); } }


		private long _BloodTypeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long BloodTypeID { get { return _BloodTypeID; } set {_BloodTypeID = value; } }

		private string _PtBloodTypeCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string PtBloodTypeCode { get { return _PtBloodTypeCode; } set {_PtBloodTypeCode = value; } }

		private string _CanbeTranfusedTo;
        public string CanbeTranfusedTo { get { return _CanbeTranfusedTo; } set {_CanbeTranfusedTo = value; } }

		private string _Desc;
        [LVMaxLength(1024)]
        public string Desc { get { return _Desc; } set {_Desc = value; } }

		private string _Antibody;
        [LVMaxLength(32)]
        public string Antibody { get { return _Antibody; } set {_Antibody = value; } }

		private string _Antigen;
        [LVMaxLength(32)]
        public string Antigen { get { return _Antigen; } set {_Antigen = value; } }

		private bool? _isRhesus;
        public bool? isRhesus { get { return _isRhesus; } set {_isRhesus = value; } }

		/// <summary>
/// Ref Key: FK_Bloodbank_refBloodType
/// <summary>
/// <summary>
/// Ref Key: FK_Donor_refBloodType
/// <summary>
/// <summary>
/// Ref Key: FK_Patient_refBloodType
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
    public class KeyedrefBloodType : KeyedCollection<KeyValuePair<string, long>, refBloodType>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefBloodType() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refBloodType item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_BloodTypeID) { return new KeyValuePair<string, long>("BloodTypeID", k_BloodTypeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refBloodType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refBloodType item)
        {
            refBloodType orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refBloodType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refBloodType item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refBloodType GetObjectByKey(long k_BloodTypeID) 
		{
            if (this.Contains(GetKey(k_BloodTypeID)) == false) return null;
            refBloodType ob = this[GetKey(k_BloodTypeID)];
            return (refBloodType)ob;
        }

		public refBloodType GetObjectByKey(long k_BloodTypeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_BloodTypeID)) == false) {
				refBloodType ob = repository.GetQuery<refBloodType>().FirstOrDefault(o => o.BloodTypeID == k_BloodTypeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refBloodType obj = this[GetKey(k_BloodTypeID)];
            return (refBloodType)obj;
        }

		public refBloodType GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refBloodType ob = this[keypair];
            return (refBloodType)ob;
        }

        public refBloodType GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refBloodType ob = this[GetKey(keypair)];
            return (refBloodType)ob;
        }

		bool _LoadAll = false;
        public List<refBloodType> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refBloodType>().ToList();
			foreach (refBloodType item in list) {
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

        ~KeyedrefBloodType()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
