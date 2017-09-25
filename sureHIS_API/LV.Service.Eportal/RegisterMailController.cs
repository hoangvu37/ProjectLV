using LV.Common;
using LV.Poco;
//using LV.Poco.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LV.Service.Eportal
{
    public class RegisterMailController:LVApiController
    {
        public RegisterMailController()
        {

        }
        /*
        to: địa chỉ em ail người nhận
        subject:chủ đề
        link: link để active xác nhận
        */
        //[NonAction]
        //public bool RegisterMailR(string to, string subject, Appointment appointment, string ApptDateTime,string ApptSubDateTime, string DepName, string PersName, long? hosID, RegistrationInfo registrationInfo)
        //{
        //    try
        //    {
        //        string report = "";
        //        if (appointment.WDID == null || appointment.TFID == null)
        //        {
        //            report = GetMailTemplate("ApptNotify-NoProcess");
        //        }
        //        else
        //        {
        //            report = GetMailTemplate("ApptNotify-ByProcess");
        //        }
        //        if (report.Equals(""))
        //        {
        //            return false;
        //        }
        //        Dictionary<long, string> appStatusDic = GetAppStatusDic();
        //        string Body = "";
        //        var hosInfo = (from h in this.Repository.GetQuery<HCProvider>()
        //                       where h.HosID == hosID
        //                       select
        //        new { hospital = h.HCPrvProviderName, slogan = h.Slogan, addressHos = h.HCPractAddressText, logo = h.HosLogoImgPath }).FirstOrDefault();
        //        Body = report;
        //        var url = HttpContext.Current.Request.UrlReferrer.AbsoluteUri.Replace(HttpContext.Current.Request.UrlReferrer.AbsolutePath, "");

        //        Body = Body.Replace("@hospital", hosInfo.hospital);
        //        Body = Body.Replace("@addressHos", hosInfo.addressHos);
        //        //gio lam viec
        //        List<LV.Poco.Model.WorkDayTime> dateTimeToWork = GetScheduleOfHos(hosID);
        //        string temp = "";
        //        if (dateTimeToWork != null && dateTimeToWork.Count > 0)
        //        {
        //            foreach (var date in dateTimeToWork)
        //            {
        //                temp += "<tr><td/><td/><td>" + date.VNObjectValue + ": <span style='color:red; font-weight:bold'>" + date.TimeWork + "</span></td></tr>";
        //            }
        //        }
        //        Body = Body.Replace("@workingTime", temp);
        //        //slogan
        //        Body = Body.Replace("@slogan", hosInfo.slogan);
        //        //Chuyên khoa dk
        //        Body = Body.Replace("@appointedDept", DepName);
        //        //Bs dk
        //        Body = Body.Replace("@appointedDoctorName", PersName);
        //        //Ngay gio dk
        //        Body = Body.Replace("@appointedDateTime", ApptDateTime);
        //        //Ngay gio dk phu
        //        Body = Body.Replace("@appointedSubDateTime", ApptSubDateTime);
        //        //Trieu chung ban dau
        //        Body = Body.Replace("@reasonAndSymtom", appointment.ReasonOrSymptom);
        //        //mail
        //        Body = Body.Replace("@mailAddress", registrationInfo.EmailAddress);
        //        //id cuoc hen
        //        Body = Body.Replace("@idAppointment", appointment.ApptID.ToString());
        //        //ten BN
        //        Body = Body.Replace("@ptFullName", registrationInfo.LastName + " " + registrationInfo.FirstName);
        //        //Ngày sinh
        //        Body = Body.Replace("@DOB", registrationInfo.DOB.HasValue ? registrationInfo.DOB.Value.ToString("dd/MM/yyyy") : string.Empty);
        //        //CMND
        //        Body = Body.Replace("@IDCard", registrationInfo.IDNumber != null && !registrationInfo.IDNumber.Equals("") ? registrationInfo.IDNumber : registrationInfo.PPN != null && !registrationInfo.PPN.Equals("") ? registrationInfo.PPN : string.Empty);
        //        //Giới tính
        //        Body = Body.Replace("@Gender", string.Empty);
        //        //dien thoai
        //        Body = Body.Replace("@phoneNumber", registrationInfo.MobilePhoneNumber);
        //        //Loai dk
        //        Body = Body.Replace("@apptStatus", GetNameFromDicKey((long)appointment.V_ApptStatus, appStatusDic));
        //        //LV.Common.LVCrypto cry = new LVCrypto();
        //        Body = Body.Replace("@linkActive", url + "/eportal/ActiveMail/" + appointment.ApptID.ToString());
        //        Body = Body.Replace("@linkCancel", url + "/eportal/CancelMail/" + appointment.ApptID.ToString());

        //        List<LinkedResource> res = new List<LinkedResource>();

        //        LinkedResource pic1 = new LinkedResource(HttpContext.Current.Server.MapPath("~") + hosInfo.logo);
        //        pic1.ContentId = "logo";
        //        res.Add(pic1);

        //        _SendMail(to, subject, Body, null, res);
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {
        //        return false;
        //    }
        //}
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
        [NonAction]
        public string GetMailTemplate(string AnnTempName)
        {
            return (from h in this.Repository.GetQuery<refAnnTemp>() where h.AnnTempName == AnnTempName select h.AnnTempContent).FirstOrDefault();
        }
        [NonAction]
        private string GetNameFromDicKey(long strKey, Dictionary<long, string> dic)
        {
            try
            {
                return dic[strKey];
            }
            catch
            {
                return strKey.ToString();
            }
        }
        /*
        */
        //[NonAction]
        //public List<LV.Poco.Model.WorkDayTime> GetScheduleOfHos(long? hosID, string dateView = "")
        //{
        //    var date = DateTime.Now;
        //    if (!string.IsNullOrEmpty(dateView)) date = DateTime.ParseExact(dateView, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    var obj = new object[1] { hosID };
        //    var result = this.Repository.ExecuteStoreScalar("HRM_spScheduleOfHos", obj);
        //    LV.Service.Eportal.AppointmentController.DayInWorkInWeek = new Dictionary<string, Dictionary<long, object>>();
        //    if (result != null && result.Tables.Count > 0)
        //    {
        //        var listDayInWork = new List<LV.Poco.Model.DayInWork>();
        //        var listDayInWork1001 = new List<LV.Poco.Model.DayInWork>();                
        //        foreach (DataRow item in result.Tables[0].Rows)
        //        {
        //            var dayInWork = new LV.Poco.Model.DayInWork();
        //            dayInWork.V_DayName = Convert.ToInt64(item["V_DayName"]);
        //            dayInWork.VNObjectValue = Convert.ToString(item["VNObjectValue"]);
        //            dayInWork.StartTime = (TimeSpan)(item["StartTime"]);
        //            dayInWork.EndTime = (TimeSpan)(item["EndTime"]);
        //            dayInWork.IsDelete = false;
        //            if (dayInWork.V_DayName == 1001)
        //            {
        //                listDayInWork1001.Add(dayInWork);
        //            }
        //            else
        //                listDayInWork.Add(dayInWork);
        //        }
        //        LV.Service.Eportal.AppointmentController.IncludeDay(listDayInWork, listDayInWork1001);
        //        return LV.Service.Eportal.AppointmentController.ChangDicToWorkDay();
        //    }
        //    return null;
        //}
    }
}
