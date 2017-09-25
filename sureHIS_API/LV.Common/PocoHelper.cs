using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LV.Common
{
    public class PocoHelper
    {
        public static List<string> PocoRecordPermistion = new List<string>() {
            { "AcPrincDrug" },{ "AdvancedSpecialist" },{ "Alert" },{ "AllergyIntolerance" },{ "AntagonistDrug" },{ "Application" },{ "AppliedMedStandard" },{ "Appointment" },{ "ArchitectureResources" },{ "ASPNetRole" },{ "ASPNetRolePermission" },{ "ASPNetToken" },{ "ASPNetUser" },{ "ASPNetUserClaims" },{ "ASPNetUserLogin" },{ "ASPNetUserRole" },{ "AssignMedEquip" },{ "AssignmentSchedule" },{ "AttachedDoc" },{ "BedInRoom" },{ "Bloodbank" },{ "BloodDonation" },{ "BodyRegion" },{ "BusySchedule" },{ "ClinicalIndicatorType" },{ "ClinicalTrial" },{ "ClinicalTrialResult" },{ "ContactDetails" },{ "Contract" },{ "ContractChange" },{ "ContractDocument" },{ "ChainMedicalServices" },{ "DDI" },{ "DeathSituationInfo" },{ "DHCRoomBlock" },{ "DiagDescribeTmp" },{ "DisposableMDResource" },{ "DocItem" },{ "Donor" },{ "DonorMedicalConditions" },{ "DonorMedication" },{ "DrAdviceTmp" },{ "DrMedicineAdvice" },{ "DrMedicineTmp" },{ "DrPrescriptionTmp" },{ "DrPrescriptionTmps" },{ "Drug" },{ "DrugConfign" },{ "DrugInDepartment" },{ "DrugPrice" },{ "EduLevel" },{ "EmpAllocation" },{ "Employee" },{ "EmployeeAnnualLeave" },{ "EmployeeLeaveTaken" },{ "Employeer" },{ "EmpWorkSchedule" },{ "EquipHistory" },{ "EquivMedService" },{ "EventHoliday" },{ "ExamMaintenanceHistory" },{ "FamilyHistory" },{ "ForeignExchange" },{ "GenericSocialNetwork" },{ "HCProvider" },{ "HCRoomBlock" },{ "HCStakeholder" },{ "HealthCareQueue" },{ "HealthInsurance" },{ "HIAdmission" },{ "HIServiceItem" },{ "HIServiceItems" },{ "HosFeeTransDetails" },{ "HospitalFeeTransaction" },{ "HospitalizationHistory" },{ "HospitalizationHistoryDetails" },{ "HospitalSpecialist" },{ "HosRanking" },{ "ICD10" },{ "ICDChapter" },{ "ICDGroup" },{ "ImmunizationHistory" },{ "InOutType" },{ "InOutwardDrug" },{ "InputMaskSetting" },{ "InsuranceBeneficiary" },{ "InsuranceCompany" },{ "InsuranceInterests" },{ "InsuranceRegQueue" },{ "JobHistory" },{ "JobModel" },{ "LanguageLevel" },{ "LotNumber" },{ "MedEnctrDiagnosis" },{ "MedicalBill" },{ "MedicalBills" },{ "MedicalClaimService" },{ "MedicalConditionRecord" },{ "MedicalDiagnosticMethod" },{ "MedicalEncounter" },{ "MedicalEquimentsResources" },{ "MedicalServiceItem" },{ "MedicalServicePackage" },{ "MedicalTestProcedure" },{ "MedicationHistory" },{ "MedImagingRepository" },{ "MedImagingTest" },{ "MedImagingTestItems" },{ "MedLabRepository" },{ "MedLabTest" },{ "MedLabTestItems" },{ "MedRecOutline" },{ "MedRecTmp" },{ "MedSerInDept" },{ "MesrtConv" },{ "MiscDocuments" },{ "MOHServiceItems" },{ "MRParagraph" },{ "MRSection" },{ "MRSectionOutline" },{ "NetworkGuestAccount" },{ "NextOfKins" },{ "OccCareerMOH" },{ "OnlineQueue" },{ "Operations" },{ "OperationSchedule" },{ "OpSkedDistibution" },{ "Organization" },{ "ParaClinicalExamGroup" },{ "ParaClinicalReq" },{ "ParaClinicalReqDetails" },{ "PastPersonHistory" },{ "Patient" },{ "PatientAddressHistory" },{ "PatientAdmission" },{ "PatientBed" },{ "PatientBedFeatures" },{ "PatientClassHistory" },{ "PatientClassification" },{ "PatientCommonMedRecord" },{ "PatientDiagnosticImaging" },{ "PatientInBedRoom" },{ "PatientInvoices" },{ "PatientMedLabTestResult" },{ "PatientMedRecord" },{ "PatientProblem" },{ "PatientPVID" },{ "PatientSpecimen" },{ "PatientTransaction" },{ "PatientVitalSign" },{ "Person" },{ "PersonalProperty" },{ "PersonRole" },{ "Prescription" },{ "PrescriptionDetail" },{ "PrescriptionHistory" },{ "PriceList" },{ "PrivacyClass" },{ "PrivilegeRole" },{ "PromotionPlan" },{ "PromotionService" },{ "ProvidableDrugs" },{ "PharmaceuticalCompany" },{ "PhysicalExamination" },{ "Quotation" },{ "Realms" },{ "refAcademicTile" },{ "refActiviePrinciple" },{ "refAdmissionType" },{ "refAdmReferralType" },{ "refAllergyCategory" },{ "refAllergyIndex" },{ "refAnnTemp" },{ "refAppConfig" },{ "refBloodType" },{ "refCareerMOH" },{ "refCertification" },{ "refCityProvince" },{ "refCLMeasurement" },{ "refCommonTerm" },{ "refCountry" },{ "refCurrency" },{ "refDepartment" },{ "refDepreciationType" },{ "refDiagnosis" },{ "refDischargeDisposition" },{ "refDistrict" },{ "refDrugKind" },{ "refEducationalLevel" },{ "refElthnic" },{ "refEthnicGroup" },{ "refExamAction" },{ "refExamObservation" },{ "refFAMRelationship" },{ "refHL7" },{ "refHumanLanguage" },{ "refImmunization" },{ "refInstUniversity" },{ "refInsurKind" },{ "refInternalReceiptType" },{ "refItemType" },{ "refJobBand" },{ "refJobTitle" },{ "refLimVitalSign" },{ "refLookup" },{ "refMedcnAdminRoute" },{ "refMedcnVehicleForm" },{ "refMedEquipResourceType" },{ "refMedHisIndex" },{ "refMedicalCondition" },{ "refMedicalServiceType" },{ "refOccupation" },{ "refPermission" },{ "refPersGender" },{ "refPersMaritalStatus" },{ "refPersRace" },{ "refProblem" },{ "refProviderType" },{ "refQualification" },{ "refReligion" },{ "refRole" },{ "refShelfDrugLocation" },{ "refShift" },{ "refSIPrefix" },{ "refSocialHisSeverity" },{ "refSpecimenType" },{ "refStoreHouse" },{ "refTimeFrame" },{ "refTypeAbsent" },{ "refTransactionType" },{ "refUnitOfMeasure" },{ "refVitalSign" },{ "refWard" },{ "RegQueue" },{ "RegistrationInfo" },{ "ReminderNotices" },{ "RescrUsedInOperation" },{ "ResearchPartnership" },{ "Resource" },{ "ResourceLog" },{ "RoomAllocation" },{ "RxHoldConsultation" },{ "SeparationOfBlood" },{ "ServerLog" },{ "Session" },{ "SocialAndHealthInsurance" },{ "SpecifiedParaclinical" },{ "SpecMedRecTmp" },{ "StdKSection" },{ "Supplier" },{ "SymptomIndicator" },{ "TechnicalInspectionAgency" },{ "TestBlood" },{ "TestOnPatientSpecimen" },{ "UserAccount" },{ "UserGroup" },{ "UsersInGroup" },{ "uv_Rand" },{ "Ward" },{ "WardInDept" },{ "WorkingDay" },{ "WorkingSchedule" },{ "WorkPlace" },
        };

        public static bool IsRecordPermision(string EntityName)
        {
            return PocoRecordPermistion.Contains(EntityName);
        }
        public static Dictionary<string, Type> ListPocoType = new Dictionary<string, Type>();

        public static void SetListPocoType(Dictionary<string, Type> listPocoType)
        {
            if (listPocoType != null && listPocoType.Count > 0)
                ListPocoType = listPocoType;
        }

        public static string[] GetPocoKeys(Type type)
        {
            var keys = type.GetProperties().Where(x => x.GetCustomAttributes(false).OfType<KeyAttribute>().Any())
                .Select(x => x.Name)
                .ToArray();

            return keys;
        }

        public static void SetValue(object row, string Name, object Value)
        {

            PropertyInfo prop = row.GetType().GetProperty(Name, BindingFlags.Public | BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                try { prop.SetValue(row, Value, null); }
                catch { }

            }

        }

        public static Object GetPropValue(String name, Object obj)
        {
            object Result = obj;
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null)
                {
                    //MessageBox.Show(name + " is not exists !!!");
                    return null;
                }

                Result = info.GetValue(obj, null);
            }
            return Result;
        }


        public static Dictionary<string, Type> GetListPocoType()
        {
            if (ListPocoType == null || ListPocoType.Count <= 0)
                GenerateListPocoType();

            return ListPocoType;
        }

        public static void GenerateListPocoType()
        {
            try
            {
                lock (ListPocoType)
                {
                    ListPocoType = new Dictionary<string, Type>();

                    string path = string.Empty;

                    if (HttpContext.Current != null)
                        path = HttpContext.Current.Server.MapPath("~/bin");

                    if (path != string.Empty)
                    {
                        var pocoFiles = Directory.GetFiles(path, "LV.Poco.*", SearchOption.TopDirectoryOnly)
                                            .Where(x => x.EndsWith(".dll"))
                                            .ToArray();

                        var reportPocoFiles = Directory.GetFiles(path, "LV.ReportStandard.*", SearchOption.TopDirectoryOnly)
                                            .Where(x => x.Contains(".dll"))
                                            .ToArray();

                        List<string> modelFiles = new List<string>();
                        modelFiles.AddRange(pocoFiles);
                        modelFiles.AddRange(reportPocoFiles);

                        for (int i = 0; i < modelFiles.Count; i++)
                        {
                            string file = modelFiles[i];

                            Assembly asm = Assembly.LoadFrom(file);
                            Type[] types = asm.GetTypes();

                            for (int j = 0; j < types.Length; j++)
                            {
                                Type type = types[j];

                                if (ListPocoType.ContainsKey(type.Name) == false)
                                    ListPocoType.Add(type.Name, type);
                            }
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                // now look at ex.LoaderExceptions - this is an Exception[], so:
                foreach (Exception inner in ex.LoaderExceptions)
                {
                    // write details of "inner", in particular inner.Message
                }
            }
        }

        public static Type GetTypeFromString(string sTypeName)
        {
            if (ListPocoType == null || ListPocoType.Count <= 0)
                GenerateListPocoType();

            if (sTypeName != null)
            {
                int lastDotIndex = sTypeName.LastIndexOf(".");

                if (lastDotIndex > 0)
                    sTypeName = sTypeName.Substring((lastDotIndex + 1), (sTypeName.Length - (lastDotIndex + 1)));

                if (ListPocoType != null && ListPocoType.ContainsKey(sTypeName))
                    return ListPocoType[sTypeName];
            }

            return null;
        }

        public static T Clone<T>(T poco)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, poco);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static void PocoCopy(object Source, object Target)
        {
            PocoCopy(Source, Target, null);
        }

        public static void PocoCopy(object Source, object Target, string[] Exception)
        {
            foreach (PropertyInfo s in Source.GetType().GetProperties().ToList())
                if (!s.PropertyType.FullName.Contains("LV.Poco")
                    && (Exception == null || Exception.Count() == 0 || Exception.Where(t => t == s.Name).FirstOrDefault() == null))
                    SetValue(Target, s.Name, GetPropValue(s.Name, Source));
        }

        public static void PocoFixDate(object ob)
        {
            foreach (PropertyInfo s in ob.GetType().GetProperties().ToList())
            {
                object value = GetPropValue(s.Name, ob);
                if (value != null && value.GetType() == typeof(DateTime) && ((DateTime)value).ToString("yyyyMMdd") == "00010101")
                    SetValue(ob, s.Name, DateTime.Today);
            }
        }

        public static T PocoClone<T>(T poco) where T : new()
        {
            T returnObj = new T();

            if (poco != null)
            {
                typeof(T).GetProperties().ToList()
                    .ForEach(o =>
                    {
                        if (!o.PropertyType.FullName.Contains("LV.Poco"))
                            o.SetValue(returnObj, o.GetValue(poco, null), null);
                    });
            }
            return returnObj;
        }

        public static object PocoClone(object poco, string[] Exception)
        {
            if (poco == null) return null;
            object returnObj = poco.GetType().Assembly.CreateInstance(poco.GetType().FullName);

            if (poco != null)
            {
                poco.GetType().GetProperties().ToList()
                    .ForEach(o =>
                    {
                        if (!o.PropertyType.FullName.Contains("LV.Poco") && (Exception == null || Exception.Count() == 0 || Exception.Where(t => t == o.Name).FirstOrDefault() == null))
                            o.SetValue(returnObj, o.GetValue(poco, null), null);
                    });
            }
            return returnObj;
        }

        public static T PocoCopy<T>(object poco) where T : new()
        {
            T returnObj = new T();

            if (poco != null)
            {
                var mapProprrty = from s in poco.GetType().GetProperties()
                                  join d in typeof(T).GetProperties() on new { s.PropertyType, s.Name } equals new { d.PropertyType, d.Name }
                                  select d;

                mapProprrty.ToList()
                    .ForEach(o =>
                    {
                        var pro = poco.GetType().GetProperty(o.Name);
                        if (pro != null)
                        {
                            if (!pro.PropertyType.FullName.Contains("LV.Poco"))
                                o.SetValue(returnObj, pro.GetValue(poco, null), null);
                        }
                    });
            }
            return returnObj;
        }

        public static void PocoCopyEx(object Target, object Source)
        {
            if (Source != null)
            {
                var mapProprrty = from s in Source.GetType().GetProperties()
                                  join d in Target.GetType().GetProperties() on new { s.PropertyType, s.Name } equals new { d.PropertyType, d.Name }
                                  select d;

                mapProprrty.ToList()
                    .ForEach(o =>
                    {
                        var pro = Source.GetType().GetProperty(o.Name);
                        if (pro != null)
                        {
                            if (!pro.PropertyType.FullName.Contains("LV.Poco"))
                                o.SetValue(Target, pro.GetValue(Source, null), null);
                        }
                    });
            }
        }

        public static void SelfLoopObjects(object Source)
        {
            if (Source == null && Source as IEnumerable != null) return;
            IEnumerable list = (IEnumerable)Source;
            foreach (var item in list)
            {
                SelfLoopObject(item);
            }
            
        }

        public static void SelfLoopObject(object Source)
        {
            if (Source != null)
            {
                var notMap = Source.GetType().GetProperties().Where(o => o.GetCustomAttribute(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute),true)!=null);

                foreach (PropertyInfo item in notMap)
                {
                    if (item.GetGetMethod() != null)
                        item.GetValue(Source,null);
                }

                var mapProprrty = Source.GetType().GetProperties().Where(o => o.PropertyType.FullName.Contains("LV.Poco"));
                foreach (PropertyInfo item in mapProprrty)
                {
                    if(item.GetSetMethod()!=null)
                        item.SetValue(Source, null,null);
                }
            }
        }

        public static DataTable CreateDataTable(Type type,IEnumerable list)
        {
            var properties = type.GetProperties().Where(o=>
                (o.PropertyType == typeof(string)
                || o.PropertyType == typeof(int) || o.PropertyType == typeof(int?)
                || o.PropertyType == typeof(Int16) || o.PropertyType == typeof(Int16?)
                || o.PropertyType == typeof(decimal) || o.PropertyType == typeof(decimal?)
                || o.PropertyType == typeof(DateTime) || o.PropertyType == typeof(DateTime?)
                || o.PropertyType == typeof(Guid) || o.PropertyType == typeof(Guid?)
                || o.PropertyType == typeof(bool) || o.PropertyType == typeof(bool?)
                )
                && !o.GetCustomAttributes().Where(c=>c.GetType() == typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute)).Any()
                ).ToArray();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (var entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static List<Dictionary<string, object>> GetTableRows(DataTable dtData)
        {
            List<Dictionary<string, object>>
            lstRows = new List<Dictionary<string, object>>();
            Dictionary<string, object> dictRow = null;

            foreach (DataRow dr in dtData.Rows)
            {
                dictRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtData.Columns)
                {
                    dictRow.Add(col.ColumnName, dr[col]);
                }
                lstRows.Add(dictRow);
            }
            return lstRows;
        }
        
    }
}
