/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : PersonalProperty.cs         
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
	public partial class PersonalProperty : BaseEntity, ICloneable	{
		public PersonalProperty()
		{
			this.PerProID = 0;
            this.Taste = null;
            this.Height = null;
            this.Weight = null;
            this.UOMS = null;
            this.HealthStatus = null;
            this.Personality = null;
            this.Physiognomy = null;
            this.BloodGroup = null;
            this.Aptitude = null;
			this.EmpID = 0;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PerProID", PerProID); } }


		private long _PerProID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PerProID { get { return _PerProID; } set {_PerProID = value; } }

		private string _Taste;
        [LVMaxLength(128)]
        public string Taste { get { return _Taste; } set {_Taste = value; } }

		private double? _Height;
        public double? Height { get { return _Height; } set {_Height = value; } }

		private double? _Weight;
        public double? Weight { get { return _Weight; } set {_Weight = value; } }

		private byte? _UOMS;
        public byte? UOMS { get { return _UOMS; } set {_UOMS = value; } }

		private string _HealthStatus;
        [LVMaxLength(128)]
        public string HealthStatus { get { return _HealthStatus; } set {_HealthStatus = value; } }

		private string _Personality;
        [LVMaxLength(128)]
        public string Personality { get { return _Personality; } set {_Personality = value; } }

		private string _Physiognomy;
        [LVMaxLength(128)]
        public string Physiognomy { get { return _Physiognomy; } set {_Physiognomy = value; } }

		private string _BloodGroup;
        [LVMaxLength(10)]
        public string BloodGroup { get { return _BloodGroup; } set {_BloodGroup = value; } }

		private string _Aptitude;
        [LVMaxLength(128)]
        public string Aptitude { get { return _Aptitude; } set {_Aptitude = value; } }

		private long? _EmpID;
        public long? EmpID { get { return _EmpID; } set {_EmpID = value; } }

		/// <summary>
/// Ref Key: FK_PersonalProperty_Employee
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
    public class KeyedPersonalProperty : KeyedCollection<KeyValuePair<string, long>, PersonalProperty>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPersonalProperty() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(PersonalProperty item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PerProID) { return new KeyValuePair<string, long>("PerProID", k_PerProID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(PersonalProperty item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, PersonalProperty item)
        {
            PersonalProperty orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(PersonalProperty item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(PersonalProperty item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public PersonalProperty GetObjectByKey(long k_PerProID) 
		{
            if (this.Contains(GetKey(k_PerProID)) == false) return null;
            PersonalProperty ob = this[GetKey(k_PerProID)];
            return (PersonalProperty)ob;
        }

		public PersonalProperty GetObjectByKey(long k_PerProID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PerProID)) == false) {
				PersonalProperty ob = repository.GetQuery<PersonalProperty>().FirstOrDefault(o => o.PerProID == k_PerProID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            PersonalProperty obj = this[GetKey(k_PerProID)];
            return (PersonalProperty)obj;
        }

		public PersonalProperty GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            PersonalProperty ob = this[keypair];
            return (PersonalProperty)ob;
        }

        public PersonalProperty GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            PersonalProperty ob = this[GetKey(keypair)];
            return (PersonalProperty)ob;
        }

		bool _LoadAll = false;
        public List<PersonalProperty> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<PersonalProperty>().ToList();
			foreach (PersonalProperty item in list) {
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

        ~KeyedPersonalProperty()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
