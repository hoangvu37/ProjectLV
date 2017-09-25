/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Quotation.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class Quotation : BaseEntity, ICloneable	{
		public Quotation()
		{
			this.QuotationID = 0;
            this.IsNHI = false;
            this.ValidDateTo = DateTime.Now;
            this.Approved = false;
			this.ApprovedBy = 0;
            this.Stop = false;
            this.CreatedDate = DateTime.Now;
			this.CreatedBy = 0;
			this.LastUpdBy = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("QuotationID", QuotationID); } }


		private long _QuotationID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long QuotationID { get { return _QuotationID; } set {_QuotationID = value; } }

		private string _QuotationCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string QuotationCode { get { return _QuotationCode; } set {_QuotationCode = value; } }

		private string _QuotationName;
		[LVRequired]
        [LVMaxLength(150)]
        public string QuotationName { get { return _QuotationName; } set {_QuotationName = value; } }

		private string _QuotationDesc;
        [LVMaxLength(250)]
        public string QuotationDesc { get { return _QuotationDesc; } set {_QuotationDesc = value; } }

		private bool _IsNHI;
        public bool IsNHI { get { return _IsNHI; } set {_IsNHI = value; } }

		private DateTime _ValidDateFrom;
		[LVRequired]
        public DateTime ValidDateFrom { get { return _ValidDateFrom; } set {_ValidDateFrom = value; } }

		private DateTime? _ValidDateTo;
        public DateTime? ValidDateTo { get { return _ValidDateTo; } set {_ValidDateTo = value; } }

		private string _StrPtClassID;
        [LVMaxLength(50)]
        public string StrPtClassID { get { return _StrPtClassID; } set {_StrPtClassID = value; } }

		private DateTime _IssueDate;
		[LVRequired]
        public DateTime IssueDate { get { return _IssueDate; } set {_IssueDate = value; } }

		private string _CurCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string CurCode { get { return _CurCode; } set {_CurCode = value; } }

		private bool _Approved;
        public bool Approved { get { return _Approved; } set {_Approved = value; } }

		private DateTime? _ApprovedDate;
        public DateTime? ApprovedDate { get { return _ApprovedDate; } set {_ApprovedDate = value; } }

		private long? _ApprovedBy;
        public long? ApprovedBy { get { return _ApprovedBy; } set {_ApprovedBy = value; } }

		private bool _Stop;
        public bool Stop { get { return _Stop; } set {_Stop = value; } }

		private DateTime _CreatedDate;
		[LVRequired]
        public DateTime CreatedDate { get { return _CreatedDate; } set {_CreatedDate = value; } }

		private long? _CreatedBy;
        public long? CreatedBy { get { return _CreatedBy; } set {_CreatedBy = value; } }

		private DateTime? _LastUpdDate;
        public DateTime? LastUpdDate { get { return _LastUpdDate; } set {_LastUpdDate = value; } }

		private long? _LastUpdBy;
        public long? LastUpdBy { get { return _LastUpdBy; } set {_LastUpdBy = value; } }

		/// <summary>
/// Ref Key: FK_HIServiceItems_Quotation
/// <summary>
/// <summary>
/// Ref Key: FK_MOHServiceItems_Quotation
/// <summary>
/// <summary>
/// Ref Key: FK_Quotation_refCurrency
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
    public class KeyedQuotation : KeyedCollection<KeyValuePair<string, long>, Quotation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedQuotation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Quotation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_QuotationID) { return new KeyValuePair<string, long>("QuotationID", k_QuotationID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Quotation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Quotation item)
        {
            Quotation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Quotation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Quotation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Quotation GetObjectByKey(long k_QuotationID) 
		{
            if (this.Contains(GetKey(k_QuotationID)) == false) return null;
            Quotation ob = this[GetKey(k_QuotationID)];
            return (Quotation)ob;
        }

		public Quotation GetObjectByKey(long k_QuotationID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_QuotationID)) == false) {
				Quotation ob = repository.GetQuery<Quotation>().FirstOrDefault(o => o.QuotationID == k_QuotationID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Quotation obj = this[GetKey(k_QuotationID)];
            return (Quotation)obj;
        }

		public Quotation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Quotation ob = this[keypair];
            return (Quotation)ob;
        }

        public Quotation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Quotation ob = this[GetKey(keypair)];
            return (Quotation)ob;
        }

		bool _LoadAll = false;
        public List<Quotation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Quotation>().ToList();
			foreach (Quotation item in list) {
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

        ~KeyedQuotation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
