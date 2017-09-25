/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DocItem.cs         
 * Created by           : Auto - 09/11/2017 15:19:54                     
 * Last modify          : Auto - 09/11/2017 15:19:54                     
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
	public partial class DocItem : BaseEntity, ICloneable	{
		public DocItem()
		{
			this.DocItemID = 0;
			this.ItemTypeID = 0;
            this.IssuedDate = DateTime.Now;
            this.Note = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DocItemID", DocItemID); } }


		private long _DocItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DocItemID { get { return _DocItemID; } set {_DocItemID = value; } }

		private long? _ItemTypeID;
        public long? ItemTypeID { get { return _ItemTypeID; } set {_ItemTypeID = value; } }

		private string _DocItemTile;
		[LVRequired]
        [LVMaxLength(64)]
        public string DocItemTile { get { return _DocItemTile; } set {_DocItemTile = value; } }

		private string _FilePathLocation;
		[LVRequired]
        [LVMaxLength(512)]
        public string FilePathLocation { get { return _FilePathLocation; } set {_FilePathLocation = value; } }

		private DateTime? _IssuedDate;
        public DateTime? IssuedDate { get { return _IssuedDate; } set {_IssuedDate = value; } }

		private string _Note;
        [LVMaxLength(1024)]
        public string Note { get { return _Note; } set {_Note = value; } }

		/// <summary>
/// Ref Key: FK_AttachedDoc_DocItem
/// <summary>
/// <summary>
/// Ref Key: FK_DocItem_refItemType
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
    public class KeyedDocItem : KeyedCollection<KeyValuePair<string, long>, DocItem>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDocItem() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DocItem item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DocItemID) { return new KeyValuePair<string, long>("DocItemID", k_DocItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DocItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DocItem item)
        {
            DocItem orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DocItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DocItem item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DocItem GetObjectByKey(long k_DocItemID) 
		{
            if (this.Contains(GetKey(k_DocItemID)) == false) return null;
            DocItem ob = this[GetKey(k_DocItemID)];
            return (DocItem)ob;
        }

		public DocItem GetObjectByKey(long k_DocItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DocItemID)) == false) {
				DocItem ob = repository.GetQuery<DocItem>().FirstOrDefault(o => o.DocItemID == k_DocItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DocItem obj = this[GetKey(k_DocItemID)];
            return (DocItem)obj;
        }

		public DocItem GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DocItem ob = this[keypair];
            return (DocItem)ob;
        }

        public DocItem GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DocItem ob = this[GetKey(keypair)];
            return (DocItem)ob;
        }

		bool _LoadAll = false;
        public List<DocItem> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DocItem>().ToList();
			foreach (DocItem item in list) {
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

        ~KeyedDocItem()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
