/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refAppConfig.cs         
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
	public partial class refAppConfig : BaseEntity, ICloneable	{
		public refAppConfig()
		{
			this.ConfigItemID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ConfigItemID", ConfigItemID); } }


		private long _ConfigItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ConfigItemID { get { return _ConfigItemID; } set {_ConfigItemID = value; } }

		private string _ConfigItemKey;
		[LVRequired]
        [LVMaxLength(100)]
        public string ConfigItemKey { get { return _ConfigItemKey; } set {_ConfigItemKey = value; } }

		private string _ConfigItemValue;
		[LVRequired]
        [LVMaxLength(100)]
        public string ConfigItemValue { get { return _ConfigItemValue; } set {_ConfigItemValue = value; } }

		private string _ConfigItemNotes;
        [LVMaxLength(512)]
        public string ConfigItemNotes { get { return _ConfigItemNotes; } set {_ConfigItemNotes = value; } }

		

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
    public class KeyedrefAppConfig : KeyedCollection<KeyValuePair<string, long>, refAppConfig>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefAppConfig() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refAppConfig item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ConfigItemID) { return new KeyValuePair<string, long>("ConfigItemID", k_ConfigItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refAppConfig item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refAppConfig item)
        {
            refAppConfig orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refAppConfig item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refAppConfig item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refAppConfig GetObjectByKey(long k_ConfigItemID) 
		{
            if (this.Contains(GetKey(k_ConfigItemID)) == false) return null;
            refAppConfig ob = this[GetKey(k_ConfigItemID)];
            return (refAppConfig)ob;
        }

		public refAppConfig GetObjectByKey(long k_ConfigItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ConfigItemID)) == false) {
				refAppConfig ob = repository.GetQuery<refAppConfig>().FirstOrDefault(o => o.ConfigItemID == k_ConfigItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refAppConfig obj = this[GetKey(k_ConfigItemID)];
            return (refAppConfig)obj;
        }

		public refAppConfig GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refAppConfig ob = this[keypair];
            return (refAppConfig)ob;
        }

        public refAppConfig GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refAppConfig ob = this[GetKey(keypair)];
            return (refAppConfig)ob;
        }

		bool _LoadAll = false;
        public List<refAppConfig> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refAppConfig>().ToList();
			foreach (refAppConfig item in list) {
				if(this.Contains(GetKey(item))) continue;
				this.Add(item);
			}
			_LoadAll = true;
            return list;
        }
		
		public List<refAppConfig> LoadUQ_refAppConfig(string p_ConfigItemKey, LV.Core.DAL.Base.IRepository repository) {
			var list = repository.GetQuery<refAppConfig>().Where(o=> o.ConfigItemKey == p_ConfigItemKey).ToList();
			foreach (refAppConfig item in list) {
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

        ~KeyedrefAppConfig()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
