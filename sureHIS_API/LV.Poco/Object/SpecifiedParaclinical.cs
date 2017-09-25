/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : SpecifiedParaclinical.cs         
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
	public partial class SpecifiedParaclinical : BaseEntity, ICloneable	{
		public SpecifiedParaclinical()
		{
			this.SpecParClinID = 0;
			this.ParClinExamGroupID = 0;
			this.ICDID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SpecParClinID", SpecParClinID); } }


		private long _SpecParClinID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SpecParClinID { get { return _SpecParClinID; } set {_SpecParClinID = value; } }

		private long _ParClinExamGroupID;
		[LVRequired]
        public long ParClinExamGroupID { get { return _ParClinExamGroupID; } set {_ParClinExamGroupID = value; } }

		private long _ICDID;
		[LVRequired]
        public long ICDID { get { return _ICDID; } set {_ICDID = value; } }

		/// <summary>
/// Ref Key: FK_SpecifiedParaclinical_ICD10
/// <summary>
/// <summary>
/// Ref Key: FK_SpecifiedParaclinical_ParaClinicalExamGroup
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
    public class KeyedSpecifiedParaclinical : KeyedCollection<KeyValuePair<string, long>, SpecifiedParaclinical>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedSpecifiedParaclinical() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(SpecifiedParaclinical item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SpecParClinID) { return new KeyValuePair<string, long>("SpecParClinID", k_SpecParClinID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(SpecifiedParaclinical item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, SpecifiedParaclinical item)
        {
            SpecifiedParaclinical orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(SpecifiedParaclinical item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(SpecifiedParaclinical item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public SpecifiedParaclinical GetObjectByKey(long k_SpecParClinID) 
		{
            if (this.Contains(GetKey(k_SpecParClinID)) == false) return null;
            SpecifiedParaclinical ob = this[GetKey(k_SpecParClinID)];
            return (SpecifiedParaclinical)ob;
        }

		public SpecifiedParaclinical GetObjectByKey(long k_SpecParClinID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SpecParClinID)) == false) {
				SpecifiedParaclinical ob = repository.GetQuery<SpecifiedParaclinical>().FirstOrDefault(o => o.SpecParClinID == k_SpecParClinID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            SpecifiedParaclinical obj = this[GetKey(k_SpecParClinID)];
            return (SpecifiedParaclinical)obj;
        }

		public SpecifiedParaclinical GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            SpecifiedParaclinical ob = this[keypair];
            return (SpecifiedParaclinical)ob;
        }

        public SpecifiedParaclinical GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            SpecifiedParaclinical ob = this[GetKey(keypair)];
            return (SpecifiedParaclinical)ob;
        }

		bool _LoadAll = false;
        public List<SpecifiedParaclinical> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<SpecifiedParaclinical>().ToList();
			foreach (SpecifiedParaclinical item in list) {
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

        ~KeyedSpecifiedParaclinical()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
