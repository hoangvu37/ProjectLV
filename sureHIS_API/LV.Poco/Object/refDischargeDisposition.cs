/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refDischargeDisposition.cs         
 * Created by           : Auto - 09/11/2017 15:19:57                     
 * Last modify          : Auto - 09/11/2017 15:19:57                     
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
	public partial class refDischargeDisposition : BaseEntity, ICloneable	{
		public refDischargeDisposition()
		{
			this.HCFEDispDisposID = 0;
            this.Is7 = true;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HCFEDispDisposID", HCFEDispDisposID); } }


		private long _HCFEDispDisposID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HCFEDispDisposID { get { return _HCFEDispDisposID; } set {_HCFEDispDisposID = value; } }

		private string _HCFEDispDisposCode;
		[LVRequired]
        [LVMaxLength(16)]
        public string HCFEDispDisposCode { get { return _HCFEDispDisposCode; } set {_HCFEDispDisposCode = value; } }

		private string _HCFEDispDisposName;
		[LVRequired]
        [LVMaxLength(186)]
        public string HCFEDispDisposName { get { return _HCFEDispDisposName; } set {_HCFEDispDisposName = value; } }

		private string _VNHCFEDispDisposName;
        [LVMaxLength(256)]
        public string VNHCFEDispDisposName { get { return _VNHCFEDispDisposName; } set {_VNHCFEDispDisposName = value; } }

		private string _HCFEDispDisposDesc;
        [LVMaxLength(256)]
        public string HCFEDispDisposDesc { get { return _HCFEDispDisposDesc; } set {_HCFEDispDisposDesc = value; } }

		private bool _Is7;
        public bool Is7 { get { return _Is7; } set {_Is7 = value; } }

		/// <summary>
/// Ref Key: FK_Encounter_refDispositionType
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
    public class KeyedrefDischargeDisposition : KeyedCollection<KeyValuePair<string, long>, refDischargeDisposition>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefDischargeDisposition() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refDischargeDisposition item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HCFEDispDisposID) { return new KeyValuePair<string, long>("HCFEDispDisposID", k_HCFEDispDisposID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refDischargeDisposition item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refDischargeDisposition item)
        {
            refDischargeDisposition orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refDischargeDisposition item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refDischargeDisposition item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refDischargeDisposition GetObjectByKey(long k_HCFEDispDisposID) 
		{
            if (this.Contains(GetKey(k_HCFEDispDisposID)) == false) return null;
            refDischargeDisposition ob = this[GetKey(k_HCFEDispDisposID)];
            return (refDischargeDisposition)ob;
        }

		public refDischargeDisposition GetObjectByKey(long k_HCFEDispDisposID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HCFEDispDisposID)) == false) {
				refDischargeDisposition ob = repository.GetQuery<refDischargeDisposition>().FirstOrDefault(o => o.HCFEDispDisposID == k_HCFEDispDisposID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refDischargeDisposition obj = this[GetKey(k_HCFEDispDisposID)];
            return (refDischargeDisposition)obj;
        }

		public refDischargeDisposition GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refDischargeDisposition ob = this[keypair];
            return (refDischargeDisposition)ob;
        }

        public refDischargeDisposition GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refDischargeDisposition ob = this[GetKey(keypair)];
            return (refDischargeDisposition)ob;
        }

		bool _LoadAll = false;
        public List<refDischargeDisposition> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refDischargeDisposition>().ToList();
			foreach (refDischargeDisposition item in list) {
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

        ~KeyedrefDischargeDisposition()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
