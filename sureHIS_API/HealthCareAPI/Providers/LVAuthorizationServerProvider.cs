using LV.Service.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace HealthAPI.Providers
{
    public class LVAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
  

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //context.Validated();
            if (context.ClientId == null)
            {
                context.Validated(); 
            }

            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string V_AccountType = string.Empty;
            LVLoginUser user = null;
            AccountController.ResultLogin loginUser = null;
            Task task;
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            //filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            var form = await context.Request.ReadFormAsync();
            //sử dụng cho trường hợp login theo loại tài khoản nào
            if (form["V_AccountType"] != null)
                V_AccountType = form["V_AccountType"].ToString();
            task = Task.Factory.StartNew<LVLoginUser>(() =>
            {
                AccountController ac = new AccountController();
                loginUser = ac.Login(context.UserName, context.Password);                
                user = loginUser.loginUser;
                return user;
            });

            await task;
            if (loginUser.loginUser == null)
            {
                context.SetError(loginUser.code);
                return;
            }
            IDictionary<string, string> data = new Dictionary<string, string>();
            if (loginUser.loginUser != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                if (loginUser.loginUser.UserCode == null)
                    loginUser.loginUser.UserCode = "";
                if (loginUser.loginUser.Type == null)
                    loginUser.loginUser.Type = loginUser.loginUser.Type;
                if (loginUser.loginUser.ConfigByUser == null)
                    loginUser.loginUser.ConfigByUser = "";
                if (loginUser.loginUser.account.PrimaryRoleID == null)
                    loginUser.loginUser.account.PrimaryRoleID = 0;
                data.Add("error", loginUser.code);
                data.Add("ReturnCode", loginUser.code);
                data.Add("UserName", loginUser.loginUser.PersName);
                data.Add("Mail", loginUser.loginUser.Email);
                data.Add("PersonID", loginUser.loginUser.account.PersonID.ToString());
                data.Add("AccountID", loginUser.loginUser.account.AccountID.ToString());
                data.Add("ProfilePhoto", loginUser.loginUser.ProfilePhoto);
                data.Add("FirstName", loginUser.loginUser.FirstName);
                //data.Add("PtCode", loginUser.loginUser.UserCode);
                data.Add("Type", loginUser.loginUser.Type.ToString());
                data.Add("Role", loginUser.loginUser.account.PrimaryRoleID.ToString());
                data.Add("RoleName", loginUser.loginUser.account.RoleName);
                //data.Add("Config", loginUser.loginUser.ConfigByUser);
                AuthenticationProperties properties = new AuthenticationProperties(data);
                AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);
                context.Validated(ticket);
            }
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}