using LV.Core.DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LV.Service.Common
{
     public class LVSessionHelper
    {
        public LVSessionHelper() { }

        public LVLoginUser LoginUser
        {
            get {
                var login = HttpContext.Current == null ? null : HttpContext.Current.Session["LoginUser"] as LVLoginUser;

                return login; 
            }
            set {
                HttpContext.Current.Session["LoginUser"] = value; 
            }
        }
    }
}
