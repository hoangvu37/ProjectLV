/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AttachedDoc.cs         
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
	public partial class AttachedDoc : BaseEntity, ICloneable	{
		public AttachedDoc()
		{
			this.AttDocID = 0;
			this.DocItemID = 0;
			this.AdmID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AttDocID", AttDocID); } }


		private long _AttDocID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AttDocID { get { return _AttDocID; } set {_AttDocID = value; } }

		private long? _DocItemID;
        public long? DocItemID { get { return _DocItemID; } set {_DocItemID = value; } }

		private long? _AdmID;
        public long? AdmID { get { return _AdmID; } set {_AdmID = value; } }

		/// <summary>
/// Ref Key: FK_AttachedDoc_DocItem
/// <summary>
/// <summary>
/// Ref Key: FK_AttachedDoc_PatientAdmission
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
    public class KeyedAttachedDoc : KeyedCollection<KeyValuePair<string, long>, AttachedDoc>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAttachedDoc() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AttachedDoc item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AttDocID) { return new KeyValuePair<string, long>("AttDocID", k_AttDocID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AttachedDoc item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AttachedDoc item)
        {
            AttachedDoc orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AttachedDoc item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AttachedDoc item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AttachedDoc GetObjectByKey(long k_AttDocID) 
		{
            if (this.Contains(GetKey(k_AttDocID)) == false) return null;
            AttachedDoc ob = this[GetKey(k_AttDocID)];
            return (AttachedDoc)ob;
        }

		public AttachedDoc GetObjectByKey(long k_AttDocID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AttDocID)) == false) {
				AttachedDoc ob = repository.GetQuery<AttachedDoc>().FirstOrDefault(o => o.AttDocID == k_AttDocID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AttachedDoc obj = this[GetKey(k_AttDocID)];
            return (AttachedDoc)obj;
        }

		public AttachedDoc GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AttachedDoc ob = this[keypair];
            return (AttachedDoc)ob;
        }

        public AttachedDoc GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AttachedDoc ob = this[GetKey(keypair)];
            return (AttachedDoc)ob;
        }

		bool _LoadAll = false;
        public List<AttachedDoc> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AttachedDoc>().ToList();
			foreach (AttachedDoc item in list) {
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

        ~KeyedAttachedDoc()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
