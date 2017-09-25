/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Bloodbank.cs         
 * Created by           : Auto - 09/11/2017 15:20:03                     
 * Last modify          : Auto - 09/11/2017 15:20:03                     
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
	public partial class Bloodbank : BaseEntity, ICloneable	{
		public Bloodbank()
		{
			this.BloodBankID = 0;
			this.BloodTypeID = 0;
			this.Qty = 0;
            this.IsLimited = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("BloodBankID", BloodBankID); } }


		private long _BloodBankID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long BloodBankID { get { return _BloodBankID; } set {_BloodBankID = value; } }

		private long _BloodTypeID;
		[LVRequired]
        public long BloodTypeID { get { return _BloodTypeID; } set {_BloodTypeID = value; } }

		private short _Qty;
		[LVRequired]
        public short Qty { get { return _Qty; } set {_Qty = value; } }

		private string _DonatedUnit;
        [LVMaxLength(64)]
        public string DonatedUnit { get { return _DonatedUnit; } set {_DonatedUnit = value; } }

		private DateTime _StorageDate;
		[LVRequired]
        public DateTime StorageDate { get { return _StorageDate; } set {_StorageDate = value; } }

		private bool _IsLimited;
        public bool IsLimited { get { return _IsLimited; } set {_IsLimited = value; } }

		/// <summary>
/// Ref Key: FK_Bloodbank_refBloodType
/// <summary>
/// <summary>
/// Ref Key: FK_BloodDonation_Bloodbank
/// <summary>
/// <summary>
/// Ref Key: FK_SeparationOfBlood_Bloodbank
/// <summary>
/// <summary>
/// Ref Key: FK_TestBlood_Bloodbank
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
    public class KeyedBloodbank : KeyedCollection<KeyValuePair<string, long>, Bloodbank>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedBloodbank() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Bloodbank item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_BloodBankID) { return new KeyValuePair<string, long>("BloodBankID", k_BloodBankID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Bloodbank item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Bloodbank item)
        {
            Bloodbank orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Bloodbank item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Bloodbank item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Bloodbank GetObjectByKey(long k_BloodBankID) 
		{
            if (this.Contains(GetKey(k_BloodBankID)) == false) return null;
            Bloodbank ob = this[GetKey(k_BloodBankID)];
            return (Bloodbank)ob;
        }

		public Bloodbank GetObjectByKey(long k_BloodBankID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_BloodBankID)) == false) {
				Bloodbank ob = repository.GetQuery<Bloodbank>().FirstOrDefault(o => o.BloodBankID == k_BloodBankID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Bloodbank obj = this[GetKey(k_BloodBankID)];
            return (Bloodbank)obj;
        }

		public Bloodbank GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Bloodbank ob = this[keypair];
            return (Bloodbank)ob;
        }

        public Bloodbank GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Bloodbank ob = this[GetKey(keypair)];
            return (Bloodbank)ob;
        }

		bool _LoadAll = false;
        public List<Bloodbank> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Bloodbank>().ToList();
			foreach (Bloodbank item in list) {
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

        ~KeyedBloodbank()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
