/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DisposableMDResource.cs         
 * Created by           : Auto - 09/11/2017 15:19:58                     
 * Last modify          : Auto - 09/11/2017 15:19:58                     
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
	public partial class DisposableMDResource : BaseEntity, ICloneable	{
		public DisposableMDResource()
		{
			this.DispMDRscrID = 0;
            this.UsedTech = null;
            this.Components = null;
            this.ClinicalIndications = null;
            this.Effective = null;
            this.ExpectedTimeUse = null;
            this.TreatmentNotes = null;
			this.RscrID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DispMDRscrID", DispMDRscrID); } }


		private long _DispMDRscrID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DispMDRscrID { get { return _DispMDRscrID; } set {_DispMDRscrID = value; } }

		private string _UsedTech;
        [LVMaxLength(128)]
        public string UsedTech { get { return _UsedTech; } set {_UsedTech = value; } }

		private string _Components;
        [LVMaxLength(256)]
        public string Components { get { return _Components; } set {_Components = value; } }

		private string _ClinicalIndications;
        [LVMaxLength(256)]
        public string ClinicalIndications { get { return _ClinicalIndications; } set {_ClinicalIndications = value; } }

		private string _Effective;
        [LVMaxLength(256)]
        public string Effective { get { return _Effective; } set {_Effective = value; } }

		private long? _ExpectedTimeUse;
        public long? ExpectedTimeUse { get { return _ExpectedTimeUse; } set {_ExpectedTimeUse = value; } }

		private string _TreatmentNotes;
        [LVMaxLength(2048)]
        public string TreatmentNotes { get { return _TreatmentNotes; } set {_TreatmentNotes = value; } }

		private long? _RscrID;
        public long? RscrID { get { return _RscrID; } set {_RscrID = value; } }

		/// <summary>
/// Ref Key: FK_DisposableMDResource_Resource
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
    public class KeyedDisposableMDResource : KeyedCollection<KeyValuePair<string, long>, DisposableMDResource>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDisposableMDResource() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DisposableMDResource item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DispMDRscrID) { return new KeyValuePair<string, long>("DispMDRscrID", k_DispMDRscrID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DisposableMDResource item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DisposableMDResource item)
        {
            DisposableMDResource orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DisposableMDResource item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DisposableMDResource item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DisposableMDResource GetObjectByKey(long k_DispMDRscrID) 
		{
            if (this.Contains(GetKey(k_DispMDRscrID)) == false) return null;
            DisposableMDResource ob = this[GetKey(k_DispMDRscrID)];
            return (DisposableMDResource)ob;
        }

		public DisposableMDResource GetObjectByKey(long k_DispMDRscrID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DispMDRscrID)) == false) {
				DisposableMDResource ob = repository.GetQuery<DisposableMDResource>().FirstOrDefault(o => o.DispMDRscrID == k_DispMDRscrID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DisposableMDResource obj = this[GetKey(k_DispMDRscrID)];
            return (DisposableMDResource)obj;
        }

		public DisposableMDResource GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DisposableMDResource ob = this[keypair];
            return (DisposableMDResource)ob;
        }

        public DisposableMDResource GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DisposableMDResource ob = this[GetKey(keypair)];
            return (DisposableMDResource)ob;
        }

		bool _LoadAll = false;
        public List<DisposableMDResource> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DisposableMDResource>().ToList();
			foreach (DisposableMDResource item in list) {
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

        ~KeyedDisposableMDResource()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}