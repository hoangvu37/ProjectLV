/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DDI.cs         
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
	public partial class DDI : BaseEntity, ICloneable	{
		public DDI()
		{
			this.DDIID = 0;
			this.MajDID = 0;
			this.RefDID = 0;
            this.V_DDILevel = null;
            this.V_DDIVNLevel = null;
            this.Notes = null;
            this.VNNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DDIID", DDIID); } }


		private long _DDIID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DDIID { get { return _DDIID; } set {_DDIID = value; } }

		private long _MajDID;
		[LVRequired]
        public long MajDID { get { return _MajDID; } set {_MajDID = value; } }

		private long _RefDID;
		[LVRequired]
        public long RefDID { get { return _RefDID; } set {_RefDID = value; } }

		private long? _V_DDILevel;
        public long? V_DDILevel { get { return _V_DDILevel; } set {_V_DDILevel = value; } }

		private long? _V_DDIVNLevel;
        public long? V_DDIVNLevel { get { return _V_DDIVNLevel; } set {_V_DDIVNLevel = value; } }

		private string _Notes;
        [LVMaxLength(4000)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private string _VNNotes;
        [LVMaxLength(4000)]
        public string VNNotes { get { return _VNNotes; } set {_VNNotes = value; } }

		/// <summary>
/// Ref Key: FK_DDI_Drug
/// <summary>
/// <summary>
/// Ref Key: FK_DDI_Drug_02
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
    public class KeyedDDI : KeyedCollection<KeyValuePair<string, long>, DDI>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDDI() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DDI item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DDIID) { return new KeyValuePair<string, long>("DDIID", k_DDIID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DDI item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DDI item)
        {
            DDI orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DDI item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DDI item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DDI GetObjectByKey(long k_DDIID) 
		{
            if (this.Contains(GetKey(k_DDIID)) == false) return null;
            DDI ob = this[GetKey(k_DDIID)];
            return (DDI)ob;
        }

		public DDI GetObjectByKey(long k_DDIID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DDIID)) == false) {
				DDI ob = repository.GetQuery<DDI>().FirstOrDefault(o => o.DDIID == k_DDIID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DDI obj = this[GetKey(k_DDIID)];
            return (DDI)obj;
        }

		public DDI GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DDI ob = this[keypair];
            return (DDI)ob;
        }

        public DDI GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DDI ob = this[GetKey(keypair)];
            return (DDI)ob;
        }

		bool _LoadAll = false;
        public List<DDI> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DDI>().ToList();
			foreach (DDI item in list) {
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

        ~KeyedDDI()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
