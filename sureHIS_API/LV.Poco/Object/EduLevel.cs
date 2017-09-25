/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : EduLevel.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class EduLevel : BaseEntity, ICloneable	{
		public EduLevel()
		{
			this.EduLevelID = 0;
			this.PersonID = 0;
            this.InstitudeID = null;
            this.IssuedDate = DateTime.Now;
            this.ExpiredDate = DateTime.Now;
			this.CertificateCode = 0;
            this.CertificateNo = null;
            this.PlaceOfIssue = null;
            this.Issuer = null;
            this.TrainingType = null;
            this.TrainingYear = null;
            this.TrainingDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("EduLevelID", EduLevelID); } }


		private long _EduLevelID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long EduLevelID { get { return _EduLevelID; } set {_EduLevelID = value; } }

		private long _PersonID;
		[LVRequired]
        public long PersonID { get { return _PersonID; } set {_PersonID = value; } }

		private long? _InstitudeID;
        public long? InstitudeID { get { return _InstitudeID; } set {_InstitudeID = value; } }

		private DateTime? _IssuedDate;
        public DateTime? IssuedDate { get { return _IssuedDate; } set {_IssuedDate = value; } }

		private DateTime? _ExpiredDate;
        public DateTime? ExpiredDate { get { return _ExpiredDate; } set {_ExpiredDate = value; } }

		private long? _CertificateCode;
        public long? CertificateCode { get { return _CertificateCode; } set {_CertificateCode = value; } }

		private string _CertificateNo;
        [LVMaxLength(30)]
        public string CertificateNo { get { return _CertificateNo; } set {_CertificateNo = value; } }

		private string _PlaceOfIssue;
        [LVMaxLength(128)]
        public string PlaceOfIssue { get { return _PlaceOfIssue; } set {_PlaceOfIssue = value; } }

		private string _Issuer;
        [LVMaxLength(80)]
        public string Issuer { get { return _Issuer; } set {_Issuer = value; } }

		private string _TrainingType;
        [LVMaxLength(80)]
        public string TrainingType { get { return _TrainingType; } set {_TrainingType = value; } }

		private string _TrainingYear;
        [LVMaxLength(4)]
        public string TrainingYear { get { return _TrainingYear; } set {_TrainingYear = value; } }

		private string _TrainingDesc;
        [LVMaxLength(256)]
        public string TrainingDesc { get { return _TrainingDesc; } set {_TrainingDesc = value; } }

		/// <summary>
/// Ref Key: FK_EduLevel_Person
/// <summary>
/// <summary>
/// Ref Key: FK_EduLevel_refCertification_
/// <summary>
/// <summary>
/// Ref Key: FK_EduLevel_refInstUniversity
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
    public class KeyedEduLevel : KeyedCollection<KeyValuePair<string, long>, EduLevel>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedEduLevel() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(EduLevel item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_EduLevelID) { return new KeyValuePair<string, long>("EduLevelID", k_EduLevelID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(EduLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, EduLevel item)
        {
            EduLevel orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(EduLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(EduLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public EduLevel GetObjectByKey(long k_EduLevelID) 
		{
            if (this.Contains(GetKey(k_EduLevelID)) == false) return null;
            EduLevel ob = this[GetKey(k_EduLevelID)];
            return (EduLevel)ob;
        }

		public EduLevel GetObjectByKey(long k_EduLevelID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_EduLevelID)) == false) {
				EduLevel ob = repository.GetQuery<EduLevel>().FirstOrDefault(o => o.EduLevelID == k_EduLevelID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            EduLevel obj = this[GetKey(k_EduLevelID)];
            return (EduLevel)obj;
        }

		public EduLevel GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            EduLevel ob = this[keypair];
            return (EduLevel)ob;
        }

        public EduLevel GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            EduLevel ob = this[GetKey(keypair)];
            return (EduLevel)ob;
        }

		bool _LoadAll = false;
        public List<EduLevel> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<EduLevel>().ToList();
			foreach (EduLevel item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<EduLevel> LoadIXFK_EduLevel_refCertification (long p_CertificateCode, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<EduLevel>().Where(o=> o.CertificateCode == p_CertificateCode).ToList();
			foreach (EduLevel item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
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

        ~KeyedEduLevel()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
