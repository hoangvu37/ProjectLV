/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AdmNoTempHolding.cs         
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
	public partial class AdmNoTempHolding : BaseEntity, ICloneable	{
		public AdmNoTempHolding()
		{
			this.AdmNoTempID = 0;
            this.IsHolding = true;
			this.AccountID = 0;
            this.GeneratedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public  Key { get { return ; } }


		private long _AdmNoTempID;
		[LVRequired]
        public long AdmNoTempID { get { return _AdmNoTempID; } set {_AdmNoTempID = value; } }

		private string _PtAdmNo;
        [LVMaxLength(20)]
        public string PtAdmNo { get { return _PtAdmNo; } set {_PtAdmNo = value; } }

		private bool? _IsHolding;
        public bool? IsHolding { get { return _IsHolding; } set {_IsHolding = value; } }

		private long? _AccountID;
        public long? AccountID { get { return _AccountID; } set {_AccountID = value; } }

		private DateTime? _GeneratedDate;
        public DateTime? GeneratedDate { get { return _GeneratedDate; } set {_GeneratedDate = value; } }

		/// <summary>
/// Ref Key: FK_AdmNoTempHolding_AdmNoTemp
/// <summary>
/// <summary>
/// Ref Key: FK_AdmNoTempHolding_UserAccount
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
    public class KeyedAdmNoTempHolding : KeyedCollection<, AdmNoTempHolding>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAdmNoTempHolding() : base() { }

        protected override  GetKeyForItem(AdmNoTempHolding item)
        {
            return item.Key;
        }

        public  GetKey() { return ; }

        public  GetKey(object keypair) { try { return ()keypair; } catch { return new (); } }
        #endregion

        #region Method
        public bool AddObject(AdmNoTempHolding item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem( keypair, AdmNoTempHolding item)
        {
            AdmNoTempHolding orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AdmNoTempHolding item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AdmNoTempHolding item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AdmNoTempHolding GetObjectByKey() 
		{
            if (this.Contains(GetKey()) == false) return null;
            AdmNoTempHolding ob = this[GetKey()];
            return (AdmNoTempHolding)ob;
        }

		public AdmNoTempHolding GetObjectByKey(, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey()) == false) {
				AdmNoTempHolding ob = repository.GetQuery<AdmNoTempHolding>().FirstOrDefault(o => );
				if(ob != null) this.Add(ob);
				return ob;
			}
            AdmNoTempHolding obj = this[GetKey()];
            return (AdmNoTempHolding)obj;
        }

		public AdmNoTempHolding GetObjectByKey( keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AdmNoTempHolding ob = this[keypair];
            return (AdmNoTempHolding)ob;
        }

        public AdmNoTempHolding GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AdmNoTempHolding ob = this[GetKey(keypair)];
            return (AdmNoTempHolding)ob;
        }

		bool _LoadAll = false;
        public List<AdmNoTempHolding> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AdmNoTempHolding>().ToList();
			foreach (AdmNoTempHolding item in list) {
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

        ~KeyedAdmNoTempHolding()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
