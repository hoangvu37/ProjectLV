/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ICDChapter.cs         
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
	public partial class ICDChapter : BaseEntity, ICloneable	{
		public ICDChapter()
		{
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, byte> Key { get { return new KeyValuePair<string, byte>("ChapterID", ChapterID); } }


		private byte _ChapterID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public byte ChapterID { get { return _ChapterID; } set {_ChapterID = value; } }

		private string _ChapterNo;
		[LVRequired]
        [LVMaxLength(5)]
        public string ChapterNo { get { return _ChapterNo; } set {_ChapterNo = value; } }

		private string _ChapterCode;
		[LVRequired]
        [LVMaxLength(7)]
        public string ChapterCode { get { return _ChapterCode; } set {_ChapterCode = value; } }

		private string _ChapterName;
		[LVRequired]
        [LVMaxLength(128)]
        public string ChapterName { get { return _ChapterName; } set {_ChapterName = value; } }

		private string _ChapterNameVNese;
		[LVRequired]
        [LVMaxLength(256)]
        public string ChapterNameVNese { get { return _ChapterNameVNese; } set {_ChapterNameVNese = value; } }

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
    public class KeyedICDChapter : KeyedCollection<KeyValuePair<string, byte>, ICDChapter>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedICDChapter() : base() { }

        protected override KeyValuePair<string, byte> GetKeyForItem(ICDChapter item)
        {
            return item.Key;
        }

        public KeyValuePair<string, byte> GetKey(byte k_ChapterID) { return new KeyValuePair<string, byte>("ChapterID", k_ChapterID); }

        public KeyValuePair<string, byte> GetKey(object keypair) { try { return (KeyValuePair<string, byte>)keypair; } catch { return new KeyValuePair<string, byte>(); } }
        #endregion

        #region Method
        public bool AddObject(ICDChapter item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, byte> keypair, ICDChapter item)
        {
            ICDChapter orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ICDChapter item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ICDChapter item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ICDChapter GetObjectByKey(byte k_ChapterID) 
		{
            if (this.Contains(GetKey(k_ChapterID)) == false) return null;
            ICDChapter ob = this[GetKey(k_ChapterID)];
            return (ICDChapter)ob;
        }

		public ICDChapter GetObjectByKey(byte k_ChapterID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ChapterID)) == false) {
				ICDChapter ob = repository.GetQuery<ICDChapter>().FirstOrDefault(o => o.ChapterID == k_ChapterID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ICDChapter obj = this[GetKey(k_ChapterID)];
            return (ICDChapter)obj;
        }

		public ICDChapter GetObjectByKey(KeyValuePair<string, byte> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ICDChapter ob = this[keypair];
            return (ICDChapter)ob;
        }

        public ICDChapter GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ICDChapter ob = this[GetKey(keypair)];
            return (ICDChapter)ob;
        }

		bool _LoadAll = false;
        public List<ICDChapter> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ICDChapter>().ToList();
			foreach (ICDChapter item in list) {
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

        ~KeyedICDChapter()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
