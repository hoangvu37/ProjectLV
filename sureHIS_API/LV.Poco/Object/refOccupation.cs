/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refOccupation.cs         
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
	public partial class refOccupation : BaseEntity, ICloneable	{
		public refOccupation()
		{
			this.OccupationID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("OccupationID", OccupationID); } }


		private long _OccupationID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long OccupationID { get { return _OccupationID; } set {_OccupationID = value; } }

		private string _OccupationCode;
		[LVRequired]
        [LVMaxLength(7)]
        public string OccupationCode { get { return _OccupationCode; } set {_OccupationCode = value; } }

		private string _OccupationTitle;
		[LVRequired]
        [LVMaxLength(256)]
        public string OccupationTitle { get { return _OccupationTitle; } set {_OccupationTitle = value; } }

		private string _VNOccupationTitle;
        [LVMaxLength(256)]
        public string VNOccupationTitle { get { return _VNOccupationTitle; } set {_VNOccupationTitle = value; } }

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
    public class KeyedrefOccupation : KeyedCollection<KeyValuePair<string, long>, refOccupation>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefOccupation() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refOccupation item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_OccupationID) { return new KeyValuePair<string, long>("OccupationID", k_OccupationID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refOccupation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refOccupation item)
        {
            refOccupation orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refOccupation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refOccupation item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refOccupation GetObjectByKey(long k_OccupationID) 
		{
            if (this.Contains(GetKey(k_OccupationID)) == false) return null;
            refOccupation ob = this[GetKey(k_OccupationID)];
            return (refOccupation)ob;
        }

		public refOccupation GetObjectByKey(long k_OccupationID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_OccupationID)) == false) {
				refOccupation ob = repository.GetQuery<refOccupation>().FirstOrDefault(o => o.OccupationID == k_OccupationID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refOccupation obj = this[GetKey(k_OccupationID)];
            return (refOccupation)obj;
        }

		public refOccupation GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refOccupation ob = this[keypair];
            return (refOccupation)ob;
        }

        public refOccupation GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refOccupation ob = this[GetKey(keypair)];
            return (refOccupation)ob;
        }

		bool _LoadAll = false;
        public List<refOccupation> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refOccupation>().ToList();
			foreach (refOccupation item in list) {
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

        ~KeyedrefOccupation()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
