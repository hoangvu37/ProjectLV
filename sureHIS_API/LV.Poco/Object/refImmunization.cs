/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refImmunization.cs         
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
	public partial class refImmunization : BaseEntity, ICloneable	{
		public refImmunization()
		{
			this.ImmID = 0;
            this.IsOther = false;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("ImmID", ImmID); } }


		private long _ImmID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long ImmID { get { return _ImmID; } set {_ImmID = value; } }

		private string _ImmText;
		[LVRequired]
        [LVMaxLength(50)]
        public string ImmText { get { return _ImmText; } set {_ImmText = value; } }

		private bool _IsOther;
        public bool IsOther { get { return _IsOther; } set {_IsOther = value; } }

		/// <summary>
/// Ref Key: FK_ImmunizationHistory_refImmunization
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
    public class KeyedrefImmunization : KeyedCollection<KeyValuePair<string, long>, refImmunization>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefImmunization() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refImmunization item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_ImmID) { return new KeyValuePair<string, long>("ImmID", k_ImmID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refImmunization item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refImmunization item)
        {
            refImmunization orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refImmunization item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refImmunization item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refImmunization GetObjectByKey(long k_ImmID) 
		{
            if (this.Contains(GetKey(k_ImmID)) == false) return null;
            refImmunization ob = this[GetKey(k_ImmID)];
            return (refImmunization)ob;
        }

		public refImmunization GetObjectByKey(long k_ImmID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_ImmID)) == false) {
				refImmunization ob = repository.GetQuery<refImmunization>().FirstOrDefault(o => o.ImmID == k_ImmID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refImmunization obj = this[GetKey(k_ImmID)];
            return (refImmunization)obj;
        }

		public refImmunization GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refImmunization ob = this[keypair];
            return (refImmunization)ob;
        }

        public refImmunization GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refImmunization ob = this[GetKey(keypair)];
            return (refImmunization)ob;
        }

		bool _LoadAll = false;
        public List<refImmunization> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refImmunization>().ToList();
			foreach (refImmunization item in list) {
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

        ~KeyedrefImmunization()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
