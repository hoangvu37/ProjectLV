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
using System.Globalization;

namespace HealthCareAPI.Controllers
{
    
    [RoutePrefix("api/employee")]
    public class EmployeeController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public EmployeeController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
        [AllowAnonymous]
        /// <summary>
        /// Lấy thông tin của nhân viên trong bệnh viện
        /// </summary>
        /// <param name="EmpID">Mã nhân viên</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmployeeById")]
        public IHttpActionResult GetEmployeeById(long EmpID)
        {
            try
            {
                var objNames = new object[] { "EmpID", "language" };
                var objValues = new object[] { EmpID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetEmployeeById", objNames, objValues);
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
