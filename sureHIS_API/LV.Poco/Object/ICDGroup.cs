/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ICDGroup.cs         
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
	public partial class ICDGroup : BaseEntity, ICloneable	{
		public ICDGroup()
		{
			this.GroupID = 0;
            this.SubGroupCodeI = null;
            this.SubGroupNameI = null;
            this.SubGroupnameVNeseI = null;
            this.SubGroupCodeII = null;
            this.SubGroupNameII = null;
            this.SubGroupNameVNeseII = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("GroupID", GroupID); } }


		private byte? _ChapterID;
        public byte? ChapterID { get { return _ChapterID; } set {_ChapterID = value; } }

		private long _GroupID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long GroupID { get { return _GroupID; } set {_GroupID = value; } }

		private string _GroupCode;
		[LVRequired]
        [LVMaxLength(7)]
        public string GroupCode { get { return _GroupCode; } set {_GroupCode = value; } }

		private string _GroupName;
		[LVRequired]
        [LVMaxLength(512)]
        public string GroupName { get { return _GroupName; } set {_GroupName = value; } }

		private string _GroupNameVNese;
		[LVRequired]
        [LVMaxLength(1024)]
        public string GroupNameVNese { get { return _GroupNameVNese; } set {_GroupNameVNese = value; } }

		private string _SubGroupCodeI;
        [LVMaxLength(7)]
        public string SubGroupCodeI { get { return _SubGroupCodeI; } set {_SubGroupCodeI = value; } }

		private string _SubGroupNameI;
        [LVMaxLength(512)]
        public string SubGroupNameI { get { return _SubGroupNameI; } set {_SubGroupNameI = value; } }

		private string _SubGroupnameVNeseI;
        [LVMaxLength(1024)]
        public string SubGroupnameVNeseI { get { return _SubGroupnameVNeseI; } set {_SubGroupnameVNeseI = value; } }

		private string _SubGroupCodeII;
        [LVMaxLength(7)]
        public string SubGroupCodeII { get { return _SubGroupCodeII; } set {_SubGroupCodeII = value; } }

		private string _SubGroupNameII;
        [LVMaxLength(512)]
        public string SubGroupNameII { get { return _SubGroupNameII; } set {_SubGroupNameII = value; } }

		private string _SubGroupNameVNeseII;
        [LVMaxLength(1024)]
        public string SubGroupNameVNeseII { get { return _SubGroupNameVNeseII; } set {_SubGroupNameVNeseII = value; } }

		/// <summary>
/// Ref Key: FK_ICD10_ICDGroup
/// <summary>
/// <summary>
/// Ref Key: FK_ICDGroup_ICDChapter
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
    public class KeyedICDGroup : KeyedCollection<KeyValuePair<string, long>, ICDGroup>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedICDGroup() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ICDGroup item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_GroupID) { return new KeyValuePair<string, long>("GroupID", k_GroupID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ICDGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ICDGroup item)
        {
            ICDGroup orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ICDGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ICDGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ICDGroup GetObjectByKey(long k_GroupID) 
		{
            if (this.Contains(GetKey(k_GroupID)) == false) return null;
            ICDGroup ob = this[GetKey(k_GroupID)];
            return (ICDGroup)ob;
        }

		public ICDGroup GetObjectByKey(long k_GroupID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_GroupID)) == false) {
				ICDGroup ob = repository.GetQuery<ICDGroup>().FirstOrDefault(o => o.GroupID == k_GroupID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ICDGroup obj = this[GetKey(k_GroupID)];
            return (ICDGroup)obj;
        }

		public ICDGroup GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ICDGroup ob = this[keypair];
            return (ICDGroup)ob;
        }

        public ICDGroup GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ICDGroup ob = this[GetKey(keypair)];
            return (ICDGroup)ob;
        }

		bool _LoadAll = false;
        public List<ICDGroup> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ICDGroup>().ToList();
			foreach (ICDGroup item in list) {
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

        ~KeyedICDGroup()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
