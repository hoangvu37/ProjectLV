/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Donor.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class Donor : BaseEntity, ICloneable	{
		public Donor()
		{
			this.DonorID = 0;
			this.BloodTypeID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DonorID", DonorID); } }


		private long _DonorID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DonorID { get { return _DonorID; } set {_DonorID = value; } }

		private long? _BloodTypeID;
        public long? BloodTypeID { get { return _BloodTypeID; } set {_BloodTypeID = value; } }

		/// <summary>
/// Ref Key: FK_BloodDonation_Donor
/// <summary>
/// <summary>
/// Ref Key: FK_Donor_refBloodType
/// <summary>
/// <summary>
/// Ref Key: FK_DonorMedicalConditions_Donor
/// <summary>
/// <summary>
/// Ref Key: FK_DonorMedication_Donor
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
    public class KeyedDonor : KeyedCollection<KeyValuePair<string, long>, Donor>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDonor() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Donor item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DonorID) { return new KeyValuePair<string, long>("DonorID", k_DonorID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Donor item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Donor item)
        {
            Donor orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Donor item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Donor item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Donor GetObjectByKey(long k_DonorID) 
		{
            if (this.Contains(GetKey(k_DonorID)) == false) return null;
            Donor ob = this[GetKey(k_DonorID)];
            return (Donor)ob;
        }

		public Donor GetObjectByKey(long k_DonorID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DonorID)) == false) {
				Donor ob = repository.GetQuery<Donor>().FirstOrDefault(o => o.DonorID == k_DonorID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Donor obj = this[GetKey(k_DonorID)];
            return (Donor)obj;
        }

		public Donor GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Donor ob = this[keypair];
            return (Donor)ob;
        }

        public Donor GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Donor ob = this[GetKey(keypair)];
            return (Donor)ob;
        }

		bool _LoadAll = false;
        public List<Donor> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Donor>().ToList();
			foreach (Donor item in list) {
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

        ~KeyedDonor()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
