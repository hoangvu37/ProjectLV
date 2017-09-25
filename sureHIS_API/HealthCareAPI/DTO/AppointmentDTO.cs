using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareAPI.DTO
{
    public class AppointmentOnline
    {
        public  RegistrationInfo reg { get; set; }
        public Appointment apoi { get; set; }
    }

    public class RegistrationInfo
    {
        /// <summary>
        /// Tên
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Họ và tên đệm
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Ngày sinh dd/MM/yyyy
        /// </summary>
        public string DOB { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string MobilePhoneNumber { get; set; }
        /// <summary>
        /// Mã OTP
        /// </summary>
        public string OTP { get; set; }
        /// <summary>
        /// Số CMND/Hộ chiếu
        /// </summary>
        public string PPN { get; set; }
        /// <summary>
        /// Mã Person
        /// </summary>
        public string PersonID { get; set; }
        /// <summary>
        /// Yeu cau xac nhan bang SMS
        /// NULL | 0 khong yeu cau xac nhan bang SMS(mac dinh)
        /// 1 Yeu cau xac nhan bang SMS
        /// </summary>
        public Boolean ReqCfmBySMS { get; set; }
        
    }
    public class Appointment
    {
        /// <summary>
        /// Mã hàng đợi online
        /// </summary>
        public long? OQueueID { get; set; }
        /// <summary>
        /// Ngày đặt lịch hẹn dd/MM/yyyy
        /// </summary>
        public string ApptDate { get; set; }
        /// <summary>
        /// giờ đặt lịch hẹn
        /// </summary>
        public string AppTime { get; set; }
        /// <summary>
        /// Mã khung giờ làm việc của bác sĩ
        /// </summary>
        public long? WSID { get; set; }
        /// <summary>
        /// Mã phòng khám
        /// </summary>
        public long? WDID { get; set; }
        /// <summary>
        /// Mã khung giờ
        /// </summary>
        public long TFID { get; set; }
        public long? MedSerID { get; set; }
        /// <summary>
        /// Mã phương thức khám chữa bệnh theo yêu cầu
        /// 200	V_ApptStatus	Others	Khác 
        /// 201 New Khám mới 
        /// 202	Follow-up examination   Tái khám
        /// </summary>
        public long? V_ApptStatus { get; set; }
        /// <summary>
        /// Tình trạng thăm khám, khám mới/tái khám
        /// 7800	1	V_ApptMethod	Others	Hình thức đăng ký KCB khác 
        /// 7801	1	V_ApptMethod Direct Registration Đăng ký KCB trực tiếp 
        /// 7802	1	V_ApptMethod Online Registration Đăng ký KCB trực tuyến
        /// 7803	1	V_ApptMethod SMS Registration Đăng ký KCB qua SMS
        /// </summary>
        public long? V_ApptMethod { get; set; }
        /// <summary>
        /// Ngày đặt lịch hẹn thứ 2 dd/MM/yyyy
        /// </summary>
        public string SubApptDate { get; set; }
        /// <summary>
        /// giờ đặt lịch hẹn thứ 2
        /// </summary>
        public string SubAppTime { get; set; }
        /// <summary>
        /// Lý do khám bệnh
        /// </summary>
        public string ReasonOrSymptom { get; set; }
    }
    //public class CheckScheduleOfEmps
    //{
    //    public DateTime Date { get; set; }
    //    public TimeSpan Time { get; set; }
    //    public long WDID { get; set; }
    //    public long HosID { get; set; }
    //}
}