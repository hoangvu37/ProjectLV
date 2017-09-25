/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refDiagnosis.cs         
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
	public partial class refDiagnosis : BaseEntity, ICloneable	{
		public refDiagnosis()
		{
			this.DxID = 0;
            this.DxDesc = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DxID", DxID); } }


		private long _DxID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DxID { get { return _DxID; } set {_DxID = value; } }

		private string _DxCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string DxCode { get { return _DxCode; } set {_DxCode = value; } }

		private string _DxName;
		[LVRequired]
        [LVMaxLength(128)]
        public string DxName { get { return _DxName; } set {_DxName = value; } }

		private string _DxDesc;
        [LVMaxLength(2048)]
        public string DxDesc { get { return _DxDesc; } set {_DxDesc = value; } }

		/// <summary>
/// Ref Key: FK_PtAdmission_reDiagnosis
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
    public class KeyedrefDiagnosis : KeyedCollection<KeyValuePair<string, long>, refDiagnosis>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefDiagnosis() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refDiagnosis item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DxID) { return new KeyValuePair<string, long>("DxID", k_DxID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refDiagnosis item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refDiagnosis item)
        {
            refDiagnosis orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refDiagnosis item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refDiagnosis item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refDiagnosis GetObjectByKey(long k_DxID) 
		{
            if (this.Contains(GetKey(k_DxID)) == false) return null;
            refDiagnosis ob = this[GetKey(k_DxID)];
            return (refDiagnosis)ob;
        }

		public refDiagnosis GetObjectByKey(long k_DxID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DxID)) == false) {
				refDiagnosis ob = repository.GetQuery<refDiagnosis>().FirstOrDefault(o => o.DxID == k_DxID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refDiagnosis obj = this[GetKey(k_DxID)];
            return (refDiagnosis)obj;
        }

		public refDiagnosis GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refDiagnosis ob = this[keypair];
            return (refDiagnosis)ob;
        }

        public refDiagnosis GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refDiagnosis ob = this[GetKey(keypair)];
            return (refDiagnosis)ob;
        }

		bool _LoadAll = false;
        public List<refDiagnosis> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refDiagnosis>().ToList();
			foreach (refDiagnosis item in list) {
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

        ~KeyedrefDiagnosis()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
