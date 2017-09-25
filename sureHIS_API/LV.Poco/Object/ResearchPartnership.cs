/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ResearchPartnership.cs         
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
	public partial class ResearchPartnership : BaseEntity, ICloneable	{
		public ResearchPartnership()
		{
			this.PartnershipID = 0;
            this.PartnershipNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PartnershipID", PartnershipID); } }


		private long _PartnershipID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PartnershipID { get { return _PartnershipID; } set {_PartnershipID = value; } }

		private string _PartnershipName;
		[LVRequired]
        [LVMaxLength(80)]
        public string PartnershipName { get { return _PartnershipName; } set {_PartnershipName = value; } }

		private string _PartnershipContactInfo;
		[LVRequired]
        [LVMaxLength(512)]
        public string PartnershipContactInfo { get { return _PartnershipContactInfo; } set {_PartnershipContactInfo = value; } }

		private string _PartnershipNotes;
        [LVMaxLength(2147483647)]
        public string PartnershipNotes { get { return _PartnershipNotes; } set {_PartnershipNotes = value; } }

		/// <summary>
/// Ref Key: FK_MedicalServiceItems_ResearchPartnership
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
    public class KeyedResearchPartnership : KeyedCollection<KeyValuePair<string, long>, ResearchPartnership>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedResearchPartnership() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ResearchPartnership item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PartnershipID) { return new KeyValuePair<string, long>("PartnershipID", k_PartnershipID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ResearchPartnership item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ResearchPartnership item)
        {
            ResearchPartnership orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ResearchPartnership item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ResearchPartnership item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ResearchPartnership GetObjectByKey(long k_PartnershipID) 
		{
            if (this.Contains(GetKey(k_PartnershipID)) == false) return null;
            ResearchPartnership ob = this[GetKey(k_PartnershipID)];
            return (ResearchPartnership)ob;
        }

		public ResearchPartnership GetObjectByKey(long k_PartnershipID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PartnershipID)) == false) {
				ResearchPartnership ob = repository.GetQuery<ResearchPartnership>().FirstOrDefault(o => o.PartnershipID == k_PartnershipID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ResearchPartnership obj = this[GetKey(k_PartnershipID)];
            return (ResearchPartnership)obj;
        }

		public ResearchPartnership GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ResearchPartnership ob = this[keypair];
            return (ResearchPartnership)ob;
        }

        public ResearchPartnership GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ResearchPartnership ob = this[GetKey(keypair)];
            return (ResearchPartnership)ob;
        }

		bool _LoadAll = false;
        public List<ResearchPartnership> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ResearchPartnership>().ToList();
			foreach (ResearchPartnership item in list) {
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

        ~KeyedResearchPartnership()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
