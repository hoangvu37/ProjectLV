using LV.Core.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LV.Poco;

namespace LV.Common
{
    public class DataServices
    {

        public object GetDataAndRowCount(DataServiceModel oData)
        {
            try
            {

                Type oType = PocoHelper.GetTypeFromString(oData.TypeName);
                object oReturn = DynamicAssembly.InvokeGenericMethod(oType, this, "GetDataAndRowCountLogic", oData);
                return oReturn;
            }
            catch 
            {
                return null;
            }

        }

        /// <summary>
        /// Thực hiện việc lấy dữ liệu và đếm tổng số dòng trong bảng
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="oDSM"></param>
        /// <returns></returns>


        public object GetData(DataServiceModel oData)
        {
            Type oType = PocoHelper.GetTypeFromString(oData.TypeName);
            return DynamicAssembly.InvokeGenericMethod(oType, this, "GetDataLogic", oData);
        }
      

        public IList<TEntity> GetDataLogic<TEntity>(DataServiceModel oDSM) where TEntity : class
        {
            TEntity[] listData = new TEntity[0];
            string entityName = typeof(TEntity).Name;
            bool recoredLevelControl = false;

            IQueryable<TEntity> query = GenerateGetDataQuery<TEntity>(oDSM, recoredLevelControl);
            if (oDSM.IsPageLoading)
            {
                query = GenerateSortOrder(query, oDSM.SortColumns, oDSM.SortDirections);
                query = System.Linq.Queryable.Skip(query, oDSM.PageNum);
                query = System.Linq.Queryable.Take(query, oDSM.PageSize);
                listData = query.Distinct().ToArray();
            }
            else
            {
                query = query.Distinct();
                query = GenerateSortOrder(query, oDSM.SortColumns, oDSM.SortDirections);
                listData = query.ToArray();
            }
            return listData;
        }

        public async Task<object> GetDataAsync(DataServiceModel oData)
        {
            Type oType = PocoHelper.GetTypeFromString(oData.TypeName);
            var task=await DynamicAssembly.InvokeGenericMethodObjAsync(oType, this, "GetDataLogicAsync", oData);
            return task;
        }


        public async Task<object> GetDataLogicAsync<TEntity>(DataServiceModel oDSM) where TEntity : class
        {
            TEntity[] listData = new TEntity[0];
            string entityName = typeof(TEntity).Name;
            bool recoredLevelControl = false;

            IQueryable<TEntity> query = GenerateGetDataQuery<TEntity>(oDSM, recoredLevelControl);
            if (oDSM.IsPageLoading)
            {
                query = GenerateSortOrder(query, oDSM.SortColumns, oDSM.SortDirections);
                query = System.Linq.Queryable.Skip(query, oDSM.PageNum);
                query = System.Linq.Queryable.Take(query, oDSM.PageSize);
                listData = await query.Distinct().ToArrayAsync();
            }
            else
            {
                query = System.Linq.Queryable.Take(query, 5000);
                query = query.Distinct();
                query = GenerateSortOrder(query, oDSM.SortColumns, oDSM.SortDirections);
                listData = query.ToArray();//await query.ToArrayAsync();
            }
            return listData;
        }
       

        public IQueryable<TEntity> GenerateGetDataQuery<TEntity>(DataServiceModel oDSM, bool recoredLevelControl) where TEntity : class
        {
            #region Get data
            var DALContainer = new EFDALContainer();
            //IQueryable<TEntity> query = LVHubsHelper.GetDataInHubs<TEntity>(DALContainer.Repository);
            //if(query == null)
            IQueryable<TEntity> query = DALContainer.Repository.GetQuery<TEntity>(oDSM.TableInclue);

            if (!String.IsNullOrWhiteSpace(oDSM.PredicateFavorite))
                query = query.Where(oDSM.PredicateFavorite);

            if (!String.IsNullOrWhiteSpace(oDSM.Predicate))
            {
                if (oDSM.Predicate.IndexOf("Nullable_") >= 0)
                {
                    Guid nullGuid = Guid.Parse(oDSM.DataValue[0].ToString());
                    query = query.Where(oDSM.Predicate.Replace("Nullable_", "") + ".Value.Equals(@0)", nullGuid);
                }
                else
                    query = query.Where(oDSM.Predicate, oDSM.DataValue);
            }

            if (!String.IsNullOrWhiteSpace(oDSM.PredicateQuickSearch) && oDSM.DataValueQuick != null)
                query = query.Where(oDSM.PredicateQuickSearch, oDSM.DataValueQuick);

            if (oDSM.Predicates != null && oDSM.DataValues != null)
            {
                for (int i = 0; i < oDSM.Predicates.Count; i++)
                {
                    object[] oDataValue = null;
                    if (oDSM.DataValues.Count > i)
                        oDataValue = oDSM.DataValues[i];

                    query = query.Where(oDSM.Predicates[i], oDataValue);
                }
            }

            #endregion

            return query;
        }

