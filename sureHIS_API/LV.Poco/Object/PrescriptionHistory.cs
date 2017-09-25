/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PrescriptionHistory.cs         
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
	public partial class PrescriptionHistory : BaseEntity, ICloneable	{
		public PrescriptionHistory()
		{
			this.KeepTrackID = 0;
			this.PresID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("KeepTrackID", KeepTrackID); } }


		private long _KeepTrackID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long KeepTrackID { get { return _KeepTrackID; } set {_KeepTrackID = value; } }

		private long _PresID;
		[LVRequired]
        public long PresID { get { return _PresID; } set {_PresID = value; } }

		private DateTime _KeepTrackDateTime;
		[LVRequired]
        public DateTime KeepTrackDateTime { get { return _KeepTrackDateTime; } set {_KeepTrackDateTime = value; } }

		private string _AuthorID;
        [LVMaxLength(20)]
        public string AuthorID { get { return _AuthorID; } set {_AuthorID = value; } }

		private string _CreatorID;
        [LVMaxLength(20)]
        public string CreatorID { get { return _CreatorID; } set {_CreatorID = value; } }

		private string _IssuerID;
        [LVMaxLength(20)]
        public string IssuerID { get { return _IssuerID; } set {_IssuerID = value; } }

		private string _ChangeNotes;
        [LVMaxLength(1024)]
        public string ChangeNotes { get { return _ChangeNotes; } set {_ChangeNotes = value; } }

		/// <summary>
/// Ref Key: FK_PrescriptionHistory_Prescription
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
    public class KeyedPrescriptionHistory : KeyedCollection<KeyValuePair<string, long>, PrescriptionHistory>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPrescriptionHistory() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PrescriptionHistory item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_KeepTrackID) { return new KeyValuePair<string, long>("KeepTrackID", k_KeepTrackID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PrescriptionHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PrescriptionHistory item)
        {
            PrescriptionHistory orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PrescriptionHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PrescriptionHistory item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PrescriptionHistory GetObjectByKey(long k_KeepTrackID) 
		{
            if (this.Contains(GetKey(k_KeepTrackID)) == false) return null;
            PrescriptionHistory ob = this[GetKey(k_KeepTrackID)];
            return (PrescriptionHistory)ob;
        }

		public PrescriptionHistory GetObjectByKey(long k_KeepTrackID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_KeepTrackID)) == false) {
				PrescriptionHistory ob = repository.GetQuery<PrescriptionHistory>().FirstOrDefault(o => o.KeepTrackID == k_KeepTrackID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PrescriptionHistory obj = this[GetKey(k_KeepTrackID)];
            return (PrescriptionHistory)obj;
        }

		public PrescriptionHistory GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PrescriptionHistory ob = this[keypair];
            return (PrescriptionHistory)ob;
        }

        public PrescriptionHistory GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PrescriptionHistory ob = this[GetKey(keypair)];
            return (PrescriptionHistory)ob;
        }

		bool _LoadAll = false;
        public List<PrescriptionHistory> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PrescriptionHistory>().ToList();
			foreach (PrescriptionHistory item in list) {
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

        ~KeyedPrescriptionHistory()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
