/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : SeparationOfBlood.cs         
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
	public partial class SeparationOfBlood : BaseEntity, ICloneable	{
		public SeparationOfBlood()
		{
			this.SepnBloodID = 0;
			this.BloodBankID = 0;
			this.V_BloodComponent = 0;
			this.Percentage = 0;
            this.Notes = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("SepnBloodID", SepnBloodID); } }


		private long _SepnBloodID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long SepnBloodID { get { return _SepnBloodID; } set {_SepnBloodID = value; } }

		private long? _BloodBankID;
        public long? BloodBankID { get { return _BloodBankID; } set {_BloodBankID = value; } }

		private long _V_BloodComponent;
		[LVRequired]
        public long V_BloodComponent { get { return _V_BloodComponent; } set {_V_BloodComponent = value; } }

		private double _Percentage;
		[LVRequired]
        public double Percentage { get { return _Percentage; } set {_Percentage = value; } }

		private string _Notes;
        [LVMaxLength(512)]
        public string Notes { get { return _Notes; } set {_Notes = value; } }

		/// <summary>
/// Ref Key: FK_SeparationOfBlood_Bloodbank
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
    public class KeyedSeparationOfBlood : KeyedCollection<KeyValuePair<string, long>, SeparationOfBlood>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedSeparationOfBlood() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(SeparationOfBlood item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_SepnBloodID) { return new KeyValuePair<string, long>("SepnBloodID", k_SepnBloodID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(SeparationOfBlood item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, SeparationOfBlood item)
        {
            SeparationOfBlood orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(SeparationOfBlood item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(SeparationOfBlood item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public SeparationOfBlood GetObjectByKey(long k_SepnBloodID) 
		{
            if (this.Contains(GetKey(k_SepnBloodID)) == false) return null;
            SeparationOfBlood ob = this[GetKey(k_SepnBloodID)];
            return (SeparationOfBlood)ob;
        }

		public SeparationOfBlood GetObjectByKey(long k_SepnBloodID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_SepnBloodID)) == false) {
				SeparationOfBlood ob = repository.GetQuery<SeparationOfBlood>().FirstOrDefault(o => o.SepnBloodID == k_SepnBloodID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            SeparationOfBlood obj = this[GetKey(k_SepnBloodID)];
            return (SeparationOfBlood)obj;
        }

		public SeparationOfBlood GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            SeparationOfBlood ob = this[keypair];
            return (SeparationOfBlood)ob;
        }

        public SeparationOfBlood GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            SeparationOfBlood ob = this[GetKey(keypair)];
            return (SeparationOfBlood)ob;
        }

		bool _LoadAll = false;
        public List<SeparationOfBlood> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<SeparationOfBlood>().ToList();
			foreach (SeparationOfBlood item in list) {
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

        ~KeyedSeparationOfBlood()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
