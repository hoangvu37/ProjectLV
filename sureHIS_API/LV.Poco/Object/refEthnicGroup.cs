/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refEthnicGroup.cs         
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
	public partial class refEthnicGroup : BaseEntity, ICloneable	{
		public refEthnicGroup()
		{
			this.PtEthnicGroupID = 0;
			this.PPtEthnicGroupID = 0;
			this.Level = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PtEthnicGroupID", PtEthnicGroupID); } }


		private long _PtEthnicGroupID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PtEthnicGroupID { get { return _PtEthnicGroupID; } set {_PtEthnicGroupID = value; } }

		private string _PtEthnicGroupCode;
		[LVRequired]
        [LVMaxLength(6)]
        public string PtEthnicGroupCode { get { return _PtEthnicGroupCode; } set {_PtEthnicGroupCode = value; } }

		private string _PtEthnicGroupName;
		[LVRequired]
        [LVMaxLength(128)]
        public string PtEthnicGroupName { get { return _PtEthnicGroupName; } set {_PtEthnicGroupName = value; } }

		private string _VNPtEthnicGroupName;
        [LVMaxLength(128)]
        public string VNPtEthnicGroupName { get { return _VNPtEthnicGroupName; } set {_VNPtEthnicGroupName = value; } }

		private long? _PPtEthnicGroupID;
        public long? PPtEthnicGroupID { get { return _PPtEthnicGroupID; } set {_PPtEthnicGroupID = value; } }

		private short? _Level;
        public short? Level { get { return _Level; } set {_Level = value; } }

		/// <summary>
/// Ref Key: FK_refElthnic_refEthnicGroup
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
    public class KeyedrefEthnicGroup : KeyedCollection<KeyValuePair<string, long>, refEthnicGroup>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefEthnicGroup() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refEthnicGroup item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PtEthnicGroupID) { return new KeyValuePair<string, long>("PtEthnicGroupID", k_PtEthnicGroupID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refEthnicGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refEthnicGroup item)
        {
            refEthnicGroup orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refEthnicGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refEthnicGroup item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refEthnicGroup GetObjectByKey(long k_PtEthnicGroupID) 
		{
            if (this.Contains(GetKey(k_PtEthnicGroupID)) == false) return null;
            refEthnicGroup ob = this[GetKey(k_PtEthnicGroupID)];
            return (refEthnicGroup)ob;
        }

		public refEthnicGroup GetObjectByKey(long k_PtEthnicGroupID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PtEthnicGroupID)) == false) {
				refEthnicGroup ob = repository.GetQuery<refEthnicGroup>().FirstOrDefault(o => o.PtEthnicGroupID == k_PtEthnicGroupID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refEthnicGroup obj = this[GetKey(k_PtEthnicGroupID)];
            return (refEthnicGroup)obj;
        }

		public refEthnicGroup GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refEthnicGroup ob = this[keypair];
            return (refEthnicGroup)ob;
        }

        public refEthnicGroup GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refEthnicGroup ob = this[GetKey(keypair)];
            return (refEthnicGroup)ob;
        }

		bool _LoadAll = false;
        public List<refEthnicGroup> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refEthnicGroup>().ToList();
			foreach (refEthnicGroup item in list) {
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

        ~KeyedrefEthnicGroup()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
