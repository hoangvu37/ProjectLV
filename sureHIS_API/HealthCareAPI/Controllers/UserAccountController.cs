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
    [RoutePrefix("api/UserAccount")]
    public class UserAccountController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        SendMailController _sendmail;
        public UserAccountController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
            _sendmail = new SendMailController();
        }
        /// <summary>
        /// Đăng ký tài khoản người dùng
        /// </summary>
        /// <remarks>
        /// <code>
        ///     [{
        ///         ReturnCode: "Mã lỗi của hàm",
        ///         //Chú thích về mã lỗi
        ///         //60: Email đã được sử dụng
        ///         //61: Lỗi của hệ thống không xác định
        ///         //62: Các tài khoản khác chưa xứ lý---ko cần thông báo
        ///         //63: không tồn tại mã bệnh nhân
        ///         //64: sai thông tin FirstName
        ///         //65: sai thông tin PersBirthDtm
        ///         //66: Bệnh nhân này đã có tài khoản trong hệ thống
        ///         //68: sai thông tin LastName
        ///         //0: Lưu thông tin đăng ký thành  công
        ///         AcocuntID: Mã tài khoản được tạo,
        ///     }]
        /// </code>
        /// </remarks>
        /// <param name="AccountPer"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("RegisterAccount")]
        public IHttpActionResult RegisterAccount(RegisterAccountDTO AccountPer)
        {
            try
            {
                object PersBirthDtm = DateTime.Parse(AccountPer.PersBirthDtm, culture);

                var objNames = new object[] { "AccountPwd", "EmailAddress" , "FirstName", "LastName", "LandLine"
                    ,"PersBirthDtm", "PersHomePhonePhN",  "PersonType", "PrimaryRoleID", "OtherPersonDetails"
                    , "PersPermanentAddressText", "CountryID", "CityProvinceID", "DistrictID", "NationnalityCode", "Perscode", "JTID", "V_AccountType" };
                var objValues = new object[] { AccountPer.AccountPwd, AccountPer.EmailAddress, AccountPer.FirstName
                    , AccountPer.LastName, AccountPer.LandLine
                    , PersBirthDtm, AccountPer.PersHomePhonePhN, AccountPer.PersonType
                    , AccountPer.PrimaryRoleID, AccountPer.OtherPersonDetails, AccountPer.PersPermanentAddressText
                ,AccountPer.CountryID, AccountPer.CityProvinceID, AccountPer.DistrictID, AccountPer.NationnalityCode, AccountPer.Perscode, AccountPer.JTID, AccountPer.V_AccountType  };
                var result = this.Repository.ExecuteStoreScalar("usp_RegisterAccount", objNames, objValues);
                //sendmail
                //_sendmail.RegisterAccount(to, subject, AccountID, ActivationCode, Url)
                //RegisterAccount
                if (result != null)
                {
                    foreach (DataRow dr in result.Tables[0].Rows)
                    {
                        if(dr["ReturnCode"].ToString() == "0")
                        {
                            
                            string to = dr["EmailAddress"].ToString();
                            string subject = "Đăng Ký Tài Khoản Thành Công";
                            string ActivationCode = dr["ActivationCode"].ToString();
                            string Url = AccountPer.Url;
                            _sendmail.RegisterAccount(to, subject, ActivationCode, Url);
                        }
                        break;
                    }
                }
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Quên mật khẩu
        /// </summary>
        ///     [{
        ///         ReturnCode: "",
        ///         //Mã lỗi của hàm
        ///         //0: thành công
        ///         //90: 
        ///     }]
        /// <param name="EmailAddress">Địa chỉ Email</param>
        /// <param name="Url">Link site</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public IHttpActionResult ForgotPassword(string EmailAddress, string Url)
        {
            try
            {   var objNames = new object[] { "EmailAddress" };
                var objValues = new object[] { EmailAddress };
                var result = this.Repository.ExecuteStoreScalar("usp_ForgotPassword", objNames, objValues);
                if (result != null)
                {
                    foreach (DataRow dr in result.Tables[0].Rows)
                    {
                        if (dr["ReturnCode"].ToString() == "0")
                        {
                            string to = dr["EmailAddress"].ToString();
                            string ForgotPwdCode = dr["ForgotPwdCode"].ToString();
                            _sendmail.ForgotPassword(to, ForgotPwdCode, Url);
                        }
                        break;
                    }
                }
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Thay đổi Pwd
        /// </summary>
        /// <param name="ForgotPwdCode"></param>
        /// <param name="AccountPwd"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("ChangePwd")]
        public IHttpActionResult ChangePwd(string ForgotPwdCode, string AccountPwd)
        {
            try
            {
                var objNames = new object[] { "ForgotPwdCode" , "AccountPwd" };
                var objValues = new object[] { ForgotPwdCode, AccountPwd };
                var result = this.Repository.ExecuteStoreScalar("usp_ChangePwd", objNames, objValues);
                if (result != null)
                {
                    foreach (DataRow dr in result.Tables[0].Rows)
                    {
                        if (dr["ReturnCode"].ToString() == "0")
                        {
                            string to = dr["EmailAddress"].ToString();
                            _sendmail.ChangePwdSuccess(to);
                        }
                        break;
                    }
                }
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        /// <summary>
        /// Active tài khoản
        /// </summary>
        /// <param name="ActivationCode">Key Active</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("ActivedRegisterAccount")]
        public IHttpActionResult ActivedRegisterAccount(string ActivationCode)
        {
            try
            {
                var objNames = new object[] { "ActivationCode" };
                var objValues = new object[] { ActivationCode };
                var result = this.Repository.ExecuteStoreScalar("usp_ActivedRegisterAccount", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy dữ liệu giới tính
        /// </summary>
        /// <returns></returns>
        [Route("GetPersGenderTest")]
        [HttpGet]
        public IHttpActionResult GetPersGenderTest()
        {
            try
            {
                var data = this.Repository.GetAll<refPersGender>();
                return Ok(data);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [AllowAnonymous]
        [Route("SendSMS")]
        [HttpGet]
        public IHttpActionResult SendSMS()
        {
            _sendmail.sendMessage();
            return Ok();
        }


    }
}
