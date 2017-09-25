/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : LotNumber.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class LotNumber : BaseEntity, ICloneable	{
		public LotNumber()
		{
			this.LotID = 0;
			this.DrugID = 0;
			this.VendorID = 0;
            this.Stop = false;
            this.CreatedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("LotID", LotID); } }


		private long _LotID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long LotID { get { return _LotID; } set {_LotID = value; } }

		private string _LotNoItem;
		[LVRequired]
        [LVMaxLength(100)]
        public string LotNoItem { get { return _LotNoItem; } set {_LotNoItem = value; } }

		private string _LotNo;
		[LVRequired]
        [LVMaxLength(50)]
        public string LotNo { get { return _LotNo; } set {_LotNo = value; } }

		private long _DrugID;
		[LVRequired]
        public long DrugID { get { return _DrugID; } set {_DrugID = value; } }

		private string _Memo;
        [LVMaxLength(254)]
        public string Memo { get { return _Memo; } set {_Memo = value; } }

		private DateTime? _RecvDate;
        public DateTime? RecvDate { get { return _RecvDate; } set {_RecvDate = value; } }

		private DateTime? _ProductionDate;
        public DateTime? ProductionDate { get { return _ProductionDate; } set {_ProductionDate = value; } }

		private DateTime? _PackingDate;
        public DateTime? PackingDate { get { return _PackingDate; } set {_PackingDate = value; } }

		private DateTime? _ExpiredDate;
        public DateTime? ExpiredDate { get { return _ExpiredDate; } set {_ExpiredDate = value; } }

		private string _CertificateNo;
        [LVMaxLength(100)]
        public string CertificateNo { get { return _CertificateNo; } set {_CertificateNo = value; } }

		private DateTime? _CertificateDate;
        public DateTime? CertificateDate { get { return _CertificateDate; } set {_CertificateDate = value; } }

		private DateTime? _BestUseBefDate;
        public DateTime? BestUseBefDate { get { return _BestUseBefDate; } set {_BestUseBefDate = value; } }

		private string _CountryID;
        [LVMaxLength(2)]
        public string CountryID { get { return _CountryID; } set {_CountryID = value; } }

		private string _ProducerID;
        [LVMaxLength(10)]
        public string ProducerID { get { return _ProducerID; } set {_ProducerID = value; } }

		private long? _VendorID;
        public long? VendorID { get { return _VendorID; } set {_VendorID = value; } }

		private DateTime? _VendExpWarDate;
        public DateTime? VendExpWarDate { get { return _VendExpWarDate; } set {_VendExpWarDate = value; } }

		private DateTime? _ExpMaintDate;
        public DateTime? ExpMaintDate { get { return _ExpMaintDate; } set {_ExpMaintDate = value; } }

		private string _Status;
        [LVMaxLength(1)]
        public string Status { get { return _Status; } set {_Status = value; } }

		private bool _Stop;
        public bool Stop { get { return _Stop; } set {_Stop = value; } }

		private DateTime _CreatedDate;
		[LVRequired]
        public DateTime CreatedDate { get { return _CreatedDate; } set {_CreatedDate = value; } }

		private string _CreatedBy;
        [LVMaxLength(20)]
        public string CreatedBy { get { return _CreatedBy; } set {_CreatedBy = value; } }

		private DateTime? _LastUpdDate;
        public DateTime? LastUpdDate { get { return _LastUpdDate; } set {_LastUpdDate = value; } }

		private string _LastUpdBy;
        [LVMaxLength(20)]
        public string LastUpdBy { get { return _LastUpdBy; } set {_LastUpdBy = value; } }

		/// <summary>
/// Ref Key: FK_InOutwardDrug_LotNumber
/// <summary>
/// <summary>
/// Ref Key: FK_LotNumber_PharmaceuticalCompany
/// <summary>
/// <summary>
/// Ref Key: FK_LotNumber_refCountry
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
    public class KeyedLotNumber : KeyedCollection<KeyValuePair<string, long>, LotNumber>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedLotNumber() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(LotNumber item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_LotID) { return new KeyValuePair<string, long>("LotID", k_LotID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(LotNumber item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, LotNumber item)
        {
            LotNumber orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(LotNumber item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(LotNumber item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public LotNumber GetObjectByKey(long k_LotID) 
		{
            if (this.Contains(GetKey(k_LotID)) == false) return null;
            LotNumber ob = this[GetKey(k_LotID)];
            return (LotNumber)ob;
        }

		public LotNumber GetObjectByKey(long k_LotID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_LotID)) == false) {
				LotNumber ob = repository.GetQuery<LotNumber>().FirstOrDefault(o => o.LotID == k_LotID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            LotNumber obj = this[GetKey(k_LotID)];
            return (LotNumber)obj;
        }

		public LotNumber GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            LotNumber ob = this[keypair];
            return (LotNumber)ob;
        }

        public LotNumber GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            LotNumber ob = this[GetKey(keypair)];
            return (LotNumber)ob;
        }

		bool _LoadAll = false;
        public List<LotNumber> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<LotNumber>().ToList();
			foreach (LotNumber item in list) {
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

        ~KeyedLotNumber()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
