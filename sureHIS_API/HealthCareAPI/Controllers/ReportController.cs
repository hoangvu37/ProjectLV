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

namespace HealthCareAPI.Controllers
{
    [RoutePrefix("api/report")]
    public class ReportController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public ReportController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
    }
}
