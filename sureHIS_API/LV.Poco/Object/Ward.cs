/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Ward.cs         
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
	public partial class Ward : BaseEntity, ICloneable	{
		public Ward()
		{
			this.WID = 0;
            this.IsCommon = false;
            this.IsClinicWard = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("WID", WID); } }


		private long _WID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long WID { get { return _WID; } set {_WID = value; } }

		private string _WName;
		[LVRequired]
        [LVMaxLength(64)]
        public string WName { get { return _WName; } set {_WName = value; } }

		private string _WDesc;
        [LVMaxLength(1024)]
        public string WDesc { get { return _WDesc; } set {_WDesc = value; } }

		private bool _IsCommon;
        public bool IsCommon { get { return _IsCommon; } set {_IsCommon = value; } }

		private bool? _IsClinicWard;
        public bool? IsClinicWard { get { return _IsClinicWard; } set {_IsClinicWard = value; } }

		/// <summary>
/// Ref Key: FK_WardInDept_Ward
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
    public class KeyedWard : KeyedCollection<KeyValuePair<string, long>, Ward>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedWard() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Ward item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_WID) { return new KeyValuePair<string, long>("WID", k_WID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Ward item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Ward item)
        {
            Ward orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Ward item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Ward item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Ward GetObjectByKey(long k_WID) 
		{
            if (this.Contains(GetKey(k_WID)) == false) return null;
            Ward ob = this[GetKey(k_WID)];
            return (Ward)ob;
        }

		public Ward GetObjectByKey(long k_WID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_WID)) == false) {
				Ward ob = repository.GetQuery<Ward>().FirstOrDefault(o => o.WID == k_WID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Ward obj = this[GetKey(k_WID)];
            return (Ward)obj;
        }

		public Ward GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Ward ob = this[keypair];
            return (Ward)ob;
        }

        public Ward GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Ward ob = this[GetKey(keypair)];
            return (Ward)ob;
        }

		bool _LoadAll = false;
        public List<Ward> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Ward>().ToList();
			foreach (Ward item in list) {
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

        ~KeyedWard()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
