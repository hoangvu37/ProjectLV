using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace LV.Poco
{
	public class LVHubsHelper 
    {
		#region Declare KeyedCollection
		 
		static KeyedMedEnctrDiagnosis keysMedEnctrDiagnosis;
		public static KeyedMedEnctrDiagnosis KeysMedEnctrDiagnosis { get { return keysMedEnctrDiagnosis; } set { keysMedEnctrDiagnosis = value; } }

		static KeyedParaClinicalExamGroup keysParaClinicalExamGroup;
		public static KeyedParaClinicalExamGroup KeysParaClinicalExamGroup { get { return keysParaClinicalExamGroup; } set { keysParaClinicalExamGroup = value; } }

		static KeyedBloodDonation keysBloodDonation;
		public static KeyedBloodDonation KeysBloodDonation { get { return keysBloodDonation; } set { keysBloodDonation = value; } }

		static KeyedEmpWorkSchedule keysEmpWorkSchedule;
		public static KeyedEmpWorkSchedule KeysEmpWorkSchedule { get { return keysEmpWorkSchedule; } set { keysEmpWorkSchedule = value; } }

		static KeyedMedicalClaimService keysMedicalClaimService;
		public static KeyedMedicalClaimService KeysMedicalClaimService { get { return keysMedicalClaimService; } set { keysMedicalClaimService = value; } }

		static KeyedParaClinicalReq keysParaClinicalReq;
		public static KeyedParaClinicalReq KeysParaClinicalReq { get { return keysParaClinicalReq; } set { keysParaClinicalReq = value; } }

		static KeyedDonor keysDonor;
		public static KeyedDonor KeysDonor { get { return keysDonor; } set { keysDonor = value; } }

		static KeyedResourceLog keysResourceLog;
		public static KeyedResourceLog KeysResourceLog { get { return keysResourceLog; } set { keysResourceLog = value; } }

		static KeyedrefCertification keysrefCertification;
		public static KeyedrefCertification KeysrefCertification { get { return keysrefCertification; } set { keysrefCertification = value; } }

		static KeyedMedicalConditionRecord keysMedicalConditionRecord;
		public static KeyedMedicalConditionRecord KeysMedicalConditionRecord { get { return keysMedicalConditionRecord; } set { keysMedicalConditionRecord = value; } }

		static KeyedPatientVitalSign keysPatientVitalSign;
		public static KeyedPatientVitalSign KeysPatientVitalSign { get { return keysPatientVitalSign; } set { keysPatientVitalSign = value; } }

		static KeyedDonorMedicalConditions keysDonorMedicalConditions;
		public static KeyedDonorMedicalConditions KeysDonorMedicalConditions { get { return keysDonorMedicalConditions; } set { keysDonorMedicalConditions = value; } }

		static KeyedInsuranceCompany keysInsuranceCompany;
		public static KeyedInsuranceCompany KeysInsuranceCompany { get { return keysInsuranceCompany; } set { keysInsuranceCompany = value; } }

		static KeyedrefCityProvince keysrefCityProvince;
		public static KeyedrefCityProvince KeysrefCityProvince { get { return keysrefCityProvince; } set { keysrefCityProvince = value; } }

		static KeyedDonorMedication keysDonorMedication;
		public static KeyedDonorMedication KeysDonorMedication { get { return keysDonorMedication; } set { keysDonorMedication = value; } }

		static KeyedEventHoliday keysEventHoliday;
		public static KeyedEventHoliday KeysEventHoliday { get { return keysEventHoliday; } set { keysEventHoliday = value; } }

		static KeyedRoomAllocation keysRoomAllocation;
		public static KeyedRoomAllocation KeysRoomAllocation { get { return keysRoomAllocation; } set { keysRoomAllocation = value; } }

		static KeyedrefCLMeasurement keysrefCLMeasurement;
		public static KeyedrefCLMeasurement KeysrefCLMeasurement { get { return keysrefCLMeasurement; } set { keysrefCLMeasurement = value; } }

		static KeyedMedicalEncounter keysMedicalEncounter;
		public static KeyedMedicalEncounter KeysMedicalEncounter { get { return keysMedicalEncounter; } set { keysMedicalEncounter = value; } }

		static KeyedSeparationOfBlood keysSeparationOfBlood;
		public static KeyedSeparationOfBlood KeysSeparationOfBlood { get { return keysSeparationOfBlood; } set { keysSeparationOfBlood = value; } }

		static KeyedMedicationHistory keysMedicationHistory;
		public static KeyedMedicationHistory KeysMedicationHistory { get { return keysMedicationHistory; } set { keysMedicationHistory = value; } }

		static KeyedTestBlood keysTestBlood;
		public static KeyedTestBlood KeysTestBlood { get { return keysTestBlood; } set { keysTestBlood = value; } }

		static KeyedStdKSection keysStdKSection;
		public static KeyedStdKSection KeysStdKSection { get { return keysStdKSection; } set { keysStdKSection = value; } }

		static KeyedrefVitalSign keysrefVitalSign;
		public static KeyedrefVitalSign KeysrefVitalSign { get { return keysrefVitalSign; } set { keysrefVitalSign = value; } }

		static KeyedrefCommonTerm keysrefCommonTerm;
		public static KeyedrefCommonTerm KeysrefCommonTerm { get { return keysrefCommonTerm; } set { keysrefCommonTerm = value; } }

		static KeyedOperations keysOperations;
		public static KeyedOperations KeysOperations { get { return keysOperations; } set { keysOperations = value; } }

		static KeyedMiscDocuments keysMiscDocuments;
		public static KeyedMiscDocuments KeysMiscDocuments { get { return keysMiscDocuments; } set { keysMiscDocuments = value; } }

		static KeyedAttachedDoc keysAttachedDoc;
		public static KeyedAttachedDoc KeysAttachedDoc { get { return keysAttachedDoc; } set { keysAttachedDoc = value; } }

		static KeyedSupplier keysSupplier;
		public static KeyedSupplier KeysSupplier { get { return keysSupplier; } set { keysSupplier = value; } }

		static KeyedrefReligion keysrefReligion;
		public static KeyedrefReligion KeysrefReligion { get { return keysrefReligion; } set { keysrefReligion = value; } }

		static KeyedOperationSchedule keysOperationSchedule;
		public static KeyedOperationSchedule KeysOperationSchedule { get { return keysOperationSchedule; } set { keysOperationSchedule = value; } }

		static KeyedChainMedicalServices keysChainMedicalServices;
		public static KeyedChainMedicalServices KeysChainMedicalServices { get { return keysChainMedicalServices; } set { keysChainMedicalServices = value; } }

		static KeyedDocItem keysDocItem;
		public static KeyedDocItem KeysDocItem { get { return keysDocItem; } set { keysDocItem = value; } }

		static KeyedPastPersonHistory keysPastPersonHistory;
		public static KeyedPastPersonHistory KeysPastPersonHistory { get { return keysPastPersonHistory; } set { keysPastPersonHistory = value; } }

		static KeyedParaClinicalReqDetails keysParaClinicalReqDetails;
		public static KeyedParaClinicalReqDetails KeysParaClinicalReqDetails { get { return keysParaClinicalReqDetails; } set { keysParaClinicalReqDetails = value; } }

		static KeyedPatientAdmission keysPatientAdmission;
		public static KeyedPatientAdmission KeysPatientAdmission { get { return keysPatientAdmission; } set { keysPatientAdmission = value; } }

		static KeyedrefCountry keysrefCountry;
		public static KeyedrefCountry KeysrefCountry { get { return keysrefCountry; } set { keysrefCountry = value; } }

		static KeyedPatientAddressHistory keysPatientAddressHistory;
		public static KeyedPatientAddressHistory KeysPatientAddressHistory { get { return keysPatientAddressHistory; } set { keysPatientAddressHistory = value; } }

		static KeyedrefPersRace keysrefPersRace;
		public static KeyedrefPersRace KeysrefPersRace { get { return keysrefPersRace; } set { keysrefPersRace = value; } }

		static KeyedOpSkedDistibution keysOpSkedDistibution;
		public static KeyedOpSkedDistibution KeysOpSkedDistibution { get { return keysOpSkedDistibution; } set { keysOpSkedDistibution = value; } }

		static KeyedPatientDiagnosticImaging keysPatientDiagnosticImaging;
		public static KeyedPatientDiagnosticImaging KeysPatientDiagnosticImaging { get { return keysPatientDiagnosticImaging; } set { keysPatientDiagnosticImaging = value; } }

		static KeyedEquivMedService keysEquivMedService;
		public static KeyedEquivMedService KeysEquivMedService { get { return keysEquivMedService; } set { keysEquivMedService = value; } }

		static KeyedrefCurrency keysrefCurrency;
		public static KeyedrefCurrency KeysrefCurrency { get { return keysrefCurrency; } set { keysrefCurrency = value; } }

		static KeyedPatientClassHistory keysPatientClassHistory;
		public static KeyedPatientClassHistory KeysPatientClassHistory { get { return keysPatientClassHistory; } set { keysPatientClassHistory = value; } }

		static KeyedRescrUsedInOperation keysRescrUsedInOperation;
		public static KeyedRescrUsedInOperation KeysRescrUsedInOperation { get { return keysRescrUsedInOperation; } set { keysRescrUsedInOperation = value; } }

		static KeyedTechnicalInspectionAgency keysTechnicalInspectionAgency;
		public static KeyedTechnicalInspectionAgency KeysTechnicalInspectionAgency { get { return keysTechnicalInspectionAgency; } set { keysTechnicalInspectionAgency = value; } }

		static KeyedPatientClassification keysPatientClassification;
		public static KeyedPatientClassification KeysPatientClassification { get { return keysPatientClassification; } set { keysPatientClassification = value; } }

		static KeyedrefDepartment keysrefDepartment;
		public static KeyedrefDepartment KeysrefDepartment { get { return keysrefDepartment; } set { keysrefDepartment = value; } }

		static KeyedWorkingDay keysWorkingDay;
		public static KeyedWorkingDay KeysWorkingDay { get { return keysWorkingDay; } set { keysWorkingDay = value; } }

		static KeyedHIServiceItem keysHIServiceItem;
		public static KeyedHIServiceItem KeysHIServiceItem { get { return keysHIServiceItem; } set { keysHIServiceItem = value; } }

		static KeyedWorkingSchedule keysWorkingSchedule;
		public static KeyedWorkingSchedule KeysWorkingSchedule { get { return keysWorkingSchedule; } set { keysWorkingSchedule = value; } }

		static KeyedPatientMedLabTestResult keysPatientMedLabTestResult;
		public static KeyedPatientMedLabTestResult KeysPatientMedLabTestResult { get { return keysPatientMedLabTestResult; } set { keysPatientMedLabTestResult = value; } }

		static KeyedWard keysWard;
		public static KeyedWard KeysWard { get { return keysWard; } set { keysWard = value; } }

		static KeyedrefDepreciationType keysrefDepreciationType;
		public static KeyedrefDepreciationType KeysrefDepreciationType { get { return keysrefDepreciationType; } set { keysrefDepreciationType = value; } }

		static KeyedDDI keysDDI;
		public static KeyedDDI KeysDDI { get { return keysDDI; } set { keysDDI = value; } }

		static KeyedHIServiceItems keysHIServiceItems;
		public static KeyedHIServiceItems KeysHIServiceItems { get { return keysHIServiceItems; } set { keysHIServiceItems = value; } }

		static KeyedrefDiagnosis keysrefDiagnosis;
		public static KeyedrefDiagnosis KeysrefDiagnosis { get { return keysrefDiagnosis; } set { keysrefDiagnosis = value; } }

		static KeyedHistoricalAuditData keysHistoricalAuditData;
		public static KeyedHistoricalAuditData KeysHistoricalAuditData { get { return keysHistoricalAuditData; } set { keysHistoricalAuditData = value; } }

		static KeyedWardInDept keysWardInDept;
		public static KeyedWardInDept KeysWardInDept { get { return keysWardInDept; } set { keysWardInDept = value; } }

		static KeyedPatientSpecimen keysPatientSpecimen;
		public static KeyedPatientSpecimen KeysPatientSpecimen { get { return keysPatientSpecimen; } set { keysPatientSpecimen = value; } }

		static KeyedHosFeeTransDetails keysHosFeeTransDetails;
		public static KeyedHosFeeTransDetails KeysHosFeeTransDetails { get { return keysHosFeeTransDetails; } set { keysHosFeeTransDetails = value; } }

		//static KeyedTrigs keysTrigs;
		//public static KeyedTrigs KeysTrigs { get { return keysTrigs; } set { keysTrigs = value; } }

		static KeyedICD10 keysICD10;
		public static KeyedICD10 KeysICD10 { get { return keysICD10; } set { keysICD10 = value; } }

		static KeyedrefDistrict keysrefDistrict;
		public static KeyedrefDistrict KeysrefDistrict { get { return keysrefDistrict; } set { keysrefDistrict = value; } }

		static KeyedrefEthnicGroup keysrefEthnicGroup;
		public static KeyedrefEthnicGroup KeysrefEthnicGroup { get { return keysrefEthnicGroup; } set { keysrefEthnicGroup = value; } }

		static KeyedrefDrugKind keysrefDrugKind;
		public static KeyedrefDrugKind KeysrefDrugKind { get { return keysrefDrugKind; } set { keysrefDrugKind = value; } }

		static KeyedICDChapter keysICDChapter;
		public static KeyedICDChapter KeysICDChapter { get { return keysICDChapter; } set { keysICDChapter = value; } }

		static KeyedICDGroup keysICDGroup;
		public static KeyedICDGroup KeysICDGroup { get { return keysICDGroup; } set { keysICDGroup = value; } }

		static KeyedSpecifiedParaclinical keysSpecifiedParaclinical;
		public static KeyedSpecifiedParaclinical KeysSpecifiedParaclinical { get { return keysSpecifiedParaclinical; } set { keysSpecifiedParaclinical = value; } }

		static KeyedrefElthnic keysrefElthnic;
		public static KeyedrefElthnic KeysrefElthnic { get { return keysrefElthnic; } set { keysrefElthnic = value; } }

		static KeyedDiagDescribeTmp keysDiagDescribeTmp;
		public static KeyedDiagDescribeTmp KeysDiagDescribeTmp { get { return keysDiagDescribeTmp; } set { keysDiagDescribeTmp = value; } }

		static KeyedTestOnPatientSpecimen keysTestOnPatientSpecimen;
		public static KeyedTestOnPatientSpecimen KeysTestOnPatientSpecimen { get { return keysTestOnPatientSpecimen; } set { keysTestOnPatientSpecimen = value; } }

		static KeyedrefExamAction keysrefExamAction;
		public static KeyedrefExamAction KeysrefExamAction { get { return keysrefExamAction; } set { keysrefExamAction = value; } }

		static KeyedPersonalProperty keysPersonalProperty;
		public static KeyedPersonalProperty KeysPersonalProperty { get { return keysPersonalProperty; } set { keysPersonalProperty = value; } }

		static KeyedrefProblem keysrefProblem;
		public static KeyedrefProblem KeysrefProblem { get { return keysrefProblem; } set { keysrefProblem = value; } }

		static KeyedDrAdviceTmp keysDrAdviceTmp;
		public static KeyedDrAdviceTmp KeysDrAdviceTmp { get { return keysDrAdviceTmp; } set { keysDrAdviceTmp = value; } }

		static KeyedrefExamObservation keysrefExamObservation;
		public static KeyedrefExamObservation KeysrefExamObservation { get { return keysrefExamObservation; } set { keysrefExamObservation = value; } }

		static KeyedDrMedicineAdvice keysDrMedicineAdvice;
		public static KeyedDrMedicineAdvice KeysDrMedicineAdvice { get { return keysDrMedicineAdvice; } set { keysDrMedicineAdvice = value; } }

		static KeyedDrMedicineTmp keysDrMedicineTmp;
		public static KeyedDrMedicineTmp KeysDrMedicineTmp { get { return keysDrMedicineTmp; } set { keysDrMedicineTmp = value; } }

		static KeyedrefHL7 keysrefHL7;
		public static KeyedrefHL7 KeysrefHL7 { get { return keysrefHL7; } set { keysrefHL7 = value; } }

		static KeyedDrPrescriptionTmp keysDrPrescriptionTmp;
		public static KeyedDrPrescriptionTmp KeysDrPrescriptionTmp { get { return keysDrPrescriptionTmp; } set { keysDrPrescriptionTmp = value; } }

		static KeyedHospitalFeeTransaction keysHospitalFeeTransaction;
		public static KeyedHospitalFeeTransaction KeysHospitalFeeTransaction { get { return keysHospitalFeeTransaction; } set { keysHospitalFeeTransaction = value; } }

		static KeyedPatientCommonMedRecord keysPatientCommonMedRecord;
		public static KeyedPatientCommonMedRecord KeysPatientCommonMedRecord { get { return keysPatientCommonMedRecord; } set { keysPatientCommonMedRecord = value; } }

		static KeyedHealthCareQueue keysHealthCareQueue;
		public static KeyedHealthCareQueue KeysHealthCareQueue { get { return keysHealthCareQueue; } set { keysHealthCareQueue = value; } }

		static KeyedAlert keysAlert;
		public static KeyedAlert KeysAlert { get { return keysAlert; } set { keysAlert = value; } }

		static KeyedrefHumanLanguage keysrefHumanLanguage;
		public static KeyedrefHumanLanguage KeysrefHumanLanguage { get { return keysrefHumanLanguage; } set { keysrefHumanLanguage = value; } }

		static KeyedPatient keysPatient;
		public static KeyedPatient KeysPatient { get { return keysPatient; } set { keysPatient = value; } }

		static KeyedPatientMedRecord keysPatientMedRecord;
		public static KeyedPatientMedRecord KeysPatientMedRecord { get { return keysPatientMedRecord; } set { keysPatientMedRecord = value; } }

		static KeyedrefImmunization keysrefImmunization;
		public static KeyedrefImmunization KeysrefImmunization { get { return keysrefImmunization; } set { keysrefImmunization = value; } }

		static KeyedrefUnitOfMeasure keysrefUnitOfMeasure;
		public static KeyedrefUnitOfMeasure KeysrefUnitOfMeasure { get { return keysrefUnitOfMeasure; } set { keysrefUnitOfMeasure = value; } }

		static KeyedPersonRole keysPersonRole;
		public static KeyedPersonRole KeysPersonRole { get { return keysPersonRole; } set { keysPersonRole = value; } }

		static KeyedDrPrescriptionTmps keysDrPrescriptionTmps;
		public static KeyedDrPrescriptionTmps KeysDrPrescriptionTmps { get { return keysDrPrescriptionTmps; } set { keysDrPrescriptionTmps = value; } }

		static KeyedrefInstUniversity keysrefInstUniversity;
		public static KeyedrefInstUniversity KeysrefInstUniversity { get { return keysrefInstUniversity; } set { keysrefInstUniversity = value; } }

		static KeyedAppointment keysAppointment;
		public static KeyedAppointment KeysAppointment { get { return keysAppointment; } set { keysAppointment = value; } }

		static KeyedrefJobBand keysrefJobBand;
		public static KeyedrefJobBand KeysrefJobBand { get { return keysrefJobBand; } set { keysrefJobBand = value; } }

		static KeyedASPNetRole keysASPNetRole;
		public static KeyedASPNetRole KeysASPNetRole { get { return keysASPNetRole; } set { keysASPNetRole = value; } }

		static KeyedMedicalBill keysMedicalBill;
		public static KeyedMedicalBill KeysMedicalBill { get { return keysMedicalBill; } set { keysMedicalBill = value; } }

		static KeyedrefInsurKind keysrefInsurKind;
		public static KeyedrefInsurKind KeysrefInsurKind { get { return keysrefInsurKind; } set { keysrefInsurKind = value; } }

		static KeyedASPNetRolePermission keysASPNetRolePermission;
		public static KeyedASPNetRolePermission KeysASPNetRolePermission { get { return keysASPNetRolePermission; } set { keysASPNetRolePermission = value; } }

		static KeyedPatientProblem keysPatientProblem;
		public static KeyedPatientProblem KeysPatientProblem { get { return keysPatientProblem; } set { keysPatientProblem = value; } }

		static KeyedMedicalBills keysMedicalBills;
		public static KeyedMedicalBills KeysMedicalBills { get { return keysMedicalBills; } set { keysMedicalBills = value; } }

		static KeyedrefInternalReceiptType keysrefInternalReceiptType;
		public static KeyedrefInternalReceiptType KeysrefInternalReceiptType { get { return keysrefInternalReceiptType; } set { keysrefInternalReceiptType = value; } }

		static KeyedSocialAndHealthInsurance keysSocialAndHealthInsurance;
		public static KeyedSocialAndHealthInsurance KeysSocialAndHealthInsurance { get { return keysSocialAndHealthInsurance; } set { keysSocialAndHealthInsurance = value; } }

		static KeyedASPNetToken keysASPNetToken;
		public static KeyedASPNetToken KeysASPNetToken { get { return keysASPNetToken; } set { keysASPNetToken = value; } }

		static KeyedMedRecOutline keysMedRecOutline;
		public static KeyedMedRecOutline KeysMedRecOutline { get { return keysMedRecOutline; } set { keysMedRecOutline = value; } }

		static KeyedAdmNoTemp keysAdmNoTemp;
		public static KeyedAdmNoTemp KeysAdmNoTemp { get { return keysAdmNoTemp; } set { keysAdmNoTemp = value; } }

		static KeyedASPNetUser keysASPNetUser;
		public static KeyedASPNetUser KeysASPNetUser { get { return keysASPNetUser; } set { keysASPNetUser = value; } }

		static KeyedMedRecTmp keysMedRecTmp;
		public static KeyedMedRecTmp KeysMedRecTmp { get { return keysMedRecTmp; } set { keysMedRecTmp = value; } }

		static KeyedMedicalServicePackage keysMedicalServicePackage;
		public static KeyedMedicalServicePackage KeysMedicalServicePackage { get { return keysMedicalServicePackage; } set { keysMedicalServicePackage = value; } }

		static KeyedrefItemType keysrefItemType;
		public static KeyedrefItemType KeysrefItemType { get { return keysrefItemType; } set { keysrefItemType = value; } }

		static KeyedPatientPVID keysPatientPVID;
		public static KeyedPatientPVID KeysPatientPVID { get { return keysPatientPVID; } set { keysPatientPVID = value; } }

		static KeyedMedSerInDept keysMedSerInDept;
		public static KeyedMedSerInDept KeysMedSerInDept { get { return keysMedSerInDept; } set { keysMedSerInDept = value; } }

		static KeyedrefJobTitle keysrefJobTitle;
		public static KeyedrefJobTitle KeysrefJobTitle { get { return keysrefJobTitle; } set { keysrefJobTitle = value; } }

		static KeyedMRParagraph keysMRParagraph;
		public static KeyedMRParagraph KeysMRParagraph { get { return keysMRParagraph; } set { keysMRParagraph = value; } }

		static KeyedrefLimVitalSign keysrefLimVitalSign;
		public static KeyedrefLimVitalSign KeysrefLimVitalSign { get { return keysrefLimVitalSign; } set { keysrefLimVitalSign = value; } }

		static KeyedWorkPlace keysWorkPlace;
		public static KeyedWorkPlace KeysWorkPlace { get { return keysWorkPlace; } set { keysWorkPlace = value; } }

		static KeyedGenericSocialNetwork keysGenericSocialNetwork;
		public static KeyedGenericSocialNetwork KeysGenericSocialNetwork { get { return keysGenericSocialNetwork; } set { keysGenericSocialNetwork = value; } }

		static KeyedMOHServiceItems keysMOHServiceItems;
		public static KeyedMOHServiceItems KeysMOHServiceItems { get { return keysMOHServiceItems; } set { keysMOHServiceItems = value; } }

		static KeyedrefEducationalLevel keysrefEducationalLevel;
		public static KeyedrefEducationalLevel KeysrefEducationalLevel { get { return keysrefEducationalLevel; } set { keysrefEducationalLevel = value; } }

		static KeyedASPNetUserClaims keysASPNetUserClaims;
		public static KeyedASPNetUserClaims KeysASPNetUserClaims { get { return keysASPNetUserClaims; } set { keysASPNetUserClaims = value; } }

		static KeyedAppliedMedStandard keysAppliedMedStandard;
		public static KeyedAppliedMedStandard KeysAppliedMedStandard { get { return keysAppliedMedStandard; } set { keysAppliedMedStandard = value; } }

		static KeyedASPNetUserLogin keysASPNetUserLogin;
		public static KeyedASPNetUserLogin KeysASPNetUserLogin { get { return keysASPNetUserLogin; } set { keysASPNetUserLogin = value; } }

		static KeyedArchitectureResources keysArchitectureResources;
		public static KeyedArchitectureResources KeysArchitectureResources { get { return keysArchitectureResources; } set { keysArchitectureResources = value; } }

		static KeyedPhysicalExamination keysPhysicalExamination;
		public static KeyedPhysicalExamination KeysPhysicalExamination { get { return keysPhysicalExamination; } set { keysPhysicalExamination = value; } }

		static KeyedMRSection keysMRSection;
		public static KeyedMRSection KeysMRSection { get { return keysMRSection; } set { keysMRSection = value; } }

		static KeyedPatientInvoices keysPatientInvoices;
		public static KeyedPatientInvoices KeysPatientInvoices { get { return keysPatientInvoices; } set { keysPatientInvoices = value; } }

		static KeyedAssignMedEquip keysAssignMedEquip;
		public static KeyedAssignMedEquip KeysAssignMedEquip { get { return keysAssignMedEquip; } set { keysAssignMedEquip = value; } }

		static KeyedrefDischargeDisposition keysrefDischargeDisposition;
		public static KeyedrefDischargeDisposition KeysrefDischargeDisposition { get { return keysrefDischargeDisposition; } set { keysrefDischargeDisposition = value; } }

		static KeyedASPNetUserRole keysASPNetUserRole;
		public static KeyedASPNetUserRole KeysASPNetUserRole { get { return keysASPNetUserRole; } set { keysASPNetUserRole = value; } }

		static KeyedMRSectionOutline keysMRSectionOutline;
		public static KeyedMRSectionOutline KeysMRSectionOutline { get { return keysMRSectionOutline; } set { keysMRSectionOutline = value; } }

		static KeyedSpecMedRecTmp keysSpecMedRecTmp;
		public static KeyedSpecMedRecTmp KeysSpecMedRecTmp { get { return keysSpecMedRecTmp; } set { keysSpecMedRecTmp = value; } }

		static KeyedHealthInsurance keysHealthInsurance;
		public static KeyedHealthInsurance KeysHealthInsurance { get { return keysHealthInsurance; } set { keysHealthInsurance = value; } }

		static KeyedPrescription keysPrescription;
		public static KeyedPrescription KeysPrescription { get { return keysPrescription; } set { keysPrescription = value; } }

		static KeyedPrivilegeRole keysPrivilegeRole;
		public static KeyedPrivilegeRole KeysPrivilegeRole { get { return keysPrivilegeRole; } set { keysPrivilegeRole = value; } }

		static KeyedAcPrincDrug keysAcPrincDrug;
		public static KeyedAcPrincDrug KeysAcPrincDrug { get { return keysAcPrincDrug; } set { keysAcPrincDrug = value; } }

		static KeyedInsuranceBeneficiary keysInsuranceBeneficiary;
		public static KeyedInsuranceBeneficiary KeysInsuranceBeneficiary { get { return keysInsuranceBeneficiary; } set { keysInsuranceBeneficiary = value; } }

		static KeyedAntagonistDrug keysAntagonistDrug;
		public static KeyedAntagonistDrug KeysAntagonistDrug { get { return keysAntagonistDrug; } set { keysAntagonistDrug = value; } }

		static KeyedPatientTransaction keysPatientTransaction;
		public static KeyedPatientTransaction KeysPatientTransaction { get { return keysPatientTransaction; } set { keysPatientTransaction = value; } }

		static KeyedBedInRoom keysBedInRoom;
		public static KeyedBedInRoom KeysBedInRoom { get { return keysBedInRoom; } set { keysBedInRoom = value; } }

		static KeyedRealms keysRealms;
		public static KeyedRealms KeysRealms { get { return keysRealms; } set { keysRealms = value; } }

		static KeyedrefPermission keysrefPermission;
		public static KeyedrefPermission KeysrefPermission { get { return keysrefPermission; } set { keysrefPermission = value; } }

		static KeyedInsuranceInterests keysInsuranceInterests;
		public static KeyedInsuranceInterests KeysInsuranceInterests { get { return keysInsuranceInterests; } set { keysInsuranceInterests = value; } }

		static KeyedEmployee keysEmployee;
		public static KeyedEmployee KeysEmployee { get { return keysEmployee; } set { keysEmployee = value; } }

		static KeyedContactDetails keysContactDetails;
		public static KeyedContactDetails KeysContactDetails { get { return keysContactDetails; } set { keysContactDetails = value; } }

		static KeyedInsuranceRegQueue keysInsuranceRegQueue;
		public static KeyedInsuranceRegQueue KeysInsuranceRegQueue { get { return keysInsuranceRegQueue; } set { keysInsuranceRegQueue = value; } }

		static KeyedrefMedcnAdminRoute keysrefMedcnAdminRoute;
		public static KeyedrefMedcnAdminRoute KeysrefMedcnAdminRoute { get { return keysrefMedcnAdminRoute; } set { keysrefMedcnAdminRoute = value; } }

		static KeyedServerLog keysServerLog;
		public static KeyedServerLog KeysServerLog { get { return keysServerLog; } set { keysServerLog = value; } }

		static KeyedrefMedcnVehicleForm keysrefMedcnVehicleForm;
		public static KeyedrefMedcnVehicleForm KeysrefMedcnVehicleForm { get { return keysrefMedcnVehicleForm; } set { keysrefMedcnVehicleForm = value; } }

		static KeyedContract keysContract;
		public static KeyedContract KeysContract { get { return keysContract; } set { keysContract = value; } }

		static KeyedPromotionPlan keysPromotionPlan;
		public static KeyedPromotionPlan KeysPromotionPlan { get { return keysPromotionPlan; } set { keysPromotionPlan = value; } }

		static KeyedrefMedEquipResourceType keysrefMedEquipResourceType;
		public static KeyedrefMedEquipResourceType KeysrefMedEquipResourceType { get { return keysrefMedEquipResourceType; } set { keysrefMedEquipResourceType = value; } }

		static KeyedContractChange keysContractChange;
		public static KeyedContractChange KeysContractChange { get { return keysContractChange; } set { keysContractChange = value; } }

		static KeyedSession keysSession;
		public static KeyedSession KeysSession { get { return keysSession; } set { keysSession = value; } }

		static KeyedPrescriptionDetail keysPrescriptionDetail;
		public static KeyedPrescriptionDetail KeysPrescriptionDetail { get { return keysPrescriptionDetail; } set { keysPrescriptionDetail = value; } }

		static KeyedClinicalTrial keysClinicalTrial;
		public static KeyedClinicalTrial KeysClinicalTrial { get { return keysClinicalTrial; } set { keysClinicalTrial = value; } }

		static KeyedrefLookup keysrefLookup;
		public static KeyedrefLookup KeysrefLookup { get { return keysrefLookup; } set { keysrefLookup = value; } }

		static KeyedPromotionService keysPromotionService;
		public static KeyedPromotionService KeysPromotionService { get { return keysPromotionService; } set { keysPromotionService = value; } }

		static KeyedContractDocument keysContractDocument;
		public static KeyedContractDocument KeysContractDocument { get { return keysContractDocument; } set { keysContractDocument = value; } }

		static KeyedNetworkGuestAccount keysNetworkGuestAccount;
		public static KeyedNetworkGuestAccount KeysNetworkGuestAccount { get { return keysNetworkGuestAccount; } set { keysNetworkGuestAccount = value; } }

		static KeyedQuotation keysQuotation;
		public static KeyedQuotation KeysQuotation { get { return keysQuotation; } set { keysQuotation = value; } }

		static KeyedrefMedHisIndex keysrefMedHisIndex;
		public static KeyedrefMedHisIndex KeysrefMedHisIndex { get { return keysrefMedHisIndex; } set { keysrefMedHisIndex = value; } }

		static KeyedClinicalTrialResult keysClinicalTrialResult;
		public static KeyedClinicalTrialResult KeysClinicalTrialResult { get { return keysClinicalTrialResult; } set { keysClinicalTrialResult = value; } }

		static KeyedDHCRoomBlock keysDHCRoomBlock;
		public static KeyedDHCRoomBlock KeysDHCRoomBlock { get { return keysDHCRoomBlock; } set { keysDHCRoomBlock = value; } }

		static KeyedrefMedicalCondition keysrefMedicalCondition;
		public static KeyedrefMedicalCondition KeysrefMedicalCondition { get { return keysrefMedicalCondition; } set { keysrefMedicalCondition = value; } }

		static KeyedDisposableMDResource keysDisposableMDResource;
		public static KeyedDisposableMDResource KeysDisposableMDResource { get { return keysDisposableMDResource; } set { keysDisposableMDResource = value; } }

		static KeyedOnlineQueue keysOnlineQueue;
		public static KeyedOnlineQueue KeysOnlineQueue { get { return keysOnlineQueue; } set { keysOnlineQueue = value; } }

		static KeyedrefMedicalServiceType keysrefMedicalServiceType;
		public static KeyedrefMedicalServiceType KeysrefMedicalServiceType { get { return keysrefMedicalServiceType; } set { keysrefMedicalServiceType = value; } }

		static KeyedDrug keysDrug;
		public static KeyedDrug KeysDrug { get { return keysDrug; } set { keysDrug = value; } }

		static KeyedRegistrationInfo keysRegistrationInfo;
		public static KeyedRegistrationInfo KeysRegistrationInfo { get { return keysRegistrationInfo; } set { keysRegistrationInfo = value; } }

		static KeyedrefQualification keysrefQualification;
		public static KeyedrefQualification KeysrefQualification { get { return keysrefQualification; } set { keysrefQualification = value; } }

		static KeyedPrescriptionHistory keysPrescriptionHistory;
		public static KeyedPrescriptionHistory KeysPrescriptionHistory { get { return keysPrescriptionHistory; } set { keysPrescriptionHistory = value; } }

		static KeyedrefPersGender keysrefPersGender;
		public static KeyedrefPersGender KeysrefPersGender { get { return keysrefPersGender; } set { keysrefPersGender = value; } }

		static KeyedPrivacyClass keysPrivacyClass;
		public static KeyedPrivacyClass KeysPrivacyClass { get { return keysPrivacyClass; } set { keysPrivacyClass = value; } }

		static KeyedResearchPartnership keysResearchPartnership;
		public static KeyedResearchPartnership KeysResearchPartnership { get { return keysResearchPartnership; } set { keysResearchPartnership = value; } }

		static KeyedPerson keysPerson;
		public static KeyedPerson KeysPerson { get { return keysPerson; } set { keysPerson = value; } }

		static KeyedPtCodeCheckDigitTmp keysPtCodeCheckDigitTmp;
		public static KeyedPtCodeCheckDigitTmp KeysPtCodeCheckDigitTmp { get { return keysPtCodeCheckDigitTmp; } set { keysPtCodeCheckDigitTmp = value; } }

		static KeyedBodyRegion keysBodyRegion;
		public static KeyedBodyRegion KeysBodyRegion { get { return keysBodyRegion; } set { keysBodyRegion = value; } }

		static KeyedRxHoldConsultation keysRxHoldConsultation;
		public static KeyedRxHoldConsultation KeysRxHoldConsultation { get { return keysRxHoldConsultation; } set { keysRxHoldConsultation = value; } }

		static KeyedRegQueue keysRegQueue;
		public static KeyedRegQueue KeysRegQueue { get { return keysRegQueue; } set { keysRegQueue = value; } }

		static KeyedEquipHistory keysEquipHistory;
		public static KeyedEquipHistory KeysEquipHistory { get { return keysEquipHistory; } set { keysEquipHistory = value; } }

		static KeyedClinicalIndicatorType keysClinicalIndicatorType;
		public static KeyedClinicalIndicatorType KeysClinicalIndicatorType { get { return keysClinicalIndicatorType; } set { keysClinicalIndicatorType = value; } }

		static KeyedExamMaintenanceHistory keysExamMaintenanceHistory;
		public static KeyedExamMaintenanceHistory KeysExamMaintenanceHistory { get { return keysExamMaintenanceHistory; } set { keysExamMaintenanceHistory = value; } }

		static KeyedUserGroup keysUserGroup;
		public static KeyedUserGroup KeysUserGroup { get { return keysUserGroup; } set { keysUserGroup = value; } }

		static KeyedMedicalDiagnosticMethod keysMedicalDiagnosticMethod;
		public static KeyedMedicalDiagnosticMethod KeysMedicalDiagnosticMethod { get { return keysMedicalDiagnosticMethod; } set { keysMedicalDiagnosticMethod = value; } }

		static KeyedDrugConfign keysDrugConfign;
		public static KeyedDrugConfign KeysDrugConfign { get { return keysDrugConfign; } set { keysDrugConfign = value; } }

		static KeyedSymptomIndicator keysSymptomIndicator;
		public static KeyedSymptomIndicator KeysSymptomIndicator { get { return keysSymptomIndicator; } set { keysSymptomIndicator = value; } }

		static KeyedUsersInGroup keysUsersInGroup;
		public static KeyedUsersInGroup KeysUsersInGroup { get { return keysUsersInGroup; } set { keysUsersInGroup = value; } }

		static KeyedMedicalTestProcedure keysMedicalTestProcedure;
		public static KeyedMedicalTestProcedure KeysMedicalTestProcedure { get { return keysMedicalTestProcedure; } set { keysMedicalTestProcedure = value; } }

		static KeyedAdvancedSpecialist keysAdvancedSpecialist;
		public static KeyedAdvancedSpecialist KeysAdvancedSpecialist { get { return keysAdvancedSpecialist; } set { keysAdvancedSpecialist = value; } }

		static KeyedReminderNotices keysReminderNotices;
		public static KeyedReminderNotices KeysReminderNotices { get { return keysReminderNotices; } set { keysReminderNotices = value; } }

		static KeyedForeignExchange keysForeignExchange;
		public static KeyedForeignExchange KeysForeignExchange { get { return keysForeignExchange; } set { keysForeignExchange = value; } }

		static KeyedDrugInDepartment keysDrugInDepartment;
		public static KeyedDrugInDepartment KeysDrugInDepartment { get { return keysDrugInDepartment; } set { keysDrugInDepartment = value; } }

		static KeyedHosRanking keysHosRanking;
		public static KeyedHosRanking KeysHosRanking { get { return keysHosRanking; } set { keysHosRanking = value; } }

		static KeyedAllergyIntolerance keysAllergyIntolerance;
		public static KeyedAllergyIntolerance KeysAllergyIntolerance { get { return keysAllergyIntolerance; } set { keysAllergyIntolerance = value; } }

		static KeyedEduLevel keysEduLevel;
		public static KeyedEduLevel KeysEduLevel { get { return keysEduLevel; } set { keysEduLevel = value; } }

		static KeyedrefRole keysrefRole;
		public static KeyedrefRole KeysrefRole { get { return keysrefRole; } set { keysrefRole = value; } }

		static KeyedMedicalServiceItem keysMedicalServiceItem;
		public static KeyedMedicalServiceItem KeysMedicalServiceItem { get { return keysMedicalServiceItem; } set { keysMedicalServiceItem = value; } }

		static KeyedApplication keysApplication;
		public static KeyedApplication KeysApplication { get { return keysApplication; } set { keysApplication = value; } }

		static KeyedDrugPrice keysDrugPrice;
		public static KeyedDrugPrice KeysDrugPrice { get { return keysDrugPrice; } set { keysDrugPrice = value; } }

		static KeyedrefShelfDrugLocation keysrefShelfDrugLocation;
		public static KeyedrefShelfDrugLocation KeysrefShelfDrugLocation { get { return keysrefShelfDrugLocation; } set { keysrefShelfDrugLocation = value; } }

		static KeyedHCProvider keysHCProvider;
		public static KeyedHCProvider KeysHCProvider { get { return keysHCProvider; } set { keysHCProvider = value; } }

		static KeyedMedImagingRepository keysMedImagingRepository;
		public static KeyedMedImagingRepository KeysMedImagingRepository { get { return keysMedImagingRepository; } set { keysMedImagingRepository = value; } }

		static KeyedMedImagingTest keysMedImagingTest;
		public static KeyedMedImagingTest KeysMedImagingTest { get { return keysMedImagingTest; } set { keysMedImagingTest = value; } }

		static KeyedDeathSituationInfo keysDeathSituationInfo;
		public static KeyedDeathSituationInfo KeysDeathSituationInfo { get { return keysDeathSituationInfo; } set { keysDeathSituationInfo = value; } }

		static KeyedrefShift keysrefShift;
		public static KeyedrefShift KeysrefShift { get { return keysrefShift; } set { keysrefShift = value; } }

		static KeyedUserAccount keysUserAccount;
		public static KeyedUserAccount KeysUserAccount { get { return keysUserAccount; } set { keysUserAccount = value; } }

		static KeyedMedImagingTestItems keysMedImagingTestItems;
		public static KeyedMedImagingTestItems KeysMedImagingTestItems { get { return keysMedImagingTestItems; } set { keysMedImagingTestItems = value; } }

		static KeyedInOutType keysInOutType;
		public static KeyedInOutType KeysInOutType { get { return keysInOutType; } set { keysInOutType = value; } }

		static KeyedInOutwardDrug keysInOutwardDrug;
		public static KeyedInOutwardDrug KeysInOutwardDrug { get { return keysInOutwardDrug; } set { keysInOutwardDrug = value; } }

		static KeyedMedLabRepository keysMedLabRepository;
		public static KeyedMedLabRepository KeysMedLabRepository { get { return keysMedLabRepository; } set { keysMedLabRepository = value; } }

		static KeyedInputMaskSetting keysInputMaskSetting;
		public static KeyedInputMaskSetting KeysInputMaskSetting { get { return keysInputMaskSetting; } set { keysInputMaskSetting = value; } }

		static KeyedrefSIPrefix keysrefSIPrefix;
		public static KeyedrefSIPrefix KeysrefSIPrefix { get { return keysrefSIPrefix; } set { keysrefSIPrefix = value; } }

		static KeyedMesrtConv keysMesrtConv;
		public static KeyedMesrtConv KeysMesrtConv { get { return keysMesrtConv; } set { keysMesrtConv = value; } }

		static KeyedLotNumber keysLotNumber;
		public static KeyedLotNumber KeysLotNumber { get { return keysLotNumber; } set { keysLotNumber = value; } }

		static KeyedFamilyHistory keysFamilyHistory;
		public static KeyedFamilyHistory KeysFamilyHistory { get { return keysFamilyHistory; } set { keysFamilyHistory = value; } }

		static KeyedMedLabTest keysMedLabTest;
		public static KeyedMedLabTest KeysMedLabTest { get { return keysMedLabTest; } set { keysMedLabTest = value; } }

		static KeyedrefSocialHisSeverity keysrefSocialHisSeverity;
		public static KeyedrefSocialHisSeverity KeysrefSocialHisSeverity { get { return keysrefSocialHisSeverity; } set { keysrefSocialHisSeverity = value; } }

		static KeyedrefSpecimenType keysrefSpecimenType;
		public static KeyedrefSpecimenType KeysrefSpecimenType { get { return keysrefSpecimenType; } set { keysrefSpecimenType = value; } }

		static KeyedEmployeer keysEmployeer;
		public static KeyedEmployeer KeysEmployeer { get { return keysEmployeer; } set { keysEmployeer = value; } }

		static KeyedHCStakeholder keysHCStakeholder;
		public static KeyedHCStakeholder KeysHCStakeholder { get { return keysHCStakeholder; } set { keysHCStakeholder = value; } }

		static KeyedPharmaceuticalCompany keysPharmaceuticalCompany;
		public static KeyedPharmaceuticalCompany KeysPharmaceuticalCompany { get { return keysPharmaceuticalCompany; } set { keysPharmaceuticalCompany = value; } }

		static KeyedrefStoreHouse keysrefStoreHouse;
		public static KeyedrefStoreHouse KeysrefStoreHouse { get { return keysrefStoreHouse; } set { keysrefStoreHouse = value; } }

		static KeyedHIAdmission keysHIAdmission;
		public static KeyedHIAdmission KeysHIAdmission { get { return keysHIAdmission; } set { keysHIAdmission = value; } }

		static KeyedHCRoomBlock keysHCRoomBlock;
		public static KeyedHCRoomBlock KeysHCRoomBlock { get { return keysHCRoomBlock; } set { keysHCRoomBlock = value; } }

		static KeyedrefAcademicTile keysrefAcademicTile;
		public static KeyedrefAcademicTile KeysrefAcademicTile { get { return keysrefAcademicTile; } set { keysrefAcademicTile = value; } }

		static KeyedJobHistory keysJobHistory;
		public static KeyedJobHistory KeysJobHistory { get { return keysJobHistory; } set { keysJobHistory = value; } }

		static KeyedPriceList keysPriceList;
		public static KeyedPriceList KeysPriceList { get { return keysPriceList; } set { keysPriceList = value; } }

		static KeyedHospitalizationHistory keysHospitalizationHistory;
		public static KeyedHospitalizationHistory KeysHospitalizationHistory { get { return keysHospitalizationHistory; } set { keysHospitalizationHistory = value; } }

		static KeyedrefFAMRelationship keysrefFAMRelationship;
		public static KeyedrefFAMRelationship KeysrefFAMRelationship { get { return keysrefFAMRelationship; } set { keysrefFAMRelationship = value; } }

		static KeyedrefTimeFrame keysrefTimeFrame;
		public static KeyedrefTimeFrame KeysrefTimeFrame { get { return keysrefTimeFrame; } set { keysrefTimeFrame = value; } }

		static KeyedHospitalSpecialist keysHospitalSpecialist;
		public static KeyedHospitalSpecialist KeysHospitalSpecialist { get { return keysHospitalSpecialist; } set { keysHospitalSpecialist = value; } }

		static KeyedrefActiviePrinciple keysrefActiviePrinciple;
		public static KeyedrefActiviePrinciple KeysrefActiviePrinciple { get { return keysrefActiviePrinciple; } set { keysrefActiviePrinciple = value; } }

		static KeyedrefAdmissionType keysrefAdmissionType;
		public static KeyedrefAdmissionType KeysrefAdmissionType { get { return keysrefAdmissionType; } set { keysrefAdmissionType = value; } }

		static KeyedMedicalEquimentsResources keysMedicalEquimentsResources;
		public static KeyedMedicalEquimentsResources KeysMedicalEquimentsResources { get { return keysMedicalEquimentsResources; } set { keysMedicalEquimentsResources = value; } }

		static KeyedrefAdmReferralType keysrefAdmReferralType;
		public static KeyedrefAdmReferralType KeysrefAdmReferralType { get { return keysrefAdmReferralType; } set { keysrefAdmReferralType = value; } }

		static KeyedProvidableDrugs keysProvidableDrugs;
		public static KeyedProvidableDrugs KeysProvidableDrugs { get { return keysProvidableDrugs; } set { keysProvidableDrugs = value; } }

		static KeyedrefAllergyCategory keysrefAllergyCategory;
		public static KeyedrefAllergyCategory KeysrefAllergyCategory { get { return keysrefAllergyCategory; } set { keysrefAllergyCategory = value; } }

		static KeyedrefTransactionType keysrefTransactionType;
		public static KeyedrefTransactionType KeysrefTransactionType { get { return keysrefTransactionType; } set { keysrefTransactionType = value; } }

		static KeyedJobModel keysJobModel;
		public static KeyedJobModel KeysJobModel { get { return keysJobModel; } set { keysJobModel = value; } }

		static KeyedAssignmentSchedule keysAssignmentSchedule;
		public static KeyedAssignmentSchedule KeysAssignmentSchedule { get { return keysAssignmentSchedule; } set { keysAssignmentSchedule = value; } }

		static KeyedrefOccupation keysrefOccupation;
		public static KeyedrefOccupation KeysrefOccupation { get { return keysrefOccupation; } set { keysrefOccupation = value; } }

		static KeyedBusySchedule keysBusySchedule;
		public static KeyedBusySchedule KeysBusySchedule { get { return keysBusySchedule; } set { keysBusySchedule = value; } }

		//static KeyedAdmNoTempHolding keysAdmNoTempHolding;
		//public static KeyedAdmNoTempHolding KeysAdmNoTempHolding { get { return keysAdmNoTempHolding; } set { keysAdmNoTempHolding = value; } }

		static KeyedrefTypeAbsent keysrefTypeAbsent;
		public static KeyedrefTypeAbsent KeysrefTypeAbsent { get { return keysrefTypeAbsent; } set { keysrefTypeAbsent = value; } }

		static KeyedrefAllergyIndex keysrefAllergyIndex;
		public static KeyedrefAllergyIndex KeysrefAllergyIndex { get { return keysrefAllergyIndex; } set { keysrefAllergyIndex = value; } }

		static KeyedLanguageLevel keysLanguageLevel;
		public static KeyedLanguageLevel KeysLanguageLevel { get { return keysLanguageLevel; } set { keysLanguageLevel = value; } }

		static KeyedrefPersMaritalStatus keysrefPersMaritalStatus;
		public static KeyedrefPersMaritalStatus KeysrefPersMaritalStatus { get { return keysrefPersMaritalStatus; } set { keysrefPersMaritalStatus = value; } }

		static KeyedOrganization keysOrganization;
		public static KeyedOrganization KeysOrganization { get { return keysOrganization; } set { keysOrganization = value; } }

		static KeyedEmpAllocation keysEmpAllocation;
		public static KeyedEmpAllocation KeysEmpAllocation { get { return keysEmpAllocation; } set { keysEmpAllocation = value; } }

		static KeyedNextOfKins keysNextOfKins;
		public static KeyedNextOfKins KeysNextOfKins { get { return keysNextOfKins; } set { keysNextOfKins = value; } }

		static KeyedHospitalizationHistoryDetails keysHospitalizationHistoryDetails;
		public static KeyedHospitalizationHistoryDetails KeysHospitalizationHistoryDetails { get { return keysHospitalizationHistoryDetails; } set { keysHospitalizationHistoryDetails = value; } }

		static KeyedrefCareerMOH keysrefCareerMOH;
		public static KeyedrefCareerMOH KeysrefCareerMOH { get { return keysrefCareerMOH; } set { keysrefCareerMOH = value; } }

		static KeyedrefAnnTemp keysrefAnnTemp;
		public static KeyedrefAnnTemp KeysrefAnnTemp { get { return keysrefAnnTemp; } set { keysrefAnnTemp = value; } }

		static KeyedPatientBed keysPatientBed;
		public static KeyedPatientBed KeysPatientBed { get { return keysPatientBed; } set { keysPatientBed = value; } }

		static KeyedImmunizationHistory keysImmunizationHistory;
		public static KeyedImmunizationHistory KeysImmunizationHistory { get { return keysImmunizationHistory; } set { keysImmunizationHistory = value; } }

		static KeyedrefAppConfig keysrefAppConfig;
		public static KeyedrefAppConfig KeysrefAppConfig { get { return keysrefAppConfig; } set { keysrefAppConfig = value; } }

		static KeyedEmployeeAnnualLeave keysEmployeeAnnualLeave;
		public static KeyedEmployeeAnnualLeave KeysEmployeeAnnualLeave { get { return keysEmployeeAnnualLeave; } set { keysEmployeeAnnualLeave = value; } }

		static KeyedrefWard keysrefWard;
		public static KeyedrefWard KeysrefWard { get { return keysrefWard; } set { keysrefWard = value; } }

		static KeyedPatientBedFeatures keysPatientBedFeatures;
		public static KeyedPatientBedFeatures KeysPatientBedFeatures { get { return keysPatientBedFeatures; } set { keysPatientBedFeatures = value; } }

		static KeyedrefBloodType keysrefBloodType;
		public static KeyedrefBloodType KeysrefBloodType { get { return keysrefBloodType; } set { keysrefBloodType = value; } }

		static KeyedPatientInBedRoom keysPatientInBedRoom;
		public static KeyedPatientInBedRoom KeysPatientInBedRoom { get { return keysPatientInBedRoom; } set { keysPatientInBedRoom = value; } }

		static KeyedMedLabTestItems keysMedLabTestItems;
		public static KeyedMedLabTestItems KeysMedLabTestItems { get { return keysMedLabTestItems; } set { keysMedLabTestItems = value; } }

		static KeyedScheduleDoingTaskLog keysScheduleDoingTaskLog;
		public static KeyedScheduleDoingTaskLog KeysScheduleDoingTaskLog { get { return keysScheduleDoingTaskLog; } set { keysScheduleDoingTaskLog = value; } }

		static KeyedrefProviderType keysrefProviderType;
		public static KeyedrefProviderType KeysrefProviderType { get { return keysrefProviderType; } set { keysrefProviderType = value; } }

		static KeyedBloodbank keysBloodbank;
		public static KeyedBloodbank KeysBloodbank { get { return keysBloodbank; } set { keysBloodbank = value; } }

		static KeyedOccCareerMOH keysOccCareerMOH;
		public static KeyedOccCareerMOH KeysOccCareerMOH { get { return keysOccCareerMOH; } set { keysOccCareerMOH = value; } }

		static KeyedEmployeeLeaveTaken keysEmployeeLeaveTaken;
		public static KeyedEmployeeLeaveTaken KeysEmployeeLeaveTaken { get { return keysEmployeeLeaveTaken; } set { keysEmployeeLeaveTaken = value; } }

		static KeyedResource keysResource;
		public static KeyedResource KeysResource { get { return keysResource; } set { keysResource = value; } }

		#endregion
		public static event RecordChangedEventHandler OnRecordChanged;
		static bool isRunSyncDB = false;

        static Microsoft.AspNet.SignalR.IHubContext lvHub
        {
            get { return Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<LVRecordInfoHub>(); }
        }

        public static void RunSyncDB() 
        {
			if(isRunSyncDB) return;
            LV.Core.DAL.EntityFramework.DBTracker.OnDBSavechanged += DBTracker_OnDBSavechanged;
			isRunSyncDB = true;
        }

        static void DBTracker_OnDBSavechanged(object sender, List<Core.DAL.EntityFramework.DBChangeTrackerInfo> listDBChanged)
        {
            try
            {
                OnSaveChanged(listDBChanged);
            }
            catch (Exception ex) {
                LVUtility.WriteLogFile("[LVHubsHelper.DBTracker_OnDBSavechanged]" + ex.Message);
            }
        }

        public static void OnSaveChanged(List<LV.Core.DAL.EntityFramework.DBChangeTrackerInfo> entries)
        {
            foreach (LV.Core.DAL.EntityFramework.DBChangeTrackerInfo db in entries) 
            {
                if (db.Entity == null) continue;
                string tblName = db.Entity.GetType().Name;
                switch (tblName) { 
                     
	                case "MedEnctrDiagnosis":
	                    MedEnctrDiagnosis _MedEnctrDiagnosis = (MedEnctrDiagnosis)db.Entity;
	                    if (keysMedEnctrDiagnosis != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedEnctrDiagnosis.Add(_MedEnctrDiagnosis);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedEnctrDiagnosis.ChangeItem(_MedEnctrDiagnosis.Key, _MedEnctrDiagnosis) == false)
										keysMedEnctrDiagnosis.Add(_MedEnctrDiagnosis);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedEnctrDiagnosis.Contains(_MedEnctrDiagnosis.Key))
										keysMedEnctrDiagnosis.Remove(_MedEnctrDiagnosis.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedEnctrDiagnosis.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedEnctrDiagnosis.Key)); }
	                   break;

	                case "ParaClinicalExamGroup":
	                    ParaClinicalExamGroup _ParaClinicalExamGroup = (ParaClinicalExamGroup)db.Entity;
	                    if (keysParaClinicalExamGroup != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysParaClinicalExamGroup.Add(_ParaClinicalExamGroup);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysParaClinicalExamGroup.ChangeItem(_ParaClinicalExamGroup.Key, _ParaClinicalExamGroup) == false)
										keysParaClinicalExamGroup.Add(_ParaClinicalExamGroup);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysParaClinicalExamGroup.Contains(_ParaClinicalExamGroup.Key))
										keysParaClinicalExamGroup.Remove(_ParaClinicalExamGroup.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ParaClinicalExamGroup.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ParaClinicalExamGroup.Key)); }
	                   break;

	                case "BloodDonation":
	                    BloodDonation _BloodDonation = (BloodDonation)db.Entity;
	                    if (keysBloodDonation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysBloodDonation.Add(_BloodDonation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysBloodDonation.ChangeItem(_BloodDonation.Key, _BloodDonation) == false)
										keysBloodDonation.Add(_BloodDonation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysBloodDonation.Contains(_BloodDonation.Key))
										keysBloodDonation.Remove(_BloodDonation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _BloodDonation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _BloodDonation.Key)); }
	                   break;

	                case "EmpWorkSchedule":
	                    EmpWorkSchedule _EmpWorkSchedule = (EmpWorkSchedule)db.Entity;
	                    if (keysEmpWorkSchedule != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEmpWorkSchedule.Add(_EmpWorkSchedule);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEmpWorkSchedule.ChangeItem(_EmpWorkSchedule.Key, _EmpWorkSchedule) == false)
										keysEmpWorkSchedule.Add(_EmpWorkSchedule);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEmpWorkSchedule.Contains(_EmpWorkSchedule.Key))
										keysEmpWorkSchedule.Remove(_EmpWorkSchedule.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EmpWorkSchedule.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EmpWorkSchedule.Key)); }
	                   break;

	                case "MedicalClaimService":
	                    MedicalClaimService _MedicalClaimService = (MedicalClaimService)db.Entity;
	                    if (keysMedicalClaimService != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalClaimService.Add(_MedicalClaimService);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalClaimService.ChangeItem(_MedicalClaimService.Key, _MedicalClaimService) == false)
										keysMedicalClaimService.Add(_MedicalClaimService);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalClaimService.Contains(_MedicalClaimService.Key))
										keysMedicalClaimService.Remove(_MedicalClaimService.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalClaimService.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalClaimService.Key)); }
	                   break;

	                case "ParaClinicalReq":
	                    ParaClinicalReq _ParaClinicalReq = (ParaClinicalReq)db.Entity;
	                    if (keysParaClinicalReq != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysParaClinicalReq.Add(_ParaClinicalReq);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysParaClinicalReq.ChangeItem(_ParaClinicalReq.Key, _ParaClinicalReq) == false)
										keysParaClinicalReq.Add(_ParaClinicalReq);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysParaClinicalReq.Contains(_ParaClinicalReq.Key))
										keysParaClinicalReq.Remove(_ParaClinicalReq.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ParaClinicalReq.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ParaClinicalReq.Key)); }
	                   break;

	                case "Donor":
	                    Donor _Donor = (Donor)db.Entity;
	                    if (keysDonor != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDonor.Add(_Donor);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDonor.ChangeItem(_Donor.Key, _Donor) == false)
										keysDonor.Add(_Donor);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDonor.Contains(_Donor.Key))
										keysDonor.Remove(_Donor.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Donor.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Donor.Key)); }
	                   break;

	                case "ResourceLog":
	                    ResourceLog _ResourceLog = (ResourceLog)db.Entity;
	                    if (keysResourceLog != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysResourceLog.Add(_ResourceLog);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysResourceLog.ChangeItem(_ResourceLog.Key, _ResourceLog) == false)
										keysResourceLog.Add(_ResourceLog);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysResourceLog.Contains(_ResourceLog.Key))
										keysResourceLog.Remove(_ResourceLog.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ResourceLog.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ResourceLog.Key)); }
	                   break;

	                case "refCertification":
	                    refCertification _refCertification = (refCertification)db.Entity;
	                    if (keysrefCertification != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefCertification.Add(_refCertification);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefCertification.ChangeItem(_refCertification.Key, _refCertification) == false)
										keysrefCertification.Add(_refCertification);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefCertification.Contains(_refCertification.Key))
										keysrefCertification.Remove(_refCertification.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refCertification.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refCertification.Key)); }
	                   break;

	                case "MedicalConditionRecord":
	                    MedicalConditionRecord _MedicalConditionRecord = (MedicalConditionRecord)db.Entity;
	                    if (keysMedicalConditionRecord != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalConditionRecord.Add(_MedicalConditionRecord);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalConditionRecord.ChangeItem(_MedicalConditionRecord.Key, _MedicalConditionRecord) == false)
										keysMedicalConditionRecord.Add(_MedicalConditionRecord);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalConditionRecord.Contains(_MedicalConditionRecord.Key))
										keysMedicalConditionRecord.Remove(_MedicalConditionRecord.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalConditionRecord.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalConditionRecord.Key)); }
	                   break;

	                case "PatientVitalSign":
	                    PatientVitalSign _PatientVitalSign = (PatientVitalSign)db.Entity;
	                    if (keysPatientVitalSign != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientVitalSign.Add(_PatientVitalSign);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientVitalSign.ChangeItem(_PatientVitalSign.Key, _PatientVitalSign) == false)
										keysPatientVitalSign.Add(_PatientVitalSign);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientVitalSign.Contains(_PatientVitalSign.Key))
										keysPatientVitalSign.Remove(_PatientVitalSign.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientVitalSign.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientVitalSign.Key)); }
	                   break;

	                case "DonorMedicalConditions":
	                    DonorMedicalConditions _DonorMedicalConditions = (DonorMedicalConditions)db.Entity;
	                    if (keysDonorMedicalConditions != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDonorMedicalConditions.Add(_DonorMedicalConditions);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDonorMedicalConditions.ChangeItem(_DonorMedicalConditions.Key, _DonorMedicalConditions) == false)
										keysDonorMedicalConditions.Add(_DonorMedicalConditions);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDonorMedicalConditions.Contains(_DonorMedicalConditions.Key))
										keysDonorMedicalConditions.Remove(_DonorMedicalConditions.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DonorMedicalConditions.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DonorMedicalConditions.Key)); }
	                   break;

	                case "InsuranceCompany":
	                    InsuranceCompany _InsuranceCompany = (InsuranceCompany)db.Entity;
	                    if (keysInsuranceCompany != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysInsuranceCompany.Add(_InsuranceCompany);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysInsuranceCompany.ChangeItem(_InsuranceCompany.Key, _InsuranceCompany) == false)
										keysInsuranceCompany.Add(_InsuranceCompany);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysInsuranceCompany.Contains(_InsuranceCompany.Key))
										keysInsuranceCompany.Remove(_InsuranceCompany.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _InsuranceCompany.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _InsuranceCompany.Key)); }
	                   break;

	                case "refCityProvince":
	                    refCityProvince _refCityProvince = (refCityProvince)db.Entity;
	                    if (keysrefCityProvince != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefCityProvince.Add(_refCityProvince);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefCityProvince.ChangeItem(_refCityProvince.Key, _refCityProvince) == false)
										keysrefCityProvince.Add(_refCityProvince);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefCityProvince.Contains(_refCityProvince.Key))
										keysrefCityProvince.Remove(_refCityProvince.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refCityProvince.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refCityProvince.Key)); }
	                   break;

	                case "DonorMedication":
	                    DonorMedication _DonorMedication = (DonorMedication)db.Entity;
	                    if (keysDonorMedication != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDonorMedication.Add(_DonorMedication);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDonorMedication.ChangeItem(_DonorMedication.Key, _DonorMedication) == false)
										keysDonorMedication.Add(_DonorMedication);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDonorMedication.Contains(_DonorMedication.Key))
										keysDonorMedication.Remove(_DonorMedication.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DonorMedication.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DonorMedication.Key)); }
	                   break;

	                case "EventHoliday":
	                    EventHoliday _EventHoliday = (EventHoliday)db.Entity;
	                    if (keysEventHoliday != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEventHoliday.Add(_EventHoliday);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEventHoliday.ChangeItem(_EventHoliday.Key, _EventHoliday) == false)
										keysEventHoliday.Add(_EventHoliday);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEventHoliday.Contains(_EventHoliday.Key))
										keysEventHoliday.Remove(_EventHoliday.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EventHoliday.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EventHoliday.Key)); }
	                   break;

	                case "RoomAllocation":
	                    RoomAllocation _RoomAllocation = (RoomAllocation)db.Entity;
	                    if (keysRoomAllocation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysRoomAllocation.Add(_RoomAllocation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysRoomAllocation.ChangeItem(_RoomAllocation.Key, _RoomAllocation) == false)
										keysRoomAllocation.Add(_RoomAllocation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysRoomAllocation.Contains(_RoomAllocation.Key))
										keysRoomAllocation.Remove(_RoomAllocation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _RoomAllocation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _RoomAllocation.Key)); }
	                   break;

	                case "refCLMeasurement":
	                    refCLMeasurement _refCLMeasurement = (refCLMeasurement)db.Entity;
	                    if (keysrefCLMeasurement != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefCLMeasurement.Add(_refCLMeasurement);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefCLMeasurement.ChangeItem(_refCLMeasurement.Key, _refCLMeasurement) == false)
										keysrefCLMeasurement.Add(_refCLMeasurement);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefCLMeasurement.Contains(_refCLMeasurement.Key))
										keysrefCLMeasurement.Remove(_refCLMeasurement.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refCLMeasurement.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refCLMeasurement.Key)); }
	                   break;

	                case "MedicalEncounter":
	                    MedicalEncounter _MedicalEncounter = (MedicalEncounter)db.Entity;
	                    if (keysMedicalEncounter != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalEncounter.Add(_MedicalEncounter);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalEncounter.ChangeItem(_MedicalEncounter.Key, _MedicalEncounter) == false)
										keysMedicalEncounter.Add(_MedicalEncounter);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalEncounter.Contains(_MedicalEncounter.Key))
										keysMedicalEncounter.Remove(_MedicalEncounter.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalEncounter.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalEncounter.Key)); }
	                   break;

	                case "SeparationOfBlood":
	                    SeparationOfBlood _SeparationOfBlood = (SeparationOfBlood)db.Entity;
	                    if (keysSeparationOfBlood != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysSeparationOfBlood.Add(_SeparationOfBlood);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysSeparationOfBlood.ChangeItem(_SeparationOfBlood.Key, _SeparationOfBlood) == false)
										keysSeparationOfBlood.Add(_SeparationOfBlood);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysSeparationOfBlood.Contains(_SeparationOfBlood.Key))
										keysSeparationOfBlood.Remove(_SeparationOfBlood.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _SeparationOfBlood.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _SeparationOfBlood.Key)); }
	                   break;

	                case "MedicationHistory":
	                    MedicationHistory _MedicationHistory = (MedicationHistory)db.Entity;
	                    if (keysMedicationHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicationHistory.Add(_MedicationHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicationHistory.ChangeItem(_MedicationHistory.Key, _MedicationHistory) == false)
										keysMedicationHistory.Add(_MedicationHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicationHistory.Contains(_MedicationHistory.Key))
										keysMedicationHistory.Remove(_MedicationHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicationHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicationHistory.Key)); }
	                   break;

	                case "TestBlood":
	                    TestBlood _TestBlood = (TestBlood)db.Entity;
	                    if (keysTestBlood != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysTestBlood.Add(_TestBlood);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysTestBlood.ChangeItem(_TestBlood.Key, _TestBlood) == false)
										keysTestBlood.Add(_TestBlood);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysTestBlood.Contains(_TestBlood.Key))
										keysTestBlood.Remove(_TestBlood.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _TestBlood.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _TestBlood.Key)); }
	                   break;

	                case "StdKSection":
	                    StdKSection _StdKSection = (StdKSection)db.Entity;
	                    if (keysStdKSection != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysStdKSection.Add(_StdKSection);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysStdKSection.ChangeItem(_StdKSection.Key, _StdKSection) == false)
										keysStdKSection.Add(_StdKSection);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysStdKSection.Contains(_StdKSection.Key))
										keysStdKSection.Remove(_StdKSection.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _StdKSection.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _StdKSection.Key)); }
	                   break;

	                case "refVitalSign":
	                    refVitalSign _refVitalSign = (refVitalSign)db.Entity;
	                    if (keysrefVitalSign != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefVitalSign.Add(_refVitalSign);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefVitalSign.ChangeItem(_refVitalSign.Key, _refVitalSign) == false)
										keysrefVitalSign.Add(_refVitalSign);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefVitalSign.Contains(_refVitalSign.Key))
										keysrefVitalSign.Remove(_refVitalSign.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refVitalSign.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refVitalSign.Key)); }
	                   break;

	                case "refCommonTerm":
	                    refCommonTerm _refCommonTerm = (refCommonTerm)db.Entity;
	                    if (keysrefCommonTerm != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefCommonTerm.Add(_refCommonTerm);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefCommonTerm.ChangeItem(_refCommonTerm.Key, _refCommonTerm) == false)
										keysrefCommonTerm.Add(_refCommonTerm);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefCommonTerm.Contains(_refCommonTerm.Key))
										keysrefCommonTerm.Remove(_refCommonTerm.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refCommonTerm.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refCommonTerm.Key)); }
	                   break;

	                case "Operations":
	                    Operations _Operations = (Operations)db.Entity;
	                    if (keysOperations != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysOperations.Add(_Operations);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysOperations.ChangeItem(_Operations.Key, _Operations) == false)
										keysOperations.Add(_Operations);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysOperations.Contains(_Operations.Key))
										keysOperations.Remove(_Operations.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Operations.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Operations.Key)); }
	                   break;

	                case "MiscDocuments":
	                    MiscDocuments _MiscDocuments = (MiscDocuments)db.Entity;
	                    if (keysMiscDocuments != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMiscDocuments.Add(_MiscDocuments);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMiscDocuments.ChangeItem(_MiscDocuments.Key, _MiscDocuments) == false)
										keysMiscDocuments.Add(_MiscDocuments);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMiscDocuments.Contains(_MiscDocuments.Key))
										keysMiscDocuments.Remove(_MiscDocuments.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MiscDocuments.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MiscDocuments.Key)); }
	                   break;

	                case "AttachedDoc":
	                    AttachedDoc _AttachedDoc = (AttachedDoc)db.Entity;
	                    if (keysAttachedDoc != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAttachedDoc.Add(_AttachedDoc);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAttachedDoc.ChangeItem(_AttachedDoc.Key, _AttachedDoc) == false)
										keysAttachedDoc.Add(_AttachedDoc);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAttachedDoc.Contains(_AttachedDoc.Key))
										keysAttachedDoc.Remove(_AttachedDoc.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AttachedDoc.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AttachedDoc.Key)); }
	                   break;

	                case "Supplier":
	                    Supplier _Supplier = (Supplier)db.Entity;
	                    if (keysSupplier != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysSupplier.Add(_Supplier);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysSupplier.ChangeItem(_Supplier.Key, _Supplier) == false)
										keysSupplier.Add(_Supplier);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysSupplier.Contains(_Supplier.Key))
										keysSupplier.Remove(_Supplier.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Supplier.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Supplier.Key)); }
	                   break;

	                case "refReligion":
	                    refReligion _refReligion = (refReligion)db.Entity;
	                    if (keysrefReligion != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefReligion.Add(_refReligion);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefReligion.ChangeItem(_refReligion.Key, _refReligion) == false)
										keysrefReligion.Add(_refReligion);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefReligion.Contains(_refReligion.Key))
										keysrefReligion.Remove(_refReligion.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refReligion.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refReligion.Key)); }
	                   break;

	                case "OperationSchedule":
	                    OperationSchedule _OperationSchedule = (OperationSchedule)db.Entity;
	                    if (keysOperationSchedule != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysOperationSchedule.Add(_OperationSchedule);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysOperationSchedule.ChangeItem(_OperationSchedule.Key, _OperationSchedule) == false)
										keysOperationSchedule.Add(_OperationSchedule);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysOperationSchedule.Contains(_OperationSchedule.Key))
										keysOperationSchedule.Remove(_OperationSchedule.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _OperationSchedule.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _OperationSchedule.Key)); }
	                   break;

	                case "ChainMedicalServices":
	                    ChainMedicalServices _ChainMedicalServices = (ChainMedicalServices)db.Entity;
	                    if (keysChainMedicalServices != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysChainMedicalServices.Add(_ChainMedicalServices);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysChainMedicalServices.ChangeItem(_ChainMedicalServices.Key, _ChainMedicalServices) == false)
										keysChainMedicalServices.Add(_ChainMedicalServices);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysChainMedicalServices.Contains(_ChainMedicalServices.Key))
										keysChainMedicalServices.Remove(_ChainMedicalServices.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ChainMedicalServices.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ChainMedicalServices.Key)); }
	                   break;

	                case "DocItem":
	                    DocItem _DocItem = (DocItem)db.Entity;
	                    if (keysDocItem != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDocItem.Add(_DocItem);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDocItem.ChangeItem(_DocItem.Key, _DocItem) == false)
										keysDocItem.Add(_DocItem);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDocItem.Contains(_DocItem.Key))
										keysDocItem.Remove(_DocItem.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DocItem.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DocItem.Key)); }
	                   break;

	                case "PastPersonHistory":
	                    PastPersonHistory _PastPersonHistory = (PastPersonHistory)db.Entity;
	                    if (keysPastPersonHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPastPersonHistory.Add(_PastPersonHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPastPersonHistory.ChangeItem(_PastPersonHistory.Key, _PastPersonHistory) == false)
										keysPastPersonHistory.Add(_PastPersonHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPastPersonHistory.Contains(_PastPersonHistory.Key))
										keysPastPersonHistory.Remove(_PastPersonHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PastPersonHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PastPersonHistory.Key)); }
	                   break;

	                case "ParaClinicalReqDetails":
	                    ParaClinicalReqDetails _ParaClinicalReqDetails = (ParaClinicalReqDetails)db.Entity;
	                    if (keysParaClinicalReqDetails != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysParaClinicalReqDetails.Add(_ParaClinicalReqDetails);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysParaClinicalReqDetails.ChangeItem(_ParaClinicalReqDetails.Key, _ParaClinicalReqDetails) == false)
										keysParaClinicalReqDetails.Add(_ParaClinicalReqDetails);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysParaClinicalReqDetails.Contains(_ParaClinicalReqDetails.Key))
										keysParaClinicalReqDetails.Remove(_ParaClinicalReqDetails.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ParaClinicalReqDetails.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ParaClinicalReqDetails.Key)); }
	                   break;

	                case "PatientAdmission":
	                    PatientAdmission _PatientAdmission = (PatientAdmission)db.Entity;
	                    if (keysPatientAdmission != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientAdmission.Add(_PatientAdmission);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientAdmission.ChangeItem(_PatientAdmission.Key, _PatientAdmission) == false)
										keysPatientAdmission.Add(_PatientAdmission);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientAdmission.Contains(_PatientAdmission.Key))
										keysPatientAdmission.Remove(_PatientAdmission.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientAdmission.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientAdmission.Key)); }
	                   break;

	                case "refCountry":
	                    refCountry _refCountry = (refCountry)db.Entity;
	                    if (keysrefCountry != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefCountry.Add(_refCountry);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefCountry.ChangeItem(_refCountry.Key, _refCountry) == false)
										keysrefCountry.Add(_refCountry);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefCountry.Contains(_refCountry.Key))
										keysrefCountry.Remove(_refCountry.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refCountry.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refCountry.Key)); }
	                   break;

	                case "PatientAddressHistory":
	                    PatientAddressHistory _PatientAddressHistory = (PatientAddressHistory)db.Entity;
	                    if (keysPatientAddressHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientAddressHistory.Add(_PatientAddressHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientAddressHistory.ChangeItem(_PatientAddressHistory.Key, _PatientAddressHistory) == false)
										keysPatientAddressHistory.Add(_PatientAddressHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientAddressHistory.Contains(_PatientAddressHistory.Key))
										keysPatientAddressHistory.Remove(_PatientAddressHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientAddressHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientAddressHistory.Key)); }
	                   break;

	                case "refPersRace":
	                    refPersRace _refPersRace = (refPersRace)db.Entity;
	                    if (keysrefPersRace != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefPersRace.Add(_refPersRace);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefPersRace.ChangeItem(_refPersRace.Key, _refPersRace) == false)
										keysrefPersRace.Add(_refPersRace);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefPersRace.Contains(_refPersRace.Key))
										keysrefPersRace.Remove(_refPersRace.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refPersRace.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refPersRace.Key)); }
	                   break;

	                case "OpSkedDistibution":
	                    OpSkedDistibution _OpSkedDistibution = (OpSkedDistibution)db.Entity;
	                    if (keysOpSkedDistibution != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysOpSkedDistibution.Add(_OpSkedDistibution);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysOpSkedDistibution.ChangeItem(_OpSkedDistibution.Key, _OpSkedDistibution) == false)
										keysOpSkedDistibution.Add(_OpSkedDistibution);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysOpSkedDistibution.Contains(_OpSkedDistibution.Key))
										keysOpSkedDistibution.Remove(_OpSkedDistibution.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _OpSkedDistibution.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _OpSkedDistibution.Key)); }
	                   break;

	                case "PatientDiagnosticImaging":
	                    PatientDiagnosticImaging _PatientDiagnosticImaging = (PatientDiagnosticImaging)db.Entity;
	                    if (keysPatientDiagnosticImaging != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientDiagnosticImaging.Add(_PatientDiagnosticImaging);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientDiagnosticImaging.ChangeItem(_PatientDiagnosticImaging.Key, _PatientDiagnosticImaging) == false)
										keysPatientDiagnosticImaging.Add(_PatientDiagnosticImaging);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientDiagnosticImaging.Contains(_PatientDiagnosticImaging.Key))
										keysPatientDiagnosticImaging.Remove(_PatientDiagnosticImaging.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientDiagnosticImaging.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientDiagnosticImaging.Key)); }
	                   break;

	                case "EquivMedService":
	                    EquivMedService _EquivMedService = (EquivMedService)db.Entity;
	                    if (keysEquivMedService != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEquivMedService.Add(_EquivMedService);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEquivMedService.ChangeItem(_EquivMedService.Key, _EquivMedService) == false)
										keysEquivMedService.Add(_EquivMedService);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEquivMedService.Contains(_EquivMedService.Key))
										keysEquivMedService.Remove(_EquivMedService.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EquivMedService.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EquivMedService.Key)); }
	                   break;

	                case "refCurrency":
	                    refCurrency _refCurrency = (refCurrency)db.Entity;
	                    if (keysrefCurrency != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefCurrency.Add(_refCurrency);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefCurrency.ChangeItem(_refCurrency.Key, _refCurrency) == false)
										keysrefCurrency.Add(_refCurrency);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefCurrency.Contains(_refCurrency.Key))
										keysrefCurrency.Remove(_refCurrency.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refCurrency.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refCurrency.Key)); }
	                   break;

	                case "PatientClassHistory":
	                    PatientClassHistory _PatientClassHistory = (PatientClassHistory)db.Entity;
	                    if (keysPatientClassHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientClassHistory.Add(_PatientClassHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientClassHistory.ChangeItem(_PatientClassHistory.Key, _PatientClassHistory) == false)
										keysPatientClassHistory.Add(_PatientClassHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientClassHistory.Contains(_PatientClassHistory.Key))
										keysPatientClassHistory.Remove(_PatientClassHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientClassHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientClassHistory.Key)); }
	                   break;

	                case "RescrUsedInOperation":
	                    RescrUsedInOperation _RescrUsedInOperation = (RescrUsedInOperation)db.Entity;
	                    if (keysRescrUsedInOperation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysRescrUsedInOperation.Add(_RescrUsedInOperation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysRescrUsedInOperation.ChangeItem(_RescrUsedInOperation.Key, _RescrUsedInOperation) == false)
										keysRescrUsedInOperation.Add(_RescrUsedInOperation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysRescrUsedInOperation.Contains(_RescrUsedInOperation.Key))
										keysRescrUsedInOperation.Remove(_RescrUsedInOperation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _RescrUsedInOperation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _RescrUsedInOperation.Key)); }
	                   break;

	                case "TechnicalInspectionAgency":
	                    TechnicalInspectionAgency _TechnicalInspectionAgency = (TechnicalInspectionAgency)db.Entity;
	                    if (keysTechnicalInspectionAgency != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysTechnicalInspectionAgency.Add(_TechnicalInspectionAgency);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysTechnicalInspectionAgency.ChangeItem(_TechnicalInspectionAgency.Key, _TechnicalInspectionAgency) == false)
										keysTechnicalInspectionAgency.Add(_TechnicalInspectionAgency);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysTechnicalInspectionAgency.Contains(_TechnicalInspectionAgency.Key))
										keysTechnicalInspectionAgency.Remove(_TechnicalInspectionAgency.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _TechnicalInspectionAgency.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _TechnicalInspectionAgency.Key)); }
	                   break;

	                case "PatientClassification":
	                    PatientClassification _PatientClassification = (PatientClassification)db.Entity;
	                    if (keysPatientClassification != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientClassification.Add(_PatientClassification);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientClassification.ChangeItem(_PatientClassification.Key, _PatientClassification) == false)
										keysPatientClassification.Add(_PatientClassification);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientClassification.Contains(_PatientClassification.Key))
										keysPatientClassification.Remove(_PatientClassification.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientClassification.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientClassification.Key)); }
	                   break;

	                case "refDepartment":
	                    refDepartment _refDepartment = (refDepartment)db.Entity;
	                    if (keysrefDepartment != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefDepartment.Add(_refDepartment);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefDepartment.ChangeItem(_refDepartment.Key, _refDepartment) == false)
										keysrefDepartment.Add(_refDepartment);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefDepartment.Contains(_refDepartment.Key))
										keysrefDepartment.Remove(_refDepartment.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refDepartment.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refDepartment.Key)); }
	                   break;

	                case "WorkingDay":
	                    WorkingDay _WorkingDay = (WorkingDay)db.Entity;
	                    if (keysWorkingDay != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysWorkingDay.Add(_WorkingDay);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysWorkingDay.ChangeItem(_WorkingDay.Key, _WorkingDay) == false)
										keysWorkingDay.Add(_WorkingDay);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysWorkingDay.Contains(_WorkingDay.Key))
										keysWorkingDay.Remove(_WorkingDay.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _WorkingDay.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _WorkingDay.Key)); }
	                   break;

	                case "HIServiceItem":
	                    HIServiceItem _HIServiceItem = (HIServiceItem)db.Entity;
	                    if (keysHIServiceItem != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHIServiceItem.Add(_HIServiceItem);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHIServiceItem.ChangeItem(_HIServiceItem.Key, _HIServiceItem) == false)
										keysHIServiceItem.Add(_HIServiceItem);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHIServiceItem.Contains(_HIServiceItem.Key))
										keysHIServiceItem.Remove(_HIServiceItem.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HIServiceItem.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HIServiceItem.Key)); }
	                   break;

	                case "WorkingSchedule":
	                    WorkingSchedule _WorkingSchedule = (WorkingSchedule)db.Entity;
	                    if (keysWorkingSchedule != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysWorkingSchedule.Add(_WorkingSchedule);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysWorkingSchedule.ChangeItem(_WorkingSchedule.Key, _WorkingSchedule) == false)
										keysWorkingSchedule.Add(_WorkingSchedule);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysWorkingSchedule.Contains(_WorkingSchedule.Key))
										keysWorkingSchedule.Remove(_WorkingSchedule.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _WorkingSchedule.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _WorkingSchedule.Key)); }
	                   break;

	                case "PatientMedLabTestResult":
	                    PatientMedLabTestResult _PatientMedLabTestResult = (PatientMedLabTestResult)db.Entity;
	                    if (keysPatientMedLabTestResult != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientMedLabTestResult.Add(_PatientMedLabTestResult);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientMedLabTestResult.ChangeItem(_PatientMedLabTestResult.Key, _PatientMedLabTestResult) == false)
										keysPatientMedLabTestResult.Add(_PatientMedLabTestResult);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientMedLabTestResult.Contains(_PatientMedLabTestResult.Key))
										keysPatientMedLabTestResult.Remove(_PatientMedLabTestResult.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientMedLabTestResult.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientMedLabTestResult.Key)); }
	                   break;

	                case "Ward":
	                    Ward _Ward = (Ward)db.Entity;
	                    if (keysWard != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysWard.Add(_Ward);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysWard.ChangeItem(_Ward.Key, _Ward) == false)
										keysWard.Add(_Ward);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysWard.Contains(_Ward.Key))
										keysWard.Remove(_Ward.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Ward.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Ward.Key)); }
	                   break;

	                case "refDepreciationType":
	                    refDepreciationType _refDepreciationType = (refDepreciationType)db.Entity;
	                    if (keysrefDepreciationType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefDepreciationType.Add(_refDepreciationType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefDepreciationType.ChangeItem(_refDepreciationType.Key, _refDepreciationType) == false)
										keysrefDepreciationType.Add(_refDepreciationType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefDepreciationType.Contains(_refDepreciationType.Key))
										keysrefDepreciationType.Remove(_refDepreciationType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refDepreciationType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refDepreciationType.Key)); }
	                   break;

	                case "DDI":
	                    DDI _DDI = (DDI)db.Entity;
	                    if (keysDDI != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDDI.Add(_DDI);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDDI.ChangeItem(_DDI.Key, _DDI) == false)
										keysDDI.Add(_DDI);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDDI.Contains(_DDI.Key))
										keysDDI.Remove(_DDI.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DDI.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DDI.Key)); }
	                   break;

	                case "HIServiceItems":
	                    HIServiceItems _HIServiceItems = (HIServiceItems)db.Entity;
	                    if (keysHIServiceItems != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHIServiceItems.Add(_HIServiceItems);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHIServiceItems.ChangeItem(_HIServiceItems.Key, _HIServiceItems) == false)
										keysHIServiceItems.Add(_HIServiceItems);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHIServiceItems.Contains(_HIServiceItems.Key))
										keysHIServiceItems.Remove(_HIServiceItems.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HIServiceItems.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HIServiceItems.Key)); }
	                   break;

	                case "refDiagnosis":
	                    refDiagnosis _refDiagnosis = (refDiagnosis)db.Entity;
	                    if (keysrefDiagnosis != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefDiagnosis.Add(_refDiagnosis);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefDiagnosis.ChangeItem(_refDiagnosis.Key, _refDiagnosis) == false)
										keysrefDiagnosis.Add(_refDiagnosis);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefDiagnosis.Contains(_refDiagnosis.Key))
										keysrefDiagnosis.Remove(_refDiagnosis.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refDiagnosis.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refDiagnosis.Key)); }
	                   break;

	                case "HistoricalAuditData":
	                    HistoricalAuditData _HistoricalAuditData = (HistoricalAuditData)db.Entity;
	                    if (keysHistoricalAuditData != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHistoricalAuditData.Add(_HistoricalAuditData);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHistoricalAuditData.ChangeItem(_HistoricalAuditData.Key, _HistoricalAuditData) == false)
										keysHistoricalAuditData.Add(_HistoricalAuditData);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHistoricalAuditData.Contains(_HistoricalAuditData.Key))
										keysHistoricalAuditData.Remove(_HistoricalAuditData.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HistoricalAuditData.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HistoricalAuditData.Key)); }
	                   break;

	                case "WardInDept":
	                    WardInDept _WardInDept = (WardInDept)db.Entity;
	                    if (keysWardInDept != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysWardInDept.Add(_WardInDept);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysWardInDept.ChangeItem(_WardInDept.Key, _WardInDept) == false)
										keysWardInDept.Add(_WardInDept);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysWardInDept.Contains(_WardInDept.Key))
										keysWardInDept.Remove(_WardInDept.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _WardInDept.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _WardInDept.Key)); }
	                   break;

	                case "PatientSpecimen":
	                    PatientSpecimen _PatientSpecimen = (PatientSpecimen)db.Entity;
	                    if (keysPatientSpecimen != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientSpecimen.Add(_PatientSpecimen);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientSpecimen.ChangeItem(_PatientSpecimen.Key, _PatientSpecimen) == false)
										keysPatientSpecimen.Add(_PatientSpecimen);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientSpecimen.Contains(_PatientSpecimen.Key))
										keysPatientSpecimen.Remove(_PatientSpecimen.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientSpecimen.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientSpecimen.Key)); }
	                   break;

	                case "HosFeeTransDetails":
	                    HosFeeTransDetails _HosFeeTransDetails = (HosFeeTransDetails)db.Entity;
	                    if (keysHosFeeTransDetails != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHosFeeTransDetails.Add(_HosFeeTransDetails);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHosFeeTransDetails.ChangeItem(_HosFeeTransDetails.Key, _HosFeeTransDetails) == false)
										keysHosFeeTransDetails.Add(_HosFeeTransDetails);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHosFeeTransDetails.Contains(_HosFeeTransDetails.Key))
										keysHosFeeTransDetails.Remove(_HosFeeTransDetails.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HosFeeTransDetails.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HosFeeTransDetails.Key)); }
	                   break;

	     //           case "Trigs":
	     //               Trigs _Trigs = (Trigs)db.Entity;
	     //               if (keysTrigs != null)
	     //               {
						//	switch (db.State) {
						//		  case System.Data.Entity.EntityState.Added:
						//			  keysTrigs.Add(_Trigs);
						//			break;
						//		case System.Data.Entity.EntityState.Modified:
						//			  if (keysTrigs.ChangeItem(_Trigs.Key, _Trigs) == false)
						//				keysTrigs.Add(_Trigs);
						//			break;
						//		case System.Data.Entity.EntityState.Deleted:
						//			  if (keysTrigs.Contains(_Trigs.Key))
						//				keysTrigs.Remove(_Trigs.Key);
						//			break;
						//	}
						//}
	     //              if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Trigs.Key));
	     //              if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Trigs.Key)); }
	     //              break;

	                case "ICD10":
	                    ICD10 _ICD10 = (ICD10)db.Entity;
	                    if (keysICD10 != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysICD10.Add(_ICD10);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysICD10.ChangeItem(_ICD10.Key, _ICD10) == false)
										keysICD10.Add(_ICD10);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysICD10.Contains(_ICD10.Key))
										keysICD10.Remove(_ICD10.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ICD10.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ICD10.Key)); }
	                   break;

	                case "refDistrict":
	                    refDistrict _refDistrict = (refDistrict)db.Entity;
	                    if (keysrefDistrict != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefDistrict.Add(_refDistrict);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefDistrict.ChangeItem(_refDistrict.Key, _refDistrict) == false)
										keysrefDistrict.Add(_refDistrict);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefDistrict.Contains(_refDistrict.Key))
										keysrefDistrict.Remove(_refDistrict.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refDistrict.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refDistrict.Key)); }
	                   break;

	                case "refEthnicGroup":
	                    refEthnicGroup _refEthnicGroup = (refEthnicGroup)db.Entity;
	                    if (keysrefEthnicGroup != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefEthnicGroup.Add(_refEthnicGroup);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefEthnicGroup.ChangeItem(_refEthnicGroup.Key, _refEthnicGroup) == false)
										keysrefEthnicGroup.Add(_refEthnicGroup);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefEthnicGroup.Contains(_refEthnicGroup.Key))
										keysrefEthnicGroup.Remove(_refEthnicGroup.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refEthnicGroup.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refEthnicGroup.Key)); }
	                   break;

	                case "refDrugKind":
	                    refDrugKind _refDrugKind = (refDrugKind)db.Entity;
	                    if (keysrefDrugKind != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefDrugKind.Add(_refDrugKind);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefDrugKind.ChangeItem(_refDrugKind.Key, _refDrugKind) == false)
										keysrefDrugKind.Add(_refDrugKind);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefDrugKind.Contains(_refDrugKind.Key))
										keysrefDrugKind.Remove(_refDrugKind.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refDrugKind.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refDrugKind.Key)); }
	                   break;

	                case "ICDChapter":
	                    ICDChapter _ICDChapter = (ICDChapter)db.Entity;
	                    if (keysICDChapter != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysICDChapter.Add(_ICDChapter);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysICDChapter.ChangeItem(_ICDChapter.Key, _ICDChapter) == false)
										keysICDChapter.Add(_ICDChapter);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysICDChapter.Contains(_ICDChapter.Key))
										keysICDChapter.Remove(_ICDChapter.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ICDChapter.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ICDChapter.Key)); }
	                   break;

	                case "ICDGroup":
	                    ICDGroup _ICDGroup = (ICDGroup)db.Entity;
	                    if (keysICDGroup != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysICDGroup.Add(_ICDGroup);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysICDGroup.ChangeItem(_ICDGroup.Key, _ICDGroup) == false)
										keysICDGroup.Add(_ICDGroup);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysICDGroup.Contains(_ICDGroup.Key))
										keysICDGroup.Remove(_ICDGroup.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ICDGroup.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ICDGroup.Key)); }
	                   break;

	                case "SpecifiedParaclinical":
	                    SpecifiedParaclinical _SpecifiedParaclinical = (SpecifiedParaclinical)db.Entity;
	                    if (keysSpecifiedParaclinical != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysSpecifiedParaclinical.Add(_SpecifiedParaclinical);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysSpecifiedParaclinical.ChangeItem(_SpecifiedParaclinical.Key, _SpecifiedParaclinical) == false)
										keysSpecifiedParaclinical.Add(_SpecifiedParaclinical);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysSpecifiedParaclinical.Contains(_SpecifiedParaclinical.Key))
										keysSpecifiedParaclinical.Remove(_SpecifiedParaclinical.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _SpecifiedParaclinical.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _SpecifiedParaclinical.Key)); }
	                   break;

	                case "refElthnic":
	                    refElthnic _refElthnic = (refElthnic)db.Entity;
	                    if (keysrefElthnic != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefElthnic.Add(_refElthnic);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefElthnic.ChangeItem(_refElthnic.Key, _refElthnic) == false)
										keysrefElthnic.Add(_refElthnic);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefElthnic.Contains(_refElthnic.Key))
										keysrefElthnic.Remove(_refElthnic.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refElthnic.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refElthnic.Key)); }
	                   break;

	                case "DiagDescribeTmp":
	                    DiagDescribeTmp _DiagDescribeTmp = (DiagDescribeTmp)db.Entity;
	                    if (keysDiagDescribeTmp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDiagDescribeTmp.Add(_DiagDescribeTmp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDiagDescribeTmp.ChangeItem(_DiagDescribeTmp.Key, _DiagDescribeTmp) == false)
										keysDiagDescribeTmp.Add(_DiagDescribeTmp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDiagDescribeTmp.Contains(_DiagDescribeTmp.Key))
										keysDiagDescribeTmp.Remove(_DiagDescribeTmp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DiagDescribeTmp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DiagDescribeTmp.Key)); }
	                   break;

	                case "TestOnPatientSpecimen":
	                    TestOnPatientSpecimen _TestOnPatientSpecimen = (TestOnPatientSpecimen)db.Entity;
	                    if (keysTestOnPatientSpecimen != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysTestOnPatientSpecimen.Add(_TestOnPatientSpecimen);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysTestOnPatientSpecimen.ChangeItem(_TestOnPatientSpecimen.Key, _TestOnPatientSpecimen) == false)
										keysTestOnPatientSpecimen.Add(_TestOnPatientSpecimen);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysTestOnPatientSpecimen.Contains(_TestOnPatientSpecimen.Key))
										keysTestOnPatientSpecimen.Remove(_TestOnPatientSpecimen.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _TestOnPatientSpecimen.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _TestOnPatientSpecimen.Key)); }
	                   break;

	                case "refExamAction":
	                    refExamAction _refExamAction = (refExamAction)db.Entity;
	                    if (keysrefExamAction != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefExamAction.Add(_refExamAction);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefExamAction.ChangeItem(_refExamAction.Key, _refExamAction) == false)
										keysrefExamAction.Add(_refExamAction);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefExamAction.Contains(_refExamAction.Key))
										keysrefExamAction.Remove(_refExamAction.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refExamAction.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refExamAction.Key)); }
	                   break;

	                case "PersonalProperty":
	                    PersonalProperty _PersonalProperty = (PersonalProperty)db.Entity;
	                    if (keysPersonalProperty != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPersonalProperty.Add(_PersonalProperty);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPersonalProperty.ChangeItem(_PersonalProperty.Key, _PersonalProperty) == false)
										keysPersonalProperty.Add(_PersonalProperty);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPersonalProperty.Contains(_PersonalProperty.Key))
										keysPersonalProperty.Remove(_PersonalProperty.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PersonalProperty.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PersonalProperty.Key)); }
	                   break;

	                case "refProblem":
	                    refProblem _refProblem = (refProblem)db.Entity;
	                    if (keysrefProblem != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefProblem.Add(_refProblem);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefProblem.ChangeItem(_refProblem.Key, _refProblem) == false)
										keysrefProblem.Add(_refProblem);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefProblem.Contains(_refProblem.Key))
										keysrefProblem.Remove(_refProblem.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refProblem.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refProblem.Key)); }
	                   break;

	                case "DrAdviceTmp":
	                    DrAdviceTmp _DrAdviceTmp = (DrAdviceTmp)db.Entity;
	                    if (keysDrAdviceTmp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrAdviceTmp.Add(_DrAdviceTmp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrAdviceTmp.ChangeItem(_DrAdviceTmp.Key, _DrAdviceTmp) == false)
										keysDrAdviceTmp.Add(_DrAdviceTmp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrAdviceTmp.Contains(_DrAdviceTmp.Key))
										keysDrAdviceTmp.Remove(_DrAdviceTmp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrAdviceTmp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrAdviceTmp.Key)); }
	                   break;

	                case "refExamObservation":
	                    refExamObservation _refExamObservation = (refExamObservation)db.Entity;
	                    if (keysrefExamObservation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefExamObservation.Add(_refExamObservation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefExamObservation.ChangeItem(_refExamObservation.Key, _refExamObservation) == false)
										keysrefExamObservation.Add(_refExamObservation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefExamObservation.Contains(_refExamObservation.Key))
										keysrefExamObservation.Remove(_refExamObservation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refExamObservation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refExamObservation.Key)); }
	                   break;

	                case "DrMedicineAdvice":
	                    DrMedicineAdvice _DrMedicineAdvice = (DrMedicineAdvice)db.Entity;
	                    if (keysDrMedicineAdvice != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrMedicineAdvice.Add(_DrMedicineAdvice);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrMedicineAdvice.ChangeItem(_DrMedicineAdvice.Key, _DrMedicineAdvice) == false)
										keysDrMedicineAdvice.Add(_DrMedicineAdvice);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrMedicineAdvice.Contains(_DrMedicineAdvice.Key))
										keysDrMedicineAdvice.Remove(_DrMedicineAdvice.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrMedicineAdvice.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrMedicineAdvice.Key)); }
	                   break;

	                case "DrMedicineTmp":
	                    DrMedicineTmp _DrMedicineTmp = (DrMedicineTmp)db.Entity;
	                    if (keysDrMedicineTmp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrMedicineTmp.Add(_DrMedicineTmp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrMedicineTmp.ChangeItem(_DrMedicineTmp.Key, _DrMedicineTmp) == false)
										keysDrMedicineTmp.Add(_DrMedicineTmp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrMedicineTmp.Contains(_DrMedicineTmp.Key))
										keysDrMedicineTmp.Remove(_DrMedicineTmp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrMedicineTmp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrMedicineTmp.Key)); }
	                   break;

	                case "refHL7":
	                    refHL7 _refHL7 = (refHL7)db.Entity;
	                    if (keysrefHL7 != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefHL7.Add(_refHL7);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefHL7.ChangeItem(_refHL7.Key, _refHL7) == false)
										keysrefHL7.Add(_refHL7);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefHL7.Contains(_refHL7.Key))
										keysrefHL7.Remove(_refHL7.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refHL7.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refHL7.Key)); }
	                   break;

	                case "DrPrescriptionTmp":
	                    DrPrescriptionTmp _DrPrescriptionTmp = (DrPrescriptionTmp)db.Entity;
	                    if (keysDrPrescriptionTmp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrPrescriptionTmp.Add(_DrPrescriptionTmp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrPrescriptionTmp.ChangeItem(_DrPrescriptionTmp.Key, _DrPrescriptionTmp) == false)
										keysDrPrescriptionTmp.Add(_DrPrescriptionTmp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrPrescriptionTmp.Contains(_DrPrescriptionTmp.Key))
										keysDrPrescriptionTmp.Remove(_DrPrescriptionTmp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrPrescriptionTmp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrPrescriptionTmp.Key)); }
	                   break;

	                case "HospitalFeeTransaction":
	                    HospitalFeeTransaction _HospitalFeeTransaction = (HospitalFeeTransaction)db.Entity;
	                    if (keysHospitalFeeTransaction != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHospitalFeeTransaction.Add(_HospitalFeeTransaction);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHospitalFeeTransaction.ChangeItem(_HospitalFeeTransaction.Key, _HospitalFeeTransaction) == false)
										keysHospitalFeeTransaction.Add(_HospitalFeeTransaction);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHospitalFeeTransaction.Contains(_HospitalFeeTransaction.Key))
										keysHospitalFeeTransaction.Remove(_HospitalFeeTransaction.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HospitalFeeTransaction.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HospitalFeeTransaction.Key)); }
	                   break;

	                case "PatientCommonMedRecord":
	                    PatientCommonMedRecord _PatientCommonMedRecord = (PatientCommonMedRecord)db.Entity;
	                    if (keysPatientCommonMedRecord != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientCommonMedRecord.Add(_PatientCommonMedRecord);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientCommonMedRecord.ChangeItem(_PatientCommonMedRecord.Key, _PatientCommonMedRecord) == false)
										keysPatientCommonMedRecord.Add(_PatientCommonMedRecord);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientCommonMedRecord.Contains(_PatientCommonMedRecord.Key))
										keysPatientCommonMedRecord.Remove(_PatientCommonMedRecord.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientCommonMedRecord.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientCommonMedRecord.Key)); }
	                   break;

	                case "HealthCareQueue":
	                    HealthCareQueue _HealthCareQueue = (HealthCareQueue)db.Entity;
	                    if (keysHealthCareQueue != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHealthCareQueue.Add(_HealthCareQueue);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHealthCareQueue.ChangeItem(_HealthCareQueue.Key, _HealthCareQueue) == false)
										keysHealthCareQueue.Add(_HealthCareQueue);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHealthCareQueue.Contains(_HealthCareQueue.Key))
										keysHealthCareQueue.Remove(_HealthCareQueue.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HealthCareQueue.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HealthCareQueue.Key)); }
	                   break;

	                case "Alert":
	                    Alert _Alert = (Alert)db.Entity;
	                    if (keysAlert != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAlert.Add(_Alert);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAlert.ChangeItem(_Alert.Key, _Alert) == false)
										keysAlert.Add(_Alert);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAlert.Contains(_Alert.Key))
										keysAlert.Remove(_Alert.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Alert.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Alert.Key)); }
	                   break;

	                case "refHumanLanguage":
	                    refHumanLanguage _refHumanLanguage = (refHumanLanguage)db.Entity;
	                    if (keysrefHumanLanguage != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefHumanLanguage.Add(_refHumanLanguage);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefHumanLanguage.ChangeItem(_refHumanLanguage.Key, _refHumanLanguage) == false)
										keysrefHumanLanguage.Add(_refHumanLanguage);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefHumanLanguage.Contains(_refHumanLanguage.Key))
										keysrefHumanLanguage.Remove(_refHumanLanguage.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refHumanLanguage.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refHumanLanguage.Key)); }
	                   break;

	                case "Patient":
	                    Patient _Patient = (Patient)db.Entity;
	                    if (keysPatient != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatient.Add(_Patient);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatient.ChangeItem(_Patient.Key, _Patient) == false)
										keysPatient.Add(_Patient);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatient.Contains(_Patient.Key))
										keysPatient.Remove(_Patient.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Patient.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Patient.Key)); }
	                   break;

	                case "PatientMedRecord":
	                    PatientMedRecord _PatientMedRecord = (PatientMedRecord)db.Entity;
	                    if (keysPatientMedRecord != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientMedRecord.Add(_PatientMedRecord);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientMedRecord.ChangeItem(_PatientMedRecord.Key, _PatientMedRecord) == false)
										keysPatientMedRecord.Add(_PatientMedRecord);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientMedRecord.Contains(_PatientMedRecord.Key))
										keysPatientMedRecord.Remove(_PatientMedRecord.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientMedRecord.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientMedRecord.Key)); }
	                   break;

	                case "refImmunization":
	                    refImmunization _refImmunization = (refImmunization)db.Entity;
	                    if (keysrefImmunization != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefImmunization.Add(_refImmunization);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefImmunization.ChangeItem(_refImmunization.Key, _refImmunization) == false)
										keysrefImmunization.Add(_refImmunization);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefImmunization.Contains(_refImmunization.Key))
										keysrefImmunization.Remove(_refImmunization.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refImmunization.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refImmunization.Key)); }
	                   break;

	                case "refUnitOfMeasure":
	                    refUnitOfMeasure _refUnitOfMeasure = (refUnitOfMeasure)db.Entity;
	                    if (keysrefUnitOfMeasure != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefUnitOfMeasure.Add(_refUnitOfMeasure);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefUnitOfMeasure.ChangeItem(_refUnitOfMeasure.Key, _refUnitOfMeasure) == false)
										keysrefUnitOfMeasure.Add(_refUnitOfMeasure);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefUnitOfMeasure.Contains(_refUnitOfMeasure.Key))
										keysrefUnitOfMeasure.Remove(_refUnitOfMeasure.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refUnitOfMeasure.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refUnitOfMeasure.Key)); }
	                   break;

	                case "PersonRole":
	                    PersonRole _PersonRole = (PersonRole)db.Entity;
	                    if (keysPersonRole != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPersonRole.Add(_PersonRole);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPersonRole.ChangeItem(_PersonRole.Key, _PersonRole) == false)
										keysPersonRole.Add(_PersonRole);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPersonRole.Contains(_PersonRole.Key))
										keysPersonRole.Remove(_PersonRole.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PersonRole.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PersonRole.Key)); }
	                   break;

	                case "DrPrescriptionTmps":
	                    DrPrescriptionTmps _DrPrescriptionTmps = (DrPrescriptionTmps)db.Entity;
	                    if (keysDrPrescriptionTmps != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrPrescriptionTmps.Add(_DrPrescriptionTmps);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrPrescriptionTmps.ChangeItem(_DrPrescriptionTmps.Key, _DrPrescriptionTmps) == false)
										keysDrPrescriptionTmps.Add(_DrPrescriptionTmps);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrPrescriptionTmps.Contains(_DrPrescriptionTmps.Key))
										keysDrPrescriptionTmps.Remove(_DrPrescriptionTmps.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrPrescriptionTmps.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrPrescriptionTmps.Key)); }
	                   break;

	                case "refInstUniversity":
	                    refInstUniversity _refInstUniversity = (refInstUniversity)db.Entity;
	                    if (keysrefInstUniversity != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefInstUniversity.Add(_refInstUniversity);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefInstUniversity.ChangeItem(_refInstUniversity.Key, _refInstUniversity) == false)
										keysrefInstUniversity.Add(_refInstUniversity);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefInstUniversity.Contains(_refInstUniversity.Key))
										keysrefInstUniversity.Remove(_refInstUniversity.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refInstUniversity.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refInstUniversity.Key)); }
	                   break;

	                case "Appointment":
	                    Appointment _Appointment = (Appointment)db.Entity;
	                    if (keysAppointment != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAppointment.Add(_Appointment);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAppointment.ChangeItem(_Appointment.Key, _Appointment) == false)
										keysAppointment.Add(_Appointment);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAppointment.Contains(_Appointment.Key))
										keysAppointment.Remove(_Appointment.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Appointment.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Appointment.Key)); }
	                   break;

	                case "refJobBand":
	                    refJobBand _refJobBand = (refJobBand)db.Entity;
	                    if (keysrefJobBand != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefJobBand.Add(_refJobBand);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefJobBand.ChangeItem(_refJobBand.Key, _refJobBand) == false)
										keysrefJobBand.Add(_refJobBand);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefJobBand.Contains(_refJobBand.Key))
										keysrefJobBand.Remove(_refJobBand.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refJobBand.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refJobBand.Key)); }
	                   break;

	                case "ASPNetRole":
	                    ASPNetRole _ASPNetRole = (ASPNetRole)db.Entity;
	                    if (keysASPNetRole != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysASPNetRole.Add(_ASPNetRole);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysASPNetRole.ChangeItem(_ASPNetRole.Key, _ASPNetRole) == false)
										keysASPNetRole.Add(_ASPNetRole);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysASPNetRole.Contains(_ASPNetRole.Key))
										keysASPNetRole.Remove(_ASPNetRole.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ASPNetRole.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ASPNetRole.Key)); }
	                   break;

	                case "MedicalBill":
	                    MedicalBill _MedicalBill = (MedicalBill)db.Entity;
	                    if (keysMedicalBill != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalBill.Add(_MedicalBill);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalBill.ChangeItem(_MedicalBill.Key, _MedicalBill) == false)
										keysMedicalBill.Add(_MedicalBill);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalBill.Contains(_MedicalBill.Key))
										keysMedicalBill.Remove(_MedicalBill.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalBill.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalBill.Key)); }
	                   break;

	                case "refInsurKind":
	                    refInsurKind _refInsurKind = (refInsurKind)db.Entity;
	                    if (keysrefInsurKind != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefInsurKind.Add(_refInsurKind);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefInsurKind.ChangeItem(_refInsurKind.Key, _refInsurKind) == false)
										keysrefInsurKind.Add(_refInsurKind);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefInsurKind.Contains(_refInsurKind.Key))
										keysrefInsurKind.Remove(_refInsurKind.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refInsurKind.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refInsurKind.Key)); }
	                   break;

	                case "ASPNetRolePermission":
	                    ASPNetRolePermission _ASPNetRolePermission = (ASPNetRolePermission)db.Entity;
	                    if (keysASPNetRolePermission != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysASPNetRolePermission.Add(_ASPNetRolePermission);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysASPNetRolePermission.ChangeItem(_ASPNetRolePermission.Key, _ASPNetRolePermission) == false)
										keysASPNetRolePermission.Add(_ASPNetRolePermission);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysASPNetRolePermission.Contains(_ASPNetRolePermission.Key))
										keysASPNetRolePermission.Remove(_ASPNetRolePermission.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ASPNetRolePermission.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ASPNetRolePermission.Key)); }
	                   break;

	                case "PatientProblem":
	                    PatientProblem _PatientProblem = (PatientProblem)db.Entity;
	                    if (keysPatientProblem != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientProblem.Add(_PatientProblem);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientProblem.ChangeItem(_PatientProblem.Key, _PatientProblem) == false)
										keysPatientProblem.Add(_PatientProblem);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientProblem.Contains(_PatientProblem.Key))
										keysPatientProblem.Remove(_PatientProblem.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientProblem.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientProblem.Key)); }
	                   break;

	                case "MedicalBills":
	                    MedicalBills _MedicalBills = (MedicalBills)db.Entity;
	                    if (keysMedicalBills != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalBills.Add(_MedicalBills);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalBills.ChangeItem(_MedicalBills.Key, _MedicalBills) == false)
										keysMedicalBills.Add(_MedicalBills);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalBills.Contains(_MedicalBills.Key))
										keysMedicalBills.Remove(_MedicalBills.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalBills.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalBills.Key)); }
	                   break;

	                case "refInternalReceiptType":
	                    refInternalReceiptType _refInternalReceiptType = (refInternalReceiptType)db.Entity;
	                    if (keysrefInternalReceiptType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefInternalReceiptType.Add(_refInternalReceiptType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefInternalReceiptType.ChangeItem(_refInternalReceiptType.Key, _refInternalReceiptType) == false)
										keysrefInternalReceiptType.Add(_refInternalReceiptType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefInternalReceiptType.Contains(_refInternalReceiptType.Key))
										keysrefInternalReceiptType.Remove(_refInternalReceiptType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refInternalReceiptType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refInternalReceiptType.Key)); }
	                   break;

	                case "SocialAndHealthInsurance":
	                    SocialAndHealthInsurance _SocialAndHealthInsurance = (SocialAndHealthInsurance)db.Entity;
	                    if (keysSocialAndHealthInsurance != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysSocialAndHealthInsurance.Add(_SocialAndHealthInsurance);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysSocialAndHealthInsurance.ChangeItem(_SocialAndHealthInsurance.Key, _SocialAndHealthInsurance) == false)
										keysSocialAndHealthInsurance.Add(_SocialAndHealthInsurance);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysSocialAndHealthInsurance.Contains(_SocialAndHealthInsurance.Key))
										keysSocialAndHealthInsurance.Remove(_SocialAndHealthInsurance.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _SocialAndHealthInsurance.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _SocialAndHealthInsurance.Key)); }
	                   break;

	                case "ASPNetToken":
	                    ASPNetToken _ASPNetToken = (ASPNetToken)db.Entity;
	                    if (keysASPNetToken != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysASPNetToken.Add(_ASPNetToken);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysASPNetToken.ChangeItem(_ASPNetToken.Key, _ASPNetToken) == false)
										keysASPNetToken.Add(_ASPNetToken);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysASPNetToken.Contains(_ASPNetToken.Key))
										keysASPNetToken.Remove(_ASPNetToken.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ASPNetToken.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ASPNetToken.Key)); }
	                   break;

	                case "MedRecOutline":
	                    MedRecOutline _MedRecOutline = (MedRecOutline)db.Entity;
	                    if (keysMedRecOutline != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedRecOutline.Add(_MedRecOutline);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedRecOutline.ChangeItem(_MedRecOutline.Key, _MedRecOutline) == false)
										keysMedRecOutline.Add(_MedRecOutline);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedRecOutline.Contains(_MedRecOutline.Key))
										keysMedRecOutline.Remove(_MedRecOutline.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedRecOutline.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedRecOutline.Key)); }
	                   break;

	                case "AdmNoTemp":
	                    AdmNoTemp _AdmNoTemp = (AdmNoTemp)db.Entity;
	                    if (keysAdmNoTemp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAdmNoTemp.Add(_AdmNoTemp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAdmNoTemp.ChangeItem(_AdmNoTemp.Key, _AdmNoTemp) == false)
										keysAdmNoTemp.Add(_AdmNoTemp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAdmNoTemp.Contains(_AdmNoTemp.Key))
										keysAdmNoTemp.Remove(_AdmNoTemp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AdmNoTemp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AdmNoTemp.Key)); }
	                   break;

	                case "ASPNetUser":
	                    ASPNetUser _ASPNetUser = (ASPNetUser)db.Entity;
	                    if (keysASPNetUser != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysASPNetUser.Add(_ASPNetUser);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysASPNetUser.ChangeItem(_ASPNetUser.Key, _ASPNetUser) == false)
										keysASPNetUser.Add(_ASPNetUser);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysASPNetUser.Contains(_ASPNetUser.Key))
										keysASPNetUser.Remove(_ASPNetUser.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ASPNetUser.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ASPNetUser.Key)); }
	                   break;

	                case "MedRecTmp":
	                    MedRecTmp _MedRecTmp = (MedRecTmp)db.Entity;
	                    if (keysMedRecTmp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedRecTmp.Add(_MedRecTmp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedRecTmp.ChangeItem(_MedRecTmp.Key, _MedRecTmp) == false)
										keysMedRecTmp.Add(_MedRecTmp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedRecTmp.Contains(_MedRecTmp.Key))
										keysMedRecTmp.Remove(_MedRecTmp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedRecTmp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedRecTmp.Key)); }
	                   break;

	                case "MedicalServicePackage":
	                    MedicalServicePackage _MedicalServicePackage = (MedicalServicePackage)db.Entity;
	                    if (keysMedicalServicePackage != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalServicePackage.Add(_MedicalServicePackage);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalServicePackage.ChangeItem(_MedicalServicePackage.Key, _MedicalServicePackage) == false)
										keysMedicalServicePackage.Add(_MedicalServicePackage);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalServicePackage.Contains(_MedicalServicePackage.Key))
										keysMedicalServicePackage.Remove(_MedicalServicePackage.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalServicePackage.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalServicePackage.Key)); }
	                   break;

	                case "refItemType":
	                    refItemType _refItemType = (refItemType)db.Entity;
	                    if (keysrefItemType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefItemType.Add(_refItemType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefItemType.ChangeItem(_refItemType.Key, _refItemType) == false)
										keysrefItemType.Add(_refItemType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefItemType.Contains(_refItemType.Key))
										keysrefItemType.Remove(_refItemType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refItemType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refItemType.Key)); }
	                   break;

	                case "PatientPVID":
	                    PatientPVID _PatientPVID = (PatientPVID)db.Entity;
	                    if (keysPatientPVID != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientPVID.Add(_PatientPVID);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientPVID.ChangeItem(_PatientPVID.Key, _PatientPVID) == false)
										keysPatientPVID.Add(_PatientPVID);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientPVID.Contains(_PatientPVID.Key))
										keysPatientPVID.Remove(_PatientPVID.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientPVID.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientPVID.Key)); }
	                   break;

	                case "MedSerInDept":
	                    MedSerInDept _MedSerInDept = (MedSerInDept)db.Entity;
	                    if (keysMedSerInDept != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedSerInDept.Add(_MedSerInDept);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedSerInDept.ChangeItem(_MedSerInDept.Key, _MedSerInDept) == false)
										keysMedSerInDept.Add(_MedSerInDept);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedSerInDept.Contains(_MedSerInDept.Key))
										keysMedSerInDept.Remove(_MedSerInDept.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedSerInDept.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedSerInDept.Key)); }
	                   break;

	                case "refJobTitle":
	                    refJobTitle _refJobTitle = (refJobTitle)db.Entity;
	                    if (keysrefJobTitle != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefJobTitle.Add(_refJobTitle);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefJobTitle.ChangeItem(_refJobTitle.Key, _refJobTitle) == false)
										keysrefJobTitle.Add(_refJobTitle);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefJobTitle.Contains(_refJobTitle.Key))
										keysrefJobTitle.Remove(_refJobTitle.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refJobTitle.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refJobTitle.Key)); }
	                   break;

	                case "MRParagraph":
	                    MRParagraph _MRParagraph = (MRParagraph)db.Entity;
	                    if (keysMRParagraph != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMRParagraph.Add(_MRParagraph);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMRParagraph.ChangeItem(_MRParagraph.Key, _MRParagraph) == false)
										keysMRParagraph.Add(_MRParagraph);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMRParagraph.Contains(_MRParagraph.Key))
										keysMRParagraph.Remove(_MRParagraph.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MRParagraph.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MRParagraph.Key)); }
	                   break;

	                case "refLimVitalSign":
	                    refLimVitalSign _refLimVitalSign = (refLimVitalSign)db.Entity;
	                    if (keysrefLimVitalSign != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefLimVitalSign.Add(_refLimVitalSign);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefLimVitalSign.ChangeItem(_refLimVitalSign.Key, _refLimVitalSign) == false)
										keysrefLimVitalSign.Add(_refLimVitalSign);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefLimVitalSign.Contains(_refLimVitalSign.Key))
										keysrefLimVitalSign.Remove(_refLimVitalSign.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refLimVitalSign.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refLimVitalSign.Key)); }
	                   break;

	                case "WorkPlace":
	                    WorkPlace _WorkPlace = (WorkPlace)db.Entity;
	                    if (keysWorkPlace != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysWorkPlace.Add(_WorkPlace);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysWorkPlace.ChangeItem(_WorkPlace.Key, _WorkPlace) == false)
										keysWorkPlace.Add(_WorkPlace);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysWorkPlace.Contains(_WorkPlace.Key))
										keysWorkPlace.Remove(_WorkPlace.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _WorkPlace.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _WorkPlace.Key)); }
	                   break;

	                case "GenericSocialNetwork":
	                    GenericSocialNetwork _GenericSocialNetwork = (GenericSocialNetwork)db.Entity;
	                    if (keysGenericSocialNetwork != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysGenericSocialNetwork.Add(_GenericSocialNetwork);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysGenericSocialNetwork.ChangeItem(_GenericSocialNetwork.Key, _GenericSocialNetwork) == false)
										keysGenericSocialNetwork.Add(_GenericSocialNetwork);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysGenericSocialNetwork.Contains(_GenericSocialNetwork.Key))
										keysGenericSocialNetwork.Remove(_GenericSocialNetwork.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _GenericSocialNetwork.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _GenericSocialNetwork.Key)); }
	                   break;

	                case "MOHServiceItems":
	                    MOHServiceItems _MOHServiceItems = (MOHServiceItems)db.Entity;
	                    if (keysMOHServiceItems != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMOHServiceItems.Add(_MOHServiceItems);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMOHServiceItems.ChangeItem(_MOHServiceItems.Key, _MOHServiceItems) == false)
										keysMOHServiceItems.Add(_MOHServiceItems);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMOHServiceItems.Contains(_MOHServiceItems.Key))
										keysMOHServiceItems.Remove(_MOHServiceItems.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MOHServiceItems.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MOHServiceItems.Key)); }
	                   break;

	                case "refEducationalLevel":
	                    refEducationalLevel _refEducationalLevel = (refEducationalLevel)db.Entity;
	                    if (keysrefEducationalLevel != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefEducationalLevel.Add(_refEducationalLevel);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefEducationalLevel.ChangeItem(_refEducationalLevel.Key, _refEducationalLevel) == false)
										keysrefEducationalLevel.Add(_refEducationalLevel);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefEducationalLevel.Contains(_refEducationalLevel.Key))
										keysrefEducationalLevel.Remove(_refEducationalLevel.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refEducationalLevel.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refEducationalLevel.Key)); }
	                   break;

	                case "ASPNetUserClaims":
	                    ASPNetUserClaims _ASPNetUserClaims = (ASPNetUserClaims)db.Entity;
	                    if (keysASPNetUserClaims != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysASPNetUserClaims.Add(_ASPNetUserClaims);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysASPNetUserClaims.ChangeItem(_ASPNetUserClaims.Key, _ASPNetUserClaims) == false)
										keysASPNetUserClaims.Add(_ASPNetUserClaims);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysASPNetUserClaims.Contains(_ASPNetUserClaims.Key))
										keysASPNetUserClaims.Remove(_ASPNetUserClaims.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ASPNetUserClaims.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ASPNetUserClaims.Key)); }
	                   break;

	                case "AppliedMedStandard":
	                    AppliedMedStandard _AppliedMedStandard = (AppliedMedStandard)db.Entity;
	                    if (keysAppliedMedStandard != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAppliedMedStandard.Add(_AppliedMedStandard);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAppliedMedStandard.ChangeItem(_AppliedMedStandard.Key, _AppliedMedStandard) == false)
										keysAppliedMedStandard.Add(_AppliedMedStandard);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAppliedMedStandard.Contains(_AppliedMedStandard.Key))
										keysAppliedMedStandard.Remove(_AppliedMedStandard.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AppliedMedStandard.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AppliedMedStandard.Key)); }
	                   break;

	                case "ASPNetUserLogin":
	                    ASPNetUserLogin _ASPNetUserLogin = (ASPNetUserLogin)db.Entity;
	                    if (keysASPNetUserLogin != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysASPNetUserLogin.Add(_ASPNetUserLogin);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysASPNetUserLogin.ChangeItem(_ASPNetUserLogin.Key, _ASPNetUserLogin) == false)
										keysASPNetUserLogin.Add(_ASPNetUserLogin);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysASPNetUserLogin.Contains(_ASPNetUserLogin.Key))
										keysASPNetUserLogin.Remove(_ASPNetUserLogin.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ASPNetUserLogin.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ASPNetUserLogin.Key)); }
	                   break;

	                case "ArchitectureResources":
	                    ArchitectureResources _ArchitectureResources = (ArchitectureResources)db.Entity;
	                    if (keysArchitectureResources != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysArchitectureResources.Add(_ArchitectureResources);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysArchitectureResources.ChangeItem(_ArchitectureResources.Key, _ArchitectureResources) == false)
										keysArchitectureResources.Add(_ArchitectureResources);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysArchitectureResources.Contains(_ArchitectureResources.Key))
										keysArchitectureResources.Remove(_ArchitectureResources.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ArchitectureResources.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ArchitectureResources.Key)); }
	                   break;

	                case "PhysicalExamination":
	                    PhysicalExamination _PhysicalExamination = (PhysicalExamination)db.Entity;
	                    if (keysPhysicalExamination != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPhysicalExamination.Add(_PhysicalExamination);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPhysicalExamination.ChangeItem(_PhysicalExamination.Key, _PhysicalExamination) == false)
										keysPhysicalExamination.Add(_PhysicalExamination);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPhysicalExamination.Contains(_PhysicalExamination.Key))
										keysPhysicalExamination.Remove(_PhysicalExamination.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PhysicalExamination.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PhysicalExamination.Key)); }
	                   break;

	                case "MRSection":
	                    MRSection _MRSection = (MRSection)db.Entity;
	                    if (keysMRSection != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMRSection.Add(_MRSection);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMRSection.ChangeItem(_MRSection.Key, _MRSection) == false)
										keysMRSection.Add(_MRSection);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMRSection.Contains(_MRSection.Key))
										keysMRSection.Remove(_MRSection.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MRSection.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MRSection.Key)); }
	                   break;

	                case "PatientInvoices":
	                    PatientInvoices _PatientInvoices = (PatientInvoices)db.Entity;
	                    if (keysPatientInvoices != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientInvoices.Add(_PatientInvoices);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientInvoices.ChangeItem(_PatientInvoices.Key, _PatientInvoices) == false)
										keysPatientInvoices.Add(_PatientInvoices);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientInvoices.Contains(_PatientInvoices.Key))
										keysPatientInvoices.Remove(_PatientInvoices.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientInvoices.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientInvoices.Key)); }
	                   break;

	                case "AssignMedEquip":
	                    AssignMedEquip _AssignMedEquip = (AssignMedEquip)db.Entity;
	                    if (keysAssignMedEquip != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAssignMedEquip.Add(_AssignMedEquip);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAssignMedEquip.ChangeItem(_AssignMedEquip.Key, _AssignMedEquip) == false)
										keysAssignMedEquip.Add(_AssignMedEquip);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAssignMedEquip.Contains(_AssignMedEquip.Key))
										keysAssignMedEquip.Remove(_AssignMedEquip.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AssignMedEquip.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AssignMedEquip.Key)); }
	                   break;

	                case "refDischargeDisposition":
	                    refDischargeDisposition _refDischargeDisposition = (refDischargeDisposition)db.Entity;
	                    if (keysrefDischargeDisposition != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefDischargeDisposition.Add(_refDischargeDisposition);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefDischargeDisposition.ChangeItem(_refDischargeDisposition.Key, _refDischargeDisposition) == false)
										keysrefDischargeDisposition.Add(_refDischargeDisposition);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefDischargeDisposition.Contains(_refDischargeDisposition.Key))
										keysrefDischargeDisposition.Remove(_refDischargeDisposition.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refDischargeDisposition.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refDischargeDisposition.Key)); }
	                   break;

	                case "ASPNetUserRole":
	                    ASPNetUserRole _ASPNetUserRole = (ASPNetUserRole)db.Entity;
	                    if (keysASPNetUserRole != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysASPNetUserRole.Add(_ASPNetUserRole);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysASPNetUserRole.ChangeItem(_ASPNetUserRole.Key, _ASPNetUserRole) == false)
										keysASPNetUserRole.Add(_ASPNetUserRole);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysASPNetUserRole.Contains(_ASPNetUserRole.Key))
										keysASPNetUserRole.Remove(_ASPNetUserRole.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ASPNetUserRole.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ASPNetUserRole.Key)); }
	                   break;

	                case "MRSectionOutline":
	                    MRSectionOutline _MRSectionOutline = (MRSectionOutline)db.Entity;
	                    if (keysMRSectionOutline != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMRSectionOutline.Add(_MRSectionOutline);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMRSectionOutline.ChangeItem(_MRSectionOutline.Key, _MRSectionOutline) == false)
										keysMRSectionOutline.Add(_MRSectionOutline);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMRSectionOutline.Contains(_MRSectionOutline.Key))
										keysMRSectionOutline.Remove(_MRSectionOutline.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MRSectionOutline.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MRSectionOutline.Key)); }
	                   break;

	                case "SpecMedRecTmp":
	                    SpecMedRecTmp _SpecMedRecTmp = (SpecMedRecTmp)db.Entity;
	                    if (keysSpecMedRecTmp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysSpecMedRecTmp.Add(_SpecMedRecTmp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysSpecMedRecTmp.ChangeItem(_SpecMedRecTmp.Key, _SpecMedRecTmp) == false)
										keysSpecMedRecTmp.Add(_SpecMedRecTmp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysSpecMedRecTmp.Contains(_SpecMedRecTmp.Key))
										keysSpecMedRecTmp.Remove(_SpecMedRecTmp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _SpecMedRecTmp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _SpecMedRecTmp.Key)); }
	                   break;

	                case "HealthInsurance":
	                    HealthInsurance _HealthInsurance = (HealthInsurance)db.Entity;
	                    if (keysHealthInsurance != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHealthInsurance.Add(_HealthInsurance);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHealthInsurance.ChangeItem(_HealthInsurance.Key, _HealthInsurance) == false)
										keysHealthInsurance.Add(_HealthInsurance);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHealthInsurance.Contains(_HealthInsurance.Key))
										keysHealthInsurance.Remove(_HealthInsurance.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HealthInsurance.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HealthInsurance.Key)); }
	                   break;

	                case "Prescription":
	                    Prescription _Prescription = (Prescription)db.Entity;
	                    if (keysPrescription != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPrescription.Add(_Prescription);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPrescription.ChangeItem(_Prescription.Key, _Prescription) == false)
										keysPrescription.Add(_Prescription);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPrescription.Contains(_Prescription.Key))
										keysPrescription.Remove(_Prescription.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Prescription.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Prescription.Key)); }
	                   break;

	                case "PrivilegeRole":
	                    PrivilegeRole _PrivilegeRole = (PrivilegeRole)db.Entity;
	                    if (keysPrivilegeRole != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPrivilegeRole.Add(_PrivilegeRole);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPrivilegeRole.ChangeItem(_PrivilegeRole.Key, _PrivilegeRole) == false)
										keysPrivilegeRole.Add(_PrivilegeRole);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPrivilegeRole.Contains(_PrivilegeRole.Key))
										keysPrivilegeRole.Remove(_PrivilegeRole.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PrivilegeRole.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PrivilegeRole.Key)); }
	                   break;

	                case "AcPrincDrug":
	                    AcPrincDrug _AcPrincDrug = (AcPrincDrug)db.Entity;
	                    if (keysAcPrincDrug != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAcPrincDrug.Add(_AcPrincDrug);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAcPrincDrug.ChangeItem(_AcPrincDrug.Key, _AcPrincDrug) == false)
										keysAcPrincDrug.Add(_AcPrincDrug);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAcPrincDrug.Contains(_AcPrincDrug.Key))
										keysAcPrincDrug.Remove(_AcPrincDrug.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AcPrincDrug.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AcPrincDrug.Key)); }
	                   break;

	                case "InsuranceBeneficiary":
	                    InsuranceBeneficiary _InsuranceBeneficiary = (InsuranceBeneficiary)db.Entity;
	                    if (keysInsuranceBeneficiary != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysInsuranceBeneficiary.Add(_InsuranceBeneficiary);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysInsuranceBeneficiary.ChangeItem(_InsuranceBeneficiary.Key, _InsuranceBeneficiary) == false)
										keysInsuranceBeneficiary.Add(_InsuranceBeneficiary);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysInsuranceBeneficiary.Contains(_InsuranceBeneficiary.Key))
										keysInsuranceBeneficiary.Remove(_InsuranceBeneficiary.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _InsuranceBeneficiary.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _InsuranceBeneficiary.Key)); }
	                   break;

	                case "AntagonistDrug":
	                    AntagonistDrug _AntagonistDrug = (AntagonistDrug)db.Entity;
	                    if (keysAntagonistDrug != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAntagonistDrug.Add(_AntagonistDrug);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAntagonistDrug.ChangeItem(_AntagonistDrug.Key, _AntagonistDrug) == false)
										keysAntagonistDrug.Add(_AntagonistDrug);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAntagonistDrug.Contains(_AntagonistDrug.Key))
										keysAntagonistDrug.Remove(_AntagonistDrug.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AntagonistDrug.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AntagonistDrug.Key)); }
	                   break;

	                case "PatientTransaction":
	                    PatientTransaction _PatientTransaction = (PatientTransaction)db.Entity;
	                    if (keysPatientTransaction != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientTransaction.Add(_PatientTransaction);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientTransaction.ChangeItem(_PatientTransaction.Key, _PatientTransaction) == false)
										keysPatientTransaction.Add(_PatientTransaction);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientTransaction.Contains(_PatientTransaction.Key))
										keysPatientTransaction.Remove(_PatientTransaction.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientTransaction.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientTransaction.Key)); }
	                   break;

	                case "BedInRoom":
	                    BedInRoom _BedInRoom = (BedInRoom)db.Entity;
	                    if (keysBedInRoom != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysBedInRoom.Add(_BedInRoom);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysBedInRoom.ChangeItem(_BedInRoom.Key, _BedInRoom) == false)
										keysBedInRoom.Add(_BedInRoom);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysBedInRoom.Contains(_BedInRoom.Key))
										keysBedInRoom.Remove(_BedInRoom.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _BedInRoom.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _BedInRoom.Key)); }
	                   break;

	                case "Realms":
	                    Realms _Realms = (Realms)db.Entity;
	                    if (keysRealms != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysRealms.Add(_Realms);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysRealms.ChangeItem(_Realms.Key, _Realms) == false)
										keysRealms.Add(_Realms);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysRealms.Contains(_Realms.Key))
										keysRealms.Remove(_Realms.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Realms.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Realms.Key)); }
	                   break;

	                case "refPermission":
	                    refPermission _refPermission = (refPermission)db.Entity;
	                    if (keysrefPermission != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefPermission.Add(_refPermission);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefPermission.ChangeItem(_refPermission.Key, _refPermission) == false)
										keysrefPermission.Add(_refPermission);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefPermission.Contains(_refPermission.Key))
										keysrefPermission.Remove(_refPermission.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refPermission.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refPermission.Key)); }
	                   break;

	                case "InsuranceInterests":
	                    InsuranceInterests _InsuranceInterests = (InsuranceInterests)db.Entity;
	                    if (keysInsuranceInterests != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysInsuranceInterests.Add(_InsuranceInterests);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysInsuranceInterests.ChangeItem(_InsuranceInterests.Key, _InsuranceInterests) == false)
										keysInsuranceInterests.Add(_InsuranceInterests);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysInsuranceInterests.Contains(_InsuranceInterests.Key))
										keysInsuranceInterests.Remove(_InsuranceInterests.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _InsuranceInterests.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _InsuranceInterests.Key)); }
	                   break;

	                case "Employee":
	                    Employee _Employee = (Employee)db.Entity;
	                    if (keysEmployee != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEmployee.Add(_Employee);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEmployee.ChangeItem(_Employee.Key, _Employee) == false)
										keysEmployee.Add(_Employee);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEmployee.Contains(_Employee.Key))
										keysEmployee.Remove(_Employee.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Employee.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Employee.Key)); }
	                   break;

	                case "ContactDetails":
	                    ContactDetails _ContactDetails = (ContactDetails)db.Entity;
	                    if (keysContactDetails != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysContactDetails.Add(_ContactDetails);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysContactDetails.ChangeItem(_ContactDetails.Key, _ContactDetails) == false)
										keysContactDetails.Add(_ContactDetails);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysContactDetails.Contains(_ContactDetails.Key))
										keysContactDetails.Remove(_ContactDetails.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ContactDetails.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ContactDetails.Key)); }
	                   break;

	                case "InsuranceRegQueue":
	                    InsuranceRegQueue _InsuranceRegQueue = (InsuranceRegQueue)db.Entity;
	                    if (keysInsuranceRegQueue != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysInsuranceRegQueue.Add(_InsuranceRegQueue);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysInsuranceRegQueue.ChangeItem(_InsuranceRegQueue.Key, _InsuranceRegQueue) == false)
										keysInsuranceRegQueue.Add(_InsuranceRegQueue);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysInsuranceRegQueue.Contains(_InsuranceRegQueue.Key))
										keysInsuranceRegQueue.Remove(_InsuranceRegQueue.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _InsuranceRegQueue.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _InsuranceRegQueue.Key)); }
	                   break;

	                case "refMedcnAdminRoute":
	                    refMedcnAdminRoute _refMedcnAdminRoute = (refMedcnAdminRoute)db.Entity;
	                    if (keysrefMedcnAdminRoute != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefMedcnAdminRoute.Add(_refMedcnAdminRoute);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefMedcnAdminRoute.ChangeItem(_refMedcnAdminRoute.Key, _refMedcnAdminRoute) == false)
										keysrefMedcnAdminRoute.Add(_refMedcnAdminRoute);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefMedcnAdminRoute.Contains(_refMedcnAdminRoute.Key))
										keysrefMedcnAdminRoute.Remove(_refMedcnAdminRoute.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refMedcnAdminRoute.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refMedcnAdminRoute.Key)); }
	                   break;

	                case "ServerLog":
	                    ServerLog _ServerLog = (ServerLog)db.Entity;
	                    if (keysServerLog != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysServerLog.Add(_ServerLog);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysServerLog.ChangeItem(_ServerLog.Key, _ServerLog) == false)
										keysServerLog.Add(_ServerLog);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysServerLog.Contains(_ServerLog.Key))
										keysServerLog.Remove(_ServerLog.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ServerLog.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ServerLog.Key)); }
	                   break;

	                case "refMedcnVehicleForm":
	                    refMedcnVehicleForm _refMedcnVehicleForm = (refMedcnVehicleForm)db.Entity;
	                    if (keysrefMedcnVehicleForm != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefMedcnVehicleForm.Add(_refMedcnVehicleForm);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefMedcnVehicleForm.ChangeItem(_refMedcnVehicleForm.Key, _refMedcnVehicleForm) == false)
										keysrefMedcnVehicleForm.Add(_refMedcnVehicleForm);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefMedcnVehicleForm.Contains(_refMedcnVehicleForm.Key))
										keysrefMedcnVehicleForm.Remove(_refMedcnVehicleForm.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refMedcnVehicleForm.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refMedcnVehicleForm.Key)); }
	                   break;

	                case "Contract":
	                    Contract _Contract = (Contract)db.Entity;
	                    if (keysContract != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysContract.Add(_Contract);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysContract.ChangeItem(_Contract.Key, _Contract) == false)
										keysContract.Add(_Contract);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysContract.Contains(_Contract.Key))
										keysContract.Remove(_Contract.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Contract.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Contract.Key)); }
	                   break;

	                case "PromotionPlan":
	                    PromotionPlan _PromotionPlan = (PromotionPlan)db.Entity;
	                    if (keysPromotionPlan != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPromotionPlan.Add(_PromotionPlan);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPromotionPlan.ChangeItem(_PromotionPlan.Key, _PromotionPlan) == false)
										keysPromotionPlan.Add(_PromotionPlan);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPromotionPlan.Contains(_PromotionPlan.Key))
										keysPromotionPlan.Remove(_PromotionPlan.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PromotionPlan.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PromotionPlan.Key)); }
	                   break;

	                case "refMedEquipResourceType":
	                    refMedEquipResourceType _refMedEquipResourceType = (refMedEquipResourceType)db.Entity;
	                    if (keysrefMedEquipResourceType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefMedEquipResourceType.Add(_refMedEquipResourceType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefMedEquipResourceType.ChangeItem(_refMedEquipResourceType.Key, _refMedEquipResourceType) == false)
										keysrefMedEquipResourceType.Add(_refMedEquipResourceType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefMedEquipResourceType.Contains(_refMedEquipResourceType.Key))
										keysrefMedEquipResourceType.Remove(_refMedEquipResourceType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refMedEquipResourceType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refMedEquipResourceType.Key)); }
	                   break;

	                case "ContractChange":
	                    ContractChange _ContractChange = (ContractChange)db.Entity;
	                    if (keysContractChange != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysContractChange.Add(_ContractChange);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysContractChange.ChangeItem(_ContractChange.Key, _ContractChange) == false)
										keysContractChange.Add(_ContractChange);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysContractChange.Contains(_ContractChange.Key))
										keysContractChange.Remove(_ContractChange.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ContractChange.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ContractChange.Key)); }
	                   break;

	                case "Session":
	                    Session _Session = (Session)db.Entity;
	                    if (keysSession != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysSession.Add(_Session);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysSession.ChangeItem(_Session.Key, _Session) == false)
										keysSession.Add(_Session);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysSession.Contains(_Session.Key))
										keysSession.Remove(_Session.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Session.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Session.Key)); }
	                   break;

	                case "PrescriptionDetail":
	                    PrescriptionDetail _PrescriptionDetail = (PrescriptionDetail)db.Entity;
	                    if (keysPrescriptionDetail != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPrescriptionDetail.Add(_PrescriptionDetail);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPrescriptionDetail.ChangeItem(_PrescriptionDetail.Key, _PrescriptionDetail) == false)
										keysPrescriptionDetail.Add(_PrescriptionDetail);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPrescriptionDetail.Contains(_PrescriptionDetail.Key))
										keysPrescriptionDetail.Remove(_PrescriptionDetail.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PrescriptionDetail.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PrescriptionDetail.Key)); }
	                   break;

	                case "ClinicalTrial":
	                    ClinicalTrial _ClinicalTrial = (ClinicalTrial)db.Entity;
	                    if (keysClinicalTrial != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysClinicalTrial.Add(_ClinicalTrial);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysClinicalTrial.ChangeItem(_ClinicalTrial.Key, _ClinicalTrial) == false)
										keysClinicalTrial.Add(_ClinicalTrial);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysClinicalTrial.Contains(_ClinicalTrial.Key))
										keysClinicalTrial.Remove(_ClinicalTrial.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ClinicalTrial.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ClinicalTrial.Key)); }
	                   break;

	                case "refLookup":
	                    refLookup _refLookup = (refLookup)db.Entity;
	                    if (keysrefLookup != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefLookup.Add(_refLookup);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefLookup.ChangeItem(_refLookup.Key, _refLookup) == false)
										keysrefLookup.Add(_refLookup);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefLookup.Contains(_refLookup.Key))
										keysrefLookup.Remove(_refLookup.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refLookup.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refLookup.Key)); }
	                   break;

	                case "PromotionService":
	                    PromotionService _PromotionService = (PromotionService)db.Entity;
	                    if (keysPromotionService != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPromotionService.Add(_PromotionService);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPromotionService.ChangeItem(_PromotionService.Key, _PromotionService) == false)
										keysPromotionService.Add(_PromotionService);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPromotionService.Contains(_PromotionService.Key))
										keysPromotionService.Remove(_PromotionService.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PromotionService.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PromotionService.Key)); }
	                   break;

	                case "ContractDocument":
	                    ContractDocument _ContractDocument = (ContractDocument)db.Entity;
	                    if (keysContractDocument != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysContractDocument.Add(_ContractDocument);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysContractDocument.ChangeItem(_ContractDocument.Key, _ContractDocument) == false)
										keysContractDocument.Add(_ContractDocument);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysContractDocument.Contains(_ContractDocument.Key))
										keysContractDocument.Remove(_ContractDocument.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ContractDocument.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ContractDocument.Key)); }
	                   break;

	                case "NetworkGuestAccount":
	                    NetworkGuestAccount _NetworkGuestAccount = (NetworkGuestAccount)db.Entity;
	                    if (keysNetworkGuestAccount != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysNetworkGuestAccount.Add(_NetworkGuestAccount);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysNetworkGuestAccount.ChangeItem(_NetworkGuestAccount.Key, _NetworkGuestAccount) == false)
										keysNetworkGuestAccount.Add(_NetworkGuestAccount);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysNetworkGuestAccount.Contains(_NetworkGuestAccount.Key))
										keysNetworkGuestAccount.Remove(_NetworkGuestAccount.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _NetworkGuestAccount.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _NetworkGuestAccount.Key)); }
	                   break;

	                case "Quotation":
	                    Quotation _Quotation = (Quotation)db.Entity;
	                    if (keysQuotation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysQuotation.Add(_Quotation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysQuotation.ChangeItem(_Quotation.Key, _Quotation) == false)
										keysQuotation.Add(_Quotation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysQuotation.Contains(_Quotation.Key))
										keysQuotation.Remove(_Quotation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Quotation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Quotation.Key)); }
	                   break;

	                case "refMedHisIndex":
	                    refMedHisIndex _refMedHisIndex = (refMedHisIndex)db.Entity;
	                    if (keysrefMedHisIndex != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefMedHisIndex.Add(_refMedHisIndex);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefMedHisIndex.ChangeItem(_refMedHisIndex.Key, _refMedHisIndex) == false)
										keysrefMedHisIndex.Add(_refMedHisIndex);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefMedHisIndex.Contains(_refMedHisIndex.Key))
										keysrefMedHisIndex.Remove(_refMedHisIndex.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refMedHisIndex.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refMedHisIndex.Key)); }
	                   break;

	                case "ClinicalTrialResult":
	                    ClinicalTrialResult _ClinicalTrialResult = (ClinicalTrialResult)db.Entity;
	                    if (keysClinicalTrialResult != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysClinicalTrialResult.Add(_ClinicalTrialResult);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysClinicalTrialResult.ChangeItem(_ClinicalTrialResult.Key, _ClinicalTrialResult) == false)
										keysClinicalTrialResult.Add(_ClinicalTrialResult);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysClinicalTrialResult.Contains(_ClinicalTrialResult.Key))
										keysClinicalTrialResult.Remove(_ClinicalTrialResult.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ClinicalTrialResult.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ClinicalTrialResult.Key)); }
	                   break;

	                case "DHCRoomBlock":
	                    DHCRoomBlock _DHCRoomBlock = (DHCRoomBlock)db.Entity;
	                    if (keysDHCRoomBlock != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDHCRoomBlock.Add(_DHCRoomBlock);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDHCRoomBlock.ChangeItem(_DHCRoomBlock.Key, _DHCRoomBlock) == false)
										keysDHCRoomBlock.Add(_DHCRoomBlock);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDHCRoomBlock.Contains(_DHCRoomBlock.Key))
										keysDHCRoomBlock.Remove(_DHCRoomBlock.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DHCRoomBlock.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DHCRoomBlock.Key)); }
	                   break;

	                case "refMedicalCondition":
	                    refMedicalCondition _refMedicalCondition = (refMedicalCondition)db.Entity;
	                    if (keysrefMedicalCondition != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefMedicalCondition.Add(_refMedicalCondition);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefMedicalCondition.ChangeItem(_refMedicalCondition.Key, _refMedicalCondition) == false)
										keysrefMedicalCondition.Add(_refMedicalCondition);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefMedicalCondition.Contains(_refMedicalCondition.Key))
										keysrefMedicalCondition.Remove(_refMedicalCondition.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refMedicalCondition.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refMedicalCondition.Key)); }
	                   break;

	                case "DisposableMDResource":
	                    DisposableMDResource _DisposableMDResource = (DisposableMDResource)db.Entity;
	                    if (keysDisposableMDResource != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDisposableMDResource.Add(_DisposableMDResource);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDisposableMDResource.ChangeItem(_DisposableMDResource.Key, _DisposableMDResource) == false)
										keysDisposableMDResource.Add(_DisposableMDResource);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDisposableMDResource.Contains(_DisposableMDResource.Key))
										keysDisposableMDResource.Remove(_DisposableMDResource.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DisposableMDResource.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DisposableMDResource.Key)); }
	                   break;

	                case "OnlineQueue":
	                    OnlineQueue _OnlineQueue = (OnlineQueue)db.Entity;
	                    if (keysOnlineQueue != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysOnlineQueue.Add(_OnlineQueue);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysOnlineQueue.ChangeItem(_OnlineQueue.Key, _OnlineQueue) == false)
										keysOnlineQueue.Add(_OnlineQueue);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysOnlineQueue.Contains(_OnlineQueue.Key))
										keysOnlineQueue.Remove(_OnlineQueue.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _OnlineQueue.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _OnlineQueue.Key)); }
	                   break;

	                case "refMedicalServiceType":
	                    refMedicalServiceType _refMedicalServiceType = (refMedicalServiceType)db.Entity;
	                    if (keysrefMedicalServiceType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefMedicalServiceType.Add(_refMedicalServiceType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefMedicalServiceType.ChangeItem(_refMedicalServiceType.Key, _refMedicalServiceType) == false)
										keysrefMedicalServiceType.Add(_refMedicalServiceType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefMedicalServiceType.Contains(_refMedicalServiceType.Key))
										keysrefMedicalServiceType.Remove(_refMedicalServiceType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refMedicalServiceType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refMedicalServiceType.Key)); }
	                   break;

	                case "Drug":
	                    Drug _Drug = (Drug)db.Entity;
	                    if (keysDrug != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrug.Add(_Drug);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrug.ChangeItem(_Drug.Key, _Drug) == false)
										keysDrug.Add(_Drug);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrug.Contains(_Drug.Key))
										keysDrug.Remove(_Drug.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Drug.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Drug.Key)); }
	                   break;

	                case "RegistrationInfo":
	                    RegistrationInfo _RegistrationInfo = (RegistrationInfo)db.Entity;
	                    if (keysRegistrationInfo != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysRegistrationInfo.Add(_RegistrationInfo);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysRegistrationInfo.ChangeItem(_RegistrationInfo.Key, _RegistrationInfo) == false)
										keysRegistrationInfo.Add(_RegistrationInfo);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysRegistrationInfo.Contains(_RegistrationInfo.Key))
										keysRegistrationInfo.Remove(_RegistrationInfo.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _RegistrationInfo.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _RegistrationInfo.Key)); }
	                   break;

	                case "refQualification":
	                    refQualification _refQualification = (refQualification)db.Entity;
	                    if (keysrefQualification != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefQualification.Add(_refQualification);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefQualification.ChangeItem(_refQualification.Key, _refQualification) == false)
										keysrefQualification.Add(_refQualification);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefQualification.Contains(_refQualification.Key))
										keysrefQualification.Remove(_refQualification.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refQualification.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refQualification.Key)); }
	                   break;

	                case "PrescriptionHistory":
	                    PrescriptionHistory _PrescriptionHistory = (PrescriptionHistory)db.Entity;
	                    if (keysPrescriptionHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPrescriptionHistory.Add(_PrescriptionHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPrescriptionHistory.ChangeItem(_PrescriptionHistory.Key, _PrescriptionHistory) == false)
										keysPrescriptionHistory.Add(_PrescriptionHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPrescriptionHistory.Contains(_PrescriptionHistory.Key))
										keysPrescriptionHistory.Remove(_PrescriptionHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PrescriptionHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PrescriptionHistory.Key)); }
	                   break;

	                case "refPersGender":
	                    refPersGender _refPersGender = (refPersGender)db.Entity;
	                    if (keysrefPersGender != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefPersGender.Add(_refPersGender);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefPersGender.ChangeItem(_refPersGender.Key, _refPersGender) == false)
										keysrefPersGender.Add(_refPersGender);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefPersGender.Contains(_refPersGender.Key))
										keysrefPersGender.Remove(_refPersGender.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refPersGender.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refPersGender.Key)); }
	                   break;

	                case "PrivacyClass":
	                    PrivacyClass _PrivacyClass = (PrivacyClass)db.Entity;
	                    if (keysPrivacyClass != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPrivacyClass.Add(_PrivacyClass);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPrivacyClass.ChangeItem(_PrivacyClass.Key, _PrivacyClass) == false)
										keysPrivacyClass.Add(_PrivacyClass);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPrivacyClass.Contains(_PrivacyClass.Key))
										keysPrivacyClass.Remove(_PrivacyClass.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PrivacyClass.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PrivacyClass.Key)); }
	                   break;

	                case "ResearchPartnership":
	                    ResearchPartnership _ResearchPartnership = (ResearchPartnership)db.Entity;
	                    if (keysResearchPartnership != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysResearchPartnership.Add(_ResearchPartnership);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysResearchPartnership.ChangeItem(_ResearchPartnership.Key, _ResearchPartnership) == false)
										keysResearchPartnership.Add(_ResearchPartnership);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysResearchPartnership.Contains(_ResearchPartnership.Key))
										keysResearchPartnership.Remove(_ResearchPartnership.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ResearchPartnership.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ResearchPartnership.Key)); }
	                   break;

	                case "Person":
	                    Person _Person = (Person)db.Entity;
	                    if (keysPerson != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPerson.Add(_Person);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPerson.ChangeItem(_Person.Key, _Person) == false)
										keysPerson.Add(_Person);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPerson.Contains(_Person.Key))
										keysPerson.Remove(_Person.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Person.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Person.Key)); }
	                   break;

	                case "PtCodeCheckDigitTmp":
	                    PtCodeCheckDigitTmp _PtCodeCheckDigitTmp = (PtCodeCheckDigitTmp)db.Entity;
	                    if (keysPtCodeCheckDigitTmp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPtCodeCheckDigitTmp.Add(_PtCodeCheckDigitTmp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPtCodeCheckDigitTmp.ChangeItem(_PtCodeCheckDigitTmp.Key, _PtCodeCheckDigitTmp) == false)
										keysPtCodeCheckDigitTmp.Add(_PtCodeCheckDigitTmp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPtCodeCheckDigitTmp.Contains(_PtCodeCheckDigitTmp.Key))
										keysPtCodeCheckDigitTmp.Remove(_PtCodeCheckDigitTmp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PtCodeCheckDigitTmp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PtCodeCheckDigitTmp.Key)); }
	                   break;

	                case "BodyRegion":
	                    BodyRegion _BodyRegion = (BodyRegion)db.Entity;
	                    if (keysBodyRegion != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysBodyRegion.Add(_BodyRegion);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysBodyRegion.ChangeItem(_BodyRegion.Key, _BodyRegion) == false)
										keysBodyRegion.Add(_BodyRegion);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysBodyRegion.Contains(_BodyRegion.Key))
										keysBodyRegion.Remove(_BodyRegion.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _BodyRegion.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _BodyRegion.Key)); }
	                   break;

	                case "RxHoldConsultation":
	                    RxHoldConsultation _RxHoldConsultation = (RxHoldConsultation)db.Entity;
	                    if (keysRxHoldConsultation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysRxHoldConsultation.Add(_RxHoldConsultation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysRxHoldConsultation.ChangeItem(_RxHoldConsultation.Key, _RxHoldConsultation) == false)
										keysRxHoldConsultation.Add(_RxHoldConsultation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysRxHoldConsultation.Contains(_RxHoldConsultation.Key))
										keysRxHoldConsultation.Remove(_RxHoldConsultation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _RxHoldConsultation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _RxHoldConsultation.Key)); }
	                   break;

	                case "RegQueue":
	                    RegQueue _RegQueue = (RegQueue)db.Entity;
	                    if (keysRegQueue != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysRegQueue.Add(_RegQueue);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysRegQueue.ChangeItem(_RegQueue.Key, _RegQueue) == false)
										keysRegQueue.Add(_RegQueue);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysRegQueue.Contains(_RegQueue.Key))
										keysRegQueue.Remove(_RegQueue.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _RegQueue.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _RegQueue.Key)); }
	                   break;

	                case "EquipHistory":
	                    EquipHistory _EquipHistory = (EquipHistory)db.Entity;
	                    if (keysEquipHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEquipHistory.Add(_EquipHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEquipHistory.ChangeItem(_EquipHistory.Key, _EquipHistory) == false)
										keysEquipHistory.Add(_EquipHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEquipHistory.Contains(_EquipHistory.Key))
										keysEquipHistory.Remove(_EquipHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EquipHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EquipHistory.Key)); }
	                   break;

	                case "ClinicalIndicatorType":
	                    ClinicalIndicatorType _ClinicalIndicatorType = (ClinicalIndicatorType)db.Entity;
	                    if (keysClinicalIndicatorType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysClinicalIndicatorType.Add(_ClinicalIndicatorType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysClinicalIndicatorType.ChangeItem(_ClinicalIndicatorType.Key, _ClinicalIndicatorType) == false)
										keysClinicalIndicatorType.Add(_ClinicalIndicatorType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysClinicalIndicatorType.Contains(_ClinicalIndicatorType.Key))
										keysClinicalIndicatorType.Remove(_ClinicalIndicatorType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ClinicalIndicatorType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ClinicalIndicatorType.Key)); }
	                   break;

	                case "ExamMaintenanceHistory":
	                    ExamMaintenanceHistory _ExamMaintenanceHistory = (ExamMaintenanceHistory)db.Entity;
	                    if (keysExamMaintenanceHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysExamMaintenanceHistory.Add(_ExamMaintenanceHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysExamMaintenanceHistory.ChangeItem(_ExamMaintenanceHistory.Key, _ExamMaintenanceHistory) == false)
										keysExamMaintenanceHistory.Add(_ExamMaintenanceHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysExamMaintenanceHistory.Contains(_ExamMaintenanceHistory.Key))
										keysExamMaintenanceHistory.Remove(_ExamMaintenanceHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ExamMaintenanceHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ExamMaintenanceHistory.Key)); }
	                   break;

	                case "UserGroup":
	                    UserGroup _UserGroup = (UserGroup)db.Entity;
	                    if (keysUserGroup != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysUserGroup.Add(_UserGroup);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysUserGroup.ChangeItem(_UserGroup.Key, _UserGroup) == false)
										keysUserGroup.Add(_UserGroup);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysUserGroup.Contains(_UserGroup.Key))
										keysUserGroup.Remove(_UserGroup.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _UserGroup.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _UserGroup.Key)); }
	                   break;

	                case "MedicalDiagnosticMethod":
	                    MedicalDiagnosticMethod _MedicalDiagnosticMethod = (MedicalDiagnosticMethod)db.Entity;
	                    if (keysMedicalDiagnosticMethod != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalDiagnosticMethod.Add(_MedicalDiagnosticMethod);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalDiagnosticMethod.ChangeItem(_MedicalDiagnosticMethod.Key, _MedicalDiagnosticMethod) == false)
										keysMedicalDiagnosticMethod.Add(_MedicalDiagnosticMethod);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalDiagnosticMethod.Contains(_MedicalDiagnosticMethod.Key))
										keysMedicalDiagnosticMethod.Remove(_MedicalDiagnosticMethod.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalDiagnosticMethod.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalDiagnosticMethod.Key)); }
	                   break;

	                case "DrugConfign":
	                    DrugConfign _DrugConfign = (DrugConfign)db.Entity;
	                    if (keysDrugConfign != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrugConfign.Add(_DrugConfign);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrugConfign.ChangeItem(_DrugConfign.Key, _DrugConfign) == false)
										keysDrugConfign.Add(_DrugConfign);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrugConfign.Contains(_DrugConfign.Key))
										keysDrugConfign.Remove(_DrugConfign.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrugConfign.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrugConfign.Key)); }
	                   break;

	                case "SymptomIndicator":
	                    SymptomIndicator _SymptomIndicator = (SymptomIndicator)db.Entity;
	                    if (keysSymptomIndicator != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysSymptomIndicator.Add(_SymptomIndicator);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysSymptomIndicator.ChangeItem(_SymptomIndicator.Key, _SymptomIndicator) == false)
										keysSymptomIndicator.Add(_SymptomIndicator);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysSymptomIndicator.Contains(_SymptomIndicator.Key))
										keysSymptomIndicator.Remove(_SymptomIndicator.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _SymptomIndicator.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _SymptomIndicator.Key)); }
	                   break;

	                case "UsersInGroup":
	                    UsersInGroup _UsersInGroup = (UsersInGroup)db.Entity;
	                    if (keysUsersInGroup != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysUsersInGroup.Add(_UsersInGroup);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysUsersInGroup.ChangeItem(_UsersInGroup.Key, _UsersInGroup) == false)
										keysUsersInGroup.Add(_UsersInGroup);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysUsersInGroup.Contains(_UsersInGroup.Key))
										keysUsersInGroup.Remove(_UsersInGroup.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _UsersInGroup.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _UsersInGroup.Key)); }
	                   break;

	                case "MedicalTestProcedure":
	                    MedicalTestProcedure _MedicalTestProcedure = (MedicalTestProcedure)db.Entity;
	                    if (keysMedicalTestProcedure != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalTestProcedure.Add(_MedicalTestProcedure);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalTestProcedure.ChangeItem(_MedicalTestProcedure.Key, _MedicalTestProcedure) == false)
										keysMedicalTestProcedure.Add(_MedicalTestProcedure);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalTestProcedure.Contains(_MedicalTestProcedure.Key))
										keysMedicalTestProcedure.Remove(_MedicalTestProcedure.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalTestProcedure.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalTestProcedure.Key)); }
	                   break;

	                case "AdvancedSpecialist":
	                    AdvancedSpecialist _AdvancedSpecialist = (AdvancedSpecialist)db.Entity;
	                    if (keysAdvancedSpecialist != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAdvancedSpecialist.Add(_AdvancedSpecialist);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAdvancedSpecialist.ChangeItem(_AdvancedSpecialist.Key, _AdvancedSpecialist) == false)
										keysAdvancedSpecialist.Add(_AdvancedSpecialist);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAdvancedSpecialist.Contains(_AdvancedSpecialist.Key))
										keysAdvancedSpecialist.Remove(_AdvancedSpecialist.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AdvancedSpecialist.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AdvancedSpecialist.Key)); }
	                   break;

	                case "ReminderNotices":
	                    ReminderNotices _ReminderNotices = (ReminderNotices)db.Entity;
	                    if (keysReminderNotices != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysReminderNotices.Add(_ReminderNotices);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysReminderNotices.ChangeItem(_ReminderNotices.Key, _ReminderNotices) == false)
										keysReminderNotices.Add(_ReminderNotices);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysReminderNotices.Contains(_ReminderNotices.Key))
										keysReminderNotices.Remove(_ReminderNotices.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ReminderNotices.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ReminderNotices.Key)); }
	                   break;

	                case "ForeignExchange":
	                    ForeignExchange _ForeignExchange = (ForeignExchange)db.Entity;
	                    if (keysForeignExchange != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysForeignExchange.Add(_ForeignExchange);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysForeignExchange.ChangeItem(_ForeignExchange.Key, _ForeignExchange) == false)
										keysForeignExchange.Add(_ForeignExchange);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysForeignExchange.Contains(_ForeignExchange.Key))
										keysForeignExchange.Remove(_ForeignExchange.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ForeignExchange.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ForeignExchange.Key)); }
	                   break;

	                case "DrugInDepartment":
	                    DrugInDepartment _DrugInDepartment = (DrugInDepartment)db.Entity;
	                    if (keysDrugInDepartment != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrugInDepartment.Add(_DrugInDepartment);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrugInDepartment.ChangeItem(_DrugInDepartment.Key, _DrugInDepartment) == false)
										keysDrugInDepartment.Add(_DrugInDepartment);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrugInDepartment.Contains(_DrugInDepartment.Key))
										keysDrugInDepartment.Remove(_DrugInDepartment.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrugInDepartment.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrugInDepartment.Key)); }
	                   break;

	                case "HosRanking":
	                    HosRanking _HosRanking = (HosRanking)db.Entity;
	                    if (keysHosRanking != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHosRanking.Add(_HosRanking);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHosRanking.ChangeItem(_HosRanking.Key, _HosRanking) == false)
										keysHosRanking.Add(_HosRanking);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHosRanking.Contains(_HosRanking.Key))
										keysHosRanking.Remove(_HosRanking.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HosRanking.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HosRanking.Key)); }
	                   break;

	                case "AllergyIntolerance":
	                    AllergyIntolerance _AllergyIntolerance = (AllergyIntolerance)db.Entity;
	                    if (keysAllergyIntolerance != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAllergyIntolerance.Add(_AllergyIntolerance);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAllergyIntolerance.ChangeItem(_AllergyIntolerance.Key, _AllergyIntolerance) == false)
										keysAllergyIntolerance.Add(_AllergyIntolerance);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAllergyIntolerance.Contains(_AllergyIntolerance.Key))
										keysAllergyIntolerance.Remove(_AllergyIntolerance.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AllergyIntolerance.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AllergyIntolerance.Key)); }
	                   break;

	                case "EduLevel":
	                    EduLevel _EduLevel = (EduLevel)db.Entity;
	                    if (keysEduLevel != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEduLevel.Add(_EduLevel);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEduLevel.ChangeItem(_EduLevel.Key, _EduLevel) == false)
										keysEduLevel.Add(_EduLevel);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEduLevel.Contains(_EduLevel.Key))
										keysEduLevel.Remove(_EduLevel.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EduLevel.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EduLevel.Key)); }
	                   break;

	                case "refRole":
	                    refRole _refRole = (refRole)db.Entity;
	                    if (keysrefRole != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefRole.Add(_refRole);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefRole.ChangeItem(_refRole.Key, _refRole) == false)
										keysrefRole.Add(_refRole);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefRole.Contains(_refRole.Key))
										keysrefRole.Remove(_refRole.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refRole.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refRole.Key)); }
	                   break;

	                case "MedicalServiceItem":
	                    MedicalServiceItem _MedicalServiceItem = (MedicalServiceItem)db.Entity;
	                    if (keysMedicalServiceItem != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalServiceItem.Add(_MedicalServiceItem);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalServiceItem.ChangeItem(_MedicalServiceItem.Key, _MedicalServiceItem) == false)
										keysMedicalServiceItem.Add(_MedicalServiceItem);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalServiceItem.Contains(_MedicalServiceItem.Key))
										keysMedicalServiceItem.Remove(_MedicalServiceItem.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalServiceItem.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalServiceItem.Key)); }
	                   break;

	                case "Application":
	                    Application _Application = (Application)db.Entity;
	                    if (keysApplication != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysApplication.Add(_Application);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysApplication.ChangeItem(_Application.Key, _Application) == false)
										keysApplication.Add(_Application);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysApplication.Contains(_Application.Key))
										keysApplication.Remove(_Application.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Application.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Application.Key)); }
	                   break;

	                case "DrugPrice":
	                    DrugPrice _DrugPrice = (DrugPrice)db.Entity;
	                    if (keysDrugPrice != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDrugPrice.Add(_DrugPrice);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDrugPrice.ChangeItem(_DrugPrice.Key, _DrugPrice) == false)
										keysDrugPrice.Add(_DrugPrice);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDrugPrice.Contains(_DrugPrice.Key))
										keysDrugPrice.Remove(_DrugPrice.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DrugPrice.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DrugPrice.Key)); }
	                   break;

	                case "refShelfDrugLocation":
	                    refShelfDrugLocation _refShelfDrugLocation = (refShelfDrugLocation)db.Entity;
	                    if (keysrefShelfDrugLocation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefShelfDrugLocation.Add(_refShelfDrugLocation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefShelfDrugLocation.ChangeItem(_refShelfDrugLocation.Key, _refShelfDrugLocation) == false)
										keysrefShelfDrugLocation.Add(_refShelfDrugLocation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefShelfDrugLocation.Contains(_refShelfDrugLocation.Key))
										keysrefShelfDrugLocation.Remove(_refShelfDrugLocation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refShelfDrugLocation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refShelfDrugLocation.Key)); }
	                   break;

	                case "HCProvider":
	                    HCProvider _HCProvider = (HCProvider)db.Entity;
	                    if (keysHCProvider != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHCProvider.Add(_HCProvider);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHCProvider.ChangeItem(_HCProvider.Key, _HCProvider) == false)
										keysHCProvider.Add(_HCProvider);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHCProvider.Contains(_HCProvider.Key))
										keysHCProvider.Remove(_HCProvider.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HCProvider.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HCProvider.Key)); }
	                   break;

	                case "MedImagingRepository":
	                    MedImagingRepository _MedImagingRepository = (MedImagingRepository)db.Entity;
	                    if (keysMedImagingRepository != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedImagingRepository.Add(_MedImagingRepository);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedImagingRepository.ChangeItem(_MedImagingRepository.Key, _MedImagingRepository) == false)
										keysMedImagingRepository.Add(_MedImagingRepository);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedImagingRepository.Contains(_MedImagingRepository.Key))
										keysMedImagingRepository.Remove(_MedImagingRepository.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedImagingRepository.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedImagingRepository.Key)); }
	                   break;

	                case "MedImagingTest":
	                    MedImagingTest _MedImagingTest = (MedImagingTest)db.Entity;
	                    if (keysMedImagingTest != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedImagingTest.Add(_MedImagingTest);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedImagingTest.ChangeItem(_MedImagingTest.Key, _MedImagingTest) == false)
										keysMedImagingTest.Add(_MedImagingTest);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedImagingTest.Contains(_MedImagingTest.Key))
										keysMedImagingTest.Remove(_MedImagingTest.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedImagingTest.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedImagingTest.Key)); }
	                   break;

	                case "DeathSituationInfo":
	                    DeathSituationInfo _DeathSituationInfo = (DeathSituationInfo)db.Entity;
	                    if (keysDeathSituationInfo != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysDeathSituationInfo.Add(_DeathSituationInfo);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysDeathSituationInfo.ChangeItem(_DeathSituationInfo.Key, _DeathSituationInfo) == false)
										keysDeathSituationInfo.Add(_DeathSituationInfo);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysDeathSituationInfo.Contains(_DeathSituationInfo.Key))
										keysDeathSituationInfo.Remove(_DeathSituationInfo.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _DeathSituationInfo.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _DeathSituationInfo.Key)); }
	                   break;

	                case "refShift":
	                    refShift _refShift = (refShift)db.Entity;
	                    if (keysrefShift != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefShift.Add(_refShift);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefShift.ChangeItem(_refShift.Key, _refShift) == false)
										keysrefShift.Add(_refShift);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefShift.Contains(_refShift.Key))
										keysrefShift.Remove(_refShift.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refShift.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refShift.Key)); }
	                   break;

	                case "UserAccount":
	                    UserAccount _UserAccount = (UserAccount)db.Entity;
	                    if (keysUserAccount != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysUserAccount.Add(_UserAccount);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysUserAccount.ChangeItem(_UserAccount.Key, _UserAccount) == false)
										keysUserAccount.Add(_UserAccount);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysUserAccount.Contains(_UserAccount.Key))
										keysUserAccount.Remove(_UserAccount.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _UserAccount.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _UserAccount.Key)); }
	                   break;

	                case "MedImagingTestItems":
	                    MedImagingTestItems _MedImagingTestItems = (MedImagingTestItems)db.Entity;
	                    if (keysMedImagingTestItems != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedImagingTestItems.Add(_MedImagingTestItems);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedImagingTestItems.ChangeItem(_MedImagingTestItems.Key, _MedImagingTestItems) == false)
										keysMedImagingTestItems.Add(_MedImagingTestItems);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedImagingTestItems.Contains(_MedImagingTestItems.Key))
										keysMedImagingTestItems.Remove(_MedImagingTestItems.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedImagingTestItems.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedImagingTestItems.Key)); }
	                   break;

	                case "InOutType":
	                    InOutType _InOutType = (InOutType)db.Entity;
	                    if (keysInOutType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysInOutType.Add(_InOutType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysInOutType.ChangeItem(_InOutType.Key, _InOutType) == false)
										keysInOutType.Add(_InOutType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysInOutType.Contains(_InOutType.Key))
										keysInOutType.Remove(_InOutType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _InOutType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _InOutType.Key)); }
	                   break;

	                case "InOutwardDrug":
	                    InOutwardDrug _InOutwardDrug = (InOutwardDrug)db.Entity;
	                    if (keysInOutwardDrug != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysInOutwardDrug.Add(_InOutwardDrug);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysInOutwardDrug.ChangeItem(_InOutwardDrug.Key, _InOutwardDrug) == false)
										keysInOutwardDrug.Add(_InOutwardDrug);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysInOutwardDrug.Contains(_InOutwardDrug.Key))
										keysInOutwardDrug.Remove(_InOutwardDrug.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _InOutwardDrug.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _InOutwardDrug.Key)); }
	                   break;

	                case "MedLabRepository":
	                    MedLabRepository _MedLabRepository = (MedLabRepository)db.Entity;
	                    if (keysMedLabRepository != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedLabRepository.Add(_MedLabRepository);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedLabRepository.ChangeItem(_MedLabRepository.Key, _MedLabRepository) == false)
										keysMedLabRepository.Add(_MedLabRepository);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedLabRepository.Contains(_MedLabRepository.Key))
										keysMedLabRepository.Remove(_MedLabRepository.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedLabRepository.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedLabRepository.Key)); }
	                   break;

	                case "InputMaskSetting":
	                    InputMaskSetting _InputMaskSetting = (InputMaskSetting)db.Entity;
	                    if (keysInputMaskSetting != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysInputMaskSetting.Add(_InputMaskSetting);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysInputMaskSetting.ChangeItem(_InputMaskSetting.Key, _InputMaskSetting) == false)
										keysInputMaskSetting.Add(_InputMaskSetting);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysInputMaskSetting.Contains(_InputMaskSetting.Key))
										keysInputMaskSetting.Remove(_InputMaskSetting.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _InputMaskSetting.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _InputMaskSetting.Key)); }
	                   break;

	                case "refSIPrefix":
	                    refSIPrefix _refSIPrefix = (refSIPrefix)db.Entity;
	                    if (keysrefSIPrefix != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefSIPrefix.Add(_refSIPrefix);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefSIPrefix.ChangeItem(_refSIPrefix.Key, _refSIPrefix) == false)
										keysrefSIPrefix.Add(_refSIPrefix);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefSIPrefix.Contains(_refSIPrefix.Key))
										keysrefSIPrefix.Remove(_refSIPrefix.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refSIPrefix.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refSIPrefix.Key)); }
	                   break;

	                case "MesrtConv":
	                    MesrtConv _MesrtConv = (MesrtConv)db.Entity;
	                    if (keysMesrtConv != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMesrtConv.Add(_MesrtConv);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMesrtConv.ChangeItem(_MesrtConv.Key, _MesrtConv) == false)
										keysMesrtConv.Add(_MesrtConv);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMesrtConv.Contains(_MesrtConv.Key))
										keysMesrtConv.Remove(_MesrtConv.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MesrtConv.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MesrtConv.Key)); }
	                   break;

	                case "LotNumber":
	                    LotNumber _LotNumber = (LotNumber)db.Entity;
	                    if (keysLotNumber != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysLotNumber.Add(_LotNumber);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysLotNumber.ChangeItem(_LotNumber.Key, _LotNumber) == false)
										keysLotNumber.Add(_LotNumber);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysLotNumber.Contains(_LotNumber.Key))
										keysLotNumber.Remove(_LotNumber.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _LotNumber.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _LotNumber.Key)); }
	                   break;

	                case "FamilyHistory":
	                    FamilyHistory _FamilyHistory = (FamilyHistory)db.Entity;
	                    if (keysFamilyHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysFamilyHistory.Add(_FamilyHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysFamilyHistory.ChangeItem(_FamilyHistory.Key, _FamilyHistory) == false)
										keysFamilyHistory.Add(_FamilyHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysFamilyHistory.Contains(_FamilyHistory.Key))
										keysFamilyHistory.Remove(_FamilyHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _FamilyHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _FamilyHistory.Key)); }
	                   break;

	                case "MedLabTest":
	                    MedLabTest _MedLabTest = (MedLabTest)db.Entity;
	                    if (keysMedLabTest != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedLabTest.Add(_MedLabTest);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedLabTest.ChangeItem(_MedLabTest.Key, _MedLabTest) == false)
										keysMedLabTest.Add(_MedLabTest);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedLabTest.Contains(_MedLabTest.Key))
										keysMedLabTest.Remove(_MedLabTest.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedLabTest.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedLabTest.Key)); }
	                   break;

	                case "refSocialHisSeverity":
	                    refSocialHisSeverity _refSocialHisSeverity = (refSocialHisSeverity)db.Entity;
	                    if (keysrefSocialHisSeverity != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefSocialHisSeverity.Add(_refSocialHisSeverity);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefSocialHisSeverity.ChangeItem(_refSocialHisSeverity.Key, _refSocialHisSeverity) == false)
										keysrefSocialHisSeverity.Add(_refSocialHisSeverity);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefSocialHisSeverity.Contains(_refSocialHisSeverity.Key))
										keysrefSocialHisSeverity.Remove(_refSocialHisSeverity.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refSocialHisSeverity.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refSocialHisSeverity.Key)); }
	                   break;

	                case "refSpecimenType":
	                    refSpecimenType _refSpecimenType = (refSpecimenType)db.Entity;
	                    if (keysrefSpecimenType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefSpecimenType.Add(_refSpecimenType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefSpecimenType.ChangeItem(_refSpecimenType.Key, _refSpecimenType) == false)
										keysrefSpecimenType.Add(_refSpecimenType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefSpecimenType.Contains(_refSpecimenType.Key))
										keysrefSpecimenType.Remove(_refSpecimenType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refSpecimenType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refSpecimenType.Key)); }
	                   break;

	                case "Employeer":
	                    Employeer _Employeer = (Employeer)db.Entity;
	                    if (keysEmployeer != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEmployeer.Add(_Employeer);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEmployeer.ChangeItem(_Employeer.Key, _Employeer) == false)
										keysEmployeer.Add(_Employeer);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEmployeer.Contains(_Employeer.Key))
										keysEmployeer.Remove(_Employeer.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Employeer.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Employeer.Key)); }
	                   break;

	                case "HCStakeholder":
	                    HCStakeholder _HCStakeholder = (HCStakeholder)db.Entity;
	                    if (keysHCStakeholder != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHCStakeholder.Add(_HCStakeholder);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHCStakeholder.ChangeItem(_HCStakeholder.Key, _HCStakeholder) == false)
										keysHCStakeholder.Add(_HCStakeholder);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHCStakeholder.Contains(_HCStakeholder.Key))
										keysHCStakeholder.Remove(_HCStakeholder.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HCStakeholder.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HCStakeholder.Key)); }
	                   break;

	                case "PharmaceuticalCompany":
	                    PharmaceuticalCompany _PharmaceuticalCompany = (PharmaceuticalCompany)db.Entity;
	                    if (keysPharmaceuticalCompany != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPharmaceuticalCompany.Add(_PharmaceuticalCompany);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPharmaceuticalCompany.ChangeItem(_PharmaceuticalCompany.Key, _PharmaceuticalCompany) == false)
										keysPharmaceuticalCompany.Add(_PharmaceuticalCompany);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPharmaceuticalCompany.Contains(_PharmaceuticalCompany.Key))
										keysPharmaceuticalCompany.Remove(_PharmaceuticalCompany.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PharmaceuticalCompany.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PharmaceuticalCompany.Key)); }
	                   break;

	                case "refStoreHouse":
	                    refStoreHouse _refStoreHouse = (refStoreHouse)db.Entity;
	                    if (keysrefStoreHouse != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefStoreHouse.Add(_refStoreHouse);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefStoreHouse.ChangeItem(_refStoreHouse.Key, _refStoreHouse) == false)
										keysrefStoreHouse.Add(_refStoreHouse);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefStoreHouse.Contains(_refStoreHouse.Key))
										keysrefStoreHouse.Remove(_refStoreHouse.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refStoreHouse.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refStoreHouse.Key)); }
	                   break;

	                case "HIAdmission":
	                    HIAdmission _HIAdmission = (HIAdmission)db.Entity;
	                    if (keysHIAdmission != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHIAdmission.Add(_HIAdmission);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHIAdmission.ChangeItem(_HIAdmission.Key, _HIAdmission) == false)
										keysHIAdmission.Add(_HIAdmission);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHIAdmission.Contains(_HIAdmission.Key))
										keysHIAdmission.Remove(_HIAdmission.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HIAdmission.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HIAdmission.Key)); }
	                   break;

	                case "HCRoomBlock":
	                    HCRoomBlock _HCRoomBlock = (HCRoomBlock)db.Entity;
	                    if (keysHCRoomBlock != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHCRoomBlock.Add(_HCRoomBlock);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHCRoomBlock.ChangeItem(_HCRoomBlock.Key, _HCRoomBlock) == false)
										keysHCRoomBlock.Add(_HCRoomBlock);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHCRoomBlock.Contains(_HCRoomBlock.Key))
										keysHCRoomBlock.Remove(_HCRoomBlock.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HCRoomBlock.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HCRoomBlock.Key)); }
	                   break;

	                case "refAcademicTile":
	                    refAcademicTile _refAcademicTile = (refAcademicTile)db.Entity;
	                    if (keysrefAcademicTile != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefAcademicTile.Add(_refAcademicTile);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefAcademicTile.ChangeItem(_refAcademicTile.Key, _refAcademicTile) == false)
										keysrefAcademicTile.Add(_refAcademicTile);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefAcademicTile.Contains(_refAcademicTile.Key))
										keysrefAcademicTile.Remove(_refAcademicTile.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refAcademicTile.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refAcademicTile.Key)); }
	                   break;

	                case "JobHistory":
	                    JobHistory _JobHistory = (JobHistory)db.Entity;
	                    if (keysJobHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysJobHistory.Add(_JobHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysJobHistory.ChangeItem(_JobHistory.Key, _JobHistory) == false)
										keysJobHistory.Add(_JobHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysJobHistory.Contains(_JobHistory.Key))
										keysJobHistory.Remove(_JobHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _JobHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _JobHistory.Key)); }
	                   break;

	                case "PriceList":
	                    PriceList _PriceList = (PriceList)db.Entity;
	                    if (keysPriceList != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPriceList.Add(_PriceList);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPriceList.ChangeItem(_PriceList.Key, _PriceList) == false)
										keysPriceList.Add(_PriceList);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPriceList.Contains(_PriceList.Key))
										keysPriceList.Remove(_PriceList.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PriceList.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PriceList.Key)); }
	                   break;

	                case "HospitalizationHistory":
	                    HospitalizationHistory _HospitalizationHistory = (HospitalizationHistory)db.Entity;
	                    if (keysHospitalizationHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHospitalizationHistory.Add(_HospitalizationHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHospitalizationHistory.ChangeItem(_HospitalizationHistory.Key, _HospitalizationHistory) == false)
										keysHospitalizationHistory.Add(_HospitalizationHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHospitalizationHistory.Contains(_HospitalizationHistory.Key))
										keysHospitalizationHistory.Remove(_HospitalizationHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HospitalizationHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HospitalizationHistory.Key)); }
	                   break;

	                case "refFAMRelationship":
	                    refFAMRelationship _refFAMRelationship = (refFAMRelationship)db.Entity;
	                    if (keysrefFAMRelationship != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefFAMRelationship.Add(_refFAMRelationship);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefFAMRelationship.ChangeItem(_refFAMRelationship.Key, _refFAMRelationship) == false)
										keysrefFAMRelationship.Add(_refFAMRelationship);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefFAMRelationship.Contains(_refFAMRelationship.Key))
										keysrefFAMRelationship.Remove(_refFAMRelationship.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refFAMRelationship.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refFAMRelationship.Key)); }
	                   break;

	                case "refTimeFrame":
	                    refTimeFrame _refTimeFrame = (refTimeFrame)db.Entity;
	                    if (keysrefTimeFrame != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefTimeFrame.Add(_refTimeFrame);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefTimeFrame.ChangeItem(_refTimeFrame.Key, _refTimeFrame) == false)
										keysrefTimeFrame.Add(_refTimeFrame);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefTimeFrame.Contains(_refTimeFrame.Key))
										keysrefTimeFrame.Remove(_refTimeFrame.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refTimeFrame.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refTimeFrame.Key)); }
	                   break;

	                case "HospitalSpecialist":
	                    HospitalSpecialist _HospitalSpecialist = (HospitalSpecialist)db.Entity;
	                    if (keysHospitalSpecialist != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHospitalSpecialist.Add(_HospitalSpecialist);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHospitalSpecialist.ChangeItem(_HospitalSpecialist.Key, _HospitalSpecialist) == false)
										keysHospitalSpecialist.Add(_HospitalSpecialist);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHospitalSpecialist.Contains(_HospitalSpecialist.Key))
										keysHospitalSpecialist.Remove(_HospitalSpecialist.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HospitalSpecialist.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HospitalSpecialist.Key)); }
	                   break;

	                case "refActiviePrinciple":
	                    refActiviePrinciple _refActiviePrinciple = (refActiviePrinciple)db.Entity;
	                    if (keysrefActiviePrinciple != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefActiviePrinciple.Add(_refActiviePrinciple);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefActiviePrinciple.ChangeItem(_refActiviePrinciple.Key, _refActiviePrinciple) == false)
										keysrefActiviePrinciple.Add(_refActiviePrinciple);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefActiviePrinciple.Contains(_refActiviePrinciple.Key))
										keysrefActiviePrinciple.Remove(_refActiviePrinciple.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refActiviePrinciple.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refActiviePrinciple.Key)); }
	                   break;

	                case "refAdmissionType":
	                    refAdmissionType _refAdmissionType = (refAdmissionType)db.Entity;
	                    if (keysrefAdmissionType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefAdmissionType.Add(_refAdmissionType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefAdmissionType.ChangeItem(_refAdmissionType.Key, _refAdmissionType) == false)
										keysrefAdmissionType.Add(_refAdmissionType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefAdmissionType.Contains(_refAdmissionType.Key))
										keysrefAdmissionType.Remove(_refAdmissionType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refAdmissionType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refAdmissionType.Key)); }
	                   break;

	                case "MedicalEquimentsResources":
	                    MedicalEquimentsResources _MedicalEquimentsResources = (MedicalEquimentsResources)db.Entity;
	                    if (keysMedicalEquimentsResources != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedicalEquimentsResources.Add(_MedicalEquimentsResources);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedicalEquimentsResources.ChangeItem(_MedicalEquimentsResources.Key, _MedicalEquimentsResources) == false)
										keysMedicalEquimentsResources.Add(_MedicalEquimentsResources);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedicalEquimentsResources.Contains(_MedicalEquimentsResources.Key))
										keysMedicalEquimentsResources.Remove(_MedicalEquimentsResources.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedicalEquimentsResources.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedicalEquimentsResources.Key)); }
	                   break;

	                case "refAdmReferralType":
	                    refAdmReferralType _refAdmReferralType = (refAdmReferralType)db.Entity;
	                    if (keysrefAdmReferralType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefAdmReferralType.Add(_refAdmReferralType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefAdmReferralType.ChangeItem(_refAdmReferralType.Key, _refAdmReferralType) == false)
										keysrefAdmReferralType.Add(_refAdmReferralType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefAdmReferralType.Contains(_refAdmReferralType.Key))
										keysrefAdmReferralType.Remove(_refAdmReferralType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refAdmReferralType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refAdmReferralType.Key)); }
	                   break;

	                case "ProvidableDrugs":
	                    ProvidableDrugs _ProvidableDrugs = (ProvidableDrugs)db.Entity;
	                    if (keysProvidableDrugs != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysProvidableDrugs.Add(_ProvidableDrugs);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysProvidableDrugs.ChangeItem(_ProvidableDrugs.Key, _ProvidableDrugs) == false)
										keysProvidableDrugs.Add(_ProvidableDrugs);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysProvidableDrugs.Contains(_ProvidableDrugs.Key))
										keysProvidableDrugs.Remove(_ProvidableDrugs.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ProvidableDrugs.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ProvidableDrugs.Key)); }
	                   break;

	                case "refAllergyCategory":
	                    refAllergyCategory _refAllergyCategory = (refAllergyCategory)db.Entity;
	                    if (keysrefAllergyCategory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefAllergyCategory.Add(_refAllergyCategory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefAllergyCategory.ChangeItem(_refAllergyCategory.Key, _refAllergyCategory) == false)
										keysrefAllergyCategory.Add(_refAllergyCategory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefAllergyCategory.Contains(_refAllergyCategory.Key))
										keysrefAllergyCategory.Remove(_refAllergyCategory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refAllergyCategory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refAllergyCategory.Key)); }
	                   break;

	                case "refTransactionType":
	                    refTransactionType _refTransactionType = (refTransactionType)db.Entity;
	                    if (keysrefTransactionType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefTransactionType.Add(_refTransactionType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefTransactionType.ChangeItem(_refTransactionType.Key, _refTransactionType) == false)
										keysrefTransactionType.Add(_refTransactionType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefTransactionType.Contains(_refTransactionType.Key))
										keysrefTransactionType.Remove(_refTransactionType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refTransactionType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refTransactionType.Key)); }
	                   break;

	                case "JobModel":
	                    JobModel _JobModel = (JobModel)db.Entity;
	                    if (keysJobModel != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysJobModel.Add(_JobModel);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysJobModel.ChangeItem(_JobModel.Key, _JobModel) == false)
										keysJobModel.Add(_JobModel);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysJobModel.Contains(_JobModel.Key))
										keysJobModel.Remove(_JobModel.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _JobModel.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _JobModel.Key)); }
	                   break;

	                case "AssignmentSchedule":
	                    AssignmentSchedule _AssignmentSchedule = (AssignmentSchedule)db.Entity;
	                    if (keysAssignmentSchedule != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysAssignmentSchedule.Add(_AssignmentSchedule);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysAssignmentSchedule.ChangeItem(_AssignmentSchedule.Key, _AssignmentSchedule) == false)
										keysAssignmentSchedule.Add(_AssignmentSchedule);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysAssignmentSchedule.Contains(_AssignmentSchedule.Key))
										keysAssignmentSchedule.Remove(_AssignmentSchedule.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AssignmentSchedule.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AssignmentSchedule.Key)); }
	                   break;

	                case "refOccupation":
	                    refOccupation _refOccupation = (refOccupation)db.Entity;
	                    if (keysrefOccupation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefOccupation.Add(_refOccupation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefOccupation.ChangeItem(_refOccupation.Key, _refOccupation) == false)
										keysrefOccupation.Add(_refOccupation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefOccupation.Contains(_refOccupation.Key))
										keysrefOccupation.Remove(_refOccupation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refOccupation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refOccupation.Key)); }
	                   break;

	                case "BusySchedule":
	                    BusySchedule _BusySchedule = (BusySchedule)db.Entity;
	                    if (keysBusySchedule != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysBusySchedule.Add(_BusySchedule);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysBusySchedule.ChangeItem(_BusySchedule.Key, _BusySchedule) == false)
										keysBusySchedule.Add(_BusySchedule);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysBusySchedule.Contains(_BusySchedule.Key))
										keysBusySchedule.Remove(_BusySchedule.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _BusySchedule.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _BusySchedule.Key)); }
	                   break;

	     //           case "AdmNoTempHolding":
	     //               AdmNoTempHolding _AdmNoTempHolding = (AdmNoTempHolding)db.Entity;
	     //               if (keysAdmNoTempHolding != null)
	     //               {
						//	switch (db.State) {
						//		  case System.Data.Entity.EntityState.Added:
						//			  keysAdmNoTempHolding.Add(_AdmNoTempHolding);
						//			break;
						//		case System.Data.Entity.EntityState.Modified:
						//			  if (keysAdmNoTempHolding.ChangeItem(_AdmNoTempHolding.Key, _AdmNoTempHolding) == false)
						//				keysAdmNoTempHolding.Add(_AdmNoTempHolding);
						//			break;
						//		case System.Data.Entity.EntityState.Deleted:
						//			  if (keysAdmNoTempHolding.Contains(_AdmNoTempHolding.Key))
						//				keysAdmNoTempHolding.Remove(_AdmNoTempHolding.Key);
						//			break;
						//	}
						//}
	     //              if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _AdmNoTempHolding.Key));
	     //              if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _AdmNoTempHolding.Key)); }
	     //              break;

	                case "refTypeAbsent":
	                    refTypeAbsent _refTypeAbsent = (refTypeAbsent)db.Entity;
	                    if (keysrefTypeAbsent != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefTypeAbsent.Add(_refTypeAbsent);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefTypeAbsent.ChangeItem(_refTypeAbsent.Key, _refTypeAbsent) == false)
										keysrefTypeAbsent.Add(_refTypeAbsent);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefTypeAbsent.Contains(_refTypeAbsent.Key))
										keysrefTypeAbsent.Remove(_refTypeAbsent.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refTypeAbsent.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refTypeAbsent.Key)); }
	                   break;

	                case "refAllergyIndex":
	                    refAllergyIndex _refAllergyIndex = (refAllergyIndex)db.Entity;
	                    if (keysrefAllergyIndex != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefAllergyIndex.Add(_refAllergyIndex);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefAllergyIndex.ChangeItem(_refAllergyIndex.Key, _refAllergyIndex) == false)
										keysrefAllergyIndex.Add(_refAllergyIndex);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefAllergyIndex.Contains(_refAllergyIndex.Key))
										keysrefAllergyIndex.Remove(_refAllergyIndex.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refAllergyIndex.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refAllergyIndex.Key)); }
	                   break;

	                case "LanguageLevel":
	                    LanguageLevel _LanguageLevel = (LanguageLevel)db.Entity;
	                    if (keysLanguageLevel != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysLanguageLevel.Add(_LanguageLevel);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysLanguageLevel.ChangeItem(_LanguageLevel.Key, _LanguageLevel) == false)
										keysLanguageLevel.Add(_LanguageLevel);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysLanguageLevel.Contains(_LanguageLevel.Key))
										keysLanguageLevel.Remove(_LanguageLevel.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _LanguageLevel.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _LanguageLevel.Key)); }
	                   break;

	                case "refPersMaritalStatus":
	                    refPersMaritalStatus _refPersMaritalStatus = (refPersMaritalStatus)db.Entity;
	                    if (keysrefPersMaritalStatus != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefPersMaritalStatus.Add(_refPersMaritalStatus);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefPersMaritalStatus.ChangeItem(_refPersMaritalStatus.Key, _refPersMaritalStatus) == false)
										keysrefPersMaritalStatus.Add(_refPersMaritalStatus);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefPersMaritalStatus.Contains(_refPersMaritalStatus.Key))
										keysrefPersMaritalStatus.Remove(_refPersMaritalStatus.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refPersMaritalStatus.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refPersMaritalStatus.Key)); }
	                   break;

	                case "Organization":
	                    Organization _Organization = (Organization)db.Entity;
	                    if (keysOrganization != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysOrganization.Add(_Organization);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysOrganization.ChangeItem(_Organization.Key, _Organization) == false)
										keysOrganization.Add(_Organization);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysOrganization.Contains(_Organization.Key))
										keysOrganization.Remove(_Organization.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Organization.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Organization.Key)); }
	                   break;

	                case "EmpAllocation":
	                    EmpAllocation _EmpAllocation = (EmpAllocation)db.Entity;
	                    if (keysEmpAllocation != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEmpAllocation.Add(_EmpAllocation);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEmpAllocation.ChangeItem(_EmpAllocation.Key, _EmpAllocation) == false)
										keysEmpAllocation.Add(_EmpAllocation);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEmpAllocation.Contains(_EmpAllocation.Key))
										keysEmpAllocation.Remove(_EmpAllocation.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EmpAllocation.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EmpAllocation.Key)); }
	                   break;

	                case "NextOfKins":
	                    NextOfKins _NextOfKins = (NextOfKins)db.Entity;
	                    if (keysNextOfKins != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysNextOfKins.Add(_NextOfKins);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysNextOfKins.ChangeItem(_NextOfKins.Key, _NextOfKins) == false)
										keysNextOfKins.Add(_NextOfKins);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysNextOfKins.Contains(_NextOfKins.Key))
										keysNextOfKins.Remove(_NextOfKins.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _NextOfKins.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _NextOfKins.Key)); }
	                   break;

	                case "HospitalizationHistoryDetails":
	                    HospitalizationHistoryDetails _HospitalizationHistoryDetails = (HospitalizationHistoryDetails)db.Entity;
	                    if (keysHospitalizationHistoryDetails != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysHospitalizationHistoryDetails.Add(_HospitalizationHistoryDetails);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysHospitalizationHistoryDetails.ChangeItem(_HospitalizationHistoryDetails.Key, _HospitalizationHistoryDetails) == false)
										keysHospitalizationHistoryDetails.Add(_HospitalizationHistoryDetails);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysHospitalizationHistoryDetails.Contains(_HospitalizationHistoryDetails.Key))
										keysHospitalizationHistoryDetails.Remove(_HospitalizationHistoryDetails.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _HospitalizationHistoryDetails.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _HospitalizationHistoryDetails.Key)); }
	                   break;

	                case "refCareerMOH":
	                    refCareerMOH _refCareerMOH = (refCareerMOH)db.Entity;
	                    if (keysrefCareerMOH != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefCareerMOH.Add(_refCareerMOH);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefCareerMOH.ChangeItem(_refCareerMOH.Key, _refCareerMOH) == false)
										keysrefCareerMOH.Add(_refCareerMOH);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefCareerMOH.Contains(_refCareerMOH.Key))
										keysrefCareerMOH.Remove(_refCareerMOH.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refCareerMOH.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refCareerMOH.Key)); }
	                   break;

	                case "refAnnTemp":
	                    refAnnTemp _refAnnTemp = (refAnnTemp)db.Entity;
	                    if (keysrefAnnTemp != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefAnnTemp.Add(_refAnnTemp);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefAnnTemp.ChangeItem(_refAnnTemp.Key, _refAnnTemp) == false)
										keysrefAnnTemp.Add(_refAnnTemp);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefAnnTemp.Contains(_refAnnTemp.Key))
										keysrefAnnTemp.Remove(_refAnnTemp.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refAnnTemp.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refAnnTemp.Key)); }
	                   break;

	                case "PatientBed":
	                    PatientBed _PatientBed = (PatientBed)db.Entity;
	                    if (keysPatientBed != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientBed.Add(_PatientBed);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientBed.ChangeItem(_PatientBed.Key, _PatientBed) == false)
										keysPatientBed.Add(_PatientBed);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientBed.Contains(_PatientBed.Key))
										keysPatientBed.Remove(_PatientBed.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientBed.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientBed.Key)); }
	                   break;

	                case "ImmunizationHistory":
	                    ImmunizationHistory _ImmunizationHistory = (ImmunizationHistory)db.Entity;
	                    if (keysImmunizationHistory != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysImmunizationHistory.Add(_ImmunizationHistory);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysImmunizationHistory.ChangeItem(_ImmunizationHistory.Key, _ImmunizationHistory) == false)
										keysImmunizationHistory.Add(_ImmunizationHistory);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysImmunizationHistory.Contains(_ImmunizationHistory.Key))
										keysImmunizationHistory.Remove(_ImmunizationHistory.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ImmunizationHistory.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ImmunizationHistory.Key)); }
	                   break;

	                case "refAppConfig":
	                    refAppConfig _refAppConfig = (refAppConfig)db.Entity;
	                    if (keysrefAppConfig != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefAppConfig.Add(_refAppConfig);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefAppConfig.ChangeItem(_refAppConfig.Key, _refAppConfig) == false)
										keysrefAppConfig.Add(_refAppConfig);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefAppConfig.Contains(_refAppConfig.Key))
										keysrefAppConfig.Remove(_refAppConfig.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refAppConfig.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refAppConfig.Key)); }
	                   break;

	                case "EmployeeAnnualLeave":
	                    EmployeeAnnualLeave _EmployeeAnnualLeave = (EmployeeAnnualLeave)db.Entity;
	                    if (keysEmployeeAnnualLeave != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEmployeeAnnualLeave.Add(_EmployeeAnnualLeave);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEmployeeAnnualLeave.ChangeItem(_EmployeeAnnualLeave.Key, _EmployeeAnnualLeave) == false)
										keysEmployeeAnnualLeave.Add(_EmployeeAnnualLeave);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEmployeeAnnualLeave.Contains(_EmployeeAnnualLeave.Key))
										keysEmployeeAnnualLeave.Remove(_EmployeeAnnualLeave.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EmployeeAnnualLeave.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EmployeeAnnualLeave.Key)); }
	                   break;

	                case "refWard":
	                    refWard _refWard = (refWard)db.Entity;
	                    if (keysrefWard != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefWard.Add(_refWard);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefWard.ChangeItem(_refWard.Key, _refWard) == false)
										keysrefWard.Add(_refWard);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefWard.Contains(_refWard.Key))
										keysrefWard.Remove(_refWard.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refWard.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refWard.Key)); }
	                   break;

	                case "PatientBedFeatures":
	                    PatientBedFeatures _PatientBedFeatures = (PatientBedFeatures)db.Entity;
	                    if (keysPatientBedFeatures != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientBedFeatures.Add(_PatientBedFeatures);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientBedFeatures.ChangeItem(_PatientBedFeatures.Key, _PatientBedFeatures) == false)
										keysPatientBedFeatures.Add(_PatientBedFeatures);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientBedFeatures.Contains(_PatientBedFeatures.Key))
										keysPatientBedFeatures.Remove(_PatientBedFeatures.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientBedFeatures.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientBedFeatures.Key)); }
	                   break;

	                case "refBloodType":
	                    refBloodType _refBloodType = (refBloodType)db.Entity;
	                    if (keysrefBloodType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefBloodType.Add(_refBloodType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefBloodType.ChangeItem(_refBloodType.Key, _refBloodType) == false)
										keysrefBloodType.Add(_refBloodType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefBloodType.Contains(_refBloodType.Key))
										keysrefBloodType.Remove(_refBloodType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refBloodType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refBloodType.Key)); }
	                   break;

	                case "PatientInBedRoom":
	                    PatientInBedRoom _PatientInBedRoom = (PatientInBedRoom)db.Entity;
	                    if (keysPatientInBedRoom != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysPatientInBedRoom.Add(_PatientInBedRoom);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysPatientInBedRoom.ChangeItem(_PatientInBedRoom.Key, _PatientInBedRoom) == false)
										keysPatientInBedRoom.Add(_PatientInBedRoom);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysPatientInBedRoom.Contains(_PatientInBedRoom.Key))
										keysPatientInBedRoom.Remove(_PatientInBedRoom.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _PatientInBedRoom.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _PatientInBedRoom.Key)); }
	                   break;

	                case "MedLabTestItems":
	                    MedLabTestItems _MedLabTestItems = (MedLabTestItems)db.Entity;
	                    if (keysMedLabTestItems != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysMedLabTestItems.Add(_MedLabTestItems);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysMedLabTestItems.ChangeItem(_MedLabTestItems.Key, _MedLabTestItems) == false)
										keysMedLabTestItems.Add(_MedLabTestItems);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysMedLabTestItems.Contains(_MedLabTestItems.Key))
										keysMedLabTestItems.Remove(_MedLabTestItems.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _MedLabTestItems.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _MedLabTestItems.Key)); }
	                   break;

	                case "ScheduleDoingTaskLog":
	                    ScheduleDoingTaskLog _ScheduleDoingTaskLog = (ScheduleDoingTaskLog)db.Entity;
	                    if (keysScheduleDoingTaskLog != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysScheduleDoingTaskLog.Add(_ScheduleDoingTaskLog);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysScheduleDoingTaskLog.ChangeItem(_ScheduleDoingTaskLog.Key, _ScheduleDoingTaskLog) == false)
										keysScheduleDoingTaskLog.Add(_ScheduleDoingTaskLog);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysScheduleDoingTaskLog.Contains(_ScheduleDoingTaskLog.Key))
										keysScheduleDoingTaskLog.Remove(_ScheduleDoingTaskLog.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _ScheduleDoingTaskLog.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _ScheduleDoingTaskLog.Key)); }
	                   break;

	                case "refProviderType":
	                    refProviderType _refProviderType = (refProviderType)db.Entity;
	                    if (keysrefProviderType != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysrefProviderType.Add(_refProviderType);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysrefProviderType.ChangeItem(_refProviderType.Key, _refProviderType) == false)
										keysrefProviderType.Add(_refProviderType);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysrefProviderType.Contains(_refProviderType.Key))
										keysrefProviderType.Remove(_refProviderType.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _refProviderType.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _refProviderType.Key)); }
	                   break;

	                case "Bloodbank":
	                    Bloodbank _Bloodbank = (Bloodbank)db.Entity;
	                    if (keysBloodbank != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysBloodbank.Add(_Bloodbank);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysBloodbank.ChangeItem(_Bloodbank.Key, _Bloodbank) == false)
										keysBloodbank.Add(_Bloodbank);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysBloodbank.Contains(_Bloodbank.Key))
										keysBloodbank.Remove(_Bloodbank.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Bloodbank.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Bloodbank.Key)); }
	                   break;

	                case "OccCareerMOH":
	                    OccCareerMOH _OccCareerMOH = (OccCareerMOH)db.Entity;
	                    if (keysOccCareerMOH != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysOccCareerMOH.Add(_OccCareerMOH);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysOccCareerMOH.ChangeItem(_OccCareerMOH.Key, _OccCareerMOH) == false)
										keysOccCareerMOH.Add(_OccCareerMOH);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysOccCareerMOH.Contains(_OccCareerMOH.Key))
										keysOccCareerMOH.Remove(_OccCareerMOH.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _OccCareerMOH.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _OccCareerMOH.Key)); }
	                   break;

	                case "EmployeeLeaveTaken":
	                    EmployeeLeaveTaken _EmployeeLeaveTaken = (EmployeeLeaveTaken)db.Entity;
	                    if (keysEmployeeLeaveTaken != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysEmployeeLeaveTaken.Add(_EmployeeLeaveTaken);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysEmployeeLeaveTaken.ChangeItem(_EmployeeLeaveTaken.Key, _EmployeeLeaveTaken) == false)
										keysEmployeeLeaveTaken.Add(_EmployeeLeaveTaken);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysEmployeeLeaveTaken.Contains(_EmployeeLeaveTaken.Key))
										keysEmployeeLeaveTaken.Remove(_EmployeeLeaveTaken.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _EmployeeLeaveTaken.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _EmployeeLeaveTaken.Key)); }
	                   break;

	                case "Resource":
	                    Resource _Resource = (Resource)db.Entity;
	                    if (keysResource != null)
	                    {
							switch (db.State) {
								  case System.Data.Entity.EntityState.Added:
									  keysResource.Add(_Resource);
									break;
								case System.Data.Entity.EntityState.Modified:
									  if (keysResource.ChangeItem(_Resource.Key, _Resource) == false)
										keysResource.Add(_Resource);
									break;
								case System.Data.Entity.EntityState.Deleted:
									  if (keysResource.Contains(_Resource.Key))
										keysResource.Remove(_Resource.Key);
									break;
							}
						}
	                   if (OnRecordChanged != null) OnRecordChanged(new RecordInfo(db, _Resource.Key));
	                   if (lvHub != null) { lvHub.Clients.All.recordChanged(new RecordInfo(db, _Resource.Key)); }
	                   break;

                }
            }
        }

        static List<string> lstTblGetDefault;
        public static void LoadDefaultDataList(List<ETable> lstTblGet, LV.Core.DAL.Base.IRepository repository)
        {
            lstTblGetDefault = new List<string>();
            foreach (ETable tblName in lstTblGet)
            {
				lstTblGetDefault.Add(tblName.ToString());
                switch (tblName)
                {
                    case ETable.MedEnctrDiagnosis:
						keysMedEnctrDiagnosis = new KeyedMedEnctrDiagnosis();
						keysMedEnctrDiagnosis.LoadAll(repository);
						break;
					case ETable.ParaClinicalExamGroup:
						keysParaClinicalExamGroup = new KeyedParaClinicalExamGroup();
						keysParaClinicalExamGroup.LoadAll(repository);
						break;
					case ETable.BloodDonation:
						keysBloodDonation = new KeyedBloodDonation();
						keysBloodDonation.LoadAll(repository);
						break;
					case ETable.EmpWorkSchedule:
						keysEmpWorkSchedule = new KeyedEmpWorkSchedule();
						keysEmpWorkSchedule.LoadAll(repository);
						break;
					case ETable.MedicalClaimService:
						keysMedicalClaimService = new KeyedMedicalClaimService();
						keysMedicalClaimService.LoadAll(repository);
						break;
					case ETable.ParaClinicalReq:
						keysParaClinicalReq = new KeyedParaClinicalReq();
						keysParaClinicalReq.LoadAll(repository);
						break;
					case ETable.Donor:
						keysDonor = new KeyedDonor();
						keysDonor.LoadAll(repository);
						break;
					case ETable.ResourceLog:
						keysResourceLog = new KeyedResourceLog();
						keysResourceLog.LoadAll(repository);
						break;
					case ETable.refCertification:
						keysrefCertification = new KeyedrefCertification();
						keysrefCertification.LoadAll(repository);
						break;
					case ETable.MedicalConditionRecord:
						keysMedicalConditionRecord = new KeyedMedicalConditionRecord();
						keysMedicalConditionRecord.LoadAll(repository);
						break;
					case ETable.PatientVitalSign:
						keysPatientVitalSign = new KeyedPatientVitalSign();
						keysPatientVitalSign.LoadAll(repository);
						break;
					case ETable.DonorMedicalConditions:
						keysDonorMedicalConditions = new KeyedDonorMedicalConditions();
						keysDonorMedicalConditions.LoadAll(repository);
						break;
					case ETable.InsuranceCompany:
						keysInsuranceCompany = new KeyedInsuranceCompany();
						keysInsuranceCompany.LoadAll(repository);
						break;
					case ETable.refCityProvince:
						keysrefCityProvince = new KeyedrefCityProvince();
						keysrefCityProvince.LoadAll(repository);
						break;
					case ETable.DonorMedication:
						keysDonorMedication = new KeyedDonorMedication();
						keysDonorMedication.LoadAll(repository);
						break;
					case ETable.EventHoliday:
						keysEventHoliday = new KeyedEventHoliday();
						keysEventHoliday.LoadAll(repository);
						break;
					case ETable.RoomAllocation:
						keysRoomAllocation = new KeyedRoomAllocation();
						keysRoomAllocation.LoadAll(repository);
						break;
					case ETable.refCLMeasurement:
						keysrefCLMeasurement = new KeyedrefCLMeasurement();
						keysrefCLMeasurement.LoadAll(repository);
						break;
					case ETable.MedicalEncounter:
						keysMedicalEncounter = new KeyedMedicalEncounter();
						keysMedicalEncounter.LoadAll(repository);
						break;
					case ETable.SeparationOfBlood:
						keysSeparationOfBlood = new KeyedSeparationOfBlood();
						keysSeparationOfBlood.LoadAll(repository);
						break;
					case ETable.MedicationHistory:
						keysMedicationHistory = new KeyedMedicationHistory();
						keysMedicationHistory.LoadAll(repository);
						break;
					case ETable.TestBlood:
						keysTestBlood = new KeyedTestBlood();
						keysTestBlood.LoadAll(repository);
						break;
					case ETable.StdKSection:
						keysStdKSection = new KeyedStdKSection();
						keysStdKSection.LoadAll(repository);
						break;
					case ETable.refVitalSign:
						keysrefVitalSign = new KeyedrefVitalSign();
						keysrefVitalSign.LoadAll(repository);
						break;
					case ETable.refCommonTerm:
						keysrefCommonTerm = new KeyedrefCommonTerm();
						keysrefCommonTerm.LoadAll(repository);
						break;
					case ETable.Operations:
						keysOperations = new KeyedOperations();
						keysOperations.LoadAll(repository);
						break;
					case ETable.MiscDocuments:
						keysMiscDocuments = new KeyedMiscDocuments();
						keysMiscDocuments.LoadAll(repository);
						break;
					case ETable.AttachedDoc:
						keysAttachedDoc = new KeyedAttachedDoc();
						keysAttachedDoc.LoadAll(repository);
						break;
					case ETable.Supplier:
						keysSupplier = new KeyedSupplier();
						keysSupplier.LoadAll(repository);
						break;
					case ETable.refReligion:
						keysrefReligion = new KeyedrefReligion();
						keysrefReligion.LoadAll(repository);
						break;
					case ETable.OperationSchedule:
						keysOperationSchedule = new KeyedOperationSchedule();
						keysOperationSchedule.LoadAll(repository);
						break;
					case ETable.ChainMedicalServices:
						keysChainMedicalServices = new KeyedChainMedicalServices();
						keysChainMedicalServices.LoadAll(repository);
						break;
					case ETable.DocItem:
						keysDocItem = new KeyedDocItem();
						keysDocItem.LoadAll(repository);
						break;
					case ETable.PastPersonHistory:
						keysPastPersonHistory = new KeyedPastPersonHistory();
						keysPastPersonHistory.LoadAll(repository);
						break;
					case ETable.ParaClinicalReqDetails:
						keysParaClinicalReqDetails = new KeyedParaClinicalReqDetails();
						keysParaClinicalReqDetails.LoadAll(repository);
						break;
					case ETable.PatientAdmission:
						keysPatientAdmission = new KeyedPatientAdmission();
						keysPatientAdmission.LoadAll(repository);
						break;
					case ETable.refCountry:
						keysrefCountry = new KeyedrefCountry();
						keysrefCountry.LoadAll(repository);
						break;
					case ETable.PatientAddressHistory:
						keysPatientAddressHistory = new KeyedPatientAddressHistory();
						keysPatientAddressHistory.LoadAll(repository);
						break;
					case ETable.refPersRace:
						keysrefPersRace = new KeyedrefPersRace();
						keysrefPersRace.LoadAll(repository);
						break;
					case ETable.OpSkedDistibution:
						keysOpSkedDistibution = new KeyedOpSkedDistibution();
						keysOpSkedDistibution.LoadAll(repository);
						break;
					case ETable.PatientDiagnosticImaging:
						keysPatientDiagnosticImaging = new KeyedPatientDiagnosticImaging();
						keysPatientDiagnosticImaging.LoadAll(repository);
						break;
					case ETable.EquivMedService:
						keysEquivMedService = new KeyedEquivMedService();
						keysEquivMedService.LoadAll(repository);
						break;
					case ETable.refCurrency:
						keysrefCurrency = new KeyedrefCurrency();
						keysrefCurrency.LoadAll(repository);
						break;
					case ETable.PatientClassHistory:
						keysPatientClassHistory = new KeyedPatientClassHistory();
						keysPatientClassHistory.LoadAll(repository);
						break;
					case ETable.RescrUsedInOperation:
						keysRescrUsedInOperation = new KeyedRescrUsedInOperation();
						keysRescrUsedInOperation.LoadAll(repository);
						break;
					case ETable.TechnicalInspectionAgency:
						keysTechnicalInspectionAgency = new KeyedTechnicalInspectionAgency();
						keysTechnicalInspectionAgency.LoadAll(repository);
						break;
					case ETable.PatientClassification:
						keysPatientClassification = new KeyedPatientClassification();
						keysPatientClassification.LoadAll(repository);
						break;
					case ETable.refDepartment:
						keysrefDepartment = new KeyedrefDepartment();
						keysrefDepartment.LoadAll(repository);
						break;
					case ETable.WorkingDay:
						keysWorkingDay = new KeyedWorkingDay();
						keysWorkingDay.LoadAll(repository);
						break;
					case ETable.HIServiceItem:
						keysHIServiceItem = new KeyedHIServiceItem();
						keysHIServiceItem.LoadAll(repository);
						break;
					case ETable.WorkingSchedule:
						keysWorkingSchedule = new KeyedWorkingSchedule();
						keysWorkingSchedule.LoadAll(repository);
						break;
					case ETable.PatientMedLabTestResult:
						keysPatientMedLabTestResult = new KeyedPatientMedLabTestResult();
						keysPatientMedLabTestResult.LoadAll(repository);
						break;
					case ETable.Ward:
						keysWard = new KeyedWard();
						keysWard.LoadAll(repository);
						break;
					case ETable.refDepreciationType:
						keysrefDepreciationType = new KeyedrefDepreciationType();
						keysrefDepreciationType.LoadAll(repository);
						break;
					case ETable.DDI:
						keysDDI = new KeyedDDI();
						keysDDI.LoadAll(repository);
						break;
					case ETable.HIServiceItems:
						keysHIServiceItems = new KeyedHIServiceItems();
						keysHIServiceItems.LoadAll(repository);
						break;
					case ETable.refDiagnosis:
						keysrefDiagnosis = new KeyedrefDiagnosis();
						keysrefDiagnosis.LoadAll(repository);
						break;
					case ETable.HistoricalAuditData:
						keysHistoricalAuditData = new KeyedHistoricalAuditData();
						keysHistoricalAuditData.LoadAll(repository);
						break;
					case ETable.WardInDept:
						keysWardInDept = new KeyedWardInDept();
						keysWardInDept.LoadAll(repository);
						break;
					case ETable.PatientSpecimen:
						keysPatientSpecimen = new KeyedPatientSpecimen();
						keysPatientSpecimen.LoadAll(repository);
						break;
					case ETable.HosFeeTransDetails:
						keysHosFeeTransDetails = new KeyedHosFeeTransDetails();
						keysHosFeeTransDetails.LoadAll(repository);
						break;
					//case ETable.Trigs:
					//	keysTrigs = new KeyedTrigs();
					//	keysTrigs.LoadAll(repository);
					//	break;
					case ETable.ICD10:
						keysICD10 = new KeyedICD10();
						keysICD10.LoadAll(repository);
						break;
					case ETable.refDistrict:
						keysrefDistrict = new KeyedrefDistrict();
						keysrefDistrict.LoadAll(repository);
						break;
					case ETable.refEthnicGroup:
						keysrefEthnicGroup = new KeyedrefEthnicGroup();
						keysrefEthnicGroup.LoadAll(repository);
						break;
					case ETable.refDrugKind:
						keysrefDrugKind = new KeyedrefDrugKind();
						keysrefDrugKind.LoadAll(repository);
						break;
					case ETable.ICDChapter:
						keysICDChapter = new KeyedICDChapter();
						keysICDChapter.LoadAll(repository);
						break;
					case ETable.ICDGroup:
						keysICDGroup = new KeyedICDGroup();
						keysICDGroup.LoadAll(repository);
						break;
					case ETable.SpecifiedParaclinical:
						keysSpecifiedParaclinical = new KeyedSpecifiedParaclinical();
						keysSpecifiedParaclinical.LoadAll(repository);
						break;
					case ETable.refElthnic:
						keysrefElthnic = new KeyedrefElthnic();
						keysrefElthnic.LoadAll(repository);
						break;
					case ETable.DiagDescribeTmp:
						keysDiagDescribeTmp = new KeyedDiagDescribeTmp();
						keysDiagDescribeTmp.LoadAll(repository);
						break;
					case ETable.TestOnPatientSpecimen:
						keysTestOnPatientSpecimen = new KeyedTestOnPatientSpecimen();
						keysTestOnPatientSpecimen.LoadAll(repository);
						break;
					case ETable.refExamAction:
						keysrefExamAction = new KeyedrefExamAction();
						keysrefExamAction.LoadAll(repository);
						break;
					case ETable.PersonalProperty:
						keysPersonalProperty = new KeyedPersonalProperty();
						keysPersonalProperty.LoadAll(repository);
						break;
					case ETable.refProblem:
						keysrefProblem = new KeyedrefProblem();
						keysrefProblem.LoadAll(repository);
						break;
					case ETable.DrAdviceTmp:
						keysDrAdviceTmp = new KeyedDrAdviceTmp();
						keysDrAdviceTmp.LoadAll(repository);
						break;
					case ETable.refExamObservation:
						keysrefExamObservation = new KeyedrefExamObservation();
						keysrefExamObservation.LoadAll(repository);
						break;
					case ETable.DrMedicineAdvice:
						keysDrMedicineAdvice = new KeyedDrMedicineAdvice();
						keysDrMedicineAdvice.LoadAll(repository);
						break;
					case ETable.DrMedicineTmp:
						keysDrMedicineTmp = new KeyedDrMedicineTmp();
						keysDrMedicineTmp.LoadAll(repository);
						break;
					case ETable.refHL7:
						keysrefHL7 = new KeyedrefHL7();
						keysrefHL7.LoadAll(repository);
						break;
					case ETable.DrPrescriptionTmp:
						keysDrPrescriptionTmp = new KeyedDrPrescriptionTmp();
						keysDrPrescriptionTmp.LoadAll(repository);
						break;
					case ETable.HospitalFeeTransaction:
						keysHospitalFeeTransaction = new KeyedHospitalFeeTransaction();
						keysHospitalFeeTransaction.LoadAll(repository);
						break;
					case ETable.PatientCommonMedRecord:
						keysPatientCommonMedRecord = new KeyedPatientCommonMedRecord();
						keysPatientCommonMedRecord.LoadAll(repository);
						break;
					case ETable.HealthCareQueue:
						keysHealthCareQueue = new KeyedHealthCareQueue();
						keysHealthCareQueue.LoadAll(repository);
						break;
					case ETable.Alert:
						keysAlert = new KeyedAlert();
						keysAlert.LoadAll(repository);
						break;
					case ETable.refHumanLanguage:
						keysrefHumanLanguage = new KeyedrefHumanLanguage();
						keysrefHumanLanguage.LoadAll(repository);
						break;
					case ETable.Patient:
						keysPatient = new KeyedPatient();
						keysPatient.LoadAll(repository);
						break;
					case ETable.PatientMedRecord:
						keysPatientMedRecord = new KeyedPatientMedRecord();
						keysPatientMedRecord.LoadAll(repository);
						break;
					case ETable.refImmunization:
						keysrefImmunization = new KeyedrefImmunization();
						keysrefImmunization.LoadAll(repository);
						break;
					case ETable.refUnitOfMeasure:
						keysrefUnitOfMeasure = new KeyedrefUnitOfMeasure();
						keysrefUnitOfMeasure.LoadAll(repository);
						break;
					case ETable.PersonRole:
						keysPersonRole = new KeyedPersonRole();
						keysPersonRole.LoadAll(repository);
						break;
					case ETable.DrPrescriptionTmps:
						keysDrPrescriptionTmps = new KeyedDrPrescriptionTmps();
						keysDrPrescriptionTmps.LoadAll(repository);
						break;
					case ETable.refInstUniversity:
						keysrefInstUniversity = new KeyedrefInstUniversity();
						keysrefInstUniversity.LoadAll(repository);
						break;
					case ETable.Appointment:
						keysAppointment = new KeyedAppointment();
						keysAppointment.LoadAll(repository);
						break;
					case ETable.refJobBand:
						keysrefJobBand = new KeyedrefJobBand();
						keysrefJobBand.LoadAll(repository);
						break;
					case ETable.ASPNetRole:
						keysASPNetRole = new KeyedASPNetRole();
						keysASPNetRole.LoadAll(repository);
						break;
					case ETable.MedicalBill:
						keysMedicalBill = new KeyedMedicalBill();
						keysMedicalBill.LoadAll(repository);
						break;
					case ETable.refInsurKind:
						keysrefInsurKind = new KeyedrefInsurKind();
						keysrefInsurKind.LoadAll(repository);
						break;
					case ETable.ASPNetRolePermission:
						keysASPNetRolePermission = new KeyedASPNetRolePermission();
						keysASPNetRolePermission.LoadAll(repository);
						break;
					case ETable.PatientProblem:
						keysPatientProblem = new KeyedPatientProblem();
						keysPatientProblem.LoadAll(repository);
						break;
					case ETable.MedicalBills:
						keysMedicalBills = new KeyedMedicalBills();
						keysMedicalBills.LoadAll(repository);
						break;
					case ETable.refInternalReceiptType:
						keysrefInternalReceiptType = new KeyedrefInternalReceiptType();
						keysrefInternalReceiptType.LoadAll(repository);
						break;
					case ETable.SocialAndHealthInsurance:
						keysSocialAndHealthInsurance = new KeyedSocialAndHealthInsurance();
						keysSocialAndHealthInsurance.LoadAll(repository);
						break;
					case ETable.ASPNetToken:
						keysASPNetToken = new KeyedASPNetToken();
						keysASPNetToken.LoadAll(repository);
						break;
					case ETable.MedRecOutline:
						keysMedRecOutline = new KeyedMedRecOutline();
						keysMedRecOutline.LoadAll(repository);
						break;
					case ETable.AdmNoTemp:
						keysAdmNoTemp = new KeyedAdmNoTemp();
						keysAdmNoTemp.LoadAll(repository);
						break;
					case ETable.ASPNetUser:
						keysASPNetUser = new KeyedASPNetUser();
						keysASPNetUser.LoadAll(repository);
						break;
					case ETable.MedRecTmp:
						keysMedRecTmp = new KeyedMedRecTmp();
						keysMedRecTmp.LoadAll(repository);
						break;
					case ETable.MedicalServicePackage:
						keysMedicalServicePackage = new KeyedMedicalServicePackage();
						keysMedicalServicePackage.LoadAll(repository);
						break;
					case ETable.refItemType:
						keysrefItemType = new KeyedrefItemType();
						keysrefItemType.LoadAll(repository);
						break;
					case ETable.PatientPVID:
						keysPatientPVID = new KeyedPatientPVID();
						keysPatientPVID.LoadAll(repository);
						break;
					case ETable.MedSerInDept:
						keysMedSerInDept = new KeyedMedSerInDept();
						keysMedSerInDept.LoadAll(repository);
						break;
					case ETable.refJobTitle:
						keysrefJobTitle = new KeyedrefJobTitle();
						keysrefJobTitle.LoadAll(repository);
						break;
					case ETable.MRParagraph:
						keysMRParagraph = new KeyedMRParagraph();
						keysMRParagraph.LoadAll(repository);
						break;
					case ETable.refLimVitalSign:
						keysrefLimVitalSign = new KeyedrefLimVitalSign();
						keysrefLimVitalSign.LoadAll(repository);
						break;
					case ETable.WorkPlace:
						keysWorkPlace = new KeyedWorkPlace();
						keysWorkPlace.LoadAll(repository);
						break;
					case ETable.GenericSocialNetwork:
						keysGenericSocialNetwork = new KeyedGenericSocialNetwork();
						keysGenericSocialNetwork.LoadAll(repository);
						break;
					case ETable.MOHServiceItems:
						keysMOHServiceItems = new KeyedMOHServiceItems();
						keysMOHServiceItems.LoadAll(repository);
						break;
					case ETable.refEducationalLevel:
						keysrefEducationalLevel = new KeyedrefEducationalLevel();
						keysrefEducationalLevel.LoadAll(repository);
						break;
					case ETable.ASPNetUserClaims:
						keysASPNetUserClaims = new KeyedASPNetUserClaims();
						keysASPNetUserClaims.LoadAll(repository);
						break;
					case ETable.AppliedMedStandard:
						keysAppliedMedStandard = new KeyedAppliedMedStandard();
						keysAppliedMedStandard.LoadAll(repository);
						break;
					case ETable.ASPNetUserLogin:
						keysASPNetUserLogin = new KeyedASPNetUserLogin();
						keysASPNetUserLogin.LoadAll(repository);
						break;
					case ETable.ArchitectureResources:
						keysArchitectureResources = new KeyedArchitectureResources();
						keysArchitectureResources.LoadAll(repository);
						break;
					case ETable.PhysicalExamination:
						keysPhysicalExamination = new KeyedPhysicalExamination();
						keysPhysicalExamination.LoadAll(repository);
						break;
					case ETable.MRSection:
						keysMRSection = new KeyedMRSection();
						keysMRSection.LoadAll(repository);
						break;
					case ETable.PatientInvoices:
						keysPatientInvoices = new KeyedPatientInvoices();
						keysPatientInvoices.LoadAll(repository);
						break;
					case ETable.AssignMedEquip:
						keysAssignMedEquip = new KeyedAssignMedEquip();
						keysAssignMedEquip.LoadAll(repository);
						break;
					case ETable.refDischargeDisposition:
						keysrefDischargeDisposition = new KeyedrefDischargeDisposition();
						keysrefDischargeDisposition.LoadAll(repository);
						break;
					case ETable.ASPNetUserRole:
						keysASPNetUserRole = new KeyedASPNetUserRole();
						keysASPNetUserRole.LoadAll(repository);
						break;
					case ETable.MRSectionOutline:
						keysMRSectionOutline = new KeyedMRSectionOutline();
						keysMRSectionOutline.LoadAll(repository);
						break;
					case ETable.SpecMedRecTmp:
						keysSpecMedRecTmp = new KeyedSpecMedRecTmp();
						keysSpecMedRecTmp.LoadAll(repository);
						break;
					case ETable.HealthInsurance:
						keysHealthInsurance = new KeyedHealthInsurance();
						keysHealthInsurance.LoadAll(repository);
						break;
					case ETable.Prescription:
						keysPrescription = new KeyedPrescription();
						keysPrescription.LoadAll(repository);
						break;
					case ETable.PrivilegeRole:
						keysPrivilegeRole = new KeyedPrivilegeRole();
						keysPrivilegeRole.LoadAll(repository);
						break;
					case ETable.AcPrincDrug:
						keysAcPrincDrug = new KeyedAcPrincDrug();
						keysAcPrincDrug.LoadAll(repository);
						break;
					case ETable.InsuranceBeneficiary:
						keysInsuranceBeneficiary = new KeyedInsuranceBeneficiary();
						keysInsuranceBeneficiary.LoadAll(repository);
						break;
					case ETable.AntagonistDrug:
						keysAntagonistDrug = new KeyedAntagonistDrug();
						keysAntagonistDrug.LoadAll(repository);
						break;
					case ETable.PatientTransaction:
						keysPatientTransaction = new KeyedPatientTransaction();
						keysPatientTransaction.LoadAll(repository);
						break;
					case ETable.BedInRoom:
						keysBedInRoom = new KeyedBedInRoom();
						keysBedInRoom.LoadAll(repository);
						break;
					case ETable.Realms:
						keysRealms = new KeyedRealms();
						keysRealms.LoadAll(repository);
						break;
					case ETable.refPermission:
						keysrefPermission = new KeyedrefPermission();
						keysrefPermission.LoadAll(repository);
						break;
					case ETable.InsuranceInterests:
						keysInsuranceInterests = new KeyedInsuranceInterests();
						keysInsuranceInterests.LoadAll(repository);
						break;
					case ETable.Employee:
						keysEmployee = new KeyedEmployee();
						keysEmployee.LoadAll(repository);
						break;
					case ETable.ContactDetails:
						keysContactDetails = new KeyedContactDetails();
						keysContactDetails.LoadAll(repository);
						break;
					case ETable.InsuranceRegQueue:
						keysInsuranceRegQueue = new KeyedInsuranceRegQueue();
						keysInsuranceRegQueue.LoadAll(repository);
						break;
					case ETable.refMedcnAdminRoute:
						keysrefMedcnAdminRoute = new KeyedrefMedcnAdminRoute();
						keysrefMedcnAdminRoute.LoadAll(repository);
						break;
					case ETable.ServerLog:
						keysServerLog = new KeyedServerLog();
						keysServerLog.LoadAll(repository);
						break;
					case ETable.refMedcnVehicleForm:
						keysrefMedcnVehicleForm = new KeyedrefMedcnVehicleForm();
						keysrefMedcnVehicleForm.LoadAll(repository);
						break;
					case ETable.Contract:
						keysContract = new KeyedContract();
						keysContract.LoadAll(repository);
						break;
					case ETable.PromotionPlan:
						keysPromotionPlan = new KeyedPromotionPlan();
						keysPromotionPlan.LoadAll(repository);
						break;
					case ETable.refMedEquipResourceType:
						keysrefMedEquipResourceType = new KeyedrefMedEquipResourceType();
						keysrefMedEquipResourceType.LoadAll(repository);
						break;
					case ETable.ContractChange:
						keysContractChange = new KeyedContractChange();
						keysContractChange.LoadAll(repository);
						break;
					case ETable.Session:
						keysSession = new KeyedSession();
						keysSession.LoadAll(repository);
						break;
					case ETable.PrescriptionDetail:
						keysPrescriptionDetail = new KeyedPrescriptionDetail();
						keysPrescriptionDetail.LoadAll(repository);
						break;
					case ETable.ClinicalTrial:
						keysClinicalTrial = new KeyedClinicalTrial();
						keysClinicalTrial.LoadAll(repository);
						break;
					case ETable.refLookup:
						keysrefLookup = new KeyedrefLookup();
						keysrefLookup.LoadAll(repository);
						break;
					case ETable.PromotionService:
						keysPromotionService = new KeyedPromotionService();
						keysPromotionService.LoadAll(repository);
						break;
					case ETable.ContractDocument:
						keysContractDocument = new KeyedContractDocument();
						keysContractDocument.LoadAll(repository);
						break;
					case ETable.NetworkGuestAccount:
						keysNetworkGuestAccount = new KeyedNetworkGuestAccount();
						keysNetworkGuestAccount.LoadAll(repository);
						break;
					case ETable.Quotation:
						keysQuotation = new KeyedQuotation();
						keysQuotation.LoadAll(repository);
						break;
					case ETable.refMedHisIndex:
						keysrefMedHisIndex = new KeyedrefMedHisIndex();
						keysrefMedHisIndex.LoadAll(repository);
						break;
					case ETable.ClinicalTrialResult:
						keysClinicalTrialResult = new KeyedClinicalTrialResult();
						keysClinicalTrialResult.LoadAll(repository);
						break;
					case ETable.DHCRoomBlock:
						keysDHCRoomBlock = new KeyedDHCRoomBlock();
						keysDHCRoomBlock.LoadAll(repository);
						break;
					case ETable.refMedicalCondition:
						keysrefMedicalCondition = new KeyedrefMedicalCondition();
						keysrefMedicalCondition.LoadAll(repository);
						break;
					case ETable.DisposableMDResource:
						keysDisposableMDResource = new KeyedDisposableMDResource();
						keysDisposableMDResource.LoadAll(repository);
						break;
					case ETable.OnlineQueue:
						keysOnlineQueue = new KeyedOnlineQueue();
						keysOnlineQueue.LoadAll(repository);
						break;
					case ETable.refMedicalServiceType:
						keysrefMedicalServiceType = new KeyedrefMedicalServiceType();
						keysrefMedicalServiceType.LoadAll(repository);
						break;
					case ETable.Drug:
						keysDrug = new KeyedDrug();
						keysDrug.LoadAll(repository);
						break;
					case ETable.RegistrationInfo:
						keysRegistrationInfo = new KeyedRegistrationInfo();
						keysRegistrationInfo.LoadAll(repository);
						break;
					case ETable.refQualification:
						keysrefQualification = new KeyedrefQualification();
						keysrefQualification.LoadAll(repository);
						break;
					case ETable.PrescriptionHistory:
						keysPrescriptionHistory = new KeyedPrescriptionHistory();
						keysPrescriptionHistory.LoadAll(repository);
						break;
					case ETable.refPersGender:
						keysrefPersGender = new KeyedrefPersGender();
						keysrefPersGender.LoadAll(repository);
						break;
					case ETable.PrivacyClass:
						keysPrivacyClass = new KeyedPrivacyClass();
						keysPrivacyClass.LoadAll(repository);
						break;
					case ETable.ResearchPartnership:
						keysResearchPartnership = new KeyedResearchPartnership();
						keysResearchPartnership.LoadAll(repository);
						break;
					case ETable.Person:
						keysPerson = new KeyedPerson();
						keysPerson.LoadAll(repository);
						break;
					case ETable.PtCodeCheckDigitTmp:
						keysPtCodeCheckDigitTmp = new KeyedPtCodeCheckDigitTmp();
						keysPtCodeCheckDigitTmp.LoadAll(repository);
						break;
					case ETable.BodyRegion:
						keysBodyRegion = new KeyedBodyRegion();
						keysBodyRegion.LoadAll(repository);
						break;
					case ETable.RxHoldConsultation:
						keysRxHoldConsultation = new KeyedRxHoldConsultation();
						keysRxHoldConsultation.LoadAll(repository);
						break;
					case ETable.RegQueue:
						keysRegQueue = new KeyedRegQueue();
						keysRegQueue.LoadAll(repository);
						break;
					case ETable.EquipHistory:
						keysEquipHistory = new KeyedEquipHistory();
						keysEquipHistory.LoadAll(repository);
						break;
					case ETable.ClinicalIndicatorType:
						keysClinicalIndicatorType = new KeyedClinicalIndicatorType();
						keysClinicalIndicatorType.LoadAll(repository);
						break;
					case ETable.ExamMaintenanceHistory:
						keysExamMaintenanceHistory = new KeyedExamMaintenanceHistory();
						keysExamMaintenanceHistory.LoadAll(repository);
						break;
					case ETable.UserGroup:
						keysUserGroup = new KeyedUserGroup();
						keysUserGroup.LoadAll(repository);
						break;
					case ETable.MedicalDiagnosticMethod:
						keysMedicalDiagnosticMethod = new KeyedMedicalDiagnosticMethod();
						keysMedicalDiagnosticMethod.LoadAll(repository);
						break;
					case ETable.DrugConfign:
						keysDrugConfign = new KeyedDrugConfign();
						keysDrugConfign.LoadAll(repository);
						break;
					case ETable.SymptomIndicator:
						keysSymptomIndicator = new KeyedSymptomIndicator();
						keysSymptomIndicator.LoadAll(repository);
						break;
					case ETable.UsersInGroup:
						keysUsersInGroup = new KeyedUsersInGroup();
						keysUsersInGroup.LoadAll(repository);
						break;
					case ETable.MedicalTestProcedure:
						keysMedicalTestProcedure = new KeyedMedicalTestProcedure();
						keysMedicalTestProcedure.LoadAll(repository);
						break;
					case ETable.AdvancedSpecialist:
						keysAdvancedSpecialist = new KeyedAdvancedSpecialist();
						keysAdvancedSpecialist.LoadAll(repository);
						break;
					case ETable.ReminderNotices:
						keysReminderNotices = new KeyedReminderNotices();
						keysReminderNotices.LoadAll(repository);
						break;
					case ETable.ForeignExchange:
						keysForeignExchange = new KeyedForeignExchange();
						keysForeignExchange.LoadAll(repository);
						break;
					case ETable.DrugInDepartment:
						keysDrugInDepartment = new KeyedDrugInDepartment();
						keysDrugInDepartment.LoadAll(repository);
						break;
					case ETable.HosRanking:
						keysHosRanking = new KeyedHosRanking();
						keysHosRanking.LoadAll(repository);
						break;
					case ETable.AllergyIntolerance:
						keysAllergyIntolerance = new KeyedAllergyIntolerance();
						keysAllergyIntolerance.LoadAll(repository);
						break;
					case ETable.EduLevel:
						keysEduLevel = new KeyedEduLevel();
						keysEduLevel.LoadAll(repository);
						break;
					case ETable.refRole:
						keysrefRole = new KeyedrefRole();
						keysrefRole.LoadAll(repository);
						break;
					case ETable.MedicalServiceItem:
						keysMedicalServiceItem = new KeyedMedicalServiceItem();
						keysMedicalServiceItem.LoadAll(repository);
						break;
					case ETable.Application:
						keysApplication = new KeyedApplication();
						keysApplication.LoadAll(repository);
						break;
					case ETable.DrugPrice:
						keysDrugPrice = new KeyedDrugPrice();
						keysDrugPrice.LoadAll(repository);
						break;
					case ETable.refShelfDrugLocation:
						keysrefShelfDrugLocation = new KeyedrefShelfDrugLocation();
						keysrefShelfDrugLocation.LoadAll(repository);
						break;
					case ETable.HCProvider:
						keysHCProvider = new KeyedHCProvider();
						keysHCProvider.LoadAll(repository);
						break;
					case ETable.MedImagingRepository:
						keysMedImagingRepository = new KeyedMedImagingRepository();
						keysMedImagingRepository.LoadAll(repository);
						break;
					case ETable.MedImagingTest:
						keysMedImagingTest = new KeyedMedImagingTest();
						keysMedImagingTest.LoadAll(repository);
						break;
					case ETable.DeathSituationInfo:
						keysDeathSituationInfo = new KeyedDeathSituationInfo();
						keysDeathSituationInfo.LoadAll(repository);
						break;
					case ETable.refShift:
						keysrefShift = new KeyedrefShift();
						keysrefShift.LoadAll(repository);
						break;
					case ETable.UserAccount:
						keysUserAccount = new KeyedUserAccount();
						keysUserAccount.LoadAll(repository);
						break;
					case ETable.MedImagingTestItems:
						keysMedImagingTestItems = new KeyedMedImagingTestItems();
						keysMedImagingTestItems.LoadAll(repository);
						break;
					case ETable.InOutType:
						keysInOutType = new KeyedInOutType();
						keysInOutType.LoadAll(repository);
						break;
					case ETable.InOutwardDrug:
						keysInOutwardDrug = new KeyedInOutwardDrug();
						keysInOutwardDrug.LoadAll(repository);
						break;
					case ETable.MedLabRepository:
						keysMedLabRepository = new KeyedMedLabRepository();
						keysMedLabRepository.LoadAll(repository);
						break;
					case ETable.InputMaskSetting:
						keysInputMaskSetting = new KeyedInputMaskSetting();
						keysInputMaskSetting.LoadAll(repository);
						break;
					case ETable.refSIPrefix:
						keysrefSIPrefix = new KeyedrefSIPrefix();
						keysrefSIPrefix.LoadAll(repository);
						break;
					case ETable.MesrtConv:
						keysMesrtConv = new KeyedMesrtConv();
						keysMesrtConv.LoadAll(repository);
						break;
					case ETable.LotNumber:
						keysLotNumber = new KeyedLotNumber();
						keysLotNumber.LoadAll(repository);
						break;
					case ETable.FamilyHistory:
						keysFamilyHistory = new KeyedFamilyHistory();
						keysFamilyHistory.LoadAll(repository);
						break;
					case ETable.MedLabTest:
						keysMedLabTest = new KeyedMedLabTest();
						keysMedLabTest.LoadAll(repository);
						break;
					case ETable.refSocialHisSeverity:
						keysrefSocialHisSeverity = new KeyedrefSocialHisSeverity();
						keysrefSocialHisSeverity.LoadAll(repository);
						break;
					case ETable.refSpecimenType:
						keysrefSpecimenType = new KeyedrefSpecimenType();
						keysrefSpecimenType.LoadAll(repository);
						break;
					case ETable.Employeer:
						keysEmployeer = new KeyedEmployeer();
						keysEmployeer.LoadAll(repository);
						break;
					case ETable.HCStakeholder:
						keysHCStakeholder = new KeyedHCStakeholder();
						keysHCStakeholder.LoadAll(repository);
						break;
					case ETable.PharmaceuticalCompany:
						keysPharmaceuticalCompany = new KeyedPharmaceuticalCompany();
						keysPharmaceuticalCompany.LoadAll(repository);
						break;
					case ETable.refStoreHouse:
						keysrefStoreHouse = new KeyedrefStoreHouse();
						keysrefStoreHouse.LoadAll(repository);
						break;
					case ETable.HIAdmission:
						keysHIAdmission = new KeyedHIAdmission();
						keysHIAdmission.LoadAll(repository);
						break;
					case ETable.HCRoomBlock:
						keysHCRoomBlock = new KeyedHCRoomBlock();
						keysHCRoomBlock.LoadAll(repository);
						break;
					case ETable.refAcademicTile:
						keysrefAcademicTile = new KeyedrefAcademicTile();
						keysrefAcademicTile.LoadAll(repository);
						break;
					case ETable.JobHistory:
						keysJobHistory = new KeyedJobHistory();
						keysJobHistory.LoadAll(repository);
						break;
					case ETable.PriceList:
						keysPriceList = new KeyedPriceList();
						keysPriceList.LoadAll(repository);
						break;
					case ETable.HospitalizationHistory:
						keysHospitalizationHistory = new KeyedHospitalizationHistory();
						keysHospitalizationHistory.LoadAll(repository);
						break;
					case ETable.refFAMRelationship:
						keysrefFAMRelationship = new KeyedrefFAMRelationship();
						keysrefFAMRelationship.LoadAll(repository);
						break;
					case ETable.refTimeFrame:
						keysrefTimeFrame = new KeyedrefTimeFrame();
						keysrefTimeFrame.LoadAll(repository);
						break;
					case ETable.HospitalSpecialist:
						keysHospitalSpecialist = new KeyedHospitalSpecialist();
						keysHospitalSpecialist.LoadAll(repository);
						break;
					case ETable.refActiviePrinciple:
						keysrefActiviePrinciple = new KeyedrefActiviePrinciple();
						keysrefActiviePrinciple.LoadAll(repository);
						break;
					case ETable.refAdmissionType:
						keysrefAdmissionType = new KeyedrefAdmissionType();
						keysrefAdmissionType.LoadAll(repository);
						break;
					case ETable.MedicalEquimentsResources:
						keysMedicalEquimentsResources = new KeyedMedicalEquimentsResources();
						keysMedicalEquimentsResources.LoadAll(repository);
						break;
					case ETable.refAdmReferralType:
						keysrefAdmReferralType = new KeyedrefAdmReferralType();
						keysrefAdmReferralType.LoadAll(repository);
						break;
					case ETable.ProvidableDrugs:
						keysProvidableDrugs = new KeyedProvidableDrugs();
						keysProvidableDrugs.LoadAll(repository);
						break;
					case ETable.refAllergyCategory:
						keysrefAllergyCategory = new KeyedrefAllergyCategory();
						keysrefAllergyCategory.LoadAll(repository);
						break;
					case ETable.refTransactionType:
						keysrefTransactionType = new KeyedrefTransactionType();
						keysrefTransactionType.LoadAll(repository);
						break;
					case ETable.JobModel:
						keysJobModel = new KeyedJobModel();
						keysJobModel.LoadAll(repository);
						break;
					case ETable.AssignmentSchedule:
						keysAssignmentSchedule = new KeyedAssignmentSchedule();
						keysAssignmentSchedule.LoadAll(repository);
						break;
					case ETable.refOccupation:
						keysrefOccupation = new KeyedrefOccupation();
						keysrefOccupation.LoadAll(repository);
						break;
					case ETable.BusySchedule:
						keysBusySchedule = new KeyedBusySchedule();
						keysBusySchedule.LoadAll(repository);
						break;
					//case ETable.AdmNoTempHolding:
					//	keysAdmNoTempHolding = new KeyedAdmNoTempHolding();
					//	keysAdmNoTempHolding.LoadAll(repository);
					//	break;
					case ETable.refTypeAbsent:
						keysrefTypeAbsent = new KeyedrefTypeAbsent();
						keysrefTypeAbsent.LoadAll(repository);
						break;
					case ETable.refAllergyIndex:
						keysrefAllergyIndex = new KeyedrefAllergyIndex();
						keysrefAllergyIndex.LoadAll(repository);
						break;
					case ETable.LanguageLevel:
						keysLanguageLevel = new KeyedLanguageLevel();
						keysLanguageLevel.LoadAll(repository);
						break;
					case ETable.refPersMaritalStatus:
						keysrefPersMaritalStatus = new KeyedrefPersMaritalStatus();
						keysrefPersMaritalStatus.LoadAll(repository);
						break;
					case ETable.Organization:
						keysOrganization = new KeyedOrganization();
						keysOrganization.LoadAll(repository);
						break;
					case ETable.EmpAllocation:
						keysEmpAllocation = new KeyedEmpAllocation();
						keysEmpAllocation.LoadAll(repository);
						break;
					case ETable.NextOfKins:
						keysNextOfKins = new KeyedNextOfKins();
						keysNextOfKins.LoadAll(repository);
						break;
					case ETable.HospitalizationHistoryDetails:
						keysHospitalizationHistoryDetails = new KeyedHospitalizationHistoryDetails();
						keysHospitalizationHistoryDetails.LoadAll(repository);
						break;
					case ETable.refCareerMOH:
						keysrefCareerMOH = new KeyedrefCareerMOH();
						keysrefCareerMOH.LoadAll(repository);
						break;
					case ETable.refAnnTemp:
						keysrefAnnTemp = new KeyedrefAnnTemp();
						keysrefAnnTemp.LoadAll(repository);
						break;
					case ETable.PatientBed:
						keysPatientBed = new KeyedPatientBed();
						keysPatientBed.LoadAll(repository);
						break;
					case ETable.ImmunizationHistory:
						keysImmunizationHistory = new KeyedImmunizationHistory();
						keysImmunizationHistory.LoadAll(repository);
						break;
					case ETable.refAppConfig:
						keysrefAppConfig = new KeyedrefAppConfig();
						keysrefAppConfig.LoadAll(repository);
						break;
					case ETable.EmployeeAnnualLeave:
						keysEmployeeAnnualLeave = new KeyedEmployeeAnnualLeave();
						keysEmployeeAnnualLeave.LoadAll(repository);
						break;
					case ETable.refWard:
						keysrefWard = new KeyedrefWard();
						keysrefWard.LoadAll(repository);
						break;
					case ETable.PatientBedFeatures:
						keysPatientBedFeatures = new KeyedPatientBedFeatures();
						keysPatientBedFeatures.LoadAll(repository);
						break;
					case ETable.refBloodType:
						keysrefBloodType = new KeyedrefBloodType();
						keysrefBloodType.LoadAll(repository);
						break;
					case ETable.PatientInBedRoom:
						keysPatientInBedRoom = new KeyedPatientInBedRoom();
						keysPatientInBedRoom.LoadAll(repository);
						break;
					case ETable.MedLabTestItems:
						keysMedLabTestItems = new KeyedMedLabTestItems();
						keysMedLabTestItems.LoadAll(repository);
						break;
					case ETable.ScheduleDoingTaskLog:
						keysScheduleDoingTaskLog = new KeyedScheduleDoingTaskLog();
						keysScheduleDoingTaskLog.LoadAll(repository);
						break;
					case ETable.refProviderType:
						keysrefProviderType = new KeyedrefProviderType();
						keysrefProviderType.LoadAll(repository);
						break;
					case ETable.Bloodbank:
						keysBloodbank = new KeyedBloodbank();
						keysBloodbank.LoadAll(repository);
						break;
					case ETable.OccCareerMOH:
						keysOccCareerMOH = new KeyedOccCareerMOH();
						keysOccCareerMOH.LoadAll(repository);
						break;
					case ETable.EmployeeLeaveTaken:
						keysEmployeeLeaveTaken = new KeyedEmployeeLeaveTaken();
						keysEmployeeLeaveTaken.LoadAll(repository);
						break;
					case ETable.Resource:
						keysResource = new KeyedResource();
						keysResource.LoadAll(repository);
						break;

                }
            }
        }

        public static void LoadTable(string tableName, LV.Core.DAL.Base.IRepository repository)
        {
            switch (tableName)
            {
                case "MedEnctrDiagnosis":
					keysMedEnctrDiagnosis = new KeyedMedEnctrDiagnosis();
					keysMedEnctrDiagnosis.LoadAll(repository);
					break;
				case "ParaClinicalExamGroup":
					keysParaClinicalExamGroup = new KeyedParaClinicalExamGroup();
					keysParaClinicalExamGroup.LoadAll(repository);
					break;
				case "BloodDonation":
					keysBloodDonation = new KeyedBloodDonation();
					keysBloodDonation.LoadAll(repository);
					break;
				case "EmpWorkSchedule":
					keysEmpWorkSchedule = new KeyedEmpWorkSchedule();
					keysEmpWorkSchedule.LoadAll(repository);
					break;
				case "MedicalClaimService":
					keysMedicalClaimService = new KeyedMedicalClaimService();
					keysMedicalClaimService.LoadAll(repository);
					break;
				case "ParaClinicalReq":
					keysParaClinicalReq = new KeyedParaClinicalReq();
					keysParaClinicalReq.LoadAll(repository);
					break;
				case "Donor":
					keysDonor = new KeyedDonor();
					keysDonor.LoadAll(repository);
					break;
				case "ResourceLog":
					keysResourceLog = new KeyedResourceLog();
					keysResourceLog.LoadAll(repository);
					break;
				case "refCertification":
					keysrefCertification = new KeyedrefCertification();
					keysrefCertification.LoadAll(repository);
					break;
				case "MedicalConditionRecord":
					keysMedicalConditionRecord = new KeyedMedicalConditionRecord();
					keysMedicalConditionRecord.LoadAll(repository);
					break;
				case "PatientVitalSign":
					keysPatientVitalSign = new KeyedPatientVitalSign();
					keysPatientVitalSign.LoadAll(repository);
					break;
				case "DonorMedicalConditions":
					keysDonorMedicalConditions = new KeyedDonorMedicalConditions();
					keysDonorMedicalConditions.LoadAll(repository);
					break;
				case "InsuranceCompany":
					keysInsuranceCompany = new KeyedInsuranceCompany();
					keysInsuranceCompany.LoadAll(repository);
					break;
				case "refCityProvince":
					keysrefCityProvince = new KeyedrefCityProvince();
					keysrefCityProvince.LoadAll(repository);
					break;
				case "DonorMedication":
					keysDonorMedication = new KeyedDonorMedication();
					keysDonorMedication.LoadAll(repository);
					break;
				case "EventHoliday":
					keysEventHoliday = new KeyedEventHoliday();
					keysEventHoliday.LoadAll(repository);
					break;
				case "RoomAllocation":
					keysRoomAllocation = new KeyedRoomAllocation();
					keysRoomAllocation.LoadAll(repository);
					break;
				case "refCLMeasurement":
					keysrefCLMeasurement = new KeyedrefCLMeasurement();
					keysrefCLMeasurement.LoadAll(repository);
					break;
				case "MedicalEncounter":
					keysMedicalEncounter = new KeyedMedicalEncounter();
					keysMedicalEncounter.LoadAll(repository);
					break;
				case "SeparationOfBlood":
					keysSeparationOfBlood = new KeyedSeparationOfBlood();
					keysSeparationOfBlood.LoadAll(repository);
					break;
				case "MedicationHistory":
					keysMedicationHistory = new KeyedMedicationHistory();
					keysMedicationHistory.LoadAll(repository);
					break;
				case "TestBlood":
					keysTestBlood = new KeyedTestBlood();
					keysTestBlood.LoadAll(repository);
					break;
				case "StdKSection":
					keysStdKSection = new KeyedStdKSection();
					keysStdKSection.LoadAll(repository);
					break;
				case "refVitalSign":
					keysrefVitalSign = new KeyedrefVitalSign();
					keysrefVitalSign.LoadAll(repository);
					break;
				case "refCommonTerm":
					keysrefCommonTerm = new KeyedrefCommonTerm();
					keysrefCommonTerm.LoadAll(repository);
					break;
				case "Operations":
					keysOperations = new KeyedOperations();
					keysOperations.LoadAll(repository);
					break;
				case "MiscDocuments":
					keysMiscDocuments = new KeyedMiscDocuments();
					keysMiscDocuments.LoadAll(repository);
					break;
				case "AttachedDoc":
					keysAttachedDoc = new KeyedAttachedDoc();
					keysAttachedDoc.LoadAll(repository);
					break;
				case "Supplier":
					keysSupplier = new KeyedSupplier();
					keysSupplier.LoadAll(repository);
					break;
				case "refReligion":
					keysrefReligion = new KeyedrefReligion();
					keysrefReligion.LoadAll(repository);
					break;
				case "OperationSchedule":
					keysOperationSchedule = new KeyedOperationSchedule();
					keysOperationSchedule.LoadAll(repository);
					break;
				case "ChainMedicalServices":
					keysChainMedicalServices = new KeyedChainMedicalServices();
					keysChainMedicalServices.LoadAll(repository);
					break;
				case "DocItem":
					keysDocItem = new KeyedDocItem();
					keysDocItem.LoadAll(repository);
					break;
				case "PastPersonHistory":
					keysPastPersonHistory = new KeyedPastPersonHistory();
					keysPastPersonHistory.LoadAll(repository);
					break;
				case "ParaClinicalReqDetails":
					keysParaClinicalReqDetails = new KeyedParaClinicalReqDetails();
					keysParaClinicalReqDetails.LoadAll(repository);
					break;
				case "PatientAdmission":
					keysPatientAdmission = new KeyedPatientAdmission();
					keysPatientAdmission.LoadAll(repository);
					break;
				case "refCountry":
					keysrefCountry = new KeyedrefCountry();
					keysrefCountry.LoadAll(repository);
					break;
				case "PatientAddressHistory":
					keysPatientAddressHistory = new KeyedPatientAddressHistory();
					keysPatientAddressHistory.LoadAll(repository);
					break;
				case "refPersRace":
					keysrefPersRace = new KeyedrefPersRace();
					keysrefPersRace.LoadAll(repository);
					break;
				case "OpSkedDistibution":
					keysOpSkedDistibution = new KeyedOpSkedDistibution();
					keysOpSkedDistibution.LoadAll(repository);
					break;
				case "PatientDiagnosticImaging":
					keysPatientDiagnosticImaging = new KeyedPatientDiagnosticImaging();
					keysPatientDiagnosticImaging.LoadAll(repository);
					break;
				case "EquivMedService":
					keysEquivMedService = new KeyedEquivMedService();
					keysEquivMedService.LoadAll(repository);
					break;
				case "refCurrency":
					keysrefCurrency = new KeyedrefCurrency();
					keysrefCurrency.LoadAll(repository);
					break;
				case "PatientClassHistory":
					keysPatientClassHistory = new KeyedPatientClassHistory();
					keysPatientClassHistory.LoadAll(repository);
					break;
				case "RescrUsedInOperation":
					keysRescrUsedInOperation = new KeyedRescrUsedInOperation();
					keysRescrUsedInOperation.LoadAll(repository);
					break;
				case "TechnicalInspectionAgency":
					keysTechnicalInspectionAgency = new KeyedTechnicalInspectionAgency();
					keysTechnicalInspectionAgency.LoadAll(repository);
					break;
				case "PatientClassification":
					keysPatientClassification = new KeyedPatientClassification();
					keysPatientClassification.LoadAll(repository);
					break;
				case "refDepartment":
					keysrefDepartment = new KeyedrefDepartment();
					keysrefDepartment.LoadAll(repository);
					break;
				case "WorkingDay":
					keysWorkingDay = new KeyedWorkingDay();
					keysWorkingDay.LoadAll(repository);
					break;
				case "HIServiceItem":
					keysHIServiceItem = new KeyedHIServiceItem();
					keysHIServiceItem.LoadAll(repository);
					break;
				case "WorkingSchedule":
					keysWorkingSchedule = new KeyedWorkingSchedule();
					keysWorkingSchedule.LoadAll(repository);
					break;
				case "PatientMedLabTestResult":
					keysPatientMedLabTestResult = new KeyedPatientMedLabTestResult();
					keysPatientMedLabTestResult.LoadAll(repository);
					break;
				case "Ward":
					keysWard = new KeyedWard();
					keysWard.LoadAll(repository);
					break;
				case "refDepreciationType":
					keysrefDepreciationType = new KeyedrefDepreciationType();
					keysrefDepreciationType.LoadAll(repository);
					break;
				case "DDI":
					keysDDI = new KeyedDDI();
					keysDDI.LoadAll(repository);
					break;
				case "HIServiceItems":
					keysHIServiceItems = new KeyedHIServiceItems();
					keysHIServiceItems.LoadAll(repository);
					break;
				case "refDiagnosis":
					keysrefDiagnosis = new KeyedrefDiagnosis();
					keysrefDiagnosis.LoadAll(repository);
					break;
				case "HistoricalAuditData":
					keysHistoricalAuditData = new KeyedHistoricalAuditData();
					keysHistoricalAuditData.LoadAll(repository);
					break;
				case "WardInDept":
					keysWardInDept = new KeyedWardInDept();
					keysWardInDept.LoadAll(repository);
					break;
				case "PatientSpecimen":
					keysPatientSpecimen = new KeyedPatientSpecimen();
					keysPatientSpecimen.LoadAll(repository);
					break;
				case "HosFeeTransDetails":
					keysHosFeeTransDetails = new KeyedHosFeeTransDetails();
					keysHosFeeTransDetails.LoadAll(repository);
					break;
				//case "Trigs":
				//	keysTrigs = new KeyedTrigs();
				//	keysTrigs.LoadAll(repository);
				//	break;
				case "ICD10":
					keysICD10 = new KeyedICD10();
					keysICD10.LoadAll(repository);
					break;
				case "refDistrict":
					keysrefDistrict = new KeyedrefDistrict();
					keysrefDistrict.LoadAll(repository);
					break;
				case "refEthnicGroup":
					keysrefEthnicGroup = new KeyedrefEthnicGroup();
					keysrefEthnicGroup.LoadAll(repository);
					break;
				case "refDrugKind":
					keysrefDrugKind = new KeyedrefDrugKind();
					keysrefDrugKind.LoadAll(repository);
					break;
				case "ICDChapter":
					keysICDChapter = new KeyedICDChapter();
					keysICDChapter.LoadAll(repository);
					break;
				case "ICDGroup":
					keysICDGroup = new KeyedICDGroup();
					keysICDGroup.LoadAll(repository);
					break;
				case "SpecifiedParaclinical":
					keysSpecifiedParaclinical = new KeyedSpecifiedParaclinical();
					keysSpecifiedParaclinical.LoadAll(repository);
					break;
				case "refElthnic":
					keysrefElthnic = new KeyedrefElthnic();
					keysrefElthnic.LoadAll(repository);
					break;
				case "DiagDescribeTmp":
					keysDiagDescribeTmp = new KeyedDiagDescribeTmp();
					keysDiagDescribeTmp.LoadAll(repository);
					break;
				case "TestOnPatientSpecimen":
					keysTestOnPatientSpecimen = new KeyedTestOnPatientSpecimen();
					keysTestOnPatientSpecimen.LoadAll(repository);
					break;
				case "refExamAction":
					keysrefExamAction = new KeyedrefExamAction();
					keysrefExamAction.LoadAll(repository);
					break;
				case "PersonalProperty":
					keysPersonalProperty = new KeyedPersonalProperty();
					keysPersonalProperty.LoadAll(repository);
					break;
				case "refProblem":
					keysrefProblem = new KeyedrefProblem();
					keysrefProblem.LoadAll(repository);
					break;
				case "DrAdviceTmp":
					keysDrAdviceTmp = new KeyedDrAdviceTmp();
					keysDrAdviceTmp.LoadAll(repository);
					break;
				case "refExamObservation":
					keysrefExamObservation = new KeyedrefExamObservation();
					keysrefExamObservation.LoadAll(repository);
					break;
				case "DrMedicineAdvice":
					keysDrMedicineAdvice = new KeyedDrMedicineAdvice();
					keysDrMedicineAdvice.LoadAll(repository);
					break;
				case "DrMedicineTmp":
					keysDrMedicineTmp = new KeyedDrMedicineTmp();
					keysDrMedicineTmp.LoadAll(repository);
					break;
				case "refHL7":
					keysrefHL7 = new KeyedrefHL7();
					keysrefHL7.LoadAll(repository);
					break;
				case "DrPrescriptionTmp":
					keysDrPrescriptionTmp = new KeyedDrPrescriptionTmp();
					keysDrPrescriptionTmp.LoadAll(repository);
					break;
				case "HospitalFeeTransaction":
					keysHospitalFeeTransaction = new KeyedHospitalFeeTransaction();
					keysHospitalFeeTransaction.LoadAll(repository);
					break;
				case "PatientCommonMedRecord":
					keysPatientCommonMedRecord = new KeyedPatientCommonMedRecord();
					keysPatientCommonMedRecord.LoadAll(repository);
					break;
				case "HealthCareQueue":
					keysHealthCareQueue = new KeyedHealthCareQueue();
					keysHealthCareQueue.LoadAll(repository);
					break;
				case "Alert":
					keysAlert = new KeyedAlert();
					keysAlert.LoadAll(repository);
					break;
				case "refHumanLanguage":
					keysrefHumanLanguage = new KeyedrefHumanLanguage();
					keysrefHumanLanguage.LoadAll(repository);
					break;
				case "Patient":
					keysPatient = new KeyedPatient();
					keysPatient.LoadAll(repository);
					break;
				case "PatientMedRecord":
					keysPatientMedRecord = new KeyedPatientMedRecord();
					keysPatientMedRecord.LoadAll(repository);
					break;
				case "refImmunization":
					keysrefImmunization = new KeyedrefImmunization();
					keysrefImmunization.LoadAll(repository);
					break;
				case "refUnitOfMeasure":
					keysrefUnitOfMeasure = new KeyedrefUnitOfMeasure();
					keysrefUnitOfMeasure.LoadAll(repository);
					break;
				case "PersonRole":
					keysPersonRole = new KeyedPersonRole();
					keysPersonRole.LoadAll(repository);
					break;
				case "DrPrescriptionTmps":
					keysDrPrescriptionTmps = new KeyedDrPrescriptionTmps();
					keysDrPrescriptionTmps.LoadAll(repository);
					break;
				case "refInstUniversity":
					keysrefInstUniversity = new KeyedrefInstUniversity();
					keysrefInstUniversity.LoadAll(repository);
					break;
				case "Appointment":
					keysAppointment = new KeyedAppointment();
					keysAppointment.LoadAll(repository);
					break;
				case "refJobBand":
					keysrefJobBand = new KeyedrefJobBand();
					keysrefJobBand.LoadAll(repository);
					break;
				case "ASPNetRole":
					keysASPNetRole = new KeyedASPNetRole();
					keysASPNetRole.LoadAll(repository);
					break;
				case "MedicalBill":
					keysMedicalBill = new KeyedMedicalBill();
					keysMedicalBill.LoadAll(repository);
					break;
				case "refInsurKind":
					keysrefInsurKind = new KeyedrefInsurKind();
					keysrefInsurKind.LoadAll(repository);
					break;
				case "ASPNetRolePermission":
					keysASPNetRolePermission = new KeyedASPNetRolePermission();
					keysASPNetRolePermission.LoadAll(repository);
					break;
				case "PatientProblem":
					keysPatientProblem = new KeyedPatientProblem();
					keysPatientProblem.LoadAll(repository);
					break;
				case "MedicalBills":
					keysMedicalBills = new KeyedMedicalBills();
					keysMedicalBills.LoadAll(repository);
					break;
				case "refInternalReceiptType":
					keysrefInternalReceiptType = new KeyedrefInternalReceiptType();
					keysrefInternalReceiptType.LoadAll(repository);
					break;
				case "SocialAndHealthInsurance":
					keysSocialAndHealthInsurance = new KeyedSocialAndHealthInsurance();
					keysSocialAndHealthInsurance.LoadAll(repository);
					break;
				case "ASPNetToken":
					keysASPNetToken = new KeyedASPNetToken();
					keysASPNetToken.LoadAll(repository);
					break;
				case "MedRecOutline":
					keysMedRecOutline = new KeyedMedRecOutline();
					keysMedRecOutline.LoadAll(repository);
					break;
				case "AdmNoTemp":
					keysAdmNoTemp = new KeyedAdmNoTemp();
					keysAdmNoTemp.LoadAll(repository);
					break;
				case "ASPNetUser":
					keysASPNetUser = new KeyedASPNetUser();
					keysASPNetUser.LoadAll(repository);
					break;
				case "MedRecTmp":
					keysMedRecTmp = new KeyedMedRecTmp();
					keysMedRecTmp.LoadAll(repository);
					break;
				case "MedicalServicePackage":
					keysMedicalServicePackage = new KeyedMedicalServicePackage();
					keysMedicalServicePackage.LoadAll(repository);
					break;
				case "refItemType":
					keysrefItemType = new KeyedrefItemType();
					keysrefItemType.LoadAll(repository);
					break;
				case "PatientPVID":
					keysPatientPVID = new KeyedPatientPVID();
					keysPatientPVID.LoadAll(repository);
					break;
				case "MedSerInDept":
					keysMedSerInDept = new KeyedMedSerInDept();
					keysMedSerInDept.LoadAll(repository);
					break;
				case "refJobTitle":
					keysrefJobTitle = new KeyedrefJobTitle();
					keysrefJobTitle.LoadAll(repository);
					break;
				case "MRParagraph":
					keysMRParagraph = new KeyedMRParagraph();
					keysMRParagraph.LoadAll(repository);
					break;
				case "refLimVitalSign":
					keysrefLimVitalSign = new KeyedrefLimVitalSign();
					keysrefLimVitalSign.LoadAll(repository);
					break;
				case "WorkPlace":
					keysWorkPlace = new KeyedWorkPlace();
					keysWorkPlace.LoadAll(repository);
					break;
				case "GenericSocialNetwork":
					keysGenericSocialNetwork = new KeyedGenericSocialNetwork();
					keysGenericSocialNetwork.LoadAll(repository);
					break;
				case "MOHServiceItems":
					keysMOHServiceItems = new KeyedMOHServiceItems();
					keysMOHServiceItems.LoadAll(repository);
					break;
				case "refEducationalLevel":
					keysrefEducationalLevel = new KeyedrefEducationalLevel();
					keysrefEducationalLevel.LoadAll(repository);
					break;
				case "ASPNetUserClaims":
					keysASPNetUserClaims = new KeyedASPNetUserClaims();
					keysASPNetUserClaims.LoadAll(repository);
					break;
				case "AppliedMedStandard":
					keysAppliedMedStandard = new KeyedAppliedMedStandard();
					keysAppliedMedStandard.LoadAll(repository);
					break;
				case "ASPNetUserLogin":
					keysASPNetUserLogin = new KeyedASPNetUserLogin();
					keysASPNetUserLogin.LoadAll(repository);
					break;
				case "ArchitectureResources":
					keysArchitectureResources = new KeyedArchitectureResources();
					keysArchitectureResources.LoadAll(repository);
					break;
				case "PhysicalExamination":
					keysPhysicalExamination = new KeyedPhysicalExamination();
					keysPhysicalExamination.LoadAll(repository);
					break;
				case "MRSection":
					keysMRSection = new KeyedMRSection();
					keysMRSection.LoadAll(repository);
					break;
				case "PatientInvoices":
					keysPatientInvoices = new KeyedPatientInvoices();
					keysPatientInvoices.LoadAll(repository);
					break;
				case "AssignMedEquip":
					keysAssignMedEquip = new KeyedAssignMedEquip();
					keysAssignMedEquip.LoadAll(repository);
					break;
				case "refDischargeDisposition":
					keysrefDischargeDisposition = new KeyedrefDischargeDisposition();
					keysrefDischargeDisposition.LoadAll(repository);
					break;
				case "ASPNetUserRole":
					keysASPNetUserRole = new KeyedASPNetUserRole();
					keysASPNetUserRole.LoadAll(repository);
					break;
				case "MRSectionOutline":
					keysMRSectionOutline = new KeyedMRSectionOutline();
					keysMRSectionOutline.LoadAll(repository);
					break;
				case "SpecMedRecTmp":
					keysSpecMedRecTmp = new KeyedSpecMedRecTmp();
					keysSpecMedRecTmp.LoadAll(repository);
					break;
				case "HealthInsurance":
					keysHealthInsurance = new KeyedHealthInsurance();
					keysHealthInsurance.LoadAll(repository);
					break;
				case "Prescription":
					keysPrescription = new KeyedPrescription();
					keysPrescription.LoadAll(repository);
					break;
				case "PrivilegeRole":
					keysPrivilegeRole = new KeyedPrivilegeRole();
					keysPrivilegeRole.LoadAll(repository);
					break;
				case "AcPrincDrug":
					keysAcPrincDrug = new KeyedAcPrincDrug();
					keysAcPrincDrug.LoadAll(repository);
					break;
				case "InsuranceBeneficiary":
					keysInsuranceBeneficiary = new KeyedInsuranceBeneficiary();
					keysInsuranceBeneficiary.LoadAll(repository);
					break;
				case "AntagonistDrug":
					keysAntagonistDrug = new KeyedAntagonistDrug();
					keysAntagonistDrug.LoadAll(repository);
					break;
				case "PatientTransaction":
					keysPatientTransaction = new KeyedPatientTransaction();
					keysPatientTransaction.LoadAll(repository);
					break;
				case "BedInRoom":
					keysBedInRoom = new KeyedBedInRoom();
					keysBedInRoom.LoadAll(repository);
					break;
				case "Realms":
					keysRealms = new KeyedRealms();
					keysRealms.LoadAll(repository);
					break;
				case "refPermission":
					keysrefPermission = new KeyedrefPermission();
					keysrefPermission.LoadAll(repository);
					break;
				case "InsuranceInterests":
					keysInsuranceInterests = new KeyedInsuranceInterests();
					keysInsuranceInterests.LoadAll(repository);
					break;
				case "Employee":
					keysEmployee = new KeyedEmployee();
					keysEmployee.LoadAll(repository);
					break;
				case "ContactDetails":
					keysContactDetails = new KeyedContactDetails();
					keysContactDetails.LoadAll(repository);
					break;
				case "InsuranceRegQueue":
					keysInsuranceRegQueue = new KeyedInsuranceRegQueue();
					keysInsuranceRegQueue.LoadAll(repository);
					break;
				case "refMedcnAdminRoute":
					keysrefMedcnAdminRoute = new KeyedrefMedcnAdminRoute();
					keysrefMedcnAdminRoute.LoadAll(repository);
					break;
				case "ServerLog":
					keysServerLog = new KeyedServerLog();
					keysServerLog.LoadAll(repository);
					break;
				case "refMedcnVehicleForm":
					keysrefMedcnVehicleForm = new KeyedrefMedcnVehicleForm();
					keysrefMedcnVehicleForm.LoadAll(repository);
					break;
				case "Contract":
					keysContract = new KeyedContract();
					keysContract.LoadAll(repository);
					break;
				case "PromotionPlan":
					keysPromotionPlan = new KeyedPromotionPlan();
					keysPromotionPlan.LoadAll(repository);
					break;
				case "refMedEquipResourceType":
					keysrefMedEquipResourceType = new KeyedrefMedEquipResourceType();
					keysrefMedEquipResourceType.LoadAll(repository);
					break;
				case "ContractChange":
					keysContractChange = new KeyedContractChange();
					keysContractChange.LoadAll(repository);
					break;
				case "Session":
					keysSession = new KeyedSession();
					keysSession.LoadAll(repository);
					break;
				case "PrescriptionDetail":
					keysPrescriptionDetail = new KeyedPrescriptionDetail();
					keysPrescriptionDetail.LoadAll(repository);
					break;
				case "ClinicalTrial":
					keysClinicalTrial = new KeyedClinicalTrial();
					keysClinicalTrial.LoadAll(repository);
					break;
				case "refLookup":
					keysrefLookup = new KeyedrefLookup();
					keysrefLookup.LoadAll(repository);
					break;
				case "PromotionService":
					keysPromotionService = new KeyedPromotionService();
					keysPromotionService.LoadAll(repository);
					break;
				case "ContractDocument":
					keysContractDocument = new KeyedContractDocument();
					keysContractDocument.LoadAll(repository);
					break;
				case "NetworkGuestAccount":
					keysNetworkGuestAccount = new KeyedNetworkGuestAccount();
					keysNetworkGuestAccount.LoadAll(repository);
					break;
				case "Quotation":
					keysQuotation = new KeyedQuotation();
					keysQuotation.LoadAll(repository);
					break;
				case "refMedHisIndex":
					keysrefMedHisIndex = new KeyedrefMedHisIndex();
					keysrefMedHisIndex.LoadAll(repository);
					break;
				case "ClinicalTrialResult":
					keysClinicalTrialResult = new KeyedClinicalTrialResult();
					keysClinicalTrialResult.LoadAll(repository);
					break;
				case "DHCRoomBlock":
					keysDHCRoomBlock = new KeyedDHCRoomBlock();
					keysDHCRoomBlock.LoadAll(repository);
					break;
				case "refMedicalCondition":
					keysrefMedicalCondition = new KeyedrefMedicalCondition();
					keysrefMedicalCondition.LoadAll(repository);
					break;
				case "DisposableMDResource":
					keysDisposableMDResource = new KeyedDisposableMDResource();
					keysDisposableMDResource.LoadAll(repository);
					break;
				case "OnlineQueue":
					keysOnlineQueue = new KeyedOnlineQueue();
					keysOnlineQueue.LoadAll(repository);
					break;
				case "refMedicalServiceType":
					keysrefMedicalServiceType = new KeyedrefMedicalServiceType();
					keysrefMedicalServiceType.LoadAll(repository);
					break;
				case "Drug":
					keysDrug = new KeyedDrug();
					keysDrug.LoadAll(repository);
					break;
				case "RegistrationInfo":
					keysRegistrationInfo = new KeyedRegistrationInfo();
					keysRegistrationInfo.LoadAll(repository);
					break;
				case "refQualification":
					keysrefQualification = new KeyedrefQualification();
					keysrefQualification.LoadAll(repository);
					break;
				case "PrescriptionHistory":
					keysPrescriptionHistory = new KeyedPrescriptionHistory();
					keysPrescriptionHistory.LoadAll(repository);
					break;
				case "refPersGender":
					keysrefPersGender = new KeyedrefPersGender();
					keysrefPersGender.LoadAll(repository);
					break;
				case "PrivacyClass":
					keysPrivacyClass = new KeyedPrivacyClass();
					keysPrivacyClass.LoadAll(repository);
					break;
				case "ResearchPartnership":
					keysResearchPartnership = new KeyedResearchPartnership();
					keysResearchPartnership.LoadAll(repository);
					break;
				case "Person":
					keysPerson = new KeyedPerson();
					keysPerson.LoadAll(repository);
					break;
				case "PtCodeCheckDigitTmp":
					keysPtCodeCheckDigitTmp = new KeyedPtCodeCheckDigitTmp();
					keysPtCodeCheckDigitTmp.LoadAll(repository);
					break;
				case "BodyRegion":
					keysBodyRegion = new KeyedBodyRegion();
					keysBodyRegion.LoadAll(repository);
					break;
				case "RxHoldConsultation":
					keysRxHoldConsultation = new KeyedRxHoldConsultation();
					keysRxHoldConsultation.LoadAll(repository);
					break;
				case "RegQueue":
					keysRegQueue = new KeyedRegQueue();
					keysRegQueue.LoadAll(repository);
					break;
				case "EquipHistory":
					keysEquipHistory = new KeyedEquipHistory();
					keysEquipHistory.LoadAll(repository);
					break;
				case "ClinicalIndicatorType":
					keysClinicalIndicatorType = new KeyedClinicalIndicatorType();
					keysClinicalIndicatorType.LoadAll(repository);
					break;
				case "ExamMaintenanceHistory":
					keysExamMaintenanceHistory = new KeyedExamMaintenanceHistory();
					keysExamMaintenanceHistory.LoadAll(repository);
					break;
				case "UserGroup":
					keysUserGroup = new KeyedUserGroup();
					keysUserGroup.LoadAll(repository);
					break;
				case "MedicalDiagnosticMethod":
					keysMedicalDiagnosticMethod = new KeyedMedicalDiagnosticMethod();
					keysMedicalDiagnosticMethod.LoadAll(repository);
					break;
				case "DrugConfign":
					keysDrugConfign = new KeyedDrugConfign();
					keysDrugConfign.LoadAll(repository);
					break;
				case "SymptomIndicator":
					keysSymptomIndicator = new KeyedSymptomIndicator();
					keysSymptomIndicator.LoadAll(repository);
					break;
				case "UsersInGroup":
					keysUsersInGroup = new KeyedUsersInGroup();
					keysUsersInGroup.LoadAll(repository);
					break;
				case "MedicalTestProcedure":
					keysMedicalTestProcedure = new KeyedMedicalTestProcedure();
					keysMedicalTestProcedure.LoadAll(repository);
					break;
				case "AdvancedSpecialist":
					keysAdvancedSpecialist = new KeyedAdvancedSpecialist();
					keysAdvancedSpecialist.LoadAll(repository);
					break;
				case "ReminderNotices":
					keysReminderNotices = new KeyedReminderNotices();
					keysReminderNotices.LoadAll(repository);
					break;
				case "ForeignExchange":
					keysForeignExchange = new KeyedForeignExchange();
					keysForeignExchange.LoadAll(repository);
					break;
				case "DrugInDepartment":
					keysDrugInDepartment = new KeyedDrugInDepartment();
					keysDrugInDepartment.LoadAll(repository);
					break;
				case "HosRanking":
					keysHosRanking = new KeyedHosRanking();
					keysHosRanking.LoadAll(repository);
					break;
				case "AllergyIntolerance":
					keysAllergyIntolerance = new KeyedAllergyIntolerance();
					keysAllergyIntolerance.LoadAll(repository);
					break;
				case "EduLevel":
					keysEduLevel = new KeyedEduLevel();
					keysEduLevel.LoadAll(repository);
					break;
				case "refRole":
					keysrefRole = new KeyedrefRole();
					keysrefRole.LoadAll(repository);
					break;
				case "MedicalServiceItem":
					keysMedicalServiceItem = new KeyedMedicalServiceItem();
					keysMedicalServiceItem.LoadAll(repository);
					break;
				case "Application":
					keysApplication = new KeyedApplication();
					keysApplication.LoadAll(repository);
					break;
				case "DrugPrice":
					keysDrugPrice = new KeyedDrugPrice();
					keysDrugPrice.LoadAll(repository);
					break;
				case "refShelfDrugLocation":
					keysrefShelfDrugLocation = new KeyedrefShelfDrugLocation();
					keysrefShelfDrugLocation.LoadAll(repository);
					break;
				case "HCProvider":
					keysHCProvider = new KeyedHCProvider();
					keysHCProvider.LoadAll(repository);
					break;
				case "MedImagingRepository":
					keysMedImagingRepository = new KeyedMedImagingRepository();
					keysMedImagingRepository.LoadAll(repository);
					break;
				case "MedImagingTest":
					keysMedImagingTest = new KeyedMedImagingTest();
					keysMedImagingTest.LoadAll(repository);
					break;
				case "DeathSituationInfo":
					keysDeathSituationInfo = new KeyedDeathSituationInfo();
					keysDeathSituationInfo.LoadAll(repository);
					break;
				case "refShift":
					keysrefShift = new KeyedrefShift();
					keysrefShift.LoadAll(repository);
					break;
				case "UserAccount":
					keysUserAccount = new KeyedUserAccount();
					keysUserAccount.LoadAll(repository);
					break;
				case "MedImagingTestItems":
					keysMedImagingTestItems = new KeyedMedImagingTestItems();
					keysMedImagingTestItems.LoadAll(repository);
					break;
				case "InOutType":
					keysInOutType = new KeyedInOutType();
					keysInOutType.LoadAll(repository);
					break;
				case "InOutwardDrug":
					keysInOutwardDrug = new KeyedInOutwardDrug();
					keysInOutwardDrug.LoadAll(repository);
					break;
				case "MedLabRepository":
					keysMedLabRepository = new KeyedMedLabRepository();
					keysMedLabRepository.LoadAll(repository);
					break;
				case "InputMaskSetting":
					keysInputMaskSetting = new KeyedInputMaskSetting();
					keysInputMaskSetting.LoadAll(repository);
					break;
				case "refSIPrefix":
					keysrefSIPrefix = new KeyedrefSIPrefix();
					keysrefSIPrefix.LoadAll(repository);
					break;
				case "MesrtConv":
					keysMesrtConv = new KeyedMesrtConv();
					keysMesrtConv.LoadAll(repository);
					break;
				case "LotNumber":
					keysLotNumber = new KeyedLotNumber();
					keysLotNumber.LoadAll(repository);
					break;
				case "FamilyHistory":
					keysFamilyHistory = new KeyedFamilyHistory();
					keysFamilyHistory.LoadAll(repository);
					break;
				case "MedLabTest":
					keysMedLabTest = new KeyedMedLabTest();
					keysMedLabTest.LoadAll(repository);
					break;
				case "refSocialHisSeverity":
					keysrefSocialHisSeverity = new KeyedrefSocialHisSeverity();
					keysrefSocialHisSeverity.LoadAll(repository);
					break;
				case "refSpecimenType":
					keysrefSpecimenType = new KeyedrefSpecimenType();
					keysrefSpecimenType.LoadAll(repository);
					break;
				case "Employeer":
					keysEmployeer = new KeyedEmployeer();
					keysEmployeer.LoadAll(repository);
					break;
				case "HCStakeholder":
					keysHCStakeholder = new KeyedHCStakeholder();
					keysHCStakeholder.LoadAll(repository);
					break;
				case "PharmaceuticalCompany":
					keysPharmaceuticalCompany = new KeyedPharmaceuticalCompany();
					keysPharmaceuticalCompany.LoadAll(repository);
					break;
				case "refStoreHouse":
					keysrefStoreHouse = new KeyedrefStoreHouse();
					keysrefStoreHouse.LoadAll(repository);
					break;
				case "HIAdmission":
					keysHIAdmission = new KeyedHIAdmission();
					keysHIAdmission.LoadAll(repository);
					break;
				case "HCRoomBlock":
					keysHCRoomBlock = new KeyedHCRoomBlock();
					keysHCRoomBlock.LoadAll(repository);
					break;
				case "refAcademicTile":
					keysrefAcademicTile = new KeyedrefAcademicTile();
					keysrefAcademicTile.LoadAll(repository);
					break;
				case "JobHistory":
					keysJobHistory = new KeyedJobHistory();
					keysJobHistory.LoadAll(repository);
					break;
				case "PriceList":
					keysPriceList = new KeyedPriceList();
					keysPriceList.LoadAll(repository);
					break;
				case "HospitalizationHistory":
					keysHospitalizationHistory = new KeyedHospitalizationHistory();
					keysHospitalizationHistory.LoadAll(repository);
					break;
				case "refFAMRelationship":
					keysrefFAMRelationship = new KeyedrefFAMRelationship();
					keysrefFAMRelationship.LoadAll(repository);
					break;
				case "refTimeFrame":
					keysrefTimeFrame = new KeyedrefTimeFrame();
					keysrefTimeFrame.LoadAll(repository);
					break;
				case "HospitalSpecialist":
					keysHospitalSpecialist = new KeyedHospitalSpecialist();
					keysHospitalSpecialist.LoadAll(repository);
					break;
				case "refActiviePrinciple":
					keysrefActiviePrinciple = new KeyedrefActiviePrinciple();
					keysrefActiviePrinciple.LoadAll(repository);
					break;
				case "refAdmissionType":
					keysrefAdmissionType = new KeyedrefAdmissionType();
					keysrefAdmissionType.LoadAll(repository);
					break;
				case "MedicalEquimentsResources":
					keysMedicalEquimentsResources = new KeyedMedicalEquimentsResources();
					keysMedicalEquimentsResources.LoadAll(repository);
					break;
				case "refAdmReferralType":
					keysrefAdmReferralType = new KeyedrefAdmReferralType();
					keysrefAdmReferralType.LoadAll(repository);
					break;
				case "ProvidableDrugs":
					keysProvidableDrugs = new KeyedProvidableDrugs();
					keysProvidableDrugs.LoadAll(repository);
					break;
				case "refAllergyCategory":
					keysrefAllergyCategory = new KeyedrefAllergyCategory();
					keysrefAllergyCategory.LoadAll(repository);
					break;
				case "refTransactionType":
					keysrefTransactionType = new KeyedrefTransactionType();
					keysrefTransactionType.LoadAll(repository);
					break;
				case "JobModel":
					keysJobModel = new KeyedJobModel();
					keysJobModel.LoadAll(repository);
					break;
				case "AssignmentSchedule":
					keysAssignmentSchedule = new KeyedAssignmentSchedule();
					keysAssignmentSchedule.LoadAll(repository);
					break;
				case "refOccupation":
					keysrefOccupation = new KeyedrefOccupation();
					keysrefOccupation.LoadAll(repository);
					break;
				case "BusySchedule":
					keysBusySchedule = new KeyedBusySchedule();
					keysBusySchedule.LoadAll(repository);
					break;
				//case "AdmNoTempHolding":
				//	keysAdmNoTempHolding = new KeyedAdmNoTempHolding();
				//	keysAdmNoTempHolding.LoadAll(repository);
				//	break;
				case "refTypeAbsent":
					keysrefTypeAbsent = new KeyedrefTypeAbsent();
					keysrefTypeAbsent.LoadAll(repository);
					break;
				case "refAllergyIndex":
					keysrefAllergyIndex = new KeyedrefAllergyIndex();
					keysrefAllergyIndex.LoadAll(repository);
					break;
				case "LanguageLevel":
					keysLanguageLevel = new KeyedLanguageLevel();
					keysLanguageLevel.LoadAll(repository);
					break;
				case "refPersMaritalStatus":
					keysrefPersMaritalStatus = new KeyedrefPersMaritalStatus();
					keysrefPersMaritalStatus.LoadAll(repository);
					break;
				case "Organization":
					keysOrganization = new KeyedOrganization();
					keysOrganization.LoadAll(repository);
					break;
				case "EmpAllocation":
					keysEmpAllocation = new KeyedEmpAllocation();
					keysEmpAllocation.LoadAll(repository);
					break;
				case "NextOfKins":
					keysNextOfKins = new KeyedNextOfKins();
					keysNextOfKins.LoadAll(repository);
					break;
				case "HospitalizationHistoryDetails":
					keysHospitalizationHistoryDetails = new KeyedHospitalizationHistoryDetails();
					keysHospitalizationHistoryDetails.LoadAll(repository);
					break;
				case "refCareerMOH":
					keysrefCareerMOH = new KeyedrefCareerMOH();
					keysrefCareerMOH.LoadAll(repository);
					break;
				case "refAnnTemp":
					keysrefAnnTemp = new KeyedrefAnnTemp();
					keysrefAnnTemp.LoadAll(repository);
					break;
				case "PatientBed":
					keysPatientBed = new KeyedPatientBed();
					keysPatientBed.LoadAll(repository);
					break;
				case "ImmunizationHistory":
					keysImmunizationHistory = new KeyedImmunizationHistory();
					keysImmunizationHistory.LoadAll(repository);
					break;
				case "refAppConfig":
					keysrefAppConfig = new KeyedrefAppConfig();
					keysrefAppConfig.LoadAll(repository);
					break;
				case "EmployeeAnnualLeave":
					keysEmployeeAnnualLeave = new KeyedEmployeeAnnualLeave();
					keysEmployeeAnnualLeave.LoadAll(repository);
					break;
				case "refWard":
					keysrefWard = new KeyedrefWard();
					keysrefWard.LoadAll(repository);
					break;
				case "PatientBedFeatures":
					keysPatientBedFeatures = new KeyedPatientBedFeatures();
					keysPatientBedFeatures.LoadAll(repository);
					break;
				case "refBloodType":
					keysrefBloodType = new KeyedrefBloodType();
					keysrefBloodType.LoadAll(repository);
					break;
				case "PatientInBedRoom":
					keysPatientInBedRoom = new KeyedPatientInBedRoom();
					keysPatientInBedRoom.LoadAll(repository);
					break;
				case "MedLabTestItems":
					keysMedLabTestItems = new KeyedMedLabTestItems();
					keysMedLabTestItems.LoadAll(repository);
					break;
				case "ScheduleDoingTaskLog":
					keysScheduleDoingTaskLog = new KeyedScheduleDoingTaskLog();
					keysScheduleDoingTaskLog.LoadAll(repository);
					break;
				case "refProviderType":
					keysrefProviderType = new KeyedrefProviderType();
					keysrefProviderType.LoadAll(repository);
					break;
				case "Bloodbank":
					keysBloodbank = new KeyedBloodbank();
					keysBloodbank.LoadAll(repository);
					break;
				case "OccCareerMOH":
					keysOccCareerMOH = new KeyedOccCareerMOH();
					keysOccCareerMOH.LoadAll(repository);
					break;
				case "EmployeeLeaveTaken":
					keysEmployeeLeaveTaken = new KeyedEmployeeLeaveTaken();
					keysEmployeeLeaveTaken.LoadAll(repository);
					break;
				case "Resource":
					keysResource = new KeyedResource();
					keysResource.LoadAll(repository);
					break;

            }
            if (lstTblGetDefault == null) lstTblGetDefault = new List<string>();
            lstTblGetDefault.Add(tableName);
        }

		public static IQueryable<TEntity> GetDataInHubs<TEntity>() where TEntity : class
        {
            if (lstTblGetDefault == null) return null;
            string entityName = typeof(TEntity).Name;
            if (lstTblGetDefault.Any(o => o == entityName) == false) return null;
            switch (entityName)
            {
                case "MedEnctrDiagnosis":
					return keysMedEnctrDiagnosis == null ? null : (IQueryable<TEntity>)keysMedEnctrDiagnosis.AsQueryable();
				case "ParaClinicalExamGroup":
					return keysParaClinicalExamGroup == null ? null : (IQueryable<TEntity>)keysParaClinicalExamGroup.AsQueryable();
				case "BloodDonation":
					return keysBloodDonation == null ? null : (IQueryable<TEntity>)keysBloodDonation.AsQueryable();
				case "EmpWorkSchedule":
					return keysEmpWorkSchedule == null ? null : (IQueryable<TEntity>)keysEmpWorkSchedule.AsQueryable();
				case "MedicalClaimService":
					return keysMedicalClaimService == null ? null : (IQueryable<TEntity>)keysMedicalClaimService.AsQueryable();
				case "ParaClinicalReq":
					return keysParaClinicalReq == null ? null : (IQueryable<TEntity>)keysParaClinicalReq.AsQueryable();
				case "Donor":
					return keysDonor == null ? null : (IQueryable<TEntity>)keysDonor.AsQueryable();
				case "ResourceLog":
					return keysResourceLog == null ? null : (IQueryable<TEntity>)keysResourceLog.AsQueryable();
				case "refCertification":
					return keysrefCertification == null ? null : (IQueryable<TEntity>)keysrefCertification.AsQueryable();
				case "MedicalConditionRecord":
					return keysMedicalConditionRecord == null ? null : (IQueryable<TEntity>)keysMedicalConditionRecord.AsQueryable();
				case "PatientVitalSign":
					return keysPatientVitalSign == null ? null : (IQueryable<TEntity>)keysPatientVitalSign.AsQueryable();
				case "DonorMedicalConditions":
					return keysDonorMedicalConditions == null ? null : (IQueryable<TEntity>)keysDonorMedicalConditions.AsQueryable();
				case "InsuranceCompany":
					return keysInsuranceCompany == null ? null : (IQueryable<TEntity>)keysInsuranceCompany.AsQueryable();
				case "refCityProvince":
					return keysrefCityProvince == null ? null : (IQueryable<TEntity>)keysrefCityProvince.AsQueryable();
				case "DonorMedication":
					return keysDonorMedication == null ? null : (IQueryable<TEntity>)keysDonorMedication.AsQueryable();
				case "EventHoliday":
					return keysEventHoliday == null ? null : (IQueryable<TEntity>)keysEventHoliday.AsQueryable();
				case "RoomAllocation":
					return keysRoomAllocation == null ? null : (IQueryable<TEntity>)keysRoomAllocation.AsQueryable();
				case "refCLMeasurement":
					return keysrefCLMeasurement == null ? null : (IQueryable<TEntity>)keysrefCLMeasurement.AsQueryable();
				case "MedicalEncounter":
					return keysMedicalEncounter == null ? null : (IQueryable<TEntity>)keysMedicalEncounter.AsQueryable();
				case "SeparationOfBlood":
					return keysSeparationOfBlood == null ? null : (IQueryable<TEntity>)keysSeparationOfBlood.AsQueryable();
				case "MedicationHistory":
					return keysMedicationHistory == null ? null : (IQueryable<TEntity>)keysMedicationHistory.AsQueryable();
				case "TestBlood":
					return keysTestBlood == null ? null : (IQueryable<TEntity>)keysTestBlood.AsQueryable();
				case "StdKSection":
					return keysStdKSection == null ? null : (IQueryable<TEntity>)keysStdKSection.AsQueryable();
				case "refVitalSign":
					return keysrefVitalSign == null ? null : (IQueryable<TEntity>)keysrefVitalSign.AsQueryable();
				case "refCommonTerm":
					return keysrefCommonTerm == null ? null : (IQueryable<TEntity>)keysrefCommonTerm.AsQueryable();
				case "Operations":
					return keysOperations == null ? null : (IQueryable<TEntity>)keysOperations.AsQueryable();
				case "MiscDocuments":
					return keysMiscDocuments == null ? null : (IQueryable<TEntity>)keysMiscDocuments.AsQueryable();
				case "AttachedDoc":
					return keysAttachedDoc == null ? null : (IQueryable<TEntity>)keysAttachedDoc.AsQueryable();
				case "Supplier":
					return keysSupplier == null ? null : (IQueryable<TEntity>)keysSupplier.AsQueryable();
				case "refReligion":
					return keysrefReligion == null ? null : (IQueryable<TEntity>)keysrefReligion.AsQueryable();
				case "OperationSchedule":
					return keysOperationSchedule == null ? null : (IQueryable<TEntity>)keysOperationSchedule.AsQueryable();
				case "ChainMedicalServices":
					return keysChainMedicalServices == null ? null : (IQueryable<TEntity>)keysChainMedicalServices.AsQueryable();
				case "DocItem":
					return keysDocItem == null ? null : (IQueryable<TEntity>)keysDocItem.AsQueryable();
				case "PastPersonHistory":
					return keysPastPersonHistory == null ? null : (IQueryable<TEntity>)keysPastPersonHistory.AsQueryable();
				case "ParaClinicalReqDetails":
					return keysParaClinicalReqDetails == null ? null : (IQueryable<TEntity>)keysParaClinicalReqDetails.AsQueryable();
				case "PatientAdmission":
					return keysPatientAdmission == null ? null : (IQueryable<TEntity>)keysPatientAdmission.AsQueryable();
				case "refCountry":
					return keysrefCountry == null ? null : (IQueryable<TEntity>)keysrefCountry.AsQueryable();
				case "PatientAddressHistory":
					return keysPatientAddressHistory == null ? null : (IQueryable<TEntity>)keysPatientAddressHistory.AsQueryable();
				case "refPersRace":
					return keysrefPersRace == null ? null : (IQueryable<TEntity>)keysrefPersRace.AsQueryable();
				case "OpSkedDistibution":
					return keysOpSkedDistibution == null ? null : (IQueryable<TEntity>)keysOpSkedDistibution.AsQueryable();
				case "PatientDiagnosticImaging":
					return keysPatientDiagnosticImaging == null ? null : (IQueryable<TEntity>)keysPatientDiagnosticImaging.AsQueryable();
				case "EquivMedService":
					return keysEquivMedService == null ? null : (IQueryable<TEntity>)keysEquivMedService.AsQueryable();
				case "refCurrency":
					return keysrefCurrency == null ? null : (IQueryable<TEntity>)keysrefCurrency.AsQueryable();
				case "PatientClassHistory":
					return keysPatientClassHistory == null ? null : (IQueryable<TEntity>)keysPatientClassHistory.AsQueryable();
				case "RescrUsedInOperation":
					return keysRescrUsedInOperation == null ? null : (IQueryable<TEntity>)keysRescrUsedInOperation.AsQueryable();
				case "TechnicalInspectionAgency":
					return keysTechnicalInspectionAgency == null ? null : (IQueryable<TEntity>)keysTechnicalInspectionAgency.AsQueryable();
				case "PatientClassification":
					return keysPatientClassification == null ? null : (IQueryable<TEntity>)keysPatientClassification.AsQueryable();
				case "refDepartment":
					return keysrefDepartment == null ? null : (IQueryable<TEntity>)keysrefDepartment.AsQueryable();
				case "WorkingDay":
					return keysWorkingDay == null ? null : (IQueryable<TEntity>)keysWorkingDay.AsQueryable();
				case "HIServiceItem":
					return keysHIServiceItem == null ? null : (IQueryable<TEntity>)keysHIServiceItem.AsQueryable();
				case "WorkingSchedule":
					return keysWorkingSchedule == null ? null : (IQueryable<TEntity>)keysWorkingSchedule.AsQueryable();
				case "PatientMedLabTestResult":
					return keysPatientMedLabTestResult == null ? null : (IQueryable<TEntity>)keysPatientMedLabTestResult.AsQueryable();
				case "Ward":
					return keysWard == null ? null : (IQueryable<TEntity>)keysWard.AsQueryable();
				case "refDepreciationType":
					return keysrefDepreciationType == null ? null : (IQueryable<TEntity>)keysrefDepreciationType.AsQueryable();
				case "DDI":
					return keysDDI == null ? null : (IQueryable<TEntity>)keysDDI.AsQueryable();
				case "HIServiceItems":
					return keysHIServiceItems == null ? null : (IQueryable<TEntity>)keysHIServiceItems.AsQueryable();
				case "refDiagnosis":
					return keysrefDiagnosis == null ? null : (IQueryable<TEntity>)keysrefDiagnosis.AsQueryable();
				case "HistoricalAuditData":
					return keysHistoricalAuditData == null ? null : (IQueryable<TEntity>)keysHistoricalAuditData.AsQueryable();
				case "WardInDept":
					return keysWardInDept == null ? null : (IQueryable<TEntity>)keysWardInDept.AsQueryable();
				case "PatientSpecimen":
					return keysPatientSpecimen == null ? null : (IQueryable<TEntity>)keysPatientSpecimen.AsQueryable();
				case "HosFeeTransDetails":
					return keysHosFeeTransDetails == null ? null : (IQueryable<TEntity>)keysHosFeeTransDetails.AsQueryable();
				//case "Trigs":
				//	return keysTrigs == null ? null : (IQueryable<TEntity>)keysTrigs.AsQueryable();
				case "ICD10":
					return keysICD10 == null ? null : (IQueryable<TEntity>)keysICD10.AsQueryable();
				case "refDistrict":
					return keysrefDistrict == null ? null : (IQueryable<TEntity>)keysrefDistrict.AsQueryable();
				case "refEthnicGroup":
					return keysrefEthnicGroup == null ? null : (IQueryable<TEntity>)keysrefEthnicGroup.AsQueryable();
				case "refDrugKind":
					return keysrefDrugKind == null ? null : (IQueryable<TEntity>)keysrefDrugKind.AsQueryable();
				case "ICDChapter":
					return keysICDChapter == null ? null : (IQueryable<TEntity>)keysICDChapter.AsQueryable();
				case "ICDGroup":
					return keysICDGroup == null ? null : (IQueryable<TEntity>)keysICDGroup.AsQueryable();
				case "SpecifiedParaclinical":
					return keysSpecifiedParaclinical == null ? null : (IQueryable<TEntity>)keysSpecifiedParaclinical.AsQueryable();
				case "refElthnic":
					return keysrefElthnic == null ? null : (IQueryable<TEntity>)keysrefElthnic.AsQueryable();
				case "DiagDescribeTmp":
					return keysDiagDescribeTmp == null ? null : (IQueryable<TEntity>)keysDiagDescribeTmp.AsQueryable();
				case "TestOnPatientSpecimen":
					return keysTestOnPatientSpecimen == null ? null : (IQueryable<TEntity>)keysTestOnPatientSpecimen.AsQueryable();
				case "refExamAction":
					return keysrefExamAction == null ? null : (IQueryable<TEntity>)keysrefExamAction.AsQueryable();
				case "PersonalProperty":
					return keysPersonalProperty == null ? null : (IQueryable<TEntity>)keysPersonalProperty.AsQueryable();
				case "refProblem":
					return keysrefProblem == null ? null : (IQueryable<TEntity>)keysrefProblem.AsQueryable();
				case "DrAdviceTmp":
					return keysDrAdviceTmp == null ? null : (IQueryable<TEntity>)keysDrAdviceTmp.AsQueryable();
				case "refExamObservation":
					return keysrefExamObservation == null ? null : (IQueryable<TEntity>)keysrefExamObservation.AsQueryable();
				case "DrMedicineAdvice":
					return keysDrMedicineAdvice == null ? null : (IQueryable<TEntity>)keysDrMedicineAdvice.AsQueryable();
				case "DrMedicineTmp":
					return keysDrMedicineTmp == null ? null : (IQueryable<TEntity>)keysDrMedicineTmp.AsQueryable();
				case "refHL7":
					return keysrefHL7 == null ? null : (IQueryable<TEntity>)keysrefHL7.AsQueryable();
				case "DrPrescriptionTmp":
					return keysDrPrescriptionTmp == null ? null : (IQueryable<TEntity>)keysDrPrescriptionTmp.AsQueryable();
				case "HospitalFeeTransaction":
					return keysHospitalFeeTransaction == null ? null : (IQueryable<TEntity>)keysHospitalFeeTransaction.AsQueryable();
				case "PatientCommonMedRecord":
					return keysPatientCommonMedRecord == null ? null : (IQueryable<TEntity>)keysPatientCommonMedRecord.AsQueryable();
				case "HealthCareQueue":
					return keysHealthCareQueue == null ? null : (IQueryable<TEntity>)keysHealthCareQueue.AsQueryable();
				case "Alert":
					return keysAlert == null ? null : (IQueryable<TEntity>)keysAlert.AsQueryable();
				case "refHumanLanguage":
					return keysrefHumanLanguage == null ? null : (IQueryable<TEntity>)keysrefHumanLanguage.AsQueryable();
				case "Patient":
					return keysPatient == null ? null : (IQueryable<TEntity>)keysPatient.AsQueryable();
				case "PatientMedRecord":
					return keysPatientMedRecord == null ? null : (IQueryable<TEntity>)keysPatientMedRecord.AsQueryable();
				case "refImmunization":
					return keysrefImmunization == null ? null : (IQueryable<TEntity>)keysrefImmunization.AsQueryable();
				case "refUnitOfMeasure":
					return keysrefUnitOfMeasure == null ? null : (IQueryable<TEntity>)keysrefUnitOfMeasure.AsQueryable();
				case "PersonRole":
					return keysPersonRole == null ? null : (IQueryable<TEntity>)keysPersonRole.AsQueryable();
				case "DrPrescriptionTmps":
					return keysDrPrescriptionTmps == null ? null : (IQueryable<TEntity>)keysDrPrescriptionTmps.AsQueryable();
				case "refInstUniversity":
					return keysrefInstUniversity == null ? null : (IQueryable<TEntity>)keysrefInstUniversity.AsQueryable();
				case "Appointment":
					return keysAppointment == null ? null : (IQueryable<TEntity>)keysAppointment.AsQueryable();
				case "refJobBand":
					return keysrefJobBand == null ? null : (IQueryable<TEntity>)keysrefJobBand.AsQueryable();
				case "ASPNetRole":
					return keysASPNetRole == null ? null : (IQueryable<TEntity>)keysASPNetRole.AsQueryable();
				case "MedicalBill":
					return keysMedicalBill == null ? null : (IQueryable<TEntity>)keysMedicalBill.AsQueryable();
				case "refInsurKind":
					return keysrefInsurKind == null ? null : (IQueryable<TEntity>)keysrefInsurKind.AsQueryable();
				case "ASPNetRolePermission":
					return keysASPNetRolePermission == null ? null : (IQueryable<TEntity>)keysASPNetRolePermission.AsQueryable();
				case "PatientProblem":
					return keysPatientProblem == null ? null : (IQueryable<TEntity>)keysPatientProblem.AsQueryable();
				case "MedicalBills":
					return keysMedicalBills == null ? null : (IQueryable<TEntity>)keysMedicalBills.AsQueryable();
				case "refInternalReceiptType":
					return keysrefInternalReceiptType == null ? null : (IQueryable<TEntity>)keysrefInternalReceiptType.AsQueryable();
				case "SocialAndHealthInsurance":
					return keysSocialAndHealthInsurance == null ? null : (IQueryable<TEntity>)keysSocialAndHealthInsurance.AsQueryable();
				case "ASPNetToken":
					return keysASPNetToken == null ? null : (IQueryable<TEntity>)keysASPNetToken.AsQueryable();
				case "MedRecOutline":
					return keysMedRecOutline == null ? null : (IQueryable<TEntity>)keysMedRecOutline.AsQueryable();
				case "AdmNoTemp":
					return keysAdmNoTemp == null ? null : (IQueryable<TEntity>)keysAdmNoTemp.AsQueryable();
				case "ASPNetUser":
					return keysASPNetUser == null ? null : (IQueryable<TEntity>)keysASPNetUser.AsQueryable();
				case "MedRecTmp":
					return keysMedRecTmp == null ? null : (IQueryable<TEntity>)keysMedRecTmp.AsQueryable();
				case "MedicalServicePackage":
					return keysMedicalServicePackage == null ? null : (IQueryable<TEntity>)keysMedicalServicePackage.AsQueryable();
				case "refItemType":
					return keysrefItemType == null ? null : (IQueryable<TEntity>)keysrefItemType.AsQueryable();
				case "PatientPVID":
					return keysPatientPVID == null ? null : (IQueryable<TEntity>)keysPatientPVID.AsQueryable();
				case "MedSerInDept":
					return keysMedSerInDept == null ? null : (IQueryable<TEntity>)keysMedSerInDept.AsQueryable();
				case "refJobTitle":
					return keysrefJobTitle == null ? null : (IQueryable<TEntity>)keysrefJobTitle.AsQueryable();
				case "MRParagraph":
					return keysMRParagraph == null ? null : (IQueryable<TEntity>)keysMRParagraph.AsQueryable();
				case "refLimVitalSign":
					return keysrefLimVitalSign == null ? null : (IQueryable<TEntity>)keysrefLimVitalSign.AsQueryable();
				case "WorkPlace":
					return keysWorkPlace == null ? null : (IQueryable<TEntity>)keysWorkPlace.AsQueryable();
				case "GenericSocialNetwork":
					return keysGenericSocialNetwork == null ? null : (IQueryable<TEntity>)keysGenericSocialNetwork.AsQueryable();
				case "MOHServiceItems":
					return keysMOHServiceItems == null ? null : (IQueryable<TEntity>)keysMOHServiceItems.AsQueryable();
				case "refEducationalLevel":
					return keysrefEducationalLevel == null ? null : (IQueryable<TEntity>)keysrefEducationalLevel.AsQueryable();
				case "ASPNetUserClaims":
					return keysASPNetUserClaims == null ? null : (IQueryable<TEntity>)keysASPNetUserClaims.AsQueryable();
				case "AppliedMedStandard":
					return keysAppliedMedStandard == null ? null : (IQueryable<TEntity>)keysAppliedMedStandard.AsQueryable();
				case "ASPNetUserLogin":
					return keysASPNetUserLogin == null ? null : (IQueryable<TEntity>)keysASPNetUserLogin.AsQueryable();
				case "ArchitectureResources":
					return keysArchitectureResources == null ? null : (IQueryable<TEntity>)keysArchitectureResources.AsQueryable();
				case "PhysicalExamination":
					return keysPhysicalExamination == null ? null : (IQueryable<TEntity>)keysPhysicalExamination.AsQueryable();
				case "MRSection":
					return keysMRSection == null ? null : (IQueryable<TEntity>)keysMRSection.AsQueryable();
				case "PatientInvoices":
					return keysPatientInvoices == null ? null : (IQueryable<TEntity>)keysPatientInvoices.AsQueryable();
				case "AssignMedEquip":
					return keysAssignMedEquip == null ? null : (IQueryable<TEntity>)keysAssignMedEquip.AsQueryable();
				case "refDischargeDisposition":
					return keysrefDischargeDisposition == null ? null : (IQueryable<TEntity>)keysrefDischargeDisposition.AsQueryable();
				case "ASPNetUserRole":
					return keysASPNetUserRole == null ? null : (IQueryable<TEntity>)keysASPNetUserRole.AsQueryable();
				case "MRSectionOutline":
					return keysMRSectionOutline == null ? null : (IQueryable<TEntity>)keysMRSectionOutline.AsQueryable();
				case "SpecMedRecTmp":
					return keysSpecMedRecTmp == null ? null : (IQueryable<TEntity>)keysSpecMedRecTmp.AsQueryable();
				case "HealthInsurance":
					return keysHealthInsurance == null ? null : (IQueryable<TEntity>)keysHealthInsurance.AsQueryable();
				case "Prescription":
					return keysPrescription == null ? null : (IQueryable<TEntity>)keysPrescription.AsQueryable();
				case "PrivilegeRole":
					return keysPrivilegeRole == null ? null : (IQueryable<TEntity>)keysPrivilegeRole.AsQueryable();
				case "AcPrincDrug":
					return keysAcPrincDrug == null ? null : (IQueryable<TEntity>)keysAcPrincDrug.AsQueryable();
				case "InsuranceBeneficiary":
					return keysInsuranceBeneficiary == null ? null : (IQueryable<TEntity>)keysInsuranceBeneficiary.AsQueryable();
				case "AntagonistDrug":
					return keysAntagonistDrug == null ? null : (IQueryable<TEntity>)keysAntagonistDrug.AsQueryable();
				case "PatientTransaction":
					return keysPatientTransaction == null ? null : (IQueryable<TEntity>)keysPatientTransaction.AsQueryable();
				case "BedInRoom":
					return keysBedInRoom == null ? null : (IQueryable<TEntity>)keysBedInRoom.AsQueryable();
				case "Realms":
					return keysRealms == null ? null : (IQueryable<TEntity>)keysRealms.AsQueryable();
				case "refPermission":
					return keysrefPermission == null ? null : (IQueryable<TEntity>)keysrefPermission.AsQueryable();
				case "InsuranceInterests":
					return keysInsuranceInterests == null ? null : (IQueryable<TEntity>)keysInsuranceInterests.AsQueryable();
				case "Employee":
					return keysEmployee == null ? null : (IQueryable<TEntity>)keysEmployee.AsQueryable();
				case "ContactDetails":
					return keysContactDetails == null ? null : (IQueryable<TEntity>)keysContactDetails.AsQueryable();
				case "InsuranceRegQueue":
					return keysInsuranceRegQueue == null ? null : (IQueryable<TEntity>)keysInsuranceRegQueue.AsQueryable();
				case "refMedcnAdminRoute":
					return keysrefMedcnAdminRoute == null ? null : (IQueryable<TEntity>)keysrefMedcnAdminRoute.AsQueryable();
				case "ServerLog":
					return keysServerLog == null ? null : (IQueryable<TEntity>)keysServerLog.AsQueryable();
				case "refMedcnVehicleForm":
					return keysrefMedcnVehicleForm == null ? null : (IQueryable<TEntity>)keysrefMedcnVehicleForm.AsQueryable();
				case "Contract":
					return keysContract == null ? null : (IQueryable<TEntity>)keysContract.AsQueryable();
				case "PromotionPlan":
					return keysPromotionPlan == null ? null : (IQueryable<TEntity>)keysPromotionPlan.AsQueryable();
				case "refMedEquipResourceType":
					return keysrefMedEquipResourceType == null ? null : (IQueryable<TEntity>)keysrefMedEquipResourceType.AsQueryable();
				case "ContractChange":
					return keysContractChange == null ? null : (IQueryable<TEntity>)keysContractChange.AsQueryable();
				case "Session":
					return keysSession == null ? null : (IQueryable<TEntity>)keysSession.AsQueryable();
				case "PrescriptionDetail":
					return keysPrescriptionDetail == null ? null : (IQueryable<TEntity>)keysPrescriptionDetail.AsQueryable();
				case "ClinicalTrial":
					return keysClinicalTrial == null ? null : (IQueryable<TEntity>)keysClinicalTrial.AsQueryable();
				case "refLookup":
					return keysrefLookup == null ? null : (IQueryable<TEntity>)keysrefLookup.AsQueryable();
				case "PromotionService":
					return keysPromotionService == null ? null : (IQueryable<TEntity>)keysPromotionService.AsQueryable();
				case "ContractDocument":
					return keysContractDocument == null ? null : (IQueryable<TEntity>)keysContractDocument.AsQueryable();
				case "NetworkGuestAccount":
					return keysNetworkGuestAccount == null ? null : (IQueryable<TEntity>)keysNetworkGuestAccount.AsQueryable();
				case "Quotation":
					return keysQuotation == null ? null : (IQueryable<TEntity>)keysQuotation.AsQueryable();
				case "refMedHisIndex":
					return keysrefMedHisIndex == null ? null : (IQueryable<TEntity>)keysrefMedHisIndex.AsQueryable();
				case "ClinicalTrialResult":
					return keysClinicalTrialResult == null ? null : (IQueryable<TEntity>)keysClinicalTrialResult.AsQueryable();
				case "DHCRoomBlock":
					return keysDHCRoomBlock == null ? null : (IQueryable<TEntity>)keysDHCRoomBlock.AsQueryable();
				case "refMedicalCondition":
					return keysrefMedicalCondition == null ? null : (IQueryable<TEntity>)keysrefMedicalCondition.AsQueryable();
				case "DisposableMDResource":
					return keysDisposableMDResource == null ? null : (IQueryable<TEntity>)keysDisposableMDResource.AsQueryable();
				case "OnlineQueue":
					return keysOnlineQueue == null ? null : (IQueryable<TEntity>)keysOnlineQueue.AsQueryable();
				case "refMedicalServiceType":
					return keysrefMedicalServiceType == null ? null : (IQueryable<TEntity>)keysrefMedicalServiceType.AsQueryable();
				case "Drug":
					return keysDrug == null ? null : (IQueryable<TEntity>)keysDrug.AsQueryable();
				case "RegistrationInfo":
					return keysRegistrationInfo == null ? null : (IQueryable<TEntity>)keysRegistrationInfo.AsQueryable();
				case "refQualification":
					return keysrefQualification == null ? null : (IQueryable<TEntity>)keysrefQualification.AsQueryable();
				case "PrescriptionHistory":
					return keysPrescriptionHistory == null ? null : (IQueryable<TEntity>)keysPrescriptionHistory.AsQueryable();
				case "refPersGender":
					return keysrefPersGender == null ? null : (IQueryable<TEntity>)keysrefPersGender.AsQueryable();
				case "PrivacyClass":
					return keysPrivacyClass == null ? null : (IQueryable<TEntity>)keysPrivacyClass.AsQueryable();
				case "ResearchPartnership":
					return keysResearchPartnership == null ? null : (IQueryable<TEntity>)keysResearchPartnership.AsQueryable();
				case "Person":
					return keysPerson == null ? null : (IQueryable<TEntity>)keysPerson.AsQueryable();
				case "PtCodeCheckDigitTmp":
					return keysPtCodeCheckDigitTmp == null ? null : (IQueryable<TEntity>)keysPtCodeCheckDigitTmp.AsQueryable();
				case "BodyRegion":
					return keysBodyRegion == null ? null : (IQueryable<TEntity>)keysBodyRegion.AsQueryable();
				case "RxHoldConsultation":
					return keysRxHoldConsultation == null ? null : (IQueryable<TEntity>)keysRxHoldConsultation.AsQueryable();
				case "RegQueue":
					return keysRegQueue == null ? null : (IQueryable<TEntity>)keysRegQueue.AsQueryable();
				case "EquipHistory":
					return keysEquipHistory == null ? null : (IQueryable<TEntity>)keysEquipHistory.AsQueryable();
				case "ClinicalIndicatorType":
					return keysClinicalIndicatorType == null ? null : (IQueryable<TEntity>)keysClinicalIndicatorType.AsQueryable();
				case "ExamMaintenanceHistory":
					return keysExamMaintenanceHistory == null ? null : (IQueryable<TEntity>)keysExamMaintenanceHistory.AsQueryable();
				case "UserGroup":
					return keysUserGroup == null ? null : (IQueryable<TEntity>)keysUserGroup.AsQueryable();
				case "MedicalDiagnosticMethod":
					return keysMedicalDiagnosticMethod == null ? null : (IQueryable<TEntity>)keysMedicalDiagnosticMethod.AsQueryable();
				case "DrugConfign":
					return keysDrugConfign == null ? null : (IQueryable<TEntity>)keysDrugConfign.AsQueryable();
				case "SymptomIndicator":
					return keysSymptomIndicator == null ? null : (IQueryable<TEntity>)keysSymptomIndicator.AsQueryable();
				case "UsersInGroup":
					return keysUsersInGroup == null ? null : (IQueryable<TEntity>)keysUsersInGroup.AsQueryable();
				case "MedicalTestProcedure":
					return keysMedicalTestProcedure == null ? null : (IQueryable<TEntity>)keysMedicalTestProcedure.AsQueryable();
				case "AdvancedSpecialist":
					return keysAdvancedSpecialist == null ? null : (IQueryable<TEntity>)keysAdvancedSpecialist.AsQueryable();
				case "ReminderNotices":
					return keysReminderNotices == null ? null : (IQueryable<TEntity>)keysReminderNotices.AsQueryable();
				case "ForeignExchange":
					return keysForeignExchange == null ? null : (IQueryable<TEntity>)keysForeignExchange.AsQueryable();
				case "DrugInDepartment":
					return keysDrugInDepartment == null ? null : (IQueryable<TEntity>)keysDrugInDepartment.AsQueryable();
				case "HosRanking":
					return keysHosRanking == null ? null : (IQueryable<TEntity>)keysHosRanking.AsQueryable();
				case "AllergyIntolerance":
					return keysAllergyIntolerance == null ? null : (IQueryable<TEntity>)keysAllergyIntolerance.AsQueryable();
				case "EduLevel":
					return keysEduLevel == null ? null : (IQueryable<TEntity>)keysEduLevel.AsQueryable();
				case "refRole":
					return keysrefRole == null ? null : (IQueryable<TEntity>)keysrefRole.AsQueryable();
				case "MedicalServiceItem":
					return keysMedicalServiceItem == null ? null : (IQueryable<TEntity>)keysMedicalServiceItem.AsQueryable();
				case "Application":
					return keysApplication == null ? null : (IQueryable<TEntity>)keysApplication.AsQueryable();
				case "DrugPrice":
					return keysDrugPrice == null ? null : (IQueryable<TEntity>)keysDrugPrice.AsQueryable();
				case "refShelfDrugLocation":
					return keysrefShelfDrugLocation == null ? null : (IQueryable<TEntity>)keysrefShelfDrugLocation.AsQueryable();
				case "HCProvider":
					return keysHCProvider == null ? null : (IQueryable<TEntity>)keysHCProvider.AsQueryable();
				case "MedImagingRepository":
					return keysMedImagingRepository == null ? null : (IQueryable<TEntity>)keysMedImagingRepository.AsQueryable();
				case "MedImagingTest":
					return keysMedImagingTest == null ? null : (IQueryable<TEntity>)keysMedImagingTest.AsQueryable();
				case "DeathSituationInfo":
					return keysDeathSituationInfo == null ? null : (IQueryable<TEntity>)keysDeathSituationInfo.AsQueryable();
				case "refShift":
					return keysrefShift == null ? null : (IQueryable<TEntity>)keysrefShift.AsQueryable();
				case "UserAccount":
					return keysUserAccount == null ? null : (IQueryable<TEntity>)keysUserAccount.AsQueryable();
				case "MedImagingTestItems":
					return keysMedImagingTestItems == null ? null : (IQueryable<TEntity>)keysMedImagingTestItems.AsQueryable();
				case "InOutType":
					return keysInOutType == null ? null : (IQueryable<TEntity>)keysInOutType.AsQueryable();
				case "InOutwardDrug":
					return keysInOutwardDrug == null ? null : (IQueryable<TEntity>)keysInOutwardDrug.AsQueryable();
				case "MedLabRepository":
					return keysMedLabRepository == null ? null : (IQueryable<TEntity>)keysMedLabRepository.AsQueryable();
				case "InputMaskSetting":
					return keysInputMaskSetting == null ? null : (IQueryable<TEntity>)keysInputMaskSetting.AsQueryable();
				case "refSIPrefix":
					return keysrefSIPrefix == null ? null : (IQueryable<TEntity>)keysrefSIPrefix.AsQueryable();
				case "MesrtConv":
					return keysMesrtConv == null ? null : (IQueryable<TEntity>)keysMesrtConv.AsQueryable();
				case "LotNumber":
					return keysLotNumber == null ? null : (IQueryable<TEntity>)keysLotNumber.AsQueryable();
				case "FamilyHistory":
					return keysFamilyHistory == null ? null : (IQueryable<TEntity>)keysFamilyHistory.AsQueryable();
				case "MedLabTest":
					return keysMedLabTest == null ? null : (IQueryable<TEntity>)keysMedLabTest.AsQueryable();
				case "refSocialHisSeverity":
					return keysrefSocialHisSeverity == null ? null : (IQueryable<TEntity>)keysrefSocialHisSeverity.AsQueryable();
				case "refSpecimenType":
					return keysrefSpecimenType == null ? null : (IQueryable<TEntity>)keysrefSpecimenType.AsQueryable();
				case "Employeer":
					return keysEmployeer == null ? null : (IQueryable<TEntity>)keysEmployeer.AsQueryable();
				case "HCStakeholder":
					return keysHCStakeholder == null ? null : (IQueryable<TEntity>)keysHCStakeholder.AsQueryable();
				case "PharmaceuticalCompany":
					return keysPharmaceuticalCompany == null ? null : (IQueryable<TEntity>)keysPharmaceuticalCompany.AsQueryable();
				case "refStoreHouse":
					return keysrefStoreHouse == null ? null : (IQueryable<TEntity>)keysrefStoreHouse.AsQueryable();
				case "HIAdmission":
					return keysHIAdmission == null ? null : (IQueryable<TEntity>)keysHIAdmission.AsQueryable();
				case "HCRoomBlock":
					return keysHCRoomBlock == null ? null : (IQueryable<TEntity>)keysHCRoomBlock.AsQueryable();
				case "refAcademicTile":
					return keysrefAcademicTile == null ? null : (IQueryable<TEntity>)keysrefAcademicTile.AsQueryable();
				case "JobHistory":
					return keysJobHistory == null ? null : (IQueryable<TEntity>)keysJobHistory.AsQueryable();
				case "PriceList":
					return keysPriceList == null ? null : (IQueryable<TEntity>)keysPriceList.AsQueryable();
				case "HospitalizationHistory":
					return keysHospitalizationHistory == null ? null : (IQueryable<TEntity>)keysHospitalizationHistory.AsQueryable();
				case "refFAMRelationship":
					return keysrefFAMRelationship == null ? null : (IQueryable<TEntity>)keysrefFAMRelationship.AsQueryable();
				case "refTimeFrame":
					return keysrefTimeFrame == null ? null : (IQueryable<TEntity>)keysrefTimeFrame.AsQueryable();
				case "HospitalSpecialist":
					return keysHospitalSpecialist == null ? null : (IQueryable<TEntity>)keysHospitalSpecialist.AsQueryable();
				case "refActiviePrinciple":
					return keysrefActiviePrinciple == null ? null : (IQueryable<TEntity>)keysrefActiviePrinciple.AsQueryable();
				case "refAdmissionType":
					return keysrefAdmissionType == null ? null : (IQueryable<TEntity>)keysrefAdmissionType.AsQueryable();
				case "MedicalEquimentsResources":
					return keysMedicalEquimentsResources == null ? null : (IQueryable<TEntity>)keysMedicalEquimentsResources.AsQueryable();
				case "refAdmReferralType":
					return keysrefAdmReferralType == null ? null : (IQueryable<TEntity>)keysrefAdmReferralType.AsQueryable();
				case "ProvidableDrugs":
					return keysProvidableDrugs == null ? null : (IQueryable<TEntity>)keysProvidableDrugs.AsQueryable();
				case "refAllergyCategory":
					return keysrefAllergyCategory == null ? null : (IQueryable<TEntity>)keysrefAllergyCategory.AsQueryable();
				case "refTransactionType":
					return keysrefTransactionType == null ? null : (IQueryable<TEntity>)keysrefTransactionType.AsQueryable();
				case "JobModel":
					return keysJobModel == null ? null : (IQueryable<TEntity>)keysJobModel.AsQueryable();
				case "AssignmentSchedule":
					return keysAssignmentSchedule == null ? null : (IQueryable<TEntity>)keysAssignmentSchedule.AsQueryable();
				case "refOccupation":
					return keysrefOccupation == null ? null : (IQueryable<TEntity>)keysrefOccupation.AsQueryable();
				case "BusySchedule":
					return keysBusySchedule == null ? null : (IQueryable<TEntity>)keysBusySchedule.AsQueryable();
				//case "AdmNoTempHolding":
				//	return keysAdmNoTempHolding == null ? null : (IQueryable<TEntity>)keysAdmNoTempHolding.AsQueryable();
				case "refTypeAbsent":
					return keysrefTypeAbsent == null ? null : (IQueryable<TEntity>)keysrefTypeAbsent.AsQueryable();
				case "refAllergyIndex":
					return keysrefAllergyIndex == null ? null : (IQueryable<TEntity>)keysrefAllergyIndex.AsQueryable();
				case "LanguageLevel":
					return keysLanguageLevel == null ? null : (IQueryable<TEntity>)keysLanguageLevel.AsQueryable();
				case "refPersMaritalStatus":
					return keysrefPersMaritalStatus == null ? null : (IQueryable<TEntity>)keysrefPersMaritalStatus.AsQueryable();
				case "Organization":
					return keysOrganization == null ? null : (IQueryable<TEntity>)keysOrganization.AsQueryable();
				case "EmpAllocation":
					return keysEmpAllocation == null ? null : (IQueryable<TEntity>)keysEmpAllocation.AsQueryable();
				case "NextOfKins":
					return keysNextOfKins == null ? null : (IQueryable<TEntity>)keysNextOfKins.AsQueryable();
				case "HospitalizationHistoryDetails":
					return keysHospitalizationHistoryDetails == null ? null : (IQueryable<TEntity>)keysHospitalizationHistoryDetails.AsQueryable();
				case "refCareerMOH":
					return keysrefCareerMOH == null ? null : (IQueryable<TEntity>)keysrefCareerMOH.AsQueryable();
				case "refAnnTemp":
					return keysrefAnnTemp == null ? null : (IQueryable<TEntity>)keysrefAnnTemp.AsQueryable();
				case "PatientBed":
					return keysPatientBed == null ? null : (IQueryable<TEntity>)keysPatientBed.AsQueryable();
				case "ImmunizationHistory":
					return keysImmunizationHistory == null ? null : (IQueryable<TEntity>)keysImmunizationHistory.AsQueryable();
				case "refAppConfig":
					return keysrefAppConfig == null ? null : (IQueryable<TEntity>)keysrefAppConfig.AsQueryable();
				case "EmployeeAnnualLeave":
					return keysEmployeeAnnualLeave == null ? null : (IQueryable<TEntity>)keysEmployeeAnnualLeave.AsQueryable();
				case "refWard":
					return keysrefWard == null ? null : (IQueryable<TEntity>)keysrefWard.AsQueryable();
				case "PatientBedFeatures":
					return keysPatientBedFeatures == null ? null : (IQueryable<TEntity>)keysPatientBedFeatures.AsQueryable();
				case "refBloodType":
					return keysrefBloodType == null ? null : (IQueryable<TEntity>)keysrefBloodType.AsQueryable();
				case "PatientInBedRoom":
					return keysPatientInBedRoom == null ? null : (IQueryable<TEntity>)keysPatientInBedRoom.AsQueryable();
				case "MedLabTestItems":
					return keysMedLabTestItems == null ? null : (IQueryable<TEntity>)keysMedLabTestItems.AsQueryable();
				case "ScheduleDoingTaskLog":
					return keysScheduleDoingTaskLog == null ? null : (IQueryable<TEntity>)keysScheduleDoingTaskLog.AsQueryable();
				case "refProviderType":
					return keysrefProviderType == null ? null : (IQueryable<TEntity>)keysrefProviderType.AsQueryable();
				case "Bloodbank":
					return keysBloodbank == null ? null : (IQueryable<TEntity>)keysBloodbank.AsQueryable();
				case "OccCareerMOH":
					return keysOccCareerMOH == null ? null : (IQueryable<TEntity>)keysOccCareerMOH.AsQueryable();
				case "EmployeeLeaveTaken":
					return keysEmployeeLeaveTaken == null ? null : (IQueryable<TEntity>)keysEmployeeLeaveTaken.AsQueryable();
				case "Resource":
					return keysResource == null ? null : (IQueryable<TEntity>)keysResource.AsQueryable();

            }
            return null;
        }

        public static IQueryable<TEntity> GetDataInHubs<TEntity>(LV.Core.DAL.Base.IRepository repository) where TEntity : class
        {
            string entityName = typeof(TEntity).Name;
            if (lstTblGetDefault == null || lstTblGetDefault.Any(o => o == entityName) == false) 
            {
                LoadTable(entityName, repository);
            }

            return GetDataInHubs<TEntity>();
        }

        public static void ClearAllKeys()
        {
            if (keysMedEnctrDiagnosis != null) { keysMedEnctrDiagnosis.Dispose(); keysMedEnctrDiagnosis = null; }
			if (keysParaClinicalExamGroup != null) { keysParaClinicalExamGroup.Dispose(); keysParaClinicalExamGroup = null; }
			if (keysBloodDonation != null) { keysBloodDonation.Dispose(); keysBloodDonation = null; }
			if (keysEmpWorkSchedule != null) { keysEmpWorkSchedule.Dispose(); keysEmpWorkSchedule = null; }
			if (keysMedicalClaimService != null) { keysMedicalClaimService.Dispose(); keysMedicalClaimService = null; }
			if (keysParaClinicalReq != null) { keysParaClinicalReq.Dispose(); keysParaClinicalReq = null; }
			if (keysDonor != null) { keysDonor.Dispose(); keysDonor = null; }
			if (keysResourceLog != null) { keysResourceLog.Dispose(); keysResourceLog = null; }
			if (keysrefCertification != null) { keysrefCertification.Dispose(); keysrefCertification = null; }
			if (keysMedicalConditionRecord != null) { keysMedicalConditionRecord.Dispose(); keysMedicalConditionRecord = null; }
			if (keysPatientVitalSign != null) { keysPatientVitalSign.Dispose(); keysPatientVitalSign = null; }
			if (keysDonorMedicalConditions != null) { keysDonorMedicalConditions.Dispose(); keysDonorMedicalConditions = null; }
			if (keysInsuranceCompany != null) { keysInsuranceCompany.Dispose(); keysInsuranceCompany = null; }
			if (keysrefCityProvince != null) { keysrefCityProvince.Dispose(); keysrefCityProvince = null; }
			if (keysDonorMedication != null) { keysDonorMedication.Dispose(); keysDonorMedication = null; }
			if (keysEventHoliday != null) { keysEventHoliday.Dispose(); keysEventHoliday = null; }
			if (keysRoomAllocation != null) { keysRoomAllocation.Dispose(); keysRoomAllocation = null; }
			if (keysrefCLMeasurement != null) { keysrefCLMeasurement.Dispose(); keysrefCLMeasurement = null; }
			if (keysMedicalEncounter != null) { keysMedicalEncounter.Dispose(); keysMedicalEncounter = null; }
			if (keysSeparationOfBlood != null) { keysSeparationOfBlood.Dispose(); keysSeparationOfBlood = null; }
			if (keysMedicationHistory != null) { keysMedicationHistory.Dispose(); keysMedicationHistory = null; }
			if (keysTestBlood != null) { keysTestBlood.Dispose(); keysTestBlood = null; }
			if (keysStdKSection != null) { keysStdKSection.Dispose(); keysStdKSection = null; }
			if (keysrefVitalSign != null) { keysrefVitalSign.Dispose(); keysrefVitalSign = null; }
			if (keysrefCommonTerm != null) { keysrefCommonTerm.Dispose(); keysrefCommonTerm = null; }
			if (keysOperations != null) { keysOperations.Dispose(); keysOperations = null; }
			if (keysMiscDocuments != null) { keysMiscDocuments.Dispose(); keysMiscDocuments = null; }
			if (keysAttachedDoc != null) { keysAttachedDoc.Dispose(); keysAttachedDoc = null; }
			if (keysSupplier != null) { keysSupplier.Dispose(); keysSupplier = null; }
			if (keysrefReligion != null) { keysrefReligion.Dispose(); keysrefReligion = null; }
			if (keysOperationSchedule != null) { keysOperationSchedule.Dispose(); keysOperationSchedule = null; }
			if (keysChainMedicalServices != null) { keysChainMedicalServices.Dispose(); keysChainMedicalServices = null; }
			if (keysDocItem != null) { keysDocItem.Dispose(); keysDocItem = null; }
			if (keysPastPersonHistory != null) { keysPastPersonHistory.Dispose(); keysPastPersonHistory = null; }
			if (keysParaClinicalReqDetails != null) { keysParaClinicalReqDetails.Dispose(); keysParaClinicalReqDetails = null; }
			if (keysPatientAdmission != null) { keysPatientAdmission.Dispose(); keysPatientAdmission = null; }
			if (keysrefCountry != null) { keysrefCountry.Dispose(); keysrefCountry = null; }
			if (keysPatientAddressHistory != null) { keysPatientAddressHistory.Dispose(); keysPatientAddressHistory = null; }
			if (keysrefPersRace != null) { keysrefPersRace.Dispose(); keysrefPersRace = null; }
			if (keysOpSkedDistibution != null) { keysOpSkedDistibution.Dispose(); keysOpSkedDistibution = null; }
			if (keysPatientDiagnosticImaging != null) { keysPatientDiagnosticImaging.Dispose(); keysPatientDiagnosticImaging = null; }
			if (keysEquivMedService != null) { keysEquivMedService.Dispose(); keysEquivMedService = null; }
			if (keysrefCurrency != null) { keysrefCurrency.Dispose(); keysrefCurrency = null; }
			if (keysPatientClassHistory != null) { keysPatientClassHistory.Dispose(); keysPatientClassHistory = null; }
			if (keysRescrUsedInOperation != null) { keysRescrUsedInOperation.Dispose(); keysRescrUsedInOperation = null; }
			if (keysTechnicalInspectionAgency != null) { keysTechnicalInspectionAgency.Dispose(); keysTechnicalInspectionAgency = null; }
			if (keysPatientClassification != null) { keysPatientClassification.Dispose(); keysPatientClassification = null; }
			if (keysrefDepartment != null) { keysrefDepartment.Dispose(); keysrefDepartment = null; }
			if (keysWorkingDay != null) { keysWorkingDay.Dispose(); keysWorkingDay = null; }
			if (keysHIServiceItem != null) { keysHIServiceItem.Dispose(); keysHIServiceItem = null; }
			if (keysWorkingSchedule != null) { keysWorkingSchedule.Dispose(); keysWorkingSchedule = null; }
			if (keysPatientMedLabTestResult != null) { keysPatientMedLabTestResult.Dispose(); keysPatientMedLabTestResult = null; }
			if (keysWard != null) { keysWard.Dispose(); keysWard = null; }
			if (keysrefDepreciationType != null) { keysrefDepreciationType.Dispose(); keysrefDepreciationType = null; }
			if (keysDDI != null) { keysDDI.Dispose(); keysDDI = null; }
			if (keysHIServiceItems != null) { keysHIServiceItems.Dispose(); keysHIServiceItems = null; }
			if (keysrefDiagnosis != null) { keysrefDiagnosis.Dispose(); keysrefDiagnosis = null; }
			if (keysHistoricalAuditData != null) { keysHistoricalAuditData.Dispose(); keysHistoricalAuditData = null; }
			if (keysWardInDept != null) { keysWardInDept.Dispose(); keysWardInDept = null; }
			if (keysPatientSpecimen != null) { keysPatientSpecimen.Dispose(); keysPatientSpecimen = null; }
			if (keysHosFeeTransDetails != null) { keysHosFeeTransDetails.Dispose(); keysHosFeeTransDetails = null; }
			//if (keysTrigs != null) { keysTrigs.Dispose(); keysTrigs = null; }
			if (keysICD10 != null) { keysICD10.Dispose(); keysICD10 = null; }
			if (keysrefDistrict != null) { keysrefDistrict.Dispose(); keysrefDistrict = null; }
			if (keysrefEthnicGroup != null) { keysrefEthnicGroup.Dispose(); keysrefEthnicGroup = null; }
			if (keysrefDrugKind != null) { keysrefDrugKind.Dispose(); keysrefDrugKind = null; }
			if (keysICDChapter != null) { keysICDChapter.Dispose(); keysICDChapter = null; }
			if (keysICDGroup != null) { keysICDGroup.Dispose(); keysICDGroup = null; }
			if (keysSpecifiedParaclinical != null) { keysSpecifiedParaclinical.Dispose(); keysSpecifiedParaclinical = null; }
			if (keysrefElthnic != null) { keysrefElthnic.Dispose(); keysrefElthnic = null; }
			if (keysDiagDescribeTmp != null) { keysDiagDescribeTmp.Dispose(); keysDiagDescribeTmp = null; }
			if (keysTestOnPatientSpecimen != null) { keysTestOnPatientSpecimen.Dispose(); keysTestOnPatientSpecimen = null; }
			if (keysrefExamAction != null) { keysrefExamAction.Dispose(); keysrefExamAction = null; }
			if (keysPersonalProperty != null) { keysPersonalProperty.Dispose(); keysPersonalProperty = null; }
			if (keysrefProblem != null) { keysrefProblem.Dispose(); keysrefProblem = null; }
			if (keysDrAdviceTmp != null) { keysDrAdviceTmp.Dispose(); keysDrAdviceTmp = null; }
			if (keysrefExamObservation != null) { keysrefExamObservation.Dispose(); keysrefExamObservation = null; }
			if (keysDrMedicineAdvice != null) { keysDrMedicineAdvice.Dispose(); keysDrMedicineAdvice = null; }
			if (keysDrMedicineTmp != null) { keysDrMedicineTmp.Dispose(); keysDrMedicineTmp = null; }
			if (keysrefHL7 != null) { keysrefHL7.Dispose(); keysrefHL7 = null; }
			if (keysDrPrescriptionTmp != null) { keysDrPrescriptionTmp.Dispose(); keysDrPrescriptionTmp = null; }
			if (keysHospitalFeeTransaction != null) { keysHospitalFeeTransaction.Dispose(); keysHospitalFeeTransaction = null; }
			if (keysPatientCommonMedRecord != null) { keysPatientCommonMedRecord.Dispose(); keysPatientCommonMedRecord = null; }
			if (keysHealthCareQueue != null) { keysHealthCareQueue.Dispose(); keysHealthCareQueue = null; }
			if (keysAlert != null) { keysAlert.Dispose(); keysAlert = null; }
			if (keysrefHumanLanguage != null) { keysrefHumanLanguage.Dispose(); keysrefHumanLanguage = null; }
			if (keysPatient != null) { keysPatient.Dispose(); keysPatient = null; }
			if (keysPatientMedRecord != null) { keysPatientMedRecord.Dispose(); keysPatientMedRecord = null; }
			if (keysrefImmunization != null) { keysrefImmunization.Dispose(); keysrefImmunization = null; }
			if (keysrefUnitOfMeasure != null) { keysrefUnitOfMeasure.Dispose(); keysrefUnitOfMeasure = null; }
			if (keysPersonRole != null) { keysPersonRole.Dispose(); keysPersonRole = null; }
			if (keysDrPrescriptionTmps != null) { keysDrPrescriptionTmps.Dispose(); keysDrPrescriptionTmps = null; }
			if (keysrefInstUniversity != null) { keysrefInstUniversity.Dispose(); keysrefInstUniversity = null; }
			if (keysAppointment != null) { keysAppointment.Dispose(); keysAppointment = null; }
			if (keysrefJobBand != null) { keysrefJobBand.Dispose(); keysrefJobBand = null; }
			if (keysASPNetRole != null) { keysASPNetRole.Dispose(); keysASPNetRole = null; }
			if (keysMedicalBill != null) { keysMedicalBill.Dispose(); keysMedicalBill = null; }
			if (keysrefInsurKind != null) { keysrefInsurKind.Dispose(); keysrefInsurKind = null; }
			if (keysASPNetRolePermission != null) { keysASPNetRolePermission.Dispose(); keysASPNetRolePermission = null; }
			if (keysPatientProblem != null) { keysPatientProblem.Dispose(); keysPatientProblem = null; }
			if (keysMedicalBills != null) { keysMedicalBills.Dispose(); keysMedicalBills = null; }
			if (keysrefInternalReceiptType != null) { keysrefInternalReceiptType.Dispose(); keysrefInternalReceiptType = null; }
			if (keysSocialAndHealthInsurance != null) { keysSocialAndHealthInsurance.Dispose(); keysSocialAndHealthInsurance = null; }
			if (keysASPNetToken != null) { keysASPNetToken.Dispose(); keysASPNetToken = null; }
			if (keysMedRecOutline != null) { keysMedRecOutline.Dispose(); keysMedRecOutline = null; }
			if (keysAdmNoTemp != null) { keysAdmNoTemp.Dispose(); keysAdmNoTemp = null; }
			if (keysASPNetUser != null) { keysASPNetUser.Dispose(); keysASPNetUser = null; }
			if (keysMedRecTmp != null) { keysMedRecTmp.Dispose(); keysMedRecTmp = null; }
			if (keysMedicalServicePackage != null) { keysMedicalServicePackage.Dispose(); keysMedicalServicePackage = null; }
			if (keysrefItemType != null) { keysrefItemType.Dispose(); keysrefItemType = null; }
			if (keysPatientPVID != null) { keysPatientPVID.Dispose(); keysPatientPVID = null; }
			if (keysMedSerInDept != null) { keysMedSerInDept.Dispose(); keysMedSerInDept = null; }
			if (keysrefJobTitle != null) { keysrefJobTitle.Dispose(); keysrefJobTitle = null; }
			if (keysMRParagraph != null) { keysMRParagraph.Dispose(); keysMRParagraph = null; }
			if (keysrefLimVitalSign != null) { keysrefLimVitalSign.Dispose(); keysrefLimVitalSign = null; }
			if (keysWorkPlace != null) { keysWorkPlace.Dispose(); keysWorkPlace = null; }
			if (keysGenericSocialNetwork != null) { keysGenericSocialNetwork.Dispose(); keysGenericSocialNetwork = null; }
			if (keysMOHServiceItems != null) { keysMOHServiceItems.Dispose(); keysMOHServiceItems = null; }
			if (keysrefEducationalLevel != null) { keysrefEducationalLevel.Dispose(); keysrefEducationalLevel = null; }
			if (keysASPNetUserClaims != null) { keysASPNetUserClaims.Dispose(); keysASPNetUserClaims = null; }
			if (keysAppliedMedStandard != null) { keysAppliedMedStandard.Dispose(); keysAppliedMedStandard = null; }
			if (keysASPNetUserLogin != null) { keysASPNetUserLogin.Dispose(); keysASPNetUserLogin = null; }
			if (keysArchitectureResources != null) { keysArchitectureResources.Dispose(); keysArchitectureResources = null; }
			if (keysPhysicalExamination != null) { keysPhysicalExamination.Dispose(); keysPhysicalExamination = null; }
			if (keysMRSection != null) { keysMRSection.Dispose(); keysMRSection = null; }
			if (keysPatientInvoices != null) { keysPatientInvoices.Dispose(); keysPatientInvoices = null; }
			if (keysAssignMedEquip != null) { keysAssignMedEquip.Dispose(); keysAssignMedEquip = null; }
			if (keysrefDischargeDisposition != null) { keysrefDischargeDisposition.Dispose(); keysrefDischargeDisposition = null; }
			if (keysASPNetUserRole != null) { keysASPNetUserRole.Dispose(); keysASPNetUserRole = null; }
			if (keysMRSectionOutline != null) { keysMRSectionOutline.Dispose(); keysMRSectionOutline = null; }
			if (keysSpecMedRecTmp != null) { keysSpecMedRecTmp.Dispose(); keysSpecMedRecTmp = null; }
			if (keysHealthInsurance != null) { keysHealthInsurance.Dispose(); keysHealthInsurance = null; }
			if (keysPrescription != null) { keysPrescription.Dispose(); keysPrescription = null; }
			if (keysPrivilegeRole != null) { keysPrivilegeRole.Dispose(); keysPrivilegeRole = null; }
			if (keysAcPrincDrug != null) { keysAcPrincDrug.Dispose(); keysAcPrincDrug = null; }
			if (keysInsuranceBeneficiary != null) { keysInsuranceBeneficiary.Dispose(); keysInsuranceBeneficiary = null; }
			if (keysAntagonistDrug != null) { keysAntagonistDrug.Dispose(); keysAntagonistDrug = null; }
			if (keysPatientTransaction != null) { keysPatientTransaction.Dispose(); keysPatientTransaction = null; }
			if (keysBedInRoom != null) { keysBedInRoom.Dispose(); keysBedInRoom = null; }
			if (keysRealms != null) { keysRealms.Dispose(); keysRealms = null; }
			if (keysrefPermission != null) { keysrefPermission.Dispose(); keysrefPermission = null; }
			if (keysInsuranceInterests != null) { keysInsuranceInterests.Dispose(); keysInsuranceInterests = null; }
			if (keysEmployee != null) { keysEmployee.Dispose(); keysEmployee = null; }
			if (keysContactDetails != null) { keysContactDetails.Dispose(); keysContactDetails = null; }
			if (keysInsuranceRegQueue != null) { keysInsuranceRegQueue.Dispose(); keysInsuranceRegQueue = null; }
			if (keysrefMedcnAdminRoute != null) { keysrefMedcnAdminRoute.Dispose(); keysrefMedcnAdminRoute = null; }
			if (keysServerLog != null) { keysServerLog.Dispose(); keysServerLog = null; }
			if (keysrefMedcnVehicleForm != null) { keysrefMedcnVehicleForm.Dispose(); keysrefMedcnVehicleForm = null; }
			if (keysContract != null) { keysContract.Dispose(); keysContract = null; }
			if (keysPromotionPlan != null) { keysPromotionPlan.Dispose(); keysPromotionPlan = null; }
			if (keysrefMedEquipResourceType != null) { keysrefMedEquipResourceType.Dispose(); keysrefMedEquipResourceType = null; }
			if (keysContractChange != null) { keysContractChange.Dispose(); keysContractChange = null; }
			if (keysSession != null) { keysSession.Dispose(); keysSession = null; }
			if (keysPrescriptionDetail != null) { keysPrescriptionDetail.Dispose(); keysPrescriptionDetail = null; }
			if (keysClinicalTrial != null) { keysClinicalTrial.Dispose(); keysClinicalTrial = null; }
			if (keysrefLookup != null) { keysrefLookup.Dispose(); keysrefLookup = null; }
			if (keysPromotionService != null) { keysPromotionService.Dispose(); keysPromotionService = null; }
			if (keysContractDocument != null) { keysContractDocument.Dispose(); keysContractDocument = null; }
			if (keysNetworkGuestAccount != null) { keysNetworkGuestAccount.Dispose(); keysNetworkGuestAccount = null; }
			if (keysQuotation != null) { keysQuotation.Dispose(); keysQuotation = null; }
			if (keysrefMedHisIndex != null) { keysrefMedHisIndex.Dispose(); keysrefMedHisIndex = null; }
			if (keysClinicalTrialResult != null) { keysClinicalTrialResult.Dispose(); keysClinicalTrialResult = null; }
			if (keysDHCRoomBlock != null) { keysDHCRoomBlock.Dispose(); keysDHCRoomBlock = null; }
			if (keysrefMedicalCondition != null) { keysrefMedicalCondition.Dispose(); keysrefMedicalCondition = null; }
			if (keysDisposableMDResource != null) { keysDisposableMDResource.Dispose(); keysDisposableMDResource = null; }
			if (keysOnlineQueue != null) { keysOnlineQueue.Dispose(); keysOnlineQueue = null; }
			if (keysrefMedicalServiceType != null) { keysrefMedicalServiceType.Dispose(); keysrefMedicalServiceType = null; }
			if (keysDrug != null) { keysDrug.Dispose(); keysDrug = null; }
			if (keysRegistrationInfo != null) { keysRegistrationInfo.Dispose(); keysRegistrationInfo = null; }
			if (keysrefQualification != null) { keysrefQualification.Dispose(); keysrefQualification = null; }
			if (keysPrescriptionHistory != null) { keysPrescriptionHistory.Dispose(); keysPrescriptionHistory = null; }
			if (keysrefPersGender != null) { keysrefPersGender.Dispose(); keysrefPersGender = null; }
			if (keysPrivacyClass != null) { keysPrivacyClass.Dispose(); keysPrivacyClass = null; }
			if (keysResearchPartnership != null) { keysResearchPartnership.Dispose(); keysResearchPartnership = null; }
			if (keysPerson != null) { keysPerson.Dispose(); keysPerson = null; }
			if (keysPtCodeCheckDigitTmp != null) { keysPtCodeCheckDigitTmp.Dispose(); keysPtCodeCheckDigitTmp = null; }
			if (keysBodyRegion != null) { keysBodyRegion.Dispose(); keysBodyRegion = null; }
			if (keysRxHoldConsultation != null) { keysRxHoldConsultation.Dispose(); keysRxHoldConsultation = null; }
			if (keysRegQueue != null) { keysRegQueue.Dispose(); keysRegQueue = null; }
			if (keysEquipHistory != null) { keysEquipHistory.Dispose(); keysEquipHistory = null; }
			if (keysClinicalIndicatorType != null) { keysClinicalIndicatorType.Dispose(); keysClinicalIndicatorType = null; }
			if (keysExamMaintenanceHistory != null) { keysExamMaintenanceHistory.Dispose(); keysExamMaintenanceHistory = null; }
			if (keysUserGroup != null) { keysUserGroup.Dispose(); keysUserGroup = null; }
			if (keysMedicalDiagnosticMethod != null) { keysMedicalDiagnosticMethod.Dispose(); keysMedicalDiagnosticMethod = null; }
			if (keysDrugConfign != null) { keysDrugConfign.Dispose(); keysDrugConfign = null; }
			if (keysSymptomIndicator != null) { keysSymptomIndicator.Dispose(); keysSymptomIndicator = null; }
			if (keysUsersInGroup != null) { keysUsersInGroup.Dispose(); keysUsersInGroup = null; }
			if (keysMedicalTestProcedure != null) { keysMedicalTestProcedure.Dispose(); keysMedicalTestProcedure = null; }
			if (keysAdvancedSpecialist != null) { keysAdvancedSpecialist.Dispose(); keysAdvancedSpecialist = null; }
			if (keysReminderNotices != null) { keysReminderNotices.Dispose(); keysReminderNotices = null; }
			if (keysForeignExchange != null) { keysForeignExchange.Dispose(); keysForeignExchange = null; }
			if (keysDrugInDepartment != null) { keysDrugInDepartment.Dispose(); keysDrugInDepartment = null; }
			if (keysHosRanking != null) { keysHosRanking.Dispose(); keysHosRanking = null; }
			if (keysAllergyIntolerance != null) { keysAllergyIntolerance.Dispose(); keysAllergyIntolerance = null; }
			if (keysEduLevel != null) { keysEduLevel.Dispose(); keysEduLevel = null; }
			if (keysrefRole != null) { keysrefRole.Dispose(); keysrefRole = null; }
			if (keysMedicalServiceItem != null) { keysMedicalServiceItem.Dispose(); keysMedicalServiceItem = null; }
			if (keysApplication != null) { keysApplication.Dispose(); keysApplication = null; }
			if (keysDrugPrice != null) { keysDrugPrice.Dispose(); keysDrugPrice = null; }
			if (keysrefShelfDrugLocation != null) { keysrefShelfDrugLocation.Dispose(); keysrefShelfDrugLocation = null; }
			if (keysHCProvider != null) { keysHCProvider.Dispose(); keysHCProvider = null; }
			if (keysMedImagingRepository != null) { keysMedImagingRepository.Dispose(); keysMedImagingRepository = null; }
			if (keysMedImagingTest != null) { keysMedImagingTest.Dispose(); keysMedImagingTest = null; }
			if (keysDeathSituationInfo != null) { keysDeathSituationInfo.Dispose(); keysDeathSituationInfo = null; }
			if (keysrefShift != null) { keysrefShift.Dispose(); keysrefShift = null; }
			if (keysUserAccount != null) { keysUserAccount.Dispose(); keysUserAccount = null; }
			if (keysMedImagingTestItems != null) { keysMedImagingTestItems.Dispose(); keysMedImagingTestItems = null; }
			if (keysInOutType != null) { keysInOutType.Dispose(); keysInOutType = null; }
			if (keysInOutwardDrug != null) { keysInOutwardDrug.Dispose(); keysInOutwardDrug = null; }
			if (keysMedLabRepository != null) { keysMedLabRepository.Dispose(); keysMedLabRepository = null; }
			if (keysInputMaskSetting != null) { keysInputMaskSetting.Dispose(); keysInputMaskSetting = null; }
			if (keysrefSIPrefix != null) { keysrefSIPrefix.Dispose(); keysrefSIPrefix = null; }
			if (keysMesrtConv != null) { keysMesrtConv.Dispose(); keysMesrtConv = null; }
			if (keysLotNumber != null) { keysLotNumber.Dispose(); keysLotNumber = null; }
			if (keysFamilyHistory != null) { keysFamilyHistory.Dispose(); keysFamilyHistory = null; }
			if (keysMedLabTest != null) { keysMedLabTest.Dispose(); keysMedLabTest = null; }
			if (keysrefSocialHisSeverity != null) { keysrefSocialHisSeverity.Dispose(); keysrefSocialHisSeverity = null; }
			if (keysrefSpecimenType != null) { keysrefSpecimenType.Dispose(); keysrefSpecimenType = null; }
			if (keysEmployeer != null) { keysEmployeer.Dispose(); keysEmployeer = null; }
			if (keysHCStakeholder != null) { keysHCStakeholder.Dispose(); keysHCStakeholder = null; }
			if (keysPharmaceuticalCompany != null) { keysPharmaceuticalCompany.Dispose(); keysPharmaceuticalCompany = null; }
			if (keysrefStoreHouse != null) { keysrefStoreHouse.Dispose(); keysrefStoreHouse = null; }
			if (keysHIAdmission != null) { keysHIAdmission.Dispose(); keysHIAdmission = null; }
			if (keysHCRoomBlock != null) { keysHCRoomBlock.Dispose(); keysHCRoomBlock = null; }
			if (keysrefAcademicTile != null) { keysrefAcademicTile.Dispose(); keysrefAcademicTile = null; }
			if (keysJobHistory != null) { keysJobHistory.Dispose(); keysJobHistory = null; }
			if (keysPriceList != null) { keysPriceList.Dispose(); keysPriceList = null; }
			if (keysHospitalizationHistory != null) { keysHospitalizationHistory.Dispose(); keysHospitalizationHistory = null; }
			if (keysrefFAMRelationship != null) { keysrefFAMRelationship.Dispose(); keysrefFAMRelationship = null; }
			if (keysrefTimeFrame != null) { keysrefTimeFrame.Dispose(); keysrefTimeFrame = null; }
			if (keysHospitalSpecialist != null) { keysHospitalSpecialist.Dispose(); keysHospitalSpecialist = null; }
			if (keysrefActiviePrinciple != null) { keysrefActiviePrinciple.Dispose(); keysrefActiviePrinciple = null; }
			if (keysrefAdmissionType != null) { keysrefAdmissionType.Dispose(); keysrefAdmissionType = null; }
			if (keysMedicalEquimentsResources != null) { keysMedicalEquimentsResources.Dispose(); keysMedicalEquimentsResources = null; }
			if (keysrefAdmReferralType != null) { keysrefAdmReferralType.Dispose(); keysrefAdmReferralType = null; }
			if (keysProvidableDrugs != null) { keysProvidableDrugs.Dispose(); keysProvidableDrugs = null; }
			if (keysrefAllergyCategory != null) { keysrefAllergyCategory.Dispose(); keysrefAllergyCategory = null; }
			if (keysrefTransactionType != null) { keysrefTransactionType.Dispose(); keysrefTransactionType = null; }
			if (keysJobModel != null) { keysJobModel.Dispose(); keysJobModel = null; }
			if (keysAssignmentSchedule != null) { keysAssignmentSchedule.Dispose(); keysAssignmentSchedule = null; }
			if (keysrefOccupation != null) { keysrefOccupation.Dispose(); keysrefOccupation = null; }
			if (keysBusySchedule != null) { keysBusySchedule.Dispose(); keysBusySchedule = null; }
			//if (keysAdmNoTempHolding != null) { keysAdmNoTempHolding.Dispose(); keysAdmNoTempHolding = null; }
			if (keysrefTypeAbsent != null) { keysrefTypeAbsent.Dispose(); keysrefTypeAbsent = null; }
			if (keysrefAllergyIndex != null) { keysrefAllergyIndex.Dispose(); keysrefAllergyIndex = null; }
			if (keysLanguageLevel != null) { keysLanguageLevel.Dispose(); keysLanguageLevel = null; }
			if (keysrefPersMaritalStatus != null) { keysrefPersMaritalStatus.Dispose(); keysrefPersMaritalStatus = null; }
			if (keysOrganization != null) { keysOrganization.Dispose(); keysOrganization = null; }
			if (keysEmpAllocation != null) { keysEmpAllocation.Dispose(); keysEmpAllocation = null; }
			if (keysNextOfKins != null) { keysNextOfKins.Dispose(); keysNextOfKins = null; }
			if (keysHospitalizationHistoryDetails != null) { keysHospitalizationHistoryDetails.Dispose(); keysHospitalizationHistoryDetails = null; }
			if (keysrefCareerMOH != null) { keysrefCareerMOH.Dispose(); keysrefCareerMOH = null; }
			if (keysrefAnnTemp != null) { keysrefAnnTemp.Dispose(); keysrefAnnTemp = null; }
			if (keysPatientBed != null) { keysPatientBed.Dispose(); keysPatientBed = null; }
			if (keysImmunizationHistory != null) { keysImmunizationHistory.Dispose(); keysImmunizationHistory = null; }
			if (keysrefAppConfig != null) { keysrefAppConfig.Dispose(); keysrefAppConfig = null; }
			if (keysEmployeeAnnualLeave != null) { keysEmployeeAnnualLeave.Dispose(); keysEmployeeAnnualLeave = null; }
			if (keysrefWard != null) { keysrefWard.Dispose(); keysrefWard = null; }
			if (keysPatientBedFeatures != null) { keysPatientBedFeatures.Dispose(); keysPatientBedFeatures = null; }
			if (keysrefBloodType != null) { keysrefBloodType.Dispose(); keysrefBloodType = null; }
			if (keysPatientInBedRoom != null) { keysPatientInBedRoom.Dispose(); keysPatientInBedRoom = null; }
			if (keysMedLabTestItems != null) { keysMedLabTestItems.Dispose(); keysMedLabTestItems = null; }
			if (keysScheduleDoingTaskLog != null) { keysScheduleDoingTaskLog.Dispose(); keysScheduleDoingTaskLog = null; }
			if (keysrefProviderType != null) { keysrefProviderType.Dispose(); keysrefProviderType = null; }
			if (keysBloodbank != null) { keysBloodbank.Dispose(); keysBloodbank = null; }
			if (keysOccCareerMOH != null) { keysOccCareerMOH.Dispose(); keysOccCareerMOH = null; }
			if (keysEmployeeLeaveTaken != null) { keysEmployeeLeaveTaken.Dispose(); keysEmployeeLeaveTaken = null; }
			if (keysResource != null) { keysResource.Dispose(); keysResource = null; }

        }

	}

	public enum ETable 
	{
		MedEnctrDiagnosis,
		ParaClinicalExamGroup,
		BloodDonation,
		EmpWorkSchedule,
		MedicalClaimService,
		ParaClinicalReq,
		Donor,
		ResourceLog,
		refCertification,
		MedicalConditionRecord,
		PatientVitalSign,
		DonorMedicalConditions,
		InsuranceCompany,
		refCityProvince,
		DonorMedication,
		EventHoliday,
		RoomAllocation,
		refCLMeasurement,
		MedicalEncounter,
		SeparationOfBlood,
		MedicationHistory,
		TestBlood,
		StdKSection,
		refVitalSign,
		refCommonTerm,
		Operations,
		MiscDocuments,
		AttachedDoc,
		Supplier,
		refReligion,
		OperationSchedule,
		ChainMedicalServices,
		DocItem,
		PastPersonHistory,
		ParaClinicalReqDetails,
		PatientAdmission,
		refCountry,
		PatientAddressHistory,
		refPersRace,
		OpSkedDistibution,
		PatientDiagnosticImaging,
		EquivMedService,
		refCurrency,
		PatientClassHistory,
		RescrUsedInOperation,
		TechnicalInspectionAgency,
		PatientClassification,
		refDepartment,
		WorkingDay,
		HIServiceItem,
		WorkingSchedule,
		PatientMedLabTestResult,
		Ward,
		refDepreciationType,
		DDI,
		HIServiceItems,
		refDiagnosis,
		HistoricalAuditData,
		WardInDept,
		PatientSpecimen,
		HosFeeTransDetails,
		Trigs,
		ICD10,
		refDistrict,
		refEthnicGroup,
		refDrugKind,
		ICDChapter,
		ICDGroup,
		SpecifiedParaclinical,
		refElthnic,
		DiagDescribeTmp,
		TestOnPatientSpecimen,
		refExamAction,
		PersonalProperty,
		refProblem,
		DrAdviceTmp,
		refExamObservation,
		DrMedicineAdvice,
		DrMedicineTmp,
		refHL7,
		DrPrescriptionTmp,
		HospitalFeeTransaction,
		PatientCommonMedRecord,
		HealthCareQueue,
		Alert,
		refHumanLanguage,
		Patient,
		PatientMedRecord,
		refImmunization,
		refUnitOfMeasure,
		PersonRole,
		DrPrescriptionTmps,
		refInstUniversity,
		Appointment,
		refJobBand,
		ASPNetRole,
		MedicalBill,
		refInsurKind,
		ASPNetRolePermission,
		PatientProblem,
		MedicalBills,
		refInternalReceiptType,
		SocialAndHealthInsurance,
		ASPNetToken,
		MedRecOutline,
		AdmNoTemp,
		ASPNetUser,
		MedRecTmp,
		MedicalServicePackage,
		refItemType,
		PatientPVID,
		MedSerInDept,
		refJobTitle,
		MRParagraph,
		refLimVitalSign,
		WorkPlace,
		GenericSocialNetwork,
		MOHServiceItems,
		refEducationalLevel,
		ASPNetUserClaims,
		AppliedMedStandard,
		ASPNetUserLogin,
		ArchitectureResources,
		PhysicalExamination,
		MRSection,
		PatientInvoices,
		AssignMedEquip,
		refDischargeDisposition,
		ASPNetUserRole,
		MRSectionOutline,
		SpecMedRecTmp,
		HealthInsurance,
		Prescription,
		PrivilegeRole,
		AcPrincDrug,
		InsuranceBeneficiary,
		AntagonistDrug,
		PatientTransaction,
		BedInRoom,
		Realms,
		refPermission,
		InsuranceInterests,
		Employee,
		ContactDetails,
		InsuranceRegQueue,
		refMedcnAdminRoute,
		ServerLog,
		refMedcnVehicleForm,
		Contract,
		PromotionPlan,
		refMedEquipResourceType,
		ContractChange,
		Session,
		PrescriptionDetail,
		ClinicalTrial,
		refLookup,
		PromotionService,
		ContractDocument,
		NetworkGuestAccount,
		Quotation,
		refMedHisIndex,
		ClinicalTrialResult,
		DHCRoomBlock,
		refMedicalCondition,
		DisposableMDResource,
		OnlineQueue,
		refMedicalServiceType,
		Drug,
		RegistrationInfo,
		refQualification,
		PrescriptionHistory,
		refPersGender,
		PrivacyClass,
		ResearchPartnership,
		Person,
		PtCodeCheckDigitTmp,
		BodyRegion,
		RxHoldConsultation,
		RegQueue,
		EquipHistory,
		ClinicalIndicatorType,
		ExamMaintenanceHistory,
		UserGroup,
		MedicalDiagnosticMethod,
		DrugConfign,
		SymptomIndicator,
		UsersInGroup,
		MedicalTestProcedure,
		AdvancedSpecialist,
		ReminderNotices,
		ForeignExchange,
		DrugInDepartment,
		HosRanking,
		AllergyIntolerance,
		EduLevel,
		refRole,
		MedicalServiceItem,
		Application,
		DrugPrice,
		refShelfDrugLocation,
		HCProvider,
		MedImagingRepository,
		MedImagingTest,
		DeathSituationInfo,
		refShift,
		UserAccount,
		MedImagingTestItems,
		InOutType,
		InOutwardDrug,
		MedLabRepository,
		InputMaskSetting,
		refSIPrefix,
		MesrtConv,
		LotNumber,
		FamilyHistory,
		MedLabTest,
		refSocialHisSeverity,
		refSpecimenType,
		Employeer,
		HCStakeholder,
		PharmaceuticalCompany,
		refStoreHouse,
		HIAdmission,
		HCRoomBlock,
		refAcademicTile,
		JobHistory,
		PriceList,
		HospitalizationHistory,
		refFAMRelationship,
		refTimeFrame,
		HospitalSpecialist,
		refActiviePrinciple,
		refAdmissionType,
		MedicalEquimentsResources,
		refAdmReferralType,
		ProvidableDrugs,
		refAllergyCategory,
		refTransactionType,
		JobModel,
		AssignmentSchedule,
		refOccupation,
		BusySchedule,
		AdmNoTempHolding,
		refTypeAbsent,
		refAllergyIndex,
		LanguageLevel,
		refPersMaritalStatus,
		Organization,
		EmpAllocation,
		NextOfKins,
		HospitalizationHistoryDetails,
		refCareerMOH,
		refAnnTemp,
		PatientBed,
		ImmunizationHistory,
		refAppConfig,
		EmployeeAnnualLeave,
		refWard,
		PatientBedFeatures,
		refBloodType,
		PatientInBedRoom,
		MedLabTestItems,
		ScheduleDoingTaskLog,
		refProviderType,
		Bloodbank,
		OccCareerMOH,
		EmployeeLeaveTaken,
		Resource
	}

}

