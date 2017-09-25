using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class R_SearchPatientByEPRs
    {
        public string PatientCode { get; set; }
        public string UPI { get; set; }
        public string BHYT { get; set; }
        public string PatientFullName { get; set; }
        public string PersYearBirthDtm { get; set; }
    }

    public class R_SearchPatientByAppointment {
        public string MobilePhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PersYearBirthDtm { get; set; }
        public string PatientFullName { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
    }

}
