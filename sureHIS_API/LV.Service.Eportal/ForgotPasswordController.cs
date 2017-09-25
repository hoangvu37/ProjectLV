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
    [RoutePrefix("api/ForgotPassword")]
    [AllowAnonymous]
    public class ForgotPasswordController : LVApiController
    {
        [Route("checkEmailExist")]
        [HttpGet]
        public IHttpActionResult checkEmailExist(string email)
        {
            try
            {
                UserAccount user = this.Repository.GetQuery<UserAccount>().FirstOrDefault(m => m.AccountNameEmailAddress == email);
                if (user != null)
                {
                    return Ok(true);
                }
                return Ok(false);
            }
            catch (Exception exp)
            {
                return Ok(false);
            }
        }
        public string GetMailTemplate()
        {
            return (from h in this.Repository.GetQuery<refAnnTemp>() where h.AnnTempName == "ReqFuncForgetPwd" select h.AnnTempContent).FirstOrDefault();
        }

        [Route("sendEmailForgotPassword")]
        [HttpGet]
        public IHttpActionResult sendEmailForgotPassword(string email, long hosID)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                string code = DateTime.Now.ToString("yyyyMMddhhmmsstt");
                string code_encrypt = LVCrypto.GetMd5Hash(md5, code);
                // Luu thong tin lai:
                UserAccount account = this.Repository.GetQuery<UserAccount>().FirstOrDefault(m => m.AccountNameEmailAddress == email);
                if (account != null)
                {
                    account.isBlocked = true;
                    account.RequestDateForPWD = DateTime.Now;
                    account.ForgotPwdCode = code_encrypt;
                    this.Repository.Update<UserAccount>(account);
                    this.Repository.UnitOfWork.SaveChanges();
                }


                RegisterMailController mailCtrl = new RegisterMailController();
                string report = GetMailTemplate();
                //Dictionary<long, string> appStatusDic = GetAppStatusDic();
                string Body = "";
                var hosInfo = (from h in this.Repository.GetQuery<HCProvider>()
                               where h.HosID == hosID
                               select new
                               {
                                   hospital = h.HCPrvProviderName,
                                   slogan = h.Slogan,
                                   addressHos = h.HCPractAddressText,
                                   logo = h.HosLogoImgPath
                               }).FirstOrDefault();

                Body = report;
                var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");

                Body = Body.Replace("@hospital", hosInfo.hospital);
                Body = Body.Replace("@addressHos", hosInfo.addressHos);


                //slogan
                Body = Body.Replace("@slogan", hosInfo.slogan);

                LV.Common.LVCrypto cry = new LVCrypto();
                Body = Body.Replace("@ForgotPassword", url + "/eportal/NewPassword/" + code_encrypt);

                List<LinkedResource> res = new List<LinkedResource>();

                LinkedResource pic1 = new LinkedResource(HttpContext.Current.Server.MapPath("~") + hosInfo.logo);
                pic1.ContentId = "logo";
                res.Add(pic1);

                mailCtrl._SendMail(email, "Cấp lại mật khẩu", Body, null, res);
                return Ok(true);
            }
            catch (Exception exp)
            {
                return Ok(false);
            }
        }

        [Route("CheckCodeValid")]
        [HttpGet]
        public IHttpActionResult CheckCodeValid(string code)
        {
            try
            {
                UserAccount user = this.Repository.GetQuery<UserAccount>().FirstOrDefault(m => m.ForgotPwdCode == code);
                if (user != null)
                {
                    // lay gio thiet lap:
                    int hour = 0;
                    refAppConfig config = this.Repository.GetQuery<refAppConfig>().FirstOrDefault(m => m.ConfigItemKey == "TimeChangePwd");
                    if (config != null)
                    {
                        int.TryParse(config.ConfigItemValue, out hour);
                    }
                    if (((DateTime)user.RequestDateForPWD).AddHours(hour) >= DateTime.Now) // con thoi han 
                    {
                        return Ok("");
                    }
                    return Ok(new { message = "EXPIRE" });

                }
                return Ok(new { message = "NOT_FOUND" }); // ko tim thay user 
            }
            catch (Exception exp)
            {
                return Ok(new { message = "ERROR" });
            }
        }

        public string GetMailTemplateChangePasswordComplete()
        {
            return (from h in this.Repository.GetQuery<refAnnTemp>() where h.AnnTempName == "ChangePwdSuccess" select h.AnnTempContent).FirstOrDefault();
        }

        [Route("UpdatePassword")]
        [HttpPost]
        public IHttpActionResult UpdatePassword(string code, string password)
        {
            try
            {
                UserAccount user = this.Repository.GetQuery<UserAccount>().FirstOrDefault(m => m.ForgotPwdCode == code);
                if (user != null)
                {
                    string passwordMD5 = (new LVCrypto()).Encrypt(password);
                    user.AccountPwd = passwordMD5;
                    user.isBlocked = false;
                    user.ForgotPwdCode = null;
                    user.RequestDateForPWD = null;
                    this.Repository.Update<UserAccount>(user);
                    this.Repository.UnitOfWork.SaveChanges();

                    // gui email thong bao thay doi mat khau thanh cong
                    SendEmail(user.AccountNameEmailAddress, "Đổi mật khẩu thành công");

                }
                return Ok(true);
            }
            catch (Exception exp)
            {
                return Ok(false);
            }
        }

        public bool SendEmail(string to, string subject)
        {
            try
            {
                RegisterMailController mailCtrl = new RegisterMailController();
                int hosID = 11163;
                string report = GetMailTemplateChangePasswordComplete();
                //Dictionary<long, string> appStatusDic = GetAppStatusDic();
                string Body = "";
                var hosInfo = (from h in this.Repository.GetQuery<HCProvider>()
                               where h.HosID == hosID
                               select
                                new
                                {
                                    hospital = h.HCPrvProviderName,
                                    slogan = h.Slogan,
                                    addressHos = h.HCPractAddressText,
                                    logo = h.HosLogoImgPath
                                }).FirstOrDefault();

                Body = report;
                var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");

                Body = Body.Replace("@hospital", hosInfo.hospital);
                Body = Body.Replace("@addressHos", hosInfo.addressHos);

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
