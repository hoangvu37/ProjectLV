/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refMedcnAdminRoute.cs         
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
	public partial class refMedcnAdminRoute : BaseEntity, ICloneable	{
		public refMedcnAdminRoute()
		{
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("MedcnAdminRouteCode", MedcnAdminRouteCode); } }


		private string _MedcnAdminRouteCode;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(16)]
        public string MedcnAdminRouteCode { get { return _MedcnAdminRouteCode; } set {_MedcnAdminRouteCode = value; } }

		private string _MedcnAdminRouteName;
        [LVMaxLength(100)]
        public string MedcnAdminRouteName { get { return _MedcnAdminRouteName; } set {_MedcnAdminRouteName = value; } }

		/// <summary>
/// Ref Key: FK_Drug_refMedcnAdminRoute
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
    public class KeyedrefMedcnAdminRoute : KeyedCollection<KeyValuePair<string, string>, refMedcnAdminRoute>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefMedcnAdminRoute() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refMedcnAdminRoute item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_MedcnAdminRouteCode) { return new KeyValuePair<string, string>("MedcnAdminRouteCode", k_MedcnAdminRouteCode); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refMedcnAdminRoute item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refMedcnAdminRoute item)
        {
            refMedcnAdminRoute orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refMedcnAdminRoute item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refMedcnAdminRoute item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refMedcnAdminRoute GetObjectByKey(string k_MedcnAdminRouteCode) 
		{
            if (this.Contains(GetKey(k_MedcnAdminRouteCode)) == false) return null;
            refMedcnAdminRoute ob = this[GetKey(k_MedcnAdminRouteCode)];
            return (refMedcnAdminRoute)ob;
        }

		public refMedcnAdminRoute GetObjectByKey(string k_MedcnAdminRouteCode, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedcnAdminRouteCode)) == false) {
				refMedcnAdminRoute ob = repository.GetQuery<refMedcnAdminRoute>().FirstOrDefault(o => o.MedcnAdminRouteCode == k_MedcnAdminRouteCode);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refMedcnAdminRoute obj = this[GetKey(k_MedcnAdminRouteCode)];
            return (refMedcnAdminRoute)obj;
        }

		public refMedcnAdminRoute GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refMedcnAdminRoute ob = this[keypair];
            return (refMedcnAdminRoute)ob;
        }

        public refMedcnAdminRoute GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refMedcnAdminRoute ob = this[GetKey(keypair)];
            return (refMedcnAdminRoute)ob;
        }

		bool _LoadAll = false;
        public List<refMedcnAdminRoute> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refMedcnAdminRoute>().ToList();
			foreach (refMedcnAdminRoute item in list) {
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

        ~KeyedrefMedcnAdminRoute()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
