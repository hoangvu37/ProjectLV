/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedRecOutline.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class MedRecOutline : BaseEntity, ICloneable	{
		public MedRecOutline()
		{
			this.MRecID = 0;
			this.MDTmpID = 0;
			this.SecID = 0;
			this.Idx = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MRecID", MRecID); } }


		private long _MRecID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MRecID { get { return _MRecID; } set {_MRecID = value; } }

		private long _MDTmpID;
		[LVRequired]
        public long MDTmpID { get { return _MDTmpID; } set {_MDTmpID = value; } }

		private long _SecID;
		[LVRequired]
        public long SecID { get { return _SecID; } set {_SecID = value; } }

		private short _Idx;
		[LVRequired]
        public short Idx { get { return _Idx; } set {_Idx = value; } }

		/// <summary>
/// Ref Key: FK_MedRecOutline_MedRecTmp
/// <summary>
/// <summary>
/// Ref Key: FK_MedRecOutline_MRSection
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
    public class KeyedMedRecOutline : KeyedCollection<KeyValuePair<string, long>, MedRecOutline>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedRecOutline() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedRecOutline item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MRecID) { return new KeyValuePair<string, long>("MRecID", k_MRecID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedRecOutline item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedRecOutline item)
        {
            MedRecOutline orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedRecOutline item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedRecOutline item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedRecOutline GetObjectByKey(long k_MRecID) 
		{
            if (this.Contains(GetKey(k_MRecID)) == false) return null;
            MedRecOutline ob = this[GetKey(k_MRecID)];
            return (MedRecOutline)ob;
        }

		public MedRecOutline GetObjectByKey(long k_MRecID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MRecID)) == false) {
				MedRecOutline ob = repository.GetQuery<MedRecOutline>().FirstOrDefault(o => o.MRecID == k_MRecID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedRecOutline obj = this[GetKey(k_MRecID)];
            return (MedRecOutline)obj;
        }

		public MedRecOutline GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedRecOutline ob = this[keypair];
            return (MedRecOutline)ob;
        }

        public MedRecOutline GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedRecOutline ob = this[GetKey(keypair)];
            return (MedRecOutline)ob;
        }

		bool _LoadAll = false;
        public List<MedRecOutline> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedRecOutline>().ToList();
			foreach (MedRecOutline item in list) {
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

        ~KeyedMedRecOutline()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
