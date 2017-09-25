/* Lac Viet ERP                                                
 * Copyright (c) 2013 Lac Viet                                 
 * http://www.lacviet.com.vn                                   
 *=============================================================
 * File name            : Person.cs         
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
	public partial class Person : BaseEntity, ICloneable	{
		public Person()
		{
			this.PersonID = 0;
            this.PersName = null;
            this.AgeOnly = false;
            this.Age = null;
            this.POB = null;
			this.PersGenderCode = 0;
			this.EthnicID = 0;
			this.PersRaceCode = 0;
			this.PtReligionCode = 0;
            this.OtherPersonDetails = null;
            this.NativeLand = null;
            this.LandLine = null;
            this.PersHomePhonePhN = null;
            this.sQRCode = null;
            this.uQRCode = null;
            this.IDNumber = null;
            this.PPN = null;
            this.PlaceOfIssue = null;
			this.PersEducationalLevelCode = 0;
			this.PersMaritalStatusCode = 0;
			this.PersonType = 0;
            this.V_IndivLivingArrID = null;
            this.NationnalityCode = "VN";
            this.Stop = false;
            this.CreatedDate = DateTime.Now;
		}

	    #region Properties
		[NotMapped]
		public KeyValuePair<string, long> Key { get { return new KeyValuePair<string, long>("PersonID", PersonID); } }


		private long _PersonID;

        [Key]
		[LVRegularExpression(@"[a-zA-Z0-9.,+_-]*")]
		[LVRequired]
        public long PersonID { get { return _PersonID; } set {_PersonID = value; } }

		private string _FirstName;
        [LVMaxLength(15)]
        public string FirstName { get { return _FirstName; } set {_FirstName = value; } }

		private string _MiddleName;
        [LVMaxLength(64)]
        public string MiddleName { get { return _MiddleName; } set {_MiddleName = value; } }

		private string _LastName;
        [LVMaxLength(32)]
        public string LastName { get { return _LastName; } set {_LastName = value; } }

		private string _PersName;
		[LVRequired]
        [LVMaxLength(128)]
        public string PersName { get { return _PersName; } set {_PersName = value; } }

		private DateTime _PersBirthDtm;
		[LVRequired]
        public DateTime PersBirthDtm { get { return _PersBirthDtm; } set {_PersBirthDtm = value; } }

		private bool? _AgeOnly;
        public bool? AgeOnly { get { return _AgeOnly; } set {_AgeOnly = value; } }

		private short? _Age;
        public short? Age { get { return _Age; } set {_Age = value; } }

		private string _POB;
        [LVMaxLength(128)]
        public string POB { get { return _POB; } set {_POB = value; } }

		private long _PersGenderCode;
		[LVRequired]
        public long PersGenderCode { get { return _PersGenderCode; } set {_PersGenderCode = value; } }

		private long? _EthnicID;
        public long? EthnicID { get { return _EthnicID; } set {_EthnicID = value; } }

		private long? _PersRaceCode;
        public long? PersRaceCode { get { return _PersRaceCode; } set {_PersRaceCode = value; } }

		private long? _PtReligionCode;
        public long? PtReligionCode { get { return _PtReligionCode; } set {_PtReligionCode = value; } }

		private string _ProfilePhoto;
        [LVMaxLength(512)]
        public string ProfilePhoto { get { return _ProfilePhoto; } set {_ProfilePhoto = value; } }

		private string _OtherPersonDetails;
        [LVMaxLength(1024)]
        public string OtherPersonDetails { get { return _OtherPersonDetails; } set {_OtherPersonDetails = value; } }

		private string _NativeLand;
        [LVMaxLength(64)]
        public string NativeLand { get { return _NativeLand; } set {_NativeLand = value; } }

		private string _PersPermanentAddressText;
        [LVMaxLength(254)]
        public string PersPermanentAddressText { get { return _PersPermanentAddressText; } set {_PersPermanentAddressText = value; } }

		private string _CountryID;
        [LVMaxLength(2)]
        public string CountryID { get { return _CountryID; } set {_CountryID = value; } }

		private string _CityProvinceID;
        [LVMaxLength(2)]
        public string CityProvinceID { get { return _CityProvinceID; } set {_CityProvinceID = value; } }

		private string _DistrictID;
        [LVMaxLength(3)]
        public string DistrictID { get { return _DistrictID; } set {_DistrictID = value; } }

		private string _WardID;
        [LVMaxLength(5)]
        public string WardID { get { return _WardID; } set {_WardID = value; } }

		private string _LandLine;
        [LVMaxLength(15)]
        public string LandLine { get { return _LandLine; } set {_LandLine = value; } }

		private string _PersHomePhonePhN;
        [LVMaxLength(15)]
        public string PersHomePhonePhN { get { return _PersHomePhonePhN; } set {_PersHomePhonePhN = value; } }

		private string _EmailAddress;
        [LVMaxLength(80)]
        public string EmailAddress { get { return _EmailAddress; } set {_EmailAddress = value; } }

		private string _sQRCode;
        [LVMaxLength(30)]
        public string sQRCode { get { return _sQRCode; } set {_sQRCode = value; } }

		private string _uQRCode;
        [LVMaxLength(512)]
        public string uQRCode { get { return _uQRCode; } set {_uQRCode = value; } }

		private string _IDNumber;
        [LVMaxLength(12)]
        public string IDNumber { get { return _IDNumber; } set {_IDNumber = value; } }

		private string _PPN;
        [LVMaxLength(15)]
        public string PPN { get { return _PPN; } set {_PPN = value; } }

		private string _PlaceOfIssue;
        [LVMaxLength(64)]
        public string PlaceOfIssue { get { return _PlaceOfIssue; } set {_PlaceOfIssue = value; } }

		private long? _PersEducationalLevelCode;
        public long? PersEducationalLevelCode { get { return _PersEducationalLevelCode; } set {_PersEducationalLevelCode = value; } }

		private long? _PersMaritalStatusCode;
        public long? PersMaritalStatusCode { get { return _PersMaritalStatusCode; } set {_PersMaritalStatusCode = value; } }

		private short _PersonType;
		[LVRequired]
        public short PersonType { get { return _PersonType; } set {_PersonType = value; } }

		private long? _V_IndivLivingArrID;
        public long? V_IndivLivingArrID { get { return _V_IndivLivingArrID; } set {_V_IndivLivingArrID = value; } }

		private string _NationnalityCode;
		[LVRequired]
        [LVMaxLength(2)]
        public string NationnalityCode { get { return _NationnalityCode; } set {_NationnalityCode = value; } }

		private bool _Stop;
        public bool Stop { get { return _Stop; } set {_Stop = value; } }

		private DateTime _CreatedDate;
		[LVRequired]
        public DateTime CreatedDate { get { return _CreatedDate; } set {_CreatedDate = value; } }

		private string _CreatedBy;
        [LVMaxLength(20)]
        public string CreatedBy { get { return _CreatedBy; } set {_CreatedBy = value; } }

		private DateTime? _LastUpdDate;
        public DateTime? LastUpdDate { get { return _LastUpdDate; } set {_LastUpdDate = value; } }

		private string _LastUpdBy;
        [LVMaxLength(20)]
        public string LastUpdBy { get { return _LastUpdBy; } set {_LastUpdBy = value; } }

		/// <summary>
/// Ref Key: FK_EduLevel_Person
/// <summary>
/// <summary>
/// Ref Key: FK_Employee_Person
/// <summary>
/// <summary>
/// Ref Key: FK_Employeer_Person
/// <summary>
/// <summary>
/// Ref Key: FK_HCStakeholder_Person
/// <summary>
/// <summary>
/// Ref Key: FK_LanguageLevel_Person
/// <summary>
/// <summary>
/// Ref Key: FK_NetworkGuestAccount_Person
/// <summary>
/// <summary>
/// Ref Key: FK_NextOfKins_Person
/// <summary>
/// <summary>
/// Ref Key: FK_Patient_Person
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refCountry
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refDistrict
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refEducationalLevel
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refElthnic
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refPersGender
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refPersMaritalStatus
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refPersRace
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refProvince
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refReligion
/// <summary>
/// <summary>
/// Ref Key: FK_Person_refWard
/// <summary>
/// <summary>
/// Ref Key: FK_PersonRole_Person
/// <summary>
/// <summary>
/// Ref Key: FK_UserAccount_Person
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
    public class KeyedPerson : KeyedCollection<KeyValuePair<string, long>, Person>, ICloneable, IDisposable
    {
        #region Constructor
        public KeyedPerson() : base() { }

        protected override KeyValuePair<string, long> GetKeyForItem(Person item)
        {
            return item.Key;
        }

        public KeyValuePair<string, long> GetKey(long k_PersonID) { return new KeyValuePair<string, long>("PersonID", k_PersonID); }

        public KeyValuePair<string, long> GetKey(object keypair) { try { return (KeyValuePair<string, long>)keypair; } catch { return new KeyValuePair<string, long>(); } }
        #endregion

        #region Method
        public bool AddObject(Person item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Add(item);

            return true;
        }

        public bool ChangeItem(KeyValuePair<string, long> keypair, Person item)
        {
            Person orig = this.GetObjectByKey(keypair);
            if (orig != null)
            {
                int index = this.IndexOf(orig);
                this.SetItem(index, item);

                return true;
            }

            return false;
        }

		public bool UpdateObject(Person item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Delete(item);
            
            return true;
        }

		public bool DeleteObject(Person item, LV.Core.DAL.Base.IRepository repository)
        {
            repository.Update(item);
            
            return true;
        }

		public Person GetObjectByKey(long k_PersonID) 
		{
            if (this.Contains(GetKey(k_PersonID)) == false) return null;
            Person ob = this[GetKey(k_PersonID)];
            return (Person)ob;
        }

		public Person GetObjectByKey(long k_PersonID, LV.Core.DAL.Base.IRepository repository) 
		{
            if (this.Contains(GetKey(k_PersonID)) == false) {
				Person ob = repository.GetQuery<Person>().FirstOrDefault(o => o.PersonID == k_PersonID);
				if(ob != null) this.Add(ob);
				return ob;
			}
            Person obj = this[GetKey(k_PersonID)];
            return (Person)obj;
        }

		public Person GetObjectByKey(KeyValuePair<string, long> keypair) 
		{
            if (this.Contains(keypair) == false) return null;
            Person ob = this[keypair];
            return (Person)ob;
        }

        public Person GetObjectByKey(object keypair)
        {
            if (this.Contains(GetKey(keypair)) == false) return null;
            Person ob = this[GetKey(keypair)];
            return (Person)ob;
        }

		bool _LoadAll = false;
        public List<Person> LoadAll(LV.Core.DAL.Base.IRepository repository)
        {
			if(_LoadAll) return this.ToList();
			var list = repository.GetQuery<Person>().ToList();
			foreach (Person item in list) {
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

        ~KeyedPerson()
        {
            Dispose(false);
        }
       
        #endregion
        
    }

}
