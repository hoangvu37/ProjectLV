/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refHumanLanguage.cs         
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
	public partial class refHumanLanguage : BaseEntity, ICloneable	{
		public refHumanLanguage()
		{
			this.HLID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HLID", HLID); } }


		private long _HLID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HLID { get { return _HLID; } set {_HLID = value; } }

		private string _HLCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string HLCode { get { return _HLCode; } set {_HLCode = value; } }

		private string _HLName;
		[LVRequired]
        [LVMaxLength(64)]
        public string HLName { get { return _HLName; } set {_HLName = value; } }

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
    public class KeyedrefHumanLanguage : KeyedCollection<KeyValuePair<string, long>, refHumanLanguage>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefHumanLanguage() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refHumanLanguage item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HLID) { return new KeyValuePair<string, long>("HLID", k_HLID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refHumanLanguage item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refHumanLanguage item)
        {
            refHumanLanguage orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refHumanLanguage item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refHumanLanguage item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refHumanLanguage GetObjectByKey(long k_HLID) 
		{
            if (this.Contains(GetKey(k_HLID)) == false) return null;
            refHumanLanguage ob = this[GetKey(k_HLID)];
            return (refHumanLanguage)ob;
        }

		public refHumanLanguage GetObjectByKey(long k_HLID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HLID)) == false) {
				refHumanLanguage ob = repository.GetQuery<refHumanLanguage>().FirstOrDefault(o => o.HLID == k_HLID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refHumanLanguage obj = this[GetKey(k_HLID)];
            return (refHumanLanguage)obj;
        }

		public refHumanLanguage GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refHumanLanguage ob = this[keypair];
            return (refHumanLanguage)ob;
        }

        public refHumanLanguage GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refHumanLanguage ob = this[GetKey(keypair)];
            return (refHumanLanguage)ob;
        }

		bool _LoadAll = false;
        public List<refHumanLanguage> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refHumanLanguage>().ToList();
			foreach (refHumanLanguage item in list) {
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

        ~KeyedrefHumanLanguage()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
