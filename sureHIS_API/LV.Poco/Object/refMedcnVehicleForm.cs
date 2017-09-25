/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refMedcnVehicleForm.cs         
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
	public partial class refMedcnVehicleForm : BaseEntity, ICloneable	{
		public refMedcnVehicleForm()
		{
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("MedcnVehicleFormCode", MedcnVehicleFormCode); } }


		private string _MedcnVehicleFormCode;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(16)]
        public string MedcnVehicleFormCode { get { return _MedcnVehicleFormCode; } set {_MedcnVehicleFormCode = value; } }

		private string _MedcnVehicleFormName;
		[LVRequired]
        [LVMaxLength(100)]
        public string MedcnVehicleFormName { get { return _MedcnVehicleFormName; } set {_MedcnVehicleFormName = value; } }

		/// <summary>
/// Ref Key: FK_Drug_refMedcnVehicleForm
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
    public class KeyedrefMedcnVehicleForm : KeyedCollection<KeyValuePair<string, string>, refMedcnVehicleForm>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefMedcnVehicleForm() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refMedcnVehicleForm item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_MedcnVehicleFormCode) { return new KeyValuePair<string, string>("MedcnVehicleFormCode", k_MedcnVehicleFormCode); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refMedcnVehicleForm item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refMedcnVehicleForm item)
        {
            refMedcnVehicleForm orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refMedcnVehicleForm item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refMedcnVehicleForm item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refMedcnVehicleForm GetObjectByKey(string k_MedcnVehicleFormCode) 
		{
            if (this.Contains(GetKey(k_MedcnVehicleFormCode)) == false) return null;
            refMedcnVehicleForm ob = this[GetKey(k_MedcnVehicleFormCode)];
            return (refMedcnVehicleForm)ob;
        }

		public refMedcnVehicleForm GetObjectByKey(string k_MedcnVehicleFormCode, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedcnVehicleFormCode)) == false) {
				refMedcnVehicleForm ob = repository.GetQuery<refMedcnVehicleForm>().FirstOrDefault(o => o.MedcnVehicleFormCode == k_MedcnVehicleFormCode);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refMedcnVehicleForm obj = this[GetKey(k_MedcnVehicleFormCode)];
            return (refMedcnVehicleForm)obj;
        }

		public refMedcnVehicleForm GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refMedcnVehicleForm ob = this[keypair];
            return (refMedcnVehicleForm)ob;
        }

        public refMedcnVehicleForm GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refMedcnVehicleForm ob = this[GetKey(keypair)];
            return (refMedcnVehicleForm)ob;
        }

		bool _LoadAll = false;
        public List<refMedcnVehicleForm> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refMedcnVehicleForm>().ToList();
			foreach (refMedcnVehicleForm item in list) {
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

        ~KeyedrefMedcnVehicleForm()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
