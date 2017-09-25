/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientAddressHistory.cs         
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
	public partial class PatientAddressHistory : BaseEntity, ICloneable	{
		public PatientAddressHistory()
		{
			this.PtAddHisID = 0;
			this.PtID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>> Key { get { return new KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>>(new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(new KeyValuePair<string, long>("PtAddHisID", PtAddHisID), new KeyValuePair<string, long>("PtID", PtID)), new KeyValuePair<string, DateTime>("ModifiedDate", ModifiedDate)); } }


		private long _PtAddHisID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtAddHisID { get { return _PtAddHisID; } set {_PtAddHisID = value; } }

		private long _PtID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private DateTime _ModifiedDate;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public DateTime ModifiedDate { get { return _ModifiedDate; } set {_ModifiedDate = value; } }

		private string _ProvinceID;
		[LVRequired]
        [LVMaxLength(2)]
        public string ProvinceID { get { return _ProvinceID; } set {_ProvinceID = value; } }

		private string _PAHStreetAddress;
        [LVMaxLength(80)]
        public string PAHStreetAddress { get { return _PAHStreetAddress; } set {_PAHStreetAddress = value; } }

		private string _PAHSurburb;
        [LVMaxLength(80)]
        public string PAHSurburb { get { return _PAHSurburb; } set {_PAHSurburb = value; } }

		private string _PAHPhoneNumber;
        [LVMaxLength(15)]
        public string PAHPhoneNumber { get { return _PAHPhoneNumber; } set {_PAHPhoneNumber = value; } }

		private string _PAHCellPhoneNumber;
        [LVMaxLength(15)]
        public string PAHCellPhoneNumber { get { return _PAHCellPhoneNumber; } set {_PAHCellPhoneNumber = value; } }

		private string _PAHEmailAddress;
        [LVMaxLength(80)]
        public string PAHEmailAddress { get { return _PAHEmailAddress; } set {_PAHEmailAddress = value; } }

		private string _PAHEmployer;
        [LVMaxLength(25)]
        public string PAHEmployer { get { return _PAHEmployer; } set {_PAHEmployer = value; } }

		/// <summary>
/// Ref Key: FK_PatientAddressHistory_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientAddressHistory_Patient_02
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
    public class KeyedPatientAddressHistory : KeyedCollection<KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>>, PatientAddressHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientAddressHistory() : base() { }

        protected override KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>> GetKeyForItem(PatientAddressHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>> GetKey(long k_PtAddHisID, long k_PtID, DateTime k_ModifiedDate) { return new KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>>(new KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>(new KeyValuePair<string, long>("PtAddHisID", k_PtAddHisID), new KeyValuePair<string, long>("PtID", k_PtID)), new KeyValuePair<string, DateTime>("ModifiedDate", k_ModifiedDate)); }

        public KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>> GetKey(object keypair) { try { return (KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>>)keypair; } catch { return new KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientAddressHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>> keypair, PatientAddressHistory item)
        {
            PatientAddressHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientAddressHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientAddressHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientAddressHistory GetObjectByKey(long k_PtAddHisID, long k_PtID, DateTime k_ModifiedDate) 
		{
            if (this.Contains(GetKey(k_PtAddHisID, k_PtID, k_ModifiedDate)) == false) return null;
            PatientAddressHistory ob = this[GetKey(k_PtAddHisID, k_PtID, k_ModifiedDate)];
            return (PatientAddressHistory)ob;
        }

		public PatientAddressHistory GetObjectByKey(long k_PtAddHisID, long k_PtID, DateTime k_ModifiedDate, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtAddHisID, k_PtID, k_ModifiedDate)) == false) {
				PatientAddressHistory ob = repository.GetQuery<PatientAddressHistory>().FirstOrDefault(o => o.PtAddHisID == k_PtAddHisID && o.PtID == k_PtID && o.ModifiedDate == k_ModifiedDate);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientAddressHistory obj = this[GetKey(k_PtAddHisID, k_PtID, k_ModifiedDate)];
            return (PatientAddressHistory)obj;
        }

		public PatientAddressHistory GetObjectByKey(KeyValuePair<KeyValuePair<KeyValuePair<string, long>, KeyValuePair<string, long>>, KeyValuePair<string, DateTime>> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientAddressHistory ob = this[keypair];
            return (PatientAddressHistory)ob;
        }

        public PatientAddressHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientAddressHistory ob = this[GetKey(keypair)];
            return (PatientAddressHistory)ob;
        }

		bool _LoadAll = false;
        public List<PatientAddressHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientAddressHistory>().ToList();
			foreach (PatientAddressHistory item in list) {
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

        ~KeyedPatientAddressHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
