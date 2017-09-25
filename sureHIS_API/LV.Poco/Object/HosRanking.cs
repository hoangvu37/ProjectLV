/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : HosRanking.cs         
 * Created by           : Auto - 09/11/2017 15:19:59                     
 * Last modify          : Auto - 09/11/2017 15:19:59                     
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
	public partial class HosRanking : BaseEntity, ICloneable	{
		public HosRanking()
		{
			this.HosRankID = 0;
			this.HosID = 0;
            this.DateOfRecog = DateTime.Now;
			this.V_HospitalType = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("HosRankID", HosRankID); } }


		private long _HosRankID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long HosRankID { get { return _HosRankID; } set {_HosRankID = value; } }

		private long _HosID;
		[LVRequired]
        public long HosID { get { return _HosID; } set {_HosID = value; } }

		private DateTime? _DateOfRecog;
        public DateTime? DateOfRecog { get { return _DateOfRecog; } set {_DateOfRecog = value; } }

		private long _V_HospitalType;
		[LVRequired]
        public long V_HospitalType { get { return _V_HospitalType; } set {_V_HospitalType = value; } }

		private string _Notes;
        [LVMaxLength(2147483647)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_HosRanking_HCProvider
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
    public class KeyedHosRanking : KeyedCollection<KeyValuePair<string, long>, HosRanking>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedHosRanking() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(HosRanking item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_HosRankID) { return new KeyValuePair<string, long>("HosRankID", k_HosRankID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(HosRanking item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, HosRanking item)
        {
            HosRanking orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(HosRanking item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(HosRanking item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public HosRanking GetObjectByKey(long k_HosRankID) 
		{
            if (this.Contains(GetKey(k_HosRankID)) == false) return null;
            HosRanking ob = this[GetKey(k_HosRankID)];
            return (HosRanking)ob;
        }

		public HosRanking GetObjectByKey(long k_HosRankID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_HosRankID)) == false) {
				HosRanking ob = repository.GetQuery<HosRanking>().FirstOrDefault(o => o.HosRankID == k_HosRankID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            HosRanking obj = this[GetKey(k_HosRankID)];
            return (HosRanking)obj;
        }

		public HosRanking GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            HosRanking ob = this[keypair];
            return (HosRanking)ob;
        }

        public HosRanking GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            HosRanking ob = this[GetKey(keypair)];
            return (HosRanking)ob;
        }

		bool _LoadAll = false;
        public List<HosRanking> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<HosRanking>().ToList();
			foreach (HosRanking item in list) {
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

        ~KeyedHosRanking()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
