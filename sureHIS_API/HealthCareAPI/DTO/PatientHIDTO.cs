using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareAPI.DTO
{
   
    public class PatientHIDTO
    {
        public string HICode { get; set; } = "";
        public string PersName { get; set; } = "";
        public DateTime? BOD { get; set; } = null;
        public int? Gender { get; set; } = null;
        public string Address { get; set; } = "";
        public string HosCode { get; set; } = "";
        public int HosID { get; set; }
        public string HosAddress { get; set; } = "";
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;
        /// <summary>
        public string PersonalBHCode { get; set; } = "";
        public string FamilyName { get; set; } = "";
        public int? CountryCode { get; set; } = null;

        public DateTime? FiveYear { get; set; } = null;
        public string CheckedBH { get; set; } = null;
        public string InsInterestsCode { get; set; } = "";
        public double RebatePercentage { get; set; } = 0;
        public int IBID { get; set; } = 0;
        public int InsCoID { get; set; } = 1;
        public bool IsOverFiveYear { get; set; } = false;
    }
}