using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HealthCareAPI.Models
{
    public class RefAuthor
    {
        public List<Type> GetControllers(string namespaces)
        {
            List<Type> listcontroller = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(namespaces)).OrderBy(x => x.Name);
            return types.ToList();
        }
        public List<string> GetActions(Type controller)
        {
            List<string> listaction = new List<string>();
            IEnumerable<MemberInfo> memberinfor = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly |
                BindingFlags.Public).Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any()).OrderBy(x => x.Name);
            foreach (MethodInfo method in memberinfor)
            {
                if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                {
                    listaction.Add(method.Name.ToString());
                }
            }
            return listaction;
        }
    }
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filtercontetx)
        {
            //    modal.UserName = Request.Cookies["username"].Value;
            //CommonController cm = new CommonController();
            //string AccountID = "";
            //AccountID = cm.getAccountID();
            //string ControllerName = filtercontetx.ActionDescriptor.ControllerDescriptor.ControllerName;
            //string ActionName = filtercontetx.ActionDescriptor.ActionName;
            //AccountRepository _ac = new AccountRepository();
            ////string acctionname = filtercontetx.ActionDescriptor.ControllerDescriptor.ControllerName + "-" + filtercontetx.ActionDescriptor.ActionName;
            //List<Permission> per = new List<Permission>();
            //per = _ac.CheckPermission(AccountID, ControllerName, ActionName);
            //if (per.Count() <= 0)
            //{
            //    if (AccountID.Trim() == "")
            //        filtercontetx.Result = new RedirectResult("~/Admin/"+ ControllerName+"/"+ ActionName);
            //    else
            //        filtercontetx.Result = new RedirectResult("~/Admin/Common/NoPermission");
            //}
            string[] test = filtercontetx.HttpContext.Request.Params.AllKeys;
        }
    }
}