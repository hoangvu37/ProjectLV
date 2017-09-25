using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class DemographicsInfo
    {
        public long PtId { get; set; }
        public string PtCode { get; set; }
        public string PtBarCode { get; set; }
        public string PtQRcode { get; set; }
        public string PtUniversalHealthNum { get; set; }
        public DateTime DateBecamePt { get; set; }
        public string PtNotes { get; set; }
        public long OccupationCode { get; set; }
        public string FContactFullName { get; set; }
        public string FAMMbrRelationshipCode { get; set; }
        public string FContactAddress { get; set; }
        public string FContactHomePhone { get; set; }
        public string FContactBusinessPhone { get; set; }
        public string FContactCellPhone { get; set; }
        public string FAlternateContact { get; set; }
        public string FAlternatePhone { get; set; }
        public long? BloodTypeID { get; set; }
        public DateTime PtEarliestEntryDtm { get; set; }
        public DateTime PtLatestEntryDtm { get; set; }
        private long _PersonID;
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersName { get; set; }
        public DateTime PersBirthDtm { get; set; }
        public bool? AgeOnly { get; set; }
        public string POB { get; set; }
        public long PersGenderCode { get; set; }
        public long? EthnicID { get; set; }
        public long? PersRaceCode { get; set; }
        public long? PtReligionCode { get; set; }
        public string ProfilePhoto { get; set; }
        public string OtherPersonDetails { get; set; }
        public string NativeLand { get; set; }
        public string PersPermanentAddressText { get; set; }
        public string CountryID { get; set; }
        public string CityProvinceID { get; set; }
        public string DistrictID { get; set; }
        public string WardID { get; set; }
        public string LandLine { get; set; }
        public string PersHomePhonePhN { get; set; }
        public string EmailAddress { get; set; }
        public string sQRCode { get; set; }
        public string uQRCode { get; set; }
        public string IDNumber { get; set; }
        public string PPN { get; set; }
        public string PlaceOfIssue { get; set; }
        public long? PersEducationalLevelCode { get; set; }
        public long? PersMaritalStatusCode { get; set; }
        public short PersonType { get; set; }
        public long? V_IndivLivingArrID { get; set; }
        public string NationnalityCode { get; set; }
    }
}
