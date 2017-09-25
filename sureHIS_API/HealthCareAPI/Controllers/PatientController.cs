using System;
using System.Net;
using System.Web.Http;
using LV.Common;
using System.Reflection;
using log4net;
using System.Globalization;
using System.Collections.Generic;
using HealthCareAPI.DTO;
using System.Text;
using HealthCareAPI.BO;

namespace HealthCareAPI.Controllers
{
    [RoutePrefix("api/patient")]
    public class PatientController : LVApiController
    {
        ILog log;
        IFormatProvider culture;
        string language = string.Empty;
        public PatientController()
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            culture = new CultureInfo(Constant.CULTUREDEFAULT, true);
            language = GetLang();
        }
        /// <summary>
        /// Chi tiết toa thuốc của người bệnh(danh sách thuốc trong 1 đơn thuốc)
        /// </summary>
        /// <remarks>
        /// <code>
        ///     [{
        ///         RxsID: //Mã toa thuốc,
        ///         RxID: //Mã đơn thuốc,
        ///         MedcnID //Mã đợt thăm khám,
        ///         MedcnNameText //Tên đợt thăm khám,
        ///         DrugFullName //Tên thuốc,
        ///         AcPrincipleName //Tên hoạt chất của thuốc,
        ///         MedcnDoseQty //Số liều dùng hàng ngày,
        ///         MedcnDoseUnitCode //Mã đơn vị liều lượng dùng thuốc,
        ///         MedcnAdminFreqCode //Số lần trong ngày,
        ///         MedcnAdminFreqPerDay //số ngày chỉ định,
        ///         MedcnDispenseQty //Số lượng yêu cầu/Ngày,
        ///         MedcnUsingDuration//Thời gian dùng thuốc tính theo đơn vị ngày,
        ///         MedcnAdminRouteCode: "Chỉ định cách thức sử dụng như uống/tiêm/ngậm",
        ///         MedcnInstructionCode: "Mã hướng dẫn sử dụng dùng thuốc",
        ///         MedcnNoteText: "Ghi chú",
        ///         BelongingToHI: "NULL/0: thuốc thuộc danh mục BHYT và ngược lại",
        ///         InitialICD: "Chẩn đoán ban đầu trước khi chỉ định các dịch vụ CLS",
        ///         PreDiagnosis: "Chẩn đoán ban đầu của bác sĩ điều trị",
        ///         HCFEncEncounterCode: "Mã chẩn đoán bệnh sau khi có kq CLS",
        ///         HCEpiIDCode: "ASTM Mã đợt tiếp nhận ghi thông tin tử vong",
        ///         HCFEncReasonVisitCode: "Lý do nhập viên",
        ///         IAdmReferralTypeCode: "Mã loại giấy giới thiệu",
        ///     }]
        /// </code>
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="RxID">Mã đơn thuốc</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPrescriptionDetail")]
        public IHttpActionResult GetPrescriptionDetail(long AccountID, long RxID)
        {
            try
            {
                var objNames = new object[] { "AccountID", "RxID", "language" };
                var objValues = new object[] { AccountID, RxID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPrescriptionDetail", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy danh sách đơn thuốc của bệnh nhân
        /// </summary>
        /// <remarks>
        /// <code>
        ///     [{
        ///         RxID: //Mã đơn thuốc,
        ///         RxCode: //Mã Code đơn thuốc,
        ///         DiagDesc,
        ///         MedEncnID,
        ///         MedEnctrDiagID,
        ///         MedcnStartDtm,
        ///         MedcnStopDtm,
        ///         DrAdvice,
        ///         ReExamDate,
        ///         ApptID,
        ///         NeedHoldCnsl,
        ///         V_PmtMethod,
        ///         V_PmtMethodNameVN,
        ///         V_PmtMethodName,
        ///         V_PmtStatus,
        ///         V_PmtStatusNameVN,
        ///         V_PmtStatusName,
        ///         V_RxIssueType,
        ///         V_RxIssueTypeNameVN,
        ///         V_RxIssueTypeName,
        ///         V_RxStatus,
        ///         V_RxCatg,
        ///         CureNum,
        ///         IsStabilityStatus,
        ///         ApprovedInsurID,
        ///         AttendingDoctorID,
        ///         NurseID,
        ///         InitialICD,
        ///         PreDiagnosis,
        ///         HCFEncEncounterCode,
        ///         HCEpiIDCode,
        ///         HCFEncReasonVisitCode,
        ///         IAdmReferralTypeCode
        ///     }]
        /// </code>
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="PtID">Mã bệnh nhân</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPrescription")]
        public IHttpActionResult GetPrescription(long AccountID, long PtID)
        {
            try
            {
                var objNames = new object[] { "AccountID", "PtID", "language" };
                var objValues = new object[] { AccountID, PtID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPrescription", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Danh sách yêu cầu chỉ định xét nghiệm cận lâm sàng của bệnh nhân(xét nghiệm, chẩn đoán hình ảnh, thăm dò chức năng)
        /// </summary>
        /// <remarks>
        /// <example>
        /// <code>
        ///     [{
        ///         
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AccountID"></param>
        /// <param name="PtID">Mã bệnh nhân</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetParaClinicalReq")]
        public IHttpActionResult GetParaClinicalReq(long AccountID, long PtID)
        {
            try
            {
                var objNames = new object[] { "AccountID", "PtID", "language" };
                var objValues = new object[] { AccountID, PtID, language };
                var result = this.Repository.ExecuteStoreScalar("usp_GetParaClinicalReq", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin về bệnh nhân KCB 
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         sẽ bổ sung sau
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="PtId">Mã BỆNH NHÂN</param>
        /// <returns></returns>
        [Route("GetPatientInfo")]
        public IHttpActionResult GetPatientInfo(long PtId)
        {
            try
            {
                var objName = new object[] { "PtId" };
                var objValue = new object[] { PtId };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientByPtId", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin chung của bệnh nhân
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         sẽ bổ sung sau
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="PtId">ID BỆNH NHÂN</param>
        /// <param name="PtCode">Mã BỆNH NHÂN</param>
        /// <returns></returns>
        [Route("GetPersonByPtId")]
        public IHttpActionResult GetPersonByPtId(long PtId, string PtCode = "")
        {
            try
            {
                var objName = new object[] { "PtId", "PtCode" };
                var objValue = new object[] { PtId, PtCode };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPersonByPtId", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin nhập viện của bệnh nhân
        /// </summary>
        /// <remarks>
        /// Dữ liệu truyền vào
        /// <example> 
        /// <code>
        ///        Input =  'Mã dữ liệu cần truyền vào',
        ///        
        ///        TypeInput = 0: PtID ,
        ///        TypeInput = 1: PtCode,
        ///        TypeInput = 2: HICardNo ,
        ///       
        ///        Type = 0: 'Person',
        ///        Type = 1: 'Patient',
        ///        Type = 2: 'PatientAdmission' ,
        ///        Type = 3: 'HealthInsurance'
        ///        Type = 4: 'PatientMedRecord', 
        ///        Type = 5: 'MedicalEncounter'
        ///        
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="Input">Dữ liệu đầu vào</param>
        /// <param name="TypeInput">Loại dữ liệu</param>
        /// <param name="Type">Loại data cần lấy </param>
        /// <returns></returns>
        [Route("GetPatientInforByType")]
        [HttpGet]
        public IHttpActionResult GetPatientInforByType(string Input, int TypeInput, int Type = 0)
        {
            try
            {
                var objName = new object[] { "Input", "TypeInput", "Type" };
                var objValue = new object[] { Input, TypeInput, Type };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientInforByType", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + "; param: Input = " + Input + ", TypeInput = " + TypeInput.ToString());
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin hình thức điều chuyển
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         sẽ bổ sung sau
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AdmID">Mã hồ sơ KCB</param>
        /// <returns></returns>
        [Route("GetHIAdmissionByAdmID")]
        public IHttpActionResult GetHIAdmissionByAdmID(long AdmID)
        {
            try
            {
                var objName = new object[] { "AdmID" };
                var objValue = new object[] { AdmID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetHIAdmissionByAdmID", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin chuẩn đoán y khoa của bệnh nhân
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         sẽ bổ sung sau
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AdmID">Mã hồ sơ KCB</param>
        /// <returns></returns>
        [Route("GetMedicalEncounterByAdmID")]
        public IHttpActionResult GetMedicalEncounterByAdmID(long AdmID)
        {
            try
            {
                var objName = new object[] { "AdmID" };
                var objValue = new object[] { AdmID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetMedicalEncounterByAdmID", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin chung sổ KCB
        /// </summary>
        /// <remarks>
        /// Dữ liệu trả về
        /// <example> 
        /// <code>
        ///     [{
        ///         sẽ bổ sung sau
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="AdmID">Mã hồ sơ KCB</param>
        /// <param name="PtID">Mã bênh nhân</param>
        /// <returns></returns>
        [Route("getepr")]
        public IHttpActionResult Getepr(long AdmID, long PtID)
        {
            try
            {
                var objName = new object[] { "AdmID", "PtID" };
                var objValue = new object[] { AdmID, PtID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetEPR", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy thông tin Person
        /// </summary>
        /// <param name="PersonID">Mã PersonID</param>
        /// <param name="V_PersonType">Loại người dùng 5200	Nhân Viên///5201	Bênh Nhân//5202	Nhân Viên Y tế Ngoài BV//5203	Người đại diện tổ chức//5204	Người tài trợLoại người dùng trong reflookup có thể Null</param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("GetInforPerson")]
        public IHttpActionResult GetInforPerson(long PersonID, long? V_PersonType)
        {
            try
            {
                var objName = new object[] { "PersonID", "V_PersonType" };
                var objValue = new object[] { PersonID, V_PersonType };
                var result = this.Repository.ExecuteStoreScalar("usp_GetInforPerson", objName, objValue);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Lấy thông tin ngoại chuẩn
        /// </summary>
        /// <param name="PtComMedRecID">Mã thông tin BN trong sổ khám bệnh</param>
        /// <returns>
        /// [{
        ///     "VitSignCode": Mã dấu hiệu ngoại chuẩn,
        ///     "VitSignDtm": ngày khám,
        ///     "VitSignQty":kết quả đo,
        ///     "VitSignUnitCode":đơn vị,
        ///     "Executor": người đo
        ///     },
        /// ...]
        /// </returns> 
        [HttpPost]
        [Route("GetPatientVitalSignInfor")]
        public IHttpActionResult GetPatientVitalSignInfor(long PtComMedRecID)
        {
            try
            {
                var objName = new object[] { "PtComMedRecID" };
                var objParam = new object[] { PtComMedRecID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientVitalSignInfor", objName, objParam);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        /// <summary>
        /// Danh sách yêu cầu chỉ định xét nghiệm cận lâm sàng của bệnh nhân(xét nghiệm, chẩn đoán hình ảnh, thăm dò chức năng)
        /// </summary>
        /// <remarks>
        /// <example>
        /// <code>
        ///     [{
        ///         "PersonID": 1,
        ///         "FirstName": "Supervisor",
        ///         "MiddleName": "",
        ///         "LastName": "Administrator",
        ///         "PtCode": null,
        ///         "PersGenderName": "Male",
        ///         "Age": null,
        ///         "AgeOnly": false,
        ///         "PersPermanentAddressText": null,
        ///         "CountryID": null,
        ///         "CountryName": null,
        ///         "CityProvinceID": null,
        ///         "CityProvinceName": null,
        ///         "DistrictID": null,
        ///         "DistrictName": null,
        ///         "WardID": null,
        ///         "WardName": null
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="KeySearch">họ, tên lót hoặc tên bệnh nhân muốn tìm kiếm</param>
        /// <param name="PageSize">Số dòng dữ liệu 1 page</param>
        /// <param name="PageNumber">Stt page</param>
        /// <param name="YearBthDtm">Năm sinh</param>
        /// <param name="Phone">Số điện thoại</param>
        /// <param name="Mail">mail</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPatientByKey")]
        public IHttpActionResult GetPatientByKey(string KeySearch = "", int YearBthDtm = 0, string Phone = "", string Mail = "", int PageSize = 15, int PageNumber = 1)
        {
            ////bỏ dấu tiếng việt của KeySearch trước khi đưa vào
            try
            {
                PageSize = PageSize == -1 ? int.MaxValue : PageSize;
                var objNames = new object[] { "KeySearch", "YearBthDtm", "Phone", "Mail", "PageSize", "PageNumber" };
                var objValues = new object[] { KeySearch, YearBthDtm, Phone, Mail, PageSize, PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientByKeySearch", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private static string ConvertHexStrToUnicode(string hexString)
        {
            int length = hexString.Trim().Length;
            byte[] bytes = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return Encoding.UTF8.GetString(bytes);
        }
        /// <summary>
        /// cắt chuỗi QRcode BHYT trả về thông tin BHYT
        /// <remarks>
        /// <example>
        /// <code>
        ///     [{
        ///         "HI": {} //,
        ///         "PtCode": string // mã bệnh nhân,
        ///         "Err": int // Mã lỗi,
        ///     //Err = 0 //Thông tin BHYT chính xác
        ///     //Err = 1 //Mã BHYT không đúng
        ///     // Err = 2 //Mã BHYT không suy được mức hưởng BH
        ///     //Err = 3 //Thẻ hết hạn sử dụng!
        ///     //Err = 4 //Mã nơi đăng ký ban đầu không có trong hệ thống!
        ///     //Err = 5 //Thẻ QA không đúng format!
        ///     //Err = 6 //Mã thẻ BHYT không chính xác!
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// </summary>
        /// <param name="ptHI"></param>
        /// <returns></returns>
        [Route("splitPatientHI")]
        [HttpGet]
        public IHttpActionResult splitPatientHI(string ptHI)
        {
            try
            {
                var patientHi = new PatientHIDTO();
                var arrObject = ptHI.Split('|');
                bool flag = true;
                var err = 0;
                if (arrObject.Length > 13)
                {
                    var insInterestsCode = arrObject[0].Trim().Substring(0, 3);
                    var ls = getRebatePercentage(1, insInterestsCode);
                    if (arrObject[0].Trim().Length != 15)
                    {
                        flag = false;
                        err = 1;//"Mã BHYT không đúng";
                    }
                    else if (ls.Count == 0)
                    {
                        flag = false;
                        err = 2; // "Mã BHYT không suy được mức hưởng BHXY!";
                    }
                    else if (DateTime.Compare(DateTime.ParseExact(arrObject[7], "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.Now.Date) < 0)
                    {
                        flag = false;
                        err = 3;// "Thẻ hết hạn sử dụng!";
                    }
                    else if (getHosName(arrObject[5].Trim().Replace("-", "").Replace(" ", "")).Count == 0)
                    {
                        flag = false;
                        err = 4;// "Mã nơi đăng ký ban đầu không có trong hệ thống!";
                    }

                    else
                    {
                        patientHi.HICode = arrObject[0].Trim();
                        patientHi.PersName = ConvertHexStrToUnicode(arrObject[1]);
                        patientHi.BOD = DateTime.ParseExact(arrObject[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        patientHi.Gender = Convert.ToInt16(arrObject[3].Trim());
                        patientHi.Address = ConvertHexStrToUnicode(arrObject[4].Trim());
                        patientHi.HosCode = arrObject[5].Trim().Replace("-", "").Replace(" ", "");
                        patientHi.StartDate = DateTime.ParseExact(arrObject[6], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        patientHi.EndDate = DateTime.ParseExact(arrObject[7], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        patientHi.CreatedDate = DateTime.ParseExact(arrObject[8], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        patientHi.PersonalBHCode = arrObject[9].Trim();
                        patientHi.FamilyName = arrObject[10].Trim() == "-" ? arrObject[10].Trim() : ConvertHexStrToUnicode(arrObject[10]);
                        patientHi.CountryCode = Convert.ToInt16(arrObject[11].Trim());
                        if (arrObject[12].Trim() != "-")
                            patientHi.FiveYear = DateTime.ParseExact(arrObject[12], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        patientHi.CheckedBH = arrObject[13];
                        if (patientHi.HosCode != "")
                        {
                            var lss = getHosName(patientHi.HosCode.Trim());
                            if (lss.Count > 0)
                            {
                                patientHi.HosID = Convert.ToInt32(lss[0]);
                                patientHi.HosAddress = lss[1];
                            }
                        }
                        if (ls.Count > 0)
                        {
                            patientHi.RebatePercentage = Convert.ToDouble(ls[0]);
                            patientHi.IBID = Convert.ToInt32(ls[1]);
                        }
                        patientHi.InsInterestsCode = insInterestsCode;
                    }
                    string ptCode = getPtCode(patientHi.HICode.Trim());
                    if (flag)
                    {
                        return Ok(new { HI = patientHi, PtCode = ptCode, Err = err });
                    }
                    else
                    {
                        patientHi.HICode = ptHI;
                        return Ok(new { HI = patientHi, PtCode = ptCode, Err = err });
                    }
                }
                else
                {
                    patientHi.HICode = ptHI;
                    string ptCode = getPtCode(patientHi.HICode.Trim());
                    return Ok(new { HI = patientHi, PtCode = ptCode, Err = 5 }); // 5:"Thẻ QA không đúng format!"
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.ToString());
            }
        }
        [Route("getRebatePercentage")]
        [HttpGet]
        public IHttpActionResult getRebatePercentage(string ptCode)
        {
            try
            {
                var patientHi = new PatientHIDTO();
                if (ptCode.Length == 15)
                {
                    var insInterestsCode = ptCode.Trim().Substring(0, 3);
                    var ls = getRebatePercentage(1, insInterestsCode);
                    if (ls.Count == 0)
                    {
                        return Ok(new { data = false, Err = 2 }); //"Mã BHYT không suy được mức hưởng BH!" 
                    }
                    else
                    {
                        patientHi.RebatePercentage = Convert.ToDouble(ls[0]);
                        patientHi.IBID = Convert.ToInt32(ls[1]);
                        patientHi.InsInterestsCode = insInterestsCode;
                        return Ok(new { data = true, HI = patientHi });
                    }
                }
                else
                {
                    return Ok(new { data = false, Err = 6 }); // "Mã thẻ BHYT không chính xác!"
                }
            }
            catch (Exception exp)
            {

                return BadRequest(exp.ToString());
            }
        }
        [NonAction]
        public List<string> getHosName(string HIHosCode)
        {
            try
            {
                List<string> ls = new List<string>();
                var obj = new object[1] { HIHosCode };
                var result = this.Repository.ExecuteStoreScalar("usp_GetHCProviderByHIHosCode", obj);
                if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                {
                    ls.Add(result.Tables[0].Rows[0][0].ToString());
                    ls.Add(result.Tables[0].Rows[0][1].ToString());
                }
                return ls;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [NonAction]
        public List<string> getRebatePercentage(int insCoID, string insInterestsCode)
        {
            try
            {
                List<string> ls = new List<string>();
                var obj = new object[2] { insCoID, insInterestsCode };
                var result = this.Repository.ExecuteStoreScalar("usp_spGetRebatePercentage", obj);
                if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                {
                    ls.Add(result.Tables[0].Rows[0][0].ToString());
                    ls.Add(result.Tables[0].Rows[0][1].ToString());
                }
                return ls;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [NonAction]
        public string getPtCode(string hiCardCode)
        {
            try
            {
                var obj = new object[1] { hiCardCode };
                var result = this.Repository.ExecuteStoreScalar("usp_getPtCodeByHiCard", obj);
                if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                {
                    return result.Tables[0].Rows[0][0].ToString();
                }
                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Tìm kiếm bệnh nhân từ danh sách bệnh nhân đã có dữ liệu
        /// </summary>
        /// <remarks>
        /// <example>
        /// <code>
        ///     [
        ///         {
        ///         "PersonID": 385,
        ///         "FirstName": null,
        ///         "MiddleName": null,
        ///         "LastName": null,
        ///         "PersName": "tran đinh trọng",
        ///         "ProfilePhoto": null,
        ///         "PtCode": "0840790000000844.53204135",
        ///         "PersGenderCode": 2,
        ///         "PersGenderName": "Male",
        ///         "Age": 8280,
        ///         "AgeOnly": null,
        ///         "PersBirthDtm": "1994-06-04T17:00:00",
        ///         "PersHomePhonePhN": "0917311305",
        ///         "PersPermanentAddressText": "1234444",
        ///         "CountryID": null,
        ///         "CountryName": null,
        ///         "CityProvinceID": "79",
        ///         "CityProvinceName": "Hồ Chí Minh",
        ///         "DistrictID": "764",
        ///         "DistrictName": "Gò Vấp",
        ///         "WardID": null,
        ///         "WardName": null,
        ///         "Total": 1
        ///         }
        ///     ]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="EPR">Thông tin tìm kiếm</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchPatientFromEPR")]
        public IHttpActionResult SearchPatientFromEPR(PatientFromEPR EPR)
        {
            ////bỏ dấu tiếng việt của KeySearch trước khi đưa vào
            try
            {
                EPR.PageSize = EPR.PageSize == -1 ? int.MaxValue : EPR.PageSize;
                var objNames = new object[] { "KeySearch", "YearBthDtm", "PtCode", "UPI", "HICardNo", "PageSize", "PageNumber" };
                var objValues = new object[] { EPR.KeySearch, EPR.YearBthDtm, EPR.PtCode, EPR.UPI, EPR.HICardNo, EPR.PageSize, EPR.PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_SearchPatientFromEPRByKeySearch", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Tìm kiếm bệnh nhân từ danh sách bệnh nhân đã có dữ liệu
        /// </summary>
        /// <remarks>
        /// <example>
        /// <code>
        ///     [{
        ///         "RegInfoID": 179,
        ///         "PtID": 179,
        ///         "LastName": "Vũ",
        ///         "FirstName": "Hoàng",
        ///         "PerName": "Hoàng Vũ",
        ///         "MobilePhoneNumber": "543543543",
        ///         "EmailAddress": "patient@gmail.com",
        ///         "DOB": "2014-02-02T00:00:00",
        ///         "IDNumber": null,
        ///         "PPN": null,
        ///         "PersGenderCode": 2,
        ///         "PersGenderName": "Male",
        ///         "Age": 0,
        ///         "AgeOnly": null,
        ///         "PersBirthDtm": "2014-02-02T00:00:00",
        ///         "IDNumber1": "121111111   ",
        ///         "PersPermanentAddressText": "Địa chỉ liên hệ",
        ///         "CountryID": null,
        ///         "CountryName": null,
        ///         "CityProvinceID": "24",
        ///         "CityProvinceName": "Bắc Giang",
        ///         "DistrictID": "215",
        ///         "DistrictName": "Yên Thế",
        ///         "WardID": null,
        ///         "WardName": null,
        ///         "DeptName": null,
        ///         "AcademicName": "Director",
        ///         "EmpFirstName": null,
        ///         "EmpMiddleName": null,
        ///         "EmpPersName": "Nguyễn Anh Ngọc",
        ///         "StartTime": "13:00:00",
        ///         "EndTime": "13:15:00"
        ///     }]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="Appt">Thông tin đầu vào để search</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchPatientFromAppointment")]
        public IHttpActionResult SearchPatientFromAppointment(PatientFromAppointment Appt)
        {
            ////bỏ dấu tiếng việt của KeySearch trước khi đưa vào
            try
            {
                Appt.PageSize = Appt.PageSize == -1 ? int.MaxValue : Appt.PageSize;

                object DtmFrom = null, DtmTo = null;
                if (Appt.DtmFrom != null && Appt.DtmFrom != "")
                {
                    DtmFrom = Convert.ToDateTime(Appt.DtmFrom);
                }

                if (Appt.DtmTo != null && Appt.DtmTo != "")
                {
                    DtmTo = Convert.ToDateTime(Appt.DtmTo); ;
                }
                var objNames = new object[] { "KeySearch", "YearBthDtm", "Phone", "Mail", "DtmFrom", "DtmTo", "PageSize", "PageNumber" };
                var objValues = new object[] { Appt.KeySearch, Appt.YearBthDtm, Appt.Phone, Appt.Mail, DtmFrom, DtmTo, Appt.PageSize, Appt.PageNumber };
                var result = this.Repository.ExecuteStoreScalar("usp_SearchPatientFromApptByKeySearch", objNames, objValues);
                return Ok(PocoHelper.GetTableRows(result.Tables[0]));
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        /// <summary>
        /// Lấy bệnh nhân từ lịch KCB
        /// </summary>
        /// <remarks>
        /// <example>
        /// <code>
        ///     [
        ///       {
        ///         "RegInfoID": 1,
        ///         "LastName": "Lê ",
        ///         "FirstName": "Việt",
        ///         "PersName": "Lê  Việt",
        ///         "PersGenderCode": null,
        ///         "PersGenderName": null,
        ///         "PersBirthDtm": "1900-01-01T00:00:00",
        ///         "IDNo": null,
        ///         "PersHomePhonePhN": "+84.905663843",
        ///         "EmailAddress": "p010@gmail.com",
        ///         "PtId": 330,
        ///         "DeptName": "[Khoa Tai mũi họng]",
        ///         "AcademicName": null,
        ///         "EmpFirstName": "Warner",
        ///         "EmpMiddleName": null,
        ///         "EmpPersName": "John Warner",
        ///         "StartTime": "08:45:00",
        ///         "EndTime": "09:00:00"
        ///        }
        ///     ]
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="RegInfoID">ID Lịch KCB</param>
        /// <param name="PtID">ID bệnh nhân</param>
        /// <returns></returns>
        [Route("GetPatientFromAppointment")]
        [HttpGet]
        public IHttpActionResult GetPatientFromAppointment(long? RegInfoID, long? PtID)
        {
            try
            {
                var objNames = new object[] { "RegInfoID", "PtID" };
                var objValues = new object[] { RegInfoID, PtID };
                var result = this.Repository.ExecuteStoreScalar("usp_GetPatientFromApptByRegInfoID", objNames, objValues);
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
