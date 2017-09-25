using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class Register
    {
        public string PatientCode { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PersHomePhonePhN { get; set; }
        public string PhoneHeaderID { get; set; }
        public string EmailAddress { get; set; }
        public long PersGenderCode { get; set; }
        public string PersBirthDtm { get; set; }
        public string Password { get; set; }
        public long HosID { get; set; }
    }
}
