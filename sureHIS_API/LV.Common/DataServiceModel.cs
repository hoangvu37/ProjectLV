using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Common
{
    /// <summary>
    /// Mô hình chuẩn để truyền dữ liệu giữa các service
    /// </summary>
    [Serializable]
    public class DataServiceModel
    {
        /// <summary>
        /// Cho biết dữ liệu có phân trang không. Nếu mang giá trị "true" thì sẽ phân trang
        /// </summary>
        public bool IsPageLoading { get; set; }

        public bool IsViewBUHierarchy { get; set; }

        /// <summary>
        /// Toán tử (And,Or)
        /// </summary>
        public string Operation { get; set; }

        public string QueryString { get; set; }


        public string Selector { get; set; }

        /// <summary>
        /// Các table được include vào
        /// </summary>
        public string[] TableInclue { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Đơn vị kinh doanh
        /// </summary>
        public string BUID { get; set; }

        /// <summary>
        /// Tên các cột sắp xếp 
        /// </summary>
        public string[] SortColumns { get; set; }

        /// <summary>
        /// Hướng các cột sắp xếp (acs, des) ứng với SortColumns trên
        /// </summary>
        public string[] SortDirections { get; set; }


        public string SortColumn { get; set; }


        public string SortOrder { get; set; }

        /// <summary>
        /// Số dòng trong 1 trang
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Trang hiện hành
        /// </summary>
        public int PageNum { get; set; }


        public string TypeName { get; set; }

        /// <summary>
        /// Điều kiện lọc
        /// </summary>
        public string Predicate { get; set; }

        //Các giá trị lọc
        public object[] DataValue { get; set; }

        /// <summary>
        /// Diều kiện lọc quen thuộc, nhớ lại dk lọc cuoi cung va hay dung nhat
        /// </summary>
        public string PredicateFavorite { get; set; }


        public object[] DataValueFavorite { get; set; }

        public string PredicateQuickSearch { get; set; }


        public object[] DataValueQuick { get; set; }


        public List<string> Predicates { get; set; }


        public List<object[]> DataValues { get; set; }


        public string[] PredicateInColumn { get; set; }


        public object PredicateInValue { get; set; }

       
        private bool _IsSetDataPermission = true;

        /// <summary>
        /// True là lưới đã được phân quyền trên dữ liệu
        /// </summary>
        public bool IsSetDataPermission { get { return _IsSetDataPermission; } set { _IsSetDataPermission = value; } }

        public string EntitySQL { get; set; }

        public object[] EntitySQLParameters { get; set; }

        public string WhereInColumn { get; set; }

        public List<Guid> WhereInData { get; set; }

        public List<string> WhereInObjectData { get; set; }

        // public List<string> SelectOperators { get; set; }

        public string GroupByColumns { get; set; }


        public string KeyGetPage { get; set; }
        public string ValueGetPage { get; set; }

        /// <summary>
        /// Dùng để chứa các tham số khi người dùng truyền tham số từ phương thức LoadDataLogic sang phương thức của bạn
        /// </summary>
        public Dictionary<string,string> Params { get; set; }
    }
}
