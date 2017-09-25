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
using LV.Poco;
using System.Data;
using LV.Core.DAL.EntityFramework;

namespace LV.Service.Common
{
    [RoutePrefix("api/Account")]
    public class AccountController : LVApiController
    {
        ILog log;
        string language = string.Empty;
        public AccountController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //language = GetLang();
        }
        #region Login
        [Route("Login")]
        private LVDataInfo LoginUser(string username, string password)
        {

            DatabaseInfo dbInfo = null;
            LVLoginUser user = null;
            string result = LoginUserLogic(username, password, out dbInfo, out user);            
            return new LVDataInfo() { result = result, dbInfo = dbInfo, data = user };
        }
        private string LoginUserLogic(string username, string password, out DatabaseInfo dbInfo, out LVLoginUser user)
        {

            dbInfo = null;
            user = null;
            try
            {
                EFDALContainer dal = new EFDALContainer();
                dbInfo = dal.CreateDefaultDatabase();
                
                var dalSchema = new EFDALContainer(dbInfo);
                string AccountNameEmailAddress = username;
                string AccountPwd = password;
                var objName = new object[] { "AccountNameEmailAddress", "AccountPwd" };
                var objValue = new object[] { AccountNameEmailAddress, AccountPwd };
                var result = this.Repository.ExecuteStoreScalar("usp_Login", objName, objValue);
                string ReturnCode = string.Empty;
                string a =  LV.Service.Common.JsonConverter.DataSetToJson(result);
                var userAccount = new UserAccount();
                if (result != null && result.Tables.Count > 0)
                {
                    foreach (DataRow item in result.Tables[0].Rows)
                    {
                        ReturnCode = item["ReturnCode"].ToString();
                        if (ReturnCode == "0")
                        {
                            userAccount.AccountNameEmailAddress = item["AccountNameEmailAddress"].ToString();
                            userAccount.V_AccountType = Convert.ToInt64(item["V_AccountType"].ToString());
                            userAccount.AccountID = Convert.ToInt64(item["AccountID"].ToString());
                            userAccount.AccountPwd = item["AccountPwd"].ToString();
                            userAccount.PersonID = Convert.ToInt64(item["PersonID"].ToString());
                            userAccount.PrimaryRoleID = item["PrimaryRoleID"] == null ? 0 : Convert.ToInt64(item["PrimaryRoleID"].ToString());
                            userAccount.RoleName = item["RoleName"] == null ? "" : item["RoleName"].ToString();
                            
                        }
                        else
                        {
                            return item["ReturnCode"].ToString();
                        }
                    }
                }
                var obj = new object[1] { userAccount.AccountID };
                if (userAccount != null)
                {
                    user = new LVLoginUser();
                    //if (userAccount.V_AccountType == 7303 || userAccount.V_AccountType == 7302 )
                    //{
                        long V_PersonType = 0;
                        if (userAccount.V_AccountType == 7303)
                            V_PersonType = 5200;
                        else if (userAccount.V_AccountType == 7302)
                            V_PersonType = 5201;
                        else if (userAccount.V_AccountType == 7301)
                            V_PersonType = 5200;
                    var objparam = new object[] { "PersonID", "V_PersonType" };
                        var objvalue = new object[] { userAccount.PersonID, V_PersonType.ToString() };
                        var Employees = this.Repository.ExecuteStoreScalar("usp_GetInforPerson", objparam, objvalue);
                        var Employee = new Employee();
                        if (Employees.Tables.Count > 0)
                        {
                            foreach (DataRow item in Employees.Tables[0].Rows)
                            {
                                user.account = userAccount;
                                user.PersName = item["PersName"]==null ? "" : item["PersName"].ToString();
                                user.FirstName = item["FirstName"] == null? "": item["FirstName"].ToString();
                                user.ProfilePhoto = item["ProfilePhoto"] == null? "" : item["ProfilePhoto"].ToString();
                                user.Email = username;
                                user.UserCode = item["EmpCode"] == null ? "": item["EmpCode"].ToString();
                                user.EmpID = item["EmpID"] == null ? "" : item["EmpID"].ToString();
                                user.PersonID = item["PersonID"] == null ? "" : item["PersonID"].ToString();
                                user.Type = userAccount.V_AccountType.ToString();
                            }
                        }
                    //}
                    user.DatabaseInfo = dbInfo;
                }
                return ReturnCode;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return "4";
            }
        }

        protected static string GetIPAddress()
        {
            //return Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <remarks>
        /// <code>
        ///     [{
        ///         ReturnCode: ""//Mã lỗi trả ra của hàm
        ///         //0: đăng nhập thành công
        ///         //1: thông tin đăng nhập (email hoặc mật khẩu) chưa đúng
        ///         //2: tài khoản đã bị khóa
        ///         //3: tài khoản chưa kích hoạt
        ///     }]
        /// </code>
        /// </remarks>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("LoginUser")]
        public ResultLogin Login(string userName, string passWord)
        {

            var reader = LoginUser(userName, passWord);
            DatabaseInfo dbInfo = new DatabaseInfo();

            if (reader != null)
            {
                string validatorStatus = reader.result;
                dbInfo = reader.dbInfo;
                LVLoginUser loginUser = new LVLoginUser();
                loginUser = (LVLoginUser)reader.data;
                var listPocoType = GetListPocoType();
                if (listPocoType != null)
                    PocoHelper.SetListPocoType(listPocoType);
                else
                    PocoHelper.GenerateListPocoType();
                return new ResultLogin() { code = validatorStatus, loginUser = loginUser };
            }

            return null;
        }
        private class LVDataInfo
        {
            public string result { get; set; }
            public DatabaseInfo dbInfo { get; set; }
            public Object data { get; set; }
        }
        public class ResultLogin
        {
            public string code { get; set; }
            public string message { get; set; }
            public LVLoginUser loginUser { get; set; }
        }
        public Dictionary<string, Type> GetListPocoType()
        {
            var listPocoType = PocoHelper.GetListPocoType();
            return listPocoType;

        }
        #endregion

        [Authorize]
        [Route("TestAuthication")]
        [HttpGet]
        public IHttpActionResult TestAuthication()
        {
            return Ok("");
        }
    }

    class UserConfig {
        public string Language { get; set; }
    }
}
