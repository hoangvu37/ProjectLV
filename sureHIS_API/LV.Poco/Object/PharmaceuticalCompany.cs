/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PharmaceuticalCompany.cs         
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
	public partial class PharmaceuticalCompany : BaseEntity, ICloneable	{
		public PharmaceuticalCompany()
		{
			this.PharmcID = 0;
            this.OUID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PharmcID", PharmcID); } }


		private long _PharmcID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PharmcID { get { return _PharmcID; } set {_PharmcID = value; } }

		private string _PharmcName;
		[LVRequired]
        [LVMaxLength(80)]
        public string PharmcName { get { return _PharmcName; } set {_PharmcName = value; } }

		private long? _OUID;
        public long? OUID { get { return _OUID; } set {_OUID = value; } }

		/// <summary>
/// Ref Key: FK_LotNumber_PharmaceuticalCompany
/// <summary>
/// <summary>
/// Ref Key: FK_PharmaceuticalCompany_Organization
/// <summary>
/// <summary>
/// Ref Key: FK_ProvidableDrugs_PharmaceuticalCompany
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
    public class KeyedPharmaceuticalCompany : KeyedCollection<KeyValuePair<string, long>, PharmaceuticalCompany>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPharmaceuticalCompany() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PharmaceuticalCompany item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PharmcID) { return new KeyValuePair<string, long>("PharmcID", k_PharmcID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PharmaceuticalCompany item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PharmaceuticalCompany item)
        {
            PharmaceuticalCompany orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PharmaceuticalCompany item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PharmaceuticalCompany item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PharmaceuticalCompany GetObjectByKey(long k_PharmcID) 
		{
            if (this.Contains(GetKey(k_PharmcID)) == false) return null;
            PharmaceuticalCompany ob = this[GetKey(k_PharmcID)];
            return (PharmaceuticalCompany)ob;
        }

		public PharmaceuticalCompany GetObjectByKey(long k_PharmcID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PharmcID)) == false) {
				PharmaceuticalCompany ob = repository.GetQuery<PharmaceuticalCompany>().FirstOrDefault(o => o.PharmcID == k_PharmcID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PharmaceuticalCompany obj = this[GetKey(k_PharmcID)];
            return (PharmaceuticalCompany)obj;
        }

		public PharmaceuticalCompany GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PharmaceuticalCompany ob = this[keypair];
            return (PharmaceuticalCompany)ob;
        }

        public PharmaceuticalCompany GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PharmaceuticalCompany ob = this[GetKey(keypair)];
            return (PharmaceuticalCompany)ob;
        }

		bool _LoadAll = false;
        public List<PharmaceuticalCompany> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PharmaceuticalCompany>().ToList();
			foreach (PharmaceuticalCompany item in list) {
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

        ~KeyedPharmaceuticalCompany()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