        public static IQueryable<TEntity> GenerateSortOrder<TEntity>(IQueryable<TEntity> query, string[] sortColumns, string[] sortDirections) where TEntity : class
        {
            if (sortColumns != null)
            {
                for (int i = 0; i < sortColumns.Length; i++)
                {
                    string direction = "asc";

                    if (sortDirections != null && sortDirections.Length > i)
                        direction = sortDirections[i];

                    switch (direction.ToLower())
                    {
                        case "asc":
                            if (i > 0)
                                query = query.OrderBy(sortColumns[i]);
                            else
                                query = query.OrderBy(sortColumns[i]);
                            break;
                        case "desc":
                            if (i > 0)
                                query = query.OrderBy(sortColumns[i]);
                            else
                                query = query.OrderBy(sortColumns[i]);
                            break;
                    }
                }
            }

            return query;
        }

        public object GetDataPaging(DataServiceModel oData)
        {
            Type oType = PocoHelper.GetTypeFromString(oData.TypeName);
            return DynamicAssembly.InvokeGenericMethod(oType, this, "GetDataPagingLogic", oData);
        }
        public async Task<object> GetDataPagingAsync(DataServiceModel oData)
        {
            Type oType = PocoHelper.GetTypeFromString(oData.TypeName);
            return await DynamicAssembly.InvokeGenericMethodAsync(oType, this, "GetDataPagingLogicAsync", oData);
        }

        public object[] GetDataPagingLogic<TEntity>(DataServiceModel oDSM) where TEntity : class
        {
            TEntity[] listData = new TEntity[0];

            string entityName = typeof(TEntity).Name;

            IQueryable<TEntity> query = GenerateGetDataQuery<TEntity>(oDSM, false);

            query = GenerateSortOrder(query, oDSM.SortColumns, oDSM.SortDirections);
            int total = query.Distinct().Count();
            query = System.Linq.Queryable.Skip(query, oDSM.PageNum);
            query = System.Linq.Queryable.Take(query, oDSM.PageSize);
            listData = query
                            .Distinct()
                            .ToArray();
            return new object[] { listData, total };
        }

        public async Task<object[]> GetDataPagingLogicAsync<TEntity>(DataServiceModel oDSM) where TEntity : class
        {
            TEntity[] listData = new TEntity[0];

            string entityName = typeof(TEntity).Name;

            IQueryable<TEntity> query = GenerateGetDataQuery<TEntity>(oDSM, false);

            query = GenerateSortOrder(query, oDSM.SortColumns, oDSM.SortDirections);
            int total = query.Distinct().Count();
            query = System.Linq.Queryable.Skip(query, oDSM.PageNum);
            query = System.Linq.Queryable.Take(query, oDSM.PageSize);
            Task<TEntity[]> task = query.Distinct().ToArrayAsync();
            listData = await task;
            EFDALContainer d = new EFDALContainer();
            return new object[] { listData, total };
        }

        /// <summary>
        /// Phương thức cho phép lọc tất cả các field và phân trang dành cho combobox phân trang
        /// </summary>
        /// <typeparam name="T">Kiểu Entity</typeparam>
        /// <param name="dsm">DataServiceModel - Mô hình chuẩn truyền dữ liệu</param>
        /// <param name="textfields">Tên tất cả các field trong 1 combobox/autocomplete/... hiện tại</param>
        /// <param name="query">Câu lệnh query (chưa có .ToList hay .ToArray)</param>
        /// <returns>Đối tượng đã được lọc và phân trang</returns>
        public static object[] FilterAndOrderBy<TEntity>(DataServiceModel dsm, string textfields, IQueryable<TEntity> query) where TEntity : class
        {
            var value = dsm.DataValue[1].ToString();
            var cols = textfields.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);//lấy fieldName textfields (chỉ có ở combobox)
            var str = "";
            var count = 0;

            foreach (var col in cols)
            {
                str += col + ".Contains(@" + count.ToString() + ")" + "||";
                count++;
            }

            if (str.Length > 2)
            {
                str = str.Substring(0, str.Length - 2);
                query = query.Where(str, value, value, value);
            }
            query = GenerateSortOrder<TEntity>(query, cols, dsm.SortDirections);
            var total = query.Count();
            query = System.Linq.Queryable.Skip(query, dsm.PageNum);
            query = System.Linq.Queryable.Take(query, dsm.PageSize);
            var result = query.ToList();
            return new object[] { result, total };
        }
       
    }
}
