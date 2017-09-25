/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MRSectionOutline.cs         
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
	public partial class MRSectionOutline : BaseEntity, ICloneable	{
		public MRSectionOutline()
		{
			this.SecOID = 0;
			this.SecID = 0;
			this.ParID = 0;
			this.Idx = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SecOID", SecOID); } }


		private long _SecOID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SecOID { get { return _SecOID; } set {_SecOID = value; } }

		private long _SecID;
		[LVRequired]
        public long SecID { get { return _SecID; } set {_SecID = value; } }

		private long _ParID;
		[LVRequired]
        public long ParID { get { return _ParID; } set {_ParID = value; } }

		private short _Idx;
		[LVRequired]
        public short Idx { get { return _Idx; } set {_Idx = value; } }

		/// <summary>
/// Ref Key: FK_MRSectionOutline_MRParagraph
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
    public class KeyedMRSectionOutline : KeyedCollection<KeyValuePair<string, long>, MRSectionOutline>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMRSectionOutline() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MRSectionOutline item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SecOID) { return new KeyValuePair<string, long>("SecOID", k_SecOID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MRSectionOutline item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MRSectionOutline item)
        {
            MRSectionOutline orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MRSectionOutline item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MRSectionOutline item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MRSectionOutline GetObjectByKey(long k_SecOID) 
		{
            if (this.Contains(GetKey(k_SecOID)) == false) return null;
            MRSectionOutline ob = this[GetKey(k_SecOID)];
            return (MRSectionOutline)ob;
        }

		public MRSectionOutline GetObjectByKey(long k_SecOID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SecOID)) == false) {
				MRSectionOutline ob = repository.GetQuery<MRSectionOutline>().FirstOrDefault(o => o.SecOID == k_SecOID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MRSectionOutline obj = this[GetKey(k_SecOID)];
            return (MRSectionOutline)obj;
        }

		public MRSectionOutline GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MRSectionOutline ob = this[keypair];
            return (MRSectionOutline)ob;
        }

        public MRSectionOutline GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MRSectionOutline ob = this[GetKey(keypair)];
            return (MRSectionOutline)ob;
        }

		bool _LoadAll = false;
        public List<MRSectionOutline> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MRSectionOutline>().ToList();
			foreach (MRSectionOutline item in list) {
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

        ~KeyedMRSectionOutline()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
