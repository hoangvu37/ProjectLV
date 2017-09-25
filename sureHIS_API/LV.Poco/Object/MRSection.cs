/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MRSection.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class MRSection : BaseEntity, ICloneable	{
		public MRSection()
		{
			this.SecID = 0;
            this.SecDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SecID", SecID); } }


		private long _SecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SecID { get { return _SecID; } set {_SecID = value; } }

		private string _SecCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string SecCode { get { return _SecCode; } set {_SecCode = value; } }

		private string _SecTitle;
		[LVRequired]
        [LVMaxLength(128)]
        public string SecTitle { get { return _SecTitle; } set {_SecTitle = value; } }

		private string _SecDesc;
        [LVMaxLength(256)]
        public string SecDesc { get { return _SecDesc; } set {_SecDesc = value; } }

		/// <summary>
/// Ref Key: FK_MedRecOutline_MRSection
/// <summary>
/// <summary>
/// Ref Key: FK_MRSectionOutline_MRSection
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
    public class KeyedMRSection : KeyedCollection<KeyValuePair<string, long>, MRSection>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMRSection() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MRSection item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SecID) { return new KeyValuePair<string, long>("SecID", k_SecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MRSection item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MRSection item)
        {
            MRSection orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MRSection item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MRSection item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MRSection GetObjectByKey(long k_SecID) 
		{
            if (this.Contains(GetKey(k_SecID)) == false) return null;
            MRSection ob = this[GetKey(k_SecID)];
            return (MRSection)ob;
        }

		public MRSection GetObjectByKey(long k_SecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SecID)) == false) {
				MRSection ob = repository.GetQuery<MRSection>().FirstOrDefault(o => o.SecID == k_SecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MRSection obj = this[GetKey(k_SecID)];
            return (MRSection)obj;
        }

		public MRSection GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MRSection ob = this[keypair];
            return (MRSection)ob;
        }

        public MRSection GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MRSection ob = this[GetKey(keypair)];
            return (MRSection)ob;
        }

		bool _LoadAll = false;
        public List<MRSection> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MRSection>().ToList();
			foreach (MRSection item in list) {
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

        ~KeyedMRSection()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
