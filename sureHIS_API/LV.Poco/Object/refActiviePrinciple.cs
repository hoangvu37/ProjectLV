/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refActiviePrinciple.cs         
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
	public partial class refActiviePrinciple : BaseEntity, ICloneable	{
		public refActiviePrinciple()
		{
			this.AcPrincipleID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AcPrincipleID", AcPrincipleID); } }


		private long _AcPrincipleID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AcPrincipleID { get { return _AcPrincipleID; } set {_AcPrincipleID = value; } }

		private string _AcPrincipleName;
		[LVRequired]
        [LVMaxLength(100)]
        public string AcPrincipleName { get { return _AcPrincipleName; } set {_AcPrincipleName = value; } }

		private string _ATCCode;
		[LVRequired]
        [LVMaxLength(7)]
        public string ATCCode { get { return _ATCCode; } set {_ATCCode = value; } }

		private string _Notes;
        [LVMaxLength(254)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_AcPrincDrug_refActiviePrinciple
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
    public class KeyedrefActiviePrinciple : KeyedCollection<KeyValuePair<string, long>, refActiviePrinciple>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefActiviePrinciple() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refActiviePrinciple item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AcPrincipleID) { return new KeyValuePair<string, long>("AcPrincipleID", k_AcPrincipleID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refActiviePrinciple item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refActiviePrinciple item)
        {
            refActiviePrinciple orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refActiviePrinciple item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refActiviePrinciple item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refActiviePrinciple GetObjectByKey(long k_AcPrincipleID) 
		{
            if (this.Contains(GetKey(k_AcPrincipleID)) == false) return null;
            refActiviePrinciple ob = this[GetKey(k_AcPrincipleID)];
            return (refActiviePrinciple)ob;
        }

		public refActiviePrinciple GetObjectByKey(long k_AcPrincipleID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AcPrincipleID)) == false) {
				refActiviePrinciple ob = repository.GetQuery<refActiviePrinciple>().FirstOrDefault(o => o.AcPrincipleID == k_AcPrincipleID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refActiviePrinciple obj = this[GetKey(k_AcPrincipleID)];
            return (refActiviePrinciple)obj;
        }

		public refActiviePrinciple GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refActiviePrinciple ob = this[keypair];
            return (refActiviePrinciple)ob;
        }

        public refActiviePrinciple GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refActiviePrinciple ob = this[GetKey(keypair)];
            return (refActiviePrinciple)ob;
        }

		bool _LoadAll = false;
        public List<refActiviePrinciple> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refActiviePrinciple>().ToList();
			foreach (refActiviePrinciple item in list) {
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

        ~KeyedrefActiviePrinciple()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
