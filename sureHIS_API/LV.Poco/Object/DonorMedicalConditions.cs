/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : DonorMedicalConditions.cs         
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
	public partial class DonorMedicalConditions : BaseEntity, ICloneable	{
		public DonorMedicalConditions()
		{
			this.DonorMedCondID = 0;
			this.DonorID = 0;
			this.MCID = 0;
            this.MCExplainOrNotes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("DonorMedCondID", DonorMedCondID); } }


		private long _DonorMedCondID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long DonorMedCondID { get { return _DonorMedCondID; } set {_DonorMedCondID = value; } }

		private long _DonorID;
		[LVRequired]
        public long DonorID { get { return _DonorID; } set {_DonorID = value; } }

		private long _MCID;
		[LVRequired]
        public long MCID { get { return _MCID; } set {_MCID = value; } }

		private string _MCExplainOrNotes;
        [LVMaxLength(128)]
        public string MCExplainOrNotes { get { return _MCExplainOrNotes; } set {_MCExplainOrNotes = value; } }

		/// <summary>
/// Ref Key: FK_DonorMedicalConditions_Donor
/// <summary>
/// <summary>
/// Ref Key: FK_DonorMedicalConditions_refMedicalConditions
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
    public class KeyedDonorMedicalConditions : KeyedCollection<KeyValuePair<string, long>, DonorMedicalConditions>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedDonorMedicalConditions() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(DonorMedicalConditions item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_DonorMedCondID) { return new KeyValuePair<string, long>("DonorMedCondID", k_DonorMedCondID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(DonorMedicalConditions item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, DonorMedicalConditions item)
        {
            DonorMedicalConditions orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(DonorMedicalConditions item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(DonorMedicalConditions item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public DonorMedicalConditions GetObjectByKey(long k_DonorMedCondID) 
		{
            if (this.Contains(GetKey(k_DonorMedCondID)) == false) return null;
            DonorMedicalConditions ob = this[GetKey(k_DonorMedCondID)];
            return (DonorMedicalConditions)ob;
        }

		public DonorMedicalConditions GetObjectByKey(long k_DonorMedCondID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_DonorMedCondID)) == false) {
				DonorMedicalConditions ob = repository.GetQuery<DonorMedicalConditions>().FirstOrDefault(o => o.DonorMedCondID == k_DonorMedCondID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            DonorMedicalConditions obj = this[GetKey(k_DonorMedCondID)];
            return (DonorMedicalConditions)obj;
        }

		public DonorMedicalConditions GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            DonorMedicalConditions ob = this[keypair];
            return (DonorMedicalConditions)ob;
        }

        public DonorMedicalConditions GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            DonorMedicalConditions ob = this[GetKey(keypair)];
            return (DonorMedicalConditions)ob;
        }

		bool _LoadAll = false;
        public List<DonorMedicalConditions> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<DonorMedicalConditions>().ToList();
			foreach (DonorMedicalConditions item in list) {
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

        ~KeyedDonorMedicalConditions()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
