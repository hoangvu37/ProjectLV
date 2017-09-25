using LV.Common;
using LV.Poco;
using LV.Poco.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Mail;
using System.Security.Cryptography;

namespace LV.Service.Eportal
{
    [RoutePrefix("api/Register")]
    [AllowAnonymous]
    public class RegisterController : LVApiController
    {

        [NonAction]
        public string GetMailTemplate()
        {
            return (from h in this.Repository.GetQuery<refAnnTemp>() where h.AnnTempName == "RegAccountNotify" select h.AnnTempContent).FirstOrDefault();
        }
        [NonAction]
        public bool RegisterMailD(string to, string subject, long AccountID, string ActivationCode)
        {
            try
            {
                RegisterMailController mailCtrl = new RegisterMailController();
                int hosID = 11163;
                string report = GetMailTemplate();
                //Dictionary<long, string> appStatusDic = GetAppStatusDic();
                string Body = "";
                var hosInfo = (from h in this.Repository.GetQuery<HCProvider>()
                               where h.HosID == hosID
                               select
                               new { hospital = h.HCPrvProviderName, slogan = h.Slogan, addressHos = h.HCPractAddressText, logo = h.HosLogoImgPath }).FirstOrDefault();

                Body = report;
                var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");

                Body = Body.Replace("@hospital", hosInfo.hospital);
                Body = Body.Replace("@addressHos", hosInfo.addressHos);


                //slogan
                Body = Body.Replace("@slogan", hosInfo.slogan);

                LV.Common.LVCrypto cry = new LVCrypto();
                Body = Body.Replace("@linkActive", url + "/eportal/ActiveRegister/" + ActivationCode);
                List<LinkedResource> res = new List<LinkedResource>();

                LinkedResource pic1 = new LinkedResource(HttpContext.Current.Server.MapPath("~") + hosInfo.logo);
                pic1.ContentId = "logo";
                res.Add(pic1);

                mailCtrl._SendMail(to, subject, Body, null, res);
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
    }
}
