/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refSocialHisSeverity.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class refSocialHisSeverity : BaseEntity, ICloneable	{
		public refSocialHisSeverity()
		{
			this.SHSeverityID = 0;
			this.MHIndexID = 0;
			this.V_SHSeverity = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SHSeverityID", SHSeverityID); } }


		private long _SHSeverityID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SHSeverityID { get { return _SHSeverityID; } set {_SHSeverityID = value; } }

		private long _MHIndexID;
		[LVRequired]
        public long MHIndexID { get { return _MHIndexID; } set {_MHIndexID = value; } }

		private long _V_SHSeverity;
		[LVRequired]
        public long V_SHSeverity { get { return _V_SHSeverity; } set {_V_SHSeverity = value; } }

		/// <summary>
/// Ref Key: FK_refSocialHisSeverity_refMedHisIndex
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
    public class KeyedrefSocialHisSeverity : KeyedCollection<KeyValuePair<string, long>, refSocialHisSeverity>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefSocialHisSeverity() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refSocialHisSeverity item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SHSeverityID) { return new KeyValuePair<string, long>("SHSeverityID", k_SHSeverityID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refSocialHisSeverity item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refSocialHisSeverity item)
        {
            refSocialHisSeverity orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refSocialHisSeverity item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refSocialHisSeverity item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refSocialHisSeverity GetObjectByKey(long k_SHSeverityID) 
		{
            if (this.Contains(GetKey(k_SHSeverityID)) == false) return null;
            refSocialHisSeverity ob = this[GetKey(k_SHSeverityID)];
            return (refSocialHisSeverity)ob;
        }

		public refSocialHisSeverity GetObjectByKey(long k_SHSeverityID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SHSeverityID)) == false) {
				refSocialHisSeverity ob = repository.GetQuery<refSocialHisSeverity>().FirstOrDefault(o => o.SHSeverityID == k_SHSeverityID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refSocialHisSeverity obj = this[GetKey(k_SHSeverityID)];
            return (refSocialHisSeverity)obj;
        }

		public refSocialHisSeverity GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refSocialHisSeverity ob = this[keypair];
            return (refSocialHisSeverity)ob;
        }

        public refSocialHisSeverity GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refSocialHisSeverity ob = this[GetKey(keypair)];
            return (refSocialHisSeverity)ob;
        }

		bool _LoadAll = false;
        public List<refSocialHisSeverity> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refSocialHisSeverity>().ToList();
			foreach (refSocialHisSeverity item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<refSocialHisSeverity> LoadIXFK_refSocialHisSeverity_refMedHisIndex(long p_MHIndexID, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<refSocialHisSeverity>().Where(o=> o.MHIndexID == p_MHIndexID).ToList();
			foreach (refSocialHisSeverity item in list) {
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

        ~KeyedrefSocialHisSeverity()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
