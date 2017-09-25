/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : LanguageLevel.cs         
 * Created by           : Auto - 09/11/2017 15:20:02                     
 * Last modify          : Auto - 09/11/2017 15:20:02                     
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
	public partial class LanguageLevel : BaseEntity, ICloneable	{
		public LanguageLevel()
		{
			this.LangLevelID = 0;
			this.HLID = 0;
			this.PersonID = 0;
            this.IsNativeLang = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("LangLevelID", LangLevelID); } }


		private long _LangLevelID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long LangLevelID { get { return _LangLevelID; } set {_LangLevelID = value; } }

		private long _HLID;
		[LVRequired]
        public long HLID { get { return _HLID; } set {_HLID = value; } }

		private long _PersonID;
		[LVRequired]
        public long PersonID { get { return _PersonID; } set {_PersonID = value; } }

		private bool? _IsNativeLang;
        public bool? IsNativeLang { get { return _IsNativeLang; } set {_IsNativeLang = value; } }

		/// <summary>
/// Ref Key: FK_LanguageLevel_Person
/// <summary>
/// <summary>
/// Ref Key: FK_LanguageLevel_refHumanLanguage
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
    public class KeyedLanguageLevel : KeyedCollection<KeyValuePair<string, long>, LanguageLevel>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedLanguageLevel() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(LanguageLevel item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_LangLevelID) { return new KeyValuePair<string, long>("LangLevelID", k_LangLevelID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(LanguageLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, LanguageLevel item)
        {
            LanguageLevel orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(LanguageLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(LanguageLevel item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public LanguageLevel GetObjectByKey(long k_LangLevelID) 
		{
            if (this.Contains(GetKey(k_LangLevelID)) == false) return null;
            LanguageLevel ob = this[GetKey(k_LangLevelID)];
            return (LanguageLevel)ob;
        }

		public LanguageLevel GetObjectByKey(long k_LangLevelID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_LangLevelID)) == false) {
				LanguageLevel ob = repository.GetQuery<LanguageLevel>().FirstOrDefault(o => o.LangLevelID == k_LangLevelID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            LanguageLevel obj = this[GetKey(k_LangLevelID)];
            return (LanguageLevel)obj;
        }

		public LanguageLevel GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            LanguageLevel ob = this[keypair];
            return (LanguageLevel)ob;
        }

        public LanguageLevel GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            LanguageLevel ob = this[GetKey(keypair)];
            return (LanguageLevel)ob;
        }

		bool _LoadAll = false;
        public List<LanguageLevel> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<LanguageLevel>().ToList();
			foreach (LanguageLevel item in list) {
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

        ~KeyedLanguageLevel()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
