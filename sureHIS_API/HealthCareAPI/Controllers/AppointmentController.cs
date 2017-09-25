using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LV.Common;
using System.Web.Http.Routing;
using System.Reflection;
using log4net;
using HealthCareAPI.DTO;
using System.Globalization;
using System.Data;

namespace HealthCareAPI.Controllers
{
    [RoutePrefix("api/appointment")]
    [AllowAnonymous]
    public class AppointmentController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        private string language = string.Empty;
        private string accountid = string.Empty;
        SendMailController _sendmail;
        public AppointmentController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
            accountid = GetUserAccount();
            _sendmail = new SendMailController();
        }
        /// <summary>
        /// Thông tin nhập viện(Thăm khám, Cấp cứu, Chẩn đoán CLS)
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         HCFEDispDiagICDCode: null,//ID Cha
        ///         HCFEDispDispDtm: null, //Mã Function
        ///         V_ConsultStatus: null,//Mã ID cấp cha
        ///         PreDiagnosis: null,//Tiêu đề
        ///         HCFEncEncAdmDtm: null,//Mô tả
        ///         HCFEncEncDisDtm: null,
        ///         YearEncAdmDtm: null,
        ///         isInPtTX: null,
        ///         V_EmergencyMedStatus: null,
        ///         V_EmergencyMedStatusName: null,
        ///         PtBarCode: null,
        ///         PtCode: null,
        ///         PtQRcode: null,
        ///         MedReportBookCode: null,
        ///         NationalMedicalCode: null,
        ///         PtRecQRCode: null
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="PtId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMedicalEncounterByPtId")]
        public IHttpActionResult GetMedicalEncounterByPtId(long AccountID, long PtId)
        {
            try
            {
                var objNames = new object[] { "AccountID", "PtId", "language" };
                var objValues = new object[] { AccountID, PtId, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetMedicalEncounterByPtId", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Thông tin sử dụng dịch vụ cận lâm sàng của từng bênh nhân
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="PtId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParaClinicalReqDetailsByPtId")]
        public IHttpActionResult GetParaClinicalReqDetailsByPtId(long AccountID, long PtId)
        {
            try
            {
                var objNames = new object[] { "AccountID", "PtId" };
                var objValues = new object[] { AccountID, PtId };
                var result = this.Repository.ExecuteStoreScalar("usp_GetParaClinicalReqDetailsByPtId", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Phát sinh mã tiếp nhận
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     PtAdmNo: "2017.000001"//mã tiếp nhận
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="HosID"></param>
        /// <param name="IsInPatient"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GenPtAdmNo")]
        public IHttpActionResult GenPtAdmNo(long AccountID, long HosID, bool IsInPatient)
        {
            try
            {
                var objNames = new object[] { "AccountID", "nHosID", "bIsInPatient" };
                var objValues = new object[] { AccountID, HosID, IsInPatient };
                var result = this.Repository.ExecuteStoreScalar("usp_GenPtAdmNo", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Phát sinh mã số bệnh nhân
        /// </summary>
        /// <remarks>
        /// <code>
        ///     [{
        ///         PtCode: "0840270000000004.78691496"//mã bệnh nhân
        ///     }]
        /// </code>
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="HosID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GenPtCode")]
        public IHttpActionResult GenPtCode(long AccountID, long HosID)
        {
            try
            {
                var objNames = new object[] { "AccountID", "nHosID" };
                var objValues = new object[] { AccountID, HosID };
                var result = this.Repository.ExecuteStoreScalar("usp_GenPtCode", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Phát sinh Mã số Sổ khám bệnh
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     MedReportBookCode: "Mã số sổ khám bệnh"
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="AccountID">ID tài khoản</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GenMedReportBookCode")]
        public IHttpActionResult GenMedReportBookCode(long AccountID)
        {
            try
            {
                var objNames = new object[] { "AccountID", };
                var objValues = new object[] { AccountID, };
                var result = this.Repository.ExecuteStoreScalar("usp_GenMedReportBookCode", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy trạng thái lịch bận/rảnh của bác sĩ theo khung thời gian trong một ngày
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="EmpID">Mã nhân viên</param>
        /// <param name="Date">Ngày cần lấy</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmpWorkSchedule")]
        public IHttpActionResult GetEmpWorkSchedule(long AccountID, long EmpID, string Date)
        {
            try
            {
                DateTime _date = new DateTime();
                _date = DateTime.Parse(Date, culture);
                var objName = new object[] { "AccountID", "EmpID", "Date" };
                var objParam = new object[] { AccountID, EmpID, _date };
                var result = this.Repository.ExecuteStoreScalar("usp_GetEmpWorkSchedule", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy lịch bận/rảnh trong một tháng của một nhân viên/Bác sĩ
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="EmpID"></param>
        /// <param name="Date">1 Ngày trong tháng</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmpWorkCalendar")]
        public IHttpActionResult GetEmpWorkCalendar(long AccountID, long EmpID, string Date)
        {
            try
            {
                DateTime _date = new DateTime();
                _date = DateTime.Parse(Date, culture);
                var objName = new object[] { "AccountID", "EmpID", "Date" };
                var objParam = new object[] { AccountID, EmpID, _date };
                var result = this.Repository.ExecuteStoreScalar("usp_GetEmpWorkCalendar", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Danh sách chuyên khoa khám chữa bệnh ngoại trú
        /// </summary>
        /// <param name="HosID">Mã bệnh viện</param>
        /// <param name="DeptID">Mã chuyên khoa</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetScheduleOfSpecialist")]
        public IHttpActionResult GetScheduleOfSpecialist(long HosID ,long DeptID = 0)
        {
            try
            {
                var objName = new object[] { "HosID", "DeptID", "language" };
                var objParam = new object[] { HosID, DeptID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetScheduleOfSpecialist", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh sách các nhân viên trong bệnh viên hỗ trợ đăng ký khám chữa bệnh online
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     "PersName": "Bá Văn Hoàng Khanh"//Full name,
        ///     "EmpID": 186 // Mã nhân viên,
        ///     "HosDeptID": 66 //Mã chuyên khoa,
        ///     "EmpCode": "EMP-186"//Mã code của nhân viên,
        ///     "ProfilePhoto": "bvhkhanh.png"//Avatar,
        ///     "DeptName": "Khoa Tai mũi họng"//Tên chuyên khoa,
        ///     "AcademicName": null//Tên học vị học hàm,
        ///     "JTName": "[Certified Nursing Assistant]"//Tên chức danh
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="HosID">Mã bệnh viện</param>
        /// <param name="DeptID">Mã chuyên khoa</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAppointmentEmployee")]
        public IHttpActionResult GetAppointmentEmployee(long HosID, long DeptID = 0)
        {
            try
            {
                var objName = new object[] { "HosID", "DeptID", "language" };
                var objParam = new object[] { HosID, DeptID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetAppointmentEmployee", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /// <summary>
        /// Đăng ký khám bệnh Online
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     ReturnCode: "",//Mã lỗi của hàm
        ///     //0: thành công
        ///     //70: Lỗi của hệ thống không xác định
        ///     //71: Sai thông tin của bệnh nhân
        ///     //72: Không thể phát sinh hàng đợi
        ///     //73: Không thể đky kcb
        ///     //74: Đã bị trùng khung giờ, vui lòng đky lại
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="apointOnline"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegAppointmentOnline")]
        public IHttpActionResult RegAppointmentOnline(AppointmentOnline apointOnline)
        {
            try
            {
                object DOB = null, ApptDate = null, SubApptDate = null;
                DOB = DateTime.Parse(apointOnline.reg.DOB.ToString(), culture);
                ApptDate = DateTime.Parse(apointOnline.apoi.ApptDate.ToString(), culture);
                if (apointOnline.apoi.SubApptDate != null)
                    SubApptDate = DateTime.Parse(apointOnline.apoi.SubApptDate.ToString(), culture);

                object AppTime = null, SubAppTime = null;
                AppTime = apointOnline.apoi.AppTime;
                SubAppTime = apointOnline.apoi.SubAppTime;
                //if (!string.IsNullOrWhiteSpace(apointOnline.apoi.AppTime))
                //    AppTime = TimeSpan.Parse(apointOnline.apoi.AppTime, culture);
                //if (!string.IsNullOrWhiteSpace(apointOnline.apoi.SubAppTime))
                //    SubAppTime = TimeSpan.Parse(apointOnline.apoi.SubAppTime, culture);

                var objName = new object[] { "LastName", "FirstName", "MobilePhoneNumber", "EmailAddress", "DOB"
                    , "PPN", "ReqCfmBySMS", "OTP", "ApptDate", "AppTime", "WSID", "WDID", "TFID", "MedSerID", "V_ApptStatus"
                    , "SubApptDate", "SubAppTime", "ReasonOrSymptom", "PersonID" };
                var objParam = new object[] {apointOnline.reg.LastName, apointOnline.reg.FirstName, apointOnline.reg.MobilePhoneNumber
                    , apointOnline.reg.EmailAddress, DOB, apointOnline.reg.PPN, apointOnline.reg.ReqCfmBySMS
                    , apointOnline.reg.OTP, ApptDate, AppTime , apointOnline.apoi.WSID, apointOnline.apoi.WDID
                    , apointOnline.apoi.TFID, apointOnline.apoi.MedSerID, apointOnline.apoi.V_ApptStatus
                    , SubApptDate, SubAppTime, apointOnline.apoi.ReasonOrSymptom, apointOnline.reg.PersonID };
                var result = this.Repository.ExecuteStoreScalar("usp_RegAppointmentOnline", objName, objParam);

                if (result != null)
                {
                    foreach (DataRow dr in result.Tables[0].Rows)
                    {
                        if (dr["ReturnCode"].ToString() == "0")
                        {

                            string to = apointOnline.reg.EmailAddress;
                            string subject = "Đăng Ký KCB Thành Công";
                            _sendmail.RegistrationInfoSuccess(to, subject, apointOnline.apoi, apointOnline.apoi.ApptDate, apointOnline.apoi.AppTime
                                ,"khoa" , apointOnline.reg.LastName + "" + apointOnline.reg.FirstName, apointOnline.reg);
                        }
                        break;
                    }
                }
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Kiểm tra khung giờ làm việc có thỏa điểu kiện không?
        /// </summary>
        /// <param name="Date">Ngày đky khám bênh dd/MM/yyyy</param>
        /// <param name="Time">khung giờ đăng ký khám bênh</param>
        /// <param name="HosDeptID">Mã Chuyên khoa</param>
        /// <param name="HosID">Mã bệnh viện</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckScheduleOfEmps")]
        public IHttpActionResult CheckScheduleOfEmps(string Date, string Time, long HosID, long HosDeptID = 0)
        {
            
            try
            {
                object _Date = null;
                _Date = DateTime.Parse(Date, culture);
                DateTime _date = new DateTime();
                _date = DateTime.Parse(Date, culture);
                var objName = new object[] { "Date", "Time", "HosDeptID", "HosID" };
                var objParam = new object[] { _Date, Time, HosDeptID, HosID };
                var result = this.Repository.ExecuteStoreScalar("usp_CheckScheduleOfEmps", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Danh sách lịch bận của các bác sĩ chuyên khoa
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     PersName: "Full name của bác sĩ",
        ///     EmpID: "Mã bác sĩ",
        ///     HosID: "Mã bệnh viên",
        ///     DeptID:  "Mã chuyên khoa của bác sĩ",
        ///     DateOfBusy: //Danh sách ngày bận
        ///     [{
        ///         DateObserved: "Ngày bận của bác sĩ",
        ///     }]
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="HosID">Mã bệnh viện</param>
        /// <param name="DeptID">Mã chuyên khoa</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmpBusySchedule")]
        public IHttpActionResult GetEmpBusySchedule(long HosID, long DeptID = 0)
        {

            try
            {
                var objName = new object[] {"HosID", "DeptID", "language" };
                var objParam = new object[] { HosID, DeptID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetEmpBusySchedule", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lịch làm việc hàng tuần của từng chuyên khoa-Bệnh viện
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     "WorkingSked": 1 //Mã lịch làm việc, 
        ///     "DeptID": null //Mã chuyên khoa,
        ///     "HosDeptID": null//Mã,
        ///     "HosID": 1//Mã bệnh viện,
        ///     "V_DayName": "Chủ Nhật" //Ngày trong tuần,
        ///     "SID": 4 //Mã ca làm việc,
        ///     "Notes": "Lịch làm việc và giao dịch của bệnh viện" //Ghi chú,
        ///     "StartTime": "08:00:00" //Giờ bắt đầu,
        ///     "EndTime": "12:00:00" //Giờ kết thúc,
        ///     "ShiftName": "Weekend Shift"//Ca làm việc,
        ///     "isNotEffect": null//Hiệu lực,
        ///     "DeptName": null//Tên chuyên khoa
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="HosID">Mã bệnh viện</param>
        /// <param name="DeptID">Mã chuyên khoa</param>
        /// <param name="IsHos">Default true: Lấy lịch làm việ của bệnh viện/ false: lấy lịch làm việc của từng chuyên khoa</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetScheduleOfSpecialById")]
        public IHttpActionResult GetScheduleOfSpecialById(long HosID, long DeptID = 0, Boolean IsHos = true)
        {

            try
            {
                var objName = new object[] { "HosID", "DeptID", "language" , "IsHos" };
                var objParam = new object[] { HosID, DeptID, language, IsHos };
                var result = this.Repository.ExecuteStoreScalar("usp_GetScheduleOfSpecialById", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lịch làm trong tuần của một chuyên khoa (thứ, ca, danh sách nhân viên)
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     V_DayName: ""//Thứ trong tuần,
        ///     JsonDetails: ""//Chi tiết lịch
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetScheduleSpecialDetails")]
        public IHttpActionResult GetScheduleSpecialDetails(long DeptID)
        {

            try
            {
                var objName = new object[] { "DeptID", "language" };
                var objParam = new object[] { DeptID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetScheduleSpecialDetails", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        

    }
}
