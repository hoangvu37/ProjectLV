/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DonorMedication.cs         
 * Created by           : Auto - 09/11/2017 15:19:53                     
 * Last modify          : Auto - 09/11/2017 15:19:53                     
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
	public partial class DonorMedication : BaseEntity, ICloneable	{
		public DonorMedication()
		{
			this.DonorMedID = 0;
			this.DonorID = 0;
			this.MedCode = 0;
            this.Comments = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DonorMedID", DonorMedID); } }


		private long _DonorMedID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DonorMedID { get { return _DonorMedID; } set {_DonorMedID = value; } }

		private long _DonorID;
		[LVRequired]
        public long DonorID { get { return _DonorID; } set {_DonorID = value; } }

		private long _MedCode;
		[LVRequired]
        public long MedCode { get { return _MedCode; } set {_MedCode = value; } }

		private string _Comments;
        [LVMaxLength(1024)]
        public string Comments { get { return _Comments; } set {_Comments = value; } }

		/// <summary>
/// Ref Key: FK_DonorMedication_Donor
/// <summary>
/// <summary>
/// Ref Key: FK_DonorMedication_Drug
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
    public class KeyedDonorMedication : KeyedCollection<KeyValuePair<string, long>, DonorMedication>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDonorMedication() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DonorMedication item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DonorMedID) { return new KeyValuePair<string, long>("DonorMedID", k_DonorMedID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DonorMedication item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DonorMedication item)
        {
            DonorMedication orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DonorMedication item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DonorMedication item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DonorMedication GetObjectByKey(long k_DonorMedID) 
		{
            if (this.Contains(GetKey(k_DonorMedID)) == false) return null;
            DonorMedication ob = this[GetKey(k_DonorMedID)];
            return (DonorMedication)ob;
        }

		public DonorMedication GetObjectByKey(long k_DonorMedID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DonorMedID)) == false) {
				DonorMedication ob = repository.GetQuery<DonorMedication>().FirstOrDefault(o => o.DonorMedID == k_DonorMedID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DonorMedication obj = this[GetKey(k_DonorMedID)];
            return (DonorMedication)obj;
        }

		public DonorMedication GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DonorMedication ob = this[keypair];
            return (DonorMedication)ob;
        }

        public DonorMedication GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DonorMedication ob = this[GetKey(keypair)];
            return (DonorMedication)ob;
        }

		bool _LoadAll = false;
        public List<DonorMedication> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DonorMedication>().ToList();
			foreach (DonorMedication item in list) {
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

        ~KeyedDonorMedication()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
