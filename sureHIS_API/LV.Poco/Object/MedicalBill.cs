/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedicalBill.cs         
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
	public partial class MedicalBill : BaseEntity, ICloneable	{
		public MedicalBill()
		{
			this.MedBillID = 0;
			this.PresID = 0;
			this.HosFeeTransDtlID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedBillID", MedBillID); } }


		private long _MedBillID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedBillID { get { return _MedBillID; } set {_MedBillID = value; } }

		private long _PresID;
		[LVRequired]
        public long PresID { get { return _PresID; } set {_PresID = value; } }

		private long? _HosFeeTransDtlID;
        public long? HosFeeTransDtlID { get { return _HosFeeTransDtlID; } set {_HosFeeTransDtlID = value; } }

		/// <summary>
/// Ref Key: FK_MedicalBill_Prescription
/// <summary>
/// <summary>
/// Ref Key: FK_MedicalBills_MedicalBill
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
    public class KeyedMedicalBill : KeyedCollection<KeyValuePair<string, long>, MedicalBill>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedicalBill() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedicalBill item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedBillID) { return new KeyValuePair<string, long>("MedBillID", k_MedBillID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedicalBill item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedicalBill item)
        {
            MedicalBill orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedicalBill item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedicalBill item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedicalBill GetObjectByKey(long k_MedBillID) 
		{
            if (this.Contains(GetKey(k_MedBillID)) == false) return null;
            MedicalBill ob = this[GetKey(k_MedBillID)];
            return (MedicalBill)ob;
        }

		public MedicalBill GetObjectByKey(long k_MedBillID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedBillID)) == false) {
				MedicalBill ob = repository.GetQuery<MedicalBill>().FirstOrDefault(o => o.MedBillID == k_MedBillID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedicalBill obj = this[GetKey(k_MedBillID)];
            return (MedicalBill)obj;
        }

		public MedicalBill GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedicalBill ob = this[keypair];
            return (MedicalBill)ob;
        }

        public MedicalBill GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedicalBill ob = this[GetKey(keypair)];
            return (MedicalBill)ob;
        }

		bool _LoadAll = false;
        public List<MedicalBill> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedicalBill>().ToList();
			foreach (MedicalBill item in list) {
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

        ~KeyedMedicalBill()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
