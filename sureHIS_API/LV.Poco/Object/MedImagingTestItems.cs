/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedImagingTestItems.cs         
 * Created by           : Auto - 09/11/2017 15:20:00                     
 * Last modify          : Auto - 09/11/2017 15:20:00                     
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
	public partial class MedImagingTestItems : BaseEntity, ICloneable	{
		public MedImagingTestItems()
		{
			this.MedImgTestItemID = 0;
			this.MedTestProcID = 0;
			this.MedImgTestID = 0;
			this.MedSerID = 0;
            this.IsReq = true;
            this.Note = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedImgTestItemID", MedImgTestItemID); } }


		private long _MedImgTestItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedImgTestItemID { get { return _MedImgTestItemID; } set {_MedImgTestItemID = value; } }

		private long? _MedTestProcID;
        public long? MedTestProcID { get { return _MedTestProcID; } set {_MedTestProcID = value; } }

		private long? _MedImgTestID;
        public long? MedImgTestID { get { return _MedImgTestID; } set {_MedImgTestID = value; } }

		private long? _MedSerID;
        public long? MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		private bool? _IsReq;
        public bool? IsReq { get { return _IsReq; } set {_IsReq = value; } }

		private string _Note;
        [LVMaxLength(256)]
        public string Note { get { return _Note; } set {_Note = value; } }

		/// <summary>
/// Ref Key: FK_BodyRegion_MedImagingTestItems
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingTestItems_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingTestItems_MedicalTestProcedure
/// <summary>
/// <summary>
/// Ref Key: FK_MedImagingTestItem_MedImagingTest
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
    public class KeyedMedImagingTestItems : KeyedCollection<KeyValuePair<string, long>, MedImagingTestItems>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedImagingTestItems() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedImagingTestItems item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedImgTestItemID) { return new KeyValuePair<string, long>("MedImgTestItemID", k_MedImgTestItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedImagingTestItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedImagingTestItems item)
        {
            MedImagingTestItems orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedImagingTestItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedImagingTestItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedImagingTestItems GetObjectByKey(long k_MedImgTestItemID) 
		{
            if (this.Contains(GetKey(k_MedImgTestItemID)) == false) return null;
            MedImagingTestItems ob = this[GetKey(k_MedImgTestItemID)];
            return (MedImagingTestItems)ob;
        }

		public MedImagingTestItems GetObjectByKey(long k_MedImgTestItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedImgTestItemID)) == false) {
				MedImagingTestItems ob = repository.GetQuery<MedImagingTestItems>().FirstOrDefault(o => o.MedImgTestItemID == k_MedImgTestItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedImagingTestItems obj = this[GetKey(k_MedImgTestItemID)];
            return (MedImagingTestItems)obj;
        }

		public MedImagingTestItems GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedImagingTestItems ob = this[keypair];
            return (MedImagingTestItems)ob;
        }

        public MedImagingTestItems GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedImagingTestItems ob = this[GetKey(keypair)];
            return (MedImagingTestItems)ob;
        }

		bool _LoadAll = false;
        public List<MedImagingTestItems> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedImagingTestItems>().ToList();
			foreach (MedImagingTestItems item in list) {
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

        ~KeyedMedImagingTestItems()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
