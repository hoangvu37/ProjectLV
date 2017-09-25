/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : MedLabTestItems.cs         
 * Created by           : Auto - 09/11/2017 15:20:02                     
 * Last modify          : Auto - 09/11/2017 15:20:02                     
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
	public partial class MedLabTestItems : BaseEntity, ICloneable	{
		public MedLabTestItems()
		{
			this.MedLabTestItemID = 0;
			this.MedTestProcID = 0;
			this.MedLabTestID = 0;
            this.Notes = null;
            this.IsReq = true;
			this.MedSerID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("MedLabTestItemID", MedLabTestItemID); } }


		private long _MedLabTestItemID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long MedLabTestItemID { get { return _MedLabTestItemID; } set {_MedLabTestItemID = value; } }

		private long _MedTestProcID;
		[LVRequired]
        public long MedTestProcID { get { return _MedTestProcID; } set {_MedTestProcID = value; } }

		private long _MedLabTestID;
		[LVRequired]
        public long MedLabTestID { get { return _MedLabTestID; } set {_MedLabTestID = value; } }

		private string _Notes;
        [LVMaxLength(64)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		private bool? _IsReq;
        public bool? IsReq { get { return _IsReq; } set {_IsReq = value; } }

		private long? _MedSerID;
        public long? MedSerID { get { return _MedSerID; } set {_MedSerID = value; } }

		/// <summary>
/// Ref Key: FK_MedLabTestItems_MedicalServiceItem
/// <summary>
/// <summary>
/// Ref Key: FK_MedLabTestItems_MedicalTestProcedure
/// <summary>
/// <summary>
/// Ref Key: FK_MedLabTestItems_MedLabTest
/// <summary>
/// <summary>
/// Ref Key: FK_ParaClinicalReqDetails_MedLabTestItems
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
    public class KeyedMedLabTestItems : KeyedCollection<KeyValuePair<string, long>, MedLabTestItems>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedMedLabTestItems() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(MedLabTestItems item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_MedLabTestItemID) { return new KeyValuePair<string, long>("MedLabTestItemID", k_MedLabTestItemID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(MedLabTestItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, MedLabTestItems item)
        {
            MedLabTestItems orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(MedLabTestItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(MedLabTestItems item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public MedLabTestItems GetObjectByKey(long k_MedLabTestItemID) 
		{
            if (this.Contains(GetKey(k_MedLabTestItemID)) == false) return null;
            MedLabTestItems ob = this[GetKey(k_MedLabTestItemID)];
            return (MedLabTestItems)ob;
        }

		public MedLabTestItems GetObjectByKey(long k_MedLabTestItemID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_MedLabTestItemID)) == false) {
				MedLabTestItems ob = repository.GetQuery<MedLabTestItems>().FirstOrDefault(o => o.MedLabTestItemID == k_MedLabTestItemID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            MedLabTestItems obj = this[GetKey(k_MedLabTestItemID)];
            return (MedLabTestItems)obj;
        }

		public MedLabTestItems GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            MedLabTestItems ob = this[keypair];
            return (MedLabTestItems)ob;
        }

        public MedLabTestItems GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            MedLabTestItems ob = this[GetKey(keypair)];
            return (MedLabTestItems)ob;
        }

		bool _LoadAll = false;
        public List<MedLabTestItems> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<MedLabTestItems>().ToList();
			foreach (MedLabTestItems item in list) {
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

        ~KeyedMedLabTestItems()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
