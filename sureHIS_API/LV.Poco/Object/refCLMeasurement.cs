/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refCLMeasurement.cs         
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
	public partial class refCLMeasurement : BaseEntity, ICloneable	{
		public refCLMeasurement()
		{
			this.MCLID = 0;
            this.MCLDesc = null;
            this.ForClinical = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MCLID", MCLID); } }


		private long _MCLID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MCLID { get { return _MCLID; } set {_MCLID = value; } }

		private string _MCLCode;
		[LVRequired]
        [LVMaxLength(10)]
        public string MCLCode { get { return _MCLCode; } set {_MCLCode = value; } }

		private string _MCLName;
		[LVRequired]
        [LVMaxLength(64)]
        public string MCLName { get { return _MCLName; } set {_MCLName = value; } }

		private string _MCLDesc;
        [LVMaxLength(1024)]
        public string MCLDesc { get { return _MCLDesc; } set {_MCLDesc = value; } }

		private bool? _ForClinical;
        public bool? ForClinical { get { return _ForClinical; } set {_ForClinical = value; } }

		/// <summary>
/// Ref Key: FK_refUnitOfMeasure_refCLMeasurement
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
    public class KeyedrefCLMeasurement : KeyedCollection<KeyValuePair<string, long>, refCLMeasurement>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefCLMeasurement() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refCLMeasurement item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MCLID) { return new KeyValuePair<string, long>("MCLID", k_MCLID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refCLMeasurement item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refCLMeasurement item)
        {
            refCLMeasurement orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refCLMeasurement item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refCLMeasurement item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refCLMeasurement GetObjectByKey(long k_MCLID) 
		{
            if (this.Contains(GetKey(k_MCLID)) == false) return null;
            refCLMeasurement ob = this[GetKey(k_MCLID)];
            return (refCLMeasurement)ob;
        }

		public refCLMeasurement GetObjectByKey(long k_MCLID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MCLID)) == false) {
				refCLMeasurement ob = repository.GetQuery<refCLMeasurement>().FirstOrDefault(o => o.MCLID == k_MCLID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refCLMeasurement obj = this[GetKey(k_MCLID)];
            return (refCLMeasurement)obj;
        }

		public refCLMeasurement GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refCLMeasurement ob = this[keypair];
            return (refCLMeasurement)ob;
        }

        public refCLMeasurement GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refCLMeasurement ob = this[GetKey(keypair)];
            return (refCLMeasurement)ob;
        }

		bool _LoadAll = false;
        public List<refCLMeasurement> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refCLMeasurement>().ToList();
			foreach (refCLMeasurement item in list) {
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

        ~KeyedrefCLMeasurement()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
