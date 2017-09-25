/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : ParaClinicalReqDetails.cs         
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
	public partial class ParaClinicalReqDetails : BaseEntity, ICloneable	{
		public ParaClinicalReqDetails()
		{
			this.ClinReqID = 0;
			this.DClinReqID = 0;
			this.MedLabTestItemID = 0;
            this.SpecialReq = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DClinReqID", DClinReqID); } }


		private long? _ClinReqID;
        public long? ClinReqID { get { return _ClinReqID; } set {_ClinReqID = value; } }

		private long _DClinReqID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DClinReqID { get { return _DClinReqID; } set {_DClinReqID = value; } }

		private long? _MedLabTestItemID;
        public long? MedLabTestItemID { get { return _MedLabTestItemID; } set {_MedLabTestItemID = value; } }

		private string _SpecialReq;
        [LVMaxLength(1024)]
        public string SpecialReq { get { return _SpecialReq; } set {_SpecialReq = value; } }

		/// <summary>
/// Ref Key: FK_ParaClinicalReqDetails_MedLabTestItems
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReqDetails_ParaClinicalReq
/// <summary>
/// <summary>
/// Ref Key: FK_PatientRequestOnSpecimen_ParaClinicalReqDetails
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
    public class KeyedParaClinicalReqDetails : KeyedCollection<KeyValuePair<string, long>, ParaClinicalReqDetails>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedParaClinicalReqDetails() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(ParaClinicalReqDetails item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DClinReqID) { return new KeyValuePair<string, long>("DClinReqID", k_DClinReqID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(ParaClinicalReqDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, ParaClinicalReqDetails item)
        {
            ParaClinicalReqDetails orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(ParaClinicalReqDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(ParaClinicalReqDetails item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public ParaClinicalReqDetails GetObjectByKey(long k_DClinReqID) 
		{
            if (this.Contains(GetKey(k_DClinReqID)) == false) return null;
            ParaClinicalReqDetails ob = this[GetKey(k_DClinReqID)];
            return (ParaClinicalReqDetails)ob;
        }

		public ParaClinicalReqDetails GetObjectByKey(long k_DClinReqID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DClinReqID)) == false) {
				ParaClinicalReqDetails ob = repository.GetQuery<ParaClinicalReqDetails>().FirstOrDefault(o => o.DClinReqID == k_DClinReqID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            ParaClinicalReqDetails obj = this[GetKey(k_DClinReqID)];
            return (ParaClinicalReqDetails)obj;
        }

		public ParaClinicalReqDetails GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            ParaClinicalReqDetails ob = this[keypair];
            return (ParaClinicalReqDetails)ob;
        }

        public ParaClinicalReqDetails GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            ParaClinicalReqDetails ob = this[GetKey(keypair)];
            return (ParaClinicalReqDetails)ob;
        }

		bool _LoadAll = false;
        public List<ParaClinicalReqDetails> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<ParaClinicalReqDetails>().ToList();
			foreach (ParaClinicalReqDetails item in list) {
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

        ~KeyedParaClinicalReqDetails()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
