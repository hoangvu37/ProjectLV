
using LV.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LV.Common;

namespace HealthCareAPI.DTO
{
    public class QueryDTO
    {
        public QueryDTO()
        {
            PageSize = int.MaxValue;
            OrderByName = "";
            OrderByType = "";
        }
        //long AccountID, int PageNumber, string OrderByName, string OrderByType, int PageSize = int.MaxValue
        /// <summary>
        /// Mã tài khoản người dùng
        /// </summary>
        public long AccountID { get; set; }
        /// <summary>
        /// Trang hiện tại lấy dữ liệu
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Tên trường cần sort
        /// </summary>
        public string OrderByName { get; set; }
        /// <summary>
        /// Kiểu sort "ASC" Hoặc "DESC"
        /// </summary>
        public string OrderByType { get; set; }
        /// <summary>
        /// Số dòng dữ liệu cần lấy; Null hoặc -1 lấy tất cả
        /// </summary>
        public int PageSize { get ; set; }
    }
    public class GetDataDefault
    {
        /// <summary>
        /// Tên Bảng cần lấy dữ liệu
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Tên Cột cần lấy dữ liệu (Text Field)
        /// </summary>
        public string ColumnsName { get; set; }
        /// <summary>
        /// Mã Cột (Value Field)
        /// </summary>
        public string ColumnsID { get; set; }
        /// <summary>
        /// Chuổi Filter
        /// </summary>
        public string Filter { get; set; }
        public QueryDTO Default { get; set; }
    }
    public class GetRefUnitOfMeasureDTO
    {
        /// <summary>
        /// Mã Đơn vị tính lấy trong reflookup
        /// </summary>
        public long? V_UOMCategory { get; set; }
        /// <summary>
        /// Mã hệ thống phân loại đo lường
        /// </summary>
        public long? MCLID { get; set; }
        public QueryDTO Default { get; set; }
    }
    public class GetRefElthnic
    {
        /// <summary>
        /// Mã nhóm dân tộc
        /// </summary>
        public long? PtEthnicGroupID{ get; set; }
        public QueryDTO Default { get; set; }
    }
    public class RefAnnTemp
    {
        /// <summary>
        /// Mã loại mẫu thư được lấy từ bảng reflookup
        /// </summary>
        public long? V_AnnTempType { get; set; }
        /// <summary>
        /// Tên loại Mẫu mail
        /// </summary>
        public string AnnTempName { get; set; }
        public QueryDTO Default { get; set; }
    }

    public class GetHospitaltDTO
    {
        /// <summary>
        /// Mã Tĩnh
        /// </summary>
        public string ProvinceID { get; set; }
        /// <summary>
        /// Tên bệnh viện
        /// </summary>
        public string HCPrvProviderName { get; set; }
        /// <summary>
        /// Mã Bệnh viện
        /// </summary>
        public string HCPrvProviderId { get; set; }
    }
    public class EmpAllocation
    {
        /// <summary>
        /// Mã Chuyên khoa
        /// </summary>
        public long? DeptID { get; set; }
        /// <summary>
        /// Mã Bệnh viên
        /// </summary>
        public long? HosID { get; set; }
        public QueryDTO Default { get; set; }
    }
    public class GetMedicalServiceItem
    {
        /// <summary>
        /// Mã chuyên khoa
        /// </summary>
        public long? DeptID { get; set; }
        /// <summary>
        /// Mã dịch vụ
        /// </summary>
        public long? MedSerID { get; set; }
        /// <summary>
        /// Mã xác nhận xem có phải dịch vụ
        /// </summary>
        public long? QuotationIDMOHS { get; set; }
        /// <summary>
        /// Mã xác nhận bệnh nhân bảo hiểm y tế
        /// </summary>
        public long? QuotationHIS { get; set; }
        /// <summary>
        /// Tên dịch vụ
        /// </summary>
        public string  MedSerName { get; set; }
        public QueryDTO Default { get; set; }
    }
    public class AppConfigDTO
    {
        /// <summary>
        /// Json các thông tin về appconfig
        /// <code>
        /// [{
        ///     A_VATPercent: "value"
        /// }]
        /// </code>
        /// </summary>
        /// <remarks>
        /// <example> 
        /// <code>
        /// [{
        ///     A_VATPercent: "value"
        /// }]
        /// </code>
        /// </example> 
        /// </remarks>
        public Object JsonAppConfig { get; set; }
        /// <summary>
        /// Json các thông tin về bệnh viện
        /// </summary>
        public Object JsonHCProvider { get; set; }
    }
        public class AppointmentDTO
    {
        public Object Person { get; set; }
        public Object Patient { get; set; }
        public Object HealthInsurance { get; set; }
        public Object InsuranceInterests { get; set; }
        public Object PatientMedRecord { get; set; }
        public Object MedicalEncounter { get; set; }
        public Object PatientVitalSign { get; set; }
        public Object PatientClassHistory { get; set; }
        public Object PatientAdmission { get; set; }
        public Object HIAdmission { get; set; }
        public Object MiscDocuments { get; set; }
        public Object PatientCommonMedRecord { get; set; }
        public Object PatientTransaction { get; set; }
        public Object HospitalFeeTransaction { get; set; }
        public Object HosFeeTransDetails { get; set; }
        public Object MedicalClaimService { get; set; }
        public bool isHI { get; set; }
        public bool ConfigIsEnable { get; set; }
        public long AccountID { get; set; }
        public object RadtForm { get; set; }
        public object HIForm { get; set; }
        public object FAMForm { get; set; }
        public object ReciveForm { get; set; }
        public object PADForm { get; set; }
        public object PtMoreInfor { get; set; }
    }

    public class PatientFromEPR
    {
        public string KeySearch { get; set; }
        public int? YearBthDtm { get; set; }
        public string PtCode { get; set; }
        public string UPI { get; set; }
        public string HICardNo { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }

    public class PatientFromAppointment
    {
        public string KeySearch { get; set; }
        public int? YearBthDtm { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string DtmFrom { get; set; }
        public string DtmTo { get; set; }
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
    }
    public class ExecuteStoreDTO
    {
        /// <summary>
        /// Tên store
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// List tên param
        /// </summary>
        public Object[] objName { get; set; }
        /// <summary>
        /// List tên giá trị param
        /// </summary>
        public Object[] objValue { get; set; }
    }

    public class PaginServerTest {
        Request request { get; set; }
    }
}