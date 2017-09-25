/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : AdmNoTemp.cs         
 * Created by           : Auto - 09/11/2017 15:19:56                     
 * Last modify          : Auto - 09/11/2017 15:19:56                     
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
	public partial class AdmNoTemp : BaseEntity, ICloneable	{
		public AdmNoTemp()
		{
			this.AdmNoTempID = 0;
			this.HosID = 0;
			this.Year = 0;
            this.isIPt = false;
			this.MaxNumber = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("AdmNoTempID", AdmNoTempID); } }


		private long _AdmNoTempID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long AdmNoTempID { get { return _AdmNoTempID; } set {_AdmNoTempID = value; } }

		private string _Catg;
		[LVRequired]
        [LVMaxLength(5)]
        public string Catg { get { return _Catg; } set {_Catg = value; } }

		private long? _HosID;
        public long? HosID { get { return _HosID; } set {_HosID = value; } }

		private short? _Year;
        public short? Year { get { return _Year; } set {_Year = value; } }

		private byte? _Month;
        public byte? Month { get { return _Month; } set {_Month = value; } }

		private byte? _Day;
        public byte? Day { get { return _Day; } set {_Day = value; } }

		private bool? _isIPt;
        public bool? isIPt { get { return _isIPt; } set {_isIPt = value; } }

		private int? _MaxNumber;
        public int? MaxNumber { get { return _MaxNumber; } set {_MaxNumber = value; } }

		private string _Prefix;
        [LVMaxLength(6)]
        public string Prefix { get { return _Prefix; } set {_Prefix = value; } }

		/// <summary>
/// Ref Key: FK_AdmNoTemp_HCProvider
/// <summary>
/// <summary>
/// Ref Key: FK_AdmNoTempHolding_AdmNoTemp
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
    public class KeyedAdmNoTemp : KeyedCollection<KeyValuePair<string, long>, AdmNoTemp>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedAdmNoTemp() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(AdmNoTemp item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_AdmNoTempID) { return new KeyValuePair<string, long>("AdmNoTempID", k_AdmNoTempID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(AdmNoTemp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, AdmNoTemp item)
        {
            AdmNoTemp orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(AdmNoTemp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(AdmNoTemp item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public AdmNoTemp GetObjectByKey(long k_AdmNoTempID) 
		{
            if (this.Contains(GetKey(k_AdmNoTempID)) == false) return null;
            AdmNoTemp ob = this[GetKey(k_AdmNoTempID)];
            return (AdmNoTemp)ob;
        }

		public AdmNoTemp GetObjectByKey(long k_AdmNoTempID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_AdmNoTempID)) == false) {
				AdmNoTemp ob = repository.GetQuery<AdmNoTemp>().FirstOrDefault(o => o.AdmNoTempID == k_AdmNoTempID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            AdmNoTemp obj = this[GetKey(k_AdmNoTempID)];
            return (AdmNoTemp)obj;
        }

		public AdmNoTemp GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            AdmNoTemp ob = this[keypair];
            return (AdmNoTemp)ob;
        }

        public AdmNoTemp GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            AdmNoTemp ob = this[GetKey(keypair)];
            return (AdmNoTemp)ob;
        }

		bool _LoadAll = false;
        public List<AdmNoTemp> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<AdmNoTemp>().ToList();
			foreach (AdmNoTemp item in list) {
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

        ~KeyedAdmNoTemp()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
