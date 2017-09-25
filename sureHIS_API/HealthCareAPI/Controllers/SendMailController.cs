using HealthCareAPI.DTO;
using log4net;
using LV.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    [AllowAnonymous]
    [RoutePrefix("api/common")]
    public class SendMailController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public SendMailController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
        [NonAction]
        private string GetAnnTemp(string AnnTempName)
        {
            var objNames = new object[] { "AnnTempName" };
            var objValues = new object[] { AnnTempName };
            DataSet AnnTemp = this.Repository.ExecuteStoreScalar("usp_GetRefAnnTemp", objNames, objValues);
            string Body = string.Empty;
            if (AnnTemp != null)
            {
                foreach (DataRow dr in AnnTemp.Tables[0].Rows)
                {
                    Body = dr["AnnTempContent"].ToString();
                    break;
                }
            }

            return Body;
        }
        [NonAction]
        public bool RegisterAccount(string to, string subject, string ActivationCode, string Url)
        {
            try
            {
                int HosID = int.Parse(ConfigurationManager.AppSettings["HosID"]);
                string Body = GetAnnTemp("RegAccountNotify");
                if (!string.IsNullOrWhiteSpace(Body))
                {
                    var objName = new object[] { "HosID" };
                    var objParam = new object[] { HosID };
                    var hosInfo = this.Repository.ExecuteStoreScalar("usp_GetHCProviderInfor", objName, objParam);
                    List<LinkedResource> res = new List<LinkedResource>();
                    foreach (DataRow dr in hosInfo.Tables[0].Rows)
                    {
                        Body = Body.Replace("@hospital", dr["HCPrvProviderName"] == null ? "" : dr["HCPrvProviderName"].ToString());
                        Body = Body.Replace("@addressHos", dr["HCPractAddressText"] == null ? "" : dr["HCPractAddressText"].ToString());
                        Body = Body.Replace("@slogan", dr["Slogan"] == null? "" : dr["Slogan"].ToString());

                        //LinkedResource pic1 = new LinkedResource(HttpContext.Current.Server.MapPath("~") + dr["HosLogoImgPath"] == null ? "" : dr["HosLogoImgPath"].ToString());
                        //pic1.ContentId = "logo";
                        //res.Add(pic1);
                        break;
                    }
                    //var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");

                    LV.Common.LVCrypto cry = new LVCrypto();
                    Body = Body.Replace("@linkActive", Url + "/ActiveRegister/" + ActivationCode);
                    _SendMail(to, subject, Body, null, res);
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }
        [NonAction]
        public IHttpActionResult ForgotPassword(string Email, string ForgotPwdCode, string Url)
        {
            long HosID = int.Parse(ConfigurationManager.AppSettings["HosID"]);
            try
            {
                string Body = GetAnnTemp("ReqFuncForgetPwd");
                if (!string.IsNullOrWhiteSpace(Body))
                {
                    var objName = new object[] { "HosID" };
                    var objParam = new object[] { HosID };
                    var hosInfo = this.Repository.ExecuteStoreScalar("usp_GetHCProviderInfor", objName, objParam);
                    List<LinkedResource> res = new List<LinkedResource>();
                    foreach (DataRow dr in hosInfo.Tables[0].Rows)
                    {
                        Body = Body.Replace("@hospital", dr["HCPrvProviderName"] == null ? "" : dr["HCPrvProviderName"].ToString());
                        Body = Body.Replace("@addressHos", dr["HCPractAddressText"] == null ? "" : dr["HCPractAddressText"].ToString());
                        Body = Body.Replace("@slogan", dr["Slogan"] == null ? "" : dr["Slogan"].ToString());
                        break;
                    }
                    Body = Body.Replace("@ForgotPassword", Url + "/newpassword/" + ForgotPwdCode);
                    var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");
                    _SendMail(Email, "Cấp lại mật khẩu", Body, null, res);
                }
               
                return Ok(true);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Ok(false);
            }
        }
        [NonAction]
        public IHttpActionResult ChangePwdSuccess(string Email)
        {
            long HosID = int.Parse(ConfigurationManager.AppSettings["HosID"]);
            try
            {
                string Body = GetAnnTemp("ChangePwdSuccess");
                if (!string.IsNullOrWhiteSpace(Body))
                {
                    var objName = new object[] { "HosID" };
                    var objParam = new object[] { HosID };
                    var hosInfo = this.Repository.ExecuteStoreScalar("usp_GetHCProviderInfor", objName, objParam);
                    List<LinkedResource> res = new List<LinkedResource>();
                    foreach (DataRow dr in hosInfo.Tables[0].Rows)
                    {
                        Body = Body.Replace("@hospital", dr["HCPrvProviderName"] == null ? "" : dr["HCPrvProviderName"].ToString());
                        Body = Body.Replace("@addressHos", dr["HCPractAddressText"] == null ? "" : dr["HCPractAddressText"].ToString());
                        Body = Body.Replace("@slogan", dr["Slogan"] == null ? "" : dr["Slogan"].ToString());
                        break;
                    }
                    var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");
                    _SendMail(Email, "Thay Đổi Mật Khẩu Thành Công", Body, null, res);
                }
               
                return Ok(true);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Ok(false);
            }
        }
        [NonAction]
        public IHttpActionResult RegistrationInfoSuccess(string to, string subject, Appointment appointment, string ApptDateTime, string ApptSubDateTime, string DepName, string PersName, RegistrationInfo registrationInfo)
        {
            try
            {
                long HosID = int.Parse(ConfigurationManager.AppSettings["HosID"]);
                string report = "";
                if (appointment.WDID != 0 || appointment.TFID != 0)
                {
                    report = GetAnnTemp("ApptNotify-NoProcess");
                }
                else
                {
                    report = GetAnnTemp("ApptNotify-ByProcess");
                }
                if (report.Equals(""))
                {
                    return Ok(false);
                }
                //Dictionary<long, string> appStatusDic = GetAppStatusDic();
                string Body = "";
                var objName = new object[] { "HosID" };
                var objParam = new object[] { HosID };
                var hosInfo = this.Repository.ExecuteStoreScalar("usp_GetHCProviderInfor", objName, objParam);
                Body = report;
                var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");
                foreach (DataRow dr in hosInfo.Tables[0].Rows)
                {
                    Body = Body.Replace("@hospital", dr["HCPrvProviderName"] == null ? "" : dr["HCPrvProviderName"].ToString());
                    Body = Body.Replace("@addressHos", dr["HCPractAddressText"] == null ? "" : dr["HCPractAddressText"].ToString());
                    Body = Body.Replace("@slogan", dr["Slogan"] == null ? "" : dr["Slogan"].ToString());
                    break;
                }

                //gio lam viec
                //List<LV.Poco.Model.WorkDayTime> dateTimeToWork = GetScheduleOfHos(hosID);
                string temp = "";
                var ScheduleOfHost = this.Repository.ExecuteStoreScalar("usp_GetScheduleOfHost", objName, objParam);
                if (ScheduleOfHost != null)
                {
                    foreach (DataRow dr in ScheduleOfHost.Tables[0].Rows)
                    {
                        temp += "<tr><td/><td/><td>" + dr["V_DayName"].ToString() + ": <span style='color:red; font-weight:bold'>" + dr["StartTime"].ToString() + "</span></td></tr>";
                    }
                }
                //if (dateTimeToWork != null && dateTimeToWork.Count > 0)
                //{
                //    foreach (var date in dateTimeToWork)
                //    {
                //        temp += "<tr><td/><td/><td>" + date.VNObjectValue + ": <span style='color:red; font-weight:bold'>" + date.TimeWork + "</span></td></tr>";
                //    }
                //}
                Body = Body.Replace("@workingTime", temp);

                //Chuyên khoa dk
                Body = Body.Replace("@appointedDept", DepName);
                //Bs dk
                Body = Body.Replace("@appointedDoctorName", PersName);
                //Ngay gio dk
                Body = Body.Replace("@appointedDateTime", ApptDateTime);
                //Ngay gio dk phu
                Body = Body.Replace("@appointedSubDateTime", ApptSubDateTime);
                //Trieu chung ban dau
                Body = Body.Replace("@reasonAndSymtom", appointment.ReasonOrSymptom);
                //mail
                Body = Body.Replace("@mailAddress", registrationInfo.EmailAddress);
                //id cuoc hen
                //Body = Body.Replace("@idAppointment", appointment.ApptID.ToString());
                //ten BN
                Body = Body.Replace("@ptFullName", registrationInfo.LastName + " " + registrationInfo.FirstName);
                //Ngày sinh
                Body = Body.Replace("@DOB", registrationInfo.DOB == "" ? registrationInfo.DOB : string.Empty);
                //CMND
                Body = Body.Replace("@IDCard", registrationInfo.PPN != null && !registrationInfo.PPN.Equals("") ? registrationInfo.PPN : registrationInfo.PPN != null && !registrationInfo.PPN.Equals("") ? registrationInfo.PPN : string.Empty);
                //Giới tính
                Body = Body.Replace("@Gender", string.Empty);
                //dien thoai
                Body = Body.Replace("@phoneNumber", registrationInfo.MobilePhoneNumber);
                //Loai dk
                //Body = Body.Replace("@apptStatus", GetNameFromDicKey((long)appointment.V_ApptStatus, appStatusDic));
                //LV.Common.LVCrypto cry = new LVCrypto();
                //Body = Body.Replace("@linkActive", url + "/eportal/ActiveMail/" + appointment.ApptID.ToString());
                //Body = Body.Replace("@linkCancel", url + "/eportal/CancelMail/" + appointment.ApptID.ToString());

                List<LinkedResource> res = new List<LinkedResource>();

                //LinkedResource pic1 = new LinkedResource(HttpContext.Current.Server.MapPath("~") + hosInfo.logo);
                //pic1.ContentId = "logo";
                //res.Add(pic1);

                _SendMail(to, subject, Body, null, res);
                return Ok(true);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Ok(false);
            }
        }
        [NonAction]
        public void _SendMail(string ToMail, string Subject, string Body, List<Attachment> atts = null, List<LinkedResource> resources = null)
        {
            string MailAddress = ConfigurationManager.AppSettings["MailAddress"];
            string MailServer = ConfigurationManager.AppSettings["MailServer"];
            int MailPort = int.Parse(ConfigurationManager.AppSettings["MailPort"]);
            string MailPassword = ConfigurationManager.AppSettings["MailPassword"];
            string Proxy = ConfigurationManager.AppSettings["Proxy"];
            string PUserName = ConfigurationManager.AppSettings["PUserName"];
            string PPass = ConfigurationManager.AppSettings["PPass"];
            string EnableSsl = ConfigurationManager.AppSettings["EnableSsl"];

            MailAddress FromMailAddress = new MailAddress(MailAddress);
            MailAddress ToMailAddress = new MailAddress(ToMail);
            MailAddress CCMailAddress = new MailAddress(MailAddress);

            MailMessage MailMsg = new MailMessage();
            MailMsg.From = FromMailAddress;
            MailMsg.To.Add(ToMailAddress);
            MailMsg.CC.Add(CCMailAddress);
            MailMsg.Subject = Subject;
            MailMsg.IsBodyHtml = true;

            AlternateView avHtml = AlternateView.CreateAlternateViewFromString(Body, null, MediaTypeNames.Text.Html);

            if (resources != null)
            {
                foreach (var item in resources)
                {
                    avHtml.LinkedResources.Add(item);
                }
            }

            MailMsg.AlternateViews.Add(avHtml);

            SmtpClient MailSender = new SmtpClient(MailServer, MailPort);
            if (EnableSsl == "1")
                MailSender.EnableSsl = true;
            MailSender.Timeout = 10000;
            MailSender.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailSender.UseDefaultCredentials = false;
            MailSender.Credentials = new System.Net.NetworkCredential(MailAddress, MailPassword);

            MailSender.Send(MailMsg);
        }
        public class AppointmentMsg
        {
            public static int ReminderTime = 30;
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required, Phone, Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            public DateTime Time { get; set; }

            [Required]
            public string Timezone { get; set; }

            [Display(Name = "Created at")]
            public DateTime CreatedAt { get; set; }
        }
        [NonAction]
        public void sendMessage()
        {
            //TwilioClient.Init("AC3e4e070521e1ad2536bcd2df569774e0", "98f2f8c2b8a7854ba8ed6b3d4a30c744");
            //MessageResource.Create(
            //    to: new PhoneNumber("841669588804"),
            //    from: new PhoneNumber("+13207467124"),
            //    body: "Vui lòng xác nhận thông lịch hẹn của bạn [ID# 00005678]  với mã số xác nhận OTP 123456. Mọi thắc mắc vui lòng liên hệ Hot-Line 0918 33 44 55. Trân trọng.");

        }
    }
}
