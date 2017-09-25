using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LV.Common;
using LV.Core.DAL.Base;
using LV.Poco;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LV.Service.Common.Helper
{
    public static class LVPermissionHelper
    {
        public static IQueryable<T> GetViewPer<T>(IQueryable<T> query, HttpRequestMessage request, string FunctionID, IRepository Repository) where T : class
        {
            var username = request.GetHeader("username");              
            return GetViewPer(query, username, FunctionID, Repository);
        }
        //Lấy phân quyền du lieu
        public static IQueryable<T> GetViewPer<T>(IQueryable<T> query, string userCode, string FunctionID, IRepository Repository) where T:class{                        
            return query;
        } 
        //public static List<T> GetEditDeletePer<T>(List<T> Data, HttpRequestMessage request, string FunctionID, IRepository Repository)
        //{

        //    var cacheUser = LVCacheHelper.GetCacheUser(request.GetHeader("username"));
        //    var username = request.GetHeader("username");
        //    var buID = request.GetHeader("BUID");
        //    var grp = cacheUser.UMS_tblGroupAccount.Select(o => o.UserGroupID).Distinct();
        //    if (LVCacheHelper.GetCacheGolbal().AD_tblSetup.DataSecurity == false)
        //        return Data;

        //    if (cacheUser.UMS_tblUserAccount.FAdm || cacheUser.UMS_tblUserAccount.FSpv)
        //        return Data;
        //    var fuction = cacheUser.FunctionPermision.Where(o => o.FunctionID == FunctionID).FirstOrDefault();
        //    if (fuction == null || string.IsNullOrEmpty(fuction.EntityName))
        //        return Data;

        //    var edit = cacheUser.UMS_tblUserPermission.Where(o => o.FunctionID == FunctionID
        //                                                   && (o.ActionName.ToLower() == "edit")
        //                                                    ).Select(o => o.Value).Max();
        //    var delete = cacheUser.UMS_tblUserPermission.Where(o => o.FunctionID == FunctionID
        //                                                   && (o.ActionName.ToLower() == "delete")
        //                                                    ).Select(o => o.Value).Max();

        //    if ((edit == 4 || edit == 0) || (delete == 4 || delete == 0)) return Data;

        //    var batchNo = typeof(T).GetProperty("BatchNo");
        //    var createdBy = typeof(T).GetProperty("CreatedBy");
        //    var bU = typeof(T).GetProperty("BUID");
        //    var allowEdit = typeof(T).GetProperty("AllowEdit");
        //    var allowDelete = typeof(T).GetProperty("AllowDelete");
        //    var keys = typeof(T).GetProperties().Where(x => x.GetCustomAttributes(false).OfType<KeyAttribute>().Any())
        //                         .ToList().FirstOrDefault();
        //    List<string> userOfGroup = new List<string>();
        //    if (grp.Count() > 0)
        //        userOfGroup = LVCacheHelper.GetCacheGolbal().UMS_tblUserGroup.Where(o => grp.Contains(o.GroupID)).Select(o => o.UserID).ToList();

        //    var permissionExEdit = (from i in cacheUser.UMS_tblUserPermissionExp
        //                            join j in cacheUser.UMS_tblUserPermission on i.RefID equals j.ID
        //                            where j.FunctionID == FunctionID
        //                                && j.ActionName == "Edit"
        //                            select i).ToList();
        //    var predecateEdit = BuildPredicatePermissionEditView(edit,
        //        buID,
        //        userOfGroup,
        //        username,
        //        bU,
        //        batchNo,
        //        createdBy,
        //        permissionExEdit,
        //        typeof(T)
        //        );

        //    var permissionExDelete = (from i in cacheUser.UMS_tblUserPermissionExp
        //                              join j in cacheUser.UMS_tblUserPermission on i.RefID equals j.ID
        //                              where j.FunctionID == FunctionID
        //                                  && j.ActionName == "Delete"
        //                              select i).ToList();

        //    var predecateDelete = BuildPredicatePermissionEditView(delete,
        //        buID,
        //        userOfGroup,
        //        username,
        //        bU,
        //        batchNo,
        //        createdBy,
        //        permissionExDelete,
        //        typeof(T)
        //        );

        //    foreach (var item in Data)
        //    {
        //        List<T> p = new List<T>() { item };
        //        if (!string.IsNullOrEmpty(predecateEdit))
        //        {
        //            var p1 = p.AsQueryable().Where(predecateEdit);
        //            if (p1.Count() > 0 && allowEdit != null)
        //            {
        //                allowEdit.SetValue(item, true, null);
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(predecateDelete))
        //        {
        //            var p1 = p.AsQueryable().Where(predecateDelete);
        //            if (p1.Count() > 0 && allowDelete != null)
        //            {
        //                allowDelete.SetValue(item, true, null);
        //            }
        //        }


        //        if (keys != null)
        //        {
        //            object key = keys.GetValue(item, null);
        //            if (key != null)
        //            {
        //                if (LVCacheHelper.GetCacheGolbal().ShareRecored.ContainsKey(typeof(T).Name) &&
        //                    LVCacheHelper.GetCacheGolbal().ShareRecored[typeof(T).Name].ContainsKey(key)
        //                    )
        //                {
        //                    var share = LVCacheHelper.GetCacheGolbal().ShareRecored[typeof(T).Name][key];
        //                    if (share.ShareTo == username ||
        //                        grp.Contains(share.ShareTo)
        //                        )
        //                    {
        //                        if (share.Edit && allowEdit != null) allowEdit.SetValue(item, true, null);
        //                        if (share.Delete && allowDelete != null) allowDelete.SetValue(item, true, null);
        //                    }
        //                }
        //            }
        //        }


        //    }
        //    return Data;
        //}

        //private static string BuildPredicatePermissionEditView(short EditDelete,string BUID, List<string> UserOfGroup,  string userName,PropertyInfo bU, PropertyInfo batchNo, PropertyInfo createdBy, List<UMS_tblUserPermissionExp> UMS_tblUserPermissionExp, Type type)
        //{
        //    var predicate = "";
        //    if (EditDelete == 1 && createdBy != null)
        //    {
        //        predicate = predicate = predicate + "(CreatedBy!=null && CreatedBy.ToLower()=\"" + userName.ToLower() + "\") ";
        //    }
        //    if (EditDelete == 2 && createdBy != null)
        //    {
        //        foreach (var item in UserOfGroup)
        //        {
        //            if (predicate != "") predicate = predicate + " OR ";
        //            predicate = predicate = predicate + "(CreatedBy!=null &&  CreatedBy.ToLower()=\"" + item.ToLower() + "\") ";
        //        }

        //    }
        //    if (EditDelete == 3)
        //    {
        //        if (bU != null)
        //        {
        //            if (predicate != "") predicate = predicate + " OR ";
        //            predicate = predicate = predicate + "(BUID!=null && BUID.ToLower()=\"" + BUID.ToLower() + "\") ";
        //        }
        //        //batch No Chua lam
        //    }

        //    if (UMS_tblUserPermissionExp.Count > 0)
        //    {
        //        var pre = BuildPredicate(UMS_tblUserPermissionExp, type, "");
        //        if (pre != "")
        //        {
        //            if (predicate != "") predicate = predicate + " OR ";
        //            predicate = predicate = predicate + "(" + pre + ") ";
        //        }
        //    }
        //    return predicate;
        //}
        //private static string BuildPredicate(List<UMS_tblUserPermissionExp> UMS_tblUserPermissionExp, Type type, string aliasField)
        //{
        //    if (UMS_tblUserPermissionExp.Count == 0) return "";
        //    var predicate = "";
        //    foreach (var item in UMS_tblUserPermissionExp)
        //    {
        //        if (UMS_tblUserPermissionExp.IndexOf(item) != 0) predicate = predicate + " " + (string.IsNullOrEmpty(item.Condition) ? "and" : item.Condition) + " ";
        //        var pro = type.GetProperty(item.FieldName);
        //        if(pro!=null)
        //        {
        //            if(pro.PropertyType==typeof(bool) || pro.PropertyType == typeof(bool?)){
        //                predicate = predicate + BuildBool(item, aliasField);
        //            }
        //            else if (pro.PropertyType == typeof(int) || pro.PropertyType == typeof(int?)
        //                || pro.PropertyType == typeof(decimal) || pro.PropertyType == typeof(decimal?)
        //                || pro.PropertyType == typeof(short) || pro.PropertyType == typeof(short?)
        //                || pro.PropertyType == typeof(float) || pro.PropertyType == typeof(float?))
        //            {
        //                predicate = predicate + BuildNumber(item, aliasField);
        //            }
        //            else if (pro.PropertyType == typeof(DateTime) || pro.PropertyType == typeof(DateTime?))
        //            {
        //                predicate = predicate + BuildDate(item, aliasField);
        //            }
        //            else if (pro.PropertyType == typeof(string))
        //            {
        //                predicate = predicate + BuildString(item, aliasField);
        //            }
        //        }
        //    }
        //    return predicate;
        //}

        //private static string BuildString(UMS_tblUserPermissionExp Exp, string aliasField)
        //{
        //    var val = string.IsNullOrEmpty(Exp.Value) ? "" : Exp.Value;
        //    switch (Exp.Operator)
        //    {
        //        case "Con":
        //            return aliasField + Exp.FieldName + ".Contains(\"" + val + "\")";
        //        case "NotCon":
        //            return "!" + Exp.FieldName + ".Contains(\"" + val + "\")";
        //        case "Equals":
        //            return aliasField + Exp.FieldName + ".Equals(\"" + val + "\")";
        //        case "Diffirent":
        //            return "!" + aliasField + Exp.FieldName + ".Equals(\"" + val + "\")";
        //        case "Begin":
        //            return aliasField + Exp.FieldName + ".IndexOf(\"" + val + "\")==0";
        //    }

        //    return aliasField + Exp.FieldName + ".Equals(\"" + val + "\")";
        //}
        //private static string BuildBool(UMS_tblUserPermissionExp Exp,string aliasField)
        //{
        //    var val = string.IsNullOrEmpty(Exp.Value) ? "" : Exp.Value;
        //    if (val == "" || val == null || val == "0" || val == "False" || val == "false")
        //        val = "false";
        //    else
        //        val = "true";
        //    switch (Exp.Operator)
        //    {
        //        case "Equals":
        //            return aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //        case "Diffirent":
        //            return "!" + aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //    }

        //    return aliasField + Exp.FieldName + ".Equals(false)";

        //}
        //private static string BuildNumber(UMS_tblUserPermissionExp Exp, string aliasField)
        //{
        //    var val = string.IsNullOrEmpty(Exp.Value) ? "" : Exp.Value;
        //    decimal d=0;
        //    if(!decimal.TryParse(val,out d))
        //    {
        //        val = "0";
        //    }

        //    switch (Exp.Operator)
        //    {
        //        case "Equals":
        //            return aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //        case "Diffirent":
        //            return "!" + aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //        case "Smaller":
        //            return aliasField + Exp.FieldName + "<" + val;
        //        case "SmallerOrEquals":
        //            return aliasField + Exp.FieldName + "<=" + val;
        //        case "Larger":
        //            return aliasField + Exp.FieldName + ">" + val;
        //        case "LargerOrEquals":
        //            return aliasField + Exp.FieldName + ">=" + val;
        //    }

        //    return aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //}

        //private static string BuildDate(UMS_tblUserPermissionExp Exp, string aliasField)
        //{
        //    var val = string.IsNullOrEmpty(Exp.Value) ? "" : Exp.Value;
        //    DateTime? date = null;
        //    DateTime dateTime;
        //    if (DateTime.TryParseExact(val, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
        //    {
        //        date = dateTime;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            date = (DateTime)Convert.ChangeType(val, typeof(DateTime));
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }

            
            
        //    if (date.HasValue==false)
        //    {
        //        val = "DateTime(" + DateTime.Now.Year + "," + DateTime.Now.Month + "" + DateTime.Now.Day + ")";
        //    }
        //    else
        //    {
        //        val = "DateTime(" + date.Value.Year + "," + date.Value.Month + "" + date.Value.Day + ")";
        //    }

        //    switch (Exp.Operator)
        //    {
        //        case "Equals":
        //            return aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //        case "Diffirent":
        //            return "!" + aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //        case "Smaller":
        //            return aliasField + Exp.FieldName + "<" + val;
        //        case "SmallerOrEquals":
        //            return aliasField + Exp.FieldName + "<=" + val;
        //        case "Larger":
        //            return aliasField + Exp.FieldName + ">" + val;
        //        case "LargerOrEquals":
        //            return aliasField + Exp.FieldName + ">=" + val;
        //    }

        //    return aliasField + Exp.FieldName + ".Equals(" + val + ")";
        //}
    }
}
