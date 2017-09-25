using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public class ConfigData
    {
        public ConfigSys Config { get; set; }
        public HCProvider HCProvider { get; set; }

        public List<refLookup> Lookup { get; set; }

        public bool ConfigChange { get; set; }

        public bool HCProviderChange { get; set; }

        public bool LookupChange { get; set; }

        public string ObjectName { get; set; }
    }

    public class ConfigSys
    {
        public long? A_VATPercent { get; set; }
        public bool B_DayTermWarning { get; set; }
        public bool B_IsInputBarcode { get; set; }
        public bool B_IsInputFingerPrint { get; set; }
        public bool B_IsInputMagneticCard { get; set; }
        public bool B_IsInputQMS { get; set; }
        public bool B_IsInputQRCode { get; set; }
        public string C_Password { get; set; }
        public string C_PasswordDatabase { get; set; }
        public string C_Database { get; set; }
        public string C_PasswordBHYT { get; set; }
        public string C_PasswordCLS { get; set; }
        public string C_PrintBill { get; set; }
        public string C_PrintReport { get; set; }
        public string C_Server { get; set; }
        public string C_ServerBHYT { get; set; }
        public string C_ServerCLS { get; set; }
        public string C_ServerConnect { get; set; }
        public string C_ServerConnectCLS { get; set; }
        public string C_ServerConnectDatabase { get; set; }
        public string C_ServerDatabase { get; set; }
        public string C_User { get; set; }
        public string C_UserBHYT { get; set; }
        public string C_UserCLS { get; set; }
        public string C_UserDatabase { get; set; }
        public bool E_IsOnlyPrescription { get; set; }
        public long? F_DayTermWarning { get; set; }
        public long? F_ProductWarningInventory { get; set; }
        public bool F_IsWarningInventory { get; set; }
        public bool F_IsTermWarning { get; set; }
        public string F_LongDateFormat { get; set; }
        public string F_NumberFormat { get; set; }
        public string F_ShortDateFormat { get; set; }
        public long? O_FileDownloadMax { get; set; }
        public long? O_FileUploadMax { get; set; }
        public string O_FormatFileUpload { get; set; }
        public string O_Language { get; set; }
        public string U_Height { get; set; }
        public string U_MeasurementSys { get; set; }
        public string U_Temperature { get; set; }
        public string U_Volume { get; set; }
        public string U_Weight { get; set; }
        public string ProvinceCode { get; set; }
        public string NationCode { get; set; }
        public bool RegAdmAndCshr { get; set; }
        public bool RegAdmPrtByMOH { get; set; }
        public bool RegAdmSilentPrt { get; set; }
        public bool RegApptByProcess { get; set; }
    }
}
