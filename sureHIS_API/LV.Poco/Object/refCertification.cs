/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refCertification.cs         
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
	public partial class refCertification : BaseEntity, ICloneable	{
		public refCertification()
		{
			this.CertificateID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("CertificateID", CertificateID); } }


		private long _CertificateID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long CertificateID { get { return _CertificateID; } set {_CertificateID = value; } }

		private string _CertificateCode;
		[LVRequired]
        [LVMaxLength(6)]
        public string CertificateCode { get { return _CertificateCode; } set {_CertificateCode = value; } }

		private string _CertificateName;
		[LVRequired]
        [LVMaxLength(40)]
        public string CertificateName { get { return _CertificateName; } set {_CertificateName = value; } }

		private string _VNCertificateName;
        [LVMaxLength(64)]
        public string VNCertificateName { get { return _VNCertificateName; } set {_VNCertificateName = value; } }

		/// <summary>
/// Ref Key: FK_EduLevel_refCertification_
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
    public class KeyedrefCertification : KeyedCollection<KeyValuePair<string, long>, refCertification>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefCertification() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refCertification item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_CertificateID) { return new KeyValuePair<string, long>("CertificateID", k_CertificateID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refCertification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refCertification item)
        {
            refCertification orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refCertification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refCertification item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refCertification GetObjectByKey(long k_CertificateID) 
		{
            if (this.Contains(GetKey(k_CertificateID)) == false) return null;
            refCertification ob = this[GetKey(k_CertificateID)];
            return (refCertification)ob;
        }

		public refCertification GetObjectByKey(long k_CertificateID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_CertificateID)) == false) {
				refCertification ob = repository.GetQuery<refCertification>().FirstOrDefault(o => o.CertificateID == k_CertificateID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refCertification obj = this[GetKey(k_CertificateID)];
            return (refCertification)obj;
        }

		public refCertification GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refCertification ob = this[keypair];
            return (refCertification)ob;
        }

        public refCertification GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refCertification ob = this[GetKey(keypair)];
            return (refCertification)ob;
        }

		bool _LoadAll = false;
        public List<refCertification> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refCertification>().ToList();
			foreach (refCertification item in list) {
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

        ~KeyedrefCertification()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
