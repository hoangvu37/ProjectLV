using HealthCareAPI.DTO;
using log4net;
using LV.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace HealthCareAPI.Controllers
{
    [RoutePrefix("api/logic")]
    public class LogicServiceController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public LogicServiceController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
    }
}
