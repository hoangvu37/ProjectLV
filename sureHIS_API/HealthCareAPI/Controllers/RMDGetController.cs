using LV.Common;
using System;
using System.Web.Http;
using log4net;
using System.Reflection;
using LV.Service.Common;
using System.Net;
using HealthCareAPI.DTO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace HealthCareAPI.Controllers
{
    [RoutePrefix("api/rmd")]
    [AllowAnonymous]
    //[Authorize]
    public class RMDGetController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public RMDGetController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
        /// <summary>
        /// Lấy danh sách Application
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         PAppFuncID: null,//ID Cha
        ///         AppFuncID: 1, //Mã Function
        ///         AppFunctions: PAS,//Mã ID cấp cha
        ///         AppTitle: Title,//Tiêu đề
        ///         AppDesc: AppDesc,//Mô tả
        ///         LandingPageURL: null,
        ///         ColorSchema: null,
        ///         IconPath: null,
        ///         Badge: null,
        ///         IsLongTile: null,
        ///         Idx: null,
        ///         NotDisplayed: null,
        ///         FuncType: M,
        ///         level: 0,
        ///         Total: 145
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns> 
        [Route("GetApplication")]
        [HttpGet]
        public IHttpActionResult GetApplication(int PageSize = 1, int PageNumber = 1)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetApplication", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách tỉ giá chuyển đổi
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetForeignExchange")]
        [HttpGet]
        public IHttpActionResult GetForeignExchange(int PageSize, int PageNumber)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetForeignExchange", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách các công ty bảo hiểm
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetInsuranceCompany")]
        [HttpGet]
        public IHttpActionResult GetInsuranceCompany(int PageSize, int PageNumber)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetInsuranceCompany", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách mô hình công việc
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetJobModel")]
        [HttpGet]
        public IHttpActionResult GetJobModel(int PageSize, int PageNumber)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetJobModel", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex){
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách tổ chức phi chính phủ
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <param name="AccountID">AccountID</param>
        /// <returns></returns>
        [Route("GetOrganization")]
        [HttpGet]
        public IHttpActionResult GetOrganization(int PageSize, int PageNumber, long AccountID)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber", "AccountID" };
                var objValues = new object[] { PageSize, PageNumber, AccountID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetOrganization", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách phân loại đối tượng bệnh nhân
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <param name="AccountID">AccountID</param>
        /// <returns></returns>
        [Route("GetPatientClassification")]
        [HttpGet]
        public IHttpActionResult GetPatientClassification(int PageSize, int PageNumber, long AccountID)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber", "AccountID" };
                var objValues = new object[] { PageSize, PageNumber, AccountID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientClassification", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách PerApplication
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetPerApplication")]
        [HttpGet]
        public IHttpActionResult GetPerApplication(int PageSize, int PageNumber)
        {

            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPerApplication", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh mục loại nhân viên
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <param name="AccountID">số trang hiện tại</param>s
        /// <returns></returns>
        [Route("GetRefAdmissionType")]
        [HttpGet]
        public IHttpActionResult GetRefAdmissionType(int PageSize, int PageNumber, long AccountID)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber", "AccountID" };
                var objValues = new object[] { PageSize, PageNumber, AccountID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefAdmissionType", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy  danh mục loại giới thiệu
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefAdmReferralType")]
        [HttpGet]
        public IHttpActionResult GetRefAdmReferralType(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefAdmReferralType", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách cấu hình
        /// </summary>
        /// <param name="AccountID">Mã tài khoản</param>
        /// <param name="ConfigItemKey">Tên khóa config</param>
        /// <returns></returns>
        [Route("GetRefAppConfig")]
        [HttpGet]
        public IHttpActionResult GetRefAppConfig(long AccountID, string ConfigItemKey = "")
        {
            try
            {
                var objNames = new object[] { "AccountID" , "ConfigItemKey" };
                var objValues = new object[] { AccountID, ConfigItemKey };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefAppConfig", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh mục nhóm máu
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefBloodType")]
        [HttpGet]
        public IHttpActionResult GetRefBloodType(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber"};
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefBloodType", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh mục các loại chứng chỉ, chứng nhận
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefCertification")]
        [HttpGet]
        public IHttpActionResult GetRefCertification(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefCertification", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// lấy danh mục tỉnh/thành phố
        /// </summary>
        /// <param name="PageSize"></param> Số hàng trong một trang
        /// <param name="PageNumber"></param> số trang
        /// <param name="CountryID"></param> Mã quốc gia 2 ký tự
        /// <param name="OrderByName"></param>Tên trường dữ liệu cần sort
        /// <param name="OrderByType"></param>Loại sort (ASC hay DESC)
        /// <returns></returns>
        [Route("GetRefCityProvince")]
        [HttpGet]
        public IHttpActionResult GetRefCityProvince(int PageSize, int PageNumber, string CountryID = "", string OrderByName = "", string OrderByType = "")
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber", "OrderByName", "CountryID", "OrderByName", "OrderByType" };
                var objValues = new object[] { PageSize, PageNumber, OrderByName, CountryID, OrderByName, OrderByType };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefCityProvince", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh mục hệ thống phân loại đơn vị đo lường
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefCLMeasurement")]
        [HttpGet]
        public IHttpActionResult GetRefCLMeasurement(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefCLMeasurement", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Dien giai cho ca cum tu viet tat, va y nghia trong cac don vi do dung trong y hoc va xet nghiem
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefCommonTerm")]
        [HttpGet]
        public IHttpActionResult GetRefCommonTerm(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefCommonTerm", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách quốc gia
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefCountry")]
        public IHttpActionResult GetRefCountry(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {   var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefCountry", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách DialingCode
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <param name="CountryID">Mã quốc gia nếu có</param>
        /// <returns></returns>
        [Route("GetDialingCodeCountry")]
        [HttpGet]
        public IHttpActionResult GetDialingCodeCountry(int PageSize, int PageNumber, string CountryID = "")
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" , "CountryID" };
                var objValues = new object[] { PageSize, PageNumber, CountryID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetDialingCodeCountry", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh mục hướng xử lý sau khi kết thúc khám/điều trị (theo ASTM)
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefDischargeDisposition")]
        [HttpGet]
        public IHttpActionResult GetRefDischargeDisposition(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefDischargeDisposition", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách quận/huyện
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// //Trong Tran Update cho lọc theo mã TP / Tỉnh
        /// <param name="CityProvinceID">Mã TP/Tỉnh</param>
        /// <returns></returns>
        [Route("GetRefDistrict")]

        public IHttpActionResult GetRefDistrict(int PageSize, int PageNumber, string CityProvinceID)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber", "CityProvinceID" };
                var objValues = new object[] { PageSize, PageNumber, CityProvinceID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefDistrict", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách trình độ học vấn
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefEducationalLevel")]

        public IHttpActionResult GetRefEducationalLevel(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefEducationalLevel", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách dân tộc (theo ASTM)
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefEthnicGroup")]

        public IHttpActionResult GetRefEthnicGroup(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefEthnicGroup", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách danh mục quan sát đánh giá
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefExamObservation")]

        public IHttpActionResult GetRefExamObservation(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefExamObservation", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh mục các quan hệ gia đình
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefFAMRelationship")]

        public IHttpActionResult GetRefFAMRelationship(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefFAMRelationship", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách danh mục chuẩn HL7 (Store category of The Health Level Seven )
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefHL7")]

        public IHttpActionResult GetRefHL7(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefHL7", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách danh mục các ngôn ngữ được sử dụng trên thế giới (không theo quy đinh của HL7, tuy nhiên có quy định trong 1 vài hệ thống hay chuẩn khác)
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     HLID: "", //Mã ngôn ngữ
        ///     HLCode: "" , //Mã code của ngôn ngữ
        ///     HLName: "", Tên ngôn ngữ
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefHumanLanguage")]

        public IHttpActionResult GetRefHumanLanguage(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefHumanLanguage", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Thông tin về các học viện, trường đại học
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefInstUniversity")]

        public IHttpActionResult GetRefInstUniversity(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber", "language" };
                var objValues = new object[] { PageSize, PageNumber, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefInstUniversity", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách nhóm các vị trí công việc tương đồng nhau bao gồm những loại công việc hay trách nhiệm cần thực hiện ở những giới hạn phạm vi khác nhau
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefJobBand")]

        public IHttpActionResult GetRefJobBand(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefJobBand", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách danh mục chức danh
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefJobTitle")]

        public IHttpActionResult GetRefJobTitle(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefJobTitle", objNames, objValues);
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
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefMedicalCondition")]

        public IHttpActionResult GetRefMedicalCondition(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefMedicalCondition", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách danh mục nghề nghiệp
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefOccupation")]

        public IHttpActionResult GetRefOccupation(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefOccupation", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách danh mục giới tính
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefPersGender")]

        public IHttpActionResult GetRefPersGender(int PageSize, int PageNumber)
        {
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "PageSize", "PageNumber" };//Trong Tran updated change obj to objName and objValue
                var objValues = new object[] { PageSize, PageNumber };//
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefPersGender", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách danh mục tình trạng hôn nhân
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefPersMaritalStatus")]

        public IHttpActionResult GetRefPersMaritalStatus(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefPersMaritalStatus", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách danh muc loại bệnh viện
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefProviderType")]

        public IHttpActionResult GetRefProviderType(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefProviderType", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách các lĩnh vực chuyên môn trong bệnh viện
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefQualification")]

        public IHttpActionResult GetRefQualification(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefQualification", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Danh sách vai trò của người dùng/nhân viên
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("GetRefRole")]
        [HttpPost]
        public IHttpActionResult GetRefRole(QueryDTO query)
        {
            try
            {
                query.PageSize = query.PageSize <= 0 ? int.MaxValue : query.PageSize;
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType" };
                var obj = new object[] { query.AccountID, query.PageSize, query.PageNumber, query.OrderByName, query.OrderByType };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefRole", obj);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Danh sách típ đầu ngữ trong danh sách đơn vị đo lường
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefSIPrefix")]

        public IHttpActionResult GetRefSIPrefix(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefSIPrefix", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// lấy danh sách danh mục dấu hiệu sinh tồn
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefVitalSign")]

        public IHttpActionResult GetRefVitalSign(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefVitalSign", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
        /// <summary>
        /// Lấy danh sách phường xã/thị trấn
        /// </summary>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <returns></returns>
        [Route("GetRefWard")]
        //
        public IHttpActionResult GetRefWard(int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefWard", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh mục dùng chung
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber">số trang hiện tại</param>
        /// <param name="OrderByName">Column Name Order</param>
        /// <param name="OrderByType">Type Order(ASC, DESC)</param>
        /// <param name="ObjectName">ObjectName</param> 
        /// <returns></returns>

        [Route("GetRefLookup")]
        [HttpPost]
        public IHttpActionResult GetRefLookup(long AccountID, int PageSize, int PageNumber, string OrderByName = "", string OrderByType = "", string ObjectName = "")
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType", "ObjectName" };
                var objValues = new object[] { AccountID, PageSize, PageNumber, OrderByName, OrderByType, ObjectName };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefLookup", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }


        }
        /// <summary>
        /// Lấy danh mục tôn giáo
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="PageSize">số dòng dữ liệu cần lấy trong 1 trang, PageSize = -1 lấy tất cả danh sách</param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>

        [Route("GetRefReligion")]
        public IHttpActionResult GetRefReligion(long AccountID, int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "PageSize", "PageNumber" };
                var objValues = new object[] { PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefReligion", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh mục chuyển đổi đơn vị đo lường
        /// </summary>
        /// <param name="AccountID">AccountID</param>
        /// <param name="PageSize">PageSize</param>
        /// <param name="PageNumber">PageNumber</param>
        /// <returns></returns>

        [Route("GetMesrtConv")]
        public IHttpActionResult GetMesrtConv(long AccountID, int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber" };
                var objValues = new object[] { AccountID, PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetMesrtConv", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh mục chủng tộc
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>

        [Route("GetRefPersRace")]
        public IHttpActionResult GetRefPersRace(long AccountID, int PageSize, int PageNumber)
        {
            PageSize = PageSize == -1 ? int.MaxValue : PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber" };
                var objValues = new object[] { AccountID, PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefPersRace", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh mục dân tộc
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRefElthnic")]
        public IHttpActionResult GetRefElthnic(GetRefElthnic query)
        {
            query.Default.PageSize = query.Default.PageSize == -1 ? int.MaxValue : query.Default.PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PtEthnicGroupID", "PageSize", "PageNumber", "OrderByName", "OrderByType", "language" };
                var objValues = new object[] { query.Default.AccountID, query.PtEthnicGroupID, query.Default.PageSize, query.Default.PageNumber, query.Default.OrderByName, query.Default.OrderByType, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefElthnic", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh sách danh mục tiền tệ
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRefCurrency")]
        public IHttpActionResult GetRefCurrency(QueryDTO query)
        {
            query.PageSize = query.PageSize == -1 ? int.MaxValue : query.PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType" };
                var objValues = new object[] { query.AccountID, query.PageSize, query.PageNumber, query.OrderByName, query.OrderByType };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefCurrency", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }
        /// <summary>
        /// Lấy danh sách danh mục nghề nghiệp theo bảo hiểm y tế
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRefCareerMOH")]
        public IHttpActionResult GetRefCareerMOH(QueryDTO query)
        {
            query.PageSize = query.PageSize == -1 ? int.MaxValue : query.PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType" };
                var objValues = new object[] { query.AccountID, query.PageSize, query.PageNumber, query.OrderByName, query.OrderByType };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefCareerMOH", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /// <summary>
        ///  Lấy danh sách cấu trúc mẫu mail
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRefAnnTemp")]
        public IHttpActionResult GetRefAnnTemp(RefAnnTemp query)
        {
            query.Default.PageSize = query.Default.PageSize == -1 ? int.MaxValue : query.Default.PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType", "V_AnnTempType", "AnnTempName", "language" };
                var objValues = new object[] { query.Default.AccountID, query.Default.PageSize, query.Default.PageNumber, query.Default.OrderByName, query.Default.OrderByType, query.V_AnnTempType, query.AnnTempName, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefAnnTemp", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách danh mục hoạt động đánh giá kiểm tra
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRefExamAction")]
        public IHttpActionResult GetRefExamAction(QueryDTO query)
        {
            query.PageSize = query.PageSize == -1 ? int.MaxValue : query.PageSize;
            try
            {
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType" };
                var objValues = new object[] { query.AccountID, query.PageSize, query.PageNumber, query.OrderByName, query.OrderByType };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefExamAction", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách các Xã
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetWard")]
        public IHttpActionResult GetWard(QueryDTO query)
        {
            try
            {
                query.PageSize = query.PageSize <= 0 ? int.MaxValue : query.PageSize;
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType" };
                var objValues = new object[] { query.AccountID, query.PageSize, query.PageNumber, query.OrderByName, query.OrderByType };
                var result = this.Repository.ExecuteStoreScalar("usp_GetWard", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lây danh sách đơn vị tính
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetRefUnitOfMeasure")]
        public IHttpActionResult GetRefUnitOfMeasure(GetRefUnitOfMeasureDTO query)
        {
            try
            {
                query.Default.PageSize = query.Default.PageSize <= 0 ? int.MaxValue : query.Default.PageSize;
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber", "OrderByName", "OrderByType", "V_UOMCategory", "MCLID", "language" };
                var objValues = new object[] { query.Default.AccountID, query.Default.PageSize, query.Default.PageNumber, query.Default.OrderByName
                    , query.Default.OrderByType, query.V_UOMCategory, query.MCLID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetRefUnitOfMeasure", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("get-demo-parse-json-object-none-used")]
        public IHttpActionResult DemoMultiObjectTest(JObject obj)
        {
            try
            {
                
                dynamic jsonData = obj;
                JObject queryjson = jsonData.query;
                var query = queryjson.ToObject<QueryDTO>();
                JObject dtojson = jsonData.dto;
                var dto = queryjson.ToObject<CustomerDTO>();
                return Ok();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        
    }

}
