using HealthCareAPI.BO;
using HealthCareAPI.DTO;
using log4net;
using LV.Common;
using LV.Poco;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace HealthCareAPI.Controllers
{
    [RoutePrefix("api/common")]
    [AllowAnonymous]
    public class CommonController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public CommonController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
        /// <summary>
        /// Lấy ID bệnh viện hiện tại
        /// </summary>
        /// <remarks>
        /// <code>
        ///     [{
        ///         HosID:// Mã bệnh viên ,
        ///         ApptByProcess: //Quy trình thăm khám ,
        ///     }]
        /// </code>
        /// </remarks>
        /// <returns></returns>
        [Route("GetHosID")]
        [HttpGet]
        public IHttpActionResult GetHosID()
        {
            try
            {
                //var HosID = "11163"; //ConfigurationManager.AppSettings["HosID"].Trim();
                var HosID = ConfigurationManager.AppSettings["HosID"];
                var ApptByProcess = this.Repository.GetQuery<refAppConfig>().Where(x => x.ConfigItemKey == "RegApptByProcess").Select(x => x.ConfigItemValue).FirstOrDefault();
                return Ok(new
                {
                    HosID = Convert.ToInt64(HosID),
                    ApptByProcess = Convert.ToByte(string.IsNullOrEmpty(ApptByProcess) ? "1" : ApptByProcess)
                });
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
        [HttpPost]
        [Route("GetDataDefault")]
        public IHttpActionResult GetDataDefault(GetDataDefault data)
        {
            data.Default.PageSize = data.Default.PageSize == -1 ? int.MaxValue : data.Default.PageSize;
            try
            {
                var objName = new object[] { "TableName", "ColumnsName", "ColumnsID", "Filter", "PageNumber", "PageSize" };
                var objValue = new object[] { data.TableName, data.ColumnsName, data.ColumnsID, data.Filter, data.Default.PageNumber, data.Default.PageSize };
                var result = this.Repository.ExecuteStoreScalar("usp_GetDataDefault", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Thực thi store
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ExecuteStore")]
        public IHttpActionResult ExecuteStore(ExecuteStoreDTO dto)
        {
            try
            {
                var result = this.Repository.ExecuteStoreScalar(dto.name, dto.objName, dto.objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("getHospitalInfo")]
        [HttpGet]
        public IHttpActionResult getHospitalInfo(string hosId)
        {
            try
            {
                //var hospitalInfo = (from hospital in this.Repository.GetQuery<HCProvider>()
                //                    where hospital.HosID == 11163 && hospital.isBulitIn == true
                //                    select hospital).FirstOrDefault();
                var hospitalInfo = this.Repository.GetQuery<refAppConfig>();
                if (hospitalInfo == null)
                {
                    return null;
                }
                return Ok(new { hospitalInfo = hospitalInfo });
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }


        /// <summary>
        /// Test pagin server
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Testpagingserver")]
        public IHttpActionResult GetRefAppConfigTestPaging(Request request)
        {
            try
            {
                string sorting = CommonSer.ConvertSortToString(request.sort);
                string filtering = CommonSer.ConvertFilertToString(request.filter);
                var objName = new object[] { "PageNumber", "PageSize", "Sort", "Filter" };

                var objValue = new object[] { request.page, request.pageSize, sorting, filtering };

                var result = this.Repository.ExecuteStoreScalar("usp_GetRefAppConfigTestPaging", objName, objValue);
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
