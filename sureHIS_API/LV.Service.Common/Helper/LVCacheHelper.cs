using LV.Poco;
using LV.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LV.Service.Common.Helper;
using LV.Core.DAL.Base;
using LV.Poco.Model;
using System.Data;

namespace LV.Service.Common
{
    public class CustomAuthorizeEx : ICustomAuthorizeEx
    {
        //Lay record co quyen
        public IQueryable<T> GetViewPer<T>(IQueryable<T> query, string username, string buid, string EntityName, IRepository Repository) where T : class
        {
            if (string.IsNullOrEmpty(EntityName)) return query;
            string fuction = "";
            return LVPermissionHelper.GetViewPer(query, username, fuction, Repository); ;
            //var fuction = LVCacheHelper.GetCacheUser(username).FunctionPermision.Where(o => o.EntityName == EntityName).FirstOrDefault();
            //if (fuction == null) return query;
            //return LVPermissionHelper.GetViewPer(query, username, buid, fuction.FunctionID, Repository);
        }
        //Ktra user co cache user. Neu xoa cache phai login lai
        public bool IsCacheUser(string username)
        {
            return LVCacheHelper.GetCacheUser(username) != null;
        }
        //Ktra co quyen tren application
        public bool IsPermision(string userName, string FunctionID, string ActionName,string Role)
        {
            try
            {
                var user = LVCacheHelper.GetCacheUser(userName);
                if (FunctionID == null) {
                    return true;
                }
                var appId = long.Parse(FunctionID);
                if (user != null)
                {
                    long role = long.Parse(Role);
                    var applicationByRole = (from h in user.roleList
                                             from i in h.application
                                             where h.RoleID == role && i.AppFuncID == appId
                                             select i).FirstOrDefault();
                    if (applicationByRole != null)
                    {
                        var permission = (from h in user.PrivilegeRole
                                         where h.AppFuncID == applicationByRole.AppFuncID
                                         select h.PersPer).FirstOrDefault();
                        if (permission != null) {            
                            var perByRole = permission.Where(x => x == ActionName || x == "SS" || x == "SA").FirstOrDefault();
                            if (perByRole != null) {
                                return true;
                            }
                        }
                    }
                    return false;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            //var per = (from i in LVCacheHelper.GetCacheUser(userName).UMS_tblUserPermission.Where(o => o.FunctionID == FunctionID && o.ActionName == ActionName)
            //           group i by i.ActionName into grp
            //           select new
            //           {
            //               Value = grp.Max(o => o.Value)
            //           }).FirstOrDefault();
            var model = LVCacheHelper.GetCacheUser(userName);
            var func = long.Parse(FunctionID);
            //var per = (from h in model.PrivilegeRole
            //           join i in model.FunctionPermision on h.AppFuncID equals i.AppFuncID
            //           where i.AppFuncID == func
            //           select h.PersPer).ToList();
            bool isView = false;
            //if (per != null)
            //    isView = per.Value != 0;
            //isView = isView || LVCacheHelper.GetCacheUser(userName).UMS_tblUserAccount.FAdm || LVCacheHelper.GetCacheUser(userName).UMS_tblUserAccount.FSpv;
            //if (per.Count > 0)
            //{
            //    var action = per[0].Find(x => x == ActionName);
            //    if (action.Length > 0)
            //    {
            //        isView = true;
            //    }
            //}
            return isView;
        }
    }
    public class RoleList
    {
        public long RoleID { get; set; }
        public string RoleName { get; set; }
        public bool IsPrimaryRole { get; set; }
        public List<Application> application { get; set; }
    }
    public class CacheUser
    {
        public long PersonID { get; set; }
        public string PersonName { get; set; }
        public long Code { get; set; }
        public long AccountID { get; set; }
        public List<RoleList> roleList { get; set; }
        public List<PrivilegeRole> PrivilegeRole { get; set; }
        // public List<Application> FunctionPermision { get; set; }
        // public List<TreeViewObject> treeFunction { get; set; }
    }
    //Cache nhung application chung
    public class CacheGolbal
    {
       // public List<Application> Application { get; set; }
    }

    //Xu ly cache
    public static class LVCacheHelper
    {
        static LVCacheHelper()
        {
            CustomAuthorizeAttribute.CustomAuthorizeEx = new CustomAuthorizeEx();
        }
        public static Dictionary<string, Dictionary<string, LVLoginUser>> ManagerSession = new Dictionary<string, Dictionary<string, LVLoginUser>>();
        //UserLogin
        public static LVLoginUser LoginUser
        {
            get { return (new LVSessionHelper()).LoginUser; }
        }
        public static string DefaultLanguage = "VN";

        private static Dictionary<string, CacheUser> _cacheUser = new Dictionary<string, CacheUser>();
        private static CacheGolbal _cacheGolbal = null;
        public static CacheGolbal GetCacheGolbal()
        {
            return _cacheGolbal;
        }
        public static CacheUser GetCacheUser(string userName)
        {
            userName = (userName == null ? "" : userName).ToLower();
            if (_cacheUser.ContainsKey(userName))
                return _cacheUser[userName];
            return null;
        }
        public static void RemoveCacheUser(string userName)
        {
            userName = userName.ToLower();
            if (_cacheUser.ContainsKey(userName))
                _cacheUser.Remove(userName);
        }
        public static void initCacheLogin(string userName, string PersonName, long Code, long accountID, long personID)
        {
            if (_cacheUser.ContainsKey(userName)) return;

            lock (_cacheUser)
            {
                CacheUser c = new CacheUser();

                using (LV.Core.DAL.EntityFramework.EFDALContainer ef = new Core.DAL.EntityFramework.EFDALContainer())
                {
                    var obj = new object[1] { accountID };
                    c.PersonID = personID;
                    c.AccountID = accountID;
                    c.PersonName = PersonName;
                    c.Code = Code;

                    DataSet model = ef.Repository.ExecuteStoreScalar("usp_GetPerApplication", obj);
                    DataTable dt = model.Tables[0];
                    Dictionary<byte, string> PermissionList = GetPermission();
                    c.PrivilegeRole = new List<PrivilegeRole>();
                    List<Application> functionPermision = new List<Application>();
                    foreach (DataRow item in dt.Rows)
                    {

                        PrivilegeRole p = new PrivilegeRole();
                        p.AppFuncID = item.IsNull("AppFuncID") ? 0 : item.Field<long>("AppFuncID");
                        p.PermVals = item.IsNull("PermVals") ? (byte)0 : item.Field<byte>("PermVals");
                        p.PersPer = GetPerListValue(p.PermVals, PermissionList);
                        c.PrivilegeRole.Add(p);
                        Application application = new Application();
                        application.AppFunctions = item.Field<string>("AppFunctions");
                        application.Badge = item.Field<string>("Badge");
                        application.IsLongTile = item.IsNull("IsLongTile") ? false : item.Field<bool>("IsLongTile");
                        application.AppFuncID = item.IsNull("AppFuncID") ? 0 : item.Field<long>("AppFuncID");
                        application.IconPath = item.Field<string>("IconPath");
                        application.LandingPageURL = item.Field<string>("LandingPageURL");
                        application.PAppFuncID = item.IsNull("PAppFuncID") ? 0 : item.Field<long>("PAppFuncID");
                        application.Idx = item.IsNull("Idx") ? (byte)0 : item.Field<byte>("Idx");
                        application.AppTitle = item.Field<string>("AppTitle").Replace("|n|", "");
                        application.AppDesc = item.Field<string>("AppDesc");
                        application.ColorSchema = item.Field<string>("ColorSchema");
                        application.NotDisplayed = item.IsNull("NotDisplayed") ? false : item.Field<bool>("NotDisplayed");
                        application.FuncType = item.Field<string>("FuncType");
                        functionPermision.Add(application);
                    }
                    //Danh sach role cua user
                    c.roleList = (from h in ef.Repository.GetQuery<PersonRole>()
                                  join i in ef.Repository.GetQuery<Person>() on h.PersonID equals i.PersonID
                                  join j in ef.Repository.GetQuery<refRole>() on h.RoleID equals j.RoleID
                                  where h.PersonID == Code
                                  select new RoleList
                                  {
                                      RoleID = h.RoleID,
                                      RoleName = j.RoleName,
                                      IsPrimaryRole = h.IsPrimaryRole,
                                  }).ToList();
                    var ApplicationList = ef.Repository.GetQuery<Application>().ToList();
                    foreach (var role in c.roleList)
                    {
                        List<Realms> applicationByRole = (from h in ef.Repository.GetQuery<Realms>() where h.RoleID == role.RoleID select h).ToList();
                        role.application = (from h in functionPermision
                                            join k in applicationByRole on h.AppFuncID equals k.AppFuncID
                                            select h).ToList();
                    }
                    //
                    //var applicationList = _cacheGolbal.Application.ToList();
                    //var results = c.FunctionPermision.DistinctBy(x => x.PAppFuncID).ToList();
                    //c.treeFunction = new List<TreeViewObject>();
                    //foreach (var item in results)
                    //{
                    //    var row = applicationList.Where(x => x.AppFuncID == item.PAppFuncID).FirstOrDefault();
                    //    while (row.PAppFuncID != null)
                    //    {
                    //        if (row != null)
                    //        {
                    //            var check = c.FunctionPermision.Where(x => x.AppFuncID == row.AppFuncID).FirstOrDefault();
                    //            if (check == null)
                    //            {
                    //                c.FunctionPermision.Add(row);
                    //            }
                    //            row = applicationList.Where(x => x.AppFuncID == row.PAppFuncID).FirstOrDefault();
                    //            if (row == null)
                    //            {
                    //                break;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            break;
                    //        }
                    //    }
                    //    if (row.PAppFuncID == null)
                    //    {
                    //        var check = c.FunctionPermision.Where(x => x.AppFuncID == row.AppFuncID).FirstOrDefault();
                    //        if (check == null)
                    //        {
                    //            c.FunctionPermision.Add(row);
                    //        }
                    //    }
                    //}
                    //var parent = c.FunctionPermision.Where(x => x.PAppFuncID == null).ToList();
                    //foreach (var item in parent)
                    //{
                    //    Application application = new Application();
                    //    application.AppFunctions = item.AppFunctions;
                    //    application.Badge = item.Badge;
                    //    application.IsLongTile = item.IsLongTile;
                    //    application.AppFuncID = item.AppFuncID;
                    //    application.IconPath = item.IconPath;
                    //    application.LandingPageURL = item.LandingPageURL;
                    //    application.PAppFuncID = item.PAppFuncID;
                    //    application.Idx = item.Idx;
                    //    application.AppTitle = item.AppTitle.Replace("|n|", "");
                    //    application.AppDesc = item.AppDesc;
                    //    application.ColorSchema = item.ColorSchema;
                    //    application.NotDisplayed = item.NotDisplayed;
                    //    application.FuncType = item.FuncType;
                    //    var trs = new TreeViewObject() { application = application };
                    //    buildTree(trs, c.FunctionPermision);
                    //    c.treeFunction.Add(trs);
                    //}
                    _cacheUser.Add(userName, c);
                }
            }
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
                    application.NotDisplayed = item.NotDisplayed;
                    application.FuncType = item.FuncType;
                    var tree = new TreeViewObject() { application = application };
                    buildTree(tree, dt);
                    currentTree.items.Add(tree);

                }
            }
        }

