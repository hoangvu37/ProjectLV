using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareAPI.DTO
{
    public class AccountDTO
    {
    }
    public class RegisterAccountDTO
    {
        /// <summary>
        /// Địa chỉ email
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Mật khẩu đã được md5
        /// </summary>
        public string AccountPwd { get; set; }
        /// <summary>
        /// Mã Role chính của tài khoản
        /// </summary>
        public long? PrimaryRoleID { get; set; }
        /// <summary>
        /// Loại tài khoản lấy trong reflookup
        /// </summary>
        public long V_AccountType { get; set; }
        /// <summary>
        /// Họ
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Tên và họ đệm
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Ngày sinh format MM/dd/YYYY
        /// </summary>
        public string PersBirthDtm { get; set; }
        /// <summary>
        /// Thông tin khác
        /// </summary>
        public string OtherPersonDetails { get; set; }
        /// <summary>
        /// Địa chỉ nhà/đường
        /// </summary>
        public string PersPermanentAddressText { get; set; }
        /// <summary>
        /// Mã quốc gia
        /// </summary>
        public string CountryID { get; set; }
        /// <summary>
        /// Mã tỉnh/Thành phố
        /// </summary>
        public string CityProvinceID { get; set; }
        /// <summary>
        /// Mã Quận/huyện
        /// </summary>
        public string DistrictID { get; set; }
        /// <summary>
        /// Sđt bàn
        /// </summary>
        public string LandLine { get; set; }
        /// <summary>
        /// Số đt di động
        /// </summary>
        public string PersHomePhonePhN { get; set; }
        /// <summary>
        /// Loại người dùng trong quan hệ thừa kế
        /// </summary>
        public string PersonType { get; set; }
        /// <summary>
        /// Mã Quốc tích mặc đinh là 'VN'
        /// </summary>
        public string NationnalityCode { get; set; }
        /// <summary>
        /// Mã bệnh nhân nếu là bệnh nhân ngược lại nếu là nhân viên bệnh viện sẽ là mã CMND/Mã thẻ hành nghề
        /// </summary>
        public string Perscode { get; set; }

        /// <summary>
        /// Mã chức danh, vài trò của nhân viên y tế.
        /// </summary>
        public long? JTID { get; set; }
        /// <summary>
        /// Đường dẫn site
        /// </summary>
        public string Url { get; set; }
    }
}