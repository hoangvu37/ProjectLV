/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : BloodDonation.cs         
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
	public partial class BloodDonation : BaseEntity, ICloneable	{
		public BloodDonation()
		{
			this.BloodDonID = 0;
            this.Qty = 1;
			this.DonorID = 0;
            this.BloodBankID = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("BloodDonID", BloodDonID); } }


		private long _BloodDonID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long BloodDonID { get { return _BloodDonID; } set {_BloodDonID = value; } }

		private DateTime _DayOfDonation;
		[LVRequired]
        public DateTime DayOfDonation { get { return _DayOfDonation; } set {_DayOfDonation = value; } }

		private byte _Qty;
		[LVRequired]
        public byte Qty { get { return _Qty; } set {_Qty = value; } }

		private string _Desc;
        [LVMaxLength(1024)]
        public string Desc { get { return _Desc; } set {_Desc = value; } }

		private long? _DonorID;
        public long? DonorID { get { return _DonorID; } set {_DonorID = value; } }

		private long? _BloodBankID;
        public long? BloodBankID { get { return _BloodBankID; } set {_BloodBankID = value; } }

		/// <summary>
/// Ref Key: FK_BloodDonation_Bloodbank
/// <summary>
/// <summary>
/// Ref Key: FK_BloodDonation_Donor
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
    public class KeyedBloodDonation : KeyedCollection<KeyValuePair<string, long>, BloodDonation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedBloodDonation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(BloodDonation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_BloodDonID) { return new KeyValuePair<string, long>("BloodDonID", k_BloodDonID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(BloodDonation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, BloodDonation item)
        {
            BloodDonation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(BloodDonation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(BloodDonation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public BloodDonation GetObjectByKey(long k_BloodDonID) 
		{
            if (this.Contains(GetKey(k_BloodDonID)) == false) return null;
            BloodDonation ob = this[GetKey(k_BloodDonID)];
            return (BloodDonation)ob;
        }

		public BloodDonation GetObjectByKey(long k_BloodDonID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_BloodDonID)) == false) {
				BloodDonation ob = repository.GetQuery<BloodDonation>().FirstOrDefault(o => o.BloodDonID == k_BloodDonID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            BloodDonation obj = this[GetKey(k_BloodDonID)];
            return (BloodDonation)obj;
        }

		public BloodDonation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            BloodDonation ob = this[keypair];
            return (BloodDonation)ob;
        }

        public BloodDonation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            BloodDonation ob = this[GetKey(keypair)];
            return (BloodDonation)ob;
        }

		bool _LoadAll = false;
        public List<BloodDonation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<BloodDonation>().ToList();
			foreach (BloodDonation item in list) {
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

        ~KeyedBloodDonation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
