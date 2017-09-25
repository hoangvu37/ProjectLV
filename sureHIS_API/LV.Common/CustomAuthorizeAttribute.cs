using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using LV.Core.DAL.Base;

namespace LV.Common
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string FunctionID { get; set; }   
        public string ActionName { get; set; }
        public static ICustomAuthorizeEx CustomAuthorizeEx;

        public CustomAuthorizeAttribute(string FunctionID, string ActionName)
        {
            this.FunctionID = FunctionID;
            this.ActionName = ActionName;
        }
        public CustomAuthorizeAttribute()
        {

        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (CustomAuthorizeAttribute.CustomAuthorizeEx != null && CustomAuthorizeAttribute.CustomAuthorizeEx.IsCacheUser(actionContext.Request.GetHeader("UserId")) == false)
            {
                return false;
            }
            if (CustomAuthorizeAttribute.CustomAuthorizeEx != null && CustomAuthorizeAttribute.CustomAuthorizeEx.IsPermision(actionContext.Request.GetHeader("UserId"), this.FunctionID, this.ActionName, actionContext.Request.GetHeader("Role")) == false)
            {
                return false;
            }
            var _IsAuthorized = base.IsAuthorized(actionContext);
            return _IsAuthorized;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            base.HandleUnauthorizedRequest(actionContext);
        }
    }

    public interface ICustomAuthorizeEx
    {
        bool IsCacheUser(string username);
        bool IsPermision(string userName, string FunctionID, string ActionName, string Role);

        IQueryable<T> GetViewPer<T>(IQueryable<T> query, string username, string buid, string EntityName, IRepository Repository) where T : class;
    }
}
