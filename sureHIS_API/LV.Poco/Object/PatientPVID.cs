/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PatientPVID.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class PatientPVID : BaseEntity, ICloneable	{
		public PatientPVID()
		{
			this.PtPVIDItemID = 0;
			this.PtID = 0;
            this.Issueddate = DateTime.Now;
            this.IsActivated = true;
			this.PrivClssID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtPVIDItemID", PtPVIDItemID); } }


		private long _PtPVIDItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtPVIDItemID { get { return _PtPVIDItemID; } set {_PtPVIDItemID = value; } }

		private long _PtID;
		[LVRequired]
        public long PtID { get { return _PtID; } set {_PtID = value; } }

		private string _PrivClssCode;
		[LVRequired]
        [LVMaxLength(7)]
        public string PrivClssCode { get { return _PrivClssCode; } set {_PrivClssCode = value; } }

		private string _PrivClssDesc;
		[LVRequired]
        public string PrivClssDesc { get { return _PrivClssDesc; } set {_PrivClssDesc = value; } }

		private DateTime _Issueddate;
		[LVRequired]
        public DateTime Issueddate { get { return _Issueddate; } set {_Issueddate = value; } }

		private bool? _IsActivated;
        public bool? IsActivated { get { return _IsActivated; } set {_IsActivated = value; } }

		private long? _PrivClssID;
        public long? PrivClssID { get { return _PrivClssID; } set {_PrivClssID = value; } }

		/// <summary>
/// Ref Key: FK_PatientPVID_Patient
/// <summary>
/// <summary>
/// Ref Key: FK_PatientPVID_PrivacyClass
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
    public class KeyedPatientPVID : KeyedCollection<KeyValuePair<string, long>, PatientPVID>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPatientPVID() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PatientPVID item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtPVIDItemID) { return new KeyValuePair<string, long>("PtPVIDItemID", k_PtPVIDItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PatientPVID item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PatientPVID item)
        {
            PatientPVID orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PatientPVID item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PatientPVID item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PatientPVID GetObjectByKey(long k_PtPVIDItemID) 
		{
            if (this.Contains(GetKey(k_PtPVIDItemID)) == false) return null;
            PatientPVID ob = this[GetKey(k_PtPVIDItemID)];
            return (PatientPVID)ob;
        }

		public PatientPVID GetObjectByKey(long k_PtPVIDItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtPVIDItemID)) == false) {
				PatientPVID ob = repository.GetQuery<PatientPVID>().FirstOrDefault(o => o.PtPVIDItemID == k_PtPVIDItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PatientPVID obj = this[GetKey(k_PtPVIDItemID)];
            return (PatientPVID)obj;
        }

		public PatientPVID GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PatientPVID ob = this[keypair];
            return (PatientPVID)ob;
        }

        public PatientPVID GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PatientPVID ob = this[GetKey(keypair)];
            return (PatientPVID)ob;
        }

		bool _LoadAll = false;
        public List<PatientPVID> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PatientPVID>().ToList();
			foreach (PatientPVID item in list) {
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

        ~KeyedPatientPVID()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
