/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : OccCareerMOH.cs         
 * Created by           : Auto - 09/11/2017 15:20:03                     
 * Last modify          : Auto - 09/11/2017 15:20:03                     
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
	public partial class OccCareerMOH : BaseEntity, ICloneable	{
		public OccCareerMOH()
		{
			this.OccCareerMOHID = 0;
			this.OccupationID = 0;
			this.CareerMOHID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("OccCareerMOHID", OccCareerMOHID); } }


		private long _OccCareerMOHID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long OccCareerMOHID { get { return _OccCareerMOHID; } set {_OccCareerMOHID = value; } }

		private long _OccupationID;
		[LVRequired]
        public long OccupationID { get { return _OccupationID; } set {_OccupationID = value; } }

		private long _CareerMOHID;
		[LVRequired]
        public long CareerMOHID { get { return _CareerMOHID; } set {_CareerMOHID = value; } }

		/// <summary>
/// Ref Key: FK_OccCareerMOH_refCareerMOH
/// <summary>
/// <summary>
/// Ref Key: FK_OccCareerMOH_refOccupation
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
    public class KeyedOccCareerMOH : KeyedCollection<KeyValuePair<string, long>, OccCareerMOH>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedOccCareerMOH() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(OccCareerMOH item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_OccCareerMOHID) { return new KeyValuePair<string, long>("OccCareerMOHID", k_OccCareerMOHID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(OccCareerMOH item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, OccCareerMOH item)
        {
            OccCareerMOH orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(OccCareerMOH item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(OccCareerMOH item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public OccCareerMOH GetObjectByKey(long k_OccCareerMOHID) 
		{
            if (this.Contains(GetKey(k_OccCareerMOHID)) == false) return null;
            OccCareerMOH ob = this[GetKey(k_OccCareerMOHID)];
            return (OccCareerMOH)ob;
        }

		public OccCareerMOH GetObjectByKey(long k_OccCareerMOHID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_OccCareerMOHID)) == false) {
				OccCareerMOH ob = repository.GetQuery<OccCareerMOH>().FirstOrDefault(o => o.OccCareerMOHID == k_OccCareerMOHID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            OccCareerMOH obj = this[GetKey(k_OccCareerMOHID)];
            return (OccCareerMOH)obj;
        }

		public OccCareerMOH GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            OccCareerMOH ob = this[keypair];
            return (OccCareerMOH)ob;
        }

        public OccCareerMOH GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            OccCareerMOH ob = this[GetKey(keypair)];
            return (OccCareerMOH)ob;
        }

		bool _LoadAll = false;
        public List<OccCareerMOH> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<OccCareerMOH>().ToList();
			foreach (OccCareerMOH item in list) {
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

        ~KeyedOccCareerMOH()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
