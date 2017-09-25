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
using LV.Poco;
using System.Data;
using Newtonsoft.Json;

namespace HealthCareAPI.Controllers
{
    [RoutePrefix("api/Config")]
    public class ConfigSystemController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        string accountid = string.Empty;
        SendMailController _sendmail;
        public ConfigSystemController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
            accountid = GetUserAccount();
            _sendmail = new SendMailController();
        }
        /// <summary>
        /// Cập nhật thông tin cấu hình(bệnh viên, )
        /// </summary>
        /// <remarks>
        /// <code>
        /// [{
        ///     ReturnCode: "" // mã lỗi
        ///     //0:  Thành công
        ///     //100: Param JsonAppConfig truyền vào không được phép null
        ///     //101: không thể cập nhật dữ liệu
        ///     //102: Lỗi hệ thống không xác định
        /// }]
        /// </code>
        /// </remarks>
        /// <param name="app"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUpdateRefAppConfig")]
        public IHttpActionResult AddUpdateRefAppConfig(AppConfigDTO app)
        {
            try
            {
                var objNames = new object[] { "AccountID", "language", "JsonAppConfig", "JsonHCProvider" };
                var objValues = new object[] { long.Parse(accountid), language, JsonConvert.SerializeObject(app.JsonAppConfig), JsonConvert.SerializeObject(app.JsonHCProvider) };
                var result = this.Repository.ExecuteStoreScalar("usp_AddUpdateRefAppConfig", objNames, objValues);
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
