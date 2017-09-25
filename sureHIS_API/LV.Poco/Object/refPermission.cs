/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refPermission.cs         
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
	public partial class refPermission : BaseEntity, ICloneable	{
		public refPermission()
		{
			this.PermItemID = 0;
            this.IsNotEffect = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PermItemID", PermItemID); } }


		private long _PermItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PermItemID { get { return _PermItemID; } set {_PermItemID = value; } }

		private string _PermName;
		[LVRequired]
        [LVMaxLength(128)]
        public string PermName { get { return _PermName; } set {_PermName = value; } }

		private string _Desc;
        [LVMaxLength(2048)]
        public string Desc { get { return _Desc; } set {_Desc = value; } }

		private byte _PermVal;
		[LVRequired]
        public byte PermVal { get { return _PermVal; } set {_PermVal = value; } }

		private bool? _IsNotEffect;
        public bool? IsNotEffect { get { return _IsNotEffect; } set {_IsNotEffect = value; } }

		private byte? _Ordinal;
        public byte? Ordinal { get { return _Ordinal; } set {_Ordinal = value; } }

		/// <summary>
/// Ref Key: FK_ASPNetRolePermission_refPermission
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
    public class KeyedrefPermission : KeyedCollection<KeyValuePair<string, long>, refPermission>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefPermission() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refPermission item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PermItemID) { return new KeyValuePair<string, long>("PermItemID", k_PermItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refPermission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refPermission item)
        {
            refPermission orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refPermission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refPermission item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refPermission GetObjectByKey(long k_PermItemID) 
		{
            if (this.Contains(GetKey(k_PermItemID)) == false) return null;
            refPermission ob = this[GetKey(k_PermItemID)];
            return (refPermission)ob;
        }

		public refPermission GetObjectByKey(long k_PermItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PermItemID)) == false) {
				refPermission ob = repository.GetQuery<refPermission>().FirstOrDefault(o => o.PermItemID == k_PermItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refPermission obj = this[GetKey(k_PermItemID)];
            return (refPermission)obj;
        }

		public refPermission GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refPermission ob = this[keypair];
            return (refPermission)ob;
        }

        public refPermission GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refPermission ob = this[GetKey(keypair)];
            return (refPermission)ob;
        }

		bool _LoadAll = false;
        public List<refPermission> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refPermission>().ToList();
			foreach (refPermission item in list) {
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

        ~KeyedrefPermission()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
