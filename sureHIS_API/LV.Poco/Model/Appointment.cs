using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class AppointmentModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int Sex { get; set; }
        public long? WDID { get; set; }
        public long? PtID { get; set; }
        public long? HosID { get; set; }
        /// <summary>
        /// Mã nhân viên bác sĩ
        /// </summary>
        public long? WSID { get; set; }
        /// <summary>
        /// Khung giờ khám
        /// </summary>
        public Int16? TFID { get; set; }
        /// <summary>
        /// Tình trang bênh nhân 201 khám mới;202 tái khám
        /// </summary>
        public long V_ApptStatus { get; set; }
        /// <summary>
        /// Ngày đăng ký
        /// </summary>
        public string ApptDate { get; set; }
        public string BirthDate { get; set; }
        public string DepName { get; set; }
        public string PersName { get; set; }
        public string ApptDateTime { get; set; }
        public string ApptSubDateTime { get; set; }
        public string AppTime { get; set; }
        public string SubApptDate{ get; set; }
        public string SubAppTime { get; set; }
        public string IDNumber { get; set; }
        public string PPN { get; set; }
        public bool? ReqCfmBySMS { get; set; }
        public string OTP { get; set; }
        public long V_RegMethod { get; set; }

        public string ReasonOrSymptom { get; set; }
    }
}
