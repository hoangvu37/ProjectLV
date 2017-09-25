using LV.Common;
using System;
using System.Web.Http;
using log4net;
using System.Reflection;
using LV.Service.Common;
using System.Net;
using HealthCareAPI.DTO;
using Newtonsoft.Json;
using System.Globalization;

namespace HealthCareAPI.Controllers
{
    /// <summary>
    /// Danh mục RADT -  Get
    /// </summary>
    [RoutePrefix("api/radt")]
    
    [Authorize]
    public class RADTGetController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public RADTGetController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }

        /// <summary>
        /// Lấy danh sách mã chuyên khoa của bệnh viện
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         "DeptID": 3,
        ///        "HosID": 3,
        ///        "ModifiedDate": 2017-08-07 11:49:56.523,
        ///        "MOHDeptCode":"123",
        ///        "DeptName":"Noi Than Kinh",
        ///        "HIDeptCode":"123"
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AccountID">ID tài khoản</param>
        /// <param name="HosID">Mã Bệnh Viên</param>
        /// <param name="IsTotal">Kiểm tra xem có cần trả về tổng bác sĩ không</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("GetHospitalSpecialist")]
        public IHttpActionResult GetHospitalSpecialist(long AccountID, long HosID, bool IsTotal)
        {
            try
            {
                var objName = new object[] { "AccountID", "HosID", "IsTotal", "language" };
                var objParam = new object[] { AccountID, HosID, IsTotal, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetHospitalSpecialist", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy dịch vụ trong từng chuyên khoa
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         "DeptID": 3,
        ///        "HosID": 3,
        ///        "ModifiedDate": 2017-08-07 11:49:56.523,
        ///        "MOHDeptCode":"123",
        ///        "DeptName":"Noi Than Kinh",
        ///        "HIDeptCode":"123"
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetMedicalServiceItem")]
        public IHttpActionResult GetMedicalServiceItem(GetMedicalServiceItem query)
        {
            query.Default.PageSize = query.Default.PageSize == -1 ? int.MaxValue : query.Default.PageSize;
            try
            {
                var objName = new object[] { "AccountID", "DeptID","MedSerID", "MedSerName", "QuotationIDMOHS", "QuotationHIS", " PageSize", "PageNumber", "language" };
                var objParam = new object[] { query.Default.AccountID, query.DeptID, query.MedSerID, query.MedSerName
                    , query.QuotationIDMOHS, query.QuotationHIS, query.Default.PageSize, query.Default.PageNumber, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetMedicalServiceItem", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        ///  Lấy các dịch vụ khám chữa bệnh đã được lưu dưới database
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///          "HosFeeTransID": NULL,
        ///        "EMSID": dich vu y te hay cham soc suc khoe can thanh toan hay chi tra,
        ///        "UOMID": Don vi tinh,
        ///        .......
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="HosFeeTransID"></param> 
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetHosFeeTransDetailsByPtId")]
        public IHttpActionResult GetHosFeeTransDetailsByPtId(long AccountID, long HosFeeTransID, int PageSize, int PageNumber)
        {
            try
            {
                var objName = new object[] { "AccountID", "HosFeeTransID", " PageSize", "PageNumber" };
                var objParam = new object[] { AccountID, HosFeeTransID, PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetHosFeeTransDetailsByPtId", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy thông tin chung dịch vụ KCB đã đăng ký
        /// </summary>
        /// <param name="TransID"> Transaction ID </param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetHospitalFeeTransactionByTransID")]
        public IHttpActionResult GetHospitalFeeTransactionByTransID(long TransID)
        {
            try
            {
                var objName = new object[] { "TransID" };
                var objParam = new object[] { TransID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetHospitalFeeTransactionByTransID", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="PtID"></param>
        /// <param name="AdmID"></param>
        /// <param name="PtCode"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPatientTransactionByPtID")]
        public IHttpActionResult GetPatientTransactionByPtID(long PtID, long AdmID, string PtCode = "")
        {
            try
            {
                var objName = new object[] { "PtID", "AdmID", "PtCode" };
                var objParam = new object[] { PtID, AdmID ,PtCode};
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientTransactionByPtID", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy Ghi nhan thong tin lich su phan loai benh nhan theo tung benh nhan cu the
        /// </summary>
        /// <param name="PtID"></param> ID bệnh nhân
        /// <param name="PtCode"></param> Mã bệnh nhân
        /// <returns></returns>
        [HttpPost]
        [Route("GetPatientClassHistoryByPtId")]
        public IHttpActionResult GetPatientClassHistoryByPtId(long PtID,string PtCode = "")
        {
            try
            {
                var objName = new object[] { "PtID", "PtCode" };
                var objParam = new object[] { PtID,  PtCode };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientClassHistoryByPtId", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin bác sĩ trong từng chuyên khoa
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("GetEmpAllocation")]
        public IHttpActionResult GetEmpAllocation(EmpAllocation query)
        {
            query.Default.PageSize = query.Default.PageSize == -1 ? int.MaxValue : query.Default.PageSize;
            try
            {
                var objName = new object[] { "AccountID", "DeptID","HosID", "PageSize", "PageNumber", "language" };
                var objParam = new object[] { query.Default.AccountID, query.DeptID, query.HosID, query.Default.PageSize, query.Default.PageNumber, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetEmpAllocation", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        
        /// <summary>
        /// Lấy thông tin về đặt lịch hẹn của bệnh nhân
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///          "PtId": 5,
        ///        "PtCode": "PT00001",
        ///        "ReferHosID": 1,
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AccountID">ID tài khoản</param>
        /// <param name="PtId">Mã BỆNH NHÂN</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAppointment")]
        public IHttpActionResult GetAppointment(long AccountID, long PtId)
        {
            try
            {
                var objName = new object[] { "AccountID", "PtId" };
                var objParam = new object[] { AccountID, PtId };
                var result = this.Repository.ExecuteStoreScalar("usp_GetAppointment", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        

        /// <summary>
        /// Lấy Mã SerItemsID  để lấy giá BHYT hay DV
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="IsNHI"></param> Bang gia dich vu
        /// <returns></returns>
        [HttpPost]
        [Route("GetQuotationbyIsNHI")]
        public IHttpActionResult GetQuotationbyIsNHI(long AccountID, Boolean IsNHI)
        {
            try
            {
                var objName = new object[] { "AccountID", "IsNHI" };
                var objParam = new object[] { AccountID, IsNHI };
                var result = this.Repository.ExecuteStoreScalar("usp_GetQuotationbyIsNHI", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Thêm mới và Lưu thông tin tiếp nhận/điều chuyển bệnh nhân
        /// </summary>
        /// <param name="data">AppointmentDTO như code</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateAppointment")]
        public IHttpActionResult AddUpdateAppointment(AppointmentDTO data)
        {
            try
            {

                //var objName = new object[] {"personJson","patientJson","healthInsuranceJson","patientMedRecordJson",
                //                            "medicalEncounterJSon","patientVitalSignJson","patientAdmissionJson","hIAdmissionJson",
                //                            "miscDocumentsJson","patientCommonMedRecordJson","patientTransactionJson",
                //                            "hospitalFeeTransactionJson","hosFeeTransDetailsJson","medicalClaimServiceJson",
                //                            "isHI","ConfigIsEnable","AccountID",
                var objName = new object[] {"radtFormJson", "patientMoreInforFormJson", "healthInsuranceFormJson", "FAMFormJson",
                                            /*"eprForm",*/ "reciveFormJson", "padForm", "patientVitalSignJson", /*"patientClassHistoryJson",*/
                                            "patientTransactionJson", "hospitalFeeTransactionJson", "hosFeeTransDetailsJson", "medicalClaimServiceJson",
                                            "isHI","ConfigIsEnable","AccountID"
                };
                var objParam = new object[] {
                    //JsonConvert.SerializeObject(data.Person),
                    //JsonConvert.SerializeObject(data.Patient),
                    //JsonConvert.SerializeObject(data.HealthInsurance),
                    //JsonConvert.SerializeObject(data.PatientMedRecord),
                    //JsonConvert.SerializeObject(data.MedicalEncounter),
                    JsonConvert.SerializeObject(data.RadtForm),
                    JsonConvert.SerializeObject(data.PtMoreInfor),
                    JsonConvert.SerializeObject(data.HIForm),
                    JsonConvert.SerializeObject(data.FAMForm),
                    JsonConvert.SerializeObject(data.ReciveForm),
                    JsonConvert.SerializeObject(data.PADForm),
                    JsonConvert.SerializeObject(data.PatientVitalSign),
                    //JsonConvert.SerializeObject(data.PatientAdmission),
                    //JsonConvert.SerializeObject(data.HIAdmission),
                    //JsonConvert.SerializeObject(data.MiscDocuments),
                    //JsonConvert.SerializeObject(data.PatientCommonMedRecord),
                    JsonConvert.SerializeObject(data.PatientTransaction),
                    JsonConvert.SerializeObject(data.HospitalFeeTransaction),
                    JsonConvert.SerializeObject(data.HosFeeTransDetails),
                    JsonConvert.SerializeObject(data.MedicalClaimService),
                    //JsonConvert.SerializeObject(data.HIAdmission),
                    //JsonConvert.SerializeObject(data.MiscDocuments),
                    //JsonConvert.SerializeObject(data.PatientCommonMedRecord),
                    data.isHI,
                    data.ConfigIsEnable,
                    data.AccountID
                };
                var result = this.Repository.ExecuteStoreScalar("usp_InsertUpdateAppointment", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /// <summary>
        /// Hàm get thông tin ICD10
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetICD10")]
        public IHttpActionResult GetICD10(long PageSize, long PageNumber,string language)
        {
            try
            {
                var objName = new object[] { "PageSize", "PageNumber", "language" };
                var objParam = new object[] { PageSize, PageNumber, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetICD10", objName, objParam);
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