        private static List<string> GetPerListValue(int num, Dictionary<byte, string> PermissionList)
        {
            List<string> PerList = new List<string>();
            if (num == 255 || num == 128)
            {
                PerList.Add(GetNameFromDicKey(byte.Parse(num.ToString()), PermissionList));
            }
            else
            {
                int index = 0;
                while (num > 0)
                {
                    double value = num % 2;
                    if (value == 1)
                    {
                        value = Math.Pow(2, index);
                        PerList.Add(GetNameFromDicKey(byte.Parse(value.ToString()), PermissionList));
                    }

                    num = num / 2;
                    index++;
                }
            }
            return PerList;

        }
        private static Dictionary<byte, string> GetPermission()
        {
            Dictionary<byte, string> dicPermission = new Dictionary<byte, string>();
            using (LV.Core.DAL.EntityFramework.EFDALContainer ef = new Core.DAL.EntityFramework.EFDALContainer())
            {
                return dicPermission = (from h in ef.Repository.GetQuery<refPermission>() select new { h.PermVal, h.PermName }).ToDictionary(h => h.PermVal, h => h.PermName);
            }
        }
        private static string GetNameFromDicKey(byte strKey, Dictionary<byte, string> dic)
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

        public static void initCacheGolbal()
        {
            _cacheGolbal = new CacheGolbal();
            using (LV.Core.DAL.EntityFramework.EFDALContainer ef = new Core.DAL.EntityFramework.EFDALContainer())
            {
               // _cacheGolbal.Application = ef.Repository.GetQuery<Application>().ToList();
            }
        }

    }
}
