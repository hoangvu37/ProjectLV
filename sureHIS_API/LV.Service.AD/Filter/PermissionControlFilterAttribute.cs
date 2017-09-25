using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace LV.Service.AD.Filter
{
    public class PermissionControlFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //var permissions = GetUserPermissions(User.Identity.Name);
            // check if the user has permission for the action and
            // can read, write or delete according to the model type
            // and rules defined for this model type
        }
    }
}