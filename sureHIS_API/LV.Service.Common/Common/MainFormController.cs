using LV.Common;
using LV.Poco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LV.Poco;
using LV.Core.DAL.EntityFramework;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Web.Configuration;
using System.Data;

namespace LV.Service.Common
{
    //public class tree
    //{
    //    public Application application { get; set; }
    //    public Int64 RoleID { get; set; }
    //    public int dataindex { get; set; }
    //    public List<tree> items = new List<tree>();
    //}    
    [RoutePrefix("api/Application")]

    public class MainFormController : LVApiController
    {
        [Route("GetApplication")]
        [HttpGet]
        public IHttpActionResult GetApplication(string User="",string RoleID="")
        {
            try
            {
                if (string.IsNullOrEmpty(User))
                    User = Request.GetHeader("UserId");
                if (string.IsNullOrEmpty(RoleID))
                    RoleID = Request.GetHeader("Role");
                long? Role = null;
                if (!string.IsNullOrEmpty(RoleID))
                    Role = Convert.ToInt64(RoleID);
                List<Application> treeApplication = this.Repository.GetQuery<Application>().ToList();
                List<TreeViewObject> tree = buildTreeApplication(treeApplication, User, Role);
                return Ok(tree);

            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }

        [Route("GetTreeApplication")]
        [HttpGet]
        public IHttpActionResult GetTreeApplication()
        {
            try
            {
                string user = Request.GetHeader("UserId");
                string Roletemp = Request.GetHeader("Role");
                long? roleID = null;
                if (!string.IsNullOrEmpty(Roletemp))
                    roleID = Convert.ToInt64(Roletemp);
                List<Application> treeApplication = this.Repository.GetQuery<Application>().Where(x=>x.FuncType != "I").ToList();
                List<TreeViewObject> tree = buildTreeApplication(treeApplication, user, roleID);
                return Ok(tree);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }

        private List<TreeViewObject> buildTreeApplication(List<Application> application, string userName, long? Role)
        {
            CacheUser cacheUser = LVCacheHelper.GetCacheUser(userName);
            if (cacheUser == null)
            {
                return null;
            }
            int indexs = 1;
            var roleList = cacheUser.roleList.Where(x => x.RoleID == Role).FirstOrDefault(); ;
            if (roleList != null)
            {
                foreach (var item in application)
                {                    
                    foreach (var app in roleList.application) {

                        item.IsShow = app.AppFuncID == item.AppFuncID ? true : false;
                        if (item.IsShow == true) {
                            break;
                        }
                    }                    
                }
            }

            var parent = application.Where(x => x.PAppFuncID == null).ToList();
            List<TreeViewObject> treeParent = new List<TreeViewObject>();
            foreach (var item in parent)
            {
                Application applications = new Application();
                applications.AppFunctions = item.AppFunctions;
                applications.Badge = item.Badge;
                applications.IsLongTile = item.IsLongTile;
                applications.AppFuncID = item.AppFuncID;
                applications.IconPath = item.IconPath;
                applications.LandingPageURL = item.LandingPageURL;
                applications.PAppFuncID = item.PAppFuncID;
                applications.Idx = item.Idx;
                applications.AppTitle = item.AppTitle.Replace("|n|", "");
                applications.AppDesc = item.AppDesc;
                applications.ColorSchema = item.ColorSchema;
                applications.Colors = string.IsNullOrEmpty(item.ColorSchema) ? null : item.ColorSchema.Split(';');
                applications.NotDisplayed = item.NotDisplayed;
                applications.FuncType = item.FuncType;                
                var trs = new TreeViewObject() { application = applications };
                buildTree(trs, application);
                trs.dataindex = indexs;
                treeParent.Add(trs);
                indexs++;
            }
            return treeParent;
        }
        private static void buildTree(TreeViewObject currentTree, List<Application> dt)
        {
            if (currentTree != null && currentTree.application.AppFuncID != 0)
            {
                currentTree.items = new List<TreeViewObject>();
                var results = (from h in dt where h.PAppFuncID == currentTree.application.AppFuncID select h);
                foreach (var item in results)
                {
                    Application application = new Application();
                    application.AppFunctions = item.AppFunctions;
                    application.Badge = item.Badge;
                    application.IsLongTile = item.IsLongTile;
                    application.AppFuncID = item.AppFuncID;
                    application.IconPath = item.IconPath;
                    application.LandingPageURL = item.LandingPageURL;
                    application.PAppFuncID = item.PAppFuncID;
                    application.Idx = item.Idx;
                    application.AppTitle = item.AppTitle.Replace("|n|", "");
                    application.AppDesc = item.AppDesc;
                    application.ColorSchema = item.ColorSchema;
                    application.Colors = string.IsNullOrEmpty(item.ColorSchema) ? null : item.ColorSchema.Split(';');
                    application.NotDisplayed = item.NotDisplayed;
                    application.FuncType = item.FuncType;
                    application.IsShow = item.IsShow;
                    var tree = new TreeViewObject() { application = application };
                    buildTree(tree, dt);
                    currentTree.items.Add(tree);

                }
            }
        }
        //private void buildTree(tree currentTree, DataTable dt)
        //{
        //    if (currentTree != null && currentTree.application.AppFuncID != 0)
        //    {
        //        var results = dt.Rows.Cast<DataRow>().Where(x => x.Field<Int64?>("PAppFuncID") == currentTree.application.AppFuncID);
        //        foreach (var item in results)
        //        {
        //            Application application = new Application();
        //            application.AppFunctions = item.Field<string>("AppFunctions");
        //            application.Badge = item.Field<string>("Badge");
        //            application.IsLongTile = item.IsNull("IsLongTile") ? false : item.Field<bool>("IsLongTile");
        //            application.AppFuncID = item.IsNull("AppFuncID") ? 0 : item.Field<long>("AppFuncID");
        //            application.IconPath = item.Field<string>("IconPath");
        //            application.LandingPageURL = item.Field<string>("LandingPageURL");
        //            application.PAppFuncID = item.IsNull("PAppFuncID") ? 0 : item.Field<long>("PAppFuncID");
        //            application.Idx = item.IsNull("Idx") ? (byte)0 : item.Field<byte>("Idx");
        //            application.AppTitle = item.Field<string>("AppTitle").Replace("|n|", "");
        //            application.AppDesc = item.Field<string>("AppDesc");
        //            application.ColorSchema = item.Field<string>("ColorSchema");
        //            application.NotDisplayed = item.IsNull("NotDisplayed") ? false : item.Field<bool>("NotDisplayed");
        //            application.FuncType = item.Field<string>("FuncType");
        //            var tree = new Service.Common.tree() { application = application };
        //            buildTree(tree, dt);
        //            currentTree.items.Add(tree);
        //        }
        //    }
        //}
    }


}
