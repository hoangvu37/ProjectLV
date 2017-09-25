using LV.Poco;
using LV.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using LV.Core.DAL.EntityFramework;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data;
using log4net;
using System.Reflection;
using Newtonsoft.Json.Linq;
using HealthCareAPI.DTO;
using System.Net;
using System.Globalization;

namespace HealthCareAPI.Controllers
{
    /// <summary>
    /// Danh mục HCP -  Get
    /// </summary>
    [RoutePrefix("api/HCP")]
    [AllowAnonymous]
    //[Authorize]
    public class HCPGetController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public HCPGetController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
        /// <summary>
        /// Lấy danh sách bệnh viện / trung tâm y tế
        /// </summary>
        /// Dữ liệu trả về
        /// <remarks>
        /// <example> 
        /// <code>
        ///   [
        ///          {
        ///            "HosID": 13449,
        ///            "HCPrvProviderId": "80002",
        ///            "HCPrvProviderName": "Ban bảo vệ sức khỏe Long An"
        ///          },
        ///         {
        ///            "HosID": 13448,
        ///            "HCPrvProviderId": "80001",
        ///            "HCPrvProviderName": "Bệnh viện đa khoa Long An"
        ///          },
        ///          {
        ///            "HosID": 13452,
        ///            "HCPrvProviderId": "80211",
        ///           "HCPrvProviderName": "Bệnh viện đa khoa tư nhân Long An Segaero"
        ///          }
        ///   ]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="text">Có thể là tên bệnh viện/ Mã bệnh viện, có đấu hoặc không dấu</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetListHCProvider")]
        public IHttpActionResult GetListHCProvider(string text="")
        {
            try
            {
                var objName = new object[] { "text" };
                var objParam = new object[] { text };
                var result = this.Repository.ExecuteStoreScalar("usp_GetListHCProvider", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách bệnh viện
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>

        [Route("GetHCProvider")]
        public IHttpActionResult GetHCProvider(long? AccountID, int PageSize, int PageNumber)
        {
            try
            {
                PageSize = PageSize <= 0 ? int.MaxValue : PageSize;
                var objNames = new object[] { "AccountID", "PageSize", "PageNumber" };
                var objValues = new object[] { AccountID, PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetHCProvider", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        ///  Lấy thông tin 1 bệnh viện
        /// </summary>
        /// <remarks>
        /// <example> 
        /// <code>
        ///     [
        ///       {  
        ///         "HosID": // Mã bệnh viện,
        ///         "PHosID": //Mã bệnh viện cấp cha,
        ///         "SatOfHosID": //NULL khong la benh vien ve tinh. Nguoc lai benh vien chi dinh se la benh vien ve tinh cua benh vien co ID tuong ung lu trong SatOfHosID. Vi to chuc nay theo co che cua Government Satellite Hospital ,
        ///         "HIHosCode": //Ma CSKCB theo quy dinh BH,
        ///         "OUID"://Loai to chuc ma HCEnterprise truc thuoc: thuoc he thong cham soc suc khoe y te cua Quoc gia, hay thuoc cac to chuc phi chinh phu,
        ///         "HCPrvProviderId":// ASTM Ma benh vien theo quy dinh cua BYT,
        ///         "HCPrvProviderName"://ASTM Ten day du cua benh vien/ CSKCB  (HosName),
        ///         "ProvinceID": //ID tinh thanh ma benh vien dang truc thuoc (CityProvinceID),
        ///         "HosShortName": //Ten viet tat (ngan) cua benh vien.,
        ///         "HCPractAddressText"://ASTM Dia chi benh vien (HosAddress),
        ///          "HosLogoImgPath"://Logo bệnh viện,
        ///         "Slogan": null,
        ///         "HosPhone":null,
        ///         "HosHotline"://Duong day nong cua benh vien. Co the co nhieu line duong day nong khac nhau. Va luu tru dang string,
        ///         "HosWebSite":null,
        ///         "HosEmail":null,
        ///         "HosFax":null,
        ///         "HCPrvProviderTypeCode"://ASTM Loai benh vien (V_HospitalType):  - Theo quy dinh cua VN gom:+ Benh vien da khoa  + Benh vien chuyen khoa: nhi,      + Benh vien chuyen khoa:tai mui hong      + Benh vien chuyen khoa: mat .....  - Theo quy dinh cua ASTM, loai benh vien con chia nho ra nhu:      + Nha khoa: Phuc hinh rang     + Nha khoa: Phong ngua     + Nha khoa: Nhi     + Nha khoa: Noi nha ......   Vi vay can TBC ve du lieu theo ASTM hoac quy dinh cua BYT VN.,
        ///         "IsHeadOffice"://1: van phong dai dien,
        ///         "HCPrvAgencyIDCode"://ASTM Ma lien ket, ma co quan cung cap ID (TBD),
        ///         "IsBuiltIn":// 	- 1: benh vien hay chi nhanh chinh 	- NULL |  0: benh vien hay chi nhanh khac hay co giao dich
        ///
        ///     }
        ///   ]
        /// </code>
        /// </example> 
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="HosID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetHCProviderInfor")]
        public IHttpActionResult GetHCProviderInfor(long AccountID, long HosID)
        {
            try
            {
                var objName = new object[] { "AccountID", "HosID" };
                var objParam = new object[] { AccountID, HosID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetHCProviderInfor", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }

}
