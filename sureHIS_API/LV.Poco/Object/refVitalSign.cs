/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refVitalSign.cs         
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
	public partial class refVitalSign : BaseEntity, ICloneable	{
		public refVitalSign()
		{
			this.VitSignID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("VitSignID", VitSignID); } }


		private long _VitSignID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long VitSignID { get { return _VitSignID; } set {_VitSignID = value; } }

		private string _VitSignCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string VitSignCode { get { return _VitSignCode; } set {_VitSignCode = value; } }

		private string _VitSignName;
		[LVRequired]
        [LVMaxLength(64)]
        public string VitSignName { get { return _VitSignName; } set {_VitSignName = value; } }

		private string _VNVitSignName;
        [LVMaxLength(128)]
        public string VNVitSignName { get { return _VNVitSignName; } set {_VNVitSignName = value; } }

		/// <summary>
/// Ref Key: FK_PatientVitalSign_refVitalSign
/// <summary>
/// <summary>
/// Ref Key: FK_refLimVitalSign_refVitalSign
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
    public class KeyedrefVitalSign : KeyedCollection<KeyValuePair<string, long>, refVitalSign>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefVitalSign() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refVitalSign item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_VitSignID) { return new KeyValuePair<string, long>("VitSignID", k_VitSignID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refVitalSign item)
        {
            refVitalSign orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refVitalSign item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refVitalSign GetObjectByKey(long k_VitSignID) 
		{
            if (this.Contains(GetKey(k_VitSignID)) == false) return null;
            refVitalSign ob = this[GetKey(k_VitSignID)];
            return (refVitalSign)ob;
        }

		public refVitalSign GetObjectByKey(long k_VitSignID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_VitSignID)) == false) {
				refVitalSign ob = repository.GetQuery<refVitalSign>().FirstOrDefault(o => o.VitSignID == k_VitSignID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refVitalSign obj = this[GetKey(k_VitSignID)];
            return (refVitalSign)obj;
        }

		public refVitalSign GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refVitalSign ob = this[keypair];
            return (refVitalSign)ob;
        }

        public refVitalSign GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refVitalSign ob = this[GetKey(keypair)];
            return (refVitalSign)ob;
        }

		bool _LoadAll = false;
        public List<refVitalSign> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refVitalSign>().ToList();
			foreach (refVitalSign item in list) {
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

        ~KeyedrefVitalSign()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
