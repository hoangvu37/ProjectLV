using LV.Core.DAL.Base;
using LV.Core.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LV.Common
{
    public static class LVValidateHelper
    {
        public static Dictionary<string, Dictionary<string, Dictionary<string, string>>> MessageCode = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

    }
    [Authorize]
    //[AllowAnonymous]
    public class LVApiController : ApiController, IDisposable
    {
        private IDALContainer DALContainer = null;
        //protected string language = "vi";
        protected string userAccount = string.Empty;
        public LVApiController()
        {
            DALContainer = new EFDALContainer();
            //language = GetLang();
            //userAccount = GetUserAccount();
        }

        public IRepository Repository
        {
            get
            {
                return DALContainer.Repository;
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return DALContainer.UnitOfWork;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (DALContainer != null)
            {
                DALContainer.Close();
                DALContainer.Dispose();
                DALContainer = null;
            }
            base.Dispose(disposing);
        }
        protected string GetLang()
        {
            string lang = "vi";
            //if (string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Request.Headers["language"]))
            if(System.Web.HttpContext.Current.Request.Headers["language"] == null)
                return lang;
            else
                return System.Web.HttpContext.Current.Request.Headers["language"];
        }
        protected string GetUserAccount()
        {
            string acountid = "0";
            //if (string.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Request.Headers["AccountID"]))
            if (System.Web.HttpContext.Current.Request.Headers["AccountID"] == null)
                return acountid;
            else
                return System.Web.HttpContext.Current.Request.Headers["AccountID"];
        }
    }
}
