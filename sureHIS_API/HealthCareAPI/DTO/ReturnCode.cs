using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareAPI.DTO
{
    public class ReturnCode
    {
        public List<ReturCodeDTO> lstReturCode = new List<ReturCodeDTO>();
        private const int NO_DATA_IN = -1;// KHÔNG CÓ DỮ LIỆU ĐẦU VÀO
        //1 funtion 30 ReturnCode identity
        private const int OK = 0;
        private const int LOGIN_INCORECT = 1;
        private const int LOGIN_ISBLOCKED = 2;
        private const int LOGIN_NON_ISACTIVE = 3;
        //
        private const int ALL_IVALIDPARAM_ACCOUNT = 4;

        //Addupdate HCP 10-39
        /// <summary>
        /// 
        /// </summary>
        private const int UPDATE_SUCCESS = 5;

        //InsertRADT 40-89
        private const int INSERT_SUCCESS = 40;//
        private const int INSERT_UPDATE_PERSON_ERROR = 41;
        private const int INSERT_UPDATE_PATIENT_ERROR = 42;
        private const int INSERT_UPDATE_PATIENT_ADMISSION_ERROR = 43;
        private const int INSERT_UPDATE_HEALTH_INSURANCE_ERROR = 44;
        private const int INSERT_UPDATE_HI_ADMISSION_ERROR = 45;
        private const int INSERT_UPDATE_PATIENT_MED_RECORD_ERROR = 46;
        private const int INSERT_UPDATE__ERROR = 47;//CHƯA CÓ --QUÊN 1 MÃ :) - TRONG TRAN
        private const int INSERT_UPDATE_PATIENT_COMMON_MED_RECORD_ERROR = 48;
        private const int INSERT_UPDATE_PATIENT_VITAL_SIGN_ERROR = 49;
        private const int INSERT_UPDATE_MEDICAL_CLAIM_SERVICE_CONFIG_FALSE_ERROR = 50;
        private const int INSERT_UPDATE_HEALTH_CARE_QUEUE_CONFIG_FALSE_ERROR = 51;
        private const int INSERT_UPDATE_PATIENT_TRANSACTION_ERROR = 52;
        private const int INSERT_UPDATE_HOSPITAL_FEE_TRANSACTION_ERROR = 53;
        private const int INSERT_UPDATE_HOS_FEE_TRANS_DETAIL_ERROR = 54;
        private const int INSERT_UPDATE_MEDICAL_CLAIM_SERVICE_CONFIG_TRUE_ERROR = 55;
        private const int INSERT_UPDATE_HEALTH_CARE_QUEUE_CONFIG_TRUE_ERROR = 56;

        //REGISTERACCOUNT 60-69
        private const int REGISTERACCOUNT_IVALID_EMAIL = 60;
        private const int REGISTERACCOUNT_NODEFINE = 61;
        private const int REGISTERACCOUNT_NO_PROCESS = 62;
        private const int REGISTERACCOUNT_NOTEXISTS_INFOR = 63;
        private const int REGISTERACCOUNT_FIRSTNAME_ERROR = 64;
        private const int REGISTERACCOUNT_DATEOFBIRTH_ERROR = 65;
        private const int REGISTERACCOUNT_NOTEXIST_ID = 66;
        private const int REGISTERACCOUNT_NOTEXIST_EMAIL = 67;
        private const int REGISTERACCOUNT_LASTNAME_ERROR = 68;
        private const int REGISTERACCOUNT_NOTEXIST_PERHOMEPHONE = 69;
        //REGAPPOINTMENTONLINE 70-89
        private const int REGAPPOINTMENTONLINE_NODEFINE = 70;
        private const int REGAPPOINTMENTONLINE_INSERTINFOR_ERROR = 71;
        private const int REGAPPOINTMENTONLINE_ONLINEQUE_ERROR = 72;
        private const int REGAPPOINTMENTONLINE_APPOINTMENT_ERROR = 73;
        //usp_ForgotPassword  90-99
        //AddUpdateRefAppConfig  100-129
        public ReturnCode()
        {
            ///////////////REGISTERACCOUNT 60-69
            lstReturCode.Add(new ReturCodeDTO { GroupName = "REGISTERACCOUNT", Name = "REGISTERACCOUNT_IVALID_EMAIL", Code = 60, Descriptions = "" });
            lstReturCode.Add(new ReturCodeDTO {  Name = "REGISTERACCOUNT_NODEFINE", Code = 61, Descriptions = "" });
            lstReturCode.Add(new ReturCodeDTO { Name = "REGISTERACCOUNT_NO_PROCESS", Code = 62, Descriptions = "" }); 
            lstReturCode.Add(new ReturCodeDTO { Name = "REGISTERACCOUNT_NOTEXISTS_INFOR", Code = 63, Descriptions = "" });
            lstReturCode.Add(new ReturCodeDTO { Name = "REGISTERACCOUNT_FIRSTNAME_ERROR", Code = 64, Descriptions = "" });
            lstReturCode.Add(new ReturCodeDTO { Name = "REGISTERACCOUNT_DATEOFBIRTH_ERROR", Code = 65, Descriptions = "" });
            lstReturCode.Add(new ReturCodeDTO { Name = "REGISTERACCOUNT_NOTEXIST_ID", Code = 66, Descriptions = "" });
            lstReturCode.Add(new ReturCodeDTO { Name = "REGISTERACCOUNT_LASTNAME_ERROR", Code = 68, Descriptions = "" });
        }
    }
    public class ReturCodeDTO
    {
        public string GroupName { get; set; }
        public string Name { get; set; }
        public long Code { get; set; }
        public string Descriptions { get; set; }
    }
}