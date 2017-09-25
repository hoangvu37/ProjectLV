using LV.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace LV.Service.Common
{
    //[AllowAnonymous]
    [RoutePrefix("api/LVAutoComplete")]
    public class LVAutoCompleteController : LVApiController
    {

        [Route("LoadDataSource")]
        [HttpGet]
        public IHttpActionResult LoadDataSource(string entityName, int pageNum, int pageSize, string tableFields, string predicate, string valuePredicate,
            string fieldFilter, string fieldSorting, string sortDirection, bool pageLoading,
            string fieldCustomPredicate, string valueCustomPredicate)
        {
            return _LoadDataSource(entityName, pageNum, pageSize, tableFields, predicate, valuePredicate, fieldSorting, sortDirection, pageLoading);
        }


        private IHttpActionResult _LoadDataSource(string entityName, int pageNum, int pageSize, string tableFields, string predicate, string valuePredicate, string fieldSorting, string sortDirection, bool pageLoading, string queryString = "", string ClassName = "", string Method = "")
        {
            DataServiceModel dataModel = new DataServiceModel();
            dataModel.TypeName = entityName;
            dataModel.BUID = "";
            dataModel.UserID = "";
            dataModel.PageNum = pageNum;
            dataModel.PageSize = pageSize;
            dataModel.IsViewBUHierarchy = false;
            dataModel.Predicate = predicate;
            dataModel.DataValue = valuePredicate == null ? new string[] { } : valuePredicate.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            dataModel.IsPageLoading = pageLoading;
            dataModel.IsSetDataPermission = false;
            // dataModel.QueryString = queryString;
            if (String.IsNullOrEmpty(fieldSorting) == false)
                dataModel.SortColumns = fieldSorting.Split(';');

            if (String.IsNullOrEmpty(sortDirection) == false)
                dataModel.SortDirections = sortDirection.Split(';');

            if (String.IsNullOrEmpty(tableFields) == false)
            {
                string[] fields = tableFields.Split(';');
                string selector = string.Empty;
                for (int i = 0; i < fields.Length; i++)
                {
                    if (selector == string.Empty)
                        selector = "it." + fields[i] + " as " + fields[i];
                    else
                        selector += "," + "it." + fields[i] + " as " + fields[i];
                }

                dataModel.Selector = String.Format("new({0})", selector);
            }

            Type oType = PocoHelper.GetTypeFromString(dataModel.TypeName);
            var listData = DynamicAssembly.InvokeGenericMethod(oType, this, "LoadDataSourceLogic", dataModel, ClassName, Method);


            string selectString = "new (";

            var listproperty = tableFields.Split(';');
            foreach (var item in listproperty)
            {
                var it = item.Trim();
                if (selectString != "new (")
                    selectString = selectString + ",";

                selectString = selectString + it + " as " + it;

            }
            selectString = selectString + ")";

            if (listData != null)
                listData = ((IList)listData).AsQueryable().Select(selectString, null);

            return Json(listData);
        }

        public IList<TEntity> LoadDataSourceLogic<TEntity>(DataServiceModel oDSM, string ClassName = "", string Method = "") where TEntity : class
        {
            IList<TEntity> listData = null;
            if (!string.IsNullOrEmpty(ClassName))
            {
                //listData = LVDataHelper.Execute<IList<TEntity>>(ClassName.Substring(0, ClassName.LastIndexOf(".")), ClassName.Substring(ClassName.LastIndexOf(".") + 1, ClassName.Length - ClassName.LastIndexOf(".") - 1), Method, "", oDSM);
            }
            else
            {
                var stop = typeof(TEntity).GetProperty("Stop");
                if (stop != null)
                {
                    if (!string.IsNullOrEmpty(oDSM.Predicate))
                    {
                        oDSM.Predicate = "(" + oDSM.Predicate + ")" + "&&Stop=false";
                    }
                    else
                    {
                        oDSM.Predicate = "Stop=false";
                    }
                }
                DataServices ds = new DataServices();

                listData = ds.GetData(oDSM) as IList<TEntity>;
            }
            return listData;
        }

    }
}
