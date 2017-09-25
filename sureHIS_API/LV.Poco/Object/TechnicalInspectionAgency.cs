/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : TechnicalInspectionAgency.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class TechnicalInspectionAgency : BaseEntity, ICloneable	{
		public TechnicalInspectionAgency()
		{
			this.TIANo = 0;
            this.TecInspAgencyEmail = null;
            this.TecInspAgencyPhone = null;
            this.TecInspAgencyFax = null;
            this.TecInspAgencyNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("TIANo", TIANo); } }


		private long _TIANo;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long TIANo { get { return _TIANo; } set {_TIANo = value; } }

		private string _TecInspAgencyName;
		[LVRequired]
        [LVMaxLength(64)]
        public string TecInspAgencyName { get { return _TecInspAgencyName; } set {_TecInspAgencyName = value; } }

		private string _TecInspAgencyAddress;
		[LVRequired]
        [LVMaxLength(256)]
        public string TecInspAgencyAddress { get { return _TecInspAgencyAddress; } set {_TecInspAgencyAddress = value; } }

		private string _TecInspAgencyEmail;
        [LVMaxLength(128)]
        public string TecInspAgencyEmail { get { return _TecInspAgencyEmail; } set {_TecInspAgencyEmail = value; } }

		private string _TecInspAgencyPhone;
        [LVMaxLength(20)]
        public string TecInspAgencyPhone { get { return _TecInspAgencyPhone; } set {_TecInspAgencyPhone = value; } }

		private string _TecInspAgencyFax;
        [LVMaxLength(20)]
        public string TecInspAgencyFax { get { return _TecInspAgencyFax; } set {_TecInspAgencyFax = value; } }

		private string _TecInspAgencyWebSite;
		[LVRequired]
        [LVMaxLength(128)]
        public string TecInspAgencyWebSite { get { return _TecInspAgencyWebSite; } set {_TecInspAgencyWebSite = value; } }

		private string _TecInspAgencyNotes;
        [LVMaxLength(512)]
        public string TecInspAgencyNotes { get { return _TecInspAgencyNotes; } set {_TecInspAgencyNotes = value; } }

		/// <summary>
/// Ref Key: FK_ExamMaintenanceHistory_TechnicalInspectionAgency
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
    public class KeyedTechnicalInspectionAgency : KeyedCollection<KeyValuePair<string, long>, TechnicalInspectionAgency>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedTechnicalInspectionAgency() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(TechnicalInspectionAgency item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_TIANo) { return new KeyValuePair<string, long>("TIANo", k_TIANo); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(TechnicalInspectionAgency item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, TechnicalInspectionAgency item)
        {
            TechnicalInspectionAgency orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(TechnicalInspectionAgency item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(TechnicalInspectionAgency item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public TechnicalInspectionAgency GetObjectByKey(long k_TIANo) 
		{
            if (this.Contains(GetKey(k_TIANo)) == false) return null;
            TechnicalInspectionAgency ob = this[GetKey(k_TIANo)];
            return (TechnicalInspectionAgency)ob;
        }

		public TechnicalInspectionAgency GetObjectByKey(long k_TIANo, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_TIANo)) == false) {
				TechnicalInspectionAgency ob = repository.GetQuery<TechnicalInspectionAgency>().FirstOrDefault(o => o.TIANo == k_TIANo);
				if(ob != null) this.Add(ob);
				return ob;
			}
            TechnicalInspectionAgency obj = this[GetKey(k_TIANo)];
            return (TechnicalInspectionAgency)obj;
        }

		public TechnicalInspectionAgency GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            TechnicalInspectionAgency ob = this[keypair];
            return (TechnicalInspectionAgency)ob;
        }

        public TechnicalInspectionAgency GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            TechnicalInspectionAgency ob = this[GetKey(keypair)];
            return (TechnicalInspectionAgency)ob;
        }

		bool _LoadAll = false;
        public List<TechnicalInspectionAgency> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<TechnicalInspectionAgency>().ToList();
			foreach (TechnicalInspectionAgency item in list) {
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

        ~KeyedTechnicalInspectionAgency()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
