/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refInsurKind.cs         
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
	public partial class refInsurKind : BaseEntity, ICloneable	{
		public refInsurKind()
		{
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, string> Key { get { return new KeyValuePair<string, string>("InsurKindID", InsurKindID); } }


		private string _InsurKindID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        [LVMaxLength(10)]
        public string InsurKindID { get { return _InsurKindID; } set {_InsurKindID = value; } }

		private string _InsurKindName;
		[LVRequired]
        [LVMaxLength(100)]
        public string InsurKindName { get { return _InsurKindName; } set {_InsurKindName = value; } }

		/// <summary>
/// Ref Key: FK_Drug_InsurKind
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
    public class KeyedrefInsurKind : KeyedCollection<KeyValuePair<string, string>, refInsurKind>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefInsurKind() : base() { }

        protected override KeyValuePair<string, string> GetKeyForItem(refInsurKind item)
        {
            return item.Key;
        }

        public KeyValuePair<string, string> GetKey(string k_InsurKindID) { return new KeyValuePair<string, string>("InsurKindID", k_InsurKindID); }

        public KeyValuePair<string, string> GetKey(object keypair) { try { return (KeyValuePair<string, string>)keypair; } catch { return new KeyValuePair<string, string>(); } }
        #endregion

        #region Method
        public bool AddObject(refInsurKind item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, string> keypair, refInsurKind item)
        {
            refInsurKind orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refInsurKind item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refInsurKind item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refInsurKind GetObjectByKey(string k_InsurKindID) 
		{
            if (this.Contains(GetKey(k_InsurKindID)) == false) return null;
            refInsurKind ob = this[GetKey(k_InsurKindID)];
            return (refInsurKind)ob;
        }

		public refInsurKind GetObjectByKey(string k_InsurKindID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_InsurKindID)) == false) {
				refInsurKind ob = repository.GetQuery<refInsurKind>().FirstOrDefault(o => o.InsurKindID == k_InsurKindID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refInsurKind obj = this[GetKey(k_InsurKindID)];
            return (refInsurKind)obj;
        }

		public refInsurKind GetObjectByKey(KeyValuePair<string, string> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refInsurKind ob = this[keypair];
            return (refInsurKind)ob;
        }

        public refInsurKind GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refInsurKind ob = this[GetKey(keypair)];
            return (refInsurKind)ob;
        }

		bool _LoadAll = false;
        public List<refInsurKind> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refInsurKind>().ToList();
			foreach (refInsurKind item in list) {
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

        ~KeyedrefInsurKind()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
