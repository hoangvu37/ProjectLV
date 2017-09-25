/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : BodyRegion.cs         
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
	public partial class BodyRegion : BaseEntity, ICloneable	{
		public BodyRegion()
		{
			this.BRegID = 0;
			this.ClinReqID = 0;
			this.MedImgTestItemID = 0;
			this.ExamActID = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("BRegID", BRegID); } }


		private long _BRegID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long BRegID { get { return _BRegID; } set {_BRegID = value; } }

		private long _ClinReqID;
		[LVRequired]
        public long ClinReqID { get { return _ClinReqID; } set {_ClinReqID = value; } }

		private long? _MedImgTestItemID;
        public long? MedImgTestItemID { get { return _MedImgTestItemID; } set {_MedImgTestItemID = value; } }

		private long _ExamActID;
		[LVRequired]
        public long ExamActID { get { return _ExamActID; } set {_ExamActID = value; } }

		private string _Notes;
        [LVMaxLength(1024)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_BodyRegion_MedImagingTestItems
/// <summary>
/// <summary>
/// Ref Key: FK_BodyRegion_ParaClinicalReq
/// <summary>
/// <summary>
/// Ref Key: FK_BodyRegion_refExamAction
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
    public class KeyedBodyRegion : KeyedCollection<KeyValuePair<string, long>, BodyRegion>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedBodyRegion() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(BodyRegion item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_BRegID) { return new KeyValuePair<string, long>("BRegID", k_BRegID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(BodyRegion item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, BodyRegion item)
        {
            BodyRegion orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(BodyRegion item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(BodyRegion item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public BodyRegion GetObjectByKey(long k_BRegID) 
		{
            if (this.Contains(GetKey(k_BRegID)) == false) return null;
            BodyRegion ob = this[GetKey(k_BRegID)];
            return (BodyRegion)ob;
        }

		public BodyRegion GetObjectByKey(long k_BRegID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_BRegID)) == false) {
				BodyRegion ob = repository.GetQuery<BodyRegion>().FirstOrDefault(o => o.BRegID == k_BRegID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            BodyRegion obj = this[GetKey(k_BRegID)];
            return (BodyRegion)obj;
        }

		public BodyRegion GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            BodyRegion ob = this[keypair];
            return (BodyRegion)ob;
        }

        public BodyRegion GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            BodyRegion ob = this[GetKey(keypair)];
            return (BodyRegion)ob;
        }

		bool _LoadAll = false;
        public List<BodyRegion> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<BodyRegion>().ToList();
			foreach (BodyRegion item in list) {
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

        ~KeyedBodyRegion()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
