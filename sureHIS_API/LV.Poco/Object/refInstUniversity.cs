/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : refInstUniversity.cs         
 * Created by           : Auto - 09/11/2017 15:19:55                     
 * Last modify          : Auto - 09/11/2017 15:19:55                     
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
	public partial class refInstUniversity : BaseEntity, ICloneable	{
		public refInstUniversity()
		{
			this.InstitudeID = 0;
            this.Desc = null;
            this.CountryID = null;
            this.V_UniversityLevel = null;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("InstitudeID", InstitudeID); } }


		private long _InstitudeID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long InstitudeID { get { return _InstitudeID; } set {_InstitudeID = value; } }

		private string _InsUniversityCode;
		[LVRequired]
        [LVMaxLength(3)]
        public string InsUniversityCode { get { return _InsUniversityCode; } set {_InsUniversityCode = value; } }

		private string _NameOfInstitudeUniversity;
		[LVRequired]
        [LVMaxLength(80)]
        public string NameOfInstitudeUniversity { get { return _NameOfInstitudeUniversity; } set {_NameOfInstitudeUniversity = value; } }

		private string _Desc;
        [LVMaxLength(2048)]
        public string Desc { get { return _Desc; } set {_Desc = value; } }

		private string _Abbrev;
        [LVMaxLength(15)]
        public string Abbrev { get { return _Abbrev; } set {_Abbrev = value; } }

		private string _CountryID;
        [LVMaxLength(10)]
        public string CountryID { get { return _CountryID; } set {_CountryID = value; } }

		private long? _V_UniversityLevel;
        public long? V_UniversityLevel { get { return _V_UniversityLevel; } set {_V_UniversityLevel = value; } }

		/// <summary>
/// Ref Key: FK_EduLevel_refInstUniversity
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
    public class KeyedrefInstUniversity : KeyedCollection<KeyValuePair<string, long>, refInstUniversity>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedrefInstUniversity() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(refInstUniversity item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_InstitudeID) { return new KeyValuePair<string, long>("InstitudeID", k_InstitudeID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(refInstUniversity item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, refInstUniversity item)
        {
            refInstUniversity orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(refInstUniversity item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(refInstUniversity item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public refInstUniversity GetObjectByKey(long k_InstitudeID) 
		{
            if (this.Contains(GetKey(k_InstitudeID)) == false) return null;
            refInstUniversity ob = this[GetKey(k_InstitudeID)];
            return (refInstUniversity)ob;
        }

		public refInstUniversity GetObjectByKey(long k_InstitudeID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_InstitudeID)) == false) {
				refInstUniversity ob = repository.GetQuery<refInstUniversity>().FirstOrDefault(o => o.InstitudeID == k_InstitudeID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            refInstUniversity obj = this[GetKey(k_InstitudeID)];
            return (refInstUniversity)obj;
        }

		public refInstUniversity GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            refInstUniversity ob = this[keypair];
            return (refInstUniversity)ob;
        }

        public refInstUniversity GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            refInstUniversity ob = this[GetKey(keypair)];
            return (refInstUniversity)ob;
        }

		bool _LoadAll = false;
        public List<refInstUniversity> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<refInstUniversity>().ToList();
			foreach (refInstUniversity item in list) {
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

        ~KeyedrefInstUniversity()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
