/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refFAMRelationship.cs         
 * Created by           : Auto - 09/11/2017 15:20:01                     
 * Last modify          : Auto - 09/11/2017 15:20:01                     
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
	public partial class refFAMRelationship : BaseEntity, ICloneable	{
		public refFAMRelationship()
		{
			this.FAMMbrRelUD = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("FAMMbrRelUD", FAMMbrRelUD); } }


		private long _FAMMbrRelUD;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long FAMMbrRelUD { get { return _FAMMbrRelUD; } set {_FAMMbrRelUD = value; } }

		private string _FAMMbrRelationshipCode;
		[LVRequired]
        [LVMaxLength(16)]
        public string FAMMbrRelationshipCode { get { return _FAMMbrRelationshipCode; } set {_FAMMbrRelationshipCode = value; } }

		private string _FAMMbrRelationshipName;
		[LVRequired]
        [LVMaxLength(64)]
        public string FAMMbrRelationshipName { get { return _FAMMbrRelationshipName; } set {_FAMMbrRelationshipName = value; } }

		private string _VNFAMMbrRelationshipName;
        [LVMaxLength(128)]
        public string VNFAMMbrRelationshipName { get { return _VNFAMMbrRelationshipName; } set {_VNFAMMbrRelationshipName = value; } }

		/// <summary>
/// Ref Key: FK_FamilyHistory_refFAMRelationship
/// <summary>
/// <summary>
/// Ref Key: FK_NextOfKins_refFAMRelationship
/// <summary>
/// <summary>
/// Ref Key: FK_PastPersonHistory_refFAMRelationship
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
    public class KeyedrefFAMRelationship : KeyedCollection<KeyValuePair<string, long>, refFAMRelationship>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefFAMRelationship() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refFAMRelationship item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_FAMMbrRelUD) { return new KeyValuePair<string, long>("FAMMbrRelUD", k_FAMMbrRelUD); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refFAMRelationship item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refFAMRelationship item)
        {
            refFAMRelationship orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refFAMRelationship item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refFAMRelationship item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refFAMRelationship GetObjectByKey(long k_FAMMbrRelUD) 
		{
            if (this.Contains(GetKey(k_FAMMbrRelUD)) == false) return null;
            refFAMRelationship ob = this[GetKey(k_FAMMbrRelUD)];
            return (refFAMRelationship)ob;
        }

		public refFAMRelationship GetObjectByKey(long k_FAMMbrRelUD, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_FAMMbrRelUD)) == false) {
				refFAMRelationship ob = repository.GetQuery<refFAMRelationship>().FirstOrDefault(o => o.FAMMbrRelUD == k_FAMMbrRelUD);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refFAMRelationship obj = this[GetKey(k_FAMMbrRelUD)];
            return (refFAMRelationship)obj;
        }

		public refFAMRelationship GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refFAMRelationship ob = this[keypair];
            return (refFAMRelationship)ob;
        }

        public refFAMRelationship GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refFAMRelationship ob = this[GetKey(keypair)];
            return (refFAMRelationship)ob;
        }

		bool _LoadAll = false;
        public List<refFAMRelationship> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refFAMRelationship>().ToList();
			foreach (refFAMRelationship item in list) {
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

        ~KeyedrefFAMRelationship()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
